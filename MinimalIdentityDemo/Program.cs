using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalIdentityDemo;
using MinimalIdentityDemo.Models;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});
builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
    .AddIdentityCookies()
    .ApplicationCookie!.Configure(opt => opt.Events = new CookieAuthenticationEvents()
    {
        OnRedirectToLogin = ctx =>
        {
            ctx.Response.StatusCode = 401;
            return Task.CompletedTask;
        }
    });
builder.Services.AddAuthorizationBuilder();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentityCore<MyUser>().AddEntityFrameworkStores<ApplicationDbContext>().AddApiEndpoints();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGroup("/account").MapIdentityApi<MyUser>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.MapGet("/me", (ClaimsPrincipal user) => Results.Ok($"Hello, {user.Identity?.Name}!"))
    .RequireAuthorization();

app.MapPost("/cust/register", async (
    [FromBody] RegisterUserDto userDto, 
    UserManager<MyUser> userManager,
    ApplicationDbContext context) =>
{
    if (await context.Users.AnyAsync(u => u.Email == userDto.Email))
    {
        return Results.BadRequest(new { message = "Email already exists" });
    }
    var user = new MyUser
    {
        UserName = userDto.Email,
        Email = userDto.Email,
        FirstName = userDto.FirstName, 
        LastName = userDto.LastName,
        PhoneNumber = userDto.PhoneNumber,
    };

    var result = await userManager.CreateAsync(user, userDto.Password!);

    if (result.Succeeded)
    {
        return Results.Created($"/{user.Id}", new { user.Id, user.Email, user.FirstName, userDto.Password });
    }

    return Results.BadRequest(result.Errors);
}).WithTags("Users");

app.MapPost("/cust/logout", async (
    SignInManager<MyUser> signInManager, 
    [FromBody] object userTologout) =>
{
    if (userTologout is not null)
    {
        await signInManager.SignOutAsync();
        return Results.Ok();
    }
    return Results.NotFound();
}).RequireAuthorization();

//app.MapPost("/login", async ([FromBody] LoginRequest request) =>
//{
//    if (request.Email == "test@example.com" && request.Password == "password123")
//    {
//        var tokenString = GenerateJwtToken(request.Email);
//        return Results.Ok(new { Token = tokenString });
//    }
//    return Results.BadRequest("Invalid credentials");
//});

app.Run();


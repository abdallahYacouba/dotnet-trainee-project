using BlogApp.Model;
using BlogApp.PostDbContexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// https://www.youtube.com/watch?v=SryQxUeChMc&list=PLdo4fOcmZ0oX7uTkjYwvCJDG2qhcSzwZ6
// Entity framework see => https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-6.0

builder.Services.AddDbContext<BlogAppDbContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("BlogAppStringConnection")));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Blog.Service", Version = "v1" });
}); // 1
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(
    JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "https://yourdomain.com",
            ValidAudience = "https://yourdomain.com",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("tuuyfghusdgfhsdgfhedguy43@/ghsh1234567890"))
        };
});
var app = builder.Build();

// 1 =>  Package Name Swashbuckle.AspNetCore
// Swagger configuration see => https://docs.microsoft.com/en-us/aspnet/core/tutorials/get-started-with-aspnet-core?view=aspnetcore-6.0&tabs=visual-studio#add-swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// For security JWT
app.UseAuthentication();
app.UseAuthorization();
// Get all Posts data from the database
app.MapGet("/voiture", async (BlogAppDbContext context) => { 
    var dataFromDatabase = await context.Voitures.ToListAsync();
    return Results.Ok(dataFromDatabase);
});
app.MapGet("/posts", async (BlogAppDbContext context) => { 
    var dataFromDatabase = await context.Posts.ToListAsync();
    return Results.Ok(dataFromDatabase);
}).RequireAuthorization();

app.MapGet("/gettoken", () =>
{
    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.UTF8.GetBytes("tuuyfghusdgfhsdgfhedguy43@/ghsh1234567890");
    var tokenDescriptor = new SecurityTokenDescriptor
    {
        Subject = new ClaimsIdentity(),
        Expires = DateTime.UtcNow.AddHours(1),
        Issuer = "https://yourdomain.com",
        Audience = "https://yourdomain.com",
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    };
    var token = tokenHandler.CreateToken(tokenDescriptor);
    var tokenString = tokenHandler.WriteToken(token);

    return Results.Ok(tokenString);
});

// Get a specific Post data from the database
app.MapGet("/posts/{id:int}", async (int id, BlogAppDbContext context) => {
    var dataFromDatabase = await context.Posts.FindAsync(id);
    return dataFromDatabase is not null 
    ? Results.Ok(dataFromDatabase) 
    : Results.NotFound();
});

// Add a new Post to the database
app.MapPost("/posts", async (Post post, BlogAppDbContext context) => {
    context.Posts.Add(post);
    await context.SaveChangesAsync();
    return Results.Created($"/posts/{post.Id}", post);
});
// Update an existing Post in the database
app.MapPut("/posts/{id}", async (int id, Post post, BlogAppDbContext context) => {
    if (id != post.Id)
        return Results.BadRequest();

    context.Entry(post).State = EntityState.Modified;
    try
    {
        await context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!await context.Posts.AnyAsync(p => p.Id == id))
        {
            return Results.NotFound();
        }
        throw;
    }
    return Results.NoContent();
});
// Delete a Post from the database
app.MapDelete("/posts/{id}", async (int id, BlogAppDbContext context) => {
    var post = await context.Posts.FindAsync(id);
    if (post is null)
        return Results.NotFound();
    context.Posts.Remove(post);
    await context.SaveChangesAsync();
    return Results.NoContent();
});


app.Run();

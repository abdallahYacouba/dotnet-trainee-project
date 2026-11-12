using ApiTrainee.DataContext;
using ApiTrainee.EndPointsFilter;
using ApiTrainee.EndPointsHandler;
using ApiTrainee.Models.Entities;
using ApiTrainee.Models.ModelWrapper;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Xml.Linq;

int[] lockedIdList = { 4, 5, 6, 7, 8 };

var builder = WebApplication.CreateBuilder(args);


//DataBase string connection
builder.Services.AddDbContext<TraineeDbContext>(
    o => o.UseSqlite(builder.Configuration["ConnectionStrings:TraineeDBConnectionString"]));


// Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// JWT token
// Security JWT Nuget Install : Microsoft.AspNetCore.Authentication.JwtBearer
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
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("A_Not_Very_Secret_Key_1234567890"))
                };
});

// Swagger doc OpenApi install => NuGet Swashbuckle.AspNetCore
//builder.Services.AddSwaggerGen();
//for custome see
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new()
    {
        Title = builder.Environment.ApplicationName,
        Version = "v1",
        Contact = new()
        {
            Name = "Abdallah Y.",
            Email = "abdallyacali@gmail.com",
            Url = new Uri("https://www.japprend.ne")
        },
        Description = "Abdallah Trainee Minimal API - Swagger",
        License = new Microsoft.OpenApi.Models.OpenApiLicense(),
        TermsOfService = new("https://www.japprend.ne")
    });
});



var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{builder.Environment.ApplicationName} v1"));
}

// Grouping
var traineeEndpoinds = app.MapGroup("/trainee");
var traineeWithIdEndpoinds = traineeEndpoinds.MapGroup("/{id:int}");

// Routes
traineeEndpoinds.MapGet("", TraineeHandler.GetAllTraineeAsync)
                .RequireAuthorization(); ;
traineeWithIdEndpoinds.MapGet("", TraineeHandler.GetTraineeByIdAsync)
                      .WithName("GetTrainee");
traineeEndpoinds.MapPost("", TraineeHandler.CreateTraineeAsync)
                .AddEndpointFilter<ValidationAnnotationFilter>();
traineeWithIdEndpoinds.MapPut("", TraineeHandler.UpdateTraineeAsync);
traineeWithIdEndpoinds.MapDelete("", TraineeHandler.DeleteTraineeAsync)
                      .AddEndpointFilter(new LockedIdFilter(lockedId: lockedIdList));
traineeEndpoinds.MapMethods("", [HttpMethod.Options.Method], (HttpResponse response) =>
{
    response.Headers.Append("Allow", "GET, OPTIONS, POST, PUT, DELETE");
    return Results.Ok();
});

// Jwt
app.MapGet("/gettoken", () =>
{
    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.UTF8.GetBytes("A_Not_Very_Secret_Key_1234567890");
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

// For security JWT
app.UseAuthentication();
app.UseAuthorization();

app.Run();

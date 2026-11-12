using ApiTrainee.DataContext;
using ApiTrainee.EndPointsFilter;
using ApiTrainee.EndPointsHandler;
using ApiTrainee.Models.Entities;
using ApiTrainee.Models.ModelWrapper;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

int[] lockedIdList = { 4, 5, 6, 7, 8 };

var builder = WebApplication.CreateBuilder(args);
//DataBase string connection
builder.Services.AddDbContext<TraineeDbContext>(
    o => o.UseSqlite(builder.Configuration["ConnectionStrings:TraineeDBConnectionString"]));
// Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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
traineeEndpoinds.MapGet("", TraineeHandler.GetAllTraineeAsync);
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


app.MapGet("", (HttpContext httpcontext, HttpRequest request , HttpResponse response, HttpClient client) =>
{
    
});

app.Run();

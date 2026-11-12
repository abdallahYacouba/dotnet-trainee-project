using ApiTrainee.DataContext;
using ApiTrainee.EndPointsHandler;
using ApiTrainee.Models.Entities;
using ApiTrainee.Models.ModelWrapper;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);
//DataBase string connection
builder.Services.AddDbContext<TraineeDbContext>(
    o => o.UseSqlite(builder.Configuration["ConnectionStrings:TraineeDBConnectionString"]));
// Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Grouping
var traineeEndpoinds = app.MapGroup("/trainee");
var traineeWithIdEndpoinds = traineeEndpoinds.MapGroup("/{id:int}");

traineeEndpoinds.MapGet("", TraineeHandler.GetAllTraineeAsync);
traineeWithIdEndpoinds.MapGet("", TraineeHandler.GetTraineeByIdAsync).WithName("GetTrainee");
traineeEndpoinds.MapPost("", TraineeHandler.CreateTraineeAsync);
traineeWithIdEndpoinds.MapPut("", TraineeHandler.UpdateTraineeAsync);
traineeWithIdEndpoinds.MapDelete("", TraineeHandler.DeleteTraineeAsync);
traineeEndpoinds.MapMethods("", [HttpMethod.Options.Method], (HttpResponse response) =>
{
    response.Headers.Append("Allow", "GET, OPTIONS, POST, PUT, DELETE");
    return Results.Ok();
});

app.Run();

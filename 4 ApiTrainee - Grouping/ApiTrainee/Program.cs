using ApiTrainee.DataContext;
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

// Get all Trainee
traineeEndpoinds.MapGet("",
    async Task<Ok<IEnumerable<TraineeDto>>> 
    (TraineeDbContext context,IMapper mapper, [FromQuery] string? status) =>
{
    return TypedResults.Ok(
        mapper.Map<IEnumerable<TraineeDto>>(await context.Trainees
            .Where(s => status == null || s.Status!.Contains(status))
            .ToListAsync())
    );
});

// Get a trainee by ID
traineeWithIdEndpoinds.MapGet("", 
    async Task<Results<NotFound, Ok<TraineeDto>>>
    (TraineeDbContext context, IMapper mapper, int id) =>
{
    //Fetch requested trainee from database
    var traineeFromDb = await context.Trainees.SingleOrDefaultAsync(x => x.Id == id);
    if (traineeFromDb is null)
        return TypedResults.NotFound();

    return TypedResults.Ok(mapper.Map<TraineeDto>(traineeFromDb));
}).WithName("GetTrainee"); ;

// Create a trainee
traineeEndpoinds.MapPost("", 
    async Task<CreatedAtRoute<TraineeDto>>
    (TraineeDbContext context, TraineeForCreatingDto traineeForCreatingDto, IMapper mapper) =>
{
    var traineeEntity = mapper.Map<Trainee>(traineeForCreatingDto);
    // Add to database
    context.Add(traineeEntity);
    await context.SaveChangesAsync();

    // Generate Link for redirection by Uri Name
    var taineeToRetrun = mapper.Map<TraineeDto>(traineeEntity);
    
    return TypedResults.CreatedAtRoute(taineeToRetrun, "GetTrainee", new { id = taineeToRetrun.Id });
});

// Update a trainee's details
traineeWithIdEndpoinds.MapPut("", 
    async Task<Results<NotFound, NoContent>>
    (TraineeDbContext context, TraineeForUpdatingDto traineeForUpdatingDto, IMapper mapper, int id) =>
{
    //Fetch trainee from database
    var traineeFromDb = await context.Trainees.SingleOrDefaultAsync(x => x.Id == id);
    if (traineeFromDb is null)
        return TypedResults.NotFound();

    mapper.Map(traineeForUpdatingDto, traineeFromDb);
    await context.SaveChangesAsync();

    return TypedResults.NoContent();
});

// Delete a trainee
traineeWithIdEndpoinds.MapDelete("", 
    async Task<Results<NotFound, NoContent>> 
    (TraineeDbContext context,int id) =>
{
    // Fetch the spy from the database
    var traineeFromDb = await context.Trainees.SingleOrDefaultAsync(x => x.Id == id);
    if (traineeFromDb == null)
        return TypedResults.NotFound();

    context.Trainees.Remove(traineeFromDb);
    await context.SaveChangesAsync();

    return TypedResults.NoContent();
});

// Options a trainee API
traineeEndpoinds.MapMethods("", [HttpMethod.Options.Method], (HttpResponse response) =>
{
    response.Headers.Append("Allow", "GET, OPTIONS, POST, PUT, DELETE");
    return Results.Ok();
});

app.Run();

using ApiTrainee.DataContext;
using ApiTrainee.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);
//DataBase string connection
builder.Services.AddDbContext<TraineeDbContext>(
    o => o.UseSqlite(builder.Configuration["ConnectionStrings:TraineeDBConnectionString"]));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// List all trainee
app.MapGet("/trainee", (TraineeDbContext context) =>
{
    var dataFromDb = context.Trainees.ToList();
    return Results.Ok(dataFromDb);
});

app.MapGet("/trainee", (TraineeDbContext context, [FromQuery] string? status, [FromQuery] int page = 0, [FromQuery] int nombre = 0) =>
{
    var dataFromDb = context.Trainees
    .Where(s => status == null || s.Status!.Contains(status))
    .ToList();

    if (page != 0 && nombre != 0)
    {
        var data = context.Trainees.Skip((page - 1) * nombre)
        .Take(nombre)
        .ToList();
        return Results.Ok(data);
    }

    return Results.Ok(dataFromDb);
});

// Get a trainee by ID
app.MapGet("/trainee/{id:int}", (TraineeDbContext context, int id) =>
{
    //Fetch requested trainee from database
    var traineeFromDb = context.Trainees.SingleOrDefault(x => x.Id == id);
    if (traineeFromDb is null)
        return Results.NotFound();
    return Results.Ok(traineeFromDb);
}).WithName("GetTrainee"); ;

// Create a trainee
app.MapPost("/trainee", (TraineeDbContext context, Trainee trainee) =>
{
    // Add to database
    context.Trainees.Add(trainee);
    context.SaveChanges();
    return Results.Created($"/trainee/{trainee.Id}", trainee);
});

// Update a trainee's details
app.MapPut("/trainee/{id:int}",
    async (TraineeDbContext context, Trainee trainee, int id) =>
    {
        //Fetch trainee from database
        var traineeFromDb = await context.Trainees.SingleOrDefaultAsync(x => x.Id == id);
        if (traineeFromDb is null)
            return Results.NotFound();

        context.Trainees.Add(traineeFromDb);
        await context.SaveChangesAsync();
        return Results.NoContent();
});

// Delete a trainee
app.MapDelete("/trainee/{id:int}", (TraineeDbContext context,int id) =>
{
    // Fetch the spy from the database
    var traineeFromDb = context.Trainees.SingleOrDefault(x => x.Id == id);
    if (traineeFromDb is null)
        return Results.NotFound();

    context.Trainees.Remove(traineeFromDb);
    context.SaveChanges();
    return Results.NoContent();
});

// Options a trainee
app.MapMethods("/trainee", [HttpMethod.Options.Method], (HttpResponse response) =>
{
    response.Headers.Append("Allow", "GET, OPTIONS, POST, PUT, DELETE");
    return Results.Ok();
});

app.Run();

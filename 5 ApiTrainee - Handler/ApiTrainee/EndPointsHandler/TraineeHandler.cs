using ApiTrainee.DataContext;
using ApiTrainee.Models.Entities;
using ApiTrainee.Models.ModelWrapper;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTrainee.EndPointsHandler;
public static class TraineeHandler
{
    // Get all Trainee
    public static async Task<Ok<IEnumerable<TraineeDto>>>
        GetAllTraineeAsync(TraineeDbContext context, IMapper mapper, [FromQuery] string? status)
    {
        return TypedResults.Ok(
            mapper.Map<IEnumerable<TraineeDto>>(await context.Trainees
            .Where(s => status == null || s.Status!.Contains(status))
            .ToListAsync())
        );
    }

    // Get Trainee By Id
    public static async Task<Results<NotFound, Ok<TraineeDto>>>
        GetTraineeByIdAsync(TraineeDbContext context, IMapper mapper, int id )
    {
        //Fetch requested trainee from database
        var traineeFromDb = await context.Trainees.SingleOrDefaultAsync(x => x.Id == id);
        if (traineeFromDb is null)
            return TypedResults.NotFound();

        return TypedResults.Ok(mapper.Map<TraineeDto>(traineeFromDb));
    }
    
    // Create Trainee
    public static async Task<CreatedAtRoute<TraineeDto>>
        CreateTraineeAsync(TraineeDbContext context, TraineeForCreatingDto traineeForCreatingDto, IMapper mapper)
    {
        var traineeEntity = mapper.Map<Trainee>(traineeForCreatingDto);
        // Add to database
        context.Add(traineeEntity);
        await context.SaveChangesAsync();

        // Generate Link for redirection by Uri Name
        var taineeToRetrun = mapper.Map<TraineeDto>(traineeEntity);

        return TypedResults.CreatedAtRoute(taineeToRetrun, "GetTrainee", new { id = taineeToRetrun.Id });

    }
    
    // Update trainee
    public static async Task<Results<NotFound, NoContent>> 
        UpdateTraineeAsync(TraineeDbContext context, TraineeForUpdatingDto traineeForUpdatingDto, IMapper mapper, int id)
    {
        //Fetch trainee from database
        var traineeFromDb = await context.Trainees.SingleOrDefaultAsync(x => x.Id == id);
        if (traineeFromDb is null)
            return TypedResults.NotFound();

        mapper.Map(traineeForUpdatingDto, traineeFromDb);
        await context.SaveChangesAsync();

        return TypedResults.NoContent();
    }
    
    // Delete Trainee
    public static async Task<Results<NotFound, NoContent>>
        DeleteTraineeAsync(TraineeDbContext context, int id)
    {
        // Fetch the spy from the database
        var traineeFromDb = await context.Trainees.SingleOrDefaultAsync(x => x.Id == id);
        if (traineeFromDb == null)
            return TypedResults.NotFound();

        context.Trainees.Remove(traineeFromDb);
        await context.SaveChangesAsync();

        return TypedResults.NoContent();
    }

}

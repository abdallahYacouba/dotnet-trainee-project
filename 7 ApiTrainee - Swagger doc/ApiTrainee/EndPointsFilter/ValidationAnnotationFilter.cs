
using ApiTrainee.Models.ModelWrapper;
using MiniValidation;

namespace ApiTrainee.EndPointsFilter;

public class ValidationAnnotationFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(
        EndpointFilterInvocationContext context, 
        EndpointFilterDelegate next)
    {
        var traineeForCreatingDto = context.GetArgument<TraineeForCreatingDto>(1);
        if (!MiniValidator.TryValidate(traineeForCreatingDto, out var validationError))
        {
            return TypedResults.ValidationProblem(validationError);
        }
        return await next(context);
    }
}

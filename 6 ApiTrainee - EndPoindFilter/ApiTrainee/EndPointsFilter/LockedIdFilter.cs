
namespace ApiTrainee.EndPointsFilter;

public class LockedIdFilter : IEndpointFilter
{
    private int[] _lockedId;
    private int exchangeId;

    public LockedIdFilter(int[] lockedId)
    {
        _lockedId = lockedId;
    }
    public async ValueTask<object?> InvokeAsync(
        EndpointFilterInvocationContext context, 
        EndpointFilterDelegate next)
    {
        if (context.HttpContext.Request.Method == "DELETE")
            exchangeId = context.GetArgument<int>(1);
        else
            throw new NotSupportedException("This filter is not supported for this Scenario");

        if (_lockedId.Contains(exchangeId))
        {
            return TypedResults.Problem(
                new()
                {
                    Status = 400,
                    Title = $"Task with id = {exchangeId} cannot be delete please contact your administrator",
                    Detail = "You cannot delete Perfection."
                }
            );
        }
        var result = await next.Invoke(context);
        return result;
    }
}

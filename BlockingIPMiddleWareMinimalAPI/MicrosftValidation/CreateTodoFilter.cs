
using MicrosftValidation.Models;

namespace MicrosftValidation;

public class CreateTodoFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(
        EndpointFilterInvocationContext context, 
        EndpointFilterDelegate next)
    {
        var todoItem = context.GetArgument<TodoItem>(0);
        if (todoItem.Assignee == "Abdallah Yacouba")
            return Results.Problem("Abdallah Yacouba connot be assigned a todoitem");
  
        return await next(context);
    }
}

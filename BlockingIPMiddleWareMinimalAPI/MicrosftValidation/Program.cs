using MicrosftValidation;
using MicrosftValidation.Models;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapPost("/todoitems", (TodoItem item) =>
{
    var validationResults = new List<ValidationResult>();
    var validationContext = new ValidationContext(item);
    bool isValid = Validator.TryValidateObject(
        item, validationContext, validationResults, true);
    if (!isValid)
    {
        return Results.BadRequest(validationResults);
    }
    //ToDoItems.Add(item);
    return Results.Created();
}).AddEndpointFilter<CreateTodoFilter>();
//app.MapPost("/todoitems", (TodoItem item) =>
//{
//    //ToDoItems.Add(item);
//    return Results.Created();
//}).AddEndpointFilter(async (context, next) =>
//{
//    var toDoItem = context.GetArgument<TodoItem>(0);
//    if (toDoItem.Assignee == "Joe Bloggs")
//        return Results.Problem("Joe Bloggs cannot be assigned todo items");

//    return await next(context);
//});

app.Run();

using Microsoft.AspNetCore.Mvc;
using MinimalApiDapper;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<DapperService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapPost("/employees",
    (Employee employee, [FromServices] DapperService dapperService) =>
{
});

app.Run();

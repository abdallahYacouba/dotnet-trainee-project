using ApiTrainee.EndPointsHandler;
using ApiTrainee.Extensions;


var builder = WebApplication.CreateBuilder(args);

// JWT token
// Security JWT Nuget Install : Microsoft.AspNetCore.Authentication.JwtBearer
builder.Services.AddAuthorization();
builder.Services.JwtBearerConfiguration();
// DataBase string connection
builder.Services.ConfigureSqlContext(builder.Configuration);
// Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Swagger doc OpenApi install => NuGet Swashbuckle.AspNetCore
//builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.SwaggerConfiguration(builder.Environment.ApplicationName);



var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{builder.Environment.ApplicationName} v1"));
}
// For security JWT
app.UseAuthentication();
app.UseAuthorization();


app.TraineeRegister();

app.MapGet("", () => { return Results.Ok("Welcome to the Trainee API! التفكير"); })
    .WithName("Welcome")
    .WithSummary("Welcome to the Trainee API")
    .WithDescription("This endpoint returns a welcome message for the Trainee API.")
    .Produces<string>(StatusCodes.Status200OK);

app.Run();

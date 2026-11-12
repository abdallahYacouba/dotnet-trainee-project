using ApiTrainee.EndPointsFilter;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiTrainee.EndPointsHandler;

public static class RouteBuilderExtensions
{
    private static int[] lockedIdList = { 4, 5, 6, 7, 8 };
    public static void TraineeRegister(this IEndpointRouteBuilder app)
    {
        // Jwt
        app.MapGet("/gettoken", () =>
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("A_Not_Very_Secret_Key_1234567890");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = "https://yourdomain.com",
                Audience = "https://yourdomain.com",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Results.Ok(tokenString);
        });
        // Grouping
        var traineeEndpoinds = app.MapGroup("/trainee");
        var traineeWithIdEndpoinds = traineeEndpoinds.MapGroup("/{id:int}");

        // Routes
        traineeEndpoinds.MapGet("", TraineeHandler.GetAllTraineeAsync);
        traineeWithIdEndpoinds.MapGet("", TraineeHandler.GetTraineeByIdAsync).WithName("GetTrainee");
        traineeEndpoinds.MapPost("", TraineeHandler.CreateTraineeAsync).AddEndpointFilter<ValidationAnnotationFilter>();
        traineeWithIdEndpoinds.MapPut("", TraineeHandler.UpdateTraineeAsync);
        traineeWithIdEndpoinds.MapDelete("", TraineeHandler.DeleteTraineeAsync).AddEndpointFilter(new LockedIdFilter(lockedId: lockedIdList));
        traineeEndpoinds.MapMethods("", [HttpMethod.Options.Method], (HttpResponse response) =>
        {
            response.Headers.Append("Allow", "GET, OPTIONS, POST, PUT, DELETE");
            return Results.Ok();
        });
    }
}

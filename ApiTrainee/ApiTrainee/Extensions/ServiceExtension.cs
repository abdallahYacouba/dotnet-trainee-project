using ApiTrainee.DataContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ApiTrainee.Extensions;

public static class ServiceExtension
{
    public static void ConfigureCors(this IServiceCollection services)
     => services.AddCors(options => {
         options.AddPolicy("CorsPolicy",
             builder => builder.AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader());
     });

    public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
       => services.AddDbContext<TraineeDbContext>(opts
           => opts.UseSqlite(configuration.GetConnectionString("TraineeDBConnectionString")));

    public static void SwaggerConfiguration(this IServiceCollection services, string appName)
        => services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new()
            {
                Title = appName,
                Version = "v1",
                Contact = new()
                {
                    Name = "Abdallah Y.",
                    Email = "abdallyacali@gmail.com",
                    Url = new Uri("https://www.japprend.ne")
                },
                Description = "Abdallah TRAINEE Minimal API - Swagger",
                License = new Microsoft.OpenApi.Models.OpenApiLicense(),
                TermsOfService = new("https://www.japprend.ne")
            });
        });

    public static void JwtBearerConfiguration(this IServiceCollection services)
        => services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
            options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "https://yourdomain.com",
                    ValidAudience = "https://yourdomain.com",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("A_Not_Very_Secret_Key_1234567890"))
                };
            });
}

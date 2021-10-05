using FactorialExerciseWebApi.Entities;
using FactorialExerciseWebApi.Interfaces;
using FactorialExerciseWebApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace FactorialExerciseWebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("TestingDB"));

        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IFactorialService, FactorialService>();
            services.AddScoped<IRepository, Repository>();
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Factorial API v1",
                    Version = "v1",
                });
            });
        }
    }
}

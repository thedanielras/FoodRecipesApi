using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodRecipesApi.Application.System.Commands.DbSeedCommand;
using FoodRecipesApi.Persistence;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FoodRecipesApi.WebApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var hostBuilder = CreateHostBuilder(args).Build();

            using (var scope = hostBuilder.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;               

                try
                {
                    var foodRecipesContext = serviceProvider.GetRequiredService<FoodRecipesDbContext>();
                    foodRecipesContext.Database.Migrate();

                    var mediator = serviceProvider.GetRequiredService<IMediator>();
                    await mediator.Send(new DbSeedCommand());
                }
                catch(Exception ex)
                {
                    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Error occurred while initializing the database");
                }              
            }

            hostBuilder.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

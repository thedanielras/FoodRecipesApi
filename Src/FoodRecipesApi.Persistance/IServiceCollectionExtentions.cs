using FoodRecipesApi.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRecipesApi.Persistence
{
    public static class IServiceCollectionExtentions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("FoodRecipesDB");

            services.AddDbContext<FoodRecipesDbContext>(options =>
                options.UseSqlServer(connection));

            services.AddScoped<IFoodRecipesDbContext>(provider => provider.GetService<FoodRecipesDbContext>());

            return services;
        }

    }
}

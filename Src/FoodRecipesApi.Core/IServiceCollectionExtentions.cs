using FoodRecipesApi.Application.Common.Mappers.Implementations;
using FoodRecipesApi.Application.Common.Mappers.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FoodRecipesApi.Application
{
    public static class IServiceCollectionExtentions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IRecipeMapper, RecipeMapper>();
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}

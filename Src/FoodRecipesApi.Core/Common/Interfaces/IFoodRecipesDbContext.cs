using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using FoodRecipesApi.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace FoodRecipesApi.Application.Common.Interfaces
{
    public interface IFoodRecipesDbContext
    {
        DbSet<Author> Authors { get; set; }

        DbSet<Recipe> Recipes { get; set; }
        
        DbSet<Ingredient> Ingredients { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

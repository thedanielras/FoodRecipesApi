using FoodRecipesApi.Application.Common.Interfaces;
using FoodRecipesApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FoodRecipesApi.Persistence
{
    public class FoodRecipesDbContext : DbContext, IFoodRecipesDbContext
    {
        public FoodRecipesDbContext(DbContextOptions<FoodRecipesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Recipe> Recipes { get; set; }      

        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FoodRecipesDbContext).Assembly);
        }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync();
        }
    }
}

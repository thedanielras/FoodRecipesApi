using FoodRecipesApi.Application.Common.Interfaces;
using FoodRecipesApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRecipesApi.Persistence
{
    public class FoodRecipesDbContext : DbContext, IFoodRecipesDbContext
    {
        public FoodRecipesDbContext(DbContextOptions<FoodRecipesDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FoodRecipesDbContext).Assembly);
        }
    }
}

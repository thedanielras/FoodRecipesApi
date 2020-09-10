using FoodRecipesApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRecipesApi.Persistence.Configuration
{
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.HasOne(r => r.Author)
                .WithMany(a => a.Recipes)
                .IsRequired();

            builder.HasMany(r => r.RecipeSteps)
                .WithOne(rs => rs.Recipe)
                .IsRequired();

            builder.Property(r => r.Title)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(r => r.Description)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(r => r.PreparationTime)
                .IsRequired();
            
            builder.Property(r => r.TotalTime)
                .IsRequired();

            builder.Property(r => r.ImageUrl)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}

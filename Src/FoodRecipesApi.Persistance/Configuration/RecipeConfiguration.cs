﻿using FoodRecipesApi.Domain.Entities;
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
                .HasForeignKey(r => r.AuthorId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasMany(r => r.RecipeSteps)
                .WithOne(rs => rs.Recipe)
                .HasForeignKey(rs => rs.RecipeId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasIndex(r => new { r.Title, r.AuthorId });

            builder.HasAlternateKey(r => new { r.Title, r.AuthorId });

            builder.Property(r => r.Title)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(r => r.Description)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(r => r.PreparationTimeInMinutes)
                .IsRequired();
            
            builder.Property(r => r.TotalTimeInMinutes)
                .IsRequired();

            builder.Property(r => r.ImageUrl)
                .HasMaxLength(250)
                .IsRequired();
        }
    }
}

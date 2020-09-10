using FoodRecipesApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRecipesApi.Persistence.Configuration
{
    class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasMany(a => a.Recipes)
                .WithOne(r => r.Author);

            builder.Property(a => a.Name)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(a => a.Surname)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(a => a.Born)
                .IsRequired();

            builder.Property(a => a.ImageUrl)
                .HasMaxLength(100);
        }
    }
}

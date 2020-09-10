using FoodRecipesApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRecipesApi.Persistence.Configuration
{
    class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.HasOne(i => i.Quantity)
               .WithOne(q => q.Ingredient)
               .HasForeignKey<Ingredient>(i => i.QuantityId)
               .IsRequired();

            builder.Property(i => i.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}

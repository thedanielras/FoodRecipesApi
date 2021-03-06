﻿using FoodRecipesApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRecipesApi.Persistence.Configuration
{
    class IngredientQuantityConfiguration : IEntityTypeConfiguration<IngredientQuantity>
    {
        public void Configure(EntityTypeBuilder<IngredientQuantity> builder)
        {
            builder.HasOne(iq => iq.Ingredient)
                .WithOne(i => i.Quantity)
                .HasForeignKey<IngredientQuantity>(i => i.IngredientId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(iq => iq.MeasurementUnit)
                .WithOne(mu => mu.IngredientQuantity)
                .HasForeignKey<IngredientQuantity>(iq => iq.MeasurementUnitId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}

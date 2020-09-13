using FoodRecipesApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRecipesApi.Persistence.Configuration
{
    class MeasurementUnitConfiguration : IEntityTypeConfiguration<MeasurementUnit>
    {
        public void Configure(EntityTypeBuilder<MeasurementUnit> builder)
        {
            builder.HasOne(mu => mu.IngredientQuantity)
                .WithOne(iq => iq.MeasurementUnit)
                .HasForeignKey<MeasurementUnit>(mu => mu.IngredientQuantityId);

            builder.Property(mu => mu.Unit)
                .HasMaxLength(75)
                .IsRequired();
        }
    }
}

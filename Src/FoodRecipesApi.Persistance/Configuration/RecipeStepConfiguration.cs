using FoodRecipesApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRecipesApi.Persistence.Configuration
{
    class RecipeStepConfiguration : IEntityTypeConfiguration<RecipeStep>
    {
        public void Configure(EntityTypeBuilder<RecipeStep> builder)
        {
            builder.HasOne(rs => rs.Recipe)
                 .WithMany(r => r.RecipeSteps)
                 .HasForeignKey(rs => rs.RecipeId);


            builder.Property(rs => rs.Instruction)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(rs => rs.ImageUrl)
                .HasMaxLength(100);
        }
    }
}

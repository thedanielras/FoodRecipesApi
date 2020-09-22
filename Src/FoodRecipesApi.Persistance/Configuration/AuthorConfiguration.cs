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
                .WithOne(r => r.Author)
                .HasForeignKey(r => r.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(a => new {
                a.Name,
                a.Surname,
                a.EmailAdress
            });

            builder.HasAlternateKey(a => new {
                a.Name,
                a.Surname,
                a.EmailAdress
            });

            builder.Property(a => a.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(a => a.Surname)
                .HasMaxLength(50)
                .IsRequired();  
            
            builder.Property(a => a.EmailAdress)
                .HasMaxLength(60)
                .IsRequired();         

            builder.Property(a => a.ImageUrl)
                .HasMaxLength(250);
        }
    }
}

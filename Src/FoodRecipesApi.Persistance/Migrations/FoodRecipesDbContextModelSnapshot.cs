﻿// <auto-generated />
using FoodRecipesApi.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FoodRecipesApi.Persistence.Migrations
{
    [DbContext(typeof(FoodRecipesDbContext))]
    partial class FoodRecipesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FoodRecipesApi.Domain.Entities.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAdress")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("AuthorId");

                    b.HasAlternateKey("Name", "Surname", "EmailAdress");

                    b.HasIndex("Name", "Surname", "EmailAdress");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("FoodRecipesApi.Domain.Entities.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<int>("QuantityId")
                        .HasColumnType("int");

                    b.HasKey("IngredientId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("FoodRecipesApi.Domain.Entities.IngredientQuantity", b =>
                {
                    b.Property<int>("IngredientQuantityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<int>("MeasurementUnitId")
                        .HasColumnType("int");

                    b.HasKey("IngredientQuantityId");

                    b.HasIndex("IngredientId")
                        .IsUnique();

                    b.ToTable("IngredientQuantity");
                });

            modelBuilder.Entity("FoodRecipesApi.Domain.Entities.MeasurementUnit", b =>
                {
                    b.Property<int>("MeasurementUnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IngredientQuantityId")
                        .HasColumnType("int");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(75)")
                        .HasMaxLength(75);

                    b.HasKey("MeasurementUnitId");

                    b.HasIndex("IngredientQuantityId")
                        .IsUnique();

                    b.ToTable("MeasurementUnit");
                });

            modelBuilder.Entity("FoodRecipesApi.Domain.Entities.Recipe", b =>
                {
                    b.Property<int>("RecipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<int>("PreparationTimeInMinutes")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<int>("TotalTimeInMinutes")
                        .HasColumnType("int");

                    b.HasKey("RecipeId");

                    b.HasAlternateKey("Title", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("Title", "AuthorId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("FoodRecipesApi.Domain.Entities.RecipeIngredient", b =>
                {
                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.HasKey("RecipeId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("RecipeIngredient");
                });

            modelBuilder.Entity("FoodRecipesApi.Domain.Entities.RecipeStep", b =>
                {
                    b.Property<int>("RecipeStepId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Instruction")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("RecipeStepId");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeStep");
                });

            modelBuilder.Entity("FoodRecipesApi.Domain.Entities.IngredientQuantity", b =>
                {
                    b.HasOne("FoodRecipesApi.Domain.Entities.Ingredient", "Ingredient")
                        .WithOne("Quantity")
                        .HasForeignKey("FoodRecipesApi.Domain.Entities.IngredientQuantity", "IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodRecipesApi.Domain.Entities.MeasurementUnit", b =>
                {
                    b.HasOne("FoodRecipesApi.Domain.Entities.IngredientQuantity", "IngredientQuantity")
                        .WithOne("MeasurementUnit")
                        .HasForeignKey("FoodRecipesApi.Domain.Entities.MeasurementUnit", "IngredientQuantityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodRecipesApi.Domain.Entities.Recipe", b =>
                {
                    b.HasOne("FoodRecipesApi.Domain.Entities.Author", "Author")
                        .WithMany("Recipes")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodRecipesApi.Domain.Entities.RecipeIngredient", b =>
                {
                    b.HasOne("FoodRecipesApi.Domain.Entities.Ingredient", "Ingredient")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodRecipesApi.Domain.Entities.Recipe", "Recipe")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodRecipesApi.Domain.Entities.RecipeStep", b =>
                {
                    b.HasOne("FoodRecipesApi.Domain.Entities.Recipe", "Recipe")
                        .WithMany("RecipeSteps")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

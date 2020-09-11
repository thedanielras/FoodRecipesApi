using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodRecipesApi.Persistence.Migrations
{
    public partial class AddMeasurementUnitTableAndChangedTheRecipeTimesTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreparationTime",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "TotalTime",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "MeasurementUnit",
                table: "IngredientQuantity");

            migrationBuilder.AddColumn<int>(
                name: "PreparationTimeInMinutes",
                table: "Recipes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalTimeInMinutes",
                table: "Recipes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MeasurementUnitId",
                table: "IngredientQuantity",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MeasurementUnit",
                columns: table => new
                {
                    MeasurementUnitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unit = table.Column<string>(maxLength: 15, nullable: false),
                    IngredientQuantityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementUnit", x => x.MeasurementUnitId);
                    table.ForeignKey(
                        name: "FK_MeasurementUnit_IngredientQuantity_IngredientQuantityId",
                        column: x => x.IngredientQuantityId,
                        principalTable: "IngredientQuantity",
                        principalColumn: "IngredientQuantityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementUnit_IngredientQuantityId",
                table: "MeasurementUnit",
                column: "IngredientQuantityId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeasurementUnit");

            migrationBuilder.DropColumn(
                name: "PreparationTimeInMinutes",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "TotalTimeInMinutes",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "MeasurementUnitId",
                table: "IngredientQuantity");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "PreparationTime",
                table: "Recipes",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TotalTime",
                table: "Recipes",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "MeasurementUnit",
                table: "IngredientQuantity",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}

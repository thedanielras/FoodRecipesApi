using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodRecipesApi.Persistence.Migrations
{
    public partial class RemoveAuthorEntityBornProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Authors_Name_Surname_Born",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Born",
                table: "Authors");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_Name_Surname",
                table: "Authors",
                columns: new[] { "Name", "Surname" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Authors_Name_Surname",
                table: "Authors");

            migrationBuilder.AddColumn<DateTime>(
                name: "Born",
                table: "Authors",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Authors_Name_Surname_Born",
                table: "Authors",
                columns: new[] { "Name", "Surname", "Born" });
        }
    }
}

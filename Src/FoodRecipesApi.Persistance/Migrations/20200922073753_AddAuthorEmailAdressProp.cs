using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodRecipesApi.Persistence.Migrations
{
    public partial class AddAuthorEmailAdressProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Authors_Name_Surname",
                table: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Authors_Name_Surname",
                table: "Authors");

            migrationBuilder.AddColumn<string>(
                name: "EmailAdress",
                table: "Authors",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Authors_Name_Surname_EmailAdress",
                table: "Authors",
                columns: new[] { "Name", "Surname", "EmailAdress" });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_Name_Surname_EmailAdress",
                table: "Authors",
                columns: new[] { "Name", "Surname", "EmailAdress" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Authors_Name_Surname_EmailAdress",
                table: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Authors_Name_Surname_EmailAdress",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "EmailAdress",
                table: "Authors");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Authors_Name_Surname",
                table: "Authors",
                columns: new[] { "Name", "Surname" });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_Name_Surname",
                table: "Authors",
                columns: new[] { "Name", "Surname" });
        }
    }
}

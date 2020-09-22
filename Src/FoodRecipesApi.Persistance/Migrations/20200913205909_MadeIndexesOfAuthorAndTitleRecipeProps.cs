using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodRecipesApi.Persistence.Migrations
{
    public partial class MadeIndexesOfAuthorAndTitleRecipeProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Recipes_Title_AuthorId",
                table: "Recipes",
                columns: new[] { "Title", "AuthorId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Recipes_Title_AuthorId",
                table: "Recipes");
        }
    }
}

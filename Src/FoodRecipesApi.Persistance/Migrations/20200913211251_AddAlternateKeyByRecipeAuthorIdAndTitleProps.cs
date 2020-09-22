using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodRecipesApi.Persistence.Migrations
{
    public partial class AddAlternateKeyByRecipeAuthorIdAndTitleProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Recipes_Title_AuthorId",
                table: "Recipes",
                columns: new[] { "Title", "AuthorId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Recipes_Title_AuthorId",
                table: "Recipes");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRecipesApi.Domain.Entities
{
    public class Recipe
    {
        public Recipe()
        {
            Author = new Author();
            RecipeSteps = new List<RecipeStep>();
            RecipeIngredients = new List<RecipeIngredient>();
        }

        public int RecipeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public ICollection<RecipeStep> RecipeSteps { get; set; }
        public string ImageUrl { get; set; }
        public int PreparationTimeInMinutes { get; set; }
        public int TotalTimeInMinutes { get; set; }
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}

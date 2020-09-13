using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRecipesApi.Application.Common.Dtos
{
    public class RecipeCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public AuthorCreateDto Author { get; set; }
        public string ImageUrl { get; set; }
        public int PreparationTimeInMinutes { get; set; }
        public int TotalTimeInMinutes { get; set; }
        public IEnumerable<RecipeStepCreateDto> RecipeSteps { get; set; }
        public IEnumerable<IngredientCreateDto> RecipeIngredients { get; set; }
    }
}

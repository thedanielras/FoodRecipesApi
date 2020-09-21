using FoodRecipesApi.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRecipesApi.Application.Recipes.Commands.UpsertRecipe
{
    public class UpsertRecipeCommand : IRequest<int>
    {
        public int? RecipeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public AuthorCreateDto Author { get; set; }
        public int AuthorId { get; set; }
        public List<RecipeStepCreateDto> RecipeSteps { get; set; }
        public string ImageUrl { get; set; }
        public int PreparationTimeInMinutes { get; set; }
        public int TotalTimeInMinutes { get; set; }
        public List<RecipeIngredientCreateDto> RecipeIngredients { get; set; }
    }
}

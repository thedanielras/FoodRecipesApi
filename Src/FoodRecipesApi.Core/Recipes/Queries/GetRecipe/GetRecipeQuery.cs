using FoodRecipesApi.Application.Common.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRecipesApi.Application.Recipes.Queries.GetRecipe
{
    public class GetRecipeQuery : IRequest<RecipeDto>
    {
        public GetRecipeQuery(int id)
        {
            RecipeId = id;
        }

        public int RecipeId { get; set; }
    }
}

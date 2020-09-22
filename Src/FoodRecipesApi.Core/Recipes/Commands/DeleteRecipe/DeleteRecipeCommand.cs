using FoodRecipesApi.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRecipesApi.Application.Recipes.Commands.DeleteRecipe
{
    public class DeleteRecipeCommand : IRequest<Unit>
    {
        public DeleteRecipeCommand(int id)
        {
            RecipeId = id;
        }

        public int RecipeId { get; set; }
    }
}

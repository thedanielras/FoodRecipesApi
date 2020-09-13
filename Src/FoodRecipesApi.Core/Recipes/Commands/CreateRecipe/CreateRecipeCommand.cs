using FoodRecipesApi.Application.Common.Dtos;
using FoodRecipesApi.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRecipesApi.Application.Recipes.Commands.CreateRecipe
{
    public class CreateRecipeCommand : RecipeCreateDto, IRequest<int>
    {
   
    }
}

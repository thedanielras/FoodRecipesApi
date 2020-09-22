using FoodRecipesApi.Application.Common.Dtos;
using FoodRecipesApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRecipesApi.Application.Common.Mappers.Interfaces
{
    public interface IRecipeMapper
    {
       public RecipeDto MapToRecipeDto(Recipe recipe);
    }
}

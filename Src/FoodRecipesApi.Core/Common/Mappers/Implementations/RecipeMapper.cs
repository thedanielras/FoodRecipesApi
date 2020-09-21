using FoodRecipesApi.Application.Common.Dtos;
using FoodRecipesApi.Application.Common.Mappers.Interfaces;
using FoodRecipesApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodRecipesApi.Application.Common.Mappers.Implementations
{
    public class RecipeMapper : IRecipeMapper
    {
        public RecipeDto MapToRecipeDto (Recipe recipe)
        {
            RecipeDto recipeDto = new RecipeDto()
            {
                RecipeId = recipe.RecipeId,
                Title = recipe.Title,
                Description = recipe.Description,
                Author = $"{recipe.Author.Name} {recipe.Author.Surname}",
                ImageUrl = recipe.ImageUrl,
                PreparationTimeInMinutes = recipe.PreparationTimeInMinutes,
                TotalTimeInMinutes = recipe.TotalTimeInMinutes,
                RecipeSteps = recipe.RecipeSteps.Select(rs => new RecipeStepDto()
                {
                    RecipeStepId = rs.RecipeStepId,
                    Instruction = rs.Instruction,
                    ImageUrl = rs.ImageUrl
                }),
                RecipeIngredients = recipe.RecipeIngredients.Select(ri => new IngredientDto()
                {
                    IngredientId = ri.Ingredient.IngredientId,
                    Name = ri.Ingredient.Name,
                    Quantity = new IngredientQuantityDto()
                    {
                        Amount = ri.Ingredient.Quantity.Amount,
                        MeasurementUnit = ri.Ingredient.Quantity.MeasurementUnit.Unit
                    }
                })
            };

            return recipeDto;
        }    
    }
}

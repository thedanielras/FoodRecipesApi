using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRecipesApi.Application.Recipes.Commands.UpsertRecipe
{
    public class RecipeIngredientCreateDto
    {       
        public IngredientCreateDto Ingredient { get; set; }

        public class IngredientCreateDto
        {            
            public int? IngredientId { get; set; }
            public string Name { get; set; }
            public IngredientQuantityCreateDto Quantity { get; set; }

            public class IngredientQuantityCreateDto
            {
                public float Amount { get; set; }
                public string MeasurementUnit { get; set; }                
            }
        }
    }
}

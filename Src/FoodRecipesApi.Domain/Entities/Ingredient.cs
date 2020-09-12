using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRecipesApi.Domain.Entities
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public IngredientQuantity Quantity { get; set; }
        public int QuantityId { get; set; }
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}

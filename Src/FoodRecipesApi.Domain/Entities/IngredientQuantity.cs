using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRecipesApi.Domain.Entities
{
    public class IngredientQuantity
    {
        public int IngredientQuantityId { get; set; }
        public float Ammount { get; set; }
        public string MeasurementUnit { get; set; }
        public Ingredient Ingredient { get; set; }
        public int IngredientId { get; set; }
    }
}

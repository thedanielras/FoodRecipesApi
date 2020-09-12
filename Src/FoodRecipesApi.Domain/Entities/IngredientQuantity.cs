using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRecipesApi.Domain.Entities
{
    public class IngredientQuantity
    {
        public int IngredientQuantityId { get; set; }
        public float Amount { get; set; }
        public MeasurementUnit MeasurementUnit { get; set; }
        public int MeasurementUnitId { get; set; }
        public Ingredient Ingredient { get; set; }
        public int IngredientId { get; set; }
    }
}

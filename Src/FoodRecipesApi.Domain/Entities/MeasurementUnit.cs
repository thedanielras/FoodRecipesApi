using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRecipesApi.Domain.Entities
{
    public class MeasurementUnit
    {
        public int MeasurementUnitId { get; set; }
        public string Unit { get; set; }
        public IngredientQuantity IngredientQuantity { get; set; }
        public int IngredientQuantityId { get; set; }
    }
}

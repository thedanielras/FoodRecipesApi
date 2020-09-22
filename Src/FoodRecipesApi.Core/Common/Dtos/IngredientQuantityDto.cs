using FoodRecipesApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRecipesApi.Application.Common.Dtos
{
    public class IngredientQuantityDto
    {
        public float Amount { get; set; }
        public string MeasurementUnit { get; set; }
    }
}

using FoodRecipesApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRecipesApi.Application.Common.Dtos
{
    public class IngredientQuantityDto
    {
        public float Amount { get; set; }
        public MeasurementUnit MeasurementUnit { get; set; }
    }
}

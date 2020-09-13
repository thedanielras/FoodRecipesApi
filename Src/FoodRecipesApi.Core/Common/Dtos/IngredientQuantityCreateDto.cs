using FoodRecipesApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRecipesApi.Application.Common.Dtos
{
    public class IngredientQuantityCreateDto
    {
        public float Amount { get; set; }
        public MeasurementUnitCreateDto MeasurementUnit { get; set; }
    }
}

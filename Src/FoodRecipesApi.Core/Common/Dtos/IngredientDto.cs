using FoodRecipesApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRecipesApi.Application.Common.Dtos
{
    public class IngredientDto
    {
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public IngredientQuantityDto Quantity { get; set; }
    }
}

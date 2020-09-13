using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRecipesApi.Application.Common.Dtos
{
    public class IngredientCreateDto
    {
        public string Name { get; set; }
        public IngredientQuantityDto Quantity { get; set; }
    }
}

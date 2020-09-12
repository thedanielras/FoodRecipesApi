using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRecipesApi.Application.Common.Dtos
{
    public class RecipeStepDto
    {
        public int RecipeStepId { get; set; }
        public string Instruction { get; set; }
        public string ImageUrl { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRecipesApi.Application.Common.Dtos
{
    public class RecipeStepCreateDto
    {
        public string Instruction { get; set; }
        public string ImageUrl { get; set; }
    }
}

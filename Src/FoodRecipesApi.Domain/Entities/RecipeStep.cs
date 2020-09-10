using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRecipesApi.Domain.Entities
{
    public class RecipeStep
    {
        public int RecipeStepId { get; set; }
        public string Instruction { get; set; }
        public string ImageUrl { get; set; }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRecipesApi.Application.Recipes.Commands.UpsertRecipe
{
    public class RecipeStepCreateDtoValidator : AbstractValidator<RecipeStepCreateDto>
    {
        public RecipeStepCreateDtoValidator()
        {
            RuleFor(rs => rs.Instruction).NotEmpty();
            RuleFor(rs => rs.Instruction).MaximumLength(500);
            RuleFor(rs => rs.ImageUrl).MaximumLength(250);
        }
    }
}

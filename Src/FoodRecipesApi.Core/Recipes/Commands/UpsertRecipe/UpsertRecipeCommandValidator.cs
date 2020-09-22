using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRecipesApi.Application.Recipes.Commands.UpsertRecipe
{
    public class UpsertRecipeCommandValidator : AbstractValidator<UpsertRecipeCommand>
    {
        public UpsertRecipeCommandValidator()
        {
            RuleFor(r => r.Title).NotEmpty();
            RuleFor(r => r.Title).MaximumLength(150);
            RuleFor(r => r.Description).NotEmpty();
            RuleFor(r => r.Description).MaximumLength(1000);
            RuleFor(r => r.ImageUrl).NotEmpty();
            RuleFor(r => r.ImageUrl).MaximumLength(250);
            RuleFor(r => r.PreparationTimeInMinutes).NotEmpty();
            RuleFor(r => r.TotalTimeInMinutes).NotEmpty();

            RuleFor(r => r.Author).SetValidator(new AuthorCreateDtoValidator());
            RuleForEach(r => r.RecipeSteps).SetValidator(new RecipeStepCreateDtoValidator());
            RuleForEach(r => r.RecipeIngredients).SetValidator(new RecipeIngredientCreateDtoValidator());
        }
    }
}

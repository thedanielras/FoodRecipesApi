using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRecipesApi.Application.Recipes.Commands.UpsertRecipe
{
    public class RecipeIngredientCreateDtoValidator : AbstractValidator<RecipeIngredientCreateDto>
    {
        public RecipeIngredientCreateDtoValidator()
        {
            RuleFor(ri => ri.Ingredient).ChildRules(igredient =>
            {
                igredient.RuleFor(i => i.Name).NotEmpty();
                igredient.RuleFor(i => i.Name).MaximumLength(150);
                igredient.RuleFor(i => i.Quantity).ChildRules(qunatity =>
                {
                    qunatity.RuleFor(q => q.Amount).NotEmpty();
                    qunatity.RuleFor(q => q.MeasurementUnit).NotEmpty();
                });
            });
        }
    }
}

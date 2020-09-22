using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRecipesApi.Application.Recipes.Commands.UpsertRecipe
{
    public class AuthorCreateDtoValidator : AbstractValidator<AuthorCreateDto>
    {
        public AuthorCreateDtoValidator()
        {
            RuleFor(a => a.Name).NotEmpty();
            RuleFor(a => a.Name).MaximumLength(50);
            RuleFor(a => a.Surname).NotEmpty();
            RuleFor(a => a.Surname).MaximumLength(50);
            RuleFor(a => a.Email).NotEmpty();
            RuleFor(a => a.Email).MaximumLength(60);
            RuleFor(a => a.Email).EmailAddress();   
            RuleFor(a => a.ImageUrl).MaximumLength(250);
        }
    }
}

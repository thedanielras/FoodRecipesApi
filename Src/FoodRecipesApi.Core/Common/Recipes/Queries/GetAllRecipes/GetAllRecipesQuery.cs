using FoodRecipesApi.Application.Common.Dtos;
using FoodRecipesApi.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRecipesApi.Application.Common.Recipes.Queries.GetAllRecipes
{
    public class GetAllRecipesQuery : IRequest<List<RecipeDto>>{}
}

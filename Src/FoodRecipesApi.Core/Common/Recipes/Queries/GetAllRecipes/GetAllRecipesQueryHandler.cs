using FoodRecipesApi.Application.Common.Dtos;
using FoodRecipesApi.Application.Common.Interfaces;
using FoodRecipesApi.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FoodRecipesApi.Application.Common.Recipes.Queries.GetAllRecipes
{
    public class GetAllRecipesQueryHandler : IRequestHandler<GetAllRecipesQuery, List<RecipeDto>>
    {
        private readonly IFoodRecipesDbContext _context;

        public GetAllRecipesQueryHandler(IFoodRecipesDbContext context)
        {
            _context = context;
        }

        public Task<List<RecipeDto>> Handle(GetAllRecipesQuery request, CancellationToken cancellationToken)
        {
            var recipes = _context.Recipes
                 .Include(r => r.Author)
                 .Include(r => r.RecipeIngredients)
                     .ThenInclude(ri => ri.Ingredient)
                         .ThenInclude(i => i.Quantity)
                             .ThenInclude(q => q.MeasurementUnit)
                 .Include(r => r.RecipeSteps)
                 .Select(r => new RecipeDto()
                 {
                     RecipeId = r.RecipeId,
                     Title = r.Title,
                     Description = r.Description,
                     Author = $"{r.Author.Name} {r.Author.Surname}",
                     ImageUrl = r.ImageUrl,
                     PreparationTimeInMinutes = r.PreparationTimeInMinutes,
                     TotalTimeInMinutes = r.TotalTimeInMinutes,
                     RecipeSteps = r.RecipeSteps,
                     RecipeIngredients = r.RecipeIngredients.Select(ri => new IngredientDto()
                     {
                         IngredientId = ri.Ingredient.IngredientId,
                         Name = ri.Ingredient.Name,
                         Quantity = new IngredientQuantityDto()
                         {
                             Amount = ri.Ingredient.Quantity.Amount,
                             MeasurementUnit = ri.Ingredient.Quantity.MeasurementUnit
                         }
                     })
                 });


            return recipes.ToListAsync<RecipeDto>();
        }
    }
}

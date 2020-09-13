using FoodRecipesApi.Application.Common.Dtos;
using FoodRecipesApi.Application.Common.Interfaces;
using FoodRecipesApi.Application.Common.Mappers.Interfaces;
using FoodRecipesApi.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FoodRecipesApi.Application.Recipes.Queries.GetAllRecipes
{
    public class GetAllRecipesQueryHandler : IRequestHandler<GetAllRecipesQuery, List<RecipeDto>>
    {
        private readonly IFoodRecipesDbContext _context;
        private readonly ILogger<GetAllRecipesQueryHandler> _logger;
        private readonly IRecipeMapper _recipeMapper;

        public GetAllRecipesQueryHandler(
            IFoodRecipesDbContext context, 
            ILogger<GetAllRecipesQueryHandler> logger,
            IRecipeMapper recipeMapper
            )
        {
            _context = context;
            _logger = logger;
            _recipeMapper = recipeMapper;
        }

        public async Task<List<RecipeDto>> Handle(GetAllRecipesQuery request, CancellationToken cancellationToken)
        {
            IQueryable<RecipeDto> recipes = null;

            try
            {
                recipes = _context.Recipes
                .Include(r => r.Author)
                .Include(r => r.RecipeIngredients)
                    .ThenInclude(ri => ri.Ingredient)
                        .ThenInclude(i => i.Quantity)
                            .ThenInclude(q => q.MeasurementUnit)
                .Include(r => r.RecipeSteps)
                .Select(r => _recipeMapper.MapToRecipeDto(r));               
            } catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }


            return await recipes.ToListAsync<RecipeDto>() ?? null;
        }
    }
}

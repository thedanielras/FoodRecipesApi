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

namespace FoodRecipesApi.Application.Recipes.Queries.GetRecipe
{
    public class GetRecipeQueryHandler : IRequestHandler<GetRecipeQuery, RecipeDto>
    {
        private readonly IFoodRecipesDbContext _context;
        private readonly ILogger<GetRecipeQueryHandler> _logger;
        private readonly IRecipeMapper _recipeMapper;

        public GetRecipeQueryHandler(
            IFoodRecipesDbContext context, 
            ILogger<GetRecipeQueryHandler> logger,
            IRecipeMapper recipeMapper
            )
        {
            _context = context;
            _logger = logger;
            _recipeMapper = recipeMapper;
        }

        public async Task<RecipeDto> Handle(GetRecipeQuery request, CancellationToken cancellationToken)
        {
            var recipe = await _context.Recipes
                .Where(recipe => recipe.RecipeId == request.RecipeId)
                .Include(r => r.Author)
                .Include(r => r.RecipeIngredients)
                    .ThenInclude(ri => ri.Ingredient)
                        .ThenInclude(i => i.Quantity)
                            .ThenInclude(q => q.MeasurementUnit)
                .Include(r => r.RecipeSteps)
                .FirstOrDefaultAsync();

            RecipeDto recipeDto = null;

            if (recipe is Recipe) recipeDto = _recipeMapper.MapToRecipeDto(recipe);

            return recipeDto;
        }
    }
}

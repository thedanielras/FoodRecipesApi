using FoodRecipesApi.Application.Common.Interfaces;
using FoodRecipesApi.Application.Common.Mappers.Interfaces;
using FoodRecipesApi.Application.Recipes.Queries.GetAllRecipes;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FoodRecipesApi.Application.Recipes.Commands.CreateRecipe
{
    public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, int>
    {
        private readonly IFoodRecipesDbContext _context;
        private readonly ILogger<GetAllRecipesQueryHandler> _logger;
        private readonly IRecipeMapper _recipeMapper;

        public CreateRecipeCommandHandler(
            IFoodRecipesDbContext context,
            ILogger<GetAllRecipesQueryHandler> logger,
            IRecipeMapper recipeMapper
        )
        {
            _context = context;
            _logger = logger;
            _recipeMapper = recipeMapper;
        }

        public async Task<int> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
            var recipeEntity = _recipeMapper.MapFromCreateDtoToEntity(request);

            try {
                _context.Recipes.Add(recipeEntity);
                await _context.SaveChangesAsync(cancellationToken);
            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return recipeEntity.RecipeId;
        }
    }
}

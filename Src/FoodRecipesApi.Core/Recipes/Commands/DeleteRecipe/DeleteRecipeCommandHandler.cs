using FoodRecipesApi.Application.Common.Exceptions;
using FoodRecipesApi.Application.Common.Interfaces;
using FoodRecipesApi.Application.Recipes.Queries.GetAllRecipes;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FoodRecipesApi.Application.Recipes.Commands.DeleteRecipe
{
    public class DeleteRecipeCommandHandler : IRequestHandler<DeleteRecipeCommand, Unit>
    {
        private readonly IFoodRecipesDbContext _context;
        private readonly ILogger<GetAllRecipesQueryHandler> _logger;

        public DeleteRecipeCommandHandler(
            IFoodRecipesDbContext context,
            ILogger<GetAllRecipesQueryHandler> logger
        )
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
        {
            var recipeEntity = await _context.Recipes.FindAsync(request.RecipeId);

            if (recipeEntity == null) throw new NotFoundException("Recipe", request.RecipeId);

            try
            {
                _context.Recipes.Remove(recipeEntity);
                await _context.SaveChangesAsync(cancellationToken);

            } catch( Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Unit.Value;
        }
    }
}

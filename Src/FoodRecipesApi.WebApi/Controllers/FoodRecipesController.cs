using FoodRecipesApi.Application.Common.Dtos;
using FoodRecipesApi.Application.Common.Interfaces;
using FoodRecipesApi.Application.Recipes.Commands.CreateRecipe;
using FoodRecipesApi.Application.Recipes.Commands.DeleteRecipe;
using FoodRecipesApi.Application.Recipes.Queries.GetAllRecipes;
using FoodRecipesApi.Application.Recipes.Queries.GetRecipe;
using FoodRecipesApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodRecipesApi.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodRecipesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FoodRecipesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeDto>>> GetAllRecipes()
        {
            var recipes = await _mediator.Send(new GetAllRecipesQuery());

            return Ok(recipes);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<RecipeDto>> GetRecipeById(int id)
        {
            var recipe = await _mediator.Send(new GetRecipeQuery(id));


            if (recipe == null)
                return NotFound();
            else
                return Ok(recipe);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateRecipe(CreateRecipeCommand createRecipeCommand)
        {
            int recipeId = await _mediator.Send(createRecipeCommand);

            return Ok(recipeId);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteRecipe(int id)
        {
            await _mediator.Send(new DeleteRecipeCommand(id));

            return NoContent();
        } 
    }
}

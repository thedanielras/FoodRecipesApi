using FoodRecipesApi.Application.Common.Dtos;
using FoodRecipesApi.Application.Common.Interfaces;
using FoodRecipesApi.Application.Recipes.Commands.DeleteRecipe;
using FoodRecipesApi.Application.Recipes.Commands.UpsertRecipe;
using FoodRecipesApi.Application.Recipes.Queries.GetAllRecipes;
using FoodRecipesApi.Application.Recipes.Queries.GetRecipe;
using FoodRecipesApi.Domain.Entities;
using FoodRecipesApi.WebApi.Models;
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
    [Route("api/v1/[controller]")]
    public class FoodRecipesController : BaseController
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
        public async Task<ActionResult<int>> UpsertRecipe(UpsertRecipeCommand upsertRecipeCommand)
        {
            int recipeId = await _mediator.Send(upsertRecipeCommand);

            return Ok(recipeId);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteRecipe(int id)
        {
            await _mediator.Send(new DeleteRecipeCommand(id));

            return NoContent();
        }

        [Route("/error")]
        public override ActionResult<ApiErrorModel> SendError()
        {
            return base.SendError();
        }
    }
}

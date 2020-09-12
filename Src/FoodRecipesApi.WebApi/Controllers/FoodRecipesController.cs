using FoodRecipesApi.Application.Common.Dtos;
using FoodRecipesApi.Application.Common.Interfaces;
using FoodRecipesApi.Application.Common.Recipes.Queries.GetAllRecipes;
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
        public async Task<ActionResult<IEnumerable<RecipeDto>>> Get()
        {
           var recipes = await _mediator.Send(new GetAllRecipesQuery());

            return Ok(recipes);
        }
    }
}

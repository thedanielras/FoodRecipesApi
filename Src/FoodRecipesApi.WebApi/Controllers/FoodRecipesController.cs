using FoodRecipesApi.Application.Common.Dtos;
using FoodRecipesApi.Application.Common.Interfaces;

using FoodRecipesApi.Domain.Entities;
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
        private readonly ILogger _logger;
        private readonly IFoodRecipesDbContext _context;

        public FoodRecipesController(ILogger<FoodRecipesController> logger, IFoodRecipesDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<RecipeDto> Get()
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
                        Quantity = new IngredientQuantityDto() { 
                            Amount = ri.Ingredient.Quantity.Amount,
                            MeasurementUnit = ri.Ingredient.Quantity.MeasurementUnit
                        } 
                    })
                });
                

            return recipes.ToList();
        }
    }
}

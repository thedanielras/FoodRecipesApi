using FoodRecipesApi.Application.Common.Interfaces;
using FoodRecipesApi.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FoodRecipesApi.Application.Recipes.Commands.UpsertRecipe
{
    public class UpsertRecipeCommandHandler : IRequestHandler<UpsertRecipeCommand, int>
    {
        private readonly IFoodRecipesDbContext _context;

        public UpsertRecipeCommandHandler(IFoodRecipesDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpsertRecipeCommand request, CancellationToken cancellationToken)
        {
            //handle Author
            Author authorEntity = null;

            //if AuthorId is present try get entity from db
            if (request.Author.AuthorId != null && request.Author.AuthorId > 0)
                authorEntity = await _context.Authors.FindAsync(request.Author.AuthorId);

            //else try find by alternate key (Name, Surname)
            if (authorEntity == null)
            {
                authorEntity = _context.Authors
                                       .Where(a => a.Name == request.Author.Name &&
                                                   a.Surname == request.Author.Surname)
                                       .FirstOrDefault();
            }

            //else create
            if (authorEntity == null)
                authorEntity = new Author()
                {
                    Name = request.Author.Name,
                    Surname = request.Author.Surname,
                    ImageUrl = request.Author.ImageUrl
                };

            Recipe entity = null;

            //if RecipeId is present try get entity from db
            if (request.RecipeId != null && request.RecipeId > 0)
                entity = await _context.Recipes.FindAsync(request.RecipeId);

            //else try find by alternate key (AuthorId, Title)
            if (entity == null && authorEntity.AuthorId > 0)
                entity = _context.Recipes.Where(r => r.AuthorId == authorEntity.AuthorId &&
                                                           r.Title == request.Title).FirstOrDefault();
            //else create a new one
            if (entity == null)
            {
                entity = new Recipe();
                _context.Recipes.Add(entity);
            }

            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.Author = authorEntity;
            entity.ImageUrl = request.ImageUrl;
            entity.PreparationTimeInMinutes = request.PreparationTimeInMinutes;
            entity.TotalTimeInMinutes = request.TotalTimeInMinutes;

            //handle RecipeSteps
            request.RecipeSteps.ForEach(rs =>
            {
                RecipeStep recipeStep = new RecipeStep()
                {
                    Instruction = rs.Instruction,
                    ImageUrl = rs.ImageUrl
                };

                entity.RecipeSteps.Add(recipeStep);
            });

            //handle RecipeIngredients
            request.RecipeIngredients.ForEach(ri =>
            {
                Ingredient ingredient = null;
                RecipeIngredient recipeIngredient = null;

                if (ri.Ingredient.IngredientId != null && ri.Ingredient.IngredientId > 0)
                {
                    ingredient = _context.Ingredients.Find(ri.Ingredient.IngredientId);
                }

                if (ingredient != null)
                    recipeIngredient = new RecipeIngredient()
                    {
                        Ingredient = ingredient
                    };
                else
                    recipeIngredient = new RecipeIngredient()
                    {
                        Ingredient = new Ingredient()
                        {
                            Name = ri.Ingredient.Name,
                            Quantity = new IngredientQuantity()
                            {
                                Amount = ri.Ingredient.Quantity.Amount,
                                MeasurementUnit = new MeasurementUnit()
                                {
                                    Unit = ri.Ingredient.Quantity.MeasurementUnit
                                }
                            }
                        }
                    };

                entity.RecipeIngredients.Add(recipeIngredient);
            });


            await _context.SaveChangesAsync(cancellationToken);

            return entity.RecipeId;
        }
    }
}

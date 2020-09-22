using FoodRecipesApi.Application.Common.Interfaces;
using FoodRecipesApi.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FoodRecipesApi.Application.System.Commands.DbSeedCommand
{
    public class DbSeedCommandHandler : IRequestHandler<DbSeedCommand, Unit>
    {
        private readonly IFoodRecipesDbContext _context;
        private readonly ILogger _logger;

        public DbSeedCommandHandler(IFoodRecipesDbContext context, ILogger<DbSeedCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Task<Unit> Handle(DbSeedCommand request, CancellationToken cancellationToken)
        {
            SeedRecipes();

            return Task.FromResult(Unit.Value);
        }

        private void SeedRecipes()
        {
            var sampleRecipes = new List<Recipe>();

            sampleRecipes.Add(new Recipe()
            {
                Title = "King Ranch Chicken Mac and Cheese",
                Description = "All the flavors of a favorite casserole come together in the comfort of mac and cheese. Serve King Ranch Chicken Mac and Cheese to your family, and it will become a quick favorite.",
                Author = new Author() { Name = "Southern", Surname = "Living", EmailAdress = "southern-living@gmail.com" },
                RecipeSteps = new List<RecipeStep>() {
                    new RecipeStep() {
                        Instruction = "Preheat oven to 350°. Prepare pasta according to package directions."
                    },
                    new RecipeStep() {
                        Instruction = "Meanwhile, melt butter in a large Dutch oven over medium-high heat. Add onion and bell pepper, and sauté 5 minutes or until tender. Stir in tomatoes and green chiles and prepared cheese product; cook, stirring constantly, 2 minutes or until cheese melts. Stir in chicken, next 4 ingredients, and hot cooked pasta until blended. Spoon mixture into a lightly greased 10-inch cast-iron skillet or 11- x 7-inch baking dish; sprinkle with shredded Cheddar cheese."
                    },
                    new RecipeStep() {
                        Instruction = "Bake at 350° for 25 to 30 minutes or until bubbly."
                    }
                },
                ImageUrl = "https://i.imgur.com/A14QwVW.jpeg",
                PreparationTimeInMinutes = 25,
                TotalTimeInMinutes = 45,
                RecipeIngredients = new List<RecipeIngredient>()
                {
                    new RecipeIngredient() {
                        Ingredient = new Ingredient()
                        {
                            Name = "cellentani pasta",
                            Quantity = new IngredientQuantity()
                            {
                                Amount = 0.5f,
                                MeasurementUnit = new MeasurementUnit() { Unit = "package" }
                            }
                        }
                    },
                    new RecipeIngredient() {
                        Ingredient = new Ingredient()
                        {
                            Name = "butter",
                            Quantity = new IngredientQuantity()
                            {
                                Amount = 2f,
                                MeasurementUnit = new MeasurementUnit() { Unit = "tablespoon" }
                            }
                        }
                    },
                    new RecipeIngredient() {
                        Ingredient = new Ingredient()
                        {
                            Name = "diced onion",
                            Quantity = new IngredientQuantity()
                            {
                                Amount = 1f,
                                MeasurementUnit = new MeasurementUnit() { Unit = "piece" }
                            }
                        }
                    },
                    new RecipeIngredient() {
                        Ingredient = new Ingredient()
                        {
                            Name = "diced green bell pepper",
                            Quantity = new IngredientQuantity()
                            {
                                Amount = 1f,
                                MeasurementUnit = new MeasurementUnit() { Unit = "piece" }
                            }
                        }
                    },
                    new RecipeIngredient() {
                        Ingredient = new Ingredient()
                        {
                            Name = "diced tomatoes and green chiles",
                            Quantity = new IngredientQuantity()
                            {
                                Amount = 1f,
                                MeasurementUnit = new MeasurementUnit() { Unit = "can (10-oz.)" }
                            }
                        }
                    },
                    new RecipeIngredient() {
                        Ingredient = new Ingredient()
                        {
                            Name = "pasteurized prepared cheese product, cubed",
                            Quantity = new IngredientQuantity()
                            {
                                Amount = 1f,
                                MeasurementUnit = new MeasurementUnit() { Unit = "package (8-oz.)" }
                            }
                        }
                    },
                    new RecipeIngredient() {
                        Ingredient = new Ingredient()
                        {
                            Name = "chopped cooked chicken",
                            Quantity = new IngredientQuantity()
                            {
                                Amount = 3f,
                                MeasurementUnit = new MeasurementUnit() { Unit = "cup" }
                            }
                        }
                    },
                    new RecipeIngredient() {
                        Ingredient = new Ingredient()
                        {
                            Name = "can cream of chicken soup",
                            Quantity = new IngredientQuantity()
                            {
                                Amount = 1f,
                                MeasurementUnit = new MeasurementUnit() { Unit = "can (10 3/4-oz.)" }
                            }
                        }
                    },
                    new RecipeIngredient() {
                        Ingredient = new Ingredient()
                        {
                            Name = "sour cream",
                            Quantity = new IngredientQuantity()
                            {
                                Amount = 0.5f,
                                MeasurementUnit = new MeasurementUnit() { Unit = "cup" }
                            }
                        }
                    },
                    new RecipeIngredient() {
                        Ingredient = new Ingredient()
                        {
                            Name = "chili powder",
                            Quantity = new IngredientQuantity()
                            {
                                Amount = 1f,
                                MeasurementUnit = new MeasurementUnit() { Unit = "teaspoon" }
                            }
                        }
                    },
                    new RecipeIngredient() {
                        Ingredient = new Ingredient()
                        {
                            Name = "ground cumin",
                            Quantity = new IngredientQuantity()
                            {
                                Amount = 0.5f,
                                MeasurementUnit = new MeasurementUnit() { Unit = "teaspoon" }
                            }
                        }
                    },
                    new RecipeIngredient() {
                        Ingredient = new Ingredient()
                        {
                            Name = "shredded Cheddar cheese",
                            Quantity = new IngredientQuantity()
                            {
                                Amount = 1.25f,
                                MeasurementUnit = new MeasurementUnit() { Unit = "cup (6 oz.)" }
                            }
                        }
                    }
                }
            });

            sampleRecipes.Add(new Recipe()
            {
                Title = "Easy Chicken and Dumplings",
                Description = "Deli-roasted chicken, cream of chicken soup, and canned biscuits make a quick-and-tasty version of classic chicken and dumplings.",
                Author = new Author() { Name = "Southern", Surname = "Living", EmailAdress = "southern-living@gmail.com" },
                RecipeSteps = new List<RecipeStep>() {
                    new RecipeStep() {
                        Instruction = "Bring first 4 ingredients to a boil in a Dutch oven over medium-high heat. Cover, reduce heat to low, and simmer, stirring occasionally, 5 minutes. Increase heat to medium-high; return to a low boil."
                    },
                    new RecipeStep() {
                        Instruction = "Place biscuits on a lightly floured surface. Roll or pat each biscuit to 1/8-inch thickness; cut into 1/2-inch-wide strips."
                    },
                    new RecipeStep() {
                        Instruction = "Drop strips, 1 at a time, into boiling broth mixture. Add carrots and celery. Cover, reduce heat to low, and simmer 15 to 20 minutes, stirring occasionally to prevent dumplings from sticking."
                    }
                },
                ImageUrl = "https://i.imgur.com/DtCxaCO.jpeg",
                PreparationTimeInMinutes = 10,
                TotalTimeInMinutes = 40,
                RecipeIngredients = new List<RecipeIngredient>()
                {
                    new RecipeIngredient() {
                        Ingredient = new Ingredient()
                        {
                            Name = "low-sodium chicken broth",
                            Quantity = new IngredientQuantity()
                            {
                                Amount = 1f,
                                MeasurementUnit = new MeasurementUnit() { Unit = "container (32-oz.)" }
                            }
                        }
                    },
                    new RecipeIngredient() {
                        Ingredient = new Ingredient()
                        {
                            Name = "can reduced-fat cream of chicken soup",
                            Quantity = new IngredientQuantity()
                            {
                                Amount = 1f,
                                MeasurementUnit = new MeasurementUnit() { Unit = "can (10 3/4-oz.)" }
                            }
                        }
                    },
                    new RecipeIngredient() {
                        Ingredient = new Ingredient()
                        {
                            Name = "poultry seasoning",
                            Quantity = new IngredientQuantity()
                            {
                                Amount = 0.25f,
                                MeasurementUnit = new MeasurementUnit() { Unit = "teaspoon" }
                            }
                        }
                    },
                    new RecipeIngredient() {
                        Ingredient = new Ingredient()
                        {
                            Name = "refrigerated jumbo buttermilk biscuits",
                            Quantity = new IngredientQuantity()
                            {
                                Amount = 1f,
                                MeasurementUnit = new MeasurementUnit() { Unit = "can (10.2-oz.)" }
                            }
                        }
                    },
                    new RecipeIngredient() {
                        Ingredient = new Ingredient()
                        {
                            Name = "carrots, diced",
                            Quantity = new IngredientQuantity()
                            {
                                Amount = 2f,
                                MeasurementUnit = new MeasurementUnit() { Unit = "piece" }
                            }
                        }
                    },
                    new RecipeIngredient() {
                        Ingredient = new Ingredient()
                        {
                            Name = "celery ribs, diced",
                            Quantity = new IngredientQuantity()
                            {
                                Amount = 3f,
                                MeasurementUnit = new MeasurementUnit() { Unit = "piece" }
                            }
                        }
                    },
                    new RecipeIngredient() {
                        Ingredient = new Ingredient()
                        {
                            Name = "chopped cooked chicken",
                            Quantity = new IngredientQuantity()
                            {
                                Amount = 3f,
                                MeasurementUnit = new MeasurementUnit() { Unit = "cup" }
                            }
                        }
                    },
                    new RecipeIngredient() {
                        Ingredient = new Ingredient()
                        {
                            Name = "can cream of chicken soup",
                            Quantity = new IngredientQuantity()
                            {
                                Amount = 1f,
                                MeasurementUnit = new MeasurementUnit() { Unit = "can (10 3/4-oz.)" }
                            }
                        }
                    },
                    new RecipeIngredient() {
                        Ingredient = new Ingredient()
                        {
                            Name = "sour cream",
                            Quantity = new IngredientQuantity()
                            {
                                Amount = 0.5f,
                                MeasurementUnit = new MeasurementUnit() { Unit = "cup" }
                            }
                        }
                    },
                    new RecipeIngredient() {
                        Ingredient = new Ingredient()
                        {
                            Name = "chili powder",
                            Quantity = new IngredientQuantity()
                            {
                                Amount = 1f,
                                MeasurementUnit = new MeasurementUnit() { Unit = "teaspoon" }
                            }
                        }
                    },
                    new RecipeIngredient() {
                        Ingredient = new Ingredient()
                        {
                            Name = "ground cumin",
                            Quantity = new IngredientQuantity()
                            {
                                Amount = 0.5f,
                                MeasurementUnit = new MeasurementUnit() { Unit = "teaspoon" }
                            }
                        }
                    },
                    new RecipeIngredient() {
                        Ingredient = new Ingredient()
                        {
                            Name = "shredded Cheddar cheese",
                            Quantity = new IngredientQuantity()
                            {
                                Amount = 1.25f,
                                MeasurementUnit = new MeasurementUnit() { Unit = "cup (6 oz.)" }
                            }
                        }
                    }
                }
            });

            for(int i = 0; i < sampleRecipes.Count; i++)
            {
                Recipe recipe = sampleRecipes[i];

                //check if author already exists
                var author = _context.Authors.Where(a => a.Name == recipe.Author.Name &&
                                       a.Surname == recipe.Author.Surname)
                .FirstOrDefault();

                if (author != null)
                {
                    //check if recipes already exists
                    if (_context.Recipes.Where(r => r.AuthorId == author.AuthorId && r.Title == recipe.Title).FirstOrDefault() != null)
                        continue;
                    
                    //if no then add
                    author.Recipes.Add(recipe);
                }
                else
                {
                    _context.Recipes.Add(recipe);
                }

                try
                {
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Database seeding failed!");
                }
            }           
        }
    }
}

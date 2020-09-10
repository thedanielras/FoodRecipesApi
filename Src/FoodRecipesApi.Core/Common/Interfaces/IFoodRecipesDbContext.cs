using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using FoodRecipesApi.Domain.Entities;

namespace FoodRecipesApi.Application.Common.Interfaces
{
    interface IFoodRecipesDbContext
    {
        DbSet<Recipe> Recipes { get; set; }
    }
}

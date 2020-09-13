using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRecipesApi.Domain.Entities
{
    public class Author
    {
        public Author()
        {
            Recipes = new List<Recipe>();
        }

        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Recipe> Recipes { get; private set; }
    }
}

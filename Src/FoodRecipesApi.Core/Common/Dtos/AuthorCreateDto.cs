using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRecipesApi.Application.Common.Dtos
{
    public class AuthorCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Born { get; set; }
    }
}

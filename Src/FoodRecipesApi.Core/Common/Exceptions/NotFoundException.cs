using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRecipesApi.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key)
           : base($"Entity '{name}' with key ({key}) was not found.")
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodRecipesApi.WebApi.Models
{
    public class ApiErrorModel
    {       
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ApiErrorModel(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodRecipesApi.WebApi.Models
{
    public class BaseJson
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }

        public BaseJson(int statusCode, string message, object result = null)
        {
            StatusCode = statusCode;
            Message = message;
            Result = result;
        }

        public BaseJson(object result) : this(200, "", result)
        {
        }
       
    }
}

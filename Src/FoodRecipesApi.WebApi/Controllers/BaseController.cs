using FoodRecipesApi.WebApi.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodRecipesApi.WebApi.Controllers
{
    public class BaseController : ControllerBase
    {        
        public virtual ActionResult<ApiErrorModel> SendError()
        {
            int statusCode = StatusCodes.Status500InternalServerError;
            var exceptionHandler = HttpContext.Features.Get<IExceptionHandlerFeature>();

            var error = new ApiErrorModel(statusCode, exceptionHandler.Error.Message);

            return StatusCode(statusCode, error);
        }

    }
}

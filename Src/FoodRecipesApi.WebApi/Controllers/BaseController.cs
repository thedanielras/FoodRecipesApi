using FoodRecipesApi.Application.Common.Exceptions;
using FoodRecipesApi.WebApi.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FoodRecipesApi.WebApi.Controllers
{
    public abstract class BaseController : ControllerBase
    {        
        public virtual ActionResult SendError()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>().Error;

            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            string resultMessage = exception.Message;
            object result = null;                

            switch (exception)
            {
                case ValidationException validationException:
                    statusCode = HttpStatusCode.BadRequest;                
                    result = validationException.Failures;
                    break;
                case NotFoundException _:
                    statusCode = HttpStatusCode.NotFound;
                    break;
            }

            BaseJson resultJson = new BaseJson((int)statusCode, resultMessage, result);

            return new ObjectResult(resultJson) { StatusCode = (int)statusCode};
        }

    }
}

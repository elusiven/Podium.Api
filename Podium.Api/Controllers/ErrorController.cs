using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Podium.Service.Common.Exceptions;
using Podium.Service.Primitives.Models;

namespace Podium.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        [Route("error")]
        public ApiErrorResponse Error()
        {
            ApiErrorResponse response = new ApiErrorResponse();

            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context?.Error;
            var code = 500;

            if (exception?.InnerException is ServiceException serviceException)
            {
                code = 400;
                response.Status = code;
                response.Errors = serviceException.Errors;
            }

            Response.StatusCode = code;

            return response;
        }
    }
}
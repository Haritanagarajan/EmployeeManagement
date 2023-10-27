using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeeManagement.Api.GlobalException
{
    public class GlobalExceptionalFilters : IExceptionFilter
    {

        private readonly ILogger _logger;


        public GlobalExceptionalFilters(ILogger<GlobalExceptionalFilters> logger)
        {
            _logger = logger;
        }


        public void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                var statuscode = context.HttpContext.Response.StatusCode;


                var error = new ErrorResponse
                {
                    Success = false,
                };

                switch (statuscode)
                {
                    case 401:
                        error.Message = "Page Not Found";
                        break;

                    case 403:
                        error.Message = "Forbidden";
                        break;

                    case 404:
                        error.Message = "NotFound";
                        break;

                    case 200:
                        error.Message = "success";
                        break;

                    default:
                        error.Message = "Internal Server Error ";
                        break;
                }


                _logger.LogError($"GlobalExceptionFilter: Error in {context.ActionDescriptor.DisplayName}. {error.Message}");

                context.Result = new ObjectResult(error.Message) { StatusCode = statuscode };
            }
        }
    }
}


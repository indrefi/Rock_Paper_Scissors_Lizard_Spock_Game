using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;

namespace Application.Common.Exceptions
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;

            string result;
            switch (exception)
            {
                case NotFoundException notFoundException:
                    code = HttpStatusCode.NotFound;
                    result = CreateJsonResponse(notFoundException.Message);
                    break;
                case CalculateGameResultException calculateGameResultException:
                    code = HttpStatusCode.InternalServerError;
                    result = JsonConvert.SerializeObject(calculateGameResultException);
                    break;
                case FluentValidation.ValidationException fluentValidationException:
                    code = HttpStatusCode.BadRequest;
                    result = CreateJsonResponse(fluentValidationException.Message);
                    break;
                default:
                    result = CreateJsonResponse(exception.Message);
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }

        private string CreateJsonResponse(string error) => JsonConvert.SerializeObject(new { error });
        private string CreateJsonResponse(object errorObject) => JsonConvert.SerializeObject(errorObject);
    }
}

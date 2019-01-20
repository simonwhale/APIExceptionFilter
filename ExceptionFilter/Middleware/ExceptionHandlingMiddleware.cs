using ExceptionFilter.UserDefinedExceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ExceptionFilter.ExceptionFilter
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch(Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private static Task HandleException(HttpContext context, Exception ex)
        {
            var returnedStatusCode = HttpStatusCode.InternalServerError;

            if (ex is UnauthorizedAccessException) returnedStatusCode = HttpStatusCode.Unauthorized;
            if (ex is NotRecordedIAException) returnedStatusCode = HttpStatusCode.Forbidden;

            var result = JsonConvert.SerializeObject(new { error = ex.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)returnedStatusCode;
            return context.Response.WriteAsync(result);
        }
    }
}

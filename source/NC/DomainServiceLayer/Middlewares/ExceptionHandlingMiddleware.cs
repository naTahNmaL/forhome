using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ServiceLayer.Middlewares.ErrorMessageHandles;
using System.Net;

namespace ServiceLayer.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                ErrorMessageHandle.MessageDisplay = ex.Message;
                _logger.LogError(ex, "{Message}", ex.Message);
                context.Response.Redirect("/Home/UnexpectedError");
            }
        }
    }

}

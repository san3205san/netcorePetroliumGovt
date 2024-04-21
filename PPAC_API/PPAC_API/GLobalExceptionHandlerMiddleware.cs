using System;
using System.Net;
using System.Text.Json;

namespace PPAC_API
{
	public class GLobalExceptionHandlerMiddleware
	{
        
            private readonly RequestDelegate _next;
            private readonly ILogger<GLobalExceptionHandlerMiddleware> _logger;
            public GLobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GLobalExceptionHandlerMiddleware> logger)
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
                catch (Exception e)
                {
                    if (e.Source == "Data creation Error")
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.NotAcceptable;
                    }
                    else
                    {
                        // await HandleExceptionAsync(context, e);
                        _logger.LogError(e, e.Message);
                        context.Response.StatusCode = 500;
                    }

                }
            }

            private Task HandleExceptionAsync(HttpContext context, Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var code = HttpStatusCode.InternalServerError; // 500 if unexpected


                var result = JsonSerializer.Serialize(new { Error = ex.Message, Soure = ex.Source, Stacktrace = ex.StackTrace });
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)code;
                return context.Response.WriteAsync(result);
            }
        }
    }



using System.Text.Json;
using Api.Host.Presentation.Responses;

namespace Api.Host.Presentation.Middleware;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An unexpected error occurred.");
            
            await HandleExceptionAsync(context, ex);
        }
    }
    
    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        
        var result = exception switch
        {
            BadHttpRequestException => HandleBadRequest(context),
            _ => HandleInternalServerError(context)
        };
        
        await context.Response.WriteAsync(JsonSerializer.Serialize(result));
    }

    private static FailureResponse HandleBadRequest(HttpContext context)
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;

        return new(
            Message: "The request is invalid.",
            Reason: "Bad Request"
        );
    }

    private static FailureResponse HandleInternalServerError(HttpContext context)
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        return new
        (
            Message: "Something went wrong.",
            Reason: "Internal server error."
        );
    }
}
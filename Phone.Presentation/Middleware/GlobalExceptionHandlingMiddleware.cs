using Microsoft.AspNetCore.Mvc;
using Phone.Application.Contract.Exceptions;
using Phone.Domain.Exceptions;


namespace Phone.Presentation.Middleware;

public sealed class GlobalExceptionHandlingMiddleware(
    RequestDelegate next,
    ILogger<GlobalExceptionHandlingMiddleware> logger,
    IWebHostEnvironment env)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unhandled exception");
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var problemDetails = new ProblemDetails
        {
            Instance = context.Request.Path
        };

        switch (exception)
        {
            case ValidationException validationException:
                problemDetails.Title = "Validation error";
                problemDetails.Status = StatusCodes.Status400BadRequest;
                problemDetails.Extensions["errors"] = validationException.Errors;
                break;

            case NotFoundException:
                problemDetails.Title = "Resource not found";
                problemDetails.Status = StatusCodes.Status404NotFound;
                break;

            case DomainException:
                problemDetails.Title = "Business rule violation";
                problemDetails.Status = StatusCodes.Status409Conflict;
                break;

            case UnauthorizedAccessException:
                problemDetails.Title = "Unauthorized";
                problemDetails.Status = StatusCodes.Status401Unauthorized;
                break;

            default:
                problemDetails.Title = "Internal server error";
                problemDetails.Status = StatusCodes.Status500InternalServerError;
                break;
        }

        problemDetails.Detail = env.IsDevelopment()
            ? exception.Message
            : "An unexpected error occurred.";

        context.Response.StatusCode = problemDetails.Status.Value;
        context.Response.ContentType = "application/problem+json";

        return context.Response.WriteAsJsonAsync(problemDetails);
    }
}

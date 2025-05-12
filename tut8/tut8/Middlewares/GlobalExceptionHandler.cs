using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tut8.Exceptions;

namespace tut8.Middlewares;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Exception occurred while processing request.");

        ProblemDetails problemDetails;
        
        switch (exception)
        {
            case ProductInOrderException:
                problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status409Conflict,
                    Title = "Conflict",
                    Detail = "The product is already included in an order."
                };
                httpContext.Response.StatusCode = StatusCodes.Status409Conflict;
                break;

            case CreatedAtException:
                problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "Invalid Request",
                    Detail = "The request date is invalid. Ensure it is later than the order's creation date."
                };
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                break;

            case OrderWasCompletedException:
                problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status409Conflict,
                    Title = "Conflict",
                    Detail = "The order has already been completed."
                };
                httpContext.Response.StatusCode = StatusCodes.Status409Conflict;
                break;

            default:
                problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "Internal Server Error",
                    Detail = "An unexpected error occurred while processing the request."
                };
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                break;
        }

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        return true;
    }
}
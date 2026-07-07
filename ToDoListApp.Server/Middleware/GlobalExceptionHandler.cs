using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoListApp.Server.Application.Common.Exceptions;

namespace ToDoListApp.Server.Middleware
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            var (statusCode, title) = exception switch
            {
                NotFoundException => (StatusCodes.Status404NotFound, exception.Message),
                // Azure SQL free tier auto-pauses when idle; EF Core exhausts its retries while the DB
                // resumes from a cold start. Surface this as a transient 503 instead of a generic 500.
                Microsoft.EntityFrameworkCore.Storage.RetryLimitExceededException =>
                    (StatusCodes.Status503ServiceUnavailable, "Re-activating database; please retry in a while."),
                _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred.")
            };

            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = title
            };

            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}

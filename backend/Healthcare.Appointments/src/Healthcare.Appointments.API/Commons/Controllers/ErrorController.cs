using Healthcare.Appointments.Application.Commons.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.Appointments.API.Commons.Controllers;

/// <summary>
/// Controller for handling errors
/// </summary>
[ApiExplorerSettings(IgnoreApi = true)]
[ApiController]
public class ErrorController : ControllerBase
{
    /// <summary>
    /// Handles error in development
    /// </summary>
    /// <param name="hostEnvironment"></param>
    /// <returns></returns>
    [Route("/error-development")]
    public IActionResult HandleErrorDevelopment(
        [FromServices] IHostEnvironment hostEnvironment)
    {
        if (!hostEnvironment.IsDevelopment())
        {
            return NotFound();
        }

        var exceptionHandlerFeature =
            HttpContext.Features.Get<IExceptionHandlerFeature>()!;

        var statusCode = GetStatusCode(exceptionHandlerFeature);

        return Problem(
            statusCode: statusCode,
            detail: exceptionHandlerFeature.Error.Message);
    }

    /// <summary>
    /// Handles error
    /// </summary>
    /// <returns></returns>
    [Route("/error")]
    public IActionResult HandleError()
    {
        var exceptionHandlerFeature =
            HttpContext.Features.Get<IExceptionHandlerFeature>()!;

        var statusCode = GetStatusCode(exceptionHandlerFeature);

        return Problem(
            statusCode: statusCode,
            detail: exceptionHandlerFeature.Error.Message);
    }

    private static int GetStatusCode(IExceptionHandlerFeature exceptionHandlerFeature)
    {
        return exceptionHandlerFeature.Error switch
        {
            ArgumentException => 400,
            // ForbiddenException => 403,
            NotFoundException => 404,
            BadRequestException => 400,
            // ConflictException => 409,
            _ => 500
        };
    }
}
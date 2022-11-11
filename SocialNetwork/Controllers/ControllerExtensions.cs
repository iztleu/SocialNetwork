using System.ComponentModel.DataAnnotations;
using System.Security.Authentication;
using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.Controllers;

public static class ControllerExtensions
{
    public static IActionResult Match<TResult>(this Result<TResult> result)
    {
        return result.Match<IActionResult>(obj => new OkObjectResult(obj), exception =>
        {
            return exception switch
            {
                ValidationException => new ConflictResult(),
                AuthenticationException => new UnauthorizedObjectResult(exception.Message),
                ArgumentNullException => new NotFoundResult(),
                _ => new StatusCodeResult(500)
            };
        });
    }
}
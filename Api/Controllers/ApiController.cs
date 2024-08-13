using Application.Errors;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class ApiController : ControllerBase
{
    [NonAction]
    private ObjectResult ToErrorResponse(List<IError> errors)
    {
        string? details = null;
        int code;

        if (errors.Count == 0 || errors.First() is not ErrorBase)
        {
            code = StatusCodes.Status500InternalServerError;
        }
        else
        {
            var error = (ErrorBase)errors.First();
            details = error.Detail;
            code = error.Status;
        }
        
        return Problem(
            detail: details,
            instance: HttpContext.Request.Path,
            statusCode: code
            );
    }
    [NonAction]
    public IActionResult ResultToResponse<T, G>(Result<T> result, Func<T, G> okValueMapper)
    {
        if (result.IsFailed) return ToErrorResponse(result.Errors);
        return Ok(okValueMapper(result.Value));
    }
    [NonAction]
    public IActionResult ResultToResponse(Result result)
    {
        if (result.IsFailed) return ToErrorResponse(result.Errors);
        return Ok();
    }
}
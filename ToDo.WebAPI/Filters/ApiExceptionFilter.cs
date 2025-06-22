using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Extensions;
using ToDo.WebAPI.Models.Errors;

namespace ToDo.WebAPI.Filters;

public class ApiExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var exception = context.Exception;
        
        var response = new ApiErrorResponse
        {
            Message = exception.Message,
            Description = exception.ToText()
        };

        context.Result = new JsonResult(new { response })
        {
            StatusCode = GetStatusCode(exception)
        };

        context.ExceptionHandled = true;
    }

    private static int GetStatusCode(Exception exception)
    {
        return true switch
        {
            { } when exception is NotFoundException => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status400BadRequest
        };
    }
}
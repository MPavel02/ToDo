using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Extensions;
using ToDo.Domain.Services;
using ToDo.WebAPI.Models.Errors;
using LogLevel = ToDo.Domain.Enums.LogLevel;

namespace ToDo.WebAPI.Filters;

public class ApiExceptionFilter(ILoggerService loggerService) : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var exception = context.Exception;
        
        loggerService.LogAsync(LogLevel.Exception, exception.Message, exception);
        
        var response = new ApiErrorResponse
        {
            Message = exception.Message,
            Description = exception.ToText()
        };

        context.Result = new JsonResult(response)
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
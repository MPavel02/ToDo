using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Extensions;
using ToDo.WebAPI.Enums;
using ToDo.WebAPI.Model;

namespace ToDo.WebAPI.Filters;

public class ApiExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        var statusCode = StatusCodes.Status400BadRequest;
        ApiErrorResponse response;

        switch (true)
        {
            case { } when exception is NotFoundException:
                statusCode = StatusCodes.Status404NotFound;
                response = new ApiErrorResponse
                {
                    Code = ErrorCodes.NotFound,
                    Message = exception.Message,
                    Description = exception.ToText()
                };
                break;
            default:
                response = new ApiErrorResponse
                {
                    Code = ErrorCodes.Default,
                    Message = exception.Message,
                    Description = exception.ToText()
                };
                break;
        }
        
        context.Result = new JsonResult(new { response })
        {
            StatusCode = statusCode
        };

        context.ExceptionHandled = true;
    }
}
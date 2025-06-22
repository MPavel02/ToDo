using ToDo.WebAPI.Enums;

namespace ToDo.WebAPI.Models.Errors;

public class ApiErrorResponse
{
    public required ErrorCodes Code { get; set; }
    public required string Message { get; set; }
    public string? Description { get; set; }
}
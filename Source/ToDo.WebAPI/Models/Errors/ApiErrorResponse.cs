namespace ToDo.WebAPI.Models.Errors;

public class ApiErrorResponse
{
    public required string Message { get; set; }
    public string? Description { get; set; }
}
namespace ToDo.WebAPI.Models.Errors;

public readonly record struct ApiErrorResponse(
    string Message,
    string? Description);
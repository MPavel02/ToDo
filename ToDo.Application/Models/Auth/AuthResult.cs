namespace ToDo.Application.Models.Auth;

public class AuthResult
{
    public bool Success { get; set; }
    public string? Error { get; set; }
    public string? Token { get; set; }
    public Guid UserID { get; set; }
}
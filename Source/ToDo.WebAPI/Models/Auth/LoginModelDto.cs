namespace ToDo.WebAPI.Models.Auth;

public class LoginModelDto
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}
namespace ToDo.WebAPI.Models.Auth;

public readonly record struct LoginModelDto(
    string Username,
    string Password);
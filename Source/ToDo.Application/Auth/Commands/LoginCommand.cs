using MediatR;
using ToDo.Application.Models.Auth;

namespace ToDo.Application.Auth.Commands;

public class LoginCommand : IRequest<AuthResult>
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}
using MediatR;

namespace ToDo.Application.Users.Commands;

public record CreateUserCommand : IRequest<Guid>
{
    public required string Username { get; set; }
    public required string PasswordHash { get; set; }
}
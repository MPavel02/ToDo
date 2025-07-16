using MediatR;

namespace ToDo.Application.Users.Commands;

public class UpdateUserCommand(Guid ID, string username) : IRequest<Unit>
{
    public Guid ID { get; } = ID;
    public string Username { get; } = username;
}
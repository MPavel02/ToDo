using MediatR;

namespace ToDo.Application.Users.Commands;

public class DeleteUserCommand(Guid ID) : IRequest<Unit>
{
    public Guid ID { get; } = ID;
}
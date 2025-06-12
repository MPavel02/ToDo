using MediatR;

namespace ToDo.Application.Users.Commands.DeleteCommand;

public class DeleteUserCommand : IRequest<Unit>
{
    public Guid ID { get; set; }
}
using MediatR;

namespace ToDo.Application.Users.Commands.DeleteUser;

public class DeleteUserCommand : IRequest<Unit>
{
    public Guid ID { get; set; }
}
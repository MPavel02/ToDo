using MediatR;

namespace ToDo.Application.Users.Commands.UpdateUser;

public class UpdateUserCommand : IRequest<Unit>
{
    public Guid ID { get; set; }
    public required string Name { get; set; }
}
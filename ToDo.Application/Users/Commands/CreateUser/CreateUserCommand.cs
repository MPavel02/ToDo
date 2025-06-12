using MediatR;

namespace ToDo.Application.Users.Commands.CreateUser;

public class CreateUserCommand : IRequest<Guid>
{
    public required string Name { get; set; }
}
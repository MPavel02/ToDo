using MediatR;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;

namespace ToDo.Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<CreateUserCommand, Guid>
{
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            ID = Guid.NewGuid(),
            Name = request.Name
        };
        
        await userRepository.AddAsync(user, cancellationToken);

        return user.ID;
    }
}
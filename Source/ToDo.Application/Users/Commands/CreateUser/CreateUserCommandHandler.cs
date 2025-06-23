using MediatR;
using ToDo.Domain.Entities;
using ToDo.Domain.Enums;
using ToDo.Domain.Repositories;
using ToDo.Domain.ValueObjects;

namespace ToDo.Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<CreateUserCommand, Guid>
{
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(
            Guid.NewGuid(),
            Username.From(request.Username),
            request.PasswordHash,
            RoleTypes.User,
            DateTime.UtcNow);
        
        await userRepository.AddAsync(user, cancellationToken);

        return user.ID;
    }
}
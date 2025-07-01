using MediatR;
using ToDo.Domain.DomainEntities;
using ToDo.Domain.Enums;
using ToDo.Domain.Repositories;
using ToDo.Domain.ValueObjects;

namespace ToDo.Application.Users.Commands.Handlers;

public class CreateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<CreateUserCommand, Guid>
{
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = UserDomain.Create(Username.From(request.Username), request.PasswordHash);

        await userRepository.AddAsync(user, cancellationToken);

        return user.ID;
    }
}
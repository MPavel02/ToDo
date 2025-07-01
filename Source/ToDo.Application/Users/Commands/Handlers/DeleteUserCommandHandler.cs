using MediatR;
using ToDo.Domain.DomainEntities;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Repositories;

namespace ToDo.Application.Users.Commands.Handlers;

public class DeleteUserCommandHandler(IUserRepository userRepository) : IRequestHandler<DeleteUserCommand, Unit>
{
    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIDAsync(request.ID, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(nameof(UserDomain), request.ID);
        }

        await userRepository.DeleteAsync(user.ID, cancellationToken);
        
        return Unit.Value;
    }
}
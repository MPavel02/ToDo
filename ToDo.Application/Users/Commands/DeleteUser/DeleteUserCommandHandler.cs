using MediatR;
using ToDo.Application.Exceptions;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;

namespace ToDo.Application.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler(IUserRepository userRepository) : IRequestHandler<DeleteUserCommand, Unit>
{
    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIDAsync(request.ID, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(nameof(User), request.ID);
        }

        await userRepository.DeleteAsync(user, cancellationToken);
        
        return Unit.Value;
    }
}
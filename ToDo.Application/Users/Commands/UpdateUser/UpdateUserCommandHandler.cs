using MediatR;
using ToDo.Domain.Entities;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Repositories;

namespace ToDo.Application.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<UpdateUserCommand, Unit>
{
    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIDAsync(request.ID, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(nameof(User), request.ID);
        }
        
        user.Name = request.Name;
        user.UpdatedAt = DateTime.UtcNow;
        
        await userRepository.UpdateAsync(user, cancellationToken);
        
        return Unit.Value;
    }
}
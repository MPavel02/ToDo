using MediatR;
using ToDo.Domain.DomainEntities;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Repositories;
using ToDo.Domain.ValueObjects;

namespace ToDo.Application.Users.Commands.Handlers;

public class UpdateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<UpdateUserCommand, Unit>
{
    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIDAsync(request.ID, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(nameof(UserDomain), request.ID);
        }
        
        user.ChangeName(Username.From(request.Username));

        foreach (var note in request.Notes)
        {
            user.UpdateNote(note.ID, note.Title, note.Details);
        }
        
        await userRepository.UpdateAsync(user, cancellationToken);
        
        return Unit.Value;
    }
}
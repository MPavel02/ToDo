using MediatR;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;
using ToDo.Domain.ValueObjects;

namespace ToDo.Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<CreateUserCommand, Guid>
{
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(Guid.NewGuid(), Username.From(request.Name), DateTime.UtcNow);

        foreach (var note in request.Notes)
        {
            user.AddNote(note.Title, note.Details);
        }
        
        await userRepository.AddAsync(user, cancellationToken);

        return user.ID;
    }
}
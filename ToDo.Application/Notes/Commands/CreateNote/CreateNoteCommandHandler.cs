using MediatR;
using ToDo.Domain.Entities;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Repositories;

namespace ToDo.Application.Notes.Commands.CreateNote;

public class CreateNoteCommandHandler(IUserRepository userRepository, INoteRepository noteRepository)
    : IRequestHandler<CreateNoteCommand, Guid>
{
    public async Task<Guid> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIDAsync(request.UserID, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(nameof(User), request.UserID);
        }

        var note = new Note
        {
            ID = Guid.NewGuid(),
            Title = request.Title,
            Details = request.Details,
            UserID = user.ID
        };
        
        await noteRepository.AddAsync(note, cancellationToken);
        
        return note.ID;
    }
}
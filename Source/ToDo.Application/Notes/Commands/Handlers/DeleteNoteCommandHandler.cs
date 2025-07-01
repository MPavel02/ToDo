using MediatR;
using ToDo.Domain.DomainEntities;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Repositories;

namespace ToDo.Application.Notes.Commands.Handlers;

public class DeleteNoteCommandHandler(INoteRepository noteRepository) : IRequestHandler<DeleteNoteCommand, Unit>
{
    public async Task<Unit> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
    {
        var note = await noteRepository.GetByIDAsync(request.ID, cancellationToken);

        if (note is null || note.UserID != request.UserID)
        {
            throw new NotFoundException(nameof(NoteDomain), request.ID);
        }
        
        await noteRepository.DeleteAsync(note.ID, cancellationToken);
        
        return Unit.Value;
    }
}
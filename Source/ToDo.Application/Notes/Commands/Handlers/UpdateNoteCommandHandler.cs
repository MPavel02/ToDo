using MediatR;
using ToDo.Domain.DomainEntities;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Repositories;

namespace ToDo.Application.Notes.Commands.Handlers;

internal class UpdateNoteCommandHandler(INoteRepository noteRepository) : IRequestHandler<UpdateNoteCommand, Unit>
{
    public async Task<Unit> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
    {
        var note = await noteRepository.GetByIDAsync(request.ID, cancellationToken);

        if (note is null || note.UserID != request.UserID)
        {
            throw new NotFoundException(nameof(NoteDomain), request.ID);
        }
        
        note.Update(request.Title, request.Details);

        await noteRepository.UpdateAsync(note, cancellationToken);

        return Unit.Value;
    }
}
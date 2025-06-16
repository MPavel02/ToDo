using MediatR;
using ToDo.Domain.Entities;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Repositories;

namespace ToDo.Application.Notes.Commands.UpdateNote;

public class UpdateNoteCommandHandler(INoteRepository noteRepository) : IRequestHandler<UpdateNoteCommand, Unit>
{
    public async Task<Unit> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
    {
        var note = await noteRepository.GetByIDAsync(request.ID, cancellationToken);

        if (note is null || note.UserID != request.UserID)
        {
            throw new NotFoundException(nameof(Note), request.ID);
        }

        if (!string.IsNullOrWhiteSpace(request.Title))
        {
            note.Title = request.Title;
        }

        if (request.Details is not null)
        {
            note.Details = request.Details;
        }

        await noteRepository.UpdateAsync(note, cancellationToken);

        return Unit.Value;
    }
}
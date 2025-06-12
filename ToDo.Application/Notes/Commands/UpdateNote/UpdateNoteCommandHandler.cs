using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Application.Exceptions;
using ToDo.DAL;
using ToDo.Domain.Entities;

namespace ToDo.Application.Notes.Commands.UpdateNote;

public class UpdateNoteCommandHandler(ToDoDbContext context) : IRequestHandler<UpdateNoteCommand, Unit>
{
    public async Task<Unit> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
    {
        var note = await context.Notes.FirstOrDefaultAsync(note => note.ID == request.ID, cancellationToken);

        if (note is null)
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

        await context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
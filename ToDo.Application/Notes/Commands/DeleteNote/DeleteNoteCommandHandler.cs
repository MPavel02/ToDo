using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Application.Exceptions;
using ToDo.DAL;
using ToDo.Domain.Entities;

namespace ToDo.Application.Notes.Commands.DeleteNote;

public class DeleteNoteCommandHandler(ToDoDbContext context) : IRequestHandler<DeleteNoteCommand, Unit>
{
    public async Task<Unit> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
    {
        var note = await context.Notes
            .Include(note => note.User)
            .FirstOrDefaultAsync(note => note.ID == request.ID, cancellationToken);

        if (note is null || note.UserID != request.UserID)
        {
            throw new NotFoundException(nameof(Note), request.ID);
        }
        
        context.Notes.Remove(note);
        await context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
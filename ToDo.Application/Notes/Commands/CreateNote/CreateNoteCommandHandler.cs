using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Application.Exceptions;
using ToDo.DAL;
using ToDo.Domain.Entities;

namespace ToDo.Application.Notes.Commands.CreateNote;

public class CreateNoteCommandHandler(ToDoDbContext context) : IRequestHandler<CreateNoteCommand, Guid>
{
    public async Task<Guid> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        var user = await context.Users.FirstOrDefaultAsync(user => user.ID == request.UserID, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(nameof(User), request.UserID);
        }

        var note = new Note
        {
            ID = Guid.NewGuid(),
            Title = request.Title,
            Details = request.Details,
            User = user
        };
        
        await context.Notes.AddAsync(note, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        
        return note.ID;
    }
}
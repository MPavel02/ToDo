using MediatR;

namespace ToDo.Application.Notes.Commands.CreateNote;

public class CreateNoteCommand : IRequest<Guid>
{
    public required string Title { get; set; }
    public required string Details { get; set; }
    
    public required Guid UserID { get; set; }
}
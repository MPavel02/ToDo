using MediatR;

namespace ToDo.Application.Notes.Commands.CreateNote;

public class CreateNoteCommand : IRequest<Guid>
{
    public Guid ID { get; set; }
    public Guid UserID { get; set; }
    public required string Title { get; set; }
    public required string Details { get; set; }
}
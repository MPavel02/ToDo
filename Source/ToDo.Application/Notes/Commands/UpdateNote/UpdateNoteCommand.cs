using MediatR;

namespace ToDo.Application.Notes.Commands.UpdateNote;

public class UpdateNoteCommand : IRequest<Unit>
{
    public Guid ID { get; set; }
    public Guid UserID { get; set; }
    public required string Title { get; set; }
    public required string Details { get; set; }
}
using MediatR;

namespace ToDo.Application.Notes.Commands.DeleteNote;

public class DeleteNoteCommand : IRequest<Unit>
{
    public required Guid ID { get; set; }
    public required Guid UserID { get; set; }
}
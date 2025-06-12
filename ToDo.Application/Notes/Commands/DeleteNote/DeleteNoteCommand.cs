using MediatR;

namespace ToDo.Application.Notes.Commands.DeleteNote;

public class DeleteNoteCommand : IRequest<Unit>
{
    public Guid ID { get; set; }
    public Guid UserID { get; set; }
}
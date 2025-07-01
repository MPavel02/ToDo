using MediatR;

namespace ToDo.Application.Notes.Commands;

public class DeleteNoteCommand : IRequest<Unit>
{
    public required Guid ID { get; set; }
    public required Guid UserID { get; set; }
}
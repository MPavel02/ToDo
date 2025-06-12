using MediatR;

namespace ToDo.Application.Notes.Commands.UpdateNote;

public class UpdateNoteCommand : IRequest<Unit>
{
    public Guid ID { get; set; }
    public string? Title { get; set; }
    public string? Details { get; set; }
}
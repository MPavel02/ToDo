using MediatR;
using ToDo.Application.Models.Note;

namespace ToDo.Application.Notes.Queries;

public class GetNoteByIDQuery : IRequest<NoteDto>
{
    public Guid ID { get; set; }
}
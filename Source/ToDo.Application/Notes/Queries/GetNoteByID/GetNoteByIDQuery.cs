using MediatR;
using ToDo.Application.Models.Note;

namespace ToDo.Application.Notes.Queries.GetNoteByID;

public class GetNoteByIDQuery : IRequest<NoteDto>
{
    public Guid ID { get; set; }
}
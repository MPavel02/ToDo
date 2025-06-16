using MediatR;
using ToDo.Application.Models.Note;

namespace ToDo.Application.Notes.Queries.GetNoteByID;

public class GetNoteByIDQuery(Guid ID) : IRequest<NoteDto>
{
    public Guid ID { get; set; } = ID;
}
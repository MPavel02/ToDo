using MediatR;
using ToDo.Domain.Models.Note;

namespace ToDo.Application.Notes.Queries.GetNoteByID;

public class GetNoteByIDQuery(Guid ID) : IRequest<NoteModel>
{
    public Guid ID { get; set; } = ID;
}
using MediatR;
using ToDo.Domain.Models.Note;

namespace ToDo.Application.Notes.Queries.GetAllNotes;

public class GetNoteListQuery : IRequest<NoteListModel>
{
    public required Guid UserID { get; set; }
}
using MediatR;
using ToDo.Application.Models.Note;

namespace ToDo.Application.Notes.Queries;

public class GetNoteListQuery : IRequest<NoteListDto>
{
    public required Guid UserID { get; set; }
}
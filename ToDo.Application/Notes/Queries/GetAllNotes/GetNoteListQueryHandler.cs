using Mapster;
using MediatR;
using ToDo.Application.Models;
using ToDo.Application.Models.Note;
using ToDo.Domain.Repositories;

namespace ToDo.Application.Notes.Queries.GetAllNotes;

public class GetNoteListQueryHandler(INoteRepository noteRepository) : IRequestHandler<GetNoteListQuery, NoteListModel>
{
    public async Task<NoteListModel> Handle(GetNoteListQuery request, CancellationToken cancellationToken)
    {
        var notes = await noteRepository.GetAllByIDAsync(request.UserID, cancellationToken);
        
        return new NoteListModel
        {
            Notes = notes.Select(note => note.Adapt<NoteLookupDto>()).ToList(),
        };
    }
}
using MediatR;
using ToDo.Application.Mappers;
using ToDo.Application.Models.Note;
using ToDo.Domain.Repositories;

namespace ToDo.Application.Notes.Queries.Handlers;

internal class GetNoteListQueryHandler(INoteRepository noteRepository) : IRequestHandler<GetNoteListQuery, NoteListDto>
{
    public async Task<NoteListDto> Handle(GetNoteListQuery request, CancellationToken cancellationToken)
    {
        var notes = await noteRepository.GetAllByIDAsync(request.UserID, cancellationToken);
        
        return new NoteListDto
        {
            Notes = notes.Select(note => note.MapToLookup()).ToList()
        };
    }
}
using MediatR;
using ToDo.Application.Mappers;
using ToDo.Domain.Entities;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Models.Note;
using ToDo.Domain.Repositories;

namespace ToDo.Application.Notes.Queries.GetNoteByID;

public class GetNoteByIDQueryHandler(INoteRepository noteRepository) : IRequestHandler<GetNoteByIDQuery, NoteModel>
{
    public async Task<NoteModel> Handle(GetNoteByIDQuery request, CancellationToken cancellationToken)
    {
        var note = await noteRepository.GetByIDAsync(request.ID, cancellationToken);

        if (note is null)
        {
            throw new NotFoundException(nameof(Note), request.ID);
        }
        
        return note.Map();
    }
}
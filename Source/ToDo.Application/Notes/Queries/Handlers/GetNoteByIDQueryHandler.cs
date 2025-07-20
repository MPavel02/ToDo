using MediatR;
using ToDo.Application.Mappers;
using ToDo.Application.Models.Note;
using ToDo.Domain.DomainEntities;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Repositories;

namespace ToDo.Application.Notes.Queries.Handlers;

internal class GetNoteByIDQueryHandler(INoteRepository noteRepository) : IRequestHandler<GetNoteByIDQuery, NoteDto>
{
    public async Task<NoteDto> Handle(GetNoteByIDQuery request, CancellationToken cancellationToken)
    {
        var note = await noteRepository.GetByIDAsync(request.ID, cancellationToken);

        if (note is null)
        {
            throw new NotFoundException(nameof(NoteDomain), request.ID);
        }
        
        return note.Map();
    }
}
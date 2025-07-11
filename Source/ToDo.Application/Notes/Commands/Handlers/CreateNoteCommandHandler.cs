﻿using MediatR;
using ToDo.Domain.DomainEntities;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Repositories;

namespace ToDo.Application.Notes.Commands.Handlers;

public class CreateNoteCommandHandler(IUserRepository userRepository, INoteRepository noteRepository)
    : IRequestHandler<CreateNoteCommand, Guid>
{
    public async Task<Guid> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIDAsync(request.UserID, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(nameof(UserDomain), request.UserID);
        }

        var note = NoteDomain.Create(user.ID, request.Title, request.Details);
        
        await noteRepository.AddAsync(note, cancellationToken);
        
        return note.ID;
    }
}
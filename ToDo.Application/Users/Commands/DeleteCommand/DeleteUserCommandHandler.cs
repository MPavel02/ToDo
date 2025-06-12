using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Application.Exceptions;
using ToDo.DAL;
using ToDo.Domain.Entities;

namespace ToDo.Application.Users.Commands.DeleteCommand;

public class DeleteUserCommandHandler(ToDoDbContext context) : IRequestHandler<DeleteUserCommand, Unit>
{
    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await context.Users.FirstOrDefaultAsync(user => user.ID == request.ID, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(nameof(User), request.ID);
        }

        context.Users.Remove(user);
        await context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
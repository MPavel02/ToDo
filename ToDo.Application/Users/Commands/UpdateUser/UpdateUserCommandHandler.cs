using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Application.Exceptions;
using ToDo.DAL;
using ToDo.Domain.Entities;

namespace ToDo.Application.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler(ToDoDbContext context) : IRequestHandler<UpdateUserCommand, Unit>
{
    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await context.Users.FirstOrDefaultAsync(user => user.ID == request.ID, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(nameof(User), request.ID);
        }
        
        user.Name = request.Name;
        user.UpdatedAt = DateTime.UtcNow;
        
        await context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
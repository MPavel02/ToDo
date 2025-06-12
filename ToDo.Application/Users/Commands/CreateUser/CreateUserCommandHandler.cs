using MediatR;
using ToDo.DAL;
using ToDo.Domain.Entities;

namespace ToDo.Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler(ToDoDbContext context) : IRequestHandler<CreateUserCommand, Guid>
{
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            ID = Guid.NewGuid(),
            Name = request.Name
        };
        
        await context.Users.AddAsync(user, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return user.ID;
    }
}
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Application.Exceptions;
using ToDo.Application.Mappers;
using ToDo.DAL;
using ToDo.Domain.Entities;
using ToDo.Domain.Models.User;

namespace ToDo.Application.Users.Queries.GetUserByID;

public class GetUserByIDQueryHandler(ToDoDbContext context) : IRequestHandler<GetUserByIDQuery, UserModel>
{
    public async Task<UserModel> Handle(GetUserByIDQuery request, CancellationToken cancellationToken)
    {
        var user = await context.Users.FirstOrDefaultAsync(user => user.ID == request.ID, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(nameof(User), request.ID);
        }

        return user.Map();
    }
}
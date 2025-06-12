using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Application.Mappers;
using ToDo.DAL;
using ToDo.Domain.Models.User;

namespace ToDo.Application.Users.Queries.GetAllUsers;

public class GetUserListQueryHandler(ToDoDbContext context) : IRequestHandler<GetUserListQuery, UserListModel>
{
    public async Task<UserListModel> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        var users = await context.Users.ToListAsync(cancellationToken: cancellationToken);

        return new UserListModel
        {
            Users = users.Select(user => user.MapToLookup()).ToList(),
        };
    }
}
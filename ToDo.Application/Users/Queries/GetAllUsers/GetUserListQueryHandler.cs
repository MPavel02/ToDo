using Mapster;
using MediatR;
using ToDo.Application.Models.User;
using ToDo.Domain.Repositories;

namespace ToDo.Application.Users.Queries.GetAllUsers;

public class GetUserListQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserListQuery, UserListModel>
{
    public async Task<UserListModel> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        var users = await userRepository.GetAllAsync(cancellationToken);

        return new UserListModel
        {
            Users = users.Select(user => user.Adapt<UserLookupDto>()).ToList(),
        };
    }
}
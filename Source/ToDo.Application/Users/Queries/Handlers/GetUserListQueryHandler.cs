using MediatR;
using ToDo.Application.Mappers;
using ToDo.Application.Models.User;
using ToDo.Domain.Repositories;

namespace ToDo.Application.Users.Queries.Handlers;

public class GetUserListQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserListQuery, UserListDto>
{
    public async Task<UserListDto> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        var users = await userRepository.GetAllAsync(cancellationToken);

        return new UserListDto
        {
            Users = users.Select(user => user.MapToLookup()).ToList(),
        };
    }
}
using MediatR;
using ToDo.Application.Mappers;
using ToDo.Application.Models.User;
using ToDo.Domain.Entities;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Repositories;

namespace ToDo.Application.Users.Queries.GetUserInfo;

public class GetUserInfoQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserInfoQuery, UserDto>
{
    public async Task<UserDto> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByNameAsync(request.Username, cancellationToken);

        if (user is null)
            throw new NotFoundException(nameof(User), request.Username);

        return user.Map();
    }
}
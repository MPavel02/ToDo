using MediatR;
using ToDo.Application.Mappers;
using ToDo.Application.Models.User;
using ToDo.Domain.DomainEntities;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Repositories;

namespace ToDo.Application.Users.Queries.Handlers;

internal class GetUserInfoQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserInfoQuery, UserDto>
{
    public async Task<UserDto> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByNameAsync(request.Username, cancellationToken);

        if (user is null)
            throw new NotFoundException(nameof(UserDomain), request.Username);

        return user.Map();
    }
}
using MediatR;
using ToDo.Application.Mappers;
using ToDo.Application.Models.User;
using ToDo.Domain.Entities;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Repositories;

namespace ToDo.Application.Users.Queries.GetUserByID;

public class GetUserByIDQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserByIDQuery, UserDto>
{
    public async Task<UserDto> Handle(GetUserByIDQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIDAsync(request.ID, cancellationToken);

        if (user is null)
            throw new NotFoundException(nameof(User), request.ID);

        return user.Map();
    }
}
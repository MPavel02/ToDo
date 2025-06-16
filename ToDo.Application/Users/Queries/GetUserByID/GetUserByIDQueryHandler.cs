using MediatR;
using ToDo.Application.Mappers;
using ToDo.Domain.Entities;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Models.User;
using ToDo.Domain.Repositories;

namespace ToDo.Application.Users.Queries.GetUserByID;

public class GetUserByIDQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserByIDQuery, UserModel>
{
    public async Task<UserModel> Handle(GetUserByIDQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIDAsync(request.ID, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(nameof(User), request.ID);
        }

        return user.Map();
    }
}
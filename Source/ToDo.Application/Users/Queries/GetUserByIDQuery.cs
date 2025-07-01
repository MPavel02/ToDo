using MediatR;
using ToDo.Application.Models.User;

namespace ToDo.Application.Users.Queries;

public class GetUserByIDQuery(Guid ID) : IRequest<UserDto>
{
    public Guid ID { get; } = ID;
}
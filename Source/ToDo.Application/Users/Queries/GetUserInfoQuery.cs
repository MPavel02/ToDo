using MediatR;
using ToDo.Application.Models.User;
using ToDo.Domain.ValueObjects;

namespace ToDo.Application.Users.Queries;

public class GetUserInfoQuery(Username username) : IRequest<UserDto>
{
    public Username Username { get; } = username;
}
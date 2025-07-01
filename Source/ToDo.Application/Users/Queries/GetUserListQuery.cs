using MediatR;
using ToDo.Application.Models.User;

namespace ToDo.Application.Users.Queries;

public class GetUserListQuery : IRequest<UserListDto>;
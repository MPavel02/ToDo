using MediatR;
using ToDo.Application.Models.User;

namespace ToDo.Application.Users.Queries.GetAllUsers;

public class GetUserListQuery : IRequest<UserListModel>;
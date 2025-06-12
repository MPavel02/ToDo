using MediatR;
using ToDo.Domain.Models.User;

namespace ToDo.Application.Users.Queries.GetAllUsers;

public class GetUserListQuery : IRequest<UserListModel> { }
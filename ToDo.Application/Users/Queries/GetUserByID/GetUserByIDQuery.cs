using MediatR;
using ToDo.Domain.Models.User;

namespace ToDo.Application.Users.Queries.GetUserByID;

public class GetUserByIDQuery : IRequest<UserModel>
{
    public Guid ID { get; set; }
}
using MediatR;
using ToDo.Domain.Models.User;

namespace ToDo.Application.Users.Queries.GetUserByID;

public class GetUserByIDQuery(Guid ID) : IRequest<UserModel>
{
    public Guid ID { get; } = ID;
}
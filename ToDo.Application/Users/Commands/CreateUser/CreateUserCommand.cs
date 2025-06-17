using MediatR;
using ToDo.Application.Models.Note;

namespace ToDo.Application.Users.Commands.CreateUser;

public record CreateUserCommand : IRequest<Guid>
{
    public required string Name { get; set; }
    public ICollection<CreateNoteModel> Notes { get; set; }
}
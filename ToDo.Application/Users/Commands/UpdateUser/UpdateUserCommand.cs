using MediatR;
using ToDo.Application.Models.Note;

namespace ToDo.Application.Users.Commands.UpdateUser;

public class UpdateUserCommand : IRequest<Unit>
{
    public Guid ID { get; set; }
    public required string Name { get; set; }
    public ICollection<UpdateNoteModel> Notes { get; set; }
}
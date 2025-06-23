using ToDo.Application.Models.Note;

namespace ToDo.Application.Models.User;

public class UserLookupDto
{
    public Guid ID { get; set; }
    public string Username { get; set; }
    public ICollection<NoteLookupDto> Notes { get; set; }
}
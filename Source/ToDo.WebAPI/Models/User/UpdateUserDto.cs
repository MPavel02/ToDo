﻿using ToDo.Application.Models.Note;

namespace ToDo.WebAPI.Models.User;

public class UpdateUserDto
{
    public Guid ID { get; set; }
    public required string Username { get; set; }
    public ICollection<UpdateNoteModel> Notes { get; set; }
}
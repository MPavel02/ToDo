namespace ToDo.WebAPI.Models.Note;

public readonly record struct UpdateNoteDto(
    Guid ID,
    Guid UserID,
    string Title,
    string Details);
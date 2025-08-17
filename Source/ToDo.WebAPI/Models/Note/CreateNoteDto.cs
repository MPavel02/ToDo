namespace ToDo.WebAPI.Models.Note;

public readonly record struct CreateNoteDto(
    string Title,
    string Details,
    Guid UserID);
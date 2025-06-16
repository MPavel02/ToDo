using ToDo.Application.Notes.Commands.CreateNote;
using ToDo.Application.Notes.Commands.DeleteNote;
using ToDo.Application.Notes.Commands.UpdateNote;
using ToDo.Domain.Entities;
using ToDo.Domain.Models.Note;

namespace ToDo.Application.Mappers;

public static class NoteMapper
{
    public static NoteModel Map(this Note entity) =>
        new()
        {
            ID = entity.ID,
            Title = entity.Title,
            Details = entity.Details,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt
        };
    
    public static NoteLookupDto MapToLookup(this Note entity) =>
        new()
        {
            ID = entity.ID,
            Title = entity.Title
        };
    
    public static CreateNoteCommand Map(this CreateNoteDto dto) =>
        new()
        {
            Title = dto.Title,
            Details = dto.Details,
            UserID = dto.UserID
        };

    public static UpdateNoteCommand Map(this UpdateNoteDto dto) =>
        new()
        {
            ID = dto.ID,
            Title = dto.Title,
            Details = dto.Details,
            UserID = dto.UserID
        };
}
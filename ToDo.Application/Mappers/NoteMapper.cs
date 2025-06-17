using ToDo.Application.Models.Note;
using ToDo.Domain.Entities;

namespace ToDo.Application.Mappers;

public static class NoteMapper
{
    public static NoteDto Map(this Note note)
    {
        return new NoteDto
        {
            ID = note.ID,
            Title = note.Title,
            Details = note.Details,
            CreatedAt = note.CreatedAt,
            UpdatedAt = note.UpdatedAt
        };
    }
    
    public static NoteLookupDto MapToLookup(this Note note)
    {
        return new NoteLookupDto
        {
            ID = note.ID,
            Title = note.Title
        };
    }
    
    public static ICollection<NoteDto> Map(this IEnumerable<Note> notes)
    {
        return notes.Select(Map).ToList();
    }
    
    public static ICollection<NoteLookupDto> MapToLookup(this IEnumerable<Note> notes)
    {
        return notes.Select(MapToLookup).ToList();
    }
}
using ToDo.DAL.Entities;
using ToDo.Domain.DomainEntities;

namespace ToDo.DAL.Mappers;

internal static class NoteMapper
{
    public static NoteDomain Map(this Note note)
    {
        return NoteDomain.LoadFromDb(
            note.ID,
            note.CreatedAt,
            note.UpdatedAt,
            note.UserID,
            note.Title,
            note.Details);
    }

    public static IEnumerable<NoteDomain> Map(this IEnumerable<Note> notes)
    {
        return notes.Select(Map);
    }
    
    public static Note Map(this NoteDomain note)
    {
        return new Note
        {
            ID = note.ID,
            CreatedAt = note.CreatedAt,
            UpdatedAt = note.UpdatedAt,
            Title = note.Title,
            Details = note.Details,
            UserID = note.UserID
        };
    }
    
    public static IEnumerable<Note> Map(this IEnumerable<NoteDomain> notes)
    {
        return notes.Select(Map);
    }
    
    public static void Map(NoteDomain source, Note target)
    {
        target.UpdatedAt = source.UpdatedAt;
        
        target.Title = source.Title;
        target.Details = source.Details;
        
        target.UserID = source.UserID;
    }
}
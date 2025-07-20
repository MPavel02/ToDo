using ToDo.Application.Models.Note;
using ToDo.Domain.DomainEntities;

namespace ToDo.Application.Mappers;

internal static class NoteMapper
{
    public static NoteDto Map(this NoteDomain noteDomain)
    {
        return new NoteDto
        {
            ID = noteDomain.ID,
            Title = noteDomain.Title,
            Details = noteDomain.Details,
            CreatedAt = noteDomain.CreatedAt,
            UpdatedAt = noteDomain.UpdatedAt
        };
    }
    
    public static NoteLookupDto MapToLookup(this NoteDomain noteDomain)
    {
        return new NoteLookupDto
        {
            ID = noteDomain.ID,
            Title = noteDomain.Title
        };
    }
    
    public static ICollection<NoteDto> Map(this IEnumerable<NoteDomain> notes)
    {
        return notes.Select(Map).ToList();
    }
    
    public static ICollection<NoteLookupDto> MapToLookup(this IEnumerable<NoteDomain> notes)
    {
        return notes.Select(MapToLookup).ToList();
    }
}
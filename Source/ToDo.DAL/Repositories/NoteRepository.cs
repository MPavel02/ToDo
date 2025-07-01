using Microsoft.EntityFrameworkCore;
using ToDo.DAL.Mappers;
using ToDo.DAL.Persistence;
using ToDo.Domain.DomainEntities;
using ToDo.Domain.Repositories;

namespace ToDo.DAL.Repositories;

public class NoteRepository(ToDoDbContext context) : INoteRepository
{
    public async Task<NoteDomain?> GetByIDAsync(Guid ID, CancellationToken cancellationToken = default)
    {
        var note = await context.Notes
            .Include(note => note.User)
            .FirstOrDefaultAsync(note => note.ID == ID, cancellationToken);
        
        return note?.Map();
    }

    public async Task<IEnumerable<NoteDomain>> GetAllByIDAsync(Guid userID, CancellationToken cancellationToken = default)
    {
        var notes = await context.Notes.Where(note => note.UserID == userID).ToListAsync(cancellationToken);
        
        return notes.Map();
    }

    public async Task AddAsync(NoteDomain entity, CancellationToken cancellationToken = default)
    {
        await context.Notes.AddAsync(entity.Map(), cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(NoteDomain entity, CancellationToken cancellationToken = default)
    {
        var note = await context.Notes.FindAsync([entity.ID], cancellationToken);

        if (note is null)
            return;
        
        NoteMapper.Map(entity, note);
        
        context.Notes.Update(note);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid ID, CancellationToken cancellationToken = default)
    {
        var note = await context.Notes.FindAsync([ID], cancellationToken);
        
        if (note is null)
            return;
        
        context.Notes.Remove(note);
        await context.SaveChangesAsync(cancellationToken);
    }
}
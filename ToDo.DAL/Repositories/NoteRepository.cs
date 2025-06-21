using Microsoft.EntityFrameworkCore;
using ToDo.DAL.Persistence;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;

namespace ToDo.DAL.Repositories;

public class NoteRepository(IToDoDbContextFactory contextFactory) : INoteRepository
{
    public async Task<Note?> GetByIDAsync(Guid ID, CancellationToken cancellationToken = default)
    {
        await using var dbContext = contextFactory.Create();
        
        return await dbContext.Notes
            .Include(note => note.User)
            .FirstOrDefaultAsync(note => note.ID == ID, cancellationToken);
    }

    public async Task<IList<Note>> GetAllByIDAsync(Guid userID, CancellationToken cancellationToken = default)
    {
        await using var dbContext = contextFactory.Create();
        
        return await dbContext.Notes.Where(note => note.UserID == userID).ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Note entity, CancellationToken cancellationToken = default)
    {
        await using var dbContext = contextFactory.Create();
        
        await dbContext.Notes.AddAsync(entity, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Note entity, CancellationToken cancellationToken = default)
    {
        await using var dbContext = contextFactory.Create();
        
        dbContext.Notes.Update(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Note entity, CancellationToken cancellationToken = default)
    {
        await using var dbContext = contextFactory.Create();
        
        dbContext.Notes.Remove(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
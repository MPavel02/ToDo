using Microsoft.EntityFrameworkCore;
using ToDo.DAL.Persistence;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;

namespace ToDo.DAL.Repositories;

public class NoteRepository(ToDoDbContext context) : INoteRepository
{
    public async Task<Note?> GetByIDAsync(Guid ID, CancellationToken cancellationToken = default)
    {
        return await context.Notes
            .Include(note => note.User)
            .FirstOrDefaultAsync(note => note.ID == ID, cancellationToken);
    }

    public async Task<IList<Note>> GetAllByIDAsync(Guid userID, CancellationToken cancellationToken = default)
    {
        return await context.Notes.Where(note => note.UserID == userID).ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Note entity, CancellationToken cancellationToken = default)
    {
        await context.Notes.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Note entity, CancellationToken cancellationToken = default)
    {
        context.Notes.Update(entity);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Note entity, CancellationToken cancellationToken = default)
    {
        context.Notes.Remove(entity);
        await context.SaveChangesAsync(cancellationToken);
    }
}
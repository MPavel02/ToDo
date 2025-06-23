using Microsoft.EntityFrameworkCore;
using ToDo.DAL.Persistence;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;
using ToDo.Domain.ValueObjects;

namespace ToDo.DAL.Repositories;

public class UserRepository(ToDoDbContext context) : IUserRepository
{
    public async Task<User?> GetByIDAsync(Guid ID, CancellationToken cancellationToken = default)
    {
        return await context.Users
            .Include(user => user.Notes)
            .FirstOrDefaultAsync(user => user.ID == ID, cancellationToken);
    }

    public async Task<User?> GetByNameAsync(Username username, CancellationToken cancellationToken = default)
    {
        return await context.Users
            .Include(user => user.Notes)
            .FirstOrDefaultAsync(user => user.Username.Value == username.Value, cancellationToken);
    }

    public async Task<IList<User>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await context.Users
            .Include(user => user.Notes)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(User entity, CancellationToken cancellationToken = default)
    {
        await context.Users.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(User entity, CancellationToken cancellationToken = default)
    {
        context.Users.Update(entity);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(User entity, CancellationToken cancellationToken = default)
    {
        context.Users.Remove(entity);
        await context.SaveChangesAsync(cancellationToken);
    }
}
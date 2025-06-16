using Microsoft.EntityFrameworkCore;
using ToDo.DAL.Persistence;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;

namespace ToDo.DAL.Repositories;

public class UserRepository(ToDoDbContext context) : IUserRepository
{
    public async Task<User?> GetByIDAsync(Guid ID, CancellationToken cancellationToken = default)
    {
        return await context.Users.FindAsync([ID], cancellationToken);
    }

    public async Task<IList<User>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await context.Users.ToListAsync(cancellationToken);
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
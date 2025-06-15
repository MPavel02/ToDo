using Microsoft.EntityFrameworkCore;
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

    public async Task AddAsync(User user, CancellationToken cancellationToken = default)
    {
        await context.Users.AddAsync(user, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(User user, CancellationToken cancellationToken = default)
    {
        context.Users.Update(user);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(User user, CancellationToken cancellationToken = default)
    {
        context.Users.Remove(user);
        await context.SaveChangesAsync(cancellationToken);
    }
}
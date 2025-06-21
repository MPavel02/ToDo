using Microsoft.EntityFrameworkCore;
using ToDo.DAL.Persistence;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;

namespace ToDo.DAL.Repositories;

public class UserRepository(IToDoDbContextFactory contextFactory) : IUserRepository
{
    public async Task<User?> GetByIDAsync(Guid ID, CancellationToken cancellationToken = default)
    {
        await using var dbContext = contextFactory.Create();
        
        return await dbContext.Users
            .Include(user => user.Notes)
            .FirstOrDefaultAsync(user => user.ID == ID, cancellationToken);
    }

    public async Task<IList<User>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        await using var dbContext = contextFactory.Create();
        
        return await dbContext.Users
            .Include(user => user.Notes)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(User entity, CancellationToken cancellationToken = default)
    {
        await using var dbContext = contextFactory.Create();
        
        await dbContext.Users.AddAsync(entity, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(User entity, CancellationToken cancellationToken = default)
    {
        await using var dbContext = contextFactory.Create();
        
        dbContext.Users.Update(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(User entity, CancellationToken cancellationToken = default)
    {
        await using var dbContext = contextFactory.Create();
        
        dbContext.Users.Remove(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
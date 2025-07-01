using Microsoft.EntityFrameworkCore;
using ToDo.DAL.Entities;
using ToDo.DAL.Mappers;
using ToDo.DAL.Persistence;
using ToDo.Domain.DomainEntities;
using ToDo.Domain.Repositories;
using ToDo.Domain.ValueObjects;

namespace ToDo.DAL.Repositories;

public class UserRepository(ToDoDbContext context) : IUserRepository
{
    public async Task<UserDomain?> GetByIDAsync(Guid ID, CancellationToken cancellationToken = default)
    {
        var user = await context.Users
            .Include(user => user.Notes)
            .FirstOrDefaultAsync(user => user.ID == ID, cancellationToken);
        
        return user?.Map();
    }

    public async Task<UserDomain?> GetByNameAsync(Username username, CancellationToken cancellationToken = default)
    {
        var user = await context.Users
            .Include(user => user.Notes)
            .FirstOrDefaultAsync(user => user.Username == username.Value, cancellationToken);
        
        return user?.Map();
    }

    public async Task<IEnumerable<UserDomain>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var users = await context.Users
            .Include(user => user.Notes)
            .ToListAsync(cancellationToken);

        return users.Map();
    }

    public async Task AddAsync(UserDomain entity, CancellationToken cancellationToken = default)
    {
        await context.Users.AddAsync(entity.Map(), cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(UserDomain entity, CancellationToken cancellationToken = default)
    {
        var user = await context.Users.FindAsync([entity.ID], cancellationToken);

        if (user is null)
            return;
        
        UserMapper.Map(entity, user);
        
        context.Users.Update(user);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid ID, CancellationToken cancellationToken = default)
    {
        var user = await context.Users.FindAsync([ID], cancellationToken);
        
        if (user is null)
            return;
        
        context.Users.Remove(user);
        await context.SaveChangesAsync(cancellationToken);
    }
}
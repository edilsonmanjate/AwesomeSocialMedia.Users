using AwesomeSocialMedia.Users.Core.Entities;
using AwesomeSocialMedia.Users.Core.Repositories;

using Microsoft.EntityFrameworkCore;

namespace AwesomeSocialMedia.Users.Infraestructure.Persistence.Repository;

public class UserRepository : IUserRepository
{
    private readonly UsersDbContext _context;
    public UserRepository(UsersDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        
        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
        return user;
    }

    public Task UpdateAsync(User user)
    {
        //_context.Entry(user).State = EntityState.Modified;
        _context.Users.Update(user);
        return _context.SaveChangesAsync();
    }
}

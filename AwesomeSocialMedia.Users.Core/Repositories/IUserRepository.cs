using AwesomeSocialMedia.Users.Core.Entities;

namespace AwesomeSocialMedia.Users.Core.Repositories;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task<User> GetByAsync(Guid id);
    Task<User> GetByEmailAsync(string email);
}

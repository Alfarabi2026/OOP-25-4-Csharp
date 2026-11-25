using WitcherWorld.Domain.Entities;

namespace WitcherWorld.Application.Interfaces.Repositories;

public interface IUserRepository
{
  
    Task<User?> GetByIdAsync(int id);
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByUsernameAsync(string username);

    Task<bool> ExistsByEmailAsync(string email);
    Task<bool> ExistsByUsernameAsync(string username);

    Task AddAsync(User user);
    void Update(User user);
}
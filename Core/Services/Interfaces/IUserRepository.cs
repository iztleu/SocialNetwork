using Core.Entities;

namespace Core.Services.Interfaces;

public interface IUserRepository
{
    public Task AddUserAsync(User user);
    
    public Task<User?> GetUserByEmailAsync(string email);
}
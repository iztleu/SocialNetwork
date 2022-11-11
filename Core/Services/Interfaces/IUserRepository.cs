using Core.Entities;

namespace Core.Services.Interfaces;

public interface IUserRepository
{
    public Task AddUserAsync(User user, CancellationToken cancellationToken);
    public Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
    public Task<int> UpdateAsync(User user, CancellationToken cancellationToken);
}
using Phone.Domain.Entities.Authenticates;

namespace Phone.Domain.Contract.IRepositories;

public interface IUserRepository
{
    Task SaveChangesAsync(CancellationToken cancellationToken);
    ValueTask<User> GetUserAsync(string userName, CancellationToken cancellationToken);
    Task AddAsync(User user, CancellationToken cancellationToken);
}

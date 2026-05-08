using Microsoft.EntityFrameworkCore;
using Phone.Domain.Contract.IRepositories;
using Phone.Domain.Entities.Authenticates;
using Phone.Infrastructure.EfCore.Context;

namespace Phone.Infrastructure.EfCore.Repositories;

public class UserRepository(
    PhoneContext context)
    : IUserRepository
{
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        => await context.SaveChangesAsync(cancellationToken);

    public async ValueTask<User> GetUserAsync(string userName, CancellationToken cancellationToken)
         => await context.Users.SingleOrDefaultAsync(x => x.UserName == userName);

    public async Task AddAsync(User user, CancellationToken cancellationToken)
        => await context.Users.AddAsync(user, cancellationToken);
}

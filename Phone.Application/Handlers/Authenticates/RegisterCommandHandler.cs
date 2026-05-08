using MediatR;
using Phone.Application.Contract.CommandsQueries.Authenticates;
using Phone.Domain.Contract.IRepositories;
using Phone.Domain.Entities.Authenticates;
using Phone.Utility;

namespace Phone.Application.Handlers.Authenticates;

public class RegisterCommandHandler(
    IUserRepository userRepository,
    EncryptionUtility encryptionUtility)
    : IRequestHandler<RegisterCommand>
{
    public async Task Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var salt = encryptionUtility.GetNewSalt();
        var hashPassword = encryptionUtility.GetSHA256(request.Password, salt);

        var user = new User
        {
            Id = Guid.NewGuid(),
            Password = hashPassword,
            PasswordSalt = salt,
            RegisterDate = DateTime.Now,
            UserName = request.UserName
        };

        await userRepository.AddAsync(user, cancellationToken);
        await userRepository.SaveChangesAsync(cancellationToken);
    }
}







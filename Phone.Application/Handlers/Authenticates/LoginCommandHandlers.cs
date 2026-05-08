using MediatR;
using Phone.Application.Contract.CommandsQueries.Authenticates;
using Phone.Domain.Contract.IRepositories;
using Phone.Domain.Entities.Authenticates;
using Phone.Utility;

namespace Phone.Application.Handlers.Authenticates;

public class LoginCommandHandlers(
    IUserRepository userRepository,
    EncryptionUtility encryptionUtility)
    : IRequestHandler<LoginCommand, LoginCommandResponse>
{
    public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetUserAsync(request.UserName, cancellationToken);

        if (user is null) throw new Exception();

        var hashPassword = encryptionUtility.GetSHA256(request.Password, user.PasswordSalt);
        if (user.Password != hashPassword) throw new Exception();

        var token = encryptionUtility.GetNewToken(user.Id);

        var response = new LoginCommandResponse()
        {
            UserName = user.UserName,
            Token = token
        };

        return response;
    }
}

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Phone.Utility.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


namespace Phone.Utility;

public class EncryptionUtility(IOptions<Configs> configs)
{
    public string GetSHA256(string password, string salt)
    {
        using (var sha256 = SHA256.Create())
        {
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
            var hash = BitConverter.ToString(bytes).Replace("-", "").ToLower();
            return hash;
        }
    }

    public string GetNewSalt()
        => Guid.NewGuid().ToString();

    public string GetNewToken(Guid userId)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(configs.Value.TokenKey);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim("userId", userId.ToString())
            }),
            Expires = DateTime.UtcNow.AddMinutes(configs.Value.TokenTimeout),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}

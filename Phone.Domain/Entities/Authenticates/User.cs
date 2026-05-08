namespace Phone.Domain.Entities.Authenticates;

public class User
{
    public Guid Id { get; set; }
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public string PasswordSalt { get; set; }
    public DateTime RegisterDate { get; set; }
    public DateTime? LastLoginDate { get; set; }
}

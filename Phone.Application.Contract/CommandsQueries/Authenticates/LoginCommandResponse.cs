namespace Phone.Application.Contract.CommandsQueries.Authenticates;

public class LoginCommandResponse
{
	public string UserName { get; set; }
	public string Token { get; set; }
	public int ExpireTime { get; set; }
}

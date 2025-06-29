namespace ProjectVideo.Core.Interactors.DataObjects;

public class AuthenticateUserInput
{
	public required string UserName { get; init; }
	public required string Password { get; init; }
}

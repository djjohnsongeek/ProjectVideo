namespace ProjectVideo.Core.Interactors.DataObjects;

public class AuthenticateUserResult : InteractorResult
{
	public required UserDetails UserDetails { get; set; }
}

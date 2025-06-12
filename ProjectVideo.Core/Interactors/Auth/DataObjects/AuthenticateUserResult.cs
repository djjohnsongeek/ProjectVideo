using ProjectVideo.Core.Interactors.Auth.DataObjects;

namespace ProjectVideo.Core.Interactors.DataObjects
{
	public class AuthenticateUserResult : InteractorResult
	{
		public UserDetails? UserDetails { get; set; }
		public bool IsAuthenticated { get; set; }
	}
}

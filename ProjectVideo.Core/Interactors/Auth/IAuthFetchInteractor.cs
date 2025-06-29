using ProjectVideo.Core.Interactors.DataObjects;

namespace ProjectVideo.Core.Interactors;

public interface IAuthFetchInteractor
{
	Task<AuthenticateUserResult> AuthenticateUser(AuthenticateUserInput input);
}

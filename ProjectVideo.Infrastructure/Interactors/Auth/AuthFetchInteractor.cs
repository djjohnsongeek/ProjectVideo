using Microsoft.EntityFrameworkCore;
using ProjectVideo.Core.Interactors;
using ProjectVideo.Core.Interactors.DataObjects;
using ProjectVideo.Infrastructure.Data;
using ProjectVideo.Infrastructure.Data.Entities;

namespace ProjectVideo.Infrastructure.Interactors;

public class AuthFetchInteractor: Interactor, IAuthFetchInteractor
{
	private const string _authFailedMessage = "Login failed. Invalid username or password.";
	public AuthFetchInteractor(ProjectVideoDbContext dbContext) : base(dbContext)
	{

	}

	public async Task<AuthenticateUserResult> AuthenticateUser(AuthenticateUserInput input)
	{
		AuthenticateUserResult result = new AuthenticateUserResult
		{
			UserDetails = UserDetails.Empty,
		};

		User? user = await _dbContext.Users
			.Where(x => x.UserName == input.UserName || x.Email == x.UserName)
			.FirstOrDefaultAsync();

		if (user == null)
		{
			result.AddAuthError(_authFailedMessage);
		}

		if (!result.HasErrors)
		{
			PasswordHasher hasher = new PasswordHasher();
			if (!hasher.VerifyHashedPassword(user!.HashedPassword, input.Password))
			{
				result.AddAuthError(_authFailedMessage);
			}
			else
			{
				result.SetAuthenticated(true);
				result.UserDetails = new UserDetails
				{
					Username = user.UserName,
					RoleNames = user.Roles.Select(r => r.Name).ToList(),
				};
			}

		}

		return result;
	}

}

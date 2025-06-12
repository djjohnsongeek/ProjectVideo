using Microsoft.EntityFrameworkCore;
using ProjectVideo.Core.Interactors.DataObjects;
using ProjectVideo.Infrastructure.Data;
using ProjectVideo.Infrastructure.Data.Entities;

namespace ProjectVideo.Infrastructure.Interactors.Auth
{
	public class AuthFetchInteractor: Interactor
	{
		public AuthFetchInteractor(ProjectVideoDbContext dbContext) : base(dbContext)
		{

		}

		public async Task<AuthenticateUserResult> AuthenticateUser(AuthenticateUserInput input)
		{
			//var hasher = new PasswordHasher();
			//AuthenticateUserResult

			//User? user = await _dbContext.Users
			//	.Where(x => x.UserName == input.UserName)
			//	.FirstOrDefaultAsync();

			return new AuthenticateUserResult();
		}

	}
}

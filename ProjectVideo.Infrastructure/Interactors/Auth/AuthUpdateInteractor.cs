using ProjectVideo.Core.Interactors;
using ProjectVideo.Infrastructure.Data;

namespace ProjectVideo.Infrastructure.Interactors.Auth
{
	public class AuthUpdateInteractor: Interactor, IAuthUpdateInteractor
	{
		public AuthUpdateInteractor(ProjectVideoDbContext dbContext): base(dbContext)
		{

		}
	}
}

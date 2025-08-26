using ProjectVideo.Infrastructure.Data;

namespace ProjectVideo.Infrastructure.Interactors.Auth
{
	public class AuthUpdateInteractor: Interactor
	{
		public AuthUpdateInteractor(ProjectVideoDbContext dbContext): base(dbContext)
		{

		}
	}
}

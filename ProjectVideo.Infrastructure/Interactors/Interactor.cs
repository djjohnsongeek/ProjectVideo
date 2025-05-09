using ProjectVideo.Infrastructure.Data;

namespace ProjectVideo.Infrastructure.Interactors
{
	public class Interactor
	{
		protected readonly ProjectVideoDbContext _dbContext;

		public Interactor(ProjectVideoDbContext dbContext)
		{
			_dbContext = dbContext;
		}
	}
}

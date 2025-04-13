using Microsoft.EntityFrameworkCore;
using ProjectVideo.Infrastructure.Data;
using ProjectVideo.Core.Interactors.Proposal;

namespace ProjectVideo.Infrastructure.Interactors
{
	public class ProposalsFetchInteractor : IProposalsFetchInteractor
	{
		private readonly ProjectVideoDbContext _dbContext;

		public ProposalsFetchInteractor(ProjectVideoDbContext dbcontext)
		{
			_dbContext = dbcontext;
		}

		public async Task GetProposals()
		{
			var result = await _dbContext.Proposals.ToListAsync();
		}
	}
}

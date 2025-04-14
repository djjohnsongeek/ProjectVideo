using Microsoft.EntityFrameworkCore;
using ProjectVideo.Infrastructure.Data;
using ProjectVideo.Core.Interactors.Proposal;

namespace ProjectVideo.Infrastructure.Interactors
{
	public class ProposalFetchInteractor : IProposalFetchInteractor
	{
		private readonly ProjectVideoDbContext _dbContext;

		public ProposalFetchInteractor(ProjectVideoDbContext dbcontext)
		{
			_dbContext = dbcontext;
		}

		public async Task GetProposals()
		{
			var result = await _dbContext.Proposals.ToListAsync();
		}
	}
}

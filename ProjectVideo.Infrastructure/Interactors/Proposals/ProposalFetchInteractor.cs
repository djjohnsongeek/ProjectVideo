using Microsoft.EntityFrameworkCore;
using ProjectVideo.Infrastructure.Data;
using ProjectVideo.Core.Interactors.Proposal;
using ProjectVideo.Core.Interactors;

namespace ProjectVideo.Infrastructure.Interactors
{
	public class ProposalFetchInteractor : Interactor, IProposalFetchInteractor
	{
		public ProposalFetchInteractor(ProjectVideoDbContext dbContext) : base(dbContext)
		{

		}

		public async Task<ProposalListResult> GetProposals()
		{
			var queryResult = await _dbContext.Proposals.ToListAsync();
			ProposalListResult result = new ProposalListResult
			{
				Proposals = queryResult.Select(p => new ProposalListResult.ProposalListItem
				{
					ProposalId = p.Id,
					DateSubmitted = p.DateSubmitted,
					ContactName = p.ContactName,
					ProjectTitle = p.ProjectTitle,
					OrganizationName = p.OrganizationName,
					TargetAudience = p.TargetAudience,
				}).ToList()
			};

			return result;
		}
	}
}

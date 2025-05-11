using ProjectVideo.Core.Interactors;
using ProjectVideo.Core.Interactors.Proposal;

namespace ProjectVideo.Web.Models.Proposals
{
	public class ProposalPresenter
	{
		public ProposalsIndexViewModel BuildViewModel(ProposalListResult interactorResult)
		{
			return new ProposalsIndexViewModel
			{
				Data = interactorResult
			};
		}

		public ProposalFormViewModel BuildViewModel(ProposalFormResult interactorResult)
		{
			return new ProposalFormViewModel
			{
				TeamMemberRoles = interactorResult.EthinicTeamRoles
			};
		}
	}
}

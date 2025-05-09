using ProjectVideo.Core.Interactors;

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
	}
}

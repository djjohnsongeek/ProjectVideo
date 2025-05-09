namespace ProjectVideo.Core.Interactors.Proposal
{
	public interface IProposalFetchInteractor
	{
		Task<ProposalListResult> GetProposals();
	}
}

namespace ProjectVideo.Core.Interactors.Proposal
{
	public interface IProposalFetchInteractor
	{
		Task<ProposalListResult> GetProposals();

		Task<ProposalDetailsResult> GetProposal(int id);

        Task<ProposalFormResult> GetFormRequirements();
	}
}

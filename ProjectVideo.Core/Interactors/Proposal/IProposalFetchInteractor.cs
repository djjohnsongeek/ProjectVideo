namespace ProjectVideo.Core.Interactors.Proposal
{
	public interface IProposalFetchInteractor
	{
		Task<ProposalListResult> GetProposals();

		Task<ProposalDetailsResult> GetProposalDetails(int id);

        Task<ProposalFormResult> GetFormRequirements();
	}
}

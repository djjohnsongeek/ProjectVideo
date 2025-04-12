namespace ProjectVideo.Core.Interactors.Proposal
{
	public interface IProposalUpdateInteractor
	{
		Task<InteractorResult> CreateProposal(CreateProposalInput inputData);
	}
}

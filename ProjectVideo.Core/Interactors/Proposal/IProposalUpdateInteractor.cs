using ProjectVideo.Core.Interactors.DataObjects;

namespace ProjectVideo.Core.Interactors;

public interface IProposalUpdateInteractor
{
	Task<InteractorResult> CreateProposal(CreateProposalInput inputData);

	Task<InteractorResult> UpdateProposal(UpdateProposalInput inputData);
}

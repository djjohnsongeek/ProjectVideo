using ProjectVideo.Core.Interactors.DataObjects;

namespace ProjectVideo.Core.Interactors;

public interface IProposalFetchInteractor
{
	Task<ProposalListResult> GetProposals();

	Task<ProposalDetailsResult> GetProposalDetails(int id);

    Task<ProposalFormResult> GetFormRequirements(AppLanguage lang);
}

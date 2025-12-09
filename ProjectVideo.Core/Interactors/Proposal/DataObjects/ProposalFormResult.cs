
using ProjectVideo.Core.Interactors.Proposal.DataObjects;
using System.Diagnostics.CodeAnalysis;

namespace ProjectVideo.Core.Interactors.DataObjects
{
	public class ProposalFormResult : InteractorResult
	{
		public required ProposalFormLocalization Localization;
		public required List<DropdownItem> EthnicTeamRoleOptions;
		public required List<DropdownItem> ProjectTimeframeIntervalOptions;

		[SetsRequiredMembers]
		public ProposalFormResult()
		{
			EthnicTeamRoleOptions = [];
			ProjectTimeframeIntervalOptions = [];
			Localization = ProposalFormLocalization.Empty;
		}
	}
}

using ProjectVideo.Core.Interactors.Proposal.DataObjects;
using System.Diagnostics.CodeAnalysis;

namespace ProjectVideo.Core.Interactors.DataObjects
{
	public class ProposalFormResult : InteractorResult
	{
		public required List<string> EthinicTeamRoles;
		public required ProposalFormLocalization Localization;

		[SetsRequiredMembers]
		public ProposalFormResult()
		{
			EthinicTeamRoles = [];
			Localization = ProposalFormLocalization.Empty;
		}
	}
}
namespace ProjectVideo.Core.Interactors.Proposal.DataObjects
{
	public class ProposalFormLocalization
	{
		public static ProposalFormLocalization Empty => new ProposalFormLocalization
		{

			TeamMemberNameFieldLabel = string.Empty,
			TeamMemberRoleFieldLabel = string.Empty,
			RemoveTeamMemberButtonText = string.Empty,
			PortfolioLinkNameFieldLabel = string.Empty,
			PortfolioLinkUrlFieldLabel = string.Empty,
		};

		public required string TeamMemberNameFieldLabel { get; set; }

		public required string TeamMemberRoleFieldLabel { get; set; }

		public required string RemoveTeamMemberButtonText { get; set; }

		public required string PortfolioLinkNameFieldLabel { get; set; }

		public required string PortfolioLinkUrlFieldLabel { get; set; }
	}
}

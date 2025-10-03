using System.Diagnostics.CodeAnalysis;

namespace ProjectVideo.Core.Interactors.Proposal.DataObjects
{
	public class ProposalFormLocalization
	{
		public static ProposalFormLocalization Empty => new ProposalFormLocalization
		{
			Language = AppLanguage.English,
			AboutUsHeader = string.Empty,
			AboutUsText = string.Empty,
			OrganizationSectionTitle = string.Empty,
			MainContactFieldLabel = string.Empty,
			MainContactFieldText = string.Empty,
			EmailFieldLabel = string.Empty,
			EmailFieldText = string.Empty,
			PhoneNumberFieldLabel = string.Empty,
			PhoneNumberFieldText = string.Empty,
			OrganizationFieldLabel = string.Empty,
			OrganizationHistoryFieldLabel = string.Empty,
			OrganizationHistoryText = string.Empty,
			StaftArePaidCheckboxLabel = string.Empty,
			TeamMembersSectionTitle = string.Empty,
			TeamMemberAddButtonText = string.Empty,
			TeamMemberNameFieldLabel = string.Empty,
			TeamMemberRoleFieldLabel = string.Empty,
			RemoveTeamMemberButtonText = string.Empty,
			ProjectInfoSectionTitle = string.Empty,
			ProjectTitleFieldLabel = string.Empty,
			TargetAudienceFieldLabel = string.Empty,
			KeyObjectivesFieldLabel = string.Empty,
			ProjectTimeFrameFieldLabel = string.Empty,
			MainMethodsFieldLabel = string.Empty,
			MainMethodsFieldText = string.Empty,
			PlannedVideosFieldLabel = string.Empty,
			PlannedVideosFieldText = string.Empty,
			ProjectCostEstimateFieldLabel = string.Empty,
			ProjectCostEsitmateCurrencyLabel = string.Empty,
			ProjectCostFieldText = string.Empty,
			CurrentResourcesSectionTitle = string.Empty,
			CurrentEquipmentFieldLabel = string.Empty,
			CurrentEquipmentFieldText = string.Empty,
			AudioSpaceCheckboxLabel = string.Empty,
			AudioSpaceDescriptionFieldLabel = string.Empty,
			HaveComputerCheckboxLabel = string.Empty,
			ComputerDescriptionFieldLabel = string.Empty,
			ComputerDescriptionFieldText = string.Empty,
			PortfolioSectionTitle = string.Empty,
			AddLinkButtonText = string.Empty,
			PortfolioSectionDescription = string.Empty,
			PortfolioLinkNameFieldLabel = string.Empty,
			PortfolioLinkUrlFieldLabel = string.Empty,
			EndingNoteHeader = string.Empty,
			EndingNoteText = string.Empty,
			SubmitButtonText = string.Empty,
		};

		public AppLanguage Language { get; set; }

		public required string AboutUsHeader { get; set; }

		public required string AboutUsText { get; set; }

		public required string OrganizationSectionTitle { get; set; }

		public required string MainContactFieldLabel { get; set; }

		public required string MainContactFieldText { get; set; }

		public required string EmailFieldLabel { get; set; }

		public required string EmailFieldText { get; set; }

		public required string PhoneNumberFieldLabel { get; set; }

		public required string PhoneNumberFieldText { get; set; }

		public required string OrganizationFieldLabel { get; set; }

		public required string OrganizationHistoryFieldLabel { get; set; }

		public required string OrganizationHistoryText { get; set; }

		public required string StaftArePaidCheckboxLabel { get; set; }

		public required string TeamMembersSectionTitle { get; set; }

		public required string TeamMemberAddButtonText { get; set; }

		public required string TeamMemberNameFieldLabel { get; set; }

		public required string TeamMemberRoleFieldLabel { get; set; }

		public required string RemoveTeamMemberButtonText { get; set; }

		public required string ProjectInfoSectionTitle { get; set; }

		public required string ProjectTitleFieldLabel { get; set; }

		public required string TargetAudienceFieldLabel { get; set; }

		public required string KeyObjectivesFieldLabel { get; set; }

		public required string ProjectTimeFrameFieldLabel { get; set; }

		public required string MainMethodsFieldLabel { get; set; }

		public required string MainMethodsFieldText { get; set; }

		public required string PlannedVideosFieldLabel { get; set; }

		public required string PlannedVideosFieldText { get; set; }

		public required string ProjectCostEstimateFieldLabel { get; set; }

		public required string ProjectCostEsitmateCurrencyLabel { get; set; }

		public required string ProjectCostFieldText { get; set; }

		public required string CurrentResourcesSectionTitle { get; set; }

		public required string CurrentEquipmentFieldLabel { get; set; }

		public required string CurrentEquipmentFieldText { get; set; }

		public required string AudioSpaceCheckboxLabel { get; set; }

		public required string AudioSpaceDescriptionFieldLabel { get; set; }

		public required string HaveComputerCheckboxLabel { get; set; }

		public required string ComputerDescriptionFieldLabel { get; set; }

		public required string ComputerDescriptionFieldText { get; set; }

		public required string PortfolioSectionTitle { get; set; }

		public required string AddLinkButtonText { get; set; }

		public required string PortfolioSectionDescription { get; set; }

		public required string PortfolioLinkNameFieldLabel { get; set; }

		public required string PortfolioLinkUrlFieldLabel { get; set; }

		public required string EndingNoteHeader { get; set; }

		public required string EndingNoteText { get; set; }

		public required string SubmitButtonText { get; set; }
	}
}

using ProjectVideo.Core;
using System.Diagnostics.CodeAnalysis;

namespace ProjectVideo.Infrastructure.Data.Entities
{
	public class ProjectProposalFormLocalization
	{

		#region Properties
		public int Id { get; set; }

		public AppLanguage Language { get; set; }

		public required string AboutUsHeader { get; set; } = string.Empty;

		public required string AboutUsText { get; set; } = string.Empty;

		public required string OrganizationSectionTitle { get; set; } = string.Empty;

		public required string MainContactFieldLabel { get; set; } = string.Empty;

		public required string MainContactFieldText { get; set; } = string.Empty;

		public required string EmailFieldLabel { get; set; } = string.Empty;

		public required string EmailFieldText { get; set; } = string.Empty;

		public required string PhoneNumberFieldLabel { get; set; } = string.Empty;

		public required string PhoneNumberFieldText { get; set; } = string.Empty;

		public required string OrganizationFieldLabel { get; set; } = string.Empty;

		public required string OrganizationHistoryFieldLabel { get; set; } = string.Empty;

		public required string OrganizationHistoryText { get; set; } = string.Empty;

		public required string StaftArePaidCheckboxLabel { get; set; } = string.Empty;

		public required string TeamMembersSectionTitle { get; set; } = string.Empty;

		public required string TeamMemberAddButtonText { get; set; } = string.Empty;

		public required string TeamMemberNameFieldLabel { get; set; } = string.Empty;

		public required string TeamMemberRoleFieldLabel { get; set; } = string.Empty;

		public required string RemoveTeamMemberButtonText { get; set; } = string.Empty;

		public required string ProjectInfoSectionTitle { get; set; } = string.Empty;

		public required string ProjectTitleFieldLabel { get; set; } = string.Empty;

		public required string TargetAudienceFieldLabel { get; set; } = string.Empty;

		public required string KeyObjectivesFieldLabel { get; set; } = string.Empty;

		public required string ProjectTimeFrameFieldLabel { get; set; } = string.Empty;

		public required string MainMethodsFieldLabel { get; set; } = string.Empty;

		public required string MainMethodsFieldText { get; set; } = string.Empty;

		public required string PlannedVideosFieldLabel { get; set; } = string.Empty;

		public required string PlannedVideosFieldText { get; set; } = string.Empty;

		public required string ProjectCostEstimateFieldLabel { get; set; } = string.Empty;

		public required string ProjectCostEsitmateCurrencyLabel { get; set; } = string.Empty;

		public required string ProjectCostFieldText { get; set; } = string.Empty;

		public required string CurrentResourcesSectionTitle { get; set; } = string.Empty;

		public required string CurrentEquipmentFieldLabel { get; set; } = string.Empty;

		public required string CurrentEquipmentFieldText { get; set; } = string.Empty;

		public required string AudioSpaceCheckboxLabel { get; set; } = string.Empty;

		public required string AudioSpaceDescriptionFieldLabel { get; set; } = string.Empty;

		public required string HaveComputerCheckboxLabel { get; set; } = string.Empty;

		public required string ComputerDescriptionFieldLabel { get; set; } = string.Empty;

		public required string ComputerDescriptionFieldText { get; set; } = string.Empty;

		public required string PortfolioSectionTitle { get; set; } = string.Empty;

		public required string AddLinkButtonText { get; set; } = string.Empty;

		public required string PortfolioSectionDescription { get; set; } = string.Empty;

		public required string PortfolioLinkNameFieldLabel { get; set; } = string.Empty;

		public required string PortfolioLinkUrlFieldLabel { get; set; } = string.Empty;

		public required string EndingNoteHeader { get; set; } = string.Empty;

		public required string EndingNoteText { get; set; } = string.Empty;

		public required string SubmitButtonText { get; set; } = string.Empty;

		#endregion

		public ProjectProposalFormLocalization()
		{
		}

		[SetsRequiredMembers]
		public ProjectProposalFormLocalization(AppLanguage lang)
		{
			Language = lang;
			AboutUsHeader = string.Empty;
			AboutUsText = string.Empty;
			OrganizationSectionTitle = string.Empty;
			MainContactFieldLabel = string.Empty;
			MainContactFieldText = string.Empty;
			EmailFieldLabel = string.Empty;
			EmailFieldText = string.Empty;
			PhoneNumberFieldLabel = string.Empty;
			PhoneNumberFieldText = string.Empty;
			OrganizationFieldLabel = string.Empty;
			OrganizationHistoryFieldLabel = string.Empty;
			OrganizationHistoryText = string.Empty;
			StaftArePaidCheckboxLabel = string.Empty;
			TeamMembersSectionTitle = string.Empty;
			TeamMemberAddButtonText = string.Empty;
			TeamMemberNameFieldLabel = string.Empty;
			TeamMemberRoleFieldLabel = string.Empty;
			RemoveTeamMemberButtonText = string.Empty;
			ProjectInfoSectionTitle = string.Empty;
			ProjectTitleFieldLabel = string.Empty;
			TargetAudienceFieldLabel = string.Empty;
			KeyObjectivesFieldLabel = string.Empty;
			ProjectTimeFrameFieldLabel = string.Empty;
			MainMethodsFieldLabel = string.Empty;
			MainMethodsFieldText = string.Empty;
			PlannedVideosFieldLabel = string.Empty;
			PlannedVideosFieldText = string.Empty;
			ProjectCostEstimateFieldLabel = string.Empty;
			ProjectCostEsitmateCurrencyLabel = string.Empty;
			ProjectCostFieldText = string.Empty;
			CurrentResourcesSectionTitle = string.Empty;
			CurrentEquipmentFieldLabel = string.Empty;
			CurrentEquipmentFieldText = string.Empty;
			AudioSpaceCheckboxLabel = string.Empty;
			AudioSpaceDescriptionFieldLabel = string.Empty;
			HaveComputerCheckboxLabel = string.Empty;
			ComputerDescriptionFieldLabel = string.Empty;
			ComputerDescriptionFieldText = string.Empty;
			PortfolioSectionTitle = string.Empty;
			AddLinkButtonText = string.Empty;
			PortfolioSectionDescription = string.Empty;
			PortfolioLinkNameFieldLabel = string.Empty;
			PortfolioLinkUrlFieldLabel = string.Empty;
			EndingNoteHeader = string.Empty;
			EndingNoteText = string.Empty;
			SubmitButtonText = string.Empty;
		}
	}
}

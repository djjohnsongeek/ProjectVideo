using Microsoft.EntityFrameworkCore;
using ProjectVideo.Infrastructure.Data;
using ProjectVideo.Core.Interactors;
using ProjectVideo.Infrastructure.Data.Entities;
using ProjectVideo.Core.Interactors.DataObjects;
using ProjectVideo.Core.Interactors.Proposal.DataObjects;
using ProjectVideo.Core;
using ProjectVideo.Infrastructure.Services;

namespace ProjectVideo.Infrastructure.Interactors;

public class ProposalFetchInteractor : Interactor, IProposalFetchInteractor
{
	private LocalizationService _localizationService;

	public ProposalFetchInteractor(ProjectVideoDbContext dbContext) : base(dbContext)
	{
		_localizationService = new LocalizationService(dbContext);
	}

	public async Task<ProposalListResult> GetProposals()
	{
		var queryResult = await _dbContext.Proposals.ToListAsync();
		var result = new ProposalListResult
		{
			Proposals = queryResult.Select(ExtractSummary).ToList()
		};

		return result;
	}

	public async Task<ProposalDetailsResult> GetProposalDetails(int id)
	{
		Proposal? propsal = await _dbContext.Proposals
			.Where(p => p.ProposalId == id)
			.Include(p => p.Members)
			.Include(p => p.Links)
			.FirstOrDefaultAsync();

		ProposalDetailsResult result = new ProposalDetailsResult
		{
			Details = ExtractDetails(propsal),
		};

		if (propsal == null)
		{
			result.AddError("Proposal not found.");
		}

		return result;
	}

	public async Task<ProposalFormResult> GetFormRequirements(AppLanguage lang)
	{
		ProposalFormResult result = new ProposalFormResult();

		List<DropdownOption> rolesOptions = await _dbContext.DropdownOptions
			.Where(x => x.DropdownId == DropdownId.EthnicTeamRole)
			.ToListAsync();

		List<DropdownOption> timeFrameOptions = await _dbContext.DropdownOptions
			.Where(x => x.DropdownId == DropdownId.TimeInterval)
			.ToListAsync();
		
		if (_localizationService.FetchFailed)
		{
			result.AddError("Failed to fetch localization data.");
		}

		if (rolesOptions.Count == 0)
		{
			result.AddError("Team roles not found.");
		}

		if (!result.HasErrors)
		{
			result.EthnicTeamRoleOptions = rolesOptions.Select(o => new DropdownItem
			{
				Text = _localizationService.GetLocalizedText(o.LocalizationId, lang),
				Value = o.DropdownOptionId.ToString(),
			}).ToList();
			result.ProjectTimeframeIntervalOptions = timeFrameOptions.Select(o => new DropdownItem
			{
				Text = _localizationService.GetLocalizedText(o.LocalizationId, lang),
				Value = o.DropdownOptionId.ToString(),
			}).ToList();
            result.Localization = new ProposalFormLocalization
			{
				Language = lang,
				PageTitle = _localizationService.GetLocalizedText("PageTitle", lang),
				AboutUsHeader = _localizationService.GetLocalizedText("AboutUsHeader", lang),
				AboutUsText = _localizationService.GetLocalizedText("AboutUsText", lang),
				OrganizationSectionTitle = _localizationService.GetLocalizedText("OrganizationSectionTitle", lang),
				MainContactFieldLabel = _localizationService.GetLocalizedText("MainContactFieldLabel", lang),
				MainContactFieldText = _localizationService.GetLocalizedText("MainContactFieldText", lang),
				EmailFieldLabel = _localizationService.GetLocalizedText("EmailFieldLabel", lang),
				EmailFieldText = _localizationService.GetLocalizedText("EmailFieldText", lang),
				PhoneNumberFieldLabel = _localizationService.GetLocalizedText("PhoneNumberFieldLabel", lang),
				PhoneNumberFieldText = _localizationService.GetLocalizedText("PhoneNumberFieldText", lang),
				OrganizationFieldLabel = _localizationService.GetLocalizedText("OrganizationFieldLabel", lang),
				OrganizationHistoryFieldLabel = _localizationService.GetLocalizedText("OrganizationHistoryFieldLabel", lang),
				OrganizationHistoryText = _localizationService.GetLocalizedText("OrganizationHistoryText", lang),
				StaftArePaidCheckboxLabel = _localizationService.GetLocalizedText("StaftArePaidCheckboxLabel", lang),
				TeamMembersSectionTitle = _localizationService.GetLocalizedText("TeamMembersSectionTitle", lang),
				TeamMemberAddButtonText = _localizationService.GetLocalizedText("TeamMemberAddButtonText", lang),
				TeamMemberNameFieldLabel = _localizationService.GetLocalizedText("TeamMemberNameFieldLabel", lang),
				TeamMemberRoleFieldLabel = _localizationService.GetLocalizedText("TeamMemberRoleFieldLabel", lang),
				RemoveTeamMemberButtonText = _localizationService.GetLocalizedText("RemoveTeamMemberButtonText", lang),
				ProjectInfoSectionTitle = _localizationService.GetLocalizedText("ProjectInfoSectionTitle", lang),
				ProjectTitleFieldLabel = _localizationService.GetLocalizedText("ProjectTitleFieldLabel", lang),
				ProjectCostEstimateFieldLabel = _localizationService.GetLocalizedText("ProjectCostEstimateFieldLabel", lang),
				ProjectCostEsitmateCurrencyLabel = _localizationService.GetLocalizedText("ProjectCostEsitmateCurrencyLabel", lang),
				ProjectCostFieldText = _localizationService.GetLocalizedText("ProjectCostFieldText", lang),
				TargetAudienceFieldLabel = _localizationService.GetLocalizedText("TargetAudienceFieldLabel", lang),
				KeyObjectivesFieldLabel = _localizationService.GetLocalizedText("KeyObjectivesFieldLabel", lang),
				ProjectTimeFrameFieldLabel = _localizationService.GetLocalizedText("ProjectTimeFrameFieldLabel", lang),
				MainMethodsFieldLabel = _localizationService.GetLocalizedText("MainMethodsFieldLabel", lang),
				MainMethodsFieldText = _localizationService.GetLocalizedText("MainMethodsFieldText", lang),
				PlannedVideosFieldLabel = _localizationService.GetLocalizedText("PlannedVideosFieldLabel", lang),
				PlannedVideosFieldText = _localizationService.GetLocalizedText("PlannedVideosFieldText", lang),
				CurrentEquipmentFieldLabel = _localizationService.GetLocalizedText("CurrentEquipmentFieldLabel", lang),
				CurrentEquipmentFieldText = _localizationService.GetLocalizedText("CurrentEquipmentFieldText", lang),
				ComputerDescriptionFieldLabel = _localizationService.GetLocalizedText("ComputerDescriptionFieldLabel", lang),
				ComputerDescriptionFieldText = _localizationService.GetLocalizedText("ComputerDescriptionFieldText", lang),
				HaveComputerCheckboxLabel = _localizationService.GetLocalizedText("HaveComputerCheckboxLabel", lang),
				AudioSpaceDescriptionFieldLabel = _localizationService.GetLocalizedText("AudioSpaceDescriptionFieldLabel", lang),
				AudioSpaceCheckboxLabel = _localizationService.GetLocalizedText("AudioSpaceCheckboxLabel", lang),
				CurrentResourcesSectionTitle = _localizationService.GetLocalizedText("CurrentResourcesSectionTitle", lang),
				PortfolioSectionTitle = _localizationService.GetLocalizedText("PortfolioSectionTitle", lang),
				AddLinkButtonText = _localizationService.GetLocalizedText("AddLinkButtonText", lang),
				PortfolioSectionDescription = _localizationService.GetLocalizedText("PortfolioSectionDescription", lang),
				PortfolioLinkNameFieldLabel = _localizationService.GetLocalizedText("PortfolioLinkNameFieldLabel", lang),
				PortfolioLinkUrlFieldLabel = _localizationService.GetLocalizedText("PortfolioLinkUrlFieldLabel", lang),
				EndingNoteHeader = _localizationService.GetLocalizedText("EndingNoteHeader", lang),
				EndingNoteText = _localizationService.GetLocalizedText("EndingNoteText", lang),
				SubmitButtonText = _localizationService.GetLocalizedText("SubmitButtonText", lang),
			};
		}

		return result;
	}

    private ProposalListResult.ProposalSummary ExtractSummary(Proposal p)
	{
		return new ProposalListResult.ProposalSummary
		{
			ProposalId = p.ProposalId,
			DateSubmitted = p.DateSubmitted,
			ProjectTitle = p.ProjectTitle,
			OrganizationName = p.OrganizationName,
			TargetAudience = p.TargetAudience,
			InfoMeetingDate = p.InterviewDate,
			Status = p.Status,
		};
	}

    private ProposalDetails ExtractDetails(Proposal? entity)
	{
		if (entity != null)
		{
                return new ProposalDetails
                {
				ProposalId = entity.ProposalId,
				ProjectTitle = entity.ProjectTitle,
				ContactName = entity.ContactName,
				ContactPhoneNumber = entity.ContactPhoneNumber,
				ContactEmail = entity.ContactEmail,
				OrganizationName = entity.OrganizationName,
				OrganizationHistory = entity.OrganizationHistory,
				DateSubmitted = entity.DateSubmitted,
				Methods = entity.Methods,
				PlannedVideos = entity.PlannedVideos,
				StaffArePaid = entity.StaffArePaid,
				EstimatedProjectCost = entity.EstimatedProjectCost,
				KeyObjectives = entity.KeyObjectives,
				TargetAudience = entity.TargetAudience,
				ProjectTimeFrameInterval = entity.ProjectTimeFrameInterval,
				ProjectTimeFrameTotal = entity.ProjectTimeFrameTotal,
				CurrentEquipment = entity.CurrentEquipment,
				HasComputer = entity.HasComputer,
				ComputerDescription = entity.ComputerDescription,
				HasAudioSpace = entity.HasAudioSpace,
				AudioSpaceDescription = entity.AudioSpaceDescription,
				Links = entity.Links.Select(x => new ProposalLinkDetails
				{
					Name = x.Name,
					Url = x.Url
				}).ToList(),
				Members = entity.Members.Select(x => new ProposalMemberDetails
				{
					Name = x.Name,
					Role = x.Role
				}).ToList(),
				CoordinatorProperties = new CoordinatorProperties
				{
					InterviewDate = entity.InterviewDate,
					CoordinatorNotes = entity.CoordinatorNotes,
					Status = entity.Status,
					InterviewLink = entity.InterviewLink,
				}
				
                };
            }
		else
		{
			return ProposalDetails.Empty;
		}
	}
}

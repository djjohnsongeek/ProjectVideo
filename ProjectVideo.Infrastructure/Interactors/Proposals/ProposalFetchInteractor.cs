using Microsoft.EntityFrameworkCore;
using ProjectVideo.Infrastructure.Data;
using ProjectVideo.Core.Interactors;
using ProjectVideo.Infrastructure.Data.Entities;
using ProjectVideo.Core.Interactors.DataObjects;
using ProjectVideo.Core.Interactors.Proposal.DataObjects;
using ProjectVideo.Core;

namespace ProjectVideo.Infrastructure.Interactors;

public class ProposalFetchInteractor : Interactor, IProposalFetchInteractor
{
	public ProposalFetchInteractor(ProjectVideoDbContext dbContext) : base(dbContext) { }

	public async Task<ProposalListResult> GetProposals()
	{
		var queryResult = await _dbContext.Proposals.ToListAsync();
		ProposalListResult result = new ProposalListResult
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
			.Include(x => x.Localization)
			.ToListAsync();

		List<DropdownOption> timeFrameOptions = await _dbContext.DropdownOptions
			.Where(x => x.DropdownId == DropdownId.TimeInterval)
			.Include(x => x.Localization)
			.ToListAsync();

		List<Localization> localizations = await _dbContext.Localizations
			.Where(l => l.Page == "Proposals/Form")
			.ToListAsync();

		if (localizations.Count == 0)
		{
			result.AddError("Form localization not found.");
		}

		if (rolesOptions.Count == 0)
		{
			result.AddError("Team roles not found.");
		}

		if (!result.HasErrors)
		{
			result.EthnicTeamRoleOptions = rolesOptions.Select(o => new DropdownItem
			{
				Text = GetText(o.Localization, lang),
				Value = o.DropdownOptionId.ToString(),
			}).ToList();
			result.ProjectTimeframeIntervalOptions = timeFrameOptions.Select(o => new DropdownItem
			{
				Text = GetText(o.Localization, lang),
				Value = o.DropdownOptionId.ToString(),
			}).ToList();
            result.Localization = new ProposalFormLocalization
			{
				Language = lang,
				PageTitle = GetLocalizedText(localizations, "PageTitle", lang),
				AboutUsHeader = GetLocalizedText(localizations, "AboutUsHeader", lang),
				AboutUsText = GetLocalizedText(localizations, "AboutUsText", lang),
				OrganizationSectionTitle = GetLocalizedText(localizations, "OrganizationSectionTitle", lang),
				MainContactFieldLabel = GetLocalizedText(localizations, "MainContactFieldLabel", lang),
				MainContactFieldText = GetLocalizedText(localizations, "MainContactFieldText", lang),
				EmailFieldLabel = GetLocalizedText(localizations, "EmailFieldLabel", lang),
				EmailFieldText = GetLocalizedText(localizations, "EmailFieldText", lang),
				PhoneNumberFieldLabel = GetLocalizedText(localizations, "PhoneNumberFieldLabel", lang),
				PhoneNumberFieldText = GetLocalizedText(localizations, "PhoneNumberFieldText", lang),
				OrganizationFieldLabel = GetLocalizedText(localizations, "OrganizationFieldLabel", lang),
				OrganizationHistoryFieldLabel = GetLocalizedText(localizations, "OrganizationHistoryFieldLabel", lang),
				OrganizationHistoryText = GetLocalizedText(localizations, "OrganizationHistoryText", lang),
				StaftArePaidCheckboxLabel = GetLocalizedText(localizations, "StaftArePaidCheckboxLabel", lang),
				TeamMembersSectionTitle = GetLocalizedText(localizations, "TeamMembersSectionTitle", lang),
				TeamMemberAddButtonText = GetLocalizedText(localizations, "TeamMemberAddButtonText", lang),
				TeamMemberNameFieldLabel = GetLocalizedText(localizations, "TeamMemberNameFieldLabel", lang),
				TeamMemberRoleFieldLabel = GetLocalizedText(localizations, "TeamMemberRoleFieldLabel", lang),
				RemoveTeamMemberButtonText = GetLocalizedText(localizations, "RemoveTeamMemberButtonText", lang),
				ProjectInfoSectionTitle = GetLocalizedText(localizations, "ProjectInfoSectionTitle", lang),
				ProjectTitleFieldLabel = GetLocalizedText(localizations, "ProjectTitleFieldLabel", lang),
				ProjectCostEstimateFieldLabel = GetLocalizedText(localizations, "ProjectCostEstimateFieldLabel", lang),
				ProjectCostEsitmateCurrencyLabel = GetLocalizedText(localizations, "ProjectCostEsitmateCurrencyLabel", lang),
				ProjectCostFieldText = GetLocalizedText(localizations, "ProjectCostFieldText", lang),
				TargetAudienceFieldLabel = GetLocalizedText(localizations, "TargetAudienceFieldLabel", lang),
				KeyObjectivesFieldLabel = GetLocalizedText(localizations, "KeyObjectivesFieldLabel", lang),
				ProjectTimeFrameFieldLabel = GetLocalizedText(localizations, "ProjectTimeFrameFieldLabel", lang),
				MainMethodsFieldLabel = GetLocalizedText(localizations, "MainMethodsFieldLabel", lang),
				MainMethodsFieldText = GetLocalizedText(localizations, "MainMethodsFieldText", lang),
				PlannedVideosFieldLabel = GetLocalizedText(localizations, "PlannedVideosFieldLabel", lang),
				PlannedVideosFieldText = GetLocalizedText(localizations, "PlannedVideosFieldText", lang),
				CurrentEquipmentFieldLabel = GetLocalizedText(localizations, "CurrentEquipmentFieldLabel", lang),
				CurrentEquipmentFieldText = GetLocalizedText(localizations, "CurrentEquipmentFieldText", lang),
				ComputerDescriptionFieldLabel = GetLocalizedText(localizations, "ComputerDescriptionFieldLabel", lang),
				ComputerDescriptionFieldText = GetLocalizedText(localizations, "ComputerDescriptionFieldText", lang),
				HaveComputerCheckboxLabel = GetLocalizedText(localizations, "HaveComputerCheckboxLabel", lang),
				AudioSpaceDescriptionFieldLabel = GetLocalizedText(localizations, "AudioSpaceDescriptionFieldLabel", lang),
				AudioSpaceCheckboxLabel = GetLocalizedText(localizations, "AudioSpaceCheckboxLabel", lang),
				CurrentResourcesSectionTitle = GetLocalizedText(localizations, "CurrentResourcesSectionTitle", lang),
				PortfolioSectionTitle = GetLocalizedText(localizations, "PortfolioSectionTitle", lang),
				AddLinkButtonText = GetLocalizedText(localizations, "AddLinkButtonText", lang),
				PortfolioSectionDescription = GetLocalizedText(localizations, "PortfolioSectionDescription", lang),
				PortfolioLinkNameFieldLabel = GetLocalizedText(localizations, "PortfolioLinkNameFieldLabel", lang),
				PortfolioLinkUrlFieldLabel = GetLocalizedText(localizations, "PortfolioLinkUrlFieldLabel", lang),
				EndingNoteHeader = GetLocalizedText(localizations, "EndingNoteHeader", lang),
				EndingNoteText = GetLocalizedText(localizations, "EndingNoteText", lang),
				SubmitButtonText = GetLocalizedText(localizations, "SubmitButtonText", lang),
			};
		}

		return result;
	}

	private string GetLocalizedText(List<Localization> localizations, string controlName, AppLanguage lang)
	{
		Localization? loc = localizations.Where(l => l.ControlName == controlName).FirstOrDefault();
		return GetText(loc, lang);
    }

    private string GetText(Localization? loc, AppLanguage lang)
	{
		if (loc == null)
		{
			return "Translation Missing";
        }

        return lang switch
		{
			AppLanguage.English => loc.English,
			AppLanguage.Thai => loc.Thai,
			_ => "Translation Missing",
		};
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

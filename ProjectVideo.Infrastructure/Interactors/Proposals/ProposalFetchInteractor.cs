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

		List<EthnicTeamRole> roles = await _dbContext.EthnicTeamRoles.ToListAsync();
		ProjectProposalFormLocalization? localization = await _dbContext
			.ProjectProposalFormLocalizations
			.Where(l => l.Language == lang)
			.FirstOrDefaultAsync();

		// validation
		if (localization == null)
		{
			result.AddError("Form localization not found.");
		}

		if (roles.Count == 0)
		{
			result.AddError("Team roles not found.");
		}

		if (!result.HasErrors)
		{
			result.EthinicTeamRoles = roles.Select(r => r.Name).ToList();
			result.Localization = new ProposalFormLocalization
			{
				Language = localization!.Language,
				AboutUsHeader = localization.AboutUsHeader,
				AboutUsText = localization.AboutUsText,
				OrganizationSectionTitle = localization.OrganizationSectionTitle,
				MainContactFieldLabel = localization.MainContactFieldLabel,
				MainContactFieldText = localization.MainContactFieldText,
				EmailFieldLabel = localization.EmailFieldLabel,
				EmailFieldText = localization.EmailFieldText,
				PhoneNumberFieldLabel = localization.PhoneNumberFieldLabel,
				PhoneNumberFieldText = localization.PhoneNumberFieldText,
				OrganizationFieldLabel = localization.OrganizationFieldLabel,
				OrganizationHistoryFieldLabel = localization.OrganizationHistoryFieldLabel,
				OrganizationHistoryText = localization.OrganizationHistoryText,
				StaftArePaidCheckboxLabel = localization.StaftArePaidCheckboxLabel,
				TeamMembersSectionTitle = localization.TeamMembersSectionTitle,
				TeamMemberAddButtonText = localization.TeamMemberAddButtonText,
				TeamMemberNameFieldLabel = localization.TeamMemberNameFieldLabel,
				TeamMemberRoleFieldLabel = localization.TeamMemberRoleFieldLabel,
				RemoveTeamMemberButtonText = localization.RemoveTeamMemberButtonText,
				ProjectInfoSectionTitle = localization.ProjectInfoSectionTitle,
				ProjectTitleFieldLabel = localization.ProjectTitleFieldLabel,
				ProjectCostEstimateFieldLabel = localization.ProjectCostEstimateFieldLabel,
				ProjectCostEsitmateCurrencyLabel = localization.ProjectCostEsitmateCurrencyLabel,
				ProjectCostFieldText = localization.ProjectCostFieldText,
				TargetAudienceFieldLabel = localization.TargetAudienceFieldLabel,
				KeyObjectivesFieldLabel = localization.KeyObjectivesFieldLabel,
				ProjectTimeFrameFieldLabel = localization.ProjectTimeFrameFieldLabel,
				MainMethodsFieldLabel = localization.MainMethodsFieldLabel,
				MainMethodsFieldText = localization.MainMethodsFieldText,
				PlannedVideosFieldLabel = localization.PlannedVideosFieldLabel,
				PlannedVideosFieldText = localization.PlannedVideosFieldText,
				CurrentEquipmentFieldLabel = localization.CurrentEquipmentFieldLabel,
				CurrentEquipmentFieldText = localization.CurrentEquipmentFieldText,
				ComputerDescriptionFieldLabel = localization.ComputerDescriptionFieldLabel,
				ComputerDescriptionFieldText = localization.ComputerDescriptionFieldText,
				HaveComputerCheckboxLabel = localization.HaveComputerCheckboxLabel,
				AudioSpaceDescriptionFieldLabel = localization.AudioSpaceDescriptionFieldLabel,
				AudioSpaceCheckboxLabel = localization.AudioSpaceCheckboxLabel,
				CurrentResourcesSectionTitle = localization.CurrentResourcesSectionTitle,
				PortfolioSectionTitle = localization.PortfolioSectionTitle,
				AddLinkButtonText = localization.AddLinkButtonText,
				PortfolioSectionDescription = localization.PortfolioSectionDescription,
				PortfolioLinkNameFieldLabel = localization.PortfolioLinkNameFieldLabel,
				PortfolioLinkUrlFieldLabel = localization.PortfolioLinkUrlFieldLabel,
				EndingNoteHeader = localization.EndingNoteHeader,
				EndingNoteText = localization.EndingNoteText,
				SubmitButtonText = localization.SubmitButtonText,
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

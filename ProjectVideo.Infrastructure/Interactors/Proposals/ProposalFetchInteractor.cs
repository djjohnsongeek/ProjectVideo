using Microsoft.EntityFrameworkCore;
using ProjectVideo.Infrastructure.Data;
using ProjectVideo.Core.Interactors.Proposal;
using ProjectVideo.Core.Interactors;
using ProjectVideo.Infrastructure.Data.Entities;

namespace ProjectVideo.Infrastructure.Interactors
{
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
				.Where(p => p.Id == id)
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

		public async Task<ProposalFormResult> GetFormRequirements()
		{
			List<EthnicTeamRole> roles = await _dbContext.EthnicTeamRoles.ToListAsync();
			ProposalFormResult result = new ProposalFormResult
			{
				EthinicTeamRoles = roles.Select(r => r.Name).ToList(),
			};

			return result;
		}

		private ProposalListResult.ProposalSummary ExtractSummary(Proposal p)
		{
			return new ProposalListResult.ProposalSummary
			{
				ProposalId = p.Id,
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
					ProposalId = entity.Id,
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
					Links = entity.Links.Select(x => new VideoLink
					{
						Name = x.Name,
						Url = x.Url
					}).ToList(),
					Members = entity.Members.Select(x => new ProposalMember
					{
						Name = x.Name,
						Role = x.Role
					}).ToList(),
					CoordinatorProperties = new CoordinatorProperties
					{
						InterviewDate = entity.InterviewDate,
						CoordinatorNotes = entity.CoordinatorNotes,
						Status = entity.Status,
					}
					
                };
            }
			else
			{
				return ProposalDetails.Empty;
			}
		}
	}
}

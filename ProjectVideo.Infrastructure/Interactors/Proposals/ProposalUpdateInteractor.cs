using Microsoft.EntityFrameworkCore;
using ProjectVideo.Core.Interactors;
using ProjectVideo.Core.Interactors.Proposal;
using ProjectVideo.Infrastructure.Data;
using ProjectVideo.Infrastructure.Data.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ProjectVideo.Infrastructure.Interactors
{
	public class ProposalUpdateInteractor : Interactor, IProposalUpdateInteractor
	{
		public ProposalUpdateInteractor(ProjectVideoDbContext dbContext) : base (dbContext)
		{
		}

		public async Task<InteractorResult> CreateProposal(CreateProposalInput inputData)
		{
			InteractorResult result = new InteractorResult();
			// TODO Validate
			//var errors = Validate(inputData);

			if (!result.HasErrors)
			{
				Proposal newProposal = BuildProposal(inputData);
				_dbContext.Add(newProposal);

				await UpdateChanges(result, errorContext: "Failed to create new Proposal");
			}

			return result;
		}

		public async Task<InteractorResult> UpdateProposal(UpdateProposalInput inputData)
		{
			InteractorResult result = new InteractorResult();

			Proposal? proposal = await _dbContext.Proposals
				.Where(x => x.Id == inputData.ProposalId)
				.FirstOrDefaultAsync();

			if (proposal == null)
			{
				result.AddError("Proposal Not Found.");
			}

			// TODO Validate

			if (!result.HasErrors)
			{
				// Update entity properties
				proposal!.CoordinatorNotes = inputData.CoordinatorNotes;
				proposal.Status = inputData.Status;
				proposal.InterviewDate = inputData.InterviewDate;

				// Update the entity
				await UpdateChanges(result, errorContext: "Failed to update tthe Proposal");
			}

			return result;
		}

		public Proposal BuildProposal(CreateProposalInput inputData)
		{
			return new Proposal
			{
				DateSubmitted = DateTime.UtcNow,
				ContactEmail = inputData.ContactEmail,
				 ContactPhoneNumber= inputData.ContactPhoneNumber,
				ContactName = inputData.ContactName,
				OrganizationName = inputData.OrganizationName,
				OrganizationHistory = inputData.OrganizationHistory,
				ProjectTitle = inputData.ProjectTitle,
				StaffArePaid = inputData.StaffArePaid,
				TargetAudience = inputData.TargetAudience,
				KeyObjectives = inputData.KeyObjectives,
				ProjectTimeFrameInterval = inputData.ProjectTimeFrameInterval,
				ProjectTimeFrameTotal = inputData.ProjectTimeFrameTotal,
				Methods = inputData.Methods,
				PlannedVideos = inputData.PlannedVideos,
				CurrentEquipment = inputData.CurrentEquipment,
				HasAudioSpace = inputData.HasAudioSpace,
				AudioSpaceDescription = inputData.AudioSpaceDescription,
				HasComputer = inputData.HasComputer,
				ComputerDescription = inputData.ComputerDescription,
				EstimatedProjectCost = inputData.EstimatedProjectCost,
				Members = inputData.Members.Select(m => new ProposalTeamMember
				{
					Name = m.Name,
					Role = m.Role,
				}).ToList(),
				Links = inputData.Links.Select(l => new ProposalLink
				{
					Url = l.Url,
					Name = l.Name
				}).ToList()
			};
		}
	}
}

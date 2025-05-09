using Microsoft.EntityFrameworkCore;
using ProjectVideo.Core.Interactors;
using ProjectVideo.Core.Interactors.Proposal;
using ProjectVideo.Infrastructure.Data;
using ProjectVideo.Infrastructure.Data.Entities;

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

				try
				{
					int changeCount = await _dbContext.SaveChangesAsync();
					if (changeCount == 0)
					{
						result.AddError("Unknown error. Failed to create new Proposal.");
					}
				}
				catch (DbUpdateException ex)
				{
					result.AddError("Database error. Failed to create new Proposal.");
					// TODO Log ex
				}
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

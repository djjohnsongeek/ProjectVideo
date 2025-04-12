using ProjectVideo.Core.Interactors;
using ProjectVideo.Core.Interactors.Proposal;
using ProjectVideo.Infrastructure.Data;
using ProjectVideo.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVideo.Infrastructure.Interactors
{
	public class ProposalUpdateInteractor
	{
		private ProjectVideoDbContext _dbContext;

		public ProposalUpdateInteractor(ProjectVideoDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<InteractorResult> CreateProposal(CreateProposalInput inputData)
		{
			//var errors = Validate(inputData);

			var newProposal = new Proposal
			{
				ContactEmail = inputData.ContactEmail,
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

				})
			}
		}
	}
}

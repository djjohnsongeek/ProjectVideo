using ProjectVideo.Core.Interactors;
using ProjectVideo.Core.Interactors.Proposal;

namespace ProjectVideo.Web.Models.Proposals
{
	public class ProposalPresenter
	{
		public ProposalsIndexViewModel BuildViewModel(ProposalListResult interactorResult)
		{
			return new ProposalsIndexViewModel
			{
				Data = interactorResult
			};
		}

		public ProposalFormViewModel BuildViewModel(ProposalFormResult interactorResult)
		{
			return new ProposalFormViewModel
			{
				TeamMemberRoles = interactorResult.EthinicTeamRoles
			};
		}

        internal ProposalDetailsViewModel BuildViewModel(ProposalDetailsResult result)
        {
            return new ProposalDetailsViewModel
            {
                ProposalId = result.Details.ProposalId,
                ProjectTitle = result.Details.ProjectTitle,
                ContactName = result.Details.ContactName,
                ContactPhoneNumber = result.Details.ContactPhoneNumber,
                ContactEmail = result.Details.ContactEmail,
                OrganizationName = result.Details.OrganizationName,
                OrganizationHistory = result.Details.OrganizationHistory,
                DateSubmitted = result.Details.DateSubmitted.ToShortDateString(),
                Methods = result.Details.Methods,
                PlannedVideos = result.Details.PlannedVideos,
                StaffArePaid = result.Details.StaffArePaid ? "Yes" : "No",
                EstimatedProjectCost = result.Details.EstimatedProjectCost,
                KeyObjectives = result.Details.KeyObjectives,
                TargetAudience = result.Details.TargetAudience,
                ProjectTimeFrameInterval = result.Details.ProjectTimeFrameInterval,
                ProjectTimeFrameTotal = result.Details.ProjectTimeFrameTotal,
                CurrentEquipment = result.Details.CurrentEquipment,
                HasComputer = result.Details.HasComputer ? "Yes" : "No",
                ComputerDescription = result.Details.ComputerDescription,
                HasAudioSpace = result.Details.HasAudioSpace ? "Yes" : "No",
                AudioSpaceDescription = result.Details.AudioSpaceDescription,
                Links = result.Details.Links,
                Members = result.Details.Members,
            };
        }
    }
}

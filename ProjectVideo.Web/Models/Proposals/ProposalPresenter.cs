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
                Proposals = interactorResult.Proposals.Select(BuildProposalSummary).ToList()
            };
        }

		public ProposalFormViewModel BuildViewModel(ProposalFormResult interactorResult)
		{
			return new ProposalFormViewModel
			{
				TeamMemberRoles = interactorResult.EthinicTeamRoles
			};
		}

        private ProposalsIndexViewModel.ProposalSummary BuildProposalSummary(ProposalListResult.ProposalSummary interactorSummary)
        {

            string status;
            switch (interactorSummary.Status)
            {
                case ProposalStatus.Approved:
                case ProposalStatus.Denied:
                    status = interactorSummary.Status.ToString();
                    break;
                case ProposalStatus.Interviewed:
                    status = $"Interviewed on {interactorSummary.InfoMeetingDate!.Value}";
                    break;
                case ProposalStatus.PendingInterview:
                    status = "Pending Interview";
                    break;
                default:
                    status = "Invalid Status";
                    break;
            }

            return new ProposalsIndexViewModel.ProposalSummary
            {
                Status = status,
                InterviewDate = interactorSummary.InfoMeetingDate?.ToString("g"),
                SubmitDate = interactorSummary.DateSubmitted.ToString("g"),
                OrganizationName = interactorSummary.OrganizationName,
                ProjectTitle = interactorSummary.ProjectTitle,
                ProposalId = interactorSummary.ProposalId,
                TargetAudience = interactorSummary.TargetAudience,
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
                CoordinatorFields = new CoordinatorFields {
                    CoordinatorNotes = result.Details.CoordinatorProperties.CoordinatorNotes,
                    InterviewOccured = result.Details.CoordinatorProperties.InterviewDate.HasValue,
                    Status = result.Details.CoordinatorProperties.Status,
                    InterviewDate = result.Details.CoordinatorProperties.InterviewDate,
                }
            };
        }
    }
}

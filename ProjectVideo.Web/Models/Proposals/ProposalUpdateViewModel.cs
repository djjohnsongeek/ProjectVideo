using ProjectVideo.Core.Interactors.Proposal;

namespace ProjectVideo.Web.Models.Proposals
{
	public class ProposalUpdateViewModel
	{
		ProposalStatus Status { get; set; }

		public string? CoordinatorNotes { get; set; }

		public bool InterviewOccured { get; set; }

		public DateTime InterviewDate { get; set; }
	}
}

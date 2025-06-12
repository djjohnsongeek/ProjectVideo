namespace ProjectVideo.Core.Interactors.DataObjects
{
	public class UpdateProposalInput
	{
		public int ProposalId { get; set; }
		public DateTime? InterviewDate { get; init; }
		public string? CoordinatorNotes { get; init; }
		public ProposalStatus Status { get; init; }

		public string? InterviewLink { get; init; }

	}
}

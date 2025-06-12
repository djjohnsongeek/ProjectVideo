namespace ProjectVideo.Core.Interactors.DataObjects
{
	public class ProposalListResult : InteractorResult
	{

		public List<ProposalSummary> Proposals = [];

		public class ProposalSummary
		{
			public int ProposalId { get; init; }
			public DateTime DateSubmitted { get; init; }
			public required string OrganizationName { get; init; }
			public required string ProjectTitle { get; init; }
			public required string TargetAudience { get; init; }
			public required ProposalStatus Status { get; init; }
			public DateTime? InfoMeetingDate { get; init; }
		}
	}
}

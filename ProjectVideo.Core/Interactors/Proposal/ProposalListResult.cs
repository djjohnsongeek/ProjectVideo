namespace ProjectVideo.Core.Interactors
{
	public class ProposalListResult : InteractorResult
	{

		public List<ProposalListItem> Proposals = [];

		public class ProposalListItem
		{
			public int ProposalId;
			public DateTime DateSubmitted;
			public required string OrganizationName;
			public required string ProjectTitle;
			public required string ContactName;
			public required string TargetAudience;
		}
	}
}

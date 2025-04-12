namespace ProjectVideo.Infrastructure.Data.Entities
{
	public class ProjectProposalLink
	{
		public int Id { get; set; }
		public int ProjectProposalId { get; set; }
		public required string Url { get; set; }

		// Navigation Props
		public ProjectProposal? Proposal { get; set; }
	}
}

namespace ProjectVideo.Infrastructure.Data.Entities
{
	public class ProposalLink
	{
		public int ProposalLinkId { get; set; }
		public int ProposalId { get; set; }
		public required string Url { get; set; }
		public required string Name { get; set; }

		// Navigation Props
		public Proposal? Proposal { get; set; }
	}
}

namespace ProjectVideo.Infrastructure.Data.Entities
{
	public class ProposalMember
	{
		public int ProposalMemberId { get; set; }
		public int ProposalId { get; set; }
		public required string Name { get; set; }
		public required string Role { get; set; }


		// Navigation Properties
		public Proposal? ProjectProposal { get; set; }
	}
}

namespace ProjectVideo.Infrastructure.Data.Entities
{
	public class ProjectProposalTeamMember
	{
		public int Id { get; set; }
		public int ProjectProposalId { get; set; }
		public required string Name { get; set; }
		public required string Role { get; set; }


		// Navigation Properties
		public ProjectProposal? ProjectProposal { get; set; }
	}
}

namespace ProjectVideo.Infrastructure.Data.Entities
{
	public class ProjectProposal
	{
		public int Id { get; set; }

		public required string ContactEmail { get; set; }
		public required string ContactName { get; set; }
		public required string OrganizationName {get; set;}
		public required string OrganizationHistory { get; set; }
		public bool StaffArePaid { get; set; }
		public required string ProjectTitle { get; set; }
		public required string TargetAudience { get; set; }
		public required string KeyObjectives { get; set; }
		public required string ProjectTimeFrameInterval { get; set; }
		public int ProjectTimeFrameTotal { get; set; }
		public required string Methods { get; set; }
		public required string PlannedVideos { get; set; }
		public required string CurrentEquipment { get; set; }
		public bool HasAudioSpace { get; set; }
		public string? AudioSpaceDescription { get; set; }
		public bool HasComputer { get; set; }
		public string? ComputerDescription { get; set; }
		public int EstimatedProjectCost { get; set; }

		// Navigation Props

		public List<ProjectProposalTeamMember> Members { get; set; } = [];
		public List<ProjectProposalLink> Links { get; set; } = [];

	}
}

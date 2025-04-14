namespace ProjectVideo.Web.Models.Proposals
{
	public class ProposalFormViewModel
	{
		public string? Email { get; set; }
		public string? ProjectManager { get; set; }
		public string? MainContact { get; set; }
		public string? OrganizationName { get; set; }
		public string? OrganizationHistory { get; set; }
		public bool StaffArePaid { get; set; }
		public string? ProjectTitle { get; set; }
		public string? TargetAudience { get; set; }
		public string? KeyObjectives { get; set; }
		public int ProjectTimeFrameNumber { get; set; }
		public string? ProjectTimeFrameInterval { get; set; }
		public string? MainMethods { get; set; }
		public string? PlannedVideos { get; set; }
		public List<ProposalTeamMember> TeamMembers { get; set; } = [];
		public string? CurrentEquipment { get; set; }
		public bool HasAudioSpace { get; set; }
		public string? AudioSpaceDescription { get; set; }
		// TODO: Audio Space image
		public bool HasComputer { get; set; }
		public string? ComputerDescription { get; set; }
		public int EstimatedProjectCost { get; set; }
		public List<ProposalLink> VideoLinks { get; set; } = [];
	}

	public class ProposalTeamMember
	{
		public string? Name { get; set; }
		public string? Role { get; set; }
	}

	public class ProposalLink
	{
		public string? Name { get; set; }
		public string? Url { get; set; }
	}
}

namespace ProjectVideo.Core.Interactors.DataObjects
{
	public class CreateProposalInput : InteractorResult
	{
		public List<ProposalLinkDetails> Links = [];
		public List<ProposalMemberDetails> Members = [];

		public required string ContactEmail;
		public required string ContactName;
		public required string ContactPhoneNumber;
		public required string OrganizationName;
		public required string ProjectTitle;
		public required string OrganizationHistory;
		public bool StaffArePaid;
		public required string TargetAudience;
		public required string KeyObjectives;
		public required string ProjectTimeFrameInterval;
		public int ProjectTimeFrameTotal;
		public required string Methods;
		public required string PlannedVideos;
		public required string CurrentEquipment;
		public bool HasAudioSpace;
		public string? AudioSpaceDescription;
		public bool HasComputer;
		public string? ComputerDescription;
		public int EstimatedProjectCost;
	}
}

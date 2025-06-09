namespace ProjectVideo.Core.Interactors.Proposal
{
    public class ProposalDetailsResult : InteractorResult
    {
        public required ProposalDetails Details;
    }

    public class ProposalDetails
    {
        public int ProposalId { get; init; }
        public DateTime DateSubmitted { get; init; }
        public required string ContactEmail { get; init; }
        public required string ContactPhoneNumber { get; init; }
        public required string ContactName { get; init; }
        public required string OrganizationName { get; init; }
        public required string OrganizationHistory { get; init; }
        public bool StaffArePaid { get; init; }
        public required string ProjectTitle { get; init; }
        public required string TargetAudience { get; init; }
        public required string KeyObjectives { get; init; }
        public required string ProjectTimeFrameInterval { get; init; }
        public int ProjectTimeFrameTotal { get; init; }
        public required string Methods { get; init; }
        public required string PlannedVideos { get; init; }
        public required string CurrentEquipment { get; init; }
        public bool HasAudioSpace { get; init; }
        public string? AudioSpaceDescription { get; init; }
        public bool HasComputer { get; init; }
        public string? ComputerDescription { get; init; }
        public int EstimatedProjectCost { get; init; }

        public required CoordinatorProperties CoordinatorProperties { get; init; }

        public List<ProposalLinkDetails> Links = [];
        public List<ProposalMemberDetails> Members = [];


        public static ProposalDetails Empty => new ProposalDetails
        {
            ContactEmail = string.Empty,
            ContactPhoneNumber = string.Empty,
            ContactName = string.Empty,
            OrganizationName = string.Empty,
            OrganizationHistory = string.Empty,
            ProjectTitle = string.Empty,
            TargetAudience = string.Empty,
            KeyObjectives = string.Empty,
            ProjectTimeFrameInterval = string.Empty,
            Methods = string.Empty,
            PlannedVideos = string.Empty,
            CurrentEquipment = string.Empty,
            CoordinatorProperties = new CoordinatorProperties()
        };
    }

    public class CoordinatorProperties
    {
		public string? CoordinatorNotes { get; init; }
		public DateTime? InterviewDate { get; init; }
		public ProposalStatus Status { get; init; }
	}
}

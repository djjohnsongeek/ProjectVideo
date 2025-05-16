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

        public List<VideoLink> Links = [];
        public List<ProposalMember> Members = [];

        public string? CoordinatorNotes { get; init; }
        public DateTime? InfoMeetingDate { get; init; }
        public bool IsApproved { get; init; }

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
        };
    }

    public class VideoLink
    {
        public required string Name { get; init; }
        public required string Url { get; init; }
    }

    public class ProposalMember
    {
        public required string Name { get; init; }
        public required string Role { get; init; }
    }
}

namespace ProjectVideo.Web.Models.Proposals
{
	public class ProposalsIndexViewModel
	{
        public List<ProposalSummary> Proposals { get; init;  } = [];

		public class ProposalSummary
        {
            public int ProposalId { get; init; }
            public required string Status { get; init; }
            public required string OrganizationName { get; set; }
            public required string SubmitDate { get; init; }
            public string? InterviewDate { get; init; }
            public required string ProjectTitle { get; set; }
            public required string TargetAudience { get; set; }
        }
	}
}

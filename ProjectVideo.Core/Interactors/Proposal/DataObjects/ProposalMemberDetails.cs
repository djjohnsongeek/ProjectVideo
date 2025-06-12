namespace ProjectVideo.Core.Interactors.DataObjects
{
	public class ProposalMemberDetails
	{
		public int ProposalMemberId { get; set; }
		public int ProposalId { get; set; }
		public required string Name { get; set; }
		public required string Role { get; set; }

		public static ProposalMemberDetails Empty => new ProposalMemberDetails
		{
			Name = string.Empty,
			Role = string.Empty,
		};
	}
}

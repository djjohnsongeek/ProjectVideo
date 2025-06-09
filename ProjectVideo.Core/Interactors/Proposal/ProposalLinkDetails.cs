namespace ProjectVideo.Core.Interactors.Proposal
{
	public class ProposalLinkDetails
	{
		public int ProposalLinkId { get; init; }
		public int ProposalId { get; init; }
		public required string Url { get; init; }
		public required string Name { get; init; }

		public static ProposalLinkDetails Empty => new ProposalLinkDetails {
			Name = string.Empty,
			Url = string.Empty
		};
	}
}

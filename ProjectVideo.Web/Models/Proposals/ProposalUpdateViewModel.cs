using ProjectVideo.Core.Interactors.Proposal;
using System.ComponentModel.DataAnnotations;

namespace ProjectVideo.Web.Models.Proposals
{
	public class ProposalUpdateViewModel
	{
		public int ProposalId { get; set; }

		public ProposalStatus Status { get; set; }

		[Display(Name = "Coordinator Notes")]
		public string? CoordinatorNotes { get; set; }

		[Display(Name = "Date Interview Occured")]

		[DataType(DataType.DateTime)]
		public DateTime? InterviewDate { get; set; }
	}
}

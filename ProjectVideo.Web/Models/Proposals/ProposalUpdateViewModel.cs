using ProjectVideo.Core.Interactors.DataObjects;
using System.ComponentModel.DataAnnotations;

namespace ProjectVideo.Web.Models.Proposals
{
	public class ProposalUpdateViewModel
	{
		public int ProposalId { get; set; }

		public ProposalStatus Status { get; set; }

		[Display(Name = "Coordinator Notes")]
		public string? CoordinatorNotes { get; set; }

		[Display(Name = "Interview Date")]
		[DataType(DataType.Date)]
		public DateTime? InterviewDate { get; set; }

		[Display(Name = "Interview Link")]
		public string? InterviewLink { get; set; }
	}
}

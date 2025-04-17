using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectVideo.Web.Models.Proposals
{
	public class ProposalFormViewModel
	{
		[Display(Name = "Email")]
		public string? Email { get; set; }

		[Display(Name = "Phone Number")]
		public string? PhoneNumber { get; set; }

		[Display(Name = "Main Contact")]
		public string? MainContact { get; set; }

		[Display(Name = "Organization Name")]
		public string? OrganizationName { get; set; }

		[Display(Name = "Organization History")]
		public string? OrganizationHistory { get; set; }

		[Display(Name = "Are Your Staff Paid?")]
		public bool StaffArePaid { get; set; }

		[Display(Name = "Project Title")]
		public string? ProjectTitle { get; set; }

		[DisplayName("Target Audience")]
		public string? TargetAudience { get; set; }

		[Display(Name = "Key Objectives")]
		public string? KeyObjectives { get; set; }

		public int ProjectTimeFrameNumber { get; set; }

		public string? ProjectTimeFrameInterval { get; set; }

		[Display(Name = "Main Methods")]
		public string? MainMethods { get; set; }

		[Display(Name = "Planned Videos")]
		public string? PlannedVideos { get; set; }

		public List<ProposalTeamMember> TeamMembers { get; set; } = [];

		[Display(Name = "Current Equipment")]
		public string? CurrentEquipment { get; set; }


		[Display(Name = "Do you have an audio space for recording?")]
		public bool HasAudioSpace { get; set; }


		[Display(Name = "Audio space Description")]
		public string? AudioSpaceDescription { get; set; }

		// TODO: Audio Space image

		[Display(Name = "Do you have a Computer?")]
		public bool HasComputer { get; set; }

		[Display(Name = "Computer Description")]
		public string? ComputerDescription { get; set; }

		[Display(Name = "Project Cost Estimate")]
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

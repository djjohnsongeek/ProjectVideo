
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace ProjectVideo.Web.Models.Proposals
{
	public class ProposalFormViewModel
	{
        // match required fields
        // https://docs.google.com/forms/d/e/1FAIpQLSc_AcUdBIYJDnDOA7TTDlw8oXuCb3D2CPwMxHq7__ZFVWXFtw/viewform

		[BindNever]
		public string LocalizationJson { get; set; } = "{}";

		// For Fields
		[Required]
		public string? ContactEmail { get; init; }

		[Required]
		public string? ContactPhoneNumber { get; init; }

		[Required]
		public string? ContactName { get; init; }

		[Required]
		public string? OrganizationName { get; init; }

		[Required]
		public string? OrganizationHistory { get; init; }

		[Required]
		public bool StaffArePaid { get; init; }

		[Required]
		public string? ProjectTitle { get; init; }

		[Required]
		public string? TargetAudience { get; init; }

		[Required]
		public string? KeyObjectives { get; init; }

		[Required]
		public int ProjectTimeFrameNumber { get; init; }

		[Required]
		public string? ProjectTimeFrameInterval { get; init; }

		[Required]
		public string? Methods { get; init; }

		[Required]
		public string? PlannedVideos { get; init; }

		public List<ProposalTeamMember> TeamMembers { get; init; } = [];

		[Required]
		public string? CurrentEquipment { get; init; }

		public bool HasAudioSpace { get; init; }

		public string? AudioSpaceDescription { get; init; }

		// TODO: Audio Space image

		public bool HasComputer { get; init; }

		public string? ComputerDescription { get; init; }

		[Required]
		public int EstimatedProjectCost { get; init; }

		public List<ProposalLink> VideoLinks { get; init; } = [];
	}

	public class ProposalTeamMember
	{
		public string? Name { get; set; }
		public string? Role { get; set; }
		public int EthnicTeamRoleOptionId { get; set; }
	}

	public class ProposalLink
	{
		public string? Name { get; set; }
		public string? Url { get; set; }
	}
}

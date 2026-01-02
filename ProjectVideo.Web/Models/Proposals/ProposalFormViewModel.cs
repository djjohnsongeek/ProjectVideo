using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectVideo.Core.Interactors.Proposal.DataObjects;
using System.ComponentModel.DataAnnotations;

namespace ProjectVideo.Web.Models.Proposals
{
	public class ProposalFormViewModel
	{
        // match required fields
        // https://docs.google.com/forms/d/e/1FAIpQLSc_AcUdBIYJDnDOA7TTDlw8oXuCb3D2CPwMxHq7__ZFVWXFtw/viewform

		// Data to render the form
		[BindNever]
		[ValidateNever]
		public ProposalFormLocalization? Localization { get; set; }

		[BindNever]
		public List<string> TeamMemberRoles { get; set; } = [];

		[BindNever]
		public List<SelectListItem> TimeFrameItems { get; set; } = [];

		[BindNever]
		public string LocalizationJson { get; set; } = "{}";

		// For Fields
		[Required]
		public string? Email { get; set; }

		[Required]
		public string? PhoneNumber { get; set; }

		[Required]
		public string? MainContact { get; set; }

		[Required]
		public string? OrganizationName { get; set; }

		[Required]
		public string? OrganizationHistory { get; set; }

		[Required]
		public bool StaffArePaid { get; set; }

		[Required]
		public string? ProjectTitle { get; set; }

		[Required]
		public string? TargetAudience { get; set; }

		[Required]
		public string? KeyObjectives { get; set; }

		[Required]
		public int ProjectTimeFrameNumber { get; set; }

		[Required]
		public string? ProjectTimeFrameInterval { get; set; }

		[Required]
		public string? MainMethods { get; set; }

		[Required]
		public string? PlannedVideos { get; set; }

		public List<ProposalTeamMember> TeamMembers { get; set; } = [];

		[Required]
		public string? CurrentEquipment { get; set; }

		public bool HasAudioSpace { get; set; }

		public string? AudioSpaceDescription { get; set; }

		// TODO: Audio Space image

		public bool HasComputer { get; set; }

		public string? ComputerDescription { get; set; }

		[Required]
		public int EstimatedProjectCost { get; set; }

		public List<ProposalLink> VideoLinks { get; set; } = [];
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


using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace ProjectVideo.Web.Models.Proposals
{
	public class ProposalFormViewModel
	{
		//  Attribute Validation localization:
		// https://learn.microsoft.com/en-us/aspnet/core/fundamentals/localization/make-content-localizable?view=aspnetcore-10.0#dataannotations-localization
		
		// match required fields
		// https://docs.google.com/forms/d/e/1FAIpQLSc_AcUdBIYJDnDOA7TTDlw8oXuCb3D2CPwMxHq7__ZFVWXFtw/viewform

		[BindNever]
		public string LocalizationJson { get; set; } = "{}";

		// For Fields
		[Required(ErrorMessage = "RequiredField")]
		public string? ContactEmail { get; init; }

		[Required(ErrorMessage = "RequiredField")]
		public string? ContactPhoneNumber { get; init; }

		[Required(ErrorMessage = "RequiredField")]
		public string? ContactName { get; init; }

		[Required(ErrorMessage = "RequiredField")]
		public string? OrganizationName { get; init; }

		[Required(ErrorMessage = "RequiredField")]
		public string? OrganizationHistory { get; init; }

		[Required(ErrorMessage = "RequiredField")]
		public bool StaffArePaid { get; init; }

		[Required(ErrorMessage = "RequiredField")]
		public string? ProjectTitle { get; init; }

		[Required(ErrorMessage = "RequiredField")]
		public string? TargetAudience { get; init; }

		[Required(ErrorMessage = "RequiredField")]
		public string? KeyObjectives { get; init; }

		[Required(ErrorMessage = "RequiredField")]
		public int ProjectTimeFrameNumber { get; init; }

		[Required(ErrorMessage = "RequiredField")]
		public string? ProjectTimeFrameInterval { get; init; }

		[Required(ErrorMessage = "RequiredField")]
		public string? Methods { get; init; }

		[Required(ErrorMessage = "RequiredField")]
		public string? PlannedVideos { get; init; }

		public List<ProposalTeamMember> TeamMembers { get; init; } = [];

		[Required(ErrorMessage = "RequiredField")]
		public string? CurrentEquipment { get; init; }

		public bool HasAudioSpace { get; init; }

		public string? AudioSpaceDescription { get; init; }

		// TODO: Audio Space image

		public bool HasComputer { get; init; }

		public string? ComputerDescription { get; init; }

		[Required(ErrorMessage = "RequiredField")]
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

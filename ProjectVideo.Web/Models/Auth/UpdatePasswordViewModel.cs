using System.ComponentModel.DataAnnotations;

namespace ProjectVideo.Web.Models.Auth
{
	public class UpdatePasswordViewModel
	{
		[Display(Name = "Current Password")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "Current password is required.")]
		public string? CurrentPassword { get; set; }

		[Display(Name = "New Password")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "New Passowrd is required.")]
		[Compare(nameof(ConfirmNewPassword), ErrorMessage = "The new password and confirmation password do not match.")]
		public string? NewPassword { get; set; }

		[Display(Name = "Confirm New Password")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "Confirmation password is required.")]
		[Compare(nameof(ConfirmNewPassword), ErrorMessage = "The new password and confirmation password do not match.")]
		public string? ConfirmNewPassword { get; set; }
	}
}

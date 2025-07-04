using System.ComponentModel.DataAnnotations;

namespace ProjectVideo.Web.Models.Auth
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage = "Username is required")]
		[StringLength(50, MinimumLength = 3)]
		public string Username { get; set; } = string.Empty;

		[Required(ErrorMessage = "Email address is required")]
		[EmailAddress(ErrorMessage = "Invalid email address")]
		[StringLength(100)]
		public string Email { get; set; } = string.Empty;

		[Required(ErrorMessage = "Password is required")]
		[StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long")]
		[DataType(DataType.Password)]
		public string Password { get; set; } = string.Empty;

		[Required(ErrorMessage = "Confirm password is required")]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match")]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; } = string.Empty;

		[Required(ErrorMessage = "First name is required")]
		[StringLength(50)]
		public string FirstName { get; set; } = string.Empty;

		[Required(ErrorMessage = "Last name is required")]
		[StringLength(50)]
		public string LastName { get; set; } = string.Empty;
	}
}

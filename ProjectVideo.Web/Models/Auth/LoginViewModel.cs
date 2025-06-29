using Microsoft.AspNetCore.Cors;
using System.ComponentModel.DataAnnotations;

namespace ProjectVideo.Web.Models.Auth
{
	public class LoginViewModel
	{
		[Display(Name = "Username")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "Username is required.")]
		public required string UserName { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "Password is required.")]
		public required string Password { get; set; }

		public static LoginViewModel Empty => new LoginViewModel { Password = string.Empty, UserName = string.Empty };
	}
}

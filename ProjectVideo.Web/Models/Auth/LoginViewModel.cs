using Microsoft.AspNetCore.Cors;
using System.ComponentModel.DataAnnotations;

namespace ProjectVideo.Web.Models.Auth
{
	public class LoginViewModel
	{
		[Display(Name = "Username")]
		public required string UserName { get; set; }
		public required string Password { get; set; }

		public static LoginViewModel Empty => new LoginViewModel { Password = string.Empty, UserName = string.Empty };
	}
}

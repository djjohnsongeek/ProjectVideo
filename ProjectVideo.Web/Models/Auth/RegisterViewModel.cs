﻿using System.ComponentModel.DataAnnotations;

namespace ProjectVideo.Web.Models.Auth
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage = "First name is required")]
		[StringLength(50)]
		public string FirstName { get; set; } = string.Empty;

		[Required(ErrorMessage = "Last name is required")]
		[StringLength(50)]
		public string LastName { get; set; } = string.Empty;

		[Required(ErrorMessage = "Email address is required")]
		[EmailAddress(ErrorMessage = "Invalid email address")]
		[StringLength(100)]
		public string Email { get; set; } = string.Empty;
	}
}

using Microsoft.AspNetCore.Mvc;
using ProjectVideo.Web.Models.Auth;

namespace ProjectVideo.Web.Controllers
{
	public class AuthController : BaseController
	{
		public AuthController(ILogger<AuthController> logger) : base(logger) { }

		[HttpGet]
		public IActionResult Login()
		{
			return View(LoginViewModel.Empty);
		}

		[HttpPost]
		public IActionResult Login(LoginViewModel loginModel)
		{
			// https://learn.microsoft.com/en-us/aspnet/core/security/authentication/cookie?view=aspnetcore-9.0
			return View(loginModel);
		}
	}
}
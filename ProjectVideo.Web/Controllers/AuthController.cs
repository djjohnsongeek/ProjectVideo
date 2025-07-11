﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectVideo.Core.Interactors;
using ProjectVideo.Core.Interactors.DataObjects;
using ProjectVideo.Infrastructure.Auth;
using ProjectVideo.Web.Models;
using ProjectVideo.Web.Models.Auth;
using System.Security.Claims;

namespace ProjectVideo.Web.Controllers;

public class AuthController : BaseController
{
	private IAuthFetchInteractor _authInteractor;

	public AuthController(ILogger<AuthController> logger, IAuthFetchInteractor _authInteractor) : base(logger)
	{
		this._authInteractor = _authInteractor;
	}

	[HttpGet]
	public IActionResult Login()
	{
		return View(LoginViewModel.Empty);
	}

	[HttpGet]
	public IActionResult Logout()
	{
		HttpContext.SignOutAsync();
		AddServerMessage("Logged out", ServerMessageType.Success);
		return RedirectToAction("Index", "Home");
	}

	[HttpGet]
	[Authorize(Policy = AppPolicies.AdminRequired)]
	public IActionResult Register()
	{
		return View(new RegisterViewModel());
	}

	[HttpGet]
	[Authorize(Policy = AppPolicies.UserRequired)]
	public IActionResult UpdatePassword()
	{
		return View(new UpdatePasswordViewModel());
	}

	[HttpPost]
	[Authorize(Policy = AppPolicies.AdminRequired)]
	public IActionResult Register(RegisterViewModel registerModel)
	{
		AddServerMessage("User Registered Successfully. An invitation email has been sent.", ServerMessageType.Success);;
		return RedirectToAction("Index", "Home");
	}

	[HttpPost]
	public async Task<IActionResult> Login(LoginViewModel loginModel)
	{
		// https://learn.microsoft.com/en-us/aspnet/core/security/authentication/cookie?view=aspnetcore-9.0
		if (ModelState.IsValid)
		{
			var input = new AuthenticateUserInput
			{
				UserName = loginModel.UserName,
				Password = loginModel.Password
			};

			AuthenticateUserResult result = await _authInteractor.AuthenticateUser(input);
			AddInteractorErrors(result);
			if (result.IsAuthenticated && !result.HasErrors)
			{
				// Build Claims
				List<Claim> claims = [];
				claims.Add(new Claim(ClaimTypes.Name, result.UserDetails.Username));
				foreach (string roleName in result.UserDetails.RoleNames)
				{
					claims.Add(new Claim(ClaimTypes.Role, roleName));
				}

				// Build Principal
				ClaimsIdentity claimsIdentity = new ClaimsIdentity(
					claims,
					CookieAuthenticationDefaults.AuthenticationScheme
				);
				ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);

				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

				AddServerMessage("Logged in", ServerMessageType.Success);
				return RedirectToAction("Index", "Home");
			}
		}

		AddServerMessage("Invalid Login", ServerMessageType.Error);

		return View(loginModel);
	}
}
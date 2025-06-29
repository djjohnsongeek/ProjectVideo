using Microsoft.AspNetCore.Mvc;
using ProjectVideo.Core.Interactors;

namespace ProjectVideo.Web.Controllers
{
	public class BaseController : Controller
	{
		private readonly ILogger<BaseController> _logger;

		public BaseController(ILogger<BaseController> logger)
		{
			_logger = logger;
		}

		public void AddInteractorErrors(InteractorResult result)
		{
			foreach (var interactorError in result.Errors)
			{
				ModelState.AddModelError(string.Empty, interactorError.Message);
			}
		}
	}
}
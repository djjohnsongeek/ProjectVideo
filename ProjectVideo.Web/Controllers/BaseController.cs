using Microsoft.AspNetCore.Mvc;

namespace ProjectVideo.Web.Controllers
{
	public class BaseController : Controller
	{
		private readonly ILogger<BaseController> _logger;

		public BaseController(ILogger<BaseController> logger)
		{
			_logger = logger;
		}
	}
}
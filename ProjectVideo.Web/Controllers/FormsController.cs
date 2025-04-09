using Microsoft.AspNetCore.Mvc;
using ProjectVideo.Web.Models.Forms;

namespace ProjectVideo.Web.Controllers
{
	public class FormsController : BaseController
	{
		public FormsController(ILogger<BaseController> logger) : base(logger) { }

		[HttpGet]
		public IActionResult ProjectProposal()
		{
			return View(new ProjectProposalViewModel());
		}

		[HttpPost]
		public IActionResult ProjectProposal(ProjectProposalViewModel model)
		{
			string? title = model.ProjectTitle;
			return View(model);
		}
	}
}

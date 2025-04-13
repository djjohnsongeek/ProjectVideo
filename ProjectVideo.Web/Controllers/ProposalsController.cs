using Microsoft.AspNetCore.Mvc;
using ProjectVideo.Core.Interactors.Proposal;

namespace ProjectVideo.Web.Controllers
{
	public class ProposalsController : BaseController
	{
		private readonly IProposalsFetchInteractor _fetchInteractor;
		public ProposalsController(
			ILogger<ProposalsController> logger,
			IProposalsFetchInteractor fetchInteractor) : base(logger)
		{
			_fetchInteractor = fetchInteractor;
		}

		public IActionResult Index()
		{
			_fetchInteractor.GetProposals();
			return View();
		}
	}
}

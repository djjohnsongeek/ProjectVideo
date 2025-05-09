using Microsoft.AspNetCore.Mvc;
using ProjectVideo.Core.Interactors;
using ProjectVideo.Core.Interactors.Proposal;
using ProjectVideo.Web.Models.Proposals;

namespace ProjectVideo.Web.Controllers
{
	public class ProposalsController : BaseController
	{
		private readonly IProposalFetchInteractor _fetchInteractor;
		private readonly IProposalUpdateInteractor _updateInteractor;

		public ProposalsController(
			ILogger<ProposalsController> logger,
			IProposalFetchInteractor fetchInteractor,
			IProposalUpdateInteractor updateInteractor) : base(logger)
		{
			_fetchInteractor = fetchInteractor;
			_updateInteractor = updateInteractor;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			ProposalListResult result = await _fetchInteractor.GetProposals();
			ProposalsIndexViewModel viewModel = new ProposalPresenter().BuildViewModel(result);
			return View(viewModel);
		}

		[HttpGet]
		public IActionResult Form()
		{
			return View(new ProposalFormViewModel());
		}

		[HttpPost]
		public async Task<IActionResult> Form(ProposalFormViewModel model)
		{
			if (ModelState.IsValid)
			{
				CreateProposalInput inputData = BuildInput(model);
				var result = await _updateInteractor.CreateProposal(inputData);
				if (!result.HasErrors)
				{
					return View("Views/Forms/Submitted.cshtml");
				}
			}

			return View(model);
		}


		private CreateProposalInput BuildInput(ProposalFormViewModel model)
		{
			// TO
			var inputData = new CreateProposalInput
			{
				ContactEmail = model.Email!,
				ContactName = model.MainContact!,
				OrganizationName = model.OrganizationName!,
				ProjectTitle = model.ProjectTitle!,
				OrganizationHistory = model.OrganizationHistory!,
				StaffArePaid = model.StaffArePaid,
				TargetAudience = model.TargetAudience!,
				KeyObjectives = model.KeyObjectives!,
				ProjectTimeFrameTotal = model.ProjectTimeFrameNumber,
				ProjectTimeFrameInterval = model.ProjectTimeFrameInterval!,
				Methods = model.MainMethods!,
				PlannedVideos = model.PlannedVideos!,
				CurrentEquipment = model.CurrentEquipment!,
				HasAudioSpace = model.HasAudioSpace,
				AudioSpaceDescription = model.AudioSpaceDescription,
				HasComputer = model.HasComputer,
				ComputerDescription = model.ComputerDescription,
				EstimatedProjectCost = model.EstimatedProjectCost,

				Links = model.VideoLinks.Select(vl => new ProposalLinkItem
				{
					Name = vl.Name,
					Url = vl.Url
				}).ToList(),

				Members = model.TeamMembers.Select(tm => new ProposalMemberItem
				{
					Name = tm.Name,
					Role = tm.Role,
				}).ToList()
			};

			return inputData;
		}
	}
}

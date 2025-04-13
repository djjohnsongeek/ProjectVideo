using Microsoft.AspNetCore.Mvc;
using ProjectVideo.Core.Interactors.Proposal;
using ProjectVideo.Web.Models.Forms;

namespace ProjectVideo.Web.Controllers
{
	public class FormsController : BaseController
	{
		private IProposalUpdateInteractor _updateInteractor;

		public FormsController(
			ILogger<BaseController> logger,
			IProposalUpdateInteractor updateInteractor) : base(logger)
		{
			_updateInteractor = updateInteractor;
		}

		[HttpGet]
		public IActionResult ProjectProposal()
		{
			return View(new ProjectProposalViewModel());
		}

		[HttpPost]
		public async Task<IActionResult> ProjectProposal(ProjectProposalViewModel model)
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

		private CreateProposalInput BuildInput(ProjectProposalViewModel model)
		{
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

				// Todo add memeners and links
				Links = [],
				Members = [],
			};

			return inputData;
		}
	}
}

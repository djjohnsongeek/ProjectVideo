using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using ProjectVideo.Core;
using ProjectVideo.Core.Interactors;
using ProjectVideo.Core.Interactors.DataObjects;
using ProjectVideo.Web.Models;
using ProjectVideo.Web.Models.Proposals;

namespace ProjectVideo.Web.Controllers
{
	public class ProposalsController : BaseController
	{
		private readonly IProposalFetchInteractor _fetchInteractor;
		private readonly IProposalUpdateInteractor _updateInteractor;
		private readonly IStringLocalizer<ProposalsController> _localizer;

		public ProposalsController(
			ILogger<ProposalsController> logger,
			IProposalFetchInteractor fetchInteractor,
			IProposalUpdateInteractor updateInteractor,
			IStringLocalizer<ProposalsController> localizer) : base(logger)
		{
			_fetchInteractor = fetchInteractor;
			_updateInteractor = updateInteractor;
			_localizer = localizer;
		}

		[Authorize]
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			ProposalListResult result = await _fetchInteractor.GetProposals();
			AddInteractorErrors(result);
			ProposalsIndexViewModel viewModel = new ProposalPresenter().BuildViewModel(result);
			return View(viewModel);
		}

		[HttpGet]
		public IActionResult Form()
		{
			//ProposalFormResult result = await _fetchInteractor.GetFormRequirements(AppLanguage.English);
			//AddInteractorErrors(result);
			ProposalFormViewModel viewModel = new ProposalPresenter().BuildViewModel(_localizer);
			return View(viewModel);
		}

		[Authorize]
		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			ProposalDetailsResult result = await _fetchInteractor.GetProposalDetails(id);
			AddInteractorErrors(result);
			ProposalDetailsViewModel viewModel = new ProposalPresenter().BuildViewModel(result);
			return View(viewModel);
		}

		[HttpPost]
		public async Task<IActionResult> Form(ProposalFormViewModel model)
		{
			if (ModelState.IsValid)
			{
				CreateProposalInput inputData = BuildInput(model);
				var result = await _updateInteractor.CreateProposal(inputData);
				AddInteractorErrors(result);
				if (!result.HasErrors)
				{
					return View("Views/Forms/Submitted.cshtml");
				}
			}

			new ProposalPresenter().AddLocalization(model, _localizer);
            return View(model);
		}

		[Authorize]
		[HttpPost]
		public async Task<IActionResult> Details(ProposalUpdateViewModel updateModel)
		{
			UpdateProposalInput inputData = BuildInput(updateModel);
			var result = await _updateInteractor.UpdateProposal(inputData);
			AddInteractorErrors(result);
			if (!result.HasErrors)
			{
				AddServerMessage("Proposal Details updated succesfully!", ServerMessageType.Success);
			}
			return RedirectToAction("Details", new { id = updateModel.ProposalId });
		}

		
		private CreateProposalInput BuildInput(ProposalFormViewModel model)
		{
			// TODO validate?
			var inputData = new CreateProposalInput
			{
				ContactEmail = model.ContactEmail!,
				ContactPhoneNumber = model.ContactPhoneNumber!,
				ContactName = model.ContactName!,
				OrganizationName = model.OrganizationName!,
				ProjectTitle = model.ProjectTitle!,
				OrganizationHistory = model.OrganizationHistory!,
				StaffArePaid = model.StaffArePaid,
				TargetAudience = model.TargetAudience!,
				KeyObjectives = model.KeyObjectives!,
				ProjectTimeFrameNumber = model.ProjectTimeFrameNumber,
				ProjectTimeFrameInterval = model.ProjectTimeFrameInterval!,
				Methods = model.Methods!,
				PlannedVideos = model.PlannedVideos!,
				CurrentEquipment = model.CurrentEquipment!,
				HasAudioSpace = model.HasAudioSpace,
				AudioSpaceDescription = model.AudioSpaceDescription,
				HasComputer = model.HasComputer,
				ComputerDescription = model.ComputerDescription,
				EstimatedProjectCost = model.EstimatedProjectCost,

				Links = model.VideoLinks
					.Where(x => !string.IsNullOrWhiteSpace(x.Name))
					.Where(x => !string.IsNullOrWhiteSpace(x.Url))
					.Select(vl => new ProposalLinkDetails
				{
					Name = vl.Name!,
					Url = vl.Url!
				}).ToList(),

				Members = model.TeamMembers
					.Where(x => !string.IsNullOrWhiteSpace(x.Name))
					.Where(x => !string.IsNullOrWhiteSpace(x.Role))
					.Select(tm => new ProposalMemberDetails
				{
					Name = tm.Name!,
					Role = tm.Role!,
				}).ToList()
			};

			return inputData;
		}

		private UpdateProposalInput BuildInput(ProposalUpdateViewModel model)
		{
			var inputData = new UpdateProposalInput
			{
				InterviewDate = model.InterviewDate,
				CoordinatorNotes = model.CoordinatorNotes,
				Status = model.Status,
				ProposalId = model.ProposalId,
				InterviewLink = model.InterviewLink
			};

			return inputData;
		}
	}
}

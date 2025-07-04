using Microsoft.AspNetCore.Mvc;
using ProjectVideo.Core.Interactors;
using ProjectVideo.Web.Models;
using System.Text.Json;

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

		public void AddServerMessage(string message, ServerMessageType type)
		{
			ServerMessage newMessage = new ServerMessage { Text = message, Type = type };
			List<ServerMessage> messages = [];

			if (TempData["ServerMessages"] is string serializedServerMessages)
			{
				messages = JsonSerializer.Deserialize<List<ServerMessage>>(serializedServerMessages) ?? [];
				messages.Add(newMessage);
			}
			else
			{
				messages.Add(newMessage);
			}

			TempData["ServerMessages"] = JsonSerializer.Serialize(messages);
		}
	}
}
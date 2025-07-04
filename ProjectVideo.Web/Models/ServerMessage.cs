namespace ProjectVideo.Web.Models
{
	public class ServerMessage
	{
		public required string Text { get; set; }
		public required ServerMessageType Type { get; set; }

		public string GetIconClassName()
		{
			return Type switch
			{
				ServerMessageType.Success => "fa-check-circle",
				ServerMessageType.Error => "fa-exclamation-triangle",
				ServerMessageType.Warning => "fa-exclamation-circle",
				ServerMessageType.Info => "fa-info-circle",
				_ => throw new ArgumentOutOfRangeException(nameof(Type), Type, null)
			};
		}

		public string GetAlertClassName()
		{
			return Type switch
			{
				ServerMessageType.Success => "alert-success",
				ServerMessageType.Error => "alert-danger",
				ServerMessageType.Warning => "alert-warning",
				ServerMessageType.Info => "alert-info",
				_ => throw new ArgumentOutOfRangeException(nameof(Type), Type, null)
			};
		}
	}

	public enum ServerMessageType
	{
		Success,
		Error,
		Warning,
		Info
	}
}

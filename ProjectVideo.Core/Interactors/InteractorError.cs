namespace ProjectVideo.Core.Interactors
{
	public class InteractorError
	{
		public string Message { get; private set; }
		public string? PropertyName { get; private set; } = null;

		public InteractorError(string message, string? propertyName = null)		{
			Message = message;
			PropertyName = propertyName;
		}
	}
}

namespace ProjectVideo.Core.Interactors
{
	public class InteractorError
	{
		public string Message { get; private set; }

		public InteractorError(string message)		{
			Message = message;
		}

	}
}

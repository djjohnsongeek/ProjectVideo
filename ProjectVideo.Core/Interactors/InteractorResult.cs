namespace ProjectVideo.Core.Interactors
{
	public class InteractorResult
	{
		public List<InteractorError> Errors { get; set; } = [];

		public bool HasErrors => Errors.Count > 0;

		public bool IsAuthenticated { get; private set; }

		public void AddError(string errorMessage)
		{
			Errors.Add(new InteractorError(errorMessage));
		}

		public void AddAuthError(string errorMessage)
		{
			SetAuthenticated(false);
			AddError(errorMessage);
		}

		public void SetAuthenticated(bool value)
		{
			IsAuthenticated = value;
		}

	}
}

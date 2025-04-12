namespace ProjectVideo.Core.Interactors
{
	public class InteractorResult
	{
		public List<InteractorError> Errors { get; set; } = [];

		public bool HasErrors => Errors.Count > 0;


		public void AddError(string errorMessage)
		{
			Errors.Add(new InteractorError(errorMessage));
		}

	}
}

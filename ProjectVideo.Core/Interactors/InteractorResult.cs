namespace ProjectVideo.Core.Interactors
{
	public class InteractorResult
	{
		public List<InteractorError> Errors { get; set; } = [];

		public bool Success => Errors.Count == 0;

	}
}

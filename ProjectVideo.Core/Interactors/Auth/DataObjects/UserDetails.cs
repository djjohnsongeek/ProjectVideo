namespace ProjectVideo.Core.Interactors.DataObjects;

public class UserDetails
{
	public required string Username { get; init; }

	public List<string> RoleNames { get; init; } = [];

	public static UserDetails Empty => new UserDetails
	{
		Username = string.Empty,
		RoleNames = []
	};
}

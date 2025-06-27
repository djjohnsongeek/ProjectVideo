namespace ProjectVideo.Infrastructure.Data.Entities
{
	public class Role
	{
		public int RoleId { get; set; }
		public required string Name { get; set; }
		public string? Description { get; set; }

		public List<User> Users { get; } = [];
    }
}

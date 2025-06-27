namespace ProjectVideo.Infrastructure.Data.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string UserName { get; set; }
        public required string HashedPassword { get; set; }
        public required string Email { get; set; }

        public List<Role> Roles { get; } = [];
    }
}

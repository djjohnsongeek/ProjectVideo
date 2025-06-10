namespace ProjectVideo.Infrastructure.Data.Entities
{
    public class UserRole
    {
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public required User User { get; set; }
        public required Role Role { get; set; }
    }
}

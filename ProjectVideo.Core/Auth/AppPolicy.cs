namespace ProjectVideo.Infrastructure.Auth
{
    public static class AppPolicies
    {
        public const string CoordinatorRequired = "CoordinatorRequired";
        public const string AdminRequired = "AdminRequired";
        public const string StaffRequired = "StaffRequired";
        public const string UserRequired = "UserRequired";
    }
}

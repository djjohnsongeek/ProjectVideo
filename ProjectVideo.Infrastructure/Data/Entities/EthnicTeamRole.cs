namespace ProjectVideo.Infrastructure.Data.Entities
{
    public class EthnicTeamRole
    {
        public int EthnicTeamRoleId { get; set; }

        public int LocalizationId { get; set; }

        public required Localization Localization { get; set; }
    }
}
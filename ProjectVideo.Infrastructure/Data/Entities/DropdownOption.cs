namespace ProjectVideo.Infrastructure.Data.Entities
{
    public class DropdownOption
    {
        public int DropdownOptionId { get; set; }

        public int LocalizationId { get; set; }

        public DropdownId DropdownId { get; set; }

		public required Localization Localization { get; set; }
    }
}
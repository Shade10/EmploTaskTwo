namespace EmploTaskTwo.Core.Constants
{
    public static class ApplicationConstants
    {
        public const double HoursPerWorkDay = 8.0;
        public const int MinYear = 1;

        public static readonly string ErrorEmptyTeamName = "Team name cannot be empty.";
        public static readonly string ErrorInvalidYear = $"Year must be greater than or equal to {MinYear}.";
    }
}

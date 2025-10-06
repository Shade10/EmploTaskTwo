namespace EmploTaskTwo.Core.Constants
{
    public static class ApplicationConstants
    {
        public const double HoursPerWorkDay = 8.0;
        public const int MinYear = 1;
        public const int MinFreeVacationDays = 1;

        public static readonly string ErrorEmptyTeamName = "Team name cannot be empty.";
        public static readonly string ErrorInvalidYear = $"Year must be greater than or equal to {MinYear}.";
        public static readonly string ErrorNullEmployee = "Employee cannot be null.";
        public static readonly string ErrorNullVacations = "Vacations list cannot be null.";
        public static readonly string ErrorNullVacationPackage = "Vacation package cannot be null.";

    }
}

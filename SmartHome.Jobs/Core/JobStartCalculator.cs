namespace SmartHome.Jobs.Core
{
    public static class JobStartCalculator
    {
        public static TimeSpan GetNextTimeSpan(DateTime fromDate, int dayHours, int dayMinute)
        {
            var days = 0;
            var executionDate = new DateTime(fromDate.Year, fromDate.Month, fromDate.Day, dayHours, dayMinute, 0);

            if (fromDate > executionDate)
            {
                days++;
            }

            var nextExecutionTime = new DateTime(fromDate.Date.AddDays(days).Year,
                fromDate.AddDays(days).Month,
                fromDate.AddDays(days).Day, dayHours, dayMinute, 0);

            return nextExecutionTime - fromDate;
        }

        public static bool IsDateTimeInRange(int activeFromHour, int activeFromMinute, int activeThruHour, int activeThruMinute)
        {
            var actualDateTime = DateTime.Now;
            var activeFromDate = new DateTime(actualDateTime.Year, actualDateTime.Month, actualDateTime.Day, activeFromHour, activeFromMinute, 0);
            var activeThruDate = new DateTime(actualDateTime.Year, actualDateTime.Month, actualDateTime.Day, activeThruHour, activeThruMinute, 0);

            return actualDateTime >= activeFromDate && actualDateTime <= activeThruDate;
        }
    }
}

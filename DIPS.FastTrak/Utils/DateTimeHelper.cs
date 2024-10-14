namespace DIPS.FastTrak.Utils
{
    public static class DateTimeHelper
    {
        public static string ToFriendlyString(this DateTime value)
        {
            var daysSince = (DateTime.Today - value).TotalDays;
            switch (daysSince)
            {
                case 0: return "I dag";
                case 1: return "I går";
                default: return $"{daysSince} dager siden";
            }
        }
    }
}

using System;

namespace Sacristan.Utils
{
    public static class DateUtils
    {
        public static long GetCurrentUnixTime()
        {
            return GetUnixTime(DateTime.Now);
        }

        public static long GetCurrentUTCUnixTime()
        {
            return GetUnixTime(DateTime.UtcNow);
        }

        public static long GetUnixTime(DateTime dateTime)
        {
            DateTime epoch = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
            return (long) (dateTime - epoch).TotalSeconds;
        }
    }
}
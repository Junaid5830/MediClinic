using System;
using System.Collections.Generic;
using System.Text;

namespace MedliClinic.Utilities.Utility
{
    public static class DateFormattor
    {
        public static TimeSpan LocalTimeToUTCTime(TimeSpan localTime)
        {
            var dt = new DateTime(localTime.Ticks);
            var utc = dt.ToUniversalTime();
            return new TimeSpan(utc.Ticks);
        }
    }
}

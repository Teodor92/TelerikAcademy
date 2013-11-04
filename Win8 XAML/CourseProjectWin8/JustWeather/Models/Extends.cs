using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustWeather.Models
{
    public static class Extends
    {
        private static readonly DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime ToDateTime(this long input)
        {
            return unixEpoch.AddSeconds(input);
        }

        public static string ToUTCString(this DateTime input)
        {
            var milliseconds = input
                .ToUniversalTime()
                .Subtract(unixEpoch)
                .TotalSeconds;

            return Convert.ToInt64(milliseconds).ToString();
        }
    }
}

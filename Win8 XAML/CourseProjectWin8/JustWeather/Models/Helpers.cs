using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustWeather.Models
{
    public class Helpers
    {
        public static string FormatResponse(string _input)
        {
            _input = _input.Replace("isd-stations", "isd_stations");
            _input = _input.Replace("lamp-stations", "lamp_stations");
            _input = _input.Replace("metar-stations", "metar_stations");
            _input = _input.Replace("darksky-stations", "darksky_stations");
            return _input;
        }

        public static string FormatExcludeString(Exclude[] input)
        {
            return string.Join(",", input.Select(i => Enum.GetName(typeof(Exclude), i)));
        }

        public static string FormatExtendString(Extend[] input)
        {
            return string.Join(",", input.Select(i => Enum.GetName(typeof(Extend), i)));
        }
    }
}
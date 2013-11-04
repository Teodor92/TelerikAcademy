using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustWeather.Models
{

    public enum Unit
    {
        Us,
        Si,
        Ca,
        Uk,
        Auto
    }

    public enum Exclude
    {
        Currently,
        Minutely,
        Hourly,
        Daily,
        Alerts,
        Flags
    }

    public enum Extend
    {
        Hourly
    }
}

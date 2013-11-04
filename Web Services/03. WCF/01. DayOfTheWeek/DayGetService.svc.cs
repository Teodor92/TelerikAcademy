using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace _01.DayOfTheWeek
{
    public class DayGetService : IServiceDayGetter
    {
        public DayOfWeek GetDay(DateTime day)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("bg-BG");
            return day.DayOfWeek;
        }
    }
}

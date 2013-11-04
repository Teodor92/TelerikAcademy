using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace _01.DayOfTheWeek
{
    [ServiceContract]
    public interface IServiceDayGetter
    {
        [OperationContract]
        DayOfWeek GetDay(DateTime day);
    }
}

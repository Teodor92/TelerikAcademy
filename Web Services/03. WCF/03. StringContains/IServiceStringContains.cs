using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _03.StringContains
{
    [ServiceContract]
    public interface IServiceStringContains
    {
        [OperationContract]
        int ContainsString(string valueString, string searchString);
    }
}

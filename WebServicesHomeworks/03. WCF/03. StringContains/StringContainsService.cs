using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.StringContains
{
    public class StringContainsService : IServiceStringContains
    {
        public int ContainsString(string valueString, string searchString)
        {
            MatchCollection matches = Regex.Matches(valueString, searchString, RegexOptions.IgnoreCase);

            return matches.Count;
        }
    }
}

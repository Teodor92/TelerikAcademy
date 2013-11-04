using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class ShouldNotContainBugWordAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string valueAsString = value as string;
            if (valueAsString == null)
            {
                return false;
            }

            if (valueAsString.Contains("Bug"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

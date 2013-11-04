using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JusTeeth.App.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DateTimeRangeAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }
            DateTime pickedDate = (DateTime)value;
            DateTime now = DateTime.Now;
            DateTime maxDate = now.AddDays(3);
            bool result = pickedDate > now && pickedDate <= maxDate;
            return result;
        }
    }
}
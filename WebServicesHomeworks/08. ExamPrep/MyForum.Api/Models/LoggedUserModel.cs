using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyForum.Api.Models
{
    public class LoggedUserModel
    {
        public string Nickname { get; set; }

        public string SessionKey { get; set; }
    }
}

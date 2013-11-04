using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JusTeeth.App.Areas.Administration.ViewModels
{
    public class ApplicationUserViewModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string DisplayName { get; set; }

        public string Avatar { get; set; }

        public string FacebookProfile { get; set; }

        public bool IsAdmin { get; set; }
    }
}
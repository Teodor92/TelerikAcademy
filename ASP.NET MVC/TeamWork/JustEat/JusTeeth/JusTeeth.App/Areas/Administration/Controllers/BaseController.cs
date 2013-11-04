using JusTeeth.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JusTeeth.App.Areas.Administration.Controllers
{
    public class BaseController : Controller
    {
        protected IUnitOfWork Db;

        public BaseController()
        {
            this.Db = new UnitOfWorkData();
        }

        public BaseController(IUnitOfWork db)
        {
            this.Db = db;
        }
    }
}
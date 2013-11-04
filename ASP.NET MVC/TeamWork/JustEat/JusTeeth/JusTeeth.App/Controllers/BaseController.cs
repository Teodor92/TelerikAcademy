using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JusTeeth.Data;

namespace JusTeeth.App.Controllers
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
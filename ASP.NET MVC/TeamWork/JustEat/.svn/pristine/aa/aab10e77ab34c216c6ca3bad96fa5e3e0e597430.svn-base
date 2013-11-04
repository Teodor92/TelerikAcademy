using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JusTeeth.Data;
using Microsoft.AspNet.Identity;

namespace JusTeeth.App.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController() : base(new UnitOfWorkData())
        {
        }

        public ActionResult Index()
        {
            this.ViewBag.CurrentUser = this.Db.UsersRepository.GetUserByUserId(this.User.Identity.GetUserId());

            return View();
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}
using Exam.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exam.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            if (this.HttpContext.Cache["HomePageTickets"] == null)
            {
                var tickets =
                    this.Data.Tickets.All()
                    .OrderByDescending(x => x.Comments.Count())
                    .Select(t => new HomeTicketViewModel()
                    {
                        Id = t.Id,
                        Title = t.Title,
                        Author = t.Author.UserName,
                        CategoryName = t.Category.Name,
                        NumberOfComments = t.Comments.Count
                    })
                    .Take(6);

                this.HttpContext.Cache.Add("HomePageTickets", tickets.ToList(), null, DateTime.Now.AddHours(1), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Default, null);
            }

            return View(this.HttpContext.Cache["HomePageTickets"]);
        }
    }
}
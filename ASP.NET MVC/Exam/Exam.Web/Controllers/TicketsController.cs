using Exam.Models;
using Exam.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNet.Identity;

namespace Exam.Web.Controllers
{
    public class TicketsController : BaseController
    {
        //
        // GET: /Tickets/
        [HttpGet]
        public ActionResult Details(int id)
        {
            var ticket =
                this.Data.Tickets.All()
                .Where(x => x.Id == id)
                .Select(t => new DetailedTicketViewModel()
                {
                    Id = t.Id,
                    Author = t.Author.UserName,
                    Category = t.Category.Name,
                    Comments = t.Comments.Select(com => new CommentViewModel()
                    {
                        Author = com.PostedBy.UserName,
                        Content = com.Content
                    }),
                    Description = t.Description,
                    Priority = t.Priority,
                    ScreenshotUrl = t.ScreenUrl,
                    Title = t.Title
                })
                .FirstOrDefault();

            return View(ticket);
        }

        [Authorize]
        [HttpGet]
        public ActionResult AddTicket()
        {
            var ticketVM = new AddTicketViewModel();
            ticketVM.PriorityTypeDropdown = GetPriorityItems();
            ticketVM.CategoryDropdown = GetCategoriesItems();

            return View(ticketVM);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTicket(AddTicketViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = this.Data.AppUsers.All().FirstOrDefault(x => x.UserName == User.Identity.Name);
                user.Points++;

                var ticket = new Ticket()
                {
                    Author = user,
                    CategoryId = int.Parse(viewModel.CategoryId),
                    Description = viewModel.Description,
                    Priority = viewModel.Priority,
                    ScreenUrl = viewModel.ScreenUrl,
                    Title = viewModel.Title
                };

                this.Data.Tickets.Add(ticket);
                this.Data.SaveChanges();
                return RedirectToAction("List");
            }

            viewModel.PriorityTypeDropdown = GetPriorityItems();
            viewModel.CategoryDropdown = GetCategoriesItems();

            return View(viewModel);
        }

        [Authorize]
        public ActionResult List()
        {
            return View();
        }

        public JsonResult GetTickets([DataSourceRequest] DataSourceRequest request)
        {
            var tickets = this.Data.Tickets.All().ToList().Select(x => new ListTicketViewModel() 
            { 
                Id = x.Id,
                Author = x.Author.UserName,
                Category = x.Category.Name,
                Priority = x.Priority.ToString(),
                Title = x.Title
            });


            return Json(tickets.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCategoryData([DataSourceRequest] DataSourceRequest request)
        {
            var result = this.Data.Categories
                .All()
                .Select(x => new
                {
                    CategoryName = x.Name
                });

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult PostComment(CommentViewModel commentModel)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();
                var username = this.User.Identity.GetUserName();

                this.Data.Commetns.Add(new Comment()
                {
                    PostedById = userId,
                    Content = commentModel.Content,
                    TicketId = commentModel.TicketId,
                });

                this.Data.SaveChanges();

                var viewModel = new CommentViewModel { Author = username, Content = commentModel.Content };
                return PartialView("_CommentPartial", viewModel);
            }

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, ModelState.Values.First().ToString());
        }

        [Authorize]
        public ActionResult Filter(FilterViewModel model)
        {
            var categoris =
                this.Data.Tickets.All().ToList()
                .Select(x => new ListTicketViewModel()
                {
                    Title = x.Title,
                    Author = x.Author.UserName,
                    Category = x.Category.Name,
                    Priority = x.Priority.ToString()
                });

            if (model.CategoryFilter != "All")
            {
                var filteredCategories = categoris.Where(x => x.Category == model.CategoryFilter);
                return View(filteredCategories);
            }
            else
            {
                return View(categoris);
            }

        }

        private List<SelectListItem> GetCategoriesItems()
        {
            var categories = this.Data.Categories.All();
            List<SelectListItem> placesList = new List<SelectListItem>();
            foreach (var item in categories)
            {
                placesList.Add(new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }

            return placesList;
        }

        private List<SelectListItem> GetPriorityItems()
        {
            string[] rawTypes = Enum.GetNames(typeof(PriorityType));
            List<SelectListItem> priorityList = new List<SelectListItem>();
            for (int i = 0; i < rawTypes.Length; i++)
            {
                priorityList.Add(new SelectListItem()
                {
                    Text = rawTypes[i],
                    Value = (i + 1).ToString()
                });
            }

            return priorityList;
        }
    }
}
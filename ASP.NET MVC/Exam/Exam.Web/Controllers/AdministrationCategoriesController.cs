using Exam.Models;
using Exam.Web.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exam.Web.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdministrationCategoriesController : BaseController
    {
        //
        // GET: /AdministrationCategories/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ReadCategories([DataSourceRequest] DataSourceRequest request)
        {
            var result = this.Data.Categories.All()
                .Select(x => new CategoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                });

            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {

                Category newCategory = new Category()
                {
                    Name = category.Name
                };

                this.Data.Categories.Add(newCategory);
                this.Data.SaveChanges();
                //category.Id = newCategory.Id;
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }

        public JsonResult UpdateCategories([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            var categoryDb = this.Data.Categories.GetById(category.Id);

            categoryDb.Name = category.Name;
            this.Data.SaveChanges();

            return Json(new[] { category }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DestroyCategories([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            var cat = this.Data.Categories.GetById(category.Id);

            var tickets = cat.Tickets.ToList();
            foreach (var ticket in tickets)
            {
                ticket.Author = null;

                var comments = ticket.Comments.ToList();
                foreach (var comment in comments)
                {
                    this.Data.Commetns.Delete(comment);

                }

                this.Data.Tickets.Delete(ticket);
            }



            this.Data.Categories.Delete(cat);

            this.Data.SaveChanges();

            return Json(new[] { category }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Exam.Models;
using Exam.Data;

namespace Exam.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdministrationCommentController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /AdministrationComment/
        public ActionResult Index()
        {
            var comments = db.Comments.Include(c => c.PostedBy).Include(c => c.Ticket);
            return View(comments.ToList());
        }

        // GET: /AdministrationComment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: /AdministrationComment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostedById = new SelectList(db.Users, "Id", "UserName", comment.PostedById);
            ViewBag.TicketId = new SelectList(db.Tickets, "Id", "Title", comment.TicketId);
            return View(comment);
        }

        // POST: /AdministrationComment/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Comment comment)
        {
            if (ModelState.IsValid)
            {
                var commentTarget = this.Data.Commetns.GetById(comment.Id);
                commentTarget.Content = comment.Content;
                this.Data.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PostedById = new SelectList(db.Users, "Id", "UserName", comment.PostedById);
            ViewBag.TicketId = new SelectList(db.Tickets, "Id", "Title", comment.TicketId);
            return View(comment);
        }

        // GET: /AdministrationComment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: /AdministrationComment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}

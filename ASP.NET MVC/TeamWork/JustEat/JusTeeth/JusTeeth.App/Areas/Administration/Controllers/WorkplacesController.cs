using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JusTeeth.Models;
using JusTeeth.Data;

namespace JusTeeth.App.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class WorkplacesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Administration/Workplaces/
        public ActionResult Index()
        {
            return View(db.Workplaces.ToList());
        }

        // GET: /Administration/Workplaces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workplace workplace = db.Workplaces.Find(id);
            if (workplace == null)
            {
                return HttpNotFound();
            }
            return View(workplace);
        }

        // GET: /Administration/Workplaces/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Administration/Workplaces/Create
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Workplace workplace)
        {
            if (ModelState.IsValid)
            {
                db.Workplaces.Add(workplace);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workplace);
        }

        // GET: /Administration/Workplaces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workplace workplace = db.Workplaces.Find(id);
            if (workplace == null)
            {
                return HttpNotFound();
            }
            return View(workplace);
        }

        // POST: /Administration/Workplaces/Edit/5
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Workplace workplace)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workplace).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workplace);
        }

        // GET: /Administration/Workplaces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workplace workplace = db.Workplaces.Find(id);
            if (workplace == null)
            {
                return HttpNotFound();
            }
            return View(workplace);
        }

        // POST: /Administration/Workplaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Workplace workplace = db.Workplaces.Find(id);
            db.Workplaces.Remove(workplace);
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

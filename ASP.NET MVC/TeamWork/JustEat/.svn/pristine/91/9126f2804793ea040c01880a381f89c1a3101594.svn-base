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
using JusTeeth.App.Areas.Administration.ViewModels;

namespace JusTeeth.App.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PlacesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Administration/Places/
        public ActionResult Index()
        {
            return View(db.Places.ToList());
        }

        // GET: /Administration/Places/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = db.Places.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // GET: /Administration/Places/Create
        public ActionResult Create()
        {
            PlaceViewModel place = new PlaceViewModel();


            place.EatTypeItems = GetEatTypeItems();
            place.PriceTypeItems = GetPriceTypeItems();

            return View(place);
        }

        // POST: /Administration/Places/Create
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Place place)
        {
            if (ModelState.IsValid)
            {
                db.Places.Add(place);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(place);
        }

        // GET: /Administration/Places/Edit/5
        public ActionResult Edit(int? id)
        {
            PlaceViewModel placeVM;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = db.Places.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            else
            {
                placeVM = new PlaceViewModel()
                {
                    Address = place.Address,
                    AlternativeName = place.AlternativeName,
                    Description = place.Description,
                    EatTime = place.EatTime,
                    Id = place.Id,
                    Latitude = place.Latitude,
                    Longitude = place.Longitude,
                    MonthRating = place.MonthRating,
                    Name = place.Name,
                    PriceType = place.PriceType,
                    Rating = place.Rating
                };
            }

            placeVM.EatTypeItems = GetEatTypeItems();
            placeVM.PriceTypeItems = GetPriceTypeItems();

            return View(placeVM);
        }

        // POST: /Administration/Places/Edit/5
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Place place)
        {
            if (ModelState.IsValid)
            {
                db.Entry(place).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(place);
        }

        // GET: /Administration/Places/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = db.Places.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // POST: /Administration/Places/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Place place = db.Places.Find(id);
            db.Places.Remove(place);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private List<SelectListItem> GetEatTypeItems()
        {
            string[] rawTypes = Enum.GetNames(typeof(EatTimeType));
            List<SelectListItem> eatList = new List<SelectListItem>();
            for (int i = 0; i < rawTypes.Length; i++)
            {
                eatList.Add(new SelectListItem()
                {
                    Text = rawTypes[i],
                    Value = i.ToString()
                });
            }

            return eatList;
        }

        private List<SelectListItem> GetPriceTypeItems()
        {
            string[] rawTypes = Enum.GetNames(typeof(PriceType));
            List<SelectListItem> priceList = new List<SelectListItem>();
            for (int i = 0; i < rawTypes.Length; i++)
            {
                priceList.Add(new SelectListItem()
                {
                    Text = rawTypes[i],
                    Value = i.ToString()
                });
            }

            return priceList;
        }
    }
}

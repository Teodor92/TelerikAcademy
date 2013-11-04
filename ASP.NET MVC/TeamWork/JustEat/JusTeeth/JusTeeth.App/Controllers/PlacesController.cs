using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JusTeeth.App.Models;
using JusTeeth.App.ViewModels;
using JusTeeth.Models;
using Microsoft.AspNet.Identity;

namespace JusTeeth.App.Controllers
{
    public class PlacesController : BaseController
    {
        public ActionResult Index()
        {
            var places = this.Db.PlaceRepository.All().ToList();

            return View(places);
        }

        public ActionResult Details(int id)
        {
            var place = this.Db.PlaceRepository.GetById(id);
            if (id == null)
            {
                //TODO: some bad exception
            }

            if (place == null)
            {
                //TODO: error handling
            }

            int piePercent = 10;
            string color = "#37e800";
            switch (place.EatTime)
            {
                case (EatTimeType)1:
                    piePercent = 10;
                    color = "#37e800";
                    break;
                case (EatTimeType)2:
                    piePercent = 25;
                    color = "#dae800";
                    break;
                case (EatTimeType)3:
                    piePercent = 50;
                    color = "#e8a400";
                    break;
                case (EatTimeType)4:
                    piePercent = 70;
                    color = "#dae800";
                    break;
                case (EatTimeType)5:
                    piePercent = 90;
                    color = "#e8a400";
                    break;
                default:
                    piePercent = 10;
                    color = "#37e800";
                    break;
            }
            int remainingPercent = 100 - piePercent;

            int pricePiePercent = 10;
            string priceColor = "#37e800";
            switch (place.PriceType)
            {
                case (PriceType)1:
                    pricePiePercent = 10;
                    priceColor = "#37e800";
                    break;
                case (PriceType)2:
                    pricePiePercent = 25;
                    priceColor = "#dae800";
                    break;
                case (PriceType)3:
                    pricePiePercent = 50;
                    priceColor = "#e8a400";
                    break;
                case (PriceType)4:
                    pricePiePercent = 70;
                    priceColor = "#dae800";
                    break;
                case (PriceType)5:
                    pricePiePercent = 90;
                    priceColor = "#e8a400";
                    break;
                default:
                    pricePiePercent = 10;
                    priceColor = "#37e800";
                    break;
            }
            int priceRemainingPercent = 100 - pricePiePercent;

            var model = new DetailedPlaceViewModel()
            {
                Id = place.Id,
                Name = place.Name,
                AlternativeName = place.AlternativeName,
                Address = place.Address,
                Rating = place.Rating,
                MonthRating = place.MonthRating,
                Latitude = place.Latitude,
                Longitude = place.Longitude,
                EatColor = color,
                Description = place.Description,
                EatPiePercent = piePercent,
                EatRemainingPercent = remainingPercent,
                PriceColor = priceColor,
                PricePiePercent = pricePiePercent,
                PriceRemainingPercent = priceRemainingPercent,
                Feedbacks = place.Feedbacks.Select(x => new FeedbackViewModel()
                {
                    Content = x.Content,
                    User = new LightUserViewModel()
                    {
                        Avatar = x.User.Avatar,
                        FacebookProfile = x.User.FacebookProfile,
                        DisplayName = x.User.DisplayName,
                        Department = x.User.Department == null ? string.Empty : x.User.Department.Name,
                        UserName = x.User.UserName
                    },
                    EatTime = x.EatTime,
                    Rating = x.Rating,
                    PriceType = x.PriceType,
                    Title = x.Title
                }).ToList(),
                Users = place.Visitors.Select(x => new LightUserViewModel()
                {
                    Avatar = x.Avatar,
                    FacebookProfile = x.FacebookProfile,
                    DisplayName = x.DisplayName,
                    Department = x.Department == null ? string.Empty : x.Department.Name,
                    UserName = x.UserName
                }).ToList()
            };

            ViewBag.EatTime = Enum.GetNames(typeof(EatTimeType));
            ViewBag.Price = Enum.GetNames(typeof(PriceType));

            return View(model);
        }

        [HttpPost]
        [ActionName("Feedback")]
        public ActionResult LeaveFeedback(LeaveFeedbackModel model)
        {
            var priceType = ConvertStringToPriceType(model.PriceType);
            var eatTime = ConvertStringToEatTime(model.EatTime);

            var place = this.Db.PlaceRepository.GetById(model.PlaceId);
            var user = this.Db.UsersRepository.GetUserByUserId(this.User.Identity.GetUserId());
            var feedback = new Feedback()
            {
                Content = model.Content,
                Place = place,
                Rating = model.Score,
                Title = model.Title,
                User = user,
                EatTime = eatTime,
                PriceType = priceType
            };
            this.Db.FeedbackRepository.Add(feedback);
            this.Db.SaveChanges();

            //Update place rating
            AddPlaceRating(model.PlaceId, model.Score);

            var returnedFeedback = new FeedbackViewModel()
            {
                Content = feedback.Content,
                User = new LightUserViewModel()
                {
                    Avatar = feedback.User.Avatar,
                    FacebookProfile = feedback.User.FacebookProfile,
                    DisplayName = feedback.User.DisplayName,
                    UserName = feedback.User.UserName,
                },
                Rating = feedback.Rating,
                Title = feedback.Title,
                EatTime = feedback.EatTime,
                PriceType = feedback.PriceType
            };

            return PartialView("_FeedbackPartial", returnedFeedback);
        }

        private EatTimeType ConvertStringToEatTime(string p)
        {
            switch (p)
            {
                case "Fast" :
                    return EatTimeType.Fast;
                case "GameBreaker":
                    return EatTimeType.GameBreaker;
                case "Medium":
                    return EatTimeType.Medium;
                case "Slow":
                    return EatTimeType.Slow;
                case "Ultrafast":
                    return EatTimeType.Ultrafast;
                default:
                    throw new ArgumentException("Eat time is invalid");
            }
        }

        private PriceType ConvertStringToPriceType(string p)
        {
            switch (p)
            {
                case "Cheap":
                    return PriceType.Cheap;
                case "Expensive":
                    return PriceType.Expensive;
                case "Luxury":
                    return PriceType.Luxury;
                case "MediumPriced":
                    return PriceType.MediumPriced;
                case "SuperCheap":
                    return PriceType.SuperCheap;
                default:
                    throw new ArgumentException("Price type is invalid");
            }
        }

        public void AddPlaceRating(int placeId, int rating)
        {
            var place = this.Db.PlaceRepository.GetById(placeId);
            var allScores = 0;
            foreach (var feedback in place.Feedbacks)
            {
                allScores += feedback.Rating;
            }

            var newRating = (double)allScores/place.Feedbacks.Count;

            place.Rating = newRating;
            this.Db.SaveChanges();
        }

        public JsonResult GetPushpins()
        {
            var result = this.Db.PlaceRepository
                .All()
                .Select(x => new PlaceViewModel
                {
                    Id = x.Id,
                    Address = x.Address,
                    Latitude = x.Latitude,
                    Longitude = x.Longitude,
                    Name = x.Name,
                    AlternativeName = x.AlternativeName,
                    Description = x.Description,
                    Rating = x.Rating
                });

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
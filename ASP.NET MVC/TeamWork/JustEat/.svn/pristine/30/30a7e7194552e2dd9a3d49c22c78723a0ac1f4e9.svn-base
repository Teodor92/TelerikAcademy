using System.Web.Mvc;
using JusTeeth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace JusTeeth.App.Areas.Administration.ViewModels
{
    public class HungryGroupViewModel
    {
        public int Id { get; set; }

        public virtual ApplicationUser Creator { get; set; }

        public DateTime StartingTime { get; set; }

        public EatTimeType EatTime { get; set; }

        public int PlaceId { get; set; }

        public virtual Place Place { get; set; }

        public virtual ICollection<ApplicationUser> HungryUsers { get; set; }

        public List<SelectListItem> EatItemsDropdown { get; set; }

        public List<SelectListItem> PlacesDropdown { get; set; }

        //public static Expression<Func<HungryGroupViewModel, HungryGroup>> ToModel
        //{
        //    get
        //    {
        //        return x => new HungryGroup()
        //        {
        //            Address = x.Address,
        //            AlternativeName = x.AlternativeName,
        //            Description = x.Description,
        //            EatTime = x.EatTime,
        //            Id = x.Id,
        //            Latitude = x.Latitude,
        //            Longitude = x.Longitude,
        //            MonthRating = x.MonthRating,
        //            Name = x.Name,
        //            PriceType = x.PriceType,
        //            Rating = x.Rating
        //        };
        //    }
        //}
    }
}
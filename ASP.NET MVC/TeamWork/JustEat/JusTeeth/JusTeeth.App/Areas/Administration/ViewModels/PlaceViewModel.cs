using System.Linq.Expressions;
using System.Web.Mvc;
using JusTeeth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JusTeeth.App.Areas.Administration.ViewModels
{
    public class PlaceViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AlternativeName { get; set; }

        public string Address { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public EatTimeType EatTime { get; set; }

        public double Rating { get; set; }

        public double MonthRating { get; set; }

        public PriceType PriceType { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public List<SelectListItem> EatTypeItems { get; set; }

        public List<SelectListItem> PriceTypeItems { get; set; }

        public static Expression<Func<Place, PlaceViewModel>> FromModel
        {
            get
            {
                return x => new PlaceViewModel()
                {
                    Address = x.Address,
                    AlternativeName = x.AlternativeName,
                    Description = x.Description,
                    EatTime = x.EatTime,
                    Id = x.Id,
                    Latitude = x.Latitude,
                    Longitude = x.Longitude,
                    MonthRating = x.MonthRating,
                    Name = x.Name,
                    PriceType = x.PriceType,
                    Rating = x.Rating
                };
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using JusTeeth.Models;

namespace JusTeeth.App.ViewModels
{
    public class DetailedHungryGroupViewModel : HungryGroupViewModel
    {
        public string CreatorUsername { get; set; }

        public string Address { get; set; }

        public decimal Latitude { get; set; }
 
        public decimal Longitude { get; set; }

        public string EatColor { get; set; }

        public int EatPiePercent { get; set; }

        public int EatRemainingPercent { get; set; }

        public string PriceColor { get; set; }

        public int PricePiePercent { get; set; }

        public int PriceRemainingPercent { get; set; }

        public ICollection<HungryUserViewModel> Users { get; set; }

        public static Expression<Func<HungryGroup, DetailedHungryGroupViewModel>> FromDetailedHungryGroup
        {
            get
            {
                return x =>
                    new DetailedHungryGroupViewModel
                    {
                        Creator = x.Creator.DisplayName,
                        CreatorUsername = x.Creator.UserName,
                        CreatorId = x.Creator.Id,
                        EatTime = x.EatTime.ToString(),
                        Id = x.Id,
                        Place = x.Place.Name,
                        PlaceId = x.Place.Id,
                        StartingTime = x.StartingTime.ToString("MM/dd/yy H:mm:ss"),
                        Latitude = x.Place.Latitude,
                        Longitude = x.Place.Longitude,
                        Users = (from user in x.HungryUsers
                                select new HungryUserViewModel()
                                {
                                    Id = user.Id,
                                    DisplayName = user.DisplayName,
                                    Avatar = user.DisplayName
                                }).ToList()
                    };
            }
        }
    }
}
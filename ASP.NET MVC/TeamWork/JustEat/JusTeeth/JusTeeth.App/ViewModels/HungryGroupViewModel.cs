using JusTeeth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace JusTeeth.App.ViewModels
{
    public class HungryGroupViewModel
    {
        public string Creator { get; set; }

        public string UserName { get; set; }

        public string CreatorId { get; set; }

        public string EatTime { get; set; }

        public int Id { get; set; }

        public string Place { get; set; }

        public int PlaceId { get; set; }

        public string Price { get; set; }

        public string StartingTime { get; set; }

        public bool IsCurrentUserJoint { get; set; }

        public static Expression<Func<HungryGroup, HungryGroupViewModel>> FromHungryGroup
        {
            get
            {
                return x =>
                    new HungryGroupViewModel
                    {
                        Creator = x.Creator.DisplayName,
                        CreatorId = x.Creator.Id,
                        EatTime = x.EatTime.ToString(),
                        Id = x.Id,
                        Place = x.Place.Name,
                        PlaceId = x.Place.Id,
                        StartingTime = x.StartingTime.ToString("H:mm:ss MM/dd/yy"),
                        UserName = x.Creator.UserName,
                        Price = x.Place.PriceType.ToString()
                    };
            }
        }

    }
}

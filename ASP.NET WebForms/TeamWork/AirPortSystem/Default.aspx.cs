using AirPortSystem.Data;
using AirPortSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using Error_Handler_Control;

namespace AirPortSystem
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<Flight>
            GridViewFlightsAdmin_GetData([Control] string dropDownListFromAirport, [Control] string dropDownListEndPoint)
        {
            var db = new AirPortDbContext();

            if (dropDownListFromAirport != null && dropDownListEndPoint != null)
            {
                return db.Flights.Where(f => f.FromAirPort == dropDownListFromAirport && f.ToAirPort == dropDownListEndPoint).Where(f => f.FlightDate >= DateTime.Now);
            }
            else if (dropDownListFromAirport != null)
            {
                return db.Flights.Where(f => f.FromAirPort == dropDownListFromAirport).Where(f => f.FlightDate >= DateTime.Now);
            }
            else if (dropDownListEndPoint != null)
            {
                return db.Flights.Where(f => f.FromAirPort == dropDownListEndPoint).Where(f => f.FlightDate >= DateTime.Now);
            }

            return db.Flights.OrderBy(f => f.FlightDate).Where(f => f.FlightDate >= DateTime.Now);
        }

        public IQueryable<string> DropDownListFromAirport_GetData()
        {
            var db = new AirPortDbContext();
            return db.Flights
                .GroupBy(f => f.FromAirPort)
                .Select(f => f.Key)
                .OrderBy(f => f);
        }

        public IQueryable<string> DropDownListToAirport_GetData()
        {
            var db = new AirPortDbContext();
            return db.Flights
                .GroupBy(f => f.ToAirPort)
                .Select(f => f.Key)
                .OrderBy(f => f);
        }

        protected void ButtonBuyTicket_Command(object sender, CommandEventArgs e)
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/BuyTicket.aspx?FlightId=" + e.CommandArgument.ToString());
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        public bool isButtonEnabled(int number)
        {
            if (number <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
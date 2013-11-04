using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AirPortSystem.Data;
using AirPortSystem.Models;
using System.Web.ModelBinding;
using Error_Handler_Control;

namespace AirPortSystem.Administration
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ButtonAddFlight_Click(object sender, EventArgs e)
        {
            Control footerControl = null;

            if (this.GridViewFlightsAdmin.FooterRow != null)
            {
                footerControl = this.GridViewFlightsAdmin.FooterRow;
            }
            else
            {
                footerControl = this.GridViewFlightsAdmin.Controls[0].Controls[0];
            }

            string fromAirport = (footerControl.FindControl("TextBoxFromAirPort") as TextBox).Text;
            string toAirport = (footerControl.FindControl("TextBoxToAirPort") as TextBox).Text;

            DateTimePicker dtp = (footerControl.FindControl("DateTimePicker") as DateTimePicker);
            string date = (dtp.FindControl("TextBoxFlightDate") as TextBox).Text;
            string time = (dtp.FindControl("TextBoxFlightTime") as TextBox).Text;
            string dateAndTime = date + " " + time;

            //  string result = (dtp.FindControl("TextBoxFlightDate") as TextBox).Text;
            DateTime flightDate = DateTime.ParseExact(dateAndTime, "dd-MM-yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            int availableTickets = int.Parse((footerControl.FindControl("TextBoxAvailableTickets") as TextBox).Text);
            decimal price = decimal.Parse((footerControl.FindControl("TextBoxPrice") as TextBox).Text);

            if (fromAirport != null && toAirport != null)
            {
                var db = new AirPortDbContext();
                Flight flight = new Flight()
                {
                    FromAirPort = fromAirport,
                    ToAirPort = toAirport,
                    FlightDate = flightDate,
                    AvailableTickets = availableTickets,
                    Price = price
                };

                db.Flights.Add(flight);
                db.SaveChanges();

                (footerControl.FindControl("TextBoxFromAirPort") as TextBox).Text = "";
                (footerControl.FindControl("TextBoxToAirPort") as TextBox).Text = "";
                (footerControl.FindControl("TextBoxAvailableTickets") as TextBox).Text = "";
                (footerControl.FindControl("TextBoxPrice") as TextBox).Text = "";
                DataBind();
            }
        }

        public IQueryable<Flight> GridViewFlightsAdmin_GetData([Control]
                                     string dropDownListFromAirport, [Control]
                                     string dropDownListEndPoint)
        {
            var db = new AirPortDbContext();

            if (dropDownListFromAirport != null
                && dropDownListEndPoint != null
                && dropDownListEndPoint == dropDownListFromAirport)
            {
                ErrorSuccessNotifier.AddInfoMessage("Start and Endpoint must be different!");
                return null;
            }

            if (dropDownListFromAirport != null && dropDownListEndPoint != null)
            {
                return db.Flights.Where(f => f.FromAirPort == dropDownListFromAirport && f.ToAirPort == dropDownListEndPoint);
            }
            else if (dropDownListFromAirport != null)
            {
                return db.Flights.Where(f => f.FromAirPort == dropDownListFromAirport);
            }
            else if (dropDownListEndPoint != null)
            {
                return db.Flights.Where(f => f.FromAirPort == dropDownListEndPoint);
            }

            return db.Flights.OrderBy(f => f.FlightDate);
        }

        public void GridViewFlightsAdmin_UpdateItem(int id)
        {
            var db = new AirPortDbContext();
            Flight item = db.Flights.FirstOrDefault(f => f.Id == id);
            if (item == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                db.SaveChanges();
            }
        }

        public void GridViewFlightsAdmin_DeleteItem(int id)
        {
            var db = new AirPortDbContext();
            AirPortSystem.Models.Flight item = db.Flights.FirstOrDefault(f => f.Id == id);
            if (item == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            else
            {
                db.Flights.Remove(item);
                db.SaveChanges();
            }
        }

        public IQueryable<string> DropDownListFromAirport_GetData()
        {
            var db = new AirPortDbContext();
            return db.Flights.GroupBy(f => f.FromAirPort).Select(f => f.Key).OrderBy(f => f);
        }

        public IQueryable<string> DropDownListToAirport_GetData()
        {
            var db = new AirPortDbContext();
            return db.Flights.GroupBy(f => f.ToAirPort).Select(f => f.Key).OrderBy(f => f);
        }
    }
}
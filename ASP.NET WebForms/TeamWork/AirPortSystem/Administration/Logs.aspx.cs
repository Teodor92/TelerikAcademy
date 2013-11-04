using AirPortSystem.Data;
using AirPortSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AirPortSystem.Administration
{
    public partial class Logs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<NumberOfTicketsBoughtModel> TicketsByDateGridView_GetData()
        {
            var context = new AirPortDbContext();

            var groupedLogs = from log in context.Logs
                    let dateTime = log.DateBought
                    group log by new { y = dateTime.Year, m = dateTime.Month, d = dateTime.Day} into g
                    select g;

            var output = new List<NumberOfTicketsBoughtModel>();

            foreach (var item in groupedLogs)
            {
                output.Add(new NumberOfTicketsBoughtModel() 
                { 
                    BoughtDate = item.FirstOrDefault().DateBought.Date,
                    NumberOfTickets = item.Count()
                });
            }

            return output.OrderByDescending(x => x.BoughtDate).AsQueryable<NumberOfTicketsBoughtModel>();
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<NumberOfFlightsToModel> NumberOfFlightsToGridView_GetData()
        {
            var context = new AirPortDbContext();
            var groupedLogs = context.Flights.GroupBy(x => x.ToAirPort);
            var output = new List<NumberOfFlightsToModel>();

            foreach (var item in groupedLogs)
            {
                output.Add(new NumberOfFlightsToModel()
                {
                    Destination = item.FirstOrDefault().ToAirPort,
                    NumberOfFlights = item.Count()
                });
            }

            return output.OrderByDescending(x => x.NumberOfFlights).AsQueryable<NumberOfFlightsToModel>();
        }
    }
}
using AirPortSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using Error_Handler_Control;
using AirPortSystem.Models;
using System.Transactions;

namespace AirPortSystem
{
    public partial class BuyTicket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public AirPortSystem.Models.Flight DetailsViewBuyTicket_GetItem([QueryString] int? FlightId)
        {
            var db = new AirPortDbContext();
            return db.Flights.FirstOrDefault(f => f.Id == FlightId);
        }

        protected void ButtonBuyTicket_Click(object sender, EventArgs e)
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                string user = Context.User.Identity.Name;
                int flightId = int.Parse(Request.Params["FlightId"]);
                string cardType = (this.DetailsViewBuyTicket.FindControl("CardType") as DropDownList).SelectedValue;
                string cardNumber = (this.DetailsViewBuyTicket.FindControl("TextBoxCardNumber") as TextBox).Text;

                if (cardType == null || cardType == string.Empty)
                {
                    ErrorSuccessNotifier.AddErrorMessage("Please select card type");
                }
                else if (cardNumber == null || cardNumber == string.Empty)
                {
                    ErrorSuccessNotifier.AddErrorMessage("Please enter card number");
                }
                else
                {
                    try
                    {
                        using (TransactionScope scope = new TransactionScope())
                        {
                            var db = new AirPortDbContext();
                            AirPortUser currentUser = db.Users.FirstOrDefault(u => u.UserName == user);
                            Flight currentFlight = db.Flights.FirstOrDefault(f => f.Id == flightId);
                            Ticket currentTicket = new Ticket() { Flight = currentFlight, User = currentUser };
                            Log currentLog = new Log()
                            {
                                CardNumber = cardNumber,
                                CardType = cardType,
                                DateBought = DateTime.Now,
                                Ticket = currentTicket,
                                User = currentUser
                            };

                            if (currentFlight.AvailableTickets <= 0)
                            {
                                ErrorSuccessNotifier.AddInfoMessage("No tickets available!");
                                ErrorSuccessNotifier.ShowAfterRedirect = true;
                                Response.Redirect("~/", false);
                                return;
                            }

                            currentFlight.AvailableTickets = currentFlight.AvailableTickets - 1;
                            db.Tickets.Add(currentTicket);
                            db.Logs.Add(currentLog);
                            db.SaveChanges();
                            scope.Complete();

                            ErrorSuccessNotifier.AddSuccessMessage("Ticket bought successfully!");
                            ErrorSuccessNotifier.ShowAfterRedirect = true;
                            Response.Redirect("~/", false);
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorSuccessNotifier.AddErrorMessage(ex);
                    }
                }
            }
            else
            {
                ErrorSuccessNotifier.AddErrorMessage("Please login!");
            }
        }
    }
}
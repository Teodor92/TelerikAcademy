using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AirPortSystem.Models;
using AirPortSystem.Data;

namespace AirPortSystem.Account
{
    public partial class MyTickets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }


        protected void Page_PreRender(object sender, EventArgs e)
        {

        }
        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<AirPortSystem.Models.Log> ListBoxPosts_GetData()
        {
            var userName = Context.User.Identity.Name;

            var context = new AirPortDbContext();

            var user = context.Users.Where(u => u.UserName == userName).FirstOrDefault();

            // TODO - Add DTO here
            var userTickets = context.Logs.Include("Ticket").Include("User").Where(l => l.User.Id == user.Id);

            return userTickets;
        }

        protected void ButtonDetails_Command(object sender, CommandEventArgs e)
        {
            var id = Convert.ToInt32(e.CommandArgument);

            var context = new AirPortDbContext();

            // TODO - Add DTO here
            var ticketDetails = context.Logs.Include("Ticket").Include("User").Where(l => l.Id == id).ToList();

            this.ListViewDetails.DataSource = ticketDetails;
            this.ListViewDetails.DataBind();
            this.ListViewDetails.Visible = true;
        }
    }
}
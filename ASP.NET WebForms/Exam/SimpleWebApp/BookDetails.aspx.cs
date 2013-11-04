using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleWebApp.Models;

namespace SimpleWebApp
{
    public partial class BookDetails : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Page.Request.QueryString["id"]);
            
            var context = new ApplicationDbContext();
            var books = context.Books.Where(b => b.Id == id);

            this.BookDetailsFormView.DataSource = books.ToList();
            this.BookDetailsFormView.DataBind();
        }
    }
}
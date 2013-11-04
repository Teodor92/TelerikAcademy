using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Data.Entity;
using System.Web.UI.WebControls;
using SimpleWebApp.Models;

namespace SimpleWebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Category> CategoriesRepeater_GetData()
        {
            var context = new ApplicationDbContext();
            return context.Categories.Include(x => x.Books);
        }

        protected void Search_Command(object sender, CommandEventArgs e)
        {
            string queryString = this.SearchQuery.Text;
            Response.Redirect(string.Format("~/Search?q={0}", queryString));
        }
    }
}
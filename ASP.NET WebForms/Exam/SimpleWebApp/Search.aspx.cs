using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleWebApp.Models;
using System.Data.Entity;
using Error_Handler_Control;

namespace SimpleWebApp
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            string qureyString = Page.Request.QueryString["q"];
            if (qureyString.Length != 0 && qureyString.Length > 50)
            {
                ErrorSuccessNotifier.AddErrorMessage("Search query is too long.");
                ErrorSuccessNotifier.ShowAfterRedirect = true;

                this.QueryTitle.Text = "Invalid Search";
            }
            else
            {

                var context = new ApplicationDbContext();

                string searchTitle = string.Format("Search Results for Query \"{0}\"", Server.HtmlEncode(qureyString));
                this.QueryTitle.Text = searchTitle;

                IEnumerable<Book> searchResults;

                if (string.IsNullOrWhiteSpace(qureyString))
                {
                    searchResults = context.Books
                        .Include(x => x.Category)
                        .OrderBy(x => x.Title)
                        .ThenBy(x => x.Author)
                        .ToList();
                }
                else
                {
                    searchResults = context.Books
                    .Include(x => x.Category)
                    .Where(b => b.Title.ToLower().Contains(qureyString) || b.Author.ToLower().Contains(qureyString))
                    .OrderBy(x => x.Title)
                    .ThenBy(x => x.Author)
                    .ToList();
                }

                this.SearchResultReapter.DataSource = searchResults;
                this.SearchResultReapter.DataBind();
            }
        }
    }
}
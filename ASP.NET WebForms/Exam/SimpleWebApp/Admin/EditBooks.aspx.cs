using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleWebApp.Models;
using System.Data.Entity;
using Error_Handler_Control;
using System.Text.RegularExpressions;

namespace SimpleWebApp
{
    public partial class EditBooks : System.Web.UI.Page
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
        public IQueryable<BookDTO> BooksGridView_GetData()
        {
            var context = new ApplicationDbContext();
            return context.Books
                .Include(book => book.Category).Select(b => new BookDTO() 
                { 
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Description = b.Description,
                    WebSite = b.WebSite,
                    Category = b.Category.Name,
                    ISBN = b.ISBN
                });
        }

        #region Edit Handlers

        protected void Edit_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            var context = new ApplicationDbContext();
            this.EditBookFormView.DataSource = context.Books
                .Include(x => x.Category)
                .Where(b => b.Id == id)
                .ToList();
            this.EditBookFormView.DataBind();
        }

        protected void Save_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(this.EditBookFormView.DataKey.Value);

            var titlePreTb = this.EditBookFormView.FindControl("BookEditTitleTextBox");
            string title = (titlePreTb as TextBox).Text;

            var authorsPreTb = this.EditBookFormView.FindControl("BookEditAuthorsTextBox");
            string author = (authorsPreTb as TextBox).Text;

            var isbnPreTb = this.EditBookFormView.FindControl("BookEditISBNTextBox");
            string isbn = (isbnPreTb as TextBox).Text;

            var websitePreTb = this.EditBookFormView.FindControl("BookEditWebSiteTextBox");
            string website = (websitePreTb as TextBox).Text;

            var descriptionPreTb = this.EditBookFormView.FindControl("BookEditDescriptionTextBox");
            string description = (descriptionPreTb as TextBox).Text;

            var dropdownPre = this.EditBookFormView.FindControl("CategoryEditDropDown");
            int selectedId = int.Parse((dropdownPre as DropDownList).SelectedValue);

            //var isIsbnValid = Regex.IsMatch(isbn, @"^\d{9}[\d|X]$");
            //var isWebSiteValid = Regex.IsMatch(website, @"/^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$/");

            if (string.IsNullOrWhiteSpace(title) || title.Length > 100)
            {
                this.MakeErrorMessage("Title value is incorrect.");
            }
            else if (string.IsNullOrWhiteSpace(author) || author.Length > 100)
            {
                this.MakeErrorMessage("Author value is incorrect.");
            }
            else if (isbn.Length > 100)
            {
                this.MakeErrorMessage("ISBN is incorect.");
            }
            else if (website.Length > 100)
            {
                this.MakeErrorMessage("Website value is not valid.");
            }
            else if (string.IsNullOrWhiteSpace(description) || description.Length > 2000)
            {
                this.MakeErrorMessage("Discription value is inccorect.");
            }
            else
            {
                var context = new ApplicationDbContext();
                var category = context.Categories.Find(selectedId);
                var book = context.Books.Find(id);

                book.Title = title;
                book.Author = author;
                book.ISBN = isbn;
                book.WebSite = website;
                book.Description = description;
                book.Category = category;

                context.SaveChanges();

                this.MakeSuccessMessage("Book modified.");
                this.RedirectHome();
            }
        }

        #endregion

        public IQueryable<Category> CategoryDropDown_CategoryDropDown()
        {
            var context = new ApplicationDbContext();
            return context.Categories;
        }

        #region Delete Handlers

        protected void ConfurmDelete_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(this.DeleteBookFormView.DataKey.Value);

            var parent = this.DeleteBookFormView.FindControl("DeleteNameTextBox");
            var textbox = parent as TextBox;
            string text = textbox.Text;

            var context = new ApplicationDbContext();
            var book = context.Books.Find(id);

            if (text != book.Title)
            {
                RedirectHome();
            }

            context.Books.Remove(book);
            context.SaveChanges();

            this.MakeSuccessMessage("Book delited.");
            RedirectHome();
        }

        protected void Delete_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            var context = new ApplicationDbContext();
            var category = context.Books.Where(x => x.Id == id).ToList();
            this.DeleteBookFormView.DataSource = category;
            this.DeleteBookFormView.DataBind();
        }

        #endregion

        #region Add Handlers

        protected void ShowAddPannel_Command(object sender, CommandEventArgs e)
        {
            this.ShowAddPanelButton.Visible = false;
            this.AddNewBookPanel.Visible = true;

            var context = new ApplicationDbContext();
            var categories = context.Categories.ToList();

            this.CategoryDropDown.DataSource = categories;
            this.CategoryDropDown.DataValueField = "Id";
            this.CategoryDropDown.DataTextField = "Name";
            this.CategoryDropDown.DataBind();
        }

        protected void AddNewBook_Command(object sender, CommandEventArgs e)
        {
            string title = this.BookTitleTextBox.Text;
            string authors = this.BookAuthorsTextBox.Text;
            string isbn = this.BookISBNTextBox.Text;
            string website = this.BookWebSiteTextBox.Text;
            string description = this.BookDescriptionTextBox.Text;
            int selectedId = int.Parse(this.CategoryDropDown.SelectedValue);

            if (string.IsNullOrWhiteSpace(title) || title.Length > 100)
            {
                this.MakeErrorMessage("Title value is incorrect.");
            }
            else if (string.IsNullOrWhiteSpace(authors) || authors.Length > 100)
            {
                this.MakeErrorMessage("Author value is incorrect.");
            }
            else if (isbn.Length > 100)
            {
                this.MakeErrorMessage("ISBN is incorect.");
            }
            else if (website.Length > 100)
            {
                this.MakeErrorMessage("Website value is not valid.");
            }
            else if (string.IsNullOrWhiteSpace(description) || description.Length > 2000)
            {
                this.MakeErrorMessage("Discription value is inccorect.");
            }
            else
            {
                var context = new ApplicationDbContext();
                var category = context.Categories.Find(selectedId);

                var newBook = new Book()
                {
                    Title = title,
                    Author = authors,
                    ISBN = isbn,
                    WebSite = website,
                    Description = description,
                    Category = category
                };

                context.Books.Add(newBook);
                context.SaveChanges();

                this.MakeSuccessMessage("Book created.");
                this.RedirectHome();
            }
        }

        #endregion

        protected void Cancel_Command(object sender, CommandEventArgs e)
        {
            RedirectHome();
        }

        private void RedirectHome()
        {
            Response.Redirect("~/Admin/EditBooks");
        }

        public void MakeSuccessMessage(string message)
        {
            ErrorSuccessNotifier.AddSuccessMessage(message);
            ErrorSuccessNotifier.ShowAfterRedirect = true;
            RedirectHome();
        }

        public void MakeErrorMessage(string message)
        {
            ErrorSuccessNotifier.AddErrorMessage(message);
            ErrorSuccessNotifier.ShowAfterRedirect = true;
            RedirectHome();
        }
    }
}
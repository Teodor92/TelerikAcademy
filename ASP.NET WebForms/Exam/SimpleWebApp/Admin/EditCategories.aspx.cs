using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleWebApp.Models;
using Error_Handler_Control;

namespace SimpleWebApp
{
    public partial class EditCategories : System.Web.UI.Page
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
        public IQueryable<SimpleWebApp.Models.Category> CategoriesGridView_GetData()
        {
            var context = new ApplicationDbContext();
            return context.Categories;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void CategoriesGridView_DeleteItem(int id)
        {
            var context = new ApplicationDbContext();
            var category = context.Categories.Find(id);
            var books = context.Books.Where(x => x.Category.Id == id);

            foreach (var book in books)
            {
                context.Books.Remove(book);
            }

            context.Categories.Remove(category);
            context.SaveChanges();
        }

        #region Edit Handlers

        protected void Edit_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            var context = new ApplicationDbContext();
            var category = context.Categories.Where(x => x.Id == id).ToList();
            this.EditCategoryFormView.DataSource = category;
            this.EditCategoryFormView.DataBind();
        }

        protected void Save_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(this.EditCategoryFormView.DataKey.Value);
            var parent = this.EditCategoryFormView.FindControl("EditNameTextBox");
            var textbox = parent as TextBox;
            string text = textbox.Text;

            if (string.IsNullOrWhiteSpace(text))
            {
                ErrorSuccessNotifier.AddErrorMessage("Category name must not be emty.");
                ErrorSuccessNotifier.ShowAfterRedirect = true;
                RedirectHome();
            }
            else if (text.Length > 100)
            {
                ErrorSuccessNotifier.AddErrorMessage("Category name is too long.");
                ErrorSuccessNotifier.ShowAfterRedirect = true;
                RedirectHome();
            }
            else
            {
                var context = new ApplicationDbContext();
                var category = context.Categories.Find(id);
                category.Name = text;
                context.SaveChanges();

                ErrorSuccessNotifier.AddSuccessMessage("Category modifed.");
                ErrorSuccessNotifier.ShowAfterRedirect = true;
                RedirectHome();
            }
        }

        #endregion

        #region Delete Handlers

        protected void Delete_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            var context = new ApplicationDbContext();
            var category = context.Categories.Where(x => x.Id == id).ToList();
            this.DeleteFormView.DataSource = category;
            this.DeleteFormView.DataBind();
        }

        protected void DeleteConfurm_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(this.DeleteFormView.DataKey.Value);

            var parent = this.DeleteFormView.FindControl("ConfurmNameTextBox");
            var textbox = parent as TextBox;
            string text = textbox.Text;

            var context = new ApplicationDbContext();
            var category = context.Categories.Find(id);

            if (text != category.Name)
            {
                RedirectHome();
            }

            var books = context.Books.Where(x => x.Category.Id == id);

            foreach (var book in books)
            {
                context.Books.Remove(book);
            }

            context.Categories.Remove(category);
            context.SaveChanges();

            ErrorSuccessNotifier.AddSuccessMessage("Category deleted.");
            ErrorSuccessNotifier.ShowAfterRedirect = true;
            RedirectHome();
        }

        #endregion

        #region Add Handlers

        protected void OpendAddWindow_Command(object sender, CommandEventArgs e)
        {
            this.AddNewButton.Visible = false;
            this.AddNewCategoryForm.Visible = true;
        }

        protected void AddNew_Command(object sender, CommandEventArgs e)
        {

            var parent = this.AddNewCategoryForm.FindControl("AddNewTextBox");
            var textbox = parent as TextBox;
            string text = textbox.Text;

            if (string.IsNullOrWhiteSpace(text))
            {
                ErrorSuccessNotifier.AddErrorMessage("Category name must not be emty.");
                ErrorSuccessNotifier.ShowAfterRedirect = true;
                RedirectHome();
            }
            else if (text.Length > 100)
            {
                ErrorSuccessNotifier.AddErrorMessage("Category name is too long.");
                ErrorSuccessNotifier.ShowAfterRedirect = true;
                RedirectHome();
            }
            else
            {
                var context = new ApplicationDbContext();
                var newCat = new Category()
                {
                    Name = text
                };

                context.Categories.Add(newCat);
                context.SaveChanges();

                ErrorSuccessNotifier.AddSuccessMessage("Category created.");
                ErrorSuccessNotifier.ShowAfterRedirect = true;
                RedirectHome();
            }
        }

        #endregion

        private void BindFormViews()
        {

        }

        protected void Cancel_Command(object sender, CommandEventArgs e)
        {
            RedirectHome();
        }

        private void RedirectHome()
        {
            Response.Redirect("~/Admin/EditCategories", false);
        }
    }
}
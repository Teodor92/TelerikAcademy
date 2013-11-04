using Error_Handler_Control;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using SimpleWebApp.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace SimpleWebApp.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            string userName = UserName.Text;
            var manager = new AuthenticationIdentityManager(new IdentityStore(new ApplicationDbContext()));
            User u = new User(userName) { UserName = userName };
            IdentityResult result = manager.Users.CreateLocalUser(u, Password.Text);
            if (result.Success) 
            {
                manager.Authentication.SignIn(Context.GetOwinContext().Authentication, u.Id, isPersistent: false);
                ErrorSuccessNotifier.AddSuccessMessage("Welcome back.");
                ErrorSuccessNotifier.ShowAfterRedirect = true;
                OpenAuthProviders.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorSuccessNotifier.AddErrorMessage("Register details are incorect.");
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}
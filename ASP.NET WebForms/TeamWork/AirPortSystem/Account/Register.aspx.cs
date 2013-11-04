using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using AirPortSystem.Data;
using AirPortSystem.Models;
using System.Threading;

namespace AirPortSystem.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            string userName = UserName.Text;
            var manager = new AuthenticationIdentityManager(new IdentityStore(new AirPortDbContext()));
            AirPortUser u = new AirPortUser()
            {
                UserName = userName,
                Email = this.Email.Text,
                FirstName = this.FirstName.Text,
                LastName = this.LastName.Text
            };
            IdentityResult result = manager.Users.CreateLocalUser(u, Password.Text);
            AddUserToRole(u.Id, "2", manager);
            if (result.Success)
            {
                manager.Authentication.SignIn(Context.GetOwinContext().Authentication, u.Id, isPersistent: false);
                OpenAuthProviders.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }

        private void AddUserToRole(string id, string roleId, AuthenticationIdentityManager manager)
        {
            manager.Roles.AddUserToRoleAsync(id, roleId);
        }
    }
}
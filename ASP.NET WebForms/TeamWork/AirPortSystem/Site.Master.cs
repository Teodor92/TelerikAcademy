using AirPortSystem.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AirPortSystem
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue ||
                    (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Prerender(object sender, EventArgs e)
        {
            if (this.Context.User.Identity.IsAuthenticated)
            {
                this.LoadImageAvatar();
            }
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut();
        }

        protected void LoadImageAvatar()
        {
            var dbContext = new AirPortDbContext();
            using (dbContext)
            {
                var userId = Context.User.Identity.GetUserId();
                var user = dbContext.Users.Find(userId);
                if (user != null && user.Image != null)
                {
                    var image = this.LoginView.FindControl("MiniAvatar") as HtmlImage;
                    image.Src = "data:image/jpeg;base64," + Convert.ToBase64String(user.Image);
                }
            }
        }

        private bool ShouldRemoveItem(string menuText)
        {
            var dbContext = new AirPortDbContext();

            var userId = Context.User.Identity.GetUserId();
            var user = dbContext.Users.Find(userId);

            if (menuText == "Logout" && user == null)
            {
                return true;
            }
            
            if (menuText == "Admin" && user == null)
            {
                return true;
            }

            if (menuText == "Logs" && user == null)
            {
                return true;
            }

            if (menuText == "My tickets" && user == null)
            {
                return true;
            }

            if (user != null)
            {
                if (menuText == "Admin" && user.Roles.Count == 1)
                {
                    return true;
                }

                if (menuText == "Logs" && user.Roles.Count == 1)
                {
                    return true;
                }

                if (menuText == "My tickets" && user.Roles.Count == 2)
                {
                    return true;
                }
            }

            if (menuText == "Login" && user != null)
            {
                return true;
            }

            if (menuText == "Register" && user != null)
            {
                return true;
            }

            return false;
        }

        protected void NavigationMenu_MenuItemDataBound(object sender, MenuEventArgs e)
        {
            if (ShouldRemoveItem(e.Item.Text))
            {
                e.Item.Parent.ChildItems.Remove(e.Item);
            }
        }
    }
}
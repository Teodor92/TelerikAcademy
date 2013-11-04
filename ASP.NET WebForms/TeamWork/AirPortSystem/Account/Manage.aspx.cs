using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using AirPortSystem.Data;
using System.IO;
using Error_Handler_Control;

namespace AirPortSystem.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        protected string SuccessMessage { get; private set; }
        
        protected bool CanRemoveExternalLogins { get; private set; }

        protected void Page_Load()
        {
            if (!IsPostBack)
            {
                // Determine the sections to render
                ILoginManager manager = new IdentityManager(new IdentityStore(new AirPortDbContext())).Logins;
                if (manager.HasLocalLogin(User.Identity.GetUserId())) 
                {
                    changePasswordHolder.Visible = true;
                    LoadImageAvatar();
                }
                else 
                {
                    setPassword.Visible = true;
                    changePasswordHolder.Visible = false;
                }
                CanRemoveExternalLogins = manager.GetLogins(User.Identity.GetUserId()).Count() > 1;

                // Render success message
                var message = Request.QueryString["m"];
                if (message != null) 
                {
                    // Strip the query string from action
                    Form.Action = ResolveUrl("~/Account/Manage");

                    SuccessMessage =
                                    message == "ChangePwdSuccess" ? "Your password has been changed."
                                    : message == "SetPwdSuccess" ? "Your password has been set."
                                      : message == "RemoveLoginSuccess" ? "The account was removed."
                                        : String.Empty;
                    successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
                }
            }
        }

        private void LoadImageAvatar()
        {
            var dbContext = new AirPortDbContext();
            using (dbContext)
            {
                var userId = User.Identity.GetUserId();
                var user = dbContext.Users.Find(userId);
                if (user.Image != null)
                {
                    this.profileImage.Src = "data:image/jpeg;base64," + Convert.ToBase64String(user.Image);
                }
            }
        }

        protected void ChangePassword_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                IPasswordManager manager = new IdentityManager(new IdentityStore(new AirPortDbContext())).Passwords;
                IdentityResult result = manager.ChangePassword(User.Identity.GetUserName(), CurrentPassword.Text, NewPassword.Text);
                if (result.Success) 
                {
                    Response.Redirect("~/Account/Manage?m=ChangePwdSuccess");
                }
                else 
                {
                    AddErrors(result);
                }
            }
        }

        protected void SetPassword_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Create the local login info and link the local account to the user
                ILoginManager manager = new IdentityManager(new IdentityStore(new AirPortDbContext())).Logins;
                IdentityResult result = manager.AddLocalLogin(User.Identity.GetUserId(), User.Identity.GetUserName(), password.Text);
                if (result.Success) 
                {
                    Response.Redirect("~/Account/Manage?m=SetPwdSuccess");
                }
                else 
                {
                    AddErrors(result);
                }
            }
        }

        public IEnumerable<IUserLogin> GetLogins()
        {
            ILoginManager manager = new IdentityManager(new IdentityStore(new AirPortDbContext())).Logins;
            var accounts = manager.GetLogins(User.Identity.GetUserId());
            CanRemoveExternalLogins = accounts.Count() > 1;
            return accounts;
        }

        public void RemoveLogin(string loginProvider, string providerKey)
        {
            ILoginManager manager = new IdentityManager(new IdentityStore(new AirPortDbContext())).Logins;
            var result = manager.RemoveLogin(User.Identity.GetUserId(), loginProvider, providerKey);
            var msg = result.Success
                      ? "?m=RemoveLoginSuccess"
                      : String.Empty;
            Response.Redirect("~/Account/Manage" + msg);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        protected void UploadBtn_Click(object sender, EventArgs e)
        {
            if (ValidateFile())
            {
                var dbContext = new AirPortDbContext();
                using (dbContext)
                {
                    var length = UploadAvatar.PostedFile.ContentLength;
                    byte[] fileData = new byte[length + 1];

                    Stream fileStream = UploadAvatar.PostedFile.InputStream;
                    fileStream.Read(fileData, 0, length);

                    var userId = User.Identity.GetUserId();
                    var user = dbContext.Users.Find(userId);
                    user.Image = fileData;
                    this.profileImage.Src = "data:image/jpeg;base64," + Convert.ToBase64String(fileData);
                    dbContext.SaveChanges();
                    this.SuccessMessage = "Image Upload Successful!";
                    successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
                }
            }
        }

        private bool ValidateFile()
        {
            if (this.UploadAvatar.HasFile)
            {
                try
                {
                    if (this.UploadAvatar.PostedFile.ContentLength < 102400)
                    {
                        if (this.UploadAvatar.PostedFile.ContentType == "image/jpeg" ||
                            this.UploadAvatar.PostedFile.ContentType == "image/png" ||
                            this.UploadAvatar.PostedFile.ContentType == "image/gif")
                        {
                            return true;
                        }
                        else
                        {
                            this.ImageValidator.ErrorMessage = "Invalid image format - jpeg/png/gif are supported";
                            this.ImageValidator.IsValid = false;
                            this.ValidationSummary.ShowValidationErrors = true;
                            return false;
                        }
                    }
                    else
                    {
                        this.ImageValidator.ErrorMessage = "File is too big (100KB)";
                        this.ImageValidator.IsValid = false;
                        this.ValidationSummary.ShowValidationErrors = true;
                        return false;
                    }
                }
                catch (Exception ex)
                {

                    ErrorSuccessNotifier.AddErrorMessage(ex);
                    return false;
                }
              
            }
            else
            {
                this.ImageValidator.ErrorMessage = "Select image first";
                this.ImageValidator.IsValid = false;
                this.ValidationSummary.ShowValidationErrors = true;
                return false;
            }
        }
        
    }
}
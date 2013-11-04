<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="AirPortSystem.Account.Manage" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>


<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1><%: Page.Title %>.</h1>
    </hgroup>

    <div>
        <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
            <p class="text-success"><%: SuccessMessage %></p>
        </asp:PlaceHolder>
        <asp:ValidationSummary ID="ValidationSummary" runat="server"
                               ShowModelStateErrors="true" CssClass="text-error" ValidationGroup="image" />
    </div>

    <div class="row-fluid">

        <section id="passwordForm">

            <asp:PlaceHolder runat="server" ID="setPassword" Visible="false">
                <div class="span6">
                    <p>
                        You do not have a local password for this site. Add a local
                        password so you can log in without an external login.
                    </p>
                    <fieldset class="form-horizontal">
                        <legend>Set Password Form</legend>
                        <div class="control-group">
                            <asp:Label runat="server" AssociatedControlID="password" CssClass="control-label">Password</asp:Label>
                            <div class="controls">
                                <asp:TextBox runat="server" ID="password" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="password"
                                                            CssClass="text-error" ErrorMessage="The password field is required."
                                                            Display="Dynamic" ValidationGroup="SetPassword" />
                                <asp:ModelErrorMessage runat="server" ModelStateKey="NewPassword" AssociatedControlID="password"
                                                       CssClass="text-error" SetFocusOnError="true" />
                            </div>
                        </div>

                        <div class="control-group">
                            <asp:Label runat="server" AssociatedControlID="confirmPassword" CssClass="control-label">Confirm password</asp:Label>
                            <div class="controls">
                                <asp:TextBox runat="server" ID="confirmPassword" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="confirmPassword"
                                                            CssClass="text-error" Display="Dynamic" ErrorMessage="The confirm password field is required."
                                                            ValidationGroup="SetPassword" />
                                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="confirmPassword"
                                                      CssClass="text-error" Display="Dynamic" ErrorMessage="The password and confirmation password do not match."
                                                      ValidationGroup="SetPassword" />

                            </div>
                        </div>

                        <div class="form-actions no-color">
                            <asp:Button runat="server" Text="Set Password" ValidationGroup="SetPassword" OnClick="SetPassword_Click" CssClass="btn" />
                        </div>
                    </fieldset>
                </div>
            </asp:PlaceHolder>

            <asp:PlaceHolder runat="server" ID="changePasswordHolder" Visible="false">
                <div class="span5">
                    <fieldset class="form">
                        <legend>Change Password Form</legend>
                        <div class="control-group">
                            <asp:Label runat="server" ID="CurrentPasswordLabel" AssociatedControlID="CurrentPassword" CssClass="control-label">Current password</asp:Label>
                            <div class="controls">
                                <asp:TextBox runat="server" ID="CurrentPassword" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="CurrentPassword"
                                                            CssClass="text-error" ErrorMessage="The current password field is required."
                                                            ValidationGroup="ChangePassword" />
                            </div>
                        </div>
                        <div class="control-group">
                            <asp:Label runat="server" ID="NewPasswordLabel" AssociatedControlID="NewPassword" CssClass="control-label">New password</asp:Label>
                            <div class="controls">
                                <asp:TextBox runat="server" ID="NewPassword" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="NewPassword"
                                                            CssClass="text-error" ErrorMessage="The new password is required."
                                                            ValidationGroup="ChangePassword" />
                            </div>
                        </div>
                        <div class="control-group">
                            <asp:Label runat="server" ID="ConfirmNewPasswordLabel" AssociatedControlID="ConfirmNewPassword" CssClass="control-label">Confirm new password</asp:Label>
                            <div class="controls">
                                <asp:TextBox runat="server" ID="ConfirmNewPassword" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmNewPassword"
                                                            CssClass="text-error" Display="Dynamic" ErrorMessage="Confirm new password is required."
                                                            ValidationGroup="ChangePassword" />
                                <asp:CompareValidator runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword"
                                                      CssClass="text-error" Display="Dynamic" ErrorMessage="The new password and confirmation password do not match."
                                                      ValidationGroup="ChangePassword" />
                            </div>
                        </div>
                        <div class="form-actions no-color">
                            <asp:Button runat="server" Text="Change password" OnClick="ChangePassword_Click" CssClass="btn btn-primary lg"  ValidationGroup="ChangePassword" />
                        </div>
                    </fieldset>
                </div>
                <div class="span4 avatar">
                    <fieldset>
                        <legend>Upload Avatar Image</legend>
                        <asp:FileUpload ID="UploadAvatar" runat="server"  />
                        <asp:Button Text="Upload" runat="server" ID="UploadBtn" 
                                    OnClick="UploadBtn_Click" CssClass="btn btn-primary lg" />
                    </fieldset>
                </div>
                <div class="span4">
                    <img src="~/DefaultImage/default.png" id="profileImage" runat="server" />
                    <asp:CustomValidator ErrorMessage=""  ID="ImageValidator"
                                         runat="server" ValidationGroup="image" Display="None" />
                </div>
            </asp:PlaceHolder>
            
        </section>

    </div>

</asp:Content>

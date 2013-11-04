<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditBooks.aspx.cs" Inherits="SimpleWebApp.EditBooks" %>

<asp:Content ID="EditBookContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Edit Books</h1>

    <asp:GridView
        AutoGenerateColumns="false"
        ID="BooksGridView"
        PageSize="5"
        ItemType="SimpleWebApp.Models.BookDTO"
        DataKeyNames="Id"
        SelectMethod="BooksGridView_GetData"
        AllowPaging="true"
        AllowSorting="true"
        CssClass="table table-striped table-bordered table-condensed"
        runat="server">

        <Columns>
            <asp:TemplateField HeaderText="Title" SortExpression="Title">
                <ItemTemplate>
                    <%#: Item.Title.Length < 20 ? Item.Title : Item.Title.Substring(0, 20) + "..." %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Author" SortExpression="Author">
                <ItemTemplate>
                    <%#: Item.Author.Length < 20 ? Item.Author : Item.Author.Substring(0, 20) + "..." %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="ISBN" SortExpression="ISBN">
                <ItemTemplate>
                    <%#: Item.ISBN.Length < 20 ? Item.ISBN : Item.ISBN.Substring(0, 20) + "..." %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Web Site" SortExpression="WebSite">
                <ItemTemplate>
                    <%#: Item.WebSite.Length < 20 ? Item.WebSite : Item.WebSite.Substring(0, 20) + "..." %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Category" SortExpression="Category">
                <ItemTemplate>
                    <%#: Item.Category.Length < 20 ? Item.Category : Item.Category.Substring(0, 20) + "..." %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button CssClass="btn" Text="Edit" OnCommand="Edit_Command" CommandArgument="<%# Item.Id %>" runat="server" />
                    <asp:Button CssClass="btn" Text="Delete" OnCommand="Delete_Command" CommandArgument="<%# Item.Id %>" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Button CssClass="btn" OnCommand="ShowAddPannel_Command" Text="Create New" runat="server" ID="ShowAddPanelButton" />

    <asp:Panel runat="server" Visible="false" ID="AddNewBookPanel">
        <h3>Create New Book</h3>
        <div>
            <asp:Label runat="server" Text="Title:" />
            <asp:TextBox runat="server" ID="BookTitleTextBox" />
        </div>
        <div>
            <asp:Label runat="server" Text="Author(s):" />
            <asp:TextBox runat="server" ID="BookAuthorsTextBox" />
        </div>
        <div>
            <asp:Label runat="server" Text="ISBN:" />
            <asp:TextBox runat="server" ID="BookISBNTextBox" />
        </div>
        <div>
            <asp:Label runat="server" Text="Web Site:" />
            <asp:TextBox runat="server" ID="BookWebSiteTextBox" />
        </div>
        <div>
            <asp:Label runat="server" Text="Description:" />
            <asp:TextBox ID="BookDescriptionTextBox" TextMode="multiline" Columns="50" Rows="5" runat="server" />
        </div>
        <div>
            <asp:DropDownList
                ID="CategoryDropDown"
                ItemType="SimpleWebApp.Models.Category"
                runat="server">
            </asp:DropDownList>
        </div>
        <div>
            <asp:Button CssClass="btn" Text="Create" OnCommand="AddNewBook_Command" runat="server" />
            <asp:Button CssClass="btn" Text="Cancel" OnCommand="Cancel_Command" runat="server" />
        </div>
    </asp:Panel>

    <asp:FormView
        ID="EditBookFormView"
        ItemType="SimpleWebApp.Models.Book"
        DataKeyNames="Id"
        runat="server">
        <ItemTemplate>
            <h3>Edit Book</h3>

            <div>
                <asp:Label runat="server" Text="Title:" />
                <asp:TextBox ID="BookEditTitleTextBox" Text="<%# BindItem.Title %>" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label runat="server" Text="Authors:" />
                <asp:TextBox ID="BookEditAuthorsTextBox" Text="<%# BindItem.Author %>" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label runat="server" Text="ISBN:" />
                <asp:TextBox ID="BookEditISBNTextBox" Text="<%# BindItem.ISBN %>" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label runat="server" Text="Web Site:" />
                <asp:TextBox ID="BookEditWebSiteTextBox" Text="<%# BindItem.WebSite %>" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label runat="server" Text="Description:" />
                <asp:TextBox ID="BookEditDescriptionTextBox" Text="<%# BindItem.Description %>" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:DropDownList
                    ID="CategoryEditDropDown"
                    SelectMethod="CategoryDropDown_CategoryDropDown"
                    DataTextField="Name"
                    DataValueField="Id"
                    runat="server">
                </asp:DropDownList>
            </div>
            <div>
                <asp:Button CssClass="btn" OnCommand="Save_Command" Text="Edit" runat="server" />
                <asp:Button CssClass="btn" OnCommand="Cancel_Command" Text="Cancel" runat="server" />
            </div>
        </ItemTemplate>
    </asp:FormView>

    <asp:FormView
        ID="DeleteBookFormView"
        ItemType="SimpleWebApp.Models.Book"
        DataKeyNames="Id"
        runat="server">
        <ItemTemplate>
            <h3>Delete Book</h3>
            <asp:TextBox ID="DeleteNameTextBox" Text="<%#: Item.Title %>" runat="server"></asp:TextBox>
            <asp:Button CssClass="btn" OnCommand="ConfurmDelete_Command" Text="Delete" runat="server" />
            <asp:Button CssClass="btn" OnCommand="Cancel_Command" Text="Cancel" runat="server" />
        </ItemTemplate>
    </asp:FormView>
</asp:Content>

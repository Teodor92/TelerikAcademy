<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SimpleWebApp._Default" ValidateRequest="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Books</h1>
    <div class="search-field">
        <asp:TextBox runat="server" ID="SearchQuery" />
        <asp:Button CssClass="btn" Text="Search" runat="server" OnCommand="Search_Command" />
    </div>
    <div class="all-books clearfix">
        <asp:Repeater
            ID="CategoriesRepeater"
            ItemType="SimpleWebApp.Models.Category"
            SelectMethod="CategoriesRepeater_GetData"
            runat="server">
            <ItemTemplate>
                <div class="book-tile">
                    <h2><%#: Item.Name %></h2>
                    <ul>
                        <asp:Repeater
                            ID="BooksRepater"
                            DataSource="<%# Item.Books %>"
                            ItemType="SimpleWebApp.Models.Book"
                            runat="server">
                            <ItemTemplate>
                                <li>
                                    <a href="BookDetails?id=<%# Item.Id %>"><%#: Item.Title %></a>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

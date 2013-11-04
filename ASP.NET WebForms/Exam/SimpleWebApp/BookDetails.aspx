<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="SimpleWebApp.BookDetails" %>
<asp:Content ID="BookDetailsContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:FormView 
        ID="BookDetailsFormView"
        ItemType="SimpleWebApp.Models.Book"
        runat="server">
        <ItemTemplate>
            <header>
                <h1>Book Details</h1>
                <span><%#: Item.Title %></span>
                <p>
                    <em>By <%#: Item.Author %></em>
                </p>

                <p>
                    <em><%#: string.IsNullOrWhiteSpace(Item.ISBN) ? "(none)" : Item.ISBN %></em>
                </p>

                <p>
                    <em>Web Site: <a href="<%#: string.IsNullOrWhiteSpace(Item.WebSite) ? "http://www.nooooooooooooooo.com" : Item.WebSite %>"><%#: string.IsNullOrWhiteSpace(Item.WebSite) ? "(None)" : Item.WebSite %></a></em>
                </p>
            </header>
            <section>
                <p>
                    <%#: Item.Description %>
                </p>
            </section>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>

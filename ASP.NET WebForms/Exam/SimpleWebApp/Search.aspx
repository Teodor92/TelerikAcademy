<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="SimpleWebApp.Search" ValidateRequest="false"%>

<asp:Content ID="SearchContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label runat="server" ID="QueryTitle" />
    <ul>
        <asp:Repeater
            ID="SearchResultReapter"
            ItemType="SimpleWebApp.Models.Book"
            runat="server">
            <ItemTemplate>
                <li><a href="BookDetails?id=<%# Item.Id %>"><%#: Item.Title %> by <%#: Item.Author %></a><span> (Category: <%#: Item.Category.Name %>)</span></li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</asp:Content>

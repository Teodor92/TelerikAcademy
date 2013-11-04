<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="MyTickets.aspx.cs" Inherits="AirPortSystem.Account.MyTickets" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:ListView ID="ListBoxPosts" runat="server" 
                          ItemType="AirPortSystem.Models.Log" DataKeyNames="Id" 
                          SelectMethod="ListBoxPosts_GetData">
        <LayoutTemplate>
            <h3 class="h3">Your purchases</h3>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" class="table table-striped table-bordered table-condensed">
                            <tr runat="server">
                                <th runat="server">From</th>
                                <th runat="server">To</th>
                                <th runat="server">Date of purchase</th>
                                <th runat="server">Date of flight</th>
                                <th runat="server"></th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%#: Item.Ticket.Flight.FromAirPort %></td>
                <td><%#: Item.Ticket.Flight.ToAirPort %></td>
                <td><%#: Item.DateBought %></td>
                <td><%#: Item.Ticket.Flight.FlightDate %></td>
                <td>
                            <asp:Button runat="server" ID="ButtonDetails" CommandName="Select" Text="View details" CssClass="btn" CommandArgument="<%#: Item.Id %>" OnCommand="ButtonDetails_Command"   />
                </td>
            </tr>
        </ItemTemplate>
        <EmptyDataTemplate>
            <p class="well text-error">You have no purchased tickets yet</p>
            <a class="btn btn-info" href="../../Default.aspx">Buy</a>
        </EmptyDataTemplate>
    </asp:ListView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:ListView runat="server" ID="ListViewDetails" ItemType="AirPortSystem.Models.Log" Visible="true" ViewStateMode="Disabled">
        <ItemTemplate>
                <div class="alert alert-dismissable alert-info span4">
                    <button type="button" class="close" data-dismiss="alert">×</button>
                    <ul class="list-group">
                        <li class="list-group-item">Card type: <%#: Item.CardType %></li>
                        <li class="list-group-item">Card number: <%#: Item.CardNumber %></li>
                        <li class="list-group-item">Price(EUR) <%#: Item.Ticket.Flight.Price %></li>
                    </ul>
                </div>
            <div class="clearfix"></div>
        </ItemTemplate>
    </asp:ListView>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

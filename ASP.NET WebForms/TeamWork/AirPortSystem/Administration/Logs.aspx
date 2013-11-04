<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Logs.aspx.cs" Inherits="AirPortSystem.Administration.Logs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="well">
        <h3 class="h3">Tickets sold by date.</h3>
    </div>

    <asp:GridView
        ID="TicketsByDateGridView"
        ItemType="AirPortSystem.Models.NumberOfTicketsBoughtModel"
        AutoGenerateColumns="false"
        SelectMethod="TicketsByDateGridView_GetData"
        AllowSorting="true"
        AllowPaging="true"
        PageSize="7"
        CssClass="table table-hovered table-bordered table-condensed"
        runat="server">
        <Columns>
            <asp:TemplateField HeaderText="Date" SortExpression="BoughtDate">
                <ItemTemplate>
                    <%#: Item.BoughtDate %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Number of Tickets" SortExpression="NumberOfTickets">
                <ItemTemplate>
                    <%#: Item.NumberOfTickets %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <div class="well">
                <p class="text-warning span6">Currently no sales info is available.</p>
            </div>
        </EmptyDataTemplate>
    </asp:GridView>

    <div class="well">
        <h3 class="h3">Flights by destination.</h3>
    </div>
    <asp:GridView
        ID="NumberOfFlightsToGridView"
        ItemType="AirPortSystem.Models.NumberOfFlightsToModel"
        AutoGenerateColumns="false"
        SelectMethod="NumberOfFlightsToGridView_GetData"
        AllowSorting="true"
        AllowPaging="true"
        PageSize="7"
        CssClass="table table-hovered table-bordered table-condensed"
        runat="server">
        <Columns>
            <asp:TemplateField HeaderText="Destination" SortExpression="Destination">
                <ItemTemplate>
                    <%#: Item.Destination %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Number of Flights" SortExpression="NumberOfFlights">
                <ItemTemplate>
                    <%#: Item.NumberOfFlights %>
                </ItemTemplate>

            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <div class="well">
                <p class="text-warning span6">Currently no flights are available.</p>
            </div>
        </EmptyDataTemplate>
    </asp:GridView>
</asp:Content>

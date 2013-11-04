<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AirPortSystem._Default" %>

<%@ Register TagPrefix="ajax" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="well h3 text-info">Welcome to Sphene airport.</h3>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:DropDownList runat="server"
                ID="DropDownListFromAirport"
                AutoPostBack="true"
                AppendDataBoundItems="true"
                SelectMethod="DropDownListFromAirport_GetData">
                <asp:ListItem Text="--Select start point--" Value="" />
            </asp:DropDownList>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:DropDownList runat="server"
                ID="DropDownListEndPoint"
                AutoPostBack="true"
                AppendDataBoundItems="true"
                SelectMethod="DropDownListToAirport_GetData">
                <asp:ListItem Text="--Select end point--" Value="" />
            </asp:DropDownList>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:GridView
                runat="server"
                ID="GridViewFlightsAdmin"
                ItemType="AirPortSystem.Models.Flight"
                AutoGenerateColumns="false"
                DataKeyNames="Id"
                SelectMethod="GridViewFlightsAdmin_GetData"
                AllowSorting="true"
                AllowPaging="true"
                PageSize="10"
                CssClass="table table-hovered table-bordered table-condensed">
                <Columns>

                    <asp:TemplateField HeaderText="From Airport" SortExpression="FromAirPort">
                        <ItemTemplate>
                            <%#: Item.FromAirPort %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="To airport" SortExpression="ToAirPort">
                        <ItemTemplate>
                            <%#: Item.ToAirPort %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Flight date" SortExpression="FlightDate">
                        <ItemTemplate>
                            <%#: String.Format("{0:dd-MMM-yyyy HH:mm}", Item.FlightDate) %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Available Tickets" SortExpression="AvailableTickets">
                        <ItemTemplate>
                            <%#: Item.AvailableTickets %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Price" SortExpression="Price">
                        <ItemTemplate>
                            <%#: Item.Price %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button
                                Text="Buy"
                                runat="server"
                                ID="ButtonBuyTicket"
                                CommandName="BuyTicket"
                                CommandArgument="<%# Item.Id %>"
                                OnCommand="ButtonBuyTicket_Command"
                                CssClass="btn btn-info" 
                                Enabled="<%# isButtonEnabled(Item.AvailableTickets) %>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <div class="well">
                        <p class="text-warning span6">Currently no flights are available. Please check your filters.</p>
                    </div>
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-warning" DisplayMode="SingleParagraph" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

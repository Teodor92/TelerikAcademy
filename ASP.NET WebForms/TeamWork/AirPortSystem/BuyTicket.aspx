<%@ Page Title="Buy Ticket" 
    Language="C#" 
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true" 
    CodeBehind="BuyTicket.aspx.cs" 
    Inherits="AirPortSystem.BuyTicket"
    ErrorPage="~/ErrorPage.aspx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:DetailsView 
        runat="server" ID="DetailsViewBuyTicket" 
        ItemType="AirPortSystem.Models.Flight" 
        AutoGenerateRows="false" 
        SelectMethod="DetailsViewBuyTicket_GetItem" 
        CssClass="table table-striped table-bordered table-condensed">

        <HeaderTemplate>
            Buy Ticket
        </HeaderTemplate>

        <Fields>
            
            <asp:TemplateField HeaderText="From Airport">
                <ItemTemplate>
                    <%#: Item.FromAirPort %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="To airport">
                <ItemTemplate>
                    <%#: Item.ToAirPort %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Flight date">
                <ItemTemplate>
                    <%#: String.Format("{0:dd-MMM-yyyy HH:mm}", Item.FlightDate) %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Available Tickets">
                <ItemTemplate>
                    <%#: Item.AvailableTickets %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Price">
                <ItemTemplate>
                    <asp:Label Text="<%#: Item.Price %>" runat="server" ID="LabelPrice" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Card Type">
                <ItemTemplate>
                    <asp:DropDownList runat="server" ID="CardType">
                        <asp:ListItem Text="--Select card type--" Value="" /> 
                        <asp:ListItem Text="Visa" />
                        <asp:ListItem Text="Master Card" />
                        <asp:ListItem Text="American Express" />
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Card Number">
                <ItemTemplate>
                    <asp:TextBox runat="server" ID="TextBoxCardNumber" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxCardNumber" CssClass="text-warning" Display="Dynamic" Text="Please enter credit card number">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server" ValidationExpression="^4[0-9]{12}(?:[0-9]{3})?$" ControlToValidate="TextBoxCardNumber" CssClass="text-warning" Display="Dynamic" Text="The card number is not valid">
                    </asp:RegularExpressionValidator>
                </ItemTemplate>
            </asp:TemplateField>
        </Fields>

    </asp:DetailsView>

    <asp:Button Text="Buy" runat="server" ID="ButtonBuyTicket" OnClick="ButtonBuyTicket_Click" CssClass="btn btn-primary" />

</asp:Content>

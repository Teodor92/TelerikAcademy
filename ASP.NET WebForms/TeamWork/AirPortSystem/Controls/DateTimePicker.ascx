<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DateTimePicker.ascx.cs" Inherits="AirPortSystem.DateTimePicker" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:TextBox runat="server" CssClass="input-sm span2" ID="TextBoxFlightDate" />
<asp:TextBox ID="TextBoxFlightTime" CssClass="input-sm span2" runat="server"></asp:TextBox>
<ajaxToolkit:CalendarExtender
    ID="CalendarExtender1" runat="server"
    Enabled="true"
    TargetControlID="TextBoxFlightDate"
    Format="dd-MM-yyyy">
</ajaxToolkit:CalendarExtender>
<ajaxToolkit:MaskedEditExtender
    ID="MaskedEditExtenderFlightTime" runat="server"
    Enabled="True"
    TargetControlID="TextBoxFlightTime"
    MaskType="Time"
    AutoCompleteValue="09:00"
    Mask="99:99">
</ajaxToolkit:MaskedEditExtender>
<ajaxToolkit:MaskedEditValidator
    ID="MaskedEditValidatorFlightTime"
    runat="server"
    ControlExtender="MaskedEditExtenderFlightTime"
    ControlToValidate="TextBoxFlightTime"
    IsValidEmpty="True"
    EmptyValueMessage="Time is required"
    InvalidValueMessage="Time is invalid"
    Display="Dynamic"
    TooltipMessage="Enter time"
    EmptyValueBlurredText="Required"
    InvalidValueBlurredMessage="Check time"
    CssClass="text-error" />
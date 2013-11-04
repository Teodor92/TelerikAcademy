<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="AirPortSystem.ErrorPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tbody>
            <tr>
                <td valign="top" align="left" id="tableProps">
                    <img width="25" height="33" src="http://www.larknews.com/images/pageerror.gif" id="pagerrorImg"></td>
                <td width="360" valign="middle" align="left" id="tableProps2">
                    <h1 style="color: black; font: 13pt/15pt verdana" id="errortype"><span id="errorText">The page cannot be found</span></h1>
                </td>
            </tr>
            <tr>
                <td width="400" colspan="2" id="tablePropsWidth"><font style="color: black; font: 8pt/11pt verdana">Possible causes:</font></td>
            </tr>
            <tr>
                <td width="400" colspan="2" id="tablePropsWidth2"><font style="color: black; font: 8pt/11pt verdana" id="LID1"> 
      <hr noshade="" color="#C0C0C0">
      <ul>
        <li id="list1"><span class="infotext"><strong>Baptist explanation: </strong>There 
          must be sin in your life. Everyone else opened it fine.<br>
          </span></li>
        <li><span class="infotext"> <strong>Presbyterian explanation: </strong>It's 
          not God's will for you to open this link.<br>
          </span></li>
        <li><span class="infotext"><strong> Word of Faith explanation:</strong> 
          You lack the faith to open this link. Your negative words have prevented 
          you from realizing this link's fulfillment.<br>
          </span></li>
        <li><span class="infotext"><strong>Charismatic explanation: </strong>Thou 
          art loosed! Be commanded to OPEN!<br>
          </span></li>
        <li><span class="infotext"><strong>Unitarian explanation:</strong> All 
          links are equal, so if this link doesn't work for you, feel free to 
          experiment with other links that might bring you joy and fulfillment.<br>
          </span></li>
        <li><span class="infotext"><strong>Buddhist explanation:</strong> .........................<br>
          </span></li>
        <li><span class="infotext"><strong>Episcopalian explanation:</strong> 
          Are you saying you have something against homosexuals?<br>
          </span></li>
        <li><span class="infotext"><strong>Christian Science explanation: </strong>There 
          really is no link.<br>
          </span></li>
        <li><span class="infotext"><strong>Atheist explanation: </strong>The only 
          reason you think this link exists is because you needed to invent it.<br>
          </span></li>
        <li><span class="infotext"><strong>Church counselor's explanation:</strong> 
          And what did you feel when the link would not open?</span></li>
      </ul>
      <p><br>
      </p>
      <h2 style="font:8pt/11pt verdana; color:black" id="ietext"><img width="16" height="16" align="top" src="http://www.larknews.com/images/search.gif"> 
        HTTP 404 - File not found - Internet Explorer <br>
      </h2>
      </font></td>
            </tr>
        </tbody>
    </table>
</asp:Content>

<%@ Page Language="vb" AutoEventWireup="false" Inherits="calendar.instructions" CodeFile="instructions3.aspx.vb" %>

<%@ Register TagPrefix="eCommerce" TagName="Menu" Src="Menu.ascx" %>
<%@ Register TagPrefix="eCommerce" TagName="header" Src="header.ascx" %>
<%@ Register TagPrefix="eCommerce" TagName="AuthenticateUser" Src="authenticateUser.ascx" %>
<html>
<head>
    <title>Online Timeline Followback (O-TLFB)</title>
    <link href="crcStyleSheet.css" type="text/css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
</head>
<body>
    <form runat="server">
    <div id="wrap">
        <div id="main">
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr valign="top">
                    <td id="Header">
                        <eCommerce:header ID="Header1" runat="server"></eCommerce:header>
                    </td>
                </tr>
                <tr valign="top">
                    <td id="counterCell" bgcolor="#e0e0e0" height="10">
                    </td>
                </tr>
                <tr valign="top">
                    <td id="Content" width="100%">
                        <eCommerce:AuthenticateUser ID="AuthenticateUser1" runat="server"></eCommerce:AuthenticateUser>
                        &nbsp;<br />
                        <asp:Label ID="LabelSurveyInstructions" runat="server" CssClass="homeHead">Instructions: 
                            Filling Out the Calendar</asp:Label>
                        <asp:Panel ID="Panel3" runat="server" Height="165px" Width="100%" Visible="False">
                            <br />
                            <p class="instrSubHdr">
                                Helpful Hints
                            </p>
                            <ul class="indent">
                                <li><b>Start from yesterday</b> and work backwards through time</li>
                                <li>The following can be used to help you recall your drinking and smoking each day:
                                    <ul class="indent">
                                        <li style="list-style-type:circle;"><b>Appointment book to help recall events</b> where drinking and smoking are increased
                                            or decreased (e.g., holidays, birthdays, illnesses, and stressful events) </li>
                                        <li style="list-style-type:circle;"><b>Regular drinking or smoking patterns </b>(ex. You may have regular weekend/weekday
                                            smoking or drinking patterns, smoke or drink more on trips than while at home, drink
                                            and smoke during Monday Night Football, etc.)</li>
                                    </ul>
                                </li>
                            </ul>
                        </asp:Panel>
                        <br />
                    </td>
                </tr>
            </table>
            <p>
                <asp:Button ID="Button1ProceedToCalendar" runat="server" Text="Continue"></asp:Button>
            </p>
        </div>
    </div>
    <div id="footer">
        <span class="footerText">&copy;Sobell, L.C. & Sobell, M.B., 2008</span>
    </div>
    </form>
</body>
</html>

<%@ Page Language="vb" AutoEventWireup="false" Inherits="calendar.instructions" CodeFile="instructions.aspx.vb" %>

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
                        <asp:Panel ID="Panel1" runat="server" Height="135px" Width="100%">
                            <p>
                                You&#39;re going to be presented with a calendar of the past month and asked to
                                fill in:
                            </p>
                            <ol id="olInstr1">
                                <li>Personal events to help with your recall</li>
                                <li>Your alcohol and cigarette use for each day</li>
                            </ol>
                            <p>
                                Filling out the calendar is not hard, but it is <b>VERY IMPORTANT</b> that you follow
                                the instructions carefully.</p>
                            <br />
                            <p>
                                Although we recognize that you won&#39;t have perfect recall, try to be as accurate
                                as possible.</p>
                        </asp:Panel>
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

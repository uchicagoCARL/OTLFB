<%@ Page Language="vb" AutoEventWireup="false" Inherits="calendar.instructions" CodeFile="instructions2.aspx.vb" %>

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
                        <br />
                        <br />
                        <p class="instrSubHdr">
                            What To Fill In</p>
                        <ul class="ulInstr2">
                            <li>The idea is to put two numbers in for <b>each day</b> on the calendar</li>
                            <li>On days that you did not drink alcohol (ALC) or smoke cigarettes (CIG), you should
                                enter a <b>'0'</b></li>
                            <li>On days that you did drink alcohol or smoke cigarettes, you should enter the number
                                of alcohol drinks consumed or cigarettes smoked</li>
                        </ul>
                        <div id="standards">
                            <p>
                                IMPORTANT: We want to record your drinking and smoking on the calendar using standard
                                drinks and cigarettes
                            </p>
                            <ul>
                                <li><b>1 Standard Drink = 12 oz beer, 1.5 oz liquor, 5 oz wine</b></li>
                                <li style="list-style-type: none;"><em>For example: If you had 6 beers, you would enter
                                    &#8216;6&#8217;; if you drank two or more different kinds of alcohol in a day, such
                                    as 2 beers and 3 glasses of wine, you would enter a &#8216;5&#8217; on that day.</em></li>
                            </ul>
                            <ul>
                                <li><b>1 Cigarette = 1 puff up to an entire cigarette</b></li>
                                <li style="list-style-type: none;"><em>For example: If you smoked 6 cigarettes, you
                                    would enter &#8216;6&#8217;; if you smoked 9 cigarettes and had a puff of a friend's
                                    cigarette, you would enter a &#8216;10&#8217; on that day.</em></li>
                            </ul>
                            <p>
                            </p>
                            <br />
                        </div>
                        <p class="instrSubHdr">
                            Your Best Estimate</p>
                        <p>
                            We realize it isn't easy to recall things with 100% accuracy.
                        </p>
                        <ul class="indent verticalSpace">
                            <li>If you are not sure whether you drank 7 or 11 drinks or whether you drank on Thursday
                                or Friday, <b>give it your best guess!</b>
                                <ul class="indent">
                                    <li>What is important is that 7 or 11 drinks is very different from 1 or 2 drinks or
                                        25 drinks. </li>
                                    <li>The goal is to get a sense of the frequency, quantity, and patterns of your drinking
                                        and smoking.</li>
                                </ul>
                            </li>
                        </ul>
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

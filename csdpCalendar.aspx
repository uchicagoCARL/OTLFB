<%@ Page Language="C#" %>

<%@ Register TagPrefix="eCommerce" TagName="AuthenticateUser" Src="authenticateUser.ascx" %>
<%@ Register TagPrefix="eCommerce" TagName="header" Src="header.ascx" %>
<%@ Register TagPrefix="eCommerce" TagName="sideInstructions" Src="sideInstructions.ascx" %>
<%@ Register TagPrefix="eCommerce" TagName="theCalendarControl" Src="theCalendarControl.ascx" %>
<html>
<head>
    <title>Online Timeline Followback (O-TLFB)</title>
    <link href="crcStyleSheet.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />

    <script type="text/javascript" language="JavaScript">
        function changeScreenSize() {
            window.close
            //window.location.href = "../calendar/csdpCalendar.aspx";   
            window.moveTo(0, 0)
            window.resizeTo(screen.availWidth, screen.availHeight)
        }
    </script>

</head>
<body onload="changeScreenSize()">
    <form runat="server">
    <div id="wrap">
        <div id="main">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr valign="top">
                    <td id="Header" colspan="2">
                        <eCommerce:header runat="server" ID="Header1" />
                    </td>
                </tr>
                <tr valign="top">
                    <td id="counterCell" colspan="2" height="10" bgcolor="#e0e0e0">
                    </td>
                </tr>
                <tr valign="top">
                    <td width="650" id="Content" colspan="2">
                        &nbsp;&nbsp;&nbsp;
                        <eCommerce:AuthenticateUser runat="server" ID="AuthenticateUser1" />
                    </td>
                </tr>
                <tr valign="top">
                    <td align="center" class="style1">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<eCommerce:theCalendarControl
                            ID="theCalendarControl" runat="server"></eCommerce:theCalendarControl>
                    </td>
                    <td align="left">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<eCommerce:sideInstructions ID="sideInstruction"
                            runat="server"></eCommerce:sideInstructions>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="footer">
        <span class="footerText">&copy;Sobell, L.C. & Sobell, M.B., 2008</span>
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" %>

<%@ Register TagPrefix="eCommerce" TagName="Menu" Src="Menu.ascx" %>
<%@ Register TagPrefix="eCommerce" TagName="header" Src="header.ascx" %>
<%@ Register TagPrefix="eCommerce" TagName="AuthenticateUser" Src="authenticateUser.ascx" %>
<%@ Register TagPrefix="eCommerce" TagName="personalize" Src="personal.ascx" %>
<%@ Register TagPrefix="eCommerce" TagName="eventInstructions" Src="eventInstructions.ascx" %>
<html>
<head>
    <title>Online Timeline Followback (O-TLFB)</title>
    <link href="crcStyleSheet.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />

    <script type="text/javascript">
        function YNconfirm() {
            if (confirm("Do you agree - Yes (OK) or No (Cancel)")) {
                alert("You agree")
                document.getElementById('agreeinfo').value = 'Yes';
            } else {
                alert("You do not agree")
                document.getElementById('agreeinfo').value = 'No';
            };
        } 
    </script>

</head>
<body>
    <form id="Form1" runat="server">
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
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<eCommerce:personalize ID="theCalendarControl"
                            runat="server"></eCommerce:personalize>
                    </td>
                    <td align="left">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<eCommerce:eventInstructions ID="eventInstructions"
                            runat="server"></eCommerce:eventInstructions>
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

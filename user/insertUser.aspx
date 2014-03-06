<%@ Register TagPrefix="eCommerce" TagName="AuthenticateUser" Src="~/authenticateUser.ascx" %>
<%@ Register TagPrefix="eCommerce" TagName="Content" Src="~/user/cbChargeCode.ascx" %>
<%@ Register TagPrefix="eCommerce" TagName="header" Src="~/header.ascx" %>
<%@ Register TagPrefix="eCommerce" TagName="Menu" Src="~/Menu.ascx" %>
<html>
<head>
    <title>Online Timeline Followback (O-TLFB)</title>
    <link href="../crcStyleSheet.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
</head>
<body>
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
                    <td width="150" align="left" id="Menu">
                        <eCommerce:Menu runat="server" ID="Menu1" />
                        <br />
                        <img src="../images/white1x1pix.gif" hspace="100" align="left" width="1" height="1" />
                    </td>
                    <td width="80%" id="Content">
                        <p>
                            <eCommerce:AuthenticateUser runat="server" ID="Content1" />
                            <br />
                            <p>
                                <eCommerce:Content runat="server" ID="Content2" />
                            </p>
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

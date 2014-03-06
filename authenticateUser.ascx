<%@ Control Language="vb" AutoEventWireup="false" Inherits="calendar.authenticateUser" CodeFile="authenticateUser.ascx.vb" %>
<link href="crcStyleSheet.css" rel="stylesheet" type="text/css">
	<table width="100%" border="0" cellspacing="0" cellpadding="0">
		<tr>
			<td>
				<span>
					<asp:Label id="welcomeMessage" runat="server" CssClass="homeHead"></asp:Label>
				</span><BR>
			</td>
			<td>
				<asp:HyperLink id="HyperLink1" runat="server" NavigateUrl="~/login/logout.aspx">Logout</asp:HyperLink><BR>
				<asp:HyperLink id="HyperLinkAdmin" runat="server" Enabled="False" Visible="False" NavigateUrl="~/admin.aspx">Admin Page</asp:HyperLink></td>
		</tr>
	</table>

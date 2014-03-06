<%@ Page Language="vb" AutoEventWireup="false" Inherits="calendar.confirmSave" CodeFile="confirmSave.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
	<head>
		<title>confirmSave</title>
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:Label id="Label1" style="Z-INDEX: 101; LEFT: 107px; POSITION: absolute; TOP: 62px" runat="server">Are you ready to save the calendar?</asp:Label>
			<asp:Button id="ButtonYes" style="Z-INDEX: 102; LEFT: 137px; POSITION: absolute; TOP: 100px" runat="server" Text="Yes"></asp:Button>
			<asp:Button id="ButtonNo" style="Z-INDEX: 103; LEFT: 194px; POSITION: absolute; TOP: 101px" runat="server" Text="No"></asp:Button></form>
	</body>
</html>

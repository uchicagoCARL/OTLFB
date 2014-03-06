<%@ Register TagPrefix="eCommerce" TagName="sideInstructions" Src="sideInstructions.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Inherits="calendar.theCalendar" CodeFile="theCalendar.aspx.vb" %>
<%@ Register TagPrefix="eCommerce" TagName="Menu" Src="Menu.ascx" %>
<%@ Register TagPrefix="eCommerce" TagName="header" Src="header.ascx" %>
<%@ Register TagPrefix="eCommerce" TagName="AuthenticateUser" Src="authenticateUser.ascx" %>
<%@ Register TagPrefix="eCommerce" TagName="theCalendarControl" Src="theCalendarControl.ascx" %>
<html>
	<head>
		<title>Online Timeline Followback (O-TLFB)</title>
		<script type="text/javascript">
<!--
function confirmation() {
	var answer = confirm("Leave tizag.com?")
	if (answer){
		alert("Bye bye!")
		window.location = "http://www.google.com/";
	}
	else{
		alert("Thanks for sticking around!")
	}
}

function ConfirmationWindow()
{

var r=confirm("Press a button");
if (r==true)
  {
  document.write("You pressed OK!");
  }
else
  {
  document.write("You pressed Cancel!");
  }


}

function beg() {
var myConfirm = confirm("Sure you want to leave?");
return myConfirm
} 
//-->
		</script> 
		<link href="crcStyleSheet.css" rel="stylesheet" type="text/css">
			<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
	</head>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form runat="server">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td id="Header" colspan="2"><eCommerce:header runat="server" id="Header1" /></td>
				</tr>
				<tr valign="top">
					<td id="counterCell" colspan="2" height="10" bgcolor="#e0e0e0"></td>
				</tr>
				<tr valign="top">
					<td width="150" align="left" id="Menu">
						<eCommerce:Menu runat="server" id="Menu1" /><br/>
						<img src="images/white1x1pix.gif" hspace="100" align="left" width="1" height="1">
					</td>
					
					<td width="80%" id="Content">
						<p><eCommerce:authenticateUser runat="server" id="AuthenticateUser1" />
						</p>
						<p><eCommerce:theCalendarControl runat="server" ID="theCalendarControl1" NAME="theCalendarControl1" />
						</p>
					</td>
					</tr>
			</table>
		</form>
		 </SCRIPT>
	</body>
</html>

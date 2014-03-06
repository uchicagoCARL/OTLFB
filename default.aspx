<%@ Page Language="vb" AutoEventWireup="false" Inherits="calendar._default" CodeFile="default.aspx.vb" %>
<%@ Register TagPrefix="eCommerce" TagName="AuthenticateUser" Src="~/authenticateUser.ascx" %>
<%@ Register TagPrefix="eCommerce" TagName="Menu" Src="~/Menu.ascx" %>
<%@ Register TagPrefix="eCommerce" TagName="header" Src="~/header.ascx" %>
<%@ Register TagPrefix="eCommerce" TagName="Content" Src="~/calendarControl.ascx" %>
<html>
	<head>
		<title>Online Timeline Followback (O-TLFB)</title> <LINK href="crcStyleSheet.css" type="text/css" rel="stylesheet">
			<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
	    <style type="text/css">
            .style3
            {
                font-size: small;
            }
            .style8
            {
                font-family: Arial, Helvetica, sans-serif;
                font-weight: bold;
                font-size: small;
            }
            .style10
            {
                font-family: Arial, Helvetica, sans-serif;
                font-weight: bold;
                font-size: medium;
            }
            .style11
            {
                font-family: Arial, Helvetica, sans-serif;
                font-size: medium;
            }
            .style12
            {
                font-family: Arial, Helvetica, sans-serif;
            }
            .style13
            {
                font-family: Arial, Helvetica, sans-serif;
                font-size: small;
            }
            .style14
            {
                font-family: Arial, Helvetica, sans-serif;
                font-weight: bold;
            }
        </style>
        
	    </head>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
		<form runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr vAlign="top">
					<td id="Header" colSpan="2"><ecommerce:header id="Header1" runat="server"></ecommerce:header></td>
				</tr>
				<tr vAlign="top">
					<td id="counterCell" bgColor="#e0e0e0" colSpan="2" height="10"></td>
				</tr>
				<tr vAlign="top">
					
					<td id="Content" width="100%">
						<P><ecommerce:authenticateuser id="Content2" runat="server"></ecommerce:authenticateuser>
                            <b><BR>
							<BR>
							<BR>
							</b><span class="style8">This is the Calendar Survey for the Clinical Addictions Research Laboratory study. </span>
                            <span class="style3">
							<BR class="style12">
						    </span>
						</P>
						<span class="style13">To help us evaluate your drinking and smoking patterns, we need to get an idea 
							about the specific days during the last month that you drank alcohol and smoked 
							cigarettes. To do this, we would like you to fill out a calendar.
							</st1:span>
							</span>
						<span class="style3">
							<span class="style12">
							<BR>
							<br/>
							Before we begin, please answer the following preliminary questions:</span>
                        <span class="style12">
                        </st1:span>
                        </span>
                       <br class="style11">
						
						<span class="style3">
						
						<br/>
                         </span><span class="style10">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
                        <span class="style12"><b>1)&nbsp;  Have you consumed any alcohol (even a sip) over the last 5 weeks?</st1:span></b></span><span class="style10">&nbsp; 
                            <asp:RadioButtonList ID="RadioButtonListAlcohol" runat="server" 
                            Font-Names="Arial" Font-Size="16" Height="50px" style="margin-left: 67px" 
                            Width="111px">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                            </asp:RadioButtonList>
                            <BR>
                            <span class="style10">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span class="style14"> 2)&nbsp; Have 
                        you smoked any cigarettes (even a puff) over the last 5 weeks?</span><span class="style10">
                            <asp:RadioButtonList ID="RadioButtonListCig" runat="server" 
                            Font-Names="Arial" Font-Size="16" Height="50px" style="margin-left: 71px" 
                            Width="158px">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                            </asp:RadioButtonList>
						<br />
						<BR>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:Button id="ButtonAlcohol" runat="server" Text="Continue"></asp:Button>
							<BR>
						
						
					</td>
					</tr>
			</table>
		</form>
		
	</body>
</html>

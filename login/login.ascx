<%@ Control Language="vb" AutoEventWireup="false" Inherits="calendar.cbLogin" CodeFile="login.ascx.vb" %>
<TABLE id="Table1" width="300" bgColor="#990000" border="0">
	<TR>
		<TD vAlign="top"><STRONG><FONT color="#ffffff">Login in</FONT></STRONG></TD>
	</TR>
	<TR>
		<TD vAlign="top">
			<TABLE id="Table2" width="100%" bgColor="#ffffff">
				<TR>
					<TD><STRONG>User login ID:</STRONG></TD>
					<TD><STRONG><asp:textbox id="txtUserName" runat="server"></asp:textbox></STRONG></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD><STRONG>Password:</STRONG></TD>
					<TD><STRONG><asp:textbox id="txtPassword" runat="server" TextMode="Password"></asp:textbox></STRONG></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD><STRONG>&nbsp;</STRONG></TD>
					<TD><STRONG>&nbsp;
							<asp:checkbox id="rememberLogin" runat="server" Text="Remember Login"></asp:checkbox></STRONG></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>
						<CENTER><asp:button id="lblLogin" runat="server" Text="Login"></asp:button></CENTER>
					</TD>
					<TD><asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></TD>
					<TD></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</TABLE>

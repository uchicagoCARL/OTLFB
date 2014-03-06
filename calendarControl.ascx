<%@ Reference Page="~/theCalendar.aspx" %>
<%@ Control Language="vb" AutoEventWireup="false" Inherits="calendar.calendarControl" CodeFile="calendarControl.ascx.vb" %>
<P><asp:panel id="PanelEdit" runat="server" Height="78px" Width="788px" Visible="False" Enabled="False"><BR>
		<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" border="0">
			<TR>
				<TD vAlign="top">
					<ASP:DATALIST id="DATALIST1" runat="server" RepeatDirection="Horizontal" RepeatColumns="2">
						<ItemTemplate>
							<div style="padding:15,15,15,15;font-size:10pt;font-family:Verdana">
								<div style="font:12pt verdana;color:darkred">
									<i><b><a href='<%# DataBinder.Eval(Container.DataItem, "eventID", "default.aspx?eventID={0}") %>' >
												Edit
												<%# DataBinder.Eval(Container.DataItem, "eventID") %></i></a> </b>
								</div>
								<br/>
								<b>ID: </b>
								<%# DataBinder.Eval(Container.DataItem, "eventID") %>
								<br/>
								<b>Event: </b>
								<%# DataBinder.Eval(Container.DataItem, "eventText") %>
								<br/>
								<b>Date: </b>
								<%# DataBinder.Eval(Container.DataItem, "eventDate") %>
							</div>
						</ItemTemplate>
					</ASP:DATALIST></TD>
				<TD vAlign="top">
					<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="100%" border="0">
						<TR>
							<TD style="WIDTH: 100%" colSpan="2"><STRONG>Please enter the number of drink and smoke 
									for the following date:<BR>
								</STRONG>
							</TD>
						</TR>
						<TR>
							<TD style="WIDTH: 100%" colSpan="2"><STRONG><BR>
								</STRONG>
							</TD>
						</TR>
						<TR>
							<TD style="FONT-WEIGHT: bold; WIDTH: 74px" width="74" height="23">
								<DIV align="right">Date:
								</DIV>
							</TD>
							<TD width="500">
								<asp:label id="LabelDate" runat="server"></asp:label></TD>
						</TR>
						<TR>
							<TD style="FONT-WEIGHT: bold; WIDTH: 74px; HEIGHT: 23px">
								<DIV align="right"># Alcohol:</DIV>
							</TD>
							<TD style="HEIGHT: 23px">
								<asp:textbox id="TextboxDrink" Width="156px" Height="20px" runat="server"></asp:textbox>
								<asp:ImageButton id="ImageButton1" runat="server" ToolTip="Click to get instructions on how to complete the calendar" ImageUrl="images/helpButton.jpg"></asp:ImageButton>
								<asp:rangevalidator id="Rangevalidator4" runat="server" ErrorMessage="Alcohols must be between 0 and 30" ControlToValidate="TextboxDrink" MinimumValue="0" MaximumValue="30" Type="Double"></asp:rangevalidator></TD>
						</TR>
						<TR>
							<TD style="FONT-WEIGHT: bold; WIDTH: 74px; HEIGHT: 23px">
								<DIV align="right"># Cigarett:</DIV>
							</TD>
							<TD style="HEIGHT: 23px">
								<asp:textbox id="TextboxSmoke" runat="server"></asp:textbox>
								<asp:rangevalidator id="Rangevalidator3" runat="server" ErrorMessage="Cigarettes must be between 0 and 50" ControlToValidate="TextBoxSmoke" MinimumValue="0" MaximumValue="50" Type="Double" Display="Dynamic"></asp:rangevalidator></TD>
						</TR>
						<TR>
							<TD style="FONT-WEIGHT: bold; WIDTH: 74px">
								<DIV align="right">Other comments:</DIV>
							</TD>
							<TD>
								<asp:textbox id="TextboxEvent" Width="383px" Height="84px" runat="server" TextMode="MultiLine"></asp:textbox></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 74px"></TD>
							<TD>
								<asp:Button id="ButtonSubmit" runat="server" Text="Save"></asp:Button>&nbsp;
								<asp:Button id="ButtonCancel" runat="server" Text="Cancel"></asp:Button>&nbsp;
							</TD>
						</TR>
					</TABLE>
					<asp:label id="Label3" runat="server"></asp:label>
					<asp:label id="Label4" runat="server"></asp:label></TD>
			</TR>
		</TABLE>
	</asp:panel><BR>
</P>
<P style="FONT-WEIGHT: bold; BACKGROUND-COLOR: transparent">
	Please&nbsp;choose a date in
	<asp:label id="Label1" runat="server" BackColor="PaleVioletRed"> pink color     </asp:label>&nbsp;then 
	click on the
	<asp:Label id="Label2" runat="server" BackColor="PaleVioletRed" Font-Underline="True">underline date (1, 2...)</asp:Label>&nbsp;to 
	enter the number of&nbsp;alcohol&nbsp;and/or&nbsp;cigarette 
	consumption&nbsp;for that day.</P>
<TABLE id="Table1" height="180" cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
	<TR>
		<TD vAlign="top"><asp:calendar id="Calendar1" Height="150px" Width="95%" BackColor="White" OnDayRender="CalendarDRender" BorderColor="Black" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" NextPrevFormat="ShortMonth" BorderStyle="Solid" CellSpacing="1" DayHeaderStyle-Font-Name="Verdana" TodayDayStyle-ForeColor="Black" DayStyle-BorderWidth="1" DayStyle-BorderStyle="Solid" OtherMonthDayStyle-ForeColor="#C0C0C0" SelectedDayStyle-ForeColor="#000000" SelectedDayStyle-BackColor="#faebd7" Runat="server" TitleStyle-Font-Size="12" TitleStyle-Font-Name="Verdana" TitleStyle-Font-Bold="False" DayStyle-Font-Size="12" DayStyle-Font-Name="Arial" DayStyle-verticalalign="Top" DayStyle-HorizontalAlign="Left" DayStyle-Width="75" DayStyle-Height="100">
				<TodayDayStyle ForeColor="White" BackColor="#999999"></TodayDayStyle>
				<DayStyle Font-Size="12pt" Font-Names="Arial" HorizontalAlign="Left" Height="50px" BorderWidth="1px" BorderStyle="Solid" Width="75px" VerticalAlign="Top" BackColor="#CCCCCC"></DayStyle>
				<NextPrevStyle Font-Size="8pt" Font-Bold="True" ForeColor="White"></NextPrevStyle>
				<DayHeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Height="8pt" ForeColor="#333333"></DayHeaderStyle>
				<SelectedDayStyle ForeColor="White" BackColor="#333399"></SelectedDayStyle>
				<TitleStyle Font-Size="12pt" Font-Names="Verdana" Font-Bold="True" Height="12pt" ForeColor="White" BackColor="#333399"></TitleStyle>
				<OtherMonthDayStyle ForeColor="#999999"></OtherMonthDayStyle>
			</asp:calendar></TD>
		<TD vAlign="top"><asp:calendar id="Calendar2" Height="150px" Width="95%" BackColor="White" OnDayRender="CalendarDRender" BorderColor="Black" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" NextPrevFormat="ShortMonth" BorderStyle="Solid" CellSpacing="1" DayHeaderStyle-Font-Name="Verdana" TodayDayStyle-ForeColor="Black" DayStyle-BorderWidth="1" DayStyle-BorderStyle="Solid" OtherMonthDayStyle-ForeColor="#C0C0C0" SelectedDayStyle-ForeColor="#000000" SelectedDayStyle-BackColor="#faebd7" Runat="server" TitleStyle-Font-Size="12" TitleStyle-Font-Name="Verdana" TitleStyle-Font-Bold="False" DayStyle-Font-Size="12" DayStyle-Font-Name="Arial" DayStyle-verticalalign="Top" DayStyle-HorizontalAlign="Left" DayStyle-Width="75" DayStyle-Height="100" Visible="False">
				<TodayDayStyle ForeColor="White" BackColor="#999999"></TodayDayStyle>
				<DayStyle Font-Size="12pt" Font-Names="Arial" HorizontalAlign="Left" Height="50px" BorderWidth="1px" BorderStyle="Solid" Width="75px" VerticalAlign="Top" BackColor="#CCCCCC"></DayStyle>
				<NextPrevStyle Font-Size="8pt" Font-Bold="True" ForeColor="White"></NextPrevStyle>
				<DayHeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Height="8pt" ForeColor="#333333"></DayHeaderStyle>
				<SelectedDayStyle ForeColor="White" BackColor="#333399"></SelectedDayStyle>
				<TitleStyle Font-Size="12pt" Font-Names="Verdana" Font-Bold="True" Height="12pt" ForeColor="White" BackColor="#333399"></TitleStyle>
				<OtherMonthDayStyle ForeColor="#999999"></OtherMonthDayStyle>
			</asp:calendar></TD>
	</TR>
</TABLE>
<BR>
<BR>
<BR>

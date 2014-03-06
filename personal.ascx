<%@ Control Language="VB" AutoEventWireup="false" CodeFile="personal.ascx.vb" Inherits="calendar.personal" %>
<style type="text/css">


body        {font-family:Verdana, Arial, Helvetica, sans-serif; font-size:8pt; color="#000000"; margin:0px; background-color:#F9F9F9}

.HomeHead
{
    color: #999966;
    font-family: Verdana, Arial;
    font-size: 20px;
    font-weight: bold;
    HEIGHT: 35px;
        text-align: left;
    }



</style>
<asp:panel id="PanelCalendar" Height="375px" Width="650px" runat="server" 
    HorizontalAlign="Center">
		<asp:Label ID="LabelSurveyInstructions" runat="server" CssClass="homeHead" 
            Width="550px">Event Calendar</asp:Label>
		<asp:Table id="TableCalendar" HorizontalAlign="Center" runat="server" 
            Width="550px" Height="400px" BorderColor="Maroon" BorderWidth="1px" 
            CellSpacing="0" CellPadding="0" BorderStyle="Solid" Font-Name="Arial" 
            Font-Size="11" GridLines="Both">
			<asp:TableRow BorderColor="Maroon" BorderStyle="Solid" ForeColor="White" ID="Row0" BackColor="Maroon" Height="20px" Font-Bold="True">
				<asp:TableCell Text="Sunday"></asp:TableCell>
				<asp:TableCell Text="Monday"></asp:TableCell>
				<asp:TableCell Text="Tuesday"></asp:TableCell>
				<asp:TableCell Text="Wednesday"></asp:TableCell>
				<asp:TableCell Text="Thursday"></asp:TableCell>
				<asp:TableCell Text="Friday"></asp:TableCell>
				<asp:TableCell Text="Saturday"></asp:TableCell>
			</asp:TableRow>
			<asp:TableRow ID="Row1">
				<asp:TableCell></asp:TableCell>
				<asp:TableCell></asp:TableCell>
				<asp:TableCell></asp:TableCell>
				<asp:TableCell></asp:TableCell>
				<asp:TableCell></asp:TableCell>
				<asp:TableCell></asp:TableCell>
				<asp:TableCell></asp:TableCell>
			</asp:TableRow>
			<asp:TableRow ID="Row2">
				<asp:TableCell></asp:TableCell>
				<asp:TableCell></asp:TableCell>
				<asp:TableCell></asp:TableCell>
				<asp:TableCell></asp:TableCell>
				<asp:TableCell></asp:TableCell>
				<asp:TableCell></asp:TableCell>
				<asp:TableCell></asp:TableCell>
			</asp:TableRow>
			<asp:TableRow ID="Row3">
				<asp:TableCell></asp:TableCell>
				<asp:TableCell></asp:TableCell>
				<asp:TableCell></asp:TableCell>
				<asp:TableCell></asp:TableCell>
				<asp:TableCell></asp:TableCell>
				<asp:TableCell></asp:TableCell>
				<asp:TableCell></asp:TableCell>
			</asp:TableRow>
			<asp:TableRow ID="Row4">
				<asp:TableCell></asp:TableCell>
				<asp:TableCell></asp:TableCell>
				<asp:TableCell></asp:TableCell>
				<asp:TableCell></asp:TableCell>
				<asp:TableCell></asp:TableCell>
				<asp:TableCell></asp:TableCell>
				<asp:TableCell></asp:TableCell>
			</asp:TableRow>
			<asp:TableRow ID="Row5">
				<asp:TableCell></asp:TableCell>
				<asp:TableCell></asp:TableCell>
				<asp:TableCell></asp:TableCell>
				<asp:TableCell></asp:TableCell>
				<asp:TableCell></asp:TableCell>
				<asp:TableCell></asp:TableCell>
				<asp:TableCell></asp:TableCell>
			</asp:TableRow>
			<asp:TableRow ID="Row6">
				<asp:TableCell></asp:TableCell>
				<asp:TableCell></asp:TableCell>
				<asp:TableCell></asp:TableCell>
				<asp:TableCell></asp:TableCell>
				<asp:TableCell></asp:TableCell>
				<asp:TableCell></asp:TableCell>
				<asp:TableCell></asp:TableCell>
			</asp:TableRow>
		</asp:Table>
		<BR>
		<BR>
		<asp:imagebutton id="ImageButton1" runat="server" ImageUrl="images/helpButton.jpg" ToolTip="Click to get instructions on how to complete the calendar" AlternateText="Help/Instructions" Visible="False"></asp:imagebutton>
		<BR>
		<asp:button id="Button1" runat="server" Text="Submit Responses"></asp:button>
		<BR>
		<BR>
		<asp:label id="Label4" runat="server" Font-Bold="True" ForeColor="Red"></asp:label>
	</asp:panel></P>
<P>&nbsp;</P>
<P>&nbsp;</P>
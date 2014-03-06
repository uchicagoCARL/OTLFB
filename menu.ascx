<%@ Control Language="vb" AutoEventWireup="false" Inherits="calendar.menu" CodeFile="menu.ascx.vb" %>
<br/>
<asp:datalist id="category" OnItemCommand="GetCategory" runat="server" SelectedItemStyle-BackColor="#0033cc" CellPadding="3" Width="214px" Height="30px" BorderColor="#E7E7FF" BorderStyle="None" BackColor="White" GridLines="Horizontal" BorderWidth="1px">
	<SelectedItemStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#738A9C"></SelectedItemStyle>
	<SelectedItemTemplate>
		<asp:LinkButton cssclass="MenuSelected" CausesValidation=False Id="ItemType2" Runat="server" text='<%# Container.dataItem("operation") %>' CommandName='<%# Container.DataItem("operationLink") %>'>
		</asp:LinkButton>
	</SelectedItemTemplate>
	<AlternatingItemStyle BackColor="#F7F7F7"></AlternatingItemStyle>
	<ItemStyle ForeColor="#4A3C8C" BackColor="#E7E7FF"></ItemStyle>
	<ItemTemplate>
		<asp:linkButton cssclass="MenuUnselected" id="ItemType"  CausesValidation=False runat="server" Text= '<%# Container.DataItem("operation") %>' CommandName='<%# Container.DataItem("operationLink") %>' />
	</ItemTemplate>
	<FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
	<HeaderStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#4A3C8C"></HeaderStyle>
</asp:datalist><br/>
<br/>
<br/>

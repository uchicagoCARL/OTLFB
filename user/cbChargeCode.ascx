<%@ Control Language="vb" AutoEventWireup="false" Inherits="calendar.cbChargeCode"
    CodeFile="cbChargeCode.ascx.vb" %>
<table id="Table1" width="472" bgcolor="#990000" border="0">
    <tr>
        <td valign="top" height="20">
            <strong><font color="#ffffff">User</font></strong>
        </td>
    </tr>
    <tr>
        <td valign="top">
            <table id="Table2" width="100%" bgcolor="#ffffff">
                <tr>
                    <td width="134">
                        <strong></strong>
                    </td>
                    <td>
                        <strong></strong>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td width="134">
                        <strong>Login ID:</strong>
                    </td>
                    <td>
                        <strong>
                            <asp:TextBox ID="textBoxLoginID" runat="server"></asp:TextBox></strong>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="textBoxLoginID"
                            ErrorMessage="Required">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td width="134">
                        <strong>Password:</strong>
                    </td>
                    <td>
                        <strong>
                            <asp:TextBox ID="textboxPassword" runat="server"></asp:TextBox></strong>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="textboxPassword"
                            ErrorMessage="Required">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td width="134">
                        <strong>Reenter -Password:</strong>
                    </td>
                    <td>
                        <strong>
                            <asp:TextBox ID="textboxPassword2" runat="server"></asp:TextBox></strong>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="textboxPassword2"
                            ErrorMessage="Required">*</asp:RequiredFieldValidator><asp:CompareValidator ID="CompareValidator1"
                                runat="server" ControlToValidate="textboxPassword" ErrorMessage="Password does not match"
                                ControlToCompare="textboxPassword2"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td width="134" height="16">
                        <strong>Role:</strong>
                    </td>
                    <td height="16">
                        <strong>
                            <asp:DropDownList ID="DropDownListRole" runat="server" Width="156px">
                                <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                <asp:ListItem Value="21">Administrator</asp:ListItem>
                                <asp:ListItem Value="9">User</asp:ListItem>
                            </asp:DropDownList>
                        </strong>
                    </td>
                    <td height="16">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DropDownListRole"
                            ErrorMessage="*" InitialValue="0"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td width="134">
                        <center>
                        </center>
                    </td>
                    <td>
                        <asp:Label ID="LabelID" runat="server" Visible="False">Label</asp:Label>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td valign="top">
            <center>
                <asp:Button ID="ButtonSubmit" runat="server" Text="Submit"></asp:Button>
            </center>
        </td>
    </tr>
</table>
<div>
    <asp:Label ID="lblResult" runat="server"></asp:Label>
</div>
<br />
<asp:HyperLink ID="HyperLinkAddNewUser" runat="server" NavigateUrl="insertUser.aspx">Add User</asp:HyperLink><br />
<asp:DataGrid ID="DataGridChargeCode" runat="server" Width="463px" BorderColor="#CC9966"
    BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" AutoGenerateColumns="False"
    AllowSorting="True" DataKeyField="ID">
    <SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
    <ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
    <HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
    <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
    <Columns>
        <asp:ButtonColumn Text="Edit" HeaderText="Edit" CommandName="Edit"></asp:ButtonColumn>
        <asp:ButtonColumn Text="Delete" HeaderText="Delete" CommandName="Delete"></asp:ButtonColumn>
        <asp:BoundColumn DataField="ID" SortExpression="ID" HeaderText="ID"></asp:BoundColumn>
        <asp:BoundColumn DataField="userName" SortExpression="userName" HeaderText="Login ID">
        </asp:BoundColumn>
        <asp:BoundColumn DataField="role" SortExpression="role" HeaderText="Role"></asp:BoundColumn>
        <asp:BoundColumn DataField="startDate" SortExpression="startDate" HeaderText="Start Date"
            Visible="false"></asp:BoundColumn>
        <asp:BoundColumn DataField="endDate" SortExpression="endDate" HeaderText="End Date"
            Visible="false"></asp:BoundColumn>
    </Columns>
    <PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
</asp:DataGrid>

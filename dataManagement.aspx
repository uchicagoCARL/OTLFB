<%@ Page Language="vb" AutoEventWireup="false" Inherits="calendar.dataManagement"
    CodeFile="dataManagement.aspx.vb" %>

<%@ Register TagPrefix="eCommerce" TagName="Menu" Src="~/Menu.ascx" %>
<%@ Register TagPrefix="eCommerce" TagName="header" Src="~/header.ascx" %>
<%@ Register TagPrefix="eCommerce" TagName="AuthenticateUser" Src="~/authenticateUser.ascx" %>
<html>
<head>
    <title>Online Timeline Followback (O-TLFB)</title>
    <link href="crcStyleSheet.css" rel="stylesheet" type="text/css" />
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
                        <img src="images/white1x1pix.gif" hspace="100" align="left" width="1" height="1">
                    </td>
                    <td width="80%" id="Content">
                        <p>
                            <eCommerce:AuthenticateUser runat="server" ID="AuthenticateUser1" />
                            <br>
                            <br>
                            <asp:LinkButton ID="LinkButton1" runat="server">Click Here to Export Responses to MS Excel</asp:LinkButton><br>
                            <br>
                            <asp:LinkButton ID="LinkButton2" runat="server">Click Here to Export Listing of Current Users to MS Excel</asp:LinkButton><br>
                            <br>
                            <asp:DataGrid ID="DataGridSearch" runat="server" CellPadding="4" BackColor="White"
                                BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966" AllowCustomPaging="True"
                                DataKeyField="eventID" OnSortCommand="DataGridSearch_Sort" AutoGenerateColumns="False"
                                AllowSorting="True" PageSize="10000" OnDeleteCommand="DataGridSearch_Delete"
                                OnItemDataBound="MyDataGrid_ItemDataBound">
                                <SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
                                <ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
                                <HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
                                <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                                <Columns>
                                    <asp:BoundColumn DataField="eventId" SortExpression="eventId" ReadOnly="True" HeaderText="Auto ID">
                                        <ItemStyle Wrap="False"></ItemStyle>
                                    </asp:BoundColumn>
                                    <asp:TemplateColumn SortExpression="lname" HeaderText="Last Name">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "lname") %>'
                                                ID="Label1" NAME="Label1" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="edit_LName" Text='<%# DataBinder.Eval(Container.DataItem, "lname") %>' />
                                        </EditItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn SortExpression="fname" HeaderText="First Name">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "fname") %>'
                                                ID="Label2" NAME="Label1" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="edit_fName" Text='<%# DataBinder.Eval(Container.DataItem, "fname") %>' />
                                        </EditItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn SortExpression="userName" HeaderText="User ID">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "userName") %>'
                                                ID="Label4" NAME="Label1" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="edit_invoiceNumber" Text='<%# DataBinder.Eval(Container.DataItem, "invoiceNumber") %>' />
                                        </EditItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn SortExpression="eventDate" HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "eventDate") %>'
                                                ID="Label3" NAME="Label1" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="edit_visitDate" Text='<%# DataBinder.Eval(Container.DataItem, "eventDate") %>' />
                                        </EditItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn SortExpression="drink" HeaderText="Number of Drinks">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "drink") %>'
                                                ID="Label5" NAME="Label1" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="edit_protocolNumber" Text='<%# DataBinder.Eval(Container.DataItem, "drink") %>' />
                                        </EditItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn SortExpression="smoke" HeaderText="Number of cigs">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "smoke") %>'
                                                ID="Label6" NAME="Label1" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="edit_ChargeCode" Text='<%# DataBinder.Eval(Container.DataItem, "smoke") %>' />
                                        </EditItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn SortExpression="eventText" HeaderText="Others">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "eventText") %>'
                                                ID="Label7" NAME="Label1" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="edit_Quantity" Text='<%# DataBinder.Eval(Container.DataItem, "eventText") %>' />
                                        </EditItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:ButtonColumn Text="Delete Record" HeaderText="Delete Record" CommandName="Delete">
                                    </asp:ButtonColumn>
                                </Columns>
                                <PagerStyle HorizontalAlign="Center" ForeColor="#330099" Position="TopAndBottom"
                                    BackColor="#FFFFCC" Mode="NumericPages"></PagerStyle>
                            </asp:DataGrid><br />
                            <br />
                            <br />
                            <asp:DataGrid ID="DataGridForExport" runat="server">
                            </asp:DataGrid>
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

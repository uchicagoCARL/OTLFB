Imports System.Web.Security
Imports System.Data
Imports System.Data.SqlClient


Namespace calendar


Partial  Class cbLogin
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        'Session("userRole") = 0
        SetFocus(Me.txtUserName)
    End Sub

    Private Sub SetFocus(ByVal ctrl As Control)
        ' Define the JavaScript function for the specified control.
        Dim focusScript As String = "<script language='javascript'>" & _
          "document.getElementById('" + ctrl.ClientID & _
          "').focus();</script>"

        ' Add the JavaScript code to the page.
        Page.RegisterStartupScript("FocusScript", focusScript)
    End Sub





    Private Sub lblLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblLogin.Click
        Dim sUsername As String = txtUserName.Text.Replace("'", "''")
        Dim sPassword As String = txtPassword.Text.Replace("'", "''")
        lblMessage.Text = "login"


        Dim oCRC As New myWebServices()
        Dim customerID As String = oCRC.customerLogin(sUsername, sPassword)
        Session("customerID") = customerID
        If customerID <> "" Then
            Dim customerDetails As New CustomerDetails()

            customerDetails = oCRC.getCustomerDetail(customerID)
            ' Response.Cookies("crcUserRole").Value = customerDetails.role
            'Response.Cookies("crcPiName").Value = customerDetails.FullName
            Session("userRole") = customerDetails.role
            Session("userName") = customerDetails.UserName

            'Session("piName") = customerDetails.FullName

            ' Store the user's fullname in a cookie for personalization purposes
            Session("piName") = customerDetails.FullName
            Response.Cookies("crc_FullName").Value = customerDetails.FullName
            Response.Cookies("piDegree").Value = customerDetails.degree
            Session("currentLoginUser") = customerDetails.FullName
            Session("startDate") = customerDetails.startDate
            Session("endDate") = customerDetails.endDate
            Session("drink") = customerDetails.drink
            Session("smoke") = customerDetails.smoke

            ' Make the cookie persistent only if the user selects "persistent" login checkbox
            If rememberLogin.Checked = True Then
                Response.Cookies("crc_FullName").Expires = DateTime.Now.AddMonths(1)
            End If
            'Response.Redirect("../yahoo.com")

            ''Response.Redirect("../default.aspx")
            'FormsAuthentication.RedirectFromLoginPage(customerDetails.UserName, True)
            'FormsAuthentication.RedirectFromLoginPage(customerDetails.FullName, True)
            If (Request.QueryString("ReturnUrl") <> "") Then

                Response.Redirect(Request.QueryString("ReturnUrl"))

            Else
                '  Response.Redirect("yahoo.com")
                    'If (Session("startDate") <> "" And Session("endDate") <> "") Then
                    'Response.Redirect("/calendar/instructions.aspx")
                    ' Else
                    Response.Redirect("../default.aspx")
                    ' End If
                End If


        Else
            lblMessage.Text = "Invalid login"
        End If



    End Sub
End Class
End Namespace

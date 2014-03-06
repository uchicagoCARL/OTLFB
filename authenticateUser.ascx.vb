Namespace calendar

Partial  Class authenticateUser
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
        
        Dim sPIName As String

        If Session("customerID") <> "" Then
            'If Not Request.Cookies("crc_FullName") Is Nothing Then
            sPIName = Session("customerID")
            'welcomeMessage.Text = "Welcome " & Request.Cookies("crc_FullName").Value & " " & Request.Cookies("piDegree").Value
        End If
        If Session("userRole") = 21 Then
            Me.HyperLinkAdmin.Visible = True
            Me.HyperLinkAdmin.Enabled = True
        End If


        ' sPIName = Context.User.Identity.Name
        If sPIName <> "" And Session("userRole") <> 0 Then
                ' welcomeMessage.Text = "Welcome " & Session("userName") & " " & Request.Cookies("piDegree").Value
        Else
                Response.Redirect("~/Login/login.aspx")
        End If
    End Sub

    Private Sub ButtonLogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class

End Namespace

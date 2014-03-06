Imports System.Data.SqlClient
Imports System.Web.UI.WebControls


Namespace calendar



Partial  Class menu
    Inherits System.Web.UI.UserControl
    Dim piName As String
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
        If Not Page.IsPostBack Then
            Dim oCRC As New myWebServices()
            Dim ssql As String
            piName = Session("piName")

            If Session("customerID") <> "" And Session("userRole") <> 0 Then
                ssql = "select * from operation where role <= " & Session("userRole") & " order by id "
                oCRC.loadDataList(ssql, category)
                oCRC.Dispose()
            Else
                Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5))
                'Session("userRole") = 0



            End If


        End If

    End Sub

    Sub GetCategory(ByVal Src As Object, ByVal Args As DataListCommandEventArgs)
        Response.Redirect(Args.CommandName)
    End Sub



End Class

End Namespace

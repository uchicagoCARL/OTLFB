

Namespace calendar

Partial Class instructions
    Inherits System.Web.UI.Page


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

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
            'Put user code to initialize the page here
            If (Not Page.IsPostBack) Then

                Dim oCalendar As New myWebServices()
                Dim str As String
                str = "Select drink from investigators where userName='" & Session("userName") & "'"
                Session("alcohol") = oCalendar.getOneValue(str)

                str = "Select smoke from investigators where userName='" & Session("userName") & "'"
                Session("cig") = oCalendar.getOneValue(str)

                'If (Session("alcohol") = True And Session("cig") = True) Then

                'Me.Panel1.Visible = True
                'ElseIf (Session("alcohol") = True And Session("cig") = False) Then
                ' Me.Panel2.Visible = True
                'ElseIf (Session("alcohol") = False And Session("cig") = True) Then
                ' Me.Panel3.Visible = True
                'Else
                ' Me.Panel4.Visible = True
                '  End If

                ' Me.Panel5.Visible = True

                'e.Button1.Visible = True
                'e.Button1.Enabled = True
                Me.Panel1.Visible = True



            End If

        End Sub


    Private Sub Button1ProceedToCalendar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1ProceedToCalendar.Click

            Response.Redirect("~\instructions2.aspx")

            'Response.Redirect("..\calendar\csdpCalendar.aspx")
            'Response.Redirect("..\calendar\personalize.aspx")

        ' Me.Response.Redirect("..\calendar\myCalendar.aspx")


    End Sub
End Class

End Namespace

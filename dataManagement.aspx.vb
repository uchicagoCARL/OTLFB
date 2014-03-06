Namespace calendar

Partial Class dataManagement
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If (Not Page.IsPostBack()) Then
                'loadData()
                'bindTheGrid()

           
        End If


    End Sub
    Sub bindTheGrid()

        Dim oCalendar As New myWebServices()

        Dim myString As String
        myString = "Select eventID,lName,fName,eventDate,drink,smoke,eventText,userAutoID,userName from tempTableSearch order by userAutoID"
            'oCalendar.BindGridWithSortColumn(Me.DataGridSearch, "eventID", myString, "tempTableSearch")

    End Sub

    Sub DataGridSearch_Delete(ByVal Sender As Object, ByVal E As DataGridCommandEventArgs)

        Dim deleteStr As String = "DELETE from events where eventID = " & DataGridSearch.DataKeys(CInt(E.Item.ItemIndex))
        Dim oOutpatient As New myWebServices()
        oOutpatient.deleteRecord(deleteStr)

        're-binding the data to the search result
        loadData()
        bindTheGrid()

    End Sub


    Sub DataGridSearch_Sort(ByVal Src As Object, ByVal E As DataGridSortCommandEventArgs)
        Dim myString As String
        Dim oOutPatient As New myWebServices()

        myString = "select * from tempTableSearch"
        oOutPatient.BindGridWithSortColumn(Me.DataGridSearch, E.SortExpression, myString, "tempTableSearch")

    End Sub

    Sub MyDataGrid_ItemDataBound(ByVal Sender As Object, ByVal E As DataGridItemEventArgs)
        If (E.Item.ItemType = ListItemType.EditItem) Then
            Dim i As Integer
            For i = 0 To E.Item.Controls.Count - 1
                Try
                    If (E.Item.Controls(i).Controls(1).GetType().ToString() = "System.Web.UI.WebControls.TextBox") Then
                        Dim tb As TextBox
                        tb = E.Item.Controls(i).Controls(1)
                        tb.Text = Server.HtmlDecode(tb.Text)
                    End If
                Catch

                End Try
            Next
        End If
    End Sub



    Public Sub loadData()
        Dim oOutPatient As New myWebServices()

        '''''''''''''''''''


        Dim mySQLStr As String
        Dim ArgCount As Integer
        Dim myString As String

        Dim MySQL As String
        Dim myCriteria As String

        'MySQL = "SELECT     * INTO dbo.tempTableSearch FROM outptHp "

        MySQL = " SELECT     investigators.id AS userAutoID, investigators.lName, investigators.fName,"
        MySQL &= " investigators.userName, events.eventID, events.eventDate, "
        MySQL &= "  events.eventText, events.drink, events.smoke INTO tempTableSearch"
        MySQL &= " FROM    events LEFT OUTER JOIN "
        MySQL &= " investigators ON events.userAutoID = investigators.id"
        MySQL &= " ORDER BY events.userAutoID"


        oOutPatient.dropTable("tempTableSearch")
        oOutPatient.insertRecord(MySQL)


        '''''''''''''''''''

    End Sub



    Private Sub LinkButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButton1.Click

        loadData()

        Dim oOutPatient As New myWebServices()


        oOutPatient.loadDataGrid("select * from tempTableSearch", Me.DataGridForExport)

        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=FileName.xls")
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.Private)


        Response.ContentType = "application/vnd.ms-excel"

        Me.EnableViewState() = False




        Dim stringWrite As New System.IO.StringWriter()
        Dim htmlWrite As System.Web.UI.HtmlTextWriter = New HtmlTextWriter(stringWrite)

        Me.DataGridForExport.RenderControl(htmlWrite)
        Response.Write(stringWrite.ToString())
        Response.End()
        Me.DataGridForExport.Dispose()


    End Sub

    Private Sub LinkButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        Dim oOutPatient As New myWebServices()


        oOutPatient.loadDataGrid("select id,lName,fName,userName,smoke,drink,startDate,endDate from investigators", Me.DataGridForExport)

        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=FileName.xls")
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.Private)


        Response.ContentType = "application/vnd.ms-excel"

        Me.EnableViewState() = False




        Dim stringWrite As New System.IO.StringWriter()
        Dim htmlWrite As System.Web.UI.HtmlTextWriter = New HtmlTextWriter(stringWrite)

        Me.DataGridForExport.RenderControl(htmlWrite)
        Response.Write(stringWrite.ToString())
        Response.End()
        Me.DataGridForExport.Dispose()


    End Sub
End Class

End Namespace

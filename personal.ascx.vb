Imports System.Web.Services
Imports System.Web
Imports System.Data
Imports System.Data.SqlClient
Imports System
Imports System.Web.UI
Imports System.Web.UI.Page
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls.HtmlInputFile
Imports System.Drawing
Imports System.Web.HttpServerUtility
Imports System.Configuration
Imports System.IO
Imports System.Text
Namespace calendar
    Partial Class personal
        Inherits System.Web.UI.UserControl
        Protected WithEvents tbAlc As System.Web.UI.WebControls.TextBox



        Dim TbCigArray() As System.Web.UI.WebControls.TextBox
        Dim TbAlkArray() As System.Web.UI.WebControls.TextBox

        WithEvents tbCigAction As System.Web.UI.WebControls.TextBox
        WithEvents tbCigAction2 As System.Web.UI.WebControls.TextBox

        Dim ds As New DataSet()
        Dim myda As SqlDataAdapter

        Dim stillEmptyBox As Boolean

        Dim theConfirm As Boolean
        Dim theRow As Integer
        Dim textBoxCount As Integer
        Dim myAnswer As Boolean


        Dim alkArray

        Dim cigArray

        Dim i, j As Integer


#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            ' TextBox1 = New TextBox()
            'TextBox1.ID = "TextBox1"
            ' TextBox1.Style("Position") = "Absolute"
            ' TextBox1.Style("Top") = "25px"
            ' TextBox1.Style("Left") = "100px"
            ' Me.PanelCalendar.Controls.Add(TextBox1)



            InitializeComponent()
        End Sub

#End Region

        Private Sub addDrinkTbToCalendar(ByVal theDate As Date, ByVal TBCigArray() As TextBox, ByVal i As Integer, ByVal theColor As Integer)

            Dim labelDate As Label
            labelDate = New Label()
            Dim theString As String
            labelDate.Text = Convert.ToString(theDate.Month) & "/" & Convert.ToString(theDate.Day)

            Dim labelCig As Label
            labelCig = New Label()
            labelCig.Text = "<br/><br/> Event: "



            Dim theCells As Integer

            If (theDate.DayOfWeek = DayOfWeek.Sunday) Then
                theCells = 0

            ElseIf (theDate.DayOfWeek = DayOfWeek.Monday) Then
                theCells = 1


            ElseIf (theDate.DayOfWeek = DayOfWeek.Tuesday) Then
                theCells = 2


            ElseIf (theDate.DayOfWeek = DayOfWeek.Wednesday) Then
                theCells = 3


            ElseIf (theDate.DayOfWeek = DayOfWeek.Thursday) Then

                theCells = 4


            ElseIf (theDate.DayOfWeek = DayOfWeek.Friday) Then
                theCells = 5

            ElseIf (theDate.DayOfWeek = DayOfWeek.Saturday) Then
                theCells = 6

            End If

           

            Me.TableCalendar.Rows(theRow).Cells(theCells).Controls.AddAt(0, labelDate)
            Me.TableCalendar.Rows(theRow).Cells(theCells).Controls.AddAt(1, TBCigArray(i))

            If (theColor = 1) Then
                Me.TableCalendar.Rows(theRow).Cells(theCells).BackColor = Color.Yellow
                ' ElseIf (theColor = 2) Then
                '  Me.TableCalendar.Rows(theRow).Cells(theCells).BackColor = Color.Yellow
            Else
                Me.TableCalendar.Rows(theRow).Cells(theCells).BackColor = Color.Green
            End If

            If (theDate.DayOfWeek = DayOfWeek.Saturday) Then
                theRow += 1
            End If


        End Sub



        Private Sub loadTheCalendar()



            Dim m As Integer
            Dim n As Integer
            For m = 1 To 6
                For n = 0 To 6
                    TableCalendar.Rows(m).Cells(n).Controls.Clear()

                Next

            Next


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim myStr As String
            myStr = "Select confirmAnswer from investigators where id='" & Session("customerID") & "'"
            Dim oCal As New myWebServices()

            myAnswer = oCal.getOneValue(myStr)


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            textBoxCount = 36
            theRow = 1
            'Me.TableCalendar.Rows(1).Cells(1).Controls.Clear()



            ReDim alkArray(textBoxCount - 1, 1)
            ReDim cigArray(textBoxCount - 1, 1)
            Dim theEvent As String


            theConfirm = False
            stillEmptyBox = False
            Dim oCalendar As New myWebServices()
            Dim oUserDetail As New CustomerDetails()

            oUserDetail = oCalendar.getCustomerDetail(Session("customerID"))
            Session("startDate") = oUserDetail.startDate
            Session("endDate") = oUserDetail.endDate
            Session("drink") = oUserDetail.drink
            Session("smoke") = oUserDetail.smoke


            ' oCalendar.OpenPopUp(Me.Button1, "confirmSave.aspx", "Tips", 500, 380)


            getRecordForUser()
            'attachRecordToCalendar()


            Dim d As Integer
            Dim theDate As Date
            theDate = Convert.ToDateTime(Session("startDate")).Date.ToShortDateString


            For d = 1 To textBoxCount
                Dim theColor As Integer
                theColor = 1

             
                Dim tbCigAction As TextBox
                tbCigAction = New TextBox()
                tbCigAction.ID = theDate & "Cig"
                tbCigAction.Style("width") = 40
                'tbAlkAction.BackColor = Color.Maroon
                AddHandler tbCigAction.TextChanged, AddressOf tbCigAction_TextChanged




                Dim TBCigArray(d) As TextBox
                TBCigArray(d) = New TextBox()
                TBCigArray(d) = tbCigAction

             
                '''''''''''''''''''''''''''''''''''''''''''''''''

                Dim dr As DataRow
                If ds.Tables(0).Rows.Count <> 0 Then
                    For Each dr In ds.Tables(0).Rows

                        If Not dr("eventDate") Is DBNull.Value Then

                            If (dr("eventDate").ToString = theDate.ToString) Then
                                If (Not dr("eventText") Is DBNull.Value) Then

                                    TBCigArray(d).Text = dr("eventText")
                                    theColor = 1
                                    stillEmptyBox = True


                                End If
                                Exit For

                            End If


                        End If

                    Next
                End If



                '''''''''''''''''''''''''''''''''''''''''''''''''''''



                addDrinkTbToCalendar(theDate, TBCigArray, d, theColor)

                theDate = theDate.AddDays(1).ToShortDateString



            Next



        End Sub

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            'Utilities.CreateConfirmBox(Me.Button1, "Are you sure your responses are accurate and you are ready so submit this calendar?")

            ' Dimension the array into 2 dimensions 
            '    Dim oCRC As New myWebServices()
            '  oCRC.ASPNET_YesNoMessage("Are you sure you 've entered all your personal event?")
         
            loadTheCalendar()

            Dim oCRC As New myWebServices()
          


            If (Not Me.Page.IsPostBack) Then
         
                'CreateConfirmBox(Button1, "Are you sure you 've entered all your personal event?")
                Me.Button1.Attributes.Add("onclick", _
                      "return confirm('Are you sure you have entered all your personal events?');")

                oCRC.OpenPopUp(Me.ImageButton1, "help.aspx", "Tips", 500, 380)

                i = 0
                j = 0



            End If

       
            'oCRC.ASPNET_YesNoMessage("Are you sure you 've entered all your personal event?")

        End Sub

        Private Sub attachRecordToCalendar()

            Dim dr As DataRow
            If ds.Tables(0).Rows.Count <> 0 Then
                For Each dr In ds.Tables(0).Rows

                    If Not dr("eventDate") Is DBNull.Value Then
                        Dim dtEvent As DateTime = dr("eventDate").ToString
                        Dim i As Integer
                        Dim theDate As Date

                        theDate = Session("startDate")
                        For i = 1 To textBoxCount

                            If dtEvent = theDate.ToString Then
                                TbCigArray(i).Text = i
                                TbAlkArray(i).Text = "ddd"

                            End If
                            theDate = theDate.AddDays(1).ToShortDateString
                        Next
                    End If

                Next
            End If


        End Sub


        Private Sub getRecordForUser()

            Dim ConnectString As String = System.Configuration.ConfigurationSettings.AppSettings("ConnectionString")
            Dim MyConnection As SqlConnection = New SqlConnection(ConnectString)
            ds.Clear()
            Try
                MyConnection.Open()


                Dim queryString As String
                queryString = "Select eventID,eventDate,eventText,drink,smoke from events where userAutoID='" & Session("customerID") & "' order by eventDate"

                'queryString = "Select eventID,eventDate,eventText from events where userAutoID='38" & "' order by eventDate"

                myda = New SqlDataAdapter(queryString, MyConnection)

                myda.Fill(ds, "MyTable")


            Catch e As Exception
                Throw e

            Finally

                If MyConnection.State = ConnectionState.Open Then
                    MyConnection.Close()
                End If

            End Try
        End Sub


        Private Sub tbCigAction_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbCigAction.TextChanged

            ' Utilities.CreateConfirmBox(Me.Button1, "Are you sure you want save?")

            Dim txtBoxSender As TextBox
            Dim strTextBoxID As String

            Dim d As Integer

            txtBoxSender = CType(sender, TextBox)
            strTextBoxID = txtBoxSender.ID

            Dim theDate As Date
            theDate = Convert.ToDateTime(Session("startDate")).Date.ToShortDateString
            Dim errorInput As Boolean = False
            Me.Label4.Text = ""
            Dim oError As New myWebServices()
            Dim strMessage As String
            For d = 1 To textBoxCount

                Select Case strTextBoxID
                    Case theDate & "Alk"

                        If (IsNumeric(txtBoxSender.Text)) Then
                            If txtBoxSender.Text > 50 Then
                                strMessage = "Please enter the number of alcohol consumptions less than or equal to 50"
                                Utilities.CreateMessageAlert(Me.Page, strMessage, "strKey1")
                                Session("errorInput") = "True"
                            Else
                                Dim thestring As String
                                thestring = theDate
                                alkArray(i, 0) = thestring
                                alkArray(i, 1) = txtBoxSender.Text
                                i += 1
                            End If

                        Else
                            'oError.ASPNET_MsgBox("Please enter a number in the alcohol consumption box")
                            Session("errorInput") = "True"
                            strMessage = "Please enter a number in the alcohol consumption box"
                            Utilities.CreateMessageAlert(Me.Page, strMessage, "strKey1")
                        End If

                    Case theDate & "Cig"
                        ' If (IsNumeric(txtBoxSender.Text)) Then
                        'If txtBoxSender.Text > 30 Then
                        '  strMessage = "Please ensure the number of cigarettes consumption less than or equal 30"
                        ' Utilities.CreateMessageAlert(Me.Page, strMessage, "strKey1")
                        ' Session("errorInput") = "True"

                        'Else
                        Dim thestring As String
                        thestring = theDate
                        cigArray(j, 0) = thestring
                        cigArray(j, 1) = txtBoxSender.Text
                        j += 1
                        'End If
                        'Else
                        'strMessage = "Please enter a number in the cigarette consumption box"
                        'Utilities.CreateMessageAlert(Me.Page, strMessage, "strKey1")
                        'Session("errorInput") = "True"
                        ' End If
                End Select
                theDate = theDate.AddDays(1).ToShortDateString
            Next

            'If (Session("saveCalendar") = True) Then
            theDate = Convert.ToDateTime(Session("startDate")).Date.ToShortDateString


        End Sub
        Public Sub showMessageBox()
            Dim oInsert As New myWebServices()
            oInsert.ASPNET_YesNoMessage("are you sure")


        End Sub


        Private Sub updateAlk(ByVal theDate As Date, ByVal drink As String)
            Dim oInsert As New myWebServices()
            Dim sqlString As String


            Dim oCalendar As New myWebServices()
            Dim queryString As String
            queryString = "Select eventID as theReturn from events where userAutoID='" & Session("customerID") & "' and eventDate='"
            queryString = queryString & theDate & "'"

            Dim theEventID As String
            theEventID = oCalendar.getOneValue(queryString)

            If (theEventID <> "") Then
                sqlString = "update events set drink='" & drink & "' "
                sqlString = sqlString & " where  eventID=" & theEventID


            Else

                sqlString = "insert into events (eventDate,userAutoID,drink) Values ('"
                sqlString = sqlString & theDate & "','" & Session("customerID") & "',"

                If (drink <> "") Then
                    sqlString = sqlString & drink & ""
                Else
                    sqlString = sqlString & "0"
                End If



                sqlString = sqlString & ")"

            End If

            Dim success As Boolean
            success = oInsert.insertRecord(sqlString)
            If success Then

                'oInsert.ASPNET_MsgBox("Success insert/update number of drink/alcohol consumsion.")
                ' Response.Redirect(Request.Url.ToString(), False) ' will include the querystring
            Else
                ' oInsert.ASPNET_MsgBox("Error inserting event")
            End If


            ' loadCalendar()
            'Me.PanelEdit.Visible = False
            'Me.PanelEdit.Enabled = False
        End Sub

        Private Sub updateCig(ByVal theDate As String, ByVal smoke As String)
            Dim oInsert As New myWebServices()
            Dim sqlString As String

            Dim oCalendar As New myWebServices()
            Dim queryString As String
            queryString = "Select eventID as theReturn from events where userAutoID='" & Session("customerID") & "' and eventDate='"
            queryString = queryString & theDate & "'"

            Dim theEventID As String
            theEventID = oCalendar.getOneValue(queryString)

            If (theEventID <> "") Then
                sqlString = "update events set eventText='" & smoke & "' "
                sqlString = sqlString & " where  eventID=" & theEventID

                Dim success As Boolean
                success = oInsert.insertRecord(sqlString)
                If success Then
                    ' oInsert.ASPNET_MsgBox("Success insert/update number of drink/alcohol consumsion.")
                    ' Response.Redirect(Request.Url.ToString(), False) ' will include the querystring
                Else
                    ' oInsert.ASPNET_MsgBox("Error inserting event")
                End If

            Else
                sqlString = "insert into events(eventText,userAutoID,eventDate) Values ('" & smoke & "','" & Session("customerID") & "','" & theDate & "') "


                Dim success As Boolean
                success = oInsert.insertRecord(sqlString)

            End If

            


            ' loadCalendar()
            'Me.PanelEdit.Visible = False
            'Me.PanelEdit.Enabled = False
        End Sub
        Public Shared Sub CreateConfirmBox(ByRef btn As WebControls.Button, _
ByVal strMessage As String)
            btn.Attributes.Add("onclick", "return confirm('" & strMessage & "')")


        End Sub


        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

            'Dim oCRC As New myWebServices()
            'oCRC.ASPNET_YesNoMessage("Are you sure you 've entered all your personal event?")

          
            'CreateConfirmBox(Button1, "Are you sure you 've entered all your personal event?")

            Dim oInsert As New myWebServices()

                  Dim d As Integer

            For d = 0 To j - 1
                Dim theDate As Date
                theDate = cigArray(d, 0)
                updateCig(theDate, cigArray(d, 1))


            Next
            '  Response.Redirect("/calendar/confirmAnswer.aspx")
            ' Response.Write("<script>window.open" & _
            ' "('confirmAnswer.aspx','_new', 'width=400,height=200');</script>")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''

           

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '  Response.Redirect("yahoo.com")
            ' If (Session("startDate") <> "" And Session("endDate") <> "") Then
            'Response.Redirect("/calendar/instructions.aspx")
            'Else
            Response.Redirect("~/csdpCalendar.aspx")
            'End If







        End Sub

        Private Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
            Dim oCRC As New myWebServices()

            oCRC.OpenPopUp(Me.ImageButton1, "help.aspx", "Tips", 500, 380)
        End Sub
    End Class

End Namespace
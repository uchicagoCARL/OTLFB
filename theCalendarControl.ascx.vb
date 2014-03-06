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




Partial  Class theCalendarControl
    Inherits System.Web.UI.UserControl
    Protected WithEvents tbAlc As System.Web.UI.WebControls.TextBox


        Dim reloadPage As Boolean

    Dim TbCigArray() As System.Web.UI.WebControls.TextBox
    Dim TbAlkArray() As System.Web.UI.WebControls.TextBox

    WithEvents tbCigAction As System.Web.UI.WebControls.TextBox
        WithEvents tbAlkAction As System.Web.UI.WebControls.TextBox

    Dim ds As New DataSet()
    Dim myda As SqlDataAdapter

        Dim stillEmptyBox As Boolean
        Dim boxFill As Integer
  
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

        Private Sub addDrinkTbToCalendar(ByVal theDate As Date, ByVal TBAlkArray() As TextBox, ByVal tBCigArray() As TextBox, ByVal i As Integer, ByVal theColor As Integer, ByVal theEventText As String)

            Dim labelDate As Label
            labelDate = New Label()
            Dim theString As String
            labelDate.Text = Convert.ToString(theDate.Month) & "/" & Convert.ToString(theDate.Day)

            Dim labelAlk As Label
            labelAlk = New Label()
            labelAlk.Text = "<br/><br/> Alc: "


            Dim labelCig As Label
            labelCig = New Label()
            labelCig.Text = "<br/> Cig: "

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
            Dim labelEventText As Label
            labelEventText = New Label()
            labelEventText.Text = " " & theEventText
            labelEventText.Font.Bold = True

            Me.TableCalendar.Rows(theRow).Cells(theCells).Controls.AddAt(0, labelDate)
            Me.TableCalendar.Rows(theRow).Cells(theCells).Controls.AddAt(1, labelEventText)
            Me.TableCalendar.Rows(theRow).Cells(theCells).Controls.AddAt(2, labelAlk)
            Me.TableCalendar.Rows(theRow).Cells(theCells).Controls.AddAt(3, TBAlkArray(i))
            Me.TableCalendar.Rows(theRow).Cells(theCells).Controls.AddAt(4, labelCig)
            Me.TableCalendar.Rows(theRow).Cells(theCells).Controls.AddAt(5, tBCigArray(i))
            If (theColor = 1) Then
                Me.TableCalendar.Rows(theRow).Cells(theCells).BackColor = Color.Yellow
                ' ElseIf (theColor = 2) Then
                '  Me.TableCalendar.Rows(theRow).Cells(theCells).BackColor = Color.Yellow
            Else
                Me.TableCalendar.Rows(theRow).Cells(theCells).BackColor = Color.GreenYellow
            End If

            If (theDate.DayOfWeek = DayOfWeek.Saturday) Then
                theRow += 1
            End If


        End Sub



    Private Sub loadTheCalendar()



        Dim m As Integer
            Dim n As Integer
            Dim theEventText As String

        For m = 1 To 6
            For n = 0 To 6
                TableCalendar.Rows(m).Cells(n).Controls.Clear()

            Next

            Next

            If Session("FinalSubmission") = True Then
                Me.Button1.Text = "Final Submission"
            End If


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
          
            boxFill = 0
        For d = 1 To textBoxCount
            Dim theColor As Integer
            theColor = 1

            Dim theTextBox As TextBox
                Dim theTBCig As TextBox


                Dim tbAlkAction As TextBox
                tbAlkAction = New TextBox()
                tbAlkAction.ID = theDate & "Alk"
                tbAlkAction.Style("width") = 40
            'tbAlkAction.BackColor = Color.Maroon
                AddHandler tbAlkAction.TextChanged, AddressOf tbAlkAction_TextChanged
                Dim TBAlkArray(d) As TextBox
                TBAlkArray(d) = New TextBox()
                TBAlkArray(d) = tbAlkAction


               

                ''''''''''''''''''''''''''''''''''
            Dim TbCigAction As TextBox
            TbCigAction = New TextBox()
            TbCigAction.ID = theDate & "Cig"
            TbCigAction.Style("width") = 40
            'tbAlkAction.BackColor = Color.Maroon
            AddHandler TbCigAction.TextChanged, AddressOf tbCigAction_TextChanged
                Dim TBCigArray(d) As TextBox
            TBCigArray(d) = New TextBox()

            TBCigArray(d) = TbCigAction

            If (Session("smoke") = "1") Then
                TBCigArray(d).Text = ""
            Else
                TBCigArray(d).Text = "0"
            End If

            If (Session("drink") = "1") Then
                TBAlkArray(d).Text = ""
            Else
                TBAlkArray(d).Text = "0"
            End If


            '''''''''''''''''''''''''''''''''''''''''''''''''

                Dim dr As DataRow

            If ds.Tables(0).Rows.Count <> 0 Then
                For Each dr In ds.Tables(0).Rows

                    If Not dr("eventDate") Is DBNull.Value Then

                            If (dr("eventDate").ToString = theDate.ToString) Then
                                If (Not dr("smoke") Is DBNull.Value And Not dr("drink") Is DBNull.Value) Then
                                    If (IsNumeric(dr("smoke")) And IsNumeric(dr("drink"))) Then
                                        TBCigArray(d).Text = dr("smoke")
                                        TBAlkArray(d).Text = dr("drink")
                                        theColor = 3
                                        boxFill = boxFill + 1

                                    End If



                                    If (dr("smoke") = "" Or dr("drink") = "") Then
                                        If dr("smoke") = "" And dr("drink") <> "" Then
                                            TBAlkArray(d).Text = dr("drink")
                                            TBCigArray(d).Text = ""
                                            theColor = 1
                                        End If
                                        If dr("smoke") <> "" And dr("drink") = "" Then
                                            TBCigArray(d).Text = dr("smoke")
                                            TBAlkArray(d).Text = ""
                                            theColor = 1
                                        End If

                                        If dr("smoke") = "" And dr("drink") = "" Then
                                            TBCigArray(d).Text = ""
                                            TBAlkArray(d).Text = ""
                                            theColor = 1
                                        End If
                                    End If

                                    'to make sure we don't set stillEmptyBox = false when the only last text box is filled 
                                    'If (d <> textBoxCount) Then
                                    'stillEmptyBox = False
                                    'End If

                                    '''''''''''''''''''''''''''''''''''
                                    If myAnswer = False Then
                                        theColor = 1

                                    End If
                                    '''''''''''''''''''''''''''''''''''
                                    'ONLY fill out the smoke not drink
                                ElseIf (Not dr("smoke") Is DBNull.Value) Then
                                    TBCigArray(d).Text = dr("smoke")
                                    theColor = 1
                                    ' stillEmptyBox = True
                                    'only fill out the drink not smoke
                                ElseIf (Not dr("drink") Is DBNull.Value) Then

                                    TBAlkArray(d).Text = dr("drink")
                                    theColor = 1
                                    ' stillEmptyBox = True
                                    'ElseIf (dr("drink") Is DBNull.Value Or dr("smoke") Is DBNull.Value) Then


                                    '  stillEmptyBox = True



                                End If

                                If (Not dr("eventText") Is DBNull.Value) Then
                                    theEventText = dr("eventText")
                                Else
                                    theEventText = ""
                                End If


                                Exit For
                            Else
                                theEventText = ""
                            End If


                        End If

            Next
                Else
                    theEventText = ""
                End If


                '''''''''''''''''''''''''''''''''''''''''''''''''''''



                addDrinkTbToCalendar(theDate, TBAlkArray, TBCigArray, d, theColor, theEventText)

                theDate = theDate.AddDays(1).ToShortDateString



            Next
            Dim temp2 As Integer
            temp2 = boxFill


    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
            Utilities.CreateConfirmBox(Me.Button1, "Are you sure your responses are accurate and you are ready to submit this calendar?")
          
        ' Dimension the array into 2 dimensions 


            reloadPage = True
            loadTheCalendar()



        If (Not Me.Page.IsPostBack) Then
            Dim oCRC As New myWebServices()
              
            oCRC.OpenPopUp(Me.ImageButton1, "help.aspx", "Tips", 500, 380)

            i = 0
            j = 0



        End If



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


        Private Sub tbAlkAction_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbAlkAction.TextChanged

            ' Utilities.CreateConfirmBox(Me.Button1, "Are you sure you want to save?")

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
                            If (IsNumeric(txtBoxSender.Text)) Then
                                If txtBoxSender.Text > 50 Then
                                    strMessage = "Please make certain that the total number of alcoholic drinks consumed in a day is less than 50"
                                    Utilities.CreateMessageAlert(Me.Page, strMessage, "strKey1")
                                    Session("errorInput") = "True"
                                    reloadPage = False
                                    Exit For


                                Else
                                    Dim thestring As String
                                    thestring = theDate
                                    alkArray(i, 0) = thestring
                                    alkArray(i, 1) = txtBoxSender.Text
                                    i += 1
                                    reloadPage = True
                                End If
                            End If


                        ElseIf txtBoxSender.Text = "" Then
                            Dim thestring As String
                            thestring = theDate
                            alkArray(i, 0) = thestring
                            alkArray(i, 1) = txtBoxSender.Text
                            i += 1
                            If reloadPage <> False Then
                                reloadPage = True
                            End If
                            Else
                                '  oError.ASPNET_MsgBox("Please enter a number in the alcohol consumption box")
                                Session("errorInput") = "True"
                                reloadPage = False
                                strMessage = "Please enter a number in the alcohol consumption box"
                                Utilities.CreateMessageAlert(Me.Page, strMessage, "strKey1")
                            End If



                End Select
                theDate = theDate.AddDays(1).ToShortDateString
            Next

            'If (Session("saveCalendar") = True) Then
            theDate = Convert.ToDateTime(Session("startDate")).Date.ToShortDateString


        End Sub


        Private Sub tbCigAction_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbCigAction.TextChanged

            ' Utilities.CreateConfirmBox(Me.Button1, "Are you sure you want to save?")

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

            Select strTextBoxID
                   

                    Case theDate & "Cig"
                        If (IsNumeric(txtBoxSender.Text)) Then
                            If (IsNumeric(txtBoxSender.Text)) Then

                                If txtBoxSender.Text > 80 Then
                                    strMessage = "Please make certain that the total number of cigarettes smoked in a day is less than 80"
                                    Utilities.CreateMessageAlert(Me.Page, strMessage, "strKey1")
                                    Session("errorInput") = "True"
                                    reloadPage = False
                                    Exit For



                                Else
                                    Dim thestring As String
                                    thestring = theDate
                                    cigArray(j, 0) = thestring
                                    cigArray(j, 1) = txtBoxSender.Text
                                    j += 1
                                    If reloadPage <> False Then
                                        reloadPage = True
                                    End If

                                    End If
                            End If


                        ElseIf txtBoxSender.Text = "" Then
                            Dim thestring As String
                            thestring = theDate
                            cigArray(j, 0) = thestring
                            cigArray(j, 1) = txtBoxSender.Text
                            j += 1
                            reloadPage = True


                        Else
                            strMessage = "Please enter a number in the cigarette consumption box"
                            Utilities.CreateMessageAlert(Me.Page, strMessage, "strKey1")
                            Session("errorInput") = "True"
                            reloadPage = False
                        End If

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
                    sqlString = sqlString & ""
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
                sqlString = "update events set smoke='" & smoke & "' "
                sqlString = sqlString & " where  eventID=" & theEventID


            Else

                sqlString = "insert into events (eventDate,userAutoID,smoke) Values ('"
                sqlString = sqlString & theDate & "','" & Session("customerID") & "',"

                If (smoke <> "") Then
                    sqlString = sqlString & smoke & ""
                Else
                    sqlString = sqlString & ""
                End If



                sqlString = sqlString & ")"

            End If

            Dim success As Boolean
            success = oInsert.insertRecord(sqlString)
            If success Then
                ' oInsert.ASPNET_MsgBox("Success insert/update number of drink/alcohol consumsion.")
                ' Response.Redirect(Request.Url.ToString(), False) ' will include the querystring
            Else
                ' oInsert.ASPNET_MsgBox("Error inserting event")
            End If


            ' loadCalendar()
            'Me.PanelEdit.Visible = False
            'Me.PanelEdit.Enabled = False
        End Sub

        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


            Dim oInsert As New myWebServices()
            If i > 0 Or j > 0 Then

                Dim d As Integer

                For d = 0 To i - 1
                    Dim theDate As Date
                    theDate = alkArray(d, 0)
                    updateAlk(theDate, alkArray(d, 1))
                Next

                For d = 0 To j - 1
                    Dim theDate As Date
                    theDate = cigArray(d, 0)
                    updateCig(theDate, cigArray(d, 1))
                Next
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                If myAnswer = False Then
                    Dim mystr As String
                    mystr = "update investigators set confirmAnswer='1' where id='" & Session("customerID") & "'"
                    Dim oCal As New myWebServices()

                    oCal.insertRecord(mystr)

                End If
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If (reloadPage = True) Then
                loadTheCalendar()

                '  If Session("errorInput") = "False" Then


                If (boxFill <> 36) Then
                    Dim myMessage As String
                    myMessage = "You’ve forgotten to completely fill in both spaces on one or more calendar days. Though you are welcome to still update them, calendar days highlighted in green have been accepted. Those calendar days highlighted in yellow still require your attention."
                    oInsert.ASPNET_MsgBox(myMessage)
                    ' loadTheCalendar()
                Else
                    If (Me.Button1.Text = "Final Submission" And Session("errorInput") = False) Then
                        Response.Redirect("https://www.surveymonkey.com/s.aspx?sm=vllOtqDnzz9wzGSfH_2fCFYQ_3d_3d. ")
                    Else
                        Session("FinalSubmission") = True
                        Me.Button1.Text = "Final Submission"
                        oInsert.ASPNET_MsgBox("You have completely filled in the calendar.  Please take a moment to review your responses and make any necessary changes prior to final submission. When you are satisfied, please press 'Final Submission'.")

                        loadTheCalendar()

                    End If
                    'oInsert.ASPNET_MsgBox("Success insert/update the number of drink/alcohol consumption.")

                End If
            End If

            Session("errorInput") = False
            Session("Final Submission") = False
            reloadPage = False


        End Sub

        Private Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
            Dim oCRC As New myWebServices()

            oCRC.OpenPopUp(Me.ImageButton1, "help.aspx", "Tips", 500, 380)
        End Sub
    End Class

End Namespace

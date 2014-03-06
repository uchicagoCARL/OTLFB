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





Partial  Class calendarControl
    Inherits System.Web.UI.UserControl
    Dim ds As New DataSet()
    Dim myda As SqlDataAdapter

    Protected WithEvents tbAlk As System.Web.UI.WebControls.TextBox



    Dim calendarArrayList As ArrayList

    Protected WithEvents tbDrink As System.Web.UI.WebControls.TextBox
    Protected WithEvents tbSmoke As System.Web.UI.WebControls.TextBox
    Protected WithEvents lbDrink As System.Web.UI.WebControls.Label
    Protected WithEvents lbSmoke As System.Web.UI.WebControls.Label


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
        Response.Cache.SetCacheability(HttpCacheability.NoCache)

        

        If (Not IsPostBack()) Then
            'for some reason, I need to put this one here in addtion to call it later...in order for it to response by the            'first time user click help button  ...not sure why????
            Me.OpenPopUp(Me.ImageButton1, "help.aspx", "Tips", 500, 380)
            If (Session("customerID") <> "") Then
                ' loadCalendar()
            End If
            Session("monthCalendar1Change") = False
            Session("monthCalendar2Change") = False

        End If



        If (Request.QueryString("eventID") <> "") Then
            Dim oCalendar As New myWebServices()
            Dim myCalendarDetails As New calendarDetails()
            myCalendarDetails = oCalendar.getCalendarDetail(Request.QueryString("eventID"))
            Me.LabelDate.Text = myCalendarDetails.eventDate
            Me.TextboxEvent.Text = myCalendarDetails.eventText

        End If







    End Sub
    Private Sub loadCalendar()

        'Me.Calendar1().VisibleDate = Convert.ToDateTime(Session("startDate")).Month
        Dim oCalendar As New myWebServices()
        Dim oUserDetail As New CustomerDetails()

        oUserDetail = oCalendar.getCustomerDetail(Session("customerID"))
        Session("startDate") = oUserDetail.startDate
        Session("endDate") = oUserDetail.endDate

     



        Dim startMonth = Convert.ToDateTime(Session("startDate")).Month
        Dim endMonth = Convert.ToDateTime(Session("endDate")).Month

        'if user use the next/previous month then we set the new visible date to the new month


        If (Session("monthCalendar1Change") = True) Then

            If (Calendar1.VisibleDate.Month <> startMonth) Then
                Calendar1.VisibleDate = New Date(Calendar1.VisibleDate.Year, Calendar1.VisibleDate.Month, 1)

            Else

            End If
        Else
            Me.Calendar1().VisibleDate = Convert.ToDateTime(Session("startDate"))
        End If


        If (Session("monthCalendar2Change") = True) Then

            If (Calendar2.VisibleDate.Month <> startMonth) Then
                Calendar2.VisibleDate = New Date(Calendar2.VisibleDate.Year, Calendar2.VisibleDate.Month, 1)

            Else

            End If
        Else


            If (startMonth <> endMonth) Then
                Me.Calendar2().Visible() = True
                Me.Calendar2().VisibleDate = Convert.ToDateTime(Session("endDate"))
            End If
        End If

        Dim ConnectString As String = System.Configuration.ConfigurationSettings.AppSettings("ConnectionString")
        Dim MyConnection As SqlConnection = New SqlConnection(ConnectString)
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



    Public Sub CalendarDRender(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DayRenderEventArgs)
        Dim dr As DataRow
        Dim strEvents As New StringBuilder()
        Dim strSmoke As New StringBuilder()
        Dim strDrink As New StringBuilder()
        lbDrink = New Label()
        lbSmoke = New Label()

        If Not e.Day.IsOtherMonth Then

            If (e.Day.Date >= Session("startDate") And e.Day.Date <= Session("endDate")) Then
                e.Cell.BackColor = Color.PaleVioletRed
                strDrink.Append("<br /> Drink: ")
                e.Cell.Controls.Add(New LiteralControl(strDrink.ToString()))
                Dim theString As String
                lbDrink.ID = theString & "Drink"
                e.Cell.Controls.Add(lbDrink)

                strSmoke.Append("<br />Smoke: ")
                e.Cell.Controls.Add(New LiteralControl(strSmoke.ToString()))
                lbSmoke.ID = theString & "Smoke"
                e.Cell.Controls.Add(lbSmoke)
            End If

            If ds.Tables(0).Rows.Count <> 0 Then

                For Each dr In ds.Tables(0).Rows

                    'If EventDate is not Null
                    If Not dr("eventDate") Is DBNull.Value Then
                        Dim dtEvent As DateTime = dr("eventDate").ToString

                        If dtEvent.Equals(e.Day.Date) Then
                            e.Cell.BackColor = Color.PaleVioletRed
                                If Not dr("drink") Is DBNull.Value Then
                                    lbDrink.Text = dr("drink")
                                Else
                                    lbDrink.Text = ""


                                End If
                                If Not dr("smoke") Is DBNull.Value Then
                                    lbSmoke.Text = dr("smoke")
                                Else
                                    lbSmoke.Text = 0
                                  
                                End If
                                Exit For
                            End If
                        End If

                    Next
                e.Cell.Controls.Add(New LiteralControl(strEvents.ToString()))
                'If the month is not CurrentMonth then hide the Dates
            Else
                lbDrink.Text = 0
                lbSmoke.Text = 0
            End If

        Else
            lbDrink.Text = 0
            lbSmoke.Text = 0

        End If




    End Sub

    Sub TheCalendarSelected(ByVal theCalendar As System.Web.UI.WebControls.Calendar)
        Me.PanelEdit.Visible = True
        Me.PanelEdit.Enabled = True

        SetFocus(Me.TextboxDrink)

        Dim oCalendar As New myWebServices()
        Dim queryString As String
        queryString = "Select eventID as theReturn from events where userAutoID='" & Session("customerID") & "' and eventDate='"
        queryString = queryString & theCalendar.SelectedDate.ToShortDateString & "'"
        Dim theEventID As String
        theEventID = oCalendar.getOneValue(queryString)

        Me.LabelDate.Text = theCalendar.SelectedDate.ToShortDateString
        Me.TextboxDrink.Text = ""
        Me.TextboxSmoke.Text = ""
        Me.TextboxEvent.Text = ""


        If (theEventID <> "") Then

            Dim myCalendarDetail As New calendarDetails()
            myCalendarDetail = oCalendar.getCalendarDetail(theEventID)

            Me.TextboxDrink.Text = myCalendarDetail.drink
            Me.TextboxSmoke.Text = myCalendarDetail.smoke
            Me.TextboxEvent.Text = myCalendarDetail.eventText
        Else

            Me.TextboxDrink.Text = 0
            Me.TextboxSmoke.Text = 0


        End If


        ' Me.loadCalendar()


    End Sub



    Private Sub ButtonSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSubmit.Click
        Dim oInsert As New myWebServices()
        Dim sqlString As String

        Dim oCalendar As New myWebServices()
        Dim queryString As String
        queryString = "Select eventID as theReturn from events where userAutoID='" & Session("customerID") & "' and eventDate='"
        queryString = queryString & Me.LabelDate.Text & "'"

        Dim theEventID As String
        theEventID = oCalendar.getOneValue(queryString)

        If (theEventID <> "") Then
            sqlString = "update events set eventText='" & Me.TextboxEvent.Text & "', drink=' " & Me.TextboxDrink.Text & "',"
            sqlString = sqlString & " smoke = '" & Me.TextboxSmoke.Text & "' where  eventID=" & theEventID


        Else

            sqlString = "insert into events (eventText,eventDate,userAutoID,drink,smoke) Values ('" & Me.TextboxEvent.Text & "','"
            sqlString = sqlString & Me.LabelDate.Text & "','" & Session("customerID") & "',"
            If (Me.TextboxDrink.Text <> "") Then
                sqlString = sqlString & Me.TextboxDrink.Text & ", "
            Else
                sqlString = sqlString & "0, "
            End If

            If (Me.TextboxSmoke.Text <> "") Then
                sqlString = sqlString & Me.TextboxSmoke.Text
            Else
                sqlString = sqlString & "0"
            End If


            sqlString = sqlString & ")"

        End If

        Dim success As Boolean
        success = oInsert.insertRecord(sqlString)
        If success Then
            oInsert.ASPNET_MsgBox("Success insert/update number of drink/alcohol consumsion.")
            ' Response.Redirect(Request.Url.ToString(), False) ' will include the querystring
        Else
            ' oInsert.ASPNET_MsgBox("Error inserting event")
        End If


        loadCalendar()
        Me.PanelEdit.Visible = False
        Me.PanelEdit.Enabled = False
    End Sub

    Private Sub SetFocus(ByVal ctrl As Control)
        ' Define the JavaScript function for the specified control.
        Dim focusScript As String = "<script language='javascript'>" & _
          "document.getElementById('" + ctrl.ClientID & _
          "').focus();</script>"

        ' Add the JavaScript code to the page.
        Page.RegisterStartupScript("FocusScript", focusScript)
    End Sub


    Private Sub Calendar_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged, Calendar2.SelectionChanged
        loadCalendar()
        TheCalendarSelected(sender)
    End Sub



    Private Sub Calendar_VisibleMonthChanged(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MonthChangedEventArgs) Handles Calendar1.VisibleMonthChanged, Calendar2.VisibleMonthChanged



        Me.PanelEdit.Visible = False
        Me.PanelEdit.Enabled = False

        Dim iMonth As Integer
        Dim iYear As Integer

        iMonth = sender.VisibleDate.Month '+ 1
        iYear = sender.VisibleDate.Year

        Dim theCalendar As System.Web.UI.WebControls.Calendar
        theCalendar = sender
        If (theCalendar Is Me.Calendar1) Then
            Session("monthCalendar1Change") = True
        Else
            Session("monthCalendar2Change") = True
        End If

        sender.VisibleDate = New Date(iYear, iMonth, 1)



        loadCalendar()
        ' ShowMonthSelector(e.PreviousDate)
    End Sub

    Private Sub CalendarPreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar1.PreRender, Calendar2.PreRender
        loadCalendar()
    End Sub

    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        Response.Redirect("..\calendar\myCalendar.aspx")
    End Sub

    Private Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Me.OpenPopUp(Me.ImageButton1, "help.aspx", "Tips", 500, 380)
    End Sub

    Public Shared Sub OpenPopUp(ByVal opener As System.Web.UI.WebControls.WebControl, ByVal PagePath As String, ByVal windowName As String, ByVal width As Integer, ByVal height As Integer)
        Dim clientScript As String
        Dim windowAttribs As String

        'Building Client side window attributes with width and height.
        'Also the the window will be positioned to the middle of the screen
        windowAttribs = "width=" & width & "px," & _
                  "height=" & height & "px," & _
                  "left='+((screen.width -" & width & ") / 2)+'," & _
                  "top='+ (screen.height - " & height & ") / 2+'"

        'Building the client script - window.open, with additional parameters
        clientScript = "window.open('" & PagePath & "','" & windowName & "','" & windowAttribs & "');return false;"
        'register the script to the clientside click event of 'opener' control
        opener.Attributes.Add("onClick", clientScript)
    End Sub

End Class

End Namespace

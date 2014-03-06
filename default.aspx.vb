Imports System.Web
Imports System.Data
Imports System.Data.SqlClient

Namespace calendar

    Partial Class _default
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
            If Session("startDate") <> "" And Session("endDate") <> "" Then
                Response.Redirect("~/instructions.aspx")
                'Response.Write("<script> laguage='javascript'")
                'Response.Write("window.open('../calendar/csdpCalendar.aspx',toolbar='no')")
                'Response.Write("</script>")

            End If


        End Sub








        Private Sub ButtonAlcohol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAlcohol.Click

            Dim oCalendar As New myWebServices()
            Dim sqlString As String

            If (Me.RadioButtonListAlcohol.SelectedItem.Value = "Yes") Then
                Session("alcohol") = 1


            Else
                Session("alcohol") = 0
                '   sqlString = "insert into events (eventDate,userAutoID,drink) Values ('"
                '  sqlString = sqlString & Date.Now & "','" & Session("customerID") & "',0)"


            End If

            If (Me.RadioButtonListCig.SelectedItem.Value = "Yes") Then
                Session("cig") = 1
            Else
                Session("cig") = 0
                ' sqlString = "insert into events (eventDate,userAutoID,smoke) Values ('"
                '  sqlString = sqlString & Date.Now & "','" & Session("customerID") & "',0)"

            End If

            ' If (Session("cig") = 0 And Session("alcohol") = 0) Then
            'Response.Redirect("csdpCalendar.aspx")
            'Dim oCRC As New myWebServices()
            'oCRC.ASPNET_MsgBox("Please select if you smoke or drink during last month")
            ' Exit Sub
            ' End If


            Dim endDate, startDate As Date
            endDate = DateTime.Now.AddDays(-1).ToShortDateString
            startDate = DateTime.Now.AddDays(-36).ToShortDateString
            Dim mySQL As String


            mySQL = "update investigators set startDate= '" & startDate & "', endDate= '" & endDate & "',smoke= " & Session("cig") & ", drink= " & Session("alcohol") & " where id=" & Session("customerID")


            oCalendar.insertRecord(mySQL)

            insertDateToCalendar()
            insertDefault0ToCalendar()

            ' Response.Redirect("personalize.aspx")
            Response.Redirect("instructions.aspx")
            'Response.Redirect("theCalendar.aspx")

        End Sub

        Public Sub insertDefault0ToCalendar()
            Dim textBoxCount As Integer


            textBoxCount = 36


            Dim oCalendar As New myWebServices()
            Dim oUserDetail As New CustomerDetails()

            oUserDetail = oCalendar.getCustomerDetail(Session("customerID"))
            Session("startDate") = oUserDetail.startDate
            Session("endDate") = oUserDetail.endDate
            Session("drink") = oUserDetail.drink
            Session("smoke") = oUserDetail.smoke



            Dim d As Integer
            Dim theDate As Date
            theDate = Convert.ToDateTime(Session("startDate")).Date.ToShortDateString

            Dim sqlStr As String

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim str As String
            str = "Select eventID from events where userAutoID='" & Session("customerID") & "'"
            Dim ConnectString As String = System.Configuration.ConfigurationSettings.AppSettings("ConnectionString")
            Dim MyConnection As SqlConnection = New SqlConnection(ConnectString)
            Dim MyCommand As New SqlCommand(Str, MyConnection)

            Dim myReader As SqlDataReader

            Try
                MyConnection.Open()

                myReader = MyCommand.ExecuteReader()

                Do While (myReader.Read())

                    If (myReader.GetValue(0).ToString() <> "") Then

                        If (Session("smoke") = "0" And Session("drink") = "0") Then
                            sqlStr = "update events set smoke='0',drink='0' where userAutoID='" & Session("customerID") & "' and eventID=" & myReader.GetValue(0)
                            oCalendar.insertRecord(sqlStr)


                        ElseIf (Session("smoke") = "0") Then
                            sqlStr = "update events set smoke='0' where userAutoID='" & Session("customerID") & "' and eventID=" & myReader.GetValue(0)

                            'sqlStr = "update events (eventDate,userAutoID,smoke) values ('" & _
                            'theDate & "','" & Session("customerID") & "', '0')"
                            oCalendar.insertRecord(sqlStr)


                        ElseIf (Session("drink") = "0") Then
                            sqlStr = "update events set drink='0' where userAutoID='" & Session("customerID") & "' and eventID=" & myReader.GetValue(0)

                            ' sqlStr = "Insert into events (eventDate,userAutoID,drink) values ('" & _
                            ' theDate & "','" & Session("customerID") & "', '0')"

                            oCalendar.insertRecord(sqlStr)


                        End If

                    End If
                   
                Loop

            Catch e As Exception
                Throw e
            Finally

                If Not (myReader Is Nothing) Then
                    myReader.Close()
                End If

                If (MyConnection.State = ConnectionState.Open) Then
                    MyConnection.Close()
                End If
            End Try





        End Sub

        Public Sub insertDateToCalendar()
            Dim textBoxCount As Integer


            textBoxCount = 36


            Dim oCalendar As New myWebServices()
            Dim oUserDetail As New CustomerDetails()

            oUserDetail = oCalendar.getCustomerDetail(Session("customerID"))
            Session("startDate") = oUserDetail.startDate
            Session("endDate") = oUserDetail.endDate


            Dim d As Integer
            Dim theDate As Date
            theDate = Convert.ToDateTime(Session("startDate")).Date.ToShortDateString

            Dim sqlStr As String



            For d = 1 To textBoxCount

                sqlStr = "Insert into events (eventDate,userAutoID) values ('" & _
                   theDate & "','" & Session("customerID") & "')"

                oCalendar.insertRecord(sqlStr)






                theDate = theDate.AddDays(1).ToShortDateString



            Next





        End Sub
    End Class

End Namespace

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




Public Class CustomerDetails

    Public UserName As String
    Public FullName As String
    Public lName As String
    Public fName As String
    Public Email As String
    Public role As Integer
    Public address As String
    Public phone As String
    Public degree As String
    Public startDate As String
    Public endDate As String
    Public drink As String
    Public smoke As String




End Class



Public Class chargeCodeDetail

    Public price As Double
    Public chargeTo As String
    Public chargeCode As String


End Class

Public Class calendarDetails

    Public eventID As Integer
    Public eventText As String
    Public eventDate As String
    Public drink As String
    Public smoke As String
    Public alcohol As String


End Class

Public Class outPatientRecordDetail

    Public fName As String
    Public lName As String
    Public visitDate As String
    Public invoiceNumber As String
    Public protocolNumber As String
    Public price As Double
    Public chargeTo As String
    Public total As String
    Public chargeCode As String
    Public quantity As String
    Public comment As String

End Class

Public Class recordDetails
    Public ID As String
End Class





<WebService(Namespace:="http://tempuri.org/")> _
Public Class myWebServices
    Inherits System.Web.Services.WebService

#Region " Web Services Designer Generated Code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Web Services Designer.
        InitializeComponent()

        'Add your own initialization code after the InitializeComponent() call

    End Sub

    'Required by the Web Services Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Web Services Designer
    'It can be modified using the Web Services Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        'CODEGEN: This procedure is required by the Web Services Designer
        'Do not modify it using the code editor.
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

#End Region

    ' WEB SERVICE EXAMPLE
    ' The HelloWorld() example service returns the string Hello World.
    ' To build, uncomment the following lines then save and build the project.
    ' To test this web service, ensure that the .asmx file is the start page
    ' and press F5.
    '
    '<WebMethod()> Public Function HelloWorld() As String
    '	HelloWorld = "Hello World"
    ' End Function

    

    <WebMethod()> Function getOneValue(ByVal str As String) As String

        Dim ConnectString As String = System.Configuration.ConfigurationSettings.AppSettings("ConnectionString")
        Dim MyConnection As SqlConnection = New SqlConnection(ConnectString)
        Dim MyCommand As New SqlCommand(str, MyConnection)

        Dim myReader As SqlDataReader

        Try
            MyConnection.Open()

            myReader = MyCommand.ExecuteReader()

            Dim tableExist As Boolean
            tableExist = False
            Dim foundRecord As Boolean
            foundRecord = False
            Do While (myReader.Read())

                If (myReader.GetValue(0).ToString() <> "") Then
                    foundRecord = True
                    Exit Do
                End If
            Loop
            If foundRecord = True Then
                Return myReader.GetValue(0).ToString()
            Else
                Return ""

            End If

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

    End Function

    <WebMethod()> Public Function getCalendarDetail(ByVal eventID As String) As calendarDetails

        Dim recordCount As Integer
        Dim sqlConnection As SqlConnection
        sqlConnection = New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        Try
            Dim myCommand As SqlCommand = New SqlCommand("calendarDetails", sqlConnection)
            myCommand.CommandType = CommandType.StoredProcedure

            ' Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC
            Dim parameterEventID As SqlParameter = New SqlParameter("@eventID", SqlDbType.Int, 4)
            parameterEventID.Value = CInt(eventID)
            myCommand.Parameters.Add(parameterEventID)



            Dim parameterEventText As SqlParameter = New SqlParameter("@eventText", SqlDbType.NVarChar, 4000)
            parameterEventText.Direction = ParameterDirection.Output
            myCommand.Parameters.Add(parameterEventText)


            Dim parameterEventDate As SqlParameter = New SqlParameter("@eventDate", SqlDbType.NVarChar, 50)
            parameterEventDate.Direction = ParameterDirection.Output
            myCommand.Parameters.Add(parameterEventDate)

            Dim parameterDrink As SqlParameter = New SqlParameter("@drink", SqlDbType.Int, 4)
            parameterDrink.Direction = ParameterDirection.Output
            myCommand.Parameters.Add(parameterDrink)

            Dim parameterSmoke As SqlParameter = New SqlParameter("@smoke", SqlDbType.Int, 4)
            parameterSmoke.Direction = ParameterDirection.Output
            myCommand.Parameters.Add(parameterSmoke)



            sqlConnection.Open()
            myCommand.ExecuteNonQuery()
            sqlConnection.Close()

            ' Create CustomerDetails Struct
            Dim myCalendarDetails As calendarDetails = New calendarDetails()

            ' Populate Struct using Output Params from SPROC


            If Not IsDBNull(parameterEventText.Value()) Then
                myCalendarDetails.eventText = CStr(parameterEventText.Value)
            End If
            If Not IsDBNull(parameterEventDate.Value()) Then
                myCalendarDetails.eventDate = CStr(parameterEventDate.Value)
            End If
            If Not IsDBNull(parameterDrink.Value()) Then
                myCalendarDetails.drink = CStr(parameterDrink.Value)
            End If
            If Not IsDBNull(parameterSmoke.Value()) Then
                myCalendarDetails.smoke = CStr(parameterSmoke.Value)
            End If


            Return myCalendarDetails


        Catch e As Exception

            Throw e
        Finally
            If sqlConnection.State = ConnectionState.Open Then
                sqlConnection.Close()
            End If

        End Try

    End Function



    <WebMethod()> Function customerLogin(ByVal userName As String, ByVal password As String) As String

        Dim sqlConnection As SqlConnection
        sqlConnection = New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        Try
            Dim sqlCommand As SqlCommand = New SqlCommand("customerLogin", sqlConnection)
            sqlCommand.CommandType = CommandType.StoredProcedure

            'sqlCommand.Parameters.Add(New SqlParameter("@userName", SqlDbType.NVarChar, 50))
            ' sqlCommand.Parameters.Add(New SqlParameter("@password", SqlDbType.NVarChar, 50))
            Dim parameterloginID As SqlParameter = New SqlParameter("@userName", SqlDbType.NVarChar, 50)
            parameterloginID.Value = userName
            sqlCommand.Parameters.Add(parameterloginID)

            Dim parameterPassword As SqlParameter = New SqlParameter("@password", SqlDbType.NVarChar, 50)
            parameterPassword.Value = password
            sqlCommand.Parameters.Add(parameterPassword)

            Dim parameterCustomerID As SqlParameter = New SqlParameter("@ID", SqlDbType.Int, 4)
            parameterCustomerID.Direction = ParameterDirection.Output
            sqlCommand.Parameters.Add(parameterCustomerID)

            sqlConnection.Open()


            sqlCommand.ExecuteNonQuery()
            sqlConnection.Close()


            Dim customerId As Integer = CInt(parameterCustomerID.Value)

            If customerId = 0 Then
                Return Nothing
            Else
                Return customerId.ToString()
            End If

        Catch e As Exception

            Throw e
        Finally
            If sqlConnection.State = ConnectionState.Open Then
                sqlConnection.Close()
            End If

        End Try

    End Function


    <WebMethod()> Public Function getCustomerDetail(ByVal ID As String) As CustomerDetails

        Dim recordCount As Integer
        Dim sqlConnection As SqlConnection
        sqlConnection = New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        Try
            Dim myCommand As SqlCommand = New SqlCommand("customerDetail", sqlConnection)
            myCommand.CommandType = CommandType.StoredProcedure

            ' Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC
            Dim parameterID As SqlParameter = New SqlParameter("@ID", SqlDbType.Int, 4)
            parameterID.Value = CInt(ID)
            myCommand.Parameters.Add(parameterID)

            Dim parameterUserName As SqlParameter = New SqlParameter("@userName", SqlDbType.NVarChar, 50)
            parameterUserName.Direction = ParameterDirection.Output
            myCommand.Parameters.Add(parameterUserName)


            Dim parameterFullName As SqlParameter = New SqlParameter("@FullName", SqlDbType.NVarChar, 50)
            parameterFullName.Direction = ParameterDirection.Output
            myCommand.Parameters.Add(parameterFullName)

            Dim parameterlName As SqlParameter = New SqlParameter("@lName", SqlDbType.NVarChar, 50)
            parameterlName.Direction = ParameterDirection.Output
            myCommand.Parameters.Add(parameterlName)

            Dim parameterfName As SqlParameter = New SqlParameter("@fName", SqlDbType.NVarChar, 50)
            parameterfName.Direction = ParameterDirection.Output
            myCommand.Parameters.Add(parameterfName)

            Dim parameterEmail As SqlParameter = New SqlParameter("@Email", SqlDbType.NVarChar, 50)
            parameterEmail.Direction = ParameterDirection.Output
            myCommand.Parameters.Add(parameterEmail)

            Dim parameterStartDate As SqlParameter = New SqlParameter("@startDate", SqlDbType.NVarChar, 50)
            parameterStartDate.Direction = ParameterDirection.Output
            myCommand.Parameters.Add(parameterStartDate)

            ' Dim parameterPassword As SqlParameter = New SqlParameter("@password", SqlDbType.NVarChar, 50)
            'parameterPassword.Direction = ParameterDirection.Output
            'myCommand.Parameters.Add(parameterPassword)


            Dim parameterEndDate As SqlParameter = New SqlParameter("@endDate", SqlDbType.NVarChar, 50)
            parameterEndDate.Direction = ParameterDirection.Output
            myCommand.Parameters.Add(parameterEndDate)

            Dim parameterRole As SqlParameter = New SqlParameter("@role", SqlDbType.Int, 4)
            parameterRole.Direction = ParameterDirection.Output
            myCommand.Parameters.Add(parameterRole)

            Dim parameterAddress As SqlParameter = New SqlParameter("@address", SqlDbType.NVarChar, 200)
            parameterAddress.Direction = ParameterDirection.Output
            myCommand.Parameters.Add(parameterAddress)

            Dim parameterPhone As SqlParameter = New SqlParameter("@phone", SqlDbType.NVarChar, 50)
            parameterPhone.Direction = ParameterDirection.Output
            myCommand.Parameters.Add(parameterPhone)

            Dim parameterdegree As SqlParameter = New SqlParameter("@degree", SqlDbType.NVarChar, 50)
            parameterdegree.Direction = ParameterDirection.Output
            myCommand.Parameters.Add(parameterdegree)

            Dim parameterDrink As SqlParameter = New SqlParameter("@drink", SqlDbType.Int, 4)
            parameterDrink.Direction = ParameterDirection.Output
            myCommand.Parameters.Add(parameterDrink)

            Dim parameterSmoke As SqlParameter = New SqlParameter("@smoke", SqlDbType.Int, 4)
            parameterSmoke.Direction = ParameterDirection.Output
            myCommand.Parameters.Add(parameterSmoke)




            sqlConnection.Open()
            myCommand.ExecuteNonQuery()
            sqlConnection.Close()

            ' Create CustomerDetails Struct
            Dim myCustomerDetails As CustomerDetails = New CustomerDetails()

            ' Populate Struct using Output Params from SPROC
            If Not IsDBNull(parameterUserName.Value()) Then
                myCustomerDetails.UserName = CStr(parameterUserName.Value)
            End If

            If Not IsDBNull(parameterFullName.Value()) Then
                myCustomerDetails.FullName = CStr(parameterFullName.Value)
            End If
            If Not IsDBNull(parameterlName.Value()) Then
                myCustomerDetails.lName = CStr(parameterlName.Value)
            End If
            If Not IsDBNull(parameterfName.Value()) Then
                myCustomerDetails.fName = CStr(parameterfName.Value)
            End If
            If Not IsDBNull(parameterStartDate.Value()) Then
                myCustomerDetails.startDate = CStr(parameterStartDate.Value)
            End If

            If Not IsDBNull(parameterEndDate.Value()) Then
                myCustomerDetails.endDate = CStr(parameterEndDate.Value)
            End If


            If Not IsDBNull(parameterRole.Value()) Then
                myCustomerDetails.role = CStr(parameterRole.Value)
            End If

            If Not IsDBNull(parameterEmail.Value()) Then
                myCustomerDetails.Email = CStr(parameterEmail.Value)
            End If

            If Not IsDBNull(parameterAddress.Value()) Then
                myCustomerDetails.address = CStr(parameterAddress.Value)
            End If

            'If Not IsDBNull(parameterPassword.Value()) Then
            'myCustomerDetails.password = CStr(parameterPassword.Value)
            'End If

            If Not IsDBNull(parameterPhone.Value()) Then
                myCustomerDetails.phone = CStr(parameterPhone.Value)
            End If

            If Not IsDBNull(parameterdegree.Value()) Then
                myCustomerDetails.degree = CStr(parameterdegree.Value)
            End If

            If Not IsDBNull(parameterDrink.Value()) Then
                myCustomerDetails.drink = CStr(parameterDrink.Value)
            End If

            If Not IsDBNull(parameterSmoke.Value()) Then
                myCustomerDetails.smoke = CStr(parameterSmoke.Value)
            End If



            Return myCustomerDetails


        Catch e As Exception

            Throw e
        Finally
            If sqlConnection.State = ConnectionState.Open Then
                sqlConnection.Close()
            End If

        End Try

    End Function

    <WebMethod()> Public Function loadDataList(ByVal queryString As String, ByVal theDataList As DataList)

        Dim ConnectString As String = System.Configuration.ConfigurationSettings.AppSettings("ConnectionString")
        Dim MyConnection As SqlConnection = New SqlConnection(ConnectString)
        Try
            MyConnection.Open()

            Dim DBCommand As SqlCommand = New SqlCommand(queryString, MyConnection)
            theDataList.DataSource = DBCommand.ExecuteReader()
            theDataList.DataBind()

        Catch e As Exception
            Throw e

        Finally

            theDataList.Dispose()

            If MyConnection.State = ConnectionState.Open Then
                MyConnection.Close()
            End If

        End Try

    End Function



    <WebMethod()> Public Function deleteAFile(ByVal theFilePath As String, ByVal theFileName As String)
        Dim thePath As String = Server.MapPath(theFilePath) & theFileName
        If System.IO.File.Exists(thePath) Then
            Kill(thePath)
        End If
        thePath = ""
    End Function

    <WebMethod()> Public Function deleteRecord(ByVal queryString As String) As Boolean

        Dim ConnectString As String = System.Configuration.ConfigurationSettings.AppSettings("ConnectionString")
        Dim MyConnection As SqlConnection = New SqlConnection(ConnectString)
        Try
            MyConnection.Open()

            Dim DBCommand As SqlCommand = New SqlCommand(queryString, MyConnection)
            'DBCommand.CommandType = CommandType.StoredProcedure
            DBCommand.ExecuteNonQuery()

            Return True

        Catch e As Exception
            Throw e

        Finally


            If MyConnection.State = ConnectionState.Open Then
                MyConnection.Close()
            End If

        End Try

    End Function
    <WebMethod()> Public Function insertRecord(ByVal queryString As String) As Boolean

        Dim ConnectString As String = System.Configuration.ConfigurationSettings.AppSettings("ConnectionString")
        Dim MyConnection As SqlConnection = New SqlConnection(ConnectString)
        Try
            MyConnection.Open()

            Dim DBCommand As SqlCommand = New SqlCommand(queryString, MyConnection)
            'DBCommand.CommandType = CommandType.StoredProcedure

            DBCommand.ExecuteNonQuery()
            Return True

        Catch e As Exception
            Throw e

        Finally

            If MyConnection.State = ConnectionState.Open Then
                MyConnection.Close()
                End If

        End Try

    End Function
    <WebMethod()> Public Sub ASPNET_MsgBox(ByVal Message As String)

        System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=""JavaScript"">" & vbCrLf)

        System.Web.HttpContext.Current.Response.Write("alert(""" & Message & """)" & vbCrLf)

        System.Web.HttpContext.Current.Response.Write("</SCRIPT>")



    End Sub
    <WebMethod()> Public Function OpenPopUp(ByVal opener As System.Web.UI.WebControls.WebControl, ByVal PagePath As String, ByVal windowName As String, ByVal width As Integer, ByVal height As Integer)
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
    End Function

    <WebMethod()> Public Sub ASPNET_YesNoMessage(ByVal Message As String)


        System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=""JavaScript"">" & vbCrLf)
        System.Web.HttpContext.Current.Response.Write("<input type='button' value='Submit' onclick='temp = window.confirm('")
            System.Web.HttpContext.Current.Response.Write("Message")
        System.Web.HttpContext.Current.Response.Write(">")

    End Sub



    <WebMethod()> Function checkDupblicateRecord(ByVal queryString As String) As Integer
        'return 0 when no record found else there is record exist
        Dim recordCount As Integer
        Dim sqlConnection As SqlConnection
        sqlConnection = New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        Try
            Dim sqlCommand As SqlCommand = New SqlCommand(queryString, sqlConnection)
            sqlConnection.Open()

            recordCount = CInt(sqlCommand.ExecuteScalar())
            Return recordCount
        Catch e As Exception

            Throw e
        Finally
            If sqlConnection.State = ConnectionState.Open Then
                sqlConnection.Close()
            End If

        End Try

    End Function

    <WebMethod()> Public Function loadDropDownList(ByVal queryString As String, ByVal theDropDownList As DropDownList, ByVal dataTextFieldID As String)

        Dim ConnectString As String = System.Configuration.ConfigurationSettings.AppSettings("ConnectionString")
        Dim MyConnection As SqlConnection = New SqlConnection(ConnectString)
        Try
            MyConnection.Open()

            Dim DBCommand As SqlCommand = New SqlCommand(queryString, MyConnection)
            theDropDownList.DataSource = DBCommand.ExecuteReader
            theDropDownList.DataTextField = dataTextFieldID
            theDropDownList.DataValueField = "ID"
            theDropDownList.SelectedIndex = -1

            theDropDownList.DataBind()

            MyConnection.Close()

        Catch e As Exception
            Throw e
        Finally
            If MyConnection.State = ConnectionState.Open Then
                MyConnection.Close()
            End If

        End Try


    End Function

    <WebMethod()> Public Function loadDataGrid(ByVal queryString As String, ByVal theDataGrid As DataGrid)

        Dim ConnectString As String = System.Configuration.ConfigurationSettings.AppSettings("ConnectionString")
        Dim MyConnection As SqlConnection = New SqlConnection(ConnectString)
        Try
            MyConnection.Open()

            Dim DBCommand As SqlCommand = New SqlCommand(queryString, MyConnection)
            theDataGrid.DataSource = DBCommand.ExecuteReader()
            theDataGrid.DataBind()


        Catch e As Exception
            Throw e

        Finally

            theDataGrid.Dispose()

            If MyConnection.State = ConnectionState.Open Then
                MyConnection.Close()
            End If

        End Try

    End Function

    <WebMethod()> Public Function loadDataListTemplate(ByVal queryString As String, ByVal theDataList As DataList) As DataList

        Dim ConnectString As String = System.Configuration.ConfigurationSettings.AppSettings("ConnectionString")
        Dim MyConnection As SqlConnection = New SqlConnection(ConnectString)

        Dim MyCommand As SqlDataAdapter = New SqlDataAdapter(queryString, MyConnection)
        MyCommand.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim DS As DataSet = New DataSet()
        MyCommand.Fill(DS, "Product")

        theDataList.DataSource = DS.Tables("Product").DefaultView
        theDataList.DataBind()


        Return theDataList


    End Function

    <WebMethod()> Public Function getDataSet(ByVal storedProcedure As String) As DataSet

        Dim ConnectString As String = System.Configuration.ConfigurationSettings.AppSettings("ConnectionString")
        Dim MyConnection As SqlConnection = New SqlConnection(ConnectString)

        Dim MyCommand As SqlDataAdapter = New SqlDataAdapter(storedProcedure, MyConnection)
        MyCommand.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim DS As DataSet = New DataSet()
        MyCommand.Fill(DS, "Product")
        Return DS


    End Function

    <WebMethod()> Public Function dropTable(ByVal tableName As String) As Boolean

        Dim ConnectString As String = System.Configuration.ConfigurationSettings.AppSettings("ConnectionString")
        Dim MyConnection As SqlConnection = New SqlConnection(ConnectString)
        Dim str As String

        str = "Select count(*) from sysobjects where name='" & tableName & "'"
        Dim MyCommand As New SqlCommand(str, MyConnection)

        Dim myReader As SqlDataReader
        Try
            MyConnection.Open()

            myReader = MyCommand.ExecuteReader()

            Dim tableExist As Boolean
            tableExist = False

            Do While (myReader.Read())

                If (myReader.GetValue(0).ToString() <> "0") Then
                    Dim j As Integer
                    readyTodropTable(tableName)
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
    End Function

    <WebMethod()> Public Function readyTodropTable(ByVal tableName As String) As Boolean



        Dim ConnectString As String = System.Configuration.ConfigurationSettings.AppSettings("ConnectionString")
        Dim MyConnection As SqlConnection = New SqlConnection(ConnectString)
        Try
            MyConnection.Open()

            Dim str As String

            str = "Drop table dbo." & tableName & ""

            Dim DBCommand As SqlCommand = New SqlCommand(str, MyConnection)
            'DBCommand.CommandType = CommandType.StoredProcedure
            DBCommand.ExecuteNonQuery()

            Return True

        Catch e As Exception
            Throw e

        Finally


            If MyConnection.State = ConnectionState.Open Then
                MyConnection.Close()
            End If

        End Try




    End Function



    <WebMethod()> Public Function BindGridWithSortColumn(ByVal DataGridSearch As DataGrid, ByVal SortField As String, ByVal stringSelectEverything As String, ByVal tableName As String)


        Dim DS As DataSet
        Dim MyCommand As SqlDataAdapter

        Dim ConnectString As String = System.Configuration.ConfigurationSettings.AppSettings("ConnectionString")
        Dim MyConnection As SqlConnection = New SqlConnection(ConnectString)
        Try
            MyConnection.Open()

            MyCommand = New SqlDataAdapter(stringSelectEverything, MyConnection)
            DS = New DataSet()
            MyCommand.Fill(DS, tableName)

            Dim Source As DataView = DS.Tables(tableName).DefaultView
            Source.Sort = SortField

            DataGridSearch.DataSource = Source
            DataGridSearch.DataBind()

        Catch e As Exception
            Throw e

        Finally

            DataGridSearch.Dispose()

            If MyConnection.State = ConnectionState.Open Then
                MyConnection.Close()
            End If

        End Try

    End Function


End Class

End Namespace

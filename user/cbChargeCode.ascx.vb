

Namespace calendar

Partial  Class cbChargeCode
    Inherits System.Web.UI.UserControl
    Protected WithEvents LabelRole As System.Web.UI.WebControls.Label


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

        If Not Page.IsPostBack Then
            ' Save the referrer Url
                'Session("urlstr") = Request.UrlReferrer.AbsoluteUri


                ' Me.DataGridChargeCode.Attributes.Add("onclick", "return confirm('Are you sure you want to delete this item?');")

                'Utilities.CreateConfirmBox(e.Item.ID, "Are you sure your responses are accurate and you are ready so submit this calendar?")
                '  e.Item.Attributes.Add("onclick", "javascript:window.open('ImageGrabber2.aspx?id=" & "','MyPage','height=800, width=800,left=500')")



                Dim oOutPatient As New myWebServices()
                ' oOutPatient.loadDropDownList("Select * from chargeToList order by chargeTo", Me.DropDownListChargeTo, "chargeTo", "ID")


                oOutPatient.loadDataGrid("Select * from investigators order by userName", Me.DataGridChargeCode)


            End If

      

        End Sub
        

        Private Sub loadDataGridChargeCode()
            Dim oOutPatient As New myWebServices()
            oOutPatient.loadDataGrid("Select * from investigators order by userName", Me.DataGridChargeCode)

        End Sub



        Private Sub DataGridChargeCode_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGridChargeCode.EditCommand

            HideMessage()
            Dim userDetail As New CustomerDetails()
            Dim oOutpatient As New myWebServices()
            userDetail = oOutpatient.getCustomerDetail(DataGridChargeCode.DataKeys(CInt(e.Item.ItemIndex)))


            Me.textBoxLoginID.Text = userDetail.UserName

            Me.textBoxLoginID.Enabled = False

            If (userDetail.role = 21) Then
                'Me.DropDownListRole.SelectedItem.Text = "Administrator"
                Me.DropDownListRole.SelectedIndex = 1
                'Me.DropDownListRole.SelectedItem.Value = 21
            ElseIf (userDetail.role = 9) Then
                Me.DropDownListRole.SelectedIndex = 2
                'Me.DropDownListRole.SelectedItem.Text = "User"
                'Me.DropDownListRole.SelectedItem.Value = 9
            End If

            'Me.TextBoxStartDate.Text = userDetail.startDate
            'Me.TextBoxEndDate.Text = userDetail.endDate

            Me.textboxPassword.Text = ""
            Me.textboxPassword2.Text = ""

            Me.ButtonSubmit.Text = "Update"
            Me.LabelID.Text = DataGridChargeCode.DataKeys(CInt(e.Item.ItemIndex))
            loadDataGridChargeCode()








            'Dim deleteStr As String = "DELETE from chargeCode where ID = " & DataGridChargeCode.DataKeys(CInt(e.Item.ItemIndex))
            ' Dim oOutpatient As New myWebService()
            'oOutpatient.deleteRecord(deleteStr)

            're-binding the data to the search result
            'loadDataGridChargeCode()

        End Sub




        Public Sub DataGridChargeCode_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGridChargeCode.DeleteCommand
            HideMessage()
            'Dim strMessage As String
            'strMessage = "are you sure to delete this record?"
            ' Me.DataGridChargeCode_DeleteCommand.Attributes.Add("onclick", "return confirm('" & strMessage & "');")

            'Dim userDetail As New CustomerDetails()
            Dim oOutpatient As New myWebServices()
            ' userDetail = oOutpatient.getCustomerDetail(DataGridChargeCode.DataKeys(CInt(e.Item.ItemIndex)))



            '  If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            'e.Item.Attributes.Add("onclick", "return confirm('Are you sure you want to delete'" & userDetail.UserName & ", " & userDetail.lName & ", " & userDetail.fName & "');")

            'Utilities.CreateConfirmBox(e.Item.ID, "Are you sure your responses are accurate and you are ready so submit this calendar?")
            '  e.Item.Attributes.Add("onclick", "javascript:window.open('ImageGrabber2.aspx?id=" & "','MyPage','height=800, width=800,left=500')")

            '  End If
            Dim deleteStr As String = "DELETE from investigators where ID = " & DataGridChargeCode.DataKeys(CInt(e.Item.ItemIndex))
            oOutpatient.deleteRecord(deleteStr)

            deleteStr = "DELETE from events where userAutoID = " & DataGridChargeCode.DataKeys(CInt(e.Item.ItemIndex))
            oOutpatient.deleteRecord(deleteStr)


            're-binding the data to the search result
            loadDataGridChargeCode()

            lblResult.Text = "User deleted."
            lblResult.CssClass = "successMessage"

        End Sub

        Private Sub DataGridChargeCode_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles DataGridChargeCode.SortCommand
            Dim myString As String
            Dim oOutPatient As New myWebServices()

            HideMessage()

            myString = "select * from investigators"
            oOutPatient.BindGridWithSortColumn(Me.DataGridChargeCode, e.SortExpression, myString, "tempTableSearch")

        End Sub


        Private Sub HideMessage()
            lblResult.Text = ""
        End Sub




        Private Sub ButtonSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSubmit.Click

            Dim oOutPatient As New myWebServices()
            Dim mySQL As String

            HideMessage()

            If (Me.ButtonSubmit.Text = "Submit") Then

                Dim recordReturn As Integer = oOutPatient.checkDupblicateRecord("Select * from investigators where userName='" & Me.textBoxLoginID.Text & "'")

                If recordReturn Then
                    Dim strMessage As String
                    strMessage = "Data can't be saved!  Login ID already exists! Please use a different Login ID."


                    'finishes server processing, returns to client.
                    Dim strScript As String = "<script language=JavaScript>"
                    strScript += "alert(""" & strMessage & """);"
                    strScript += "</script>"

                    If (Not Page.IsStartupScriptRegistered("clientScript")) Then
                        Page.RegisterStartupScript("clientScript", strScript)
                    End If
                Else

                    mySQL = "insert into investigators (userName, password,role)  values (" & _
                  "'" & Me.textBoxLoginID.Text & "'," & _
                   "'" & Me.textboxPassword.Text & "'," & _
                   "" & Me.DropDownListRole.SelectedItem.Value & ")"



                    oOutPatient.insertRecord(mySQL)
                    lblResult.Text = "User saved successfully."
                    lblResult.CssClass = "successMessage"

                End If


            Else

                If (Me.textboxPassword.Text <> "") Then
                    mySQL = "update investigators set " & _
                                        " password= '" & Me.textboxPassword.Text & "'," & _
                                       " role= " & Me.DropDownListRole.SelectedItem.Value & " where ID=" & Me.LabelID.Text
                    '" startDate= '" & Me.TextBoxStartDate.Text & "'," & _
                    '" endDate= '" & Me.TextBoxEndDate.Text & "'," & _
                Else
                    mySQL = "update investigators set " & _
                        " role= " & Me.DropDownListRole.SelectedItem.Value & " where ID=" & Me.LabelID.Text
                    '" startDate= '" & Me.TextBoxStartDate.Text & "'," & _
                    '" endDate= '" & Me.TextBoxEndDate.Text & "'," & _



                End If




                oOutPatient.insertRecord(mySQL)
                loadDataGridChargeCode()

                lblResult.Text = "User saved successfully."
                lblResult.CssClass = "successMessage"

                Response.Redirect(Request.Url.ToString(), False) ' will include the querystring


                Me.ButtonSubmit.Text = "Submit"






            End If
            'Response.Redirect(Session("urlstr"))

            oOutPatient.loadDataGrid("Select * from investigators order by userName", Me.DataGridChargeCode)




        End Sub


        Protected Sub DataGridChargeCode_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DataGridChargeCode.ItemCreated
            If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = _
                    ListItemType.AlternatingItem Then
                ' get a reference to the LinkButton of this row,
                '  and add the javascript confirmation
                Dim lnkDelete As LinkButton = CType(e.Item.Cells(1).Controls(0),  _
                    LinkButton)
                lnkDelete.Attributes.Add("onclick", _
                    "return confirm('Are you sure you want to delete this record?');")

                ' get a reference to the Button of this row,
                '  and add the javascript confirmation
                'Dim btnDelete As Button = CType(e.Item.Cells(1).Controls(0), Button)
                'btnDelete.Attributes.Add("onclick", _
                '    "return confirm('Are you sure you want to delete this record?');")
            End If

        End Sub
    End Class

End Namespace

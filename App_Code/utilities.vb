
Namespace calendar

Public Class Utilities
    Public Shared Sub CreateConfirmBox(ByRef btn As WebControls.Button, ByVal strMessage As String)
        btn.Attributes.Add("onclick", "return confirm('" & strMessage & "');")
    End Sub

    Public Shared Sub CreateMessageAlert(ByRef aspxPage As System.Web.UI.Page, _
                              ByVal strMessage As String, ByVal strKey As String)
        Dim strScript As String = "<script language=JavaScript>alert('" _
                                            & strMessage & "')</script>"

        If (Not aspxPage.IsStartupScriptRegistered(strKey)) Then
            aspxPage.RegisterStartupScript(strKey, strScript)
        End If
    End Sub







End Class

End Namespace




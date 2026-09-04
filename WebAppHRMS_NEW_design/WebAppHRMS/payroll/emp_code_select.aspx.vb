Imports System.Data
Imports System.Data.OracleClient
Partial Class Old_New_EmpCode_emp_code_select_a34986ae4223
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "To Find Regularised Employees in a given period"

        Dim script_val2 As String
        script_val2 = "var sal;" & "sal='" & "" & Me.Txt_EmpCode.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val2, True)


    End Sub

    Protected Sub Cmd_Confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Confirm.Click

        If Me.Check_EmpCode.Checked = True Then
            Me.Server.Transfer("oldandnewemployeereport.aspx?empcode=" & Me.Txt_EmpCode.Text)
        ElseIf Me.Check_EmpCode.Checked = False Then
            Me.Server.Transfer("oldandnewemployeereport.aspx?regdatefrom=" & Me.Txt_From.Text & "&regdateto=" & Me.Txt_To.Text & "&empcode=" & 0)
        End If

    End Sub
End Class

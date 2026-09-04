
Partial Class special_allowance_special_main_report_1e1122af6436
    Inherits System.Web.UI.Page

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Dim rdb As Integer = 0
        If Me.rdb_am.Checked = True Then
            rdb = 0
        ElseIf Me.rdb_bh.Checked = True Then
            rdb = 1
        ElseIf Me.rdb_abh.Checked = True Then
            rdb = 2
        Else
            rdb = 3
        End If
        Me.Response.Redirect("rpt_special_main_report.aspx?rdb=" & rdb)

    End Sub
End Class

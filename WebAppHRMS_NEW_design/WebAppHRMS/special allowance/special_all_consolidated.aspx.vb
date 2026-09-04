
Partial Class special_allowance_special_all_consolidated_880ed2b57596
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
        Me.Response.Redirect("rpt_summer_all_consolidated.aspx?rdb=" & rdb)

    End Sub
End Class

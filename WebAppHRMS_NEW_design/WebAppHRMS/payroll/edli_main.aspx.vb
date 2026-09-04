
Partial Class EDLI_edli_main_056275936263
    Inherits System.Web.UI.Page

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Me.Response.Redirect("rpt_edli.aspx?firm=" & Me.rdb_firm.SelectedValue & "&rpt=" & Me.rdb_rpt.SelectedValue)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("access_id") <> 33 Then
            Server.Transfer("../show_err.aspx")
        End If

    End Sub
End Class

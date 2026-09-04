
Partial Class grtuity_gratuity_main_2a148bdc5282
    Inherits System.Web.UI.Page

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Me.Response.Redirect("rpt_gratuity.aspx?firm=" & Me.cmb_firm.SelectedValue & "&report=" & Me.rdb_report.SelectedValue)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("access_id") <> 33 Then
            Server.Transfer("../show_err.aspx")
        End If

    End Sub
End Class

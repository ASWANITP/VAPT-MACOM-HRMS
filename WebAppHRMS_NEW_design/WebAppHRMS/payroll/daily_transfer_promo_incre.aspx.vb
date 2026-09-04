
Partial Class report_daily_transfer_promo_incre_561a18014069
    Inherits System.Web.UI.Page

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        If (Me.cmb_cat.SelectedValue = 1) Then
            Me.Server.Transfer("daily_tra_pro_inc_display.aspx?fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&cat=" & Me.cmb_cat.SelectedValue)
        End If
        If (Me.cmb_cat.SelectedValue = 2) Then
            Me.Server.Transfer("daily_tra_pro_inc_display.aspx?fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&cat=" & Me.cmb_cat.SelectedValue)
        End If
        If (Me.cmb_cat.SelectedValue = 3) Then
            Me.Server.Transfer("daily_tra_pro_inc_display.aspx?fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&cat=" & Me.cmb_cat.SelectedValue)
        End If
    End Sub

    Protected Sub cmd_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_exit.Click
        'Server.Transfer("../home.aspx")
        Response.Redirect("../home.aspx")
    End Sub
End Class

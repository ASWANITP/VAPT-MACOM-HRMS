Imports System.Data
Imports System.Data.OracleClient
Partial Class jwellary_reports_jewel_exp_91c29d5c2707
    Inherits System.Web.UI.Page
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.rb_1.Checked = True Then
            Response.Redirect("jewel_exp1.aspx")
        ElseIf Me.rb_2.Checked = True Then
            Response.Redirect("others_exp1.aspx")
        End If
    End Sub

    Protected Sub rb_2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rb_2.CheckedChanged

    End Sub
End Class

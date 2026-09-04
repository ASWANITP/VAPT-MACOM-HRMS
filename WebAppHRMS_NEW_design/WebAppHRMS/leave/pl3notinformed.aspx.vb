Imports system.data
Imports System.Data.OracleClient
Partial Class pl3absent_pl3notinformed_203cb4e91065
    Inherits System.Web.UI.Page

    Protected Sub cmd_confrim_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confrim.Click
        Server.Transfer("pl3absent.aspx?fdate=" & Me.Txt_fdate.Text & "")
    End Sub

    Protected Sub cmd_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_exit.Click
        Server.Transfer("../home.aspx")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Txt_fdate.Text = Format(Date.Today, "dd/MMM/yyyy")
    End Sub
End Class

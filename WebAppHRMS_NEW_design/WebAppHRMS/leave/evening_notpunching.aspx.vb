Imports System.Data
Imports System.Data.OracleClient
Partial Class evening_notpunching_373f330f3842
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_report.Click
        Me.Server.Transfer("rpt_eveningnotpunching.aspx?fr_dt=" & Me.txt_dt.Text)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class

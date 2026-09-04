Imports System.Data
Imports System.Data.OracleClient
Partial Class new_resign_report_ce2dc8ce8153
    Inherits System.Web.UI.Page

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        If CDate(Me.Txt_fdt.Text) >= CDate(Me.Txt_tdt.Text) Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("        alert('From Date is greater than To Date!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Else
            Server.Transfer("resign_view_report.aspx?fdt='" & Me.Txt_fdt.Text & "'&tdt='" & Me.Txt_tdt.Text & "'")

        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class

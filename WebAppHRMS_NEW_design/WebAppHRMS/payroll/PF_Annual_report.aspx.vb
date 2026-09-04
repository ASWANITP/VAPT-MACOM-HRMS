Imports System.Data
Imports System.Data.OracleClient
Partial Class PF_REPORT_PF_Annual_report_64f89fd46138
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.oraclehelper
    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        If Me.rdb_rpt.SelectedValue = 1 Then
            Me.Response.Redirect("pfform3a_crpt.aspx?firm=" & Me.rdb_firm.SelectedValue)
        ElseIf Me.rdb_rpt.SelectedValue = 2 Then
            Me.Response.Redirect("pfform6a_crpt.aspx?firm=" & Me.rdb_firm.SelectedValue)
        ElseIf Me.rdb_rpt.SelectedValue = 24 Then
            Me.Response.Redirect("pfform3a_crpt.aspx?firm=" & Me.rdb_firm.SelectedValue)
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Session("access_id") <> 33 Then
        '    Server.Transfer("../show_err.aspx")
        'End If

    End Sub
End Class

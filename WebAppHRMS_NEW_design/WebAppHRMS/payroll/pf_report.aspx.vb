Imports System.Data
Imports System.Data.OracleClient
Partial Class PF_REPORT_pf_report_3682a8bf1124
    Inherits System.Web.UI.Page
    Dim dt3 As String
    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        If CDate(Me.txt_pay_month.Text) > Now.Date Then
            Dim script1 As New System.Text.StringBuilder
            script1.Append("        alert('Sorry, You Cant View Coming Months Report');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        End If
        If Me.rdb_rpt.SelectedValue = 1 Then
            Me.Response.Redirect("pf_form5.aspx?firm=" & Me.rdb_firm.SelectedValue & "&dt=" & Me.txt_pay_month.Text)
        ElseIf Me.rdb_rpt.SelectedValue = 2 Then
            Me.Response.Redirect("pf_form10.aspx?firm=" & Me.rdb_firm.SelectedValue & "&dt=" & Me.txt_pay_month.Text)
        ElseIf Me.rdb_rpt.SelectedValue = 3 Then
            Me.Response.Redirect("PF_statement.aspx?firm=" & Me.rdb_firm.SelectedValue & "&dt=" & Me.txt_pay_month.Text)
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("access_id") <> 33 Then
                Server.Transfer("../show_err.aspx")
            End If
            Me.txt_pay_month.Text = Format(Now.Date, "MMM/yyyy")
        End If
    End Sub
End Class

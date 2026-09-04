Imports System.Data
Imports System.Data.OracleClient
Partial Class daily_joinning_report_daily_join1_fe4f0c149919
    Inherits System.Web.UI.Page
    Dim dt1 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim UserAll(), res, sql, str As String
    Dim UserCode, stat As Integer
    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn As New System.Text.StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'UserAll = Me.Session("user_id").ToString.Split("!")
        'UserCode = UserAll(0)

        'Dim emno As Integer = oh.ExecuteDataSet("select count(e.RECRUITMENT_OFFICER)  from zonal_master e,employee_master t where t.emp_code=e.RECRUITMENT_OFFICER and  t.emp_code = " & UserCode & "").Tables(0).Rows(0)(0)
        'If emno = 0 Then
        '    str_tkn.Append("         alert('You are not authorized...!');")
        '    str_tkn.Append(" window.open('../Home.aspx','_self');")
        '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
        'Else

        'End If

    End Sub

    Protected Sub btn_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_confirm.Click
        Dim fdt As String = Me.txt_fromdate.Text
        Dim tdt As String = Me.txt_todate.Text

        Server.Transfer("joinrpt.aspx?fdt='" & Me.txt_fromdate.Text & "'&tdt='" & Me.txt_todate.Text & "'")
    End Sub


End Class

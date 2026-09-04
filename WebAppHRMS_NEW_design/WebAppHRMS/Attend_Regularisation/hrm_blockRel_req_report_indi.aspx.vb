Imports System.Data
Imports System.Data.OracleClient
Partial Class Block_Release_Request_hrm_blockRel_req_report_indi_66fa57f65075
    Inherits System.Web.UI.Page
    Dim cbResult As String
    Dim oh As New helper.oracle.OracleHelper
    Dim dt, dt1, dt2 As New DataTable
    Dim UserAll(), BranchAll(), res, sql, str As String
    Dim UserCode, BranchId As Integer
    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn As New System.Text.StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "Block Release Request Status Report"
        Dim user() As String
        user = Session("user_id").ToString.Split("!")
        Dim fid As Integer = 542
        Dim dt As Integer = oh.ExecuteDataSet("select count(*) from form_accessibility f where f.form_id=542 and f.emp_id=" & user(0) & "").Tables(0).Rows(0)(0)
        If dt = 0 Then
            Me.Server.Transfer("../show_err.aspx")
        End If
        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txtFdate.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
    End Sub

    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        Server.Transfer("hrm_blockRel_req_Cryrpt.aspx?Fdt=" & txtFdate.Text & "&Tdt=" & Me.txtTdate.Text & "&eid=" & Me.txtcode.Text)
    End Sub
End Class

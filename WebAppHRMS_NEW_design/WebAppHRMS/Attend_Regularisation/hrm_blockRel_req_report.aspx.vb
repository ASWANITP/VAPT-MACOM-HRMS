Imports System.Data
Imports System.Data.OracleClient
Partial Class Block_Release_Request_hrm_blockRel_req_report_691c9a804480
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

        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txtFdate.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
    End Sub

    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        Server.Transfer("hrm_blockRel_req_Cryrpt.aspx?Fdt=" & txtFdate.Text & "&Tdt=" & Me.txtTdate.Text)
    End Sub
End Class

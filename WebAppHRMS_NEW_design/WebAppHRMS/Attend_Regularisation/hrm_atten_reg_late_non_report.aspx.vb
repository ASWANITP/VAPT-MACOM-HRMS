Imports System.Data
Imports System.Data.OracleClient
Partial Class Attentance_Reg_Comb_Report_hrm_atten_reg_late_non_report_7e50fe613885
    Inherits System.Web.UI.Page
    Dim cbResult As String
    Dim oh As New helper.oracle.OracleHelper
    Dim dt, dt1, dt2 As New DataTable
    Dim UserAll(), BranchAll(), res, sql, str As String
    Dim UserCode, BranchId As Integer
    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn As New System.Text.StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        CType(Me.Master, WebAppHRMS.edp).Subtitle = "Attendance Regularization Report"

        'BranchAll = Me.Session("branch_id").ToString.Split("!")
        'BranchId = BranchAll(0)

        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txtFdate.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
    End Sub

    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click

        Server.Transfer("hrm_atten_reg_late_non_Cryrpt.aspx?Fdt=" & txtFdate.Text & "&Tdt=" & Me.txtTdate.Text)

    End Sub
End Class

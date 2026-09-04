Imports System.Data
Imports System.Data.OracleClient
Partial Class Resigned_Emp_hrm_resined_emp_report_c30b36db6006
    Inherits System.Web.UI.Page
    Dim cbResult As String
    Dim oh As New helper.oracle.OracleHelper
    Dim dt, dt1, dt2 As New DataTable
    Dim UserAll(), BranchAll(), res, sql, str As String
    Dim UserCode, BranchId As Integer
    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn As New System.Text.StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "Resigned Employees List"

        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txtFdate.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

    End Sub

    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click

        If Session("firm_id") <> 8 Then
            Server.Transfer("hrm_resined_emp_Cryrpt.aspx?Fdt=" & txtFdate.Text & "&Tdt=" & Me.txtTdate.Text)
        Else
            Server.Transfer("hrm_resined_emp_Cryrpt_mac.aspx?Fdt=" & txtFdate.Text & "&Tdt=" & Me.txtTdate.Text)
        End If
    End Sub
End Class

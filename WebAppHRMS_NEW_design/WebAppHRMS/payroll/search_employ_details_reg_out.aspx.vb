Imports System.Data
Imports System.Data.OracleClient
Partial Class december_search_report_search_employ_details_reg_out_29ccd4071719
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1 As New DataTable
    Dim st As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cs As String = "var cont_name;cont_name='" & Me.Txt_exp.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)
    End Sub

    Protected Sub Cmd_Confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Confirm.Click
        If (Me.Chk_exp.Checked = True) Then
            st = 0
        Else
            st = 1
        End If
        Dim script1 As New System.Text.StringBuilder
        script1.Append("window.open('search_report_employ_details_reg_out_disp.aspx?opt=" & Me.Cmb_Cate.SelectedValue & "&exp=" & Me.Txt_exp.Text & "&sta=" & st & "','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
    End Sub
End Class

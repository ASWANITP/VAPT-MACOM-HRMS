Imports System.Data
Imports System.Data.OracleClient
Partial Class promotiondetails_promotion_report_e2d934685201
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            dt = oh.ExecuteDataSet("select emp_code||'---'||emp_name,emp_code from employee_master where emp_code > 9999 order by emp_code ").Tables(0)
            Me.cmb_select.DataSource = dt
            Me.cmb_select.DataTextField = dt.Columns(0).ColumnName
            Me.cmb_select.DataValueField = dt.Columns(1).ColumnName
            Me.cmb_select.DataBind()
            Me.Txt_tdt.Text = Format(Date.Today, "dd/MMM/yyyy")
        End If
    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Server.Transfer("promotion_display_report.aspx?emp=" & Me.cmb_select.SelectedValue & "&f_dt=" & Me.txt_fdt.Text & "&t_dt=" & Me.txt_tdt.Text)
    End Sub

    Protected Sub cmd_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_exit.Click
        Server.Transfer("../home.aspx")
    End Sub
End Class

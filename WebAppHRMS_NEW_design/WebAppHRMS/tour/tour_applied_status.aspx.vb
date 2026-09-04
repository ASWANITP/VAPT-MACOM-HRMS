Imports System.Data
Imports System.Data.OracleClient

Partial Class tour_cancellation_tour_applied_status_da0288ba1432
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim user() As String
            user = Session("user_id").ToString.Split("!")

            Dim sql As String = "select distinct e.emp_code,e.emp_code|| ' - ' ||e.emp_name from Hrm_tour_dtl el,employee_master e where e.emp_code=el.emp_code and e.emp_code=" & user(0)

            Dim dt As DataTable = oh.ExecuteDataSet(sql).Tables(0)
            If dt.Rows.Count > 0 Then
                Me.cmb_code.DataSource = dt
                Me.cmb_code.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_code.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_code.DataBind()
                Me.txt_from.Text = Format(CDate("15 / aug / 1947"), "dd/MMM/yyyy")
                Me.txt_to.Text = Format(Now.Date, "dd/MMM/yyyy")
            End If

        End If
    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Me.Response.Redirect("rpt_tour_applied_status.aspx?empcode=" & Me.cmb_code.SelectedValue & "&fromdt=" & Me.txt_from.Text & "&todt=" & Me.txt_to.Text)

    End Sub
End Class

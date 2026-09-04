Imports System.Data
Imports System.Data.OracleClient
Partial Class leave_rec_res_ho_d1b5f1c72471
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.hids.Value = Request.QueryString("code")
        dt = oh.ExecuteDataSet("select emp_name from employee_master where emp_code=" & Request.QueryString("code") & "").Tables(0)
        Me.labs.Text = "<u>" + dt.Rows(0)(0) + "</u>" + " IS IN LONG LEAVE/MATERNITY STATUS, PLEASE FILL END DATE"
    End Sub
End Class

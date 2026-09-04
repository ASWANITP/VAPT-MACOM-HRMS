Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data.OracleClient

Public Class punching_module_date
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dtn, dtn1, dt2, dt3, st As New DataTable
    Dim sf(), sf1(), sf2(), app, rec, frm, dm As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            sf = Session("user_id").ToString.Split("!")
            dt3 = oh.ExecuteDataSet("select count(*) from employee_master t where t.emp_code=" & sf(0) & " and t.department_id in (546,1050) and t.firm_id=8 and t.status_id=1").Tables(0)
            If dt3.Rows(0)(0) = 0 Then

                Me.Response.Redirect("../show_err.aspx")
            End If
        End If

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Session("user_id") Is Nothing Then
            Response.Write("Session expired. Please log in again.")
            Return
        End If

        Dim sf() As String = Session("user_id").ToString().Split("!")
        Dim empCode As String = sf(0)

        Dim fromDate As String = If(String.IsNullOrEmpty(txtFromDate.Value), DateTime.Now.ToString("yyyy-MM-dd"), txtFromDate.Value)
        Dim toDate As String = If(String.IsNullOrEmpty(txtToDate.Value), DateTime.Now.ToString("yyyy-MM-dd"), txtToDate.Value)

        Response.Redirect("punching_module_report.aspx?fdt=" & fromDate & "&tdt=" & toDate & "&emp=" & empCode)
    End Sub
End Class
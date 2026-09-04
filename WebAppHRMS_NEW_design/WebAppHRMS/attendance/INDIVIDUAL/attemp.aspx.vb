Imports System.Data
Imports system.data.oracleclient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Partial Class specificempattend_attemp_3dee93787669
    Inherits System.Web.UI.Page
    Dim report As New ReportDocument
    Dim fdt, tdt, emp, sql, sql1 As String
    Dim dt, dt1 As DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    'Dim f(), t(), e() As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        fdt = Request.QueryString.Get("fdt")
        tdt = Request.QueryString.Get("tdt")
        emp = Request.QueryString.Get("emp")

        sql = "select a.emp_code,a.emp_name,(b.branch_name) as branch_name,to_char(c.curr_date) as curr_date,c.m_time,(d1.branch_name) as m_branch,c.e_time,(d2.branch_name) as e_branch from employee_master a,branch_master b,ATTENDANCE c,branch_master d1,branch_master d2 where a.emp_code=c.emp_code and c.emp_code=" & emp & " and b.branch_id=c.branch_id and c.m_branch=d1.branch_id and c.e_branch=d2.branch_id and to_date(c.curr_date) between '" & fdt & "' and '" & tdt & "' order by c.curr_date"
        dt = oh.ExecuteDataSet(sql).Tables(0)
        report.Load(Server.MapPath("empatte.rpt"), OpenReportMethod.OpenReportByTempCopy)
        report.SetDataSource(dt)
        sql1 = "select emp_name from employee_master where emp_code=" & emp & ""
        dt1 = oh.ExecuteDataSet(sql1).Tables(0)
        report.SetParameterValue("head", "ATTENDANCE REPORT OF " & dt1.Rows(0)(0) & " FROM " & fdt & " to " & tdt)
        Me.CrystalReportViewer1.ReportSource = report

    End Sub

    Protected Sub CrystalReportViewer1_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Unload
        report.Dispose()
    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Close()
        report.Dispose()
        GC.Collect()
    End Sub
End Class

Imports System.Data
Imports system.data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Class rpt_eveningnotpunching_8aa22e105462
    Inherits System.Web.UI.Page
    Dim report As New ReportDocument
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As DataTable
        Dim str As String
        str = "select b1.branch_name,a1.emp_code,e.emp_name,a1.m_time,b2.branch_name as m_branch from attend a1,employee_master e,branch_master b1,branch_master b2 where a1.branch_id=b1.branch_id and a1.emp_code=e.emp_code and a1.m_branch=b2.branch_id and a1.shift_id not in(4,5) and a1.e_time is null and a1.m_time is not null and a1.curr_date='" & Request.QueryString("fr_dt") & "' order by a1.emp_code"
        dt = oh.ExecuteDataSet(str).Tables(0)
        report.Load(Server.MapPath("Crptevenotpunching.rpt"), OpenReportMethod.OpenReportByTempCopy)
        report.SetDataSource(dt)
        report.SetParameterValue(0, "NOT PUNCHED IN " & Request.QueryString("fr_dt") & " (EVENING)")
        Me.CrystalReportViewer1.ReportSource = report
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Close()
        report.Dispose()
        GC.Collect()
    End Sub

End Class

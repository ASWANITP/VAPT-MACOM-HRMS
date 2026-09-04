Imports System.Data
Imports system.data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Class rpt_eveningnotpunching_6356f85e6280
    Inherits System.Web.UI.Page
    Dim report As New ReportDocument
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As DataTable
        Dim str As String
        str = "select b.branch_name,a1.emp_code,e.emp_name,a1.m_time,b.branch_name as m_branch from attend a1,employee_master e,branch_master b where a1.branch_id=b.branch_id and a1.emp_code=e.emp_code and a1.m_branch=b.branch_id and a1.shift_id not in(4,5) and a1.status_id<>34 and a1.e_time is null and a1.m_time is not null and a1.curr_date='" & Request.QueryString("fr_dt") & "' order by a1.emp_code"
        dt = oh.ExecuteDataSet(str).Tables(0)
        report.Load(Server.MapPath("Crptevenotpunching.rpt"), OpenReportMethod.OpenReportByTempCopy)
        report.SetDataSource(dt)
        Me.CrystalReportViewer1.ReportSource = report
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Dispose()
        GC.Collect()
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Server.Transfer("evening_notpunching.aspx")
    End Sub
End Class

Imports system.data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Partial Class daily_joinning_report_joinrpt_a38345da6849
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim crSections As Sections
    Dim report As New ReportDocument
    Dim UserAll(), BranchAll() As String
    Dim UserCode, BranchId As Integer
    Dim dt2 As DataTable
    Dim export As New IO.MemoryStream

    Protected Sub Page_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        report.Dispose()
        report.Close()
        GC.Collect()
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '  dt2 = oh.ExecuteDataSet("select e.emp_code,       e.emp_name,       e.branch_id,       b.BRANCH_NAME,       p.post_name,       d.designation,       dp.dep_name,       e.join_dt        from employee_master e,       branch_dtl_new  b,       post_mst        p,       designation_mst d,       department_mst  dp where e.branch_id = b.BRANCH_ID   and e.post_id = p.post_id   and e.designation_id = d.designation_id   and e.department_id = dp.dep_id   and e.status_id =1 and e.branch_id=0 and e.join_dt between " & Me.Request.QueryString("fdt") & " and  " & Me.Request.QueryString("tdt") & "").Tables(0)

        dt2 = oh.ExecuteDataSet("select e.emp_code,       e.emp_name,       e.branch_id,       b.BRANCH_NAME,       p.post_name,       d.designation,       dp.dep_name,       e.join_dt        from employee_master e,       branch_dtl_new  b,       post_mst        p,       designation_mst d,       department_mst  dp, employ_firm ef where e.branch_id = b.BRANCH_ID   and e.post_id = p.post_id   and e.designation_id = d.designation_id   and e.department_id = dp.dep_id    and e.emp_code = ef.emp_code and ef.firm_id = '" & Session("firm_id") & "'   and e.status_id =1 and e.branch_id=0 and e.join_dt between " & Me.Request.QueryString("fdt") & " and  " & Me.Request.QueryString("tdt") & "").Tables(0)
        report.Load(Server.MapPath("joinCrystalReport.rpt"), OpenReportMethod.OpenReportByTempCopy)
        report.Database.Tables("join_detail").SetDataSource(dt2)
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.ReportSource = report

    End Sub



    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Dispose()
        report.Close()
        GC.Collect()
    End Sub
End Class

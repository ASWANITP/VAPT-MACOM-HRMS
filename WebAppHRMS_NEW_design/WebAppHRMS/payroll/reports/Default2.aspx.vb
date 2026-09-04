Imports System.Data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Partial Class jwellary_reports_Default1_07ae44501044
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim oh As New helper.oracle.OracleHelper
    Dim report As New ReportDocument
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim emp As Integer = Request.QueryString("e_code")
        dt = oh.ExecuteDataSet("select e.emp_code as ecode,       e.emp_name as ename,       p.post_name as post,       dm.designation as designatin,       dp.dep_name as department,       case         when et.to_dt is not null then          (to_date(et.to_dt) - to_date(et.from_dt))         else          (to_date(sysdate) - to_date(et.from_dt))       end as exep  from employee_master     e,       employ_transfer_dtl et,       post_mst            p,       designation_master  dm,       department_mst      dp where e.emp_code = et.emp_code   and et.post_id = p.post_id  and e.designation_id = dm.designation_id  and e.department_id = dp.dep_id   and et.department_id in       (select distinct d.dep_id          from employee_master e, department_mst d         where '' || d.dep_name || '' like '%' || 'JEWEL' || '%'           and e.department_id = d.dep_id)   and e.status_id = 1   and e.branch_id not in (0) and e.emp_code='" & emp & "'").Tables(0)
        report.Load(Server.MapPath("other2_dtls.rpt"), OpenReportMethod.OpenReportByTempCopy)
        report.Database.Tables("ho_exp_dtls").SetDataSource(dt)
        Me.CrystalReportViewer1.ReportSource = report
        report.SetParameterValue("firm", "MANAPPURAM GROUP OF COMPANIES")
        report.SetParameterValue("firm1", "MAJEWEL  EMPLOYEES EXPERIENCE")
    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Dispose()
        report.Close()
        GC.Collect()
    End Sub
End Class

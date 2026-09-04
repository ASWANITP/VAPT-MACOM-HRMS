Imports System.Data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Partial Class jwellary_reports_jewel_exp1_dd8cb6717767
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim oh As New helper.oracle.OracleHelper
    Dim report As New ReportDocument
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '  dt = oh.ExecuteDataSet("select x.ecode, x.ename, x.post, x.designatin, x.department, sum(x.exep) as exp  from (select e.emp_code as ecode,               e.emp_name as ename,               p.post_name as post,               dm.designation as designatin,               dp.dep_name as department,               case                 when et.to_dt is not null   then                  (to_date(et.to_dt) - to_date(et.from_dt))                 else                  (to_date(sysdate) - to_date(et.from_dt))               end as exep          from employee_master     e,               employ_transfer_dtl et,               post_mst            p,               designation_master  dm,               department_mst      dp         where e.emp_code = et.emp_code           and e.post_id = p.post_id           and e.designation_id = dm.designation_id           and e.department_id = dp.dep_id           and et.department_id in (select distinct d.dep_id  from employee_master e, department_mst d where '' || d.dep_name || '' like '%' || 'JEWEL' || '%' and e.department_id=d.dep_id)           and e.status_id = 1) x,       employee_master e where e.emp_code = x.ecode and e.department_id in (select distinct d.dep_id   from department_mst d where '' || d.dep_name || '' like '%' || 'JEWEL' || '%') and e.branch_id in (0) group by x.ecode, x.ename, x.post, x.designatin, x.department  order by x.ecode").Tables(0)
        dt = oh.ExecuteDataSet("select x.ecode,  x.ename,  x.post,  x.designatin,  x.department,  sum(x.exep) as exp  from (select e.emp_code as ecode,  e.emp_name as ename,  p.post_name as post,  dm.designation as designatin,  dp.dep_name as department,  case  when et.to_dt is not null then  (to_date(et.to_dt) - to_date(et.from_dt))  else  (to_date(sysdate) - to_date(et.from_dt))  end as exep  from employee_master     e,  employ_transfer_dtl et,  post_mst            p,  designation_master  dm,  department_mst      dp, employ_firm f  where e.emp_code = et.emp_code  and e.emp_code=f.emp_code  and f.firm_id=" & Session("firm_id") & "  and e.post_id = p.post_id  and e.designation_id = dm.designation_id  and e.department_id = dp.dep_id  and e.status_id = 1) x,  employee_master e  where e.emp_code = x.ecode  and e.branch_id in (0)  group by x.ecode, x.ename, x.post, x.designatin, x.department  order by x.ecode").Tables(0)
        report.Load(Server.MapPath("h.o_jewel.rpt"), OpenReportMethod.OpenReportByTempCopy)
        report.Database.Tables("ho_exp").SetDataSource(dt)
        Me.CrystalReportViewer1.ReportSource = report
        '    report.SetParameterValue("firm", "MANAPPURAM GROUP OF COMPANIES")
        report.SetParameterValue("FIRM", Session("firm_name"))


        '  report.SetParameterValue("firm1", "MAJEWEL  EMPLOYEES EXPERIENCE")
    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Dispose()
        report.Close()
        GC.Collect()
    End Sub
End Class

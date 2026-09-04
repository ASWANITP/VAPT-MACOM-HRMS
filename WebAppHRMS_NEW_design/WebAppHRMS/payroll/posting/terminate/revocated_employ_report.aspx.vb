Imports System.Data
Imports System.Data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Class majewel_suspention_mjewel_susp_report_6f3800735960
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim dt As New DataTable
    Dim rep As New ReportDocument
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'dt = oh.ExecuteDataSet("select distinct t.emp_code,t.emp_name NAME,b.BRANCH_NAME BRANCH,p.post_name POST,d.designation,ep.susp_rmrk as Reason, em.discont_dt Discontinue,to_date(sysdate) - to_date(em.discont_dt) AS DAYS  from employee_master  t, employ_promotion_dtl ep,  designation_master   d, employee_master_dtl  em,  branch_dtl_new   b, post_mst  p where t.department_id in   (select d.dep_id          from department_mst d         where '' || d.dep_name || '' like '%' || 'MAJE' || '%')   and t.status_id = 4   and t.emp_code = ep.emp_code   and t.designation_id = d.designation_id   and t.emp_code = em.emp_code   and p.post_id = t.post_id   and t.branch_id = b.BRANCH_ID   and ep.status_id = 4   and ep.emp_code = em.emp_code and t.emp_code=" & Me.Request.QueryString("fdt") & " ").Tables(0)

        'dt = oh.ExecuteDataSet("select distinct t.emp_code,                t.emp_name NAME,                b.BRANCH_NAME BRANCH,                p.post_name POST,                d.designation,                ep.susp_rmrk as Reason,                em.discont_dt Discontinue,                to_date(sysdate) - to_date(em.discont_dt) AS DAYS  from employee_master      t,       employ_promotion_dtl ep,       designation_master   d,       employee_master_dtl  em,       branch_master        b,       post_mst             p where t.department_id in       (select d.dep_id          from department_mst d         where '' || d.dep_name || '' like '%' || 'JEWE' || '%')   and t.status_id = 4   and t.emp_code = ep.emp_code   and t.designation_id = d.designation_id   and t.emp_code = em.emp_code   and p.post_id = t.post_id   and t.branch_id = b.BRANCH_ID   and ep.status_id = 4   and ep.emp_code = em.emp_code and  t.emp_code=" & Me.Request.QueryString("fdt") & " ").Tables(0)
        'dt = oh.ExecuteDataSet("select distinct e.emp_code,       e.emp_name,       p.post_name,       d.designation,       dp.dep_name, E.JOIN_DT,     a.revoke_rmrk as reason,     a.to_dt as revocated  from employ_promotion_dtl a,       employee_master      e,       post_mst             p,       designation_master   d,      department_mst       dp where a.emp_code=e.emp_code   and e.post_id = p.post_id  and e.designation_id = d.designation_id   and dp.dep_id = e.department_id  and a.revoke_rmrk is not null  and a.from_dt between  " & Me.Request.QueryString("fdt") & "" & Me.Request.QueryString("tdt") & " ").Tables(0)
        dt = oh.ExecuteDataSet("select distinct e.emp_code,       e.emp_name,       p.post_name,       d.designation,       dp.dep_name, E.JOIN_DT,     a.revoke_rmrk as reason,     a.to_dt as revocated  from employ_promotion_dtl a,       employee_master      e,       post_mst             p,       designation_master   d,      department_mst       dp, employ_firm ef  where a.emp_code=e.emp_code   and e.post_id = p.post_id  and e.emp_code = ef.emp_code  and ef.firm_id = " & Session("firm_id") & "  and e.designation_id = d.designation_id   and dp.dep_id = e.department_id  and a.revoke_rmrk is not null  and a.from_dt between  " & Me.Request.QueryString("fdt") & "" & Me.Request.QueryString("tdt") & " ").Tables(0)
        rep.Load(Server.MapPath("revocat_emp.rpt"), OpenReportMethod.OpenReportByTempCopy)
        rep.Database.Tables("revocated").SetDataSource(dt)
        Me.CrystalReportViewer1.ReportSource = rep
        rep.SetParameterValue("firm", Session("firm_name"))
        '    rep.SetParameterValue("firm", "MANAPPURAM GROUP OF COMPANIES")
        rep.SetParameterValue("firm1", "REVOCATED EMPLOYEES")
    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        rep.Dispose()
        rep.Close()
        GC.Collect()
    End Sub
End Class

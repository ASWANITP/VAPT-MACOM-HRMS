Imports System.Data
Imports System.Data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Class revocated_terminated_6b7744c84345
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim dt As New DataTable
    Dim rep As New ReportDocument
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '   dt = oh.ExecuteDataSet("select em.emp_code,    em.emp_name,       p.post_name,       d.dep_name,       ds.designation, em.join_dt as join_date,    e.remarks as reason,       e.discont_dt as terminated  from employee_resigtermi e,       employee_master     em,       post_mst            p,       designation_mst     ds,       department_mst      d where e.emp_code = em.emp_code   and em.post_id = p.post_id   and em.designation_id = ds.designation_id   and em.department_id = d.dep_id   and e.status_id = 5 and e.discont_dt between  " & Me.Request.QueryString("fdt") & "" & Me.Request.QueryString("tdt") & " ").Tables(0)
        dt = oh.ExecuteDataSet("select em.emp_code,    em.emp_name,       p.post_name,       d.dep_name,       ds.designation, em.join_dt as join_date,    e.remarks as reason,       e.discont_dt as terminated  from employee_resigtermi e,       employee_master     em,       post_mst            p,       designation_mst     ds,       department_mst      d,employ_firm ef where e.emp_code = em.emp_code   and em.post_id = p.post_id   and em.designation_id = ds.designation_id   and em.department_id = d.dep_id   and e.status_id = 5 and em.emp_code = ef.emp_code  and ef.firm_id = " & Session("firm_id") & " and e.discont_dt between  " & Me.Request.QueryString("fdt") & "" & Me.Request.QueryString("tdt") & " ").Tables(0)
        rep.Load(Server.MapPath("terminate.rpt"), OpenReportMethod.OpenReportByTempCopy)
        rep.Database.Tables("terminate").SetDataSource(dt)
        Me.CrystalReportViewer1.ReportSource = rep
        rep.SetParameterValue("firm", Session("firm_name"))
        ' rep.SetParameterValue("firm", "MANAPPURAM GROUP OF COMPANIES")
        rep.SetParameterValue("firm1", "TERMINATED EMPLOYEES")
    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        rep.Dispose()
        rep.Close()
        GC.Collect()
    End Sub
End Class

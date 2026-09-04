Imports System.Data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Partial Class payroll_tourrep_b419bb0e4994
    Inherits System.Web.UI.Page
    Dim report As New ReportDocument
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim oh As New Helper.Oracle.OracleHelper
        Dim dt As New DataTable
        Dim sql As String
        'sql = "select c.branch_name,d.name||' '||b.br_name||',A/C NO:'||a.bank_accno as bank,a.actual_bal,e.reason,a.req_amt,a.explanation from fundtfr_dtl a,bank_accno b,branch_master c,bank d,ftfr_reason e where a.branch_id=c.branch_id and a.branch_id=b.branch_id and a.bank_accno=b.bankacc_no and a.bank_id=d.bank_id and b.bank_id=d.bank_id and a.approved='T' and a.confirm_reso='T' and a.reason=e.r_id"
        If Request.QueryString.Get("dt") = Format(Date.Today, "dd/MMM/yyyy") Then
            'sql = "select upper(c.branch_name) branch_name,upper(substr(b.emp_name,0,20)) employee,upper(substr(d.post_name,0,15)) post_name,upper(substr(e.dep_name,0,18)) dep_name,'TOUR' particulars,'TOUR TO '||f.branch_name reason,a.emp_code from daily_attend a,employee_master b,branch_master c,post_mst d,department_mst e,branch_master f where a.emp_code=b.emp_code and a.m_branch<>a.branch_id and m_time is not NULL and a.branch_id=c.branch_id and b.post_id=d.post_id and b.department_id=e.dep_id and a.m_branch=f.branch_id order by c.branch_name,e.dep_name"
            sql = "select upper(c.branch_name) branch_name,  upper(substr(b.emp_name, 0, 20)) employee,  upper(substr(d.post_name, 0, 15)) post_name,  upper(substr(e.dep_name, 0, 18)) dep_name, 'TOUR' particulars,  'TOUR TO ' || f.branch_name reason,  a.emp_code  from daily_attend    a,  employee_master b,  branch_master   c,  post_mst        d,  department_mst  e,  branch_master   f,  employ_firm     ef  where a.emp_code = b.emp_code  and a.m_branch <> a.branch_id  and m_time is not NULL  and a.branch_id = c.branch_id  and b.post_id = d.post_id  and b.department_id = e.dep_id  and a.emp_code=ef.emp_code  and ef.firm_id=" & Session("firm_id") & "  and a.m_branch = f.branch_id  order by c.branch_name, e.dep_name"
        Else
            'sql = "select upper(c.branch_name) branch_name,upper(substr(b.emp_name,0,20)) employee,upper(substr(d.post_name,0,15)) post_name,upper(substr(e.dep_name,0,18)) dep_name,'TOUR' particulars,'TOUR TO '||f.branch_name reason,a.emp_code from attend a,employee_master b,branch_master c,post_mst d,department_mst e,branch_master f where a.emp_code=b.emp_code and a.m_branch<>a.branch_id and m_time is not NULL and a.branch_id=c.branch_id and b.post_id=d.post_id and b.department_id=e.dep_id and a.m_branch=f.branch_id and to_date(a.curr_date)=to_date('" & Request.QueryString.Get("dt") & "') order by c.branch_name,e.dep_name"
            sql = "select upper(c.branch_name) branch_name,  upper(substr(b.emp_name, 0, 20)) employee,  upper(substr(d.post_name, 0, 15)) post_name,  upper(substr(e.dep_name, 0, 18)) dep_name,  'TOUR' particulars,  'TOUR TO ' || f.branch_name reason,  a.emp_code  from attend          a,  employee_master b,  branch_master   c,  post_mst        d,  department_mst  e,  branch_master   f,  employ_firm     ef  where a.emp_code = b.emp_code  and a.m_branch <> a.branch_id  and m_time is not NULL  and a.branch_id = c.branch_id  and b.post_id = d.post_id  and b.department_id = e.dep_id  and a.m_branch = f.branch_id  and ef.emp_code = b.emp_code  and ef.firm_id = " & Session("firm_id") & "  and to_date(a.curr_date) =  to_date('" & Request.QueryString.Get("dt") & "')  order by c.branch_name, e.dep_name"

            'sql = "select upper(c.branch_name) branch_name,upper(substr(b.emp_name,0,20) employee),upper(substr(d.post_name,0,15)) post_name,upper(substr(e.dep_name,0,18)) dep_name,'TOUR' particulars,'TOUR TO '||f.branch_name reason,a.emp_code from attend a,employee_master b,branch_master c,post_mst d,department_mst e,branch_master f where a.emp_code=b.emp_code and a.m_branch<>a.branch_id and m_time is not NULL and a.branch_id=c.branch_id and b.post_id=d.post_id and b.department_id=e.dep_id and a.m_branch=f.branch_id and to_date(a.curr_date)=to_date('" & Request.QueryString.Get("dt") & "') order by c.branch_name,e.dep_name"
        End If
        dt = oh.ExecuteDataSet(sql).Tables(0)
        report.Load(Server.MapPath("tour.rpt"), OpenReportMethod.OpenReportByTempCopy)
        report.Database.Tables("pl3").SetDataSource(dt)
        report.SetParameterValue("dt", Request.QueryString.Get("dt"))
        Me.CrystalReportViewer1.ReportSource = report
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Close()
        report.Dispose()
        GC.Collect()
    End Sub
End Class

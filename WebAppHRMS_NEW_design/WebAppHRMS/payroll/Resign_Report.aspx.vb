Imports system.data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Partial Class HRM_Resign_Report_fb99f25d4433
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim repo As New ReportDocument
    Dim dt As DataTable
    Dim s As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim post As String = Request.QueryString.Get("post_name")
        'dt = oh.ExecuteDataSet("select b.ZONAL_NAME as zonal_name,b.reg_name as reg_name,e.emp_code as emp_code,e.emp_name as emp_name,b.branch_name as Branch_name,p.post_name as post_name,t.enter_dt as enter_dt,t.resign_dt as resign_dt,t.relieve_dt as relieve_dt,t.approve_dt as Approved_Dt,g.emp_name as Approved_by,decode(t.status, '0', 'Applied', '1', 'Approved') as STATUS  from m_resign_appl t,branch_dtl_new  b,employee_master e,post_mst p,employee_master g where e.emp_code = t.emp_code and p.post_id = e.post_id and e.branch_id = b.BRANCH_ID and t.status in (0, 1,5) and g.emp_code = t.approved_by and t.relieve_dt > to_date(sysdate) and e.post_id =" & post & "").Tables(0)
        dt = oh.ExecuteDataSet("select b.ZONAL_NAME as zonal_name,  b.reg_name as reg_name,  e.emp_code as emp_code,  e.emp_name as emp_name,  b.branch_name as Branch_name,  p.post_name as post_name,  t.enter_dt as enter_dt,  t.resign_dt as resign_dt,  t.relieve_dt as relieve_dt,  t.approve_dt as Approved_Dt,  g.emp_name as Approved_by,  decode(t.status, '0', 'Applied', '1', 'Approved') as STATUS  from m_resign_appl   t,  branch_dtl_new  b,  employee_master e,  post_mst        p,  employee_master g,  employ_firm ef  where e.emp_code = t.emp_code  and p.post_id = e.post_id  and e.branch_id = b.BRANCH_ID  and e.emp_code=ef.emp_code  and ef.firm_id=" & Session("firm_id") & "  and t.status in (0, 1, 5)  and g.emp_code = t.approved_by  and t.relieve_dt > to_date(sysdate)  and e.post_id =" & post & "").Tables(0)

        repo.Load(Server.MapPath("Resign_rpt.rpt"), OpenReportMethod.OpenReportByTempCopy)
        repo.Database.Tables("Resignn").SetDataSource(dt)
        repo.setparametervalue("FIRM", session("firm_name"))
        Me.crys1.DisplayGroupTree = False
        Me.crys1.ReportSource = repo
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        repo.Dispose()
        repo.Close()
        GC.Collect()

    End Sub
End Class

Imports System.Data
Imports System.Data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Class punch_block_dtls_12days_late_block_c9d645b12403
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim dt As New DataTable
    Dim rep As New ReportDocument
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'dt = oh.ExecuteDataSet("select distinct z.emp_code,e.emp_name,bt.BRANCH_NAME,d.designation,a.area_name,p.post_name,z.Late_days from (select sum(t.late_count) as Late_days, t.emp_code from hrm_late_leave_dtl t group by t.emp_code) z,employee_master e,employee_block_dtl_his bm,designation_master d,area_master a,branch_detail bt,post_mst p where e.emp_code = z.emp_code and bm.block_id = 102 and e.designation_id = d.designation_id and a.area_id = bt.area_id and bt.BRANCH_ID = e.branch_id and e.post_id=p.post_id and bm.emp_code = z.emp_code and bm.emp_code = e.emp_code and bm.block_date between to_date('01/jan/2011') and to_date(sysdate)  order by z.emp_code").Tables(0)

        '   dt = oh.ExecuteDataSet("select distinct e.emp_name,t.emp_code,b.BRANCH_NAME,d.designation,a.area_name,p.post_name,count(x.emp_code) as late_days from employee_master e,designation_master   d,area_master  a,branch_detail  b,post_mst  p,late_leave_exception t,attend x where t.emp_code = e.emp_code and t.status = 1 and t.rele_dt is null  and b.BRANCH_ID = e.branch_id  and x.pay_id=15 and x.emp_code=t.emp_code   and d.designation_id = e.designation_id and p.post_id = e.post_id  and a.area_id = b.area_id group by e.emp_name, t.emp_code, b.BRANCH_NAME,d.designation,a.area_name, p.post_name").Tables(0)
        dt = oh.ExecuteDataSet("select distinct e.emp_name,t.emp_code,b.BRANCH_NAME,d.designation,a.area_name,p.post_name,count(x.emp_code) as late_days from employee_master e,employ_firm ef,designation_master   d,area_master  a,branch_detail  b,post_mst  p,late_leave_exception t,attend x where t.emp_code = e.emp_code and e.emp_code = ef.emp_code and ef.firm_id = " & Session("firm_id") & " and t.status = 1 and e.status_id = 1 and t.rele_dt is null  and b.BRANCH_ID = e.branch_id  and x.pay_id=15 and x.emp_code=t.emp_code   and d.designation_id = e.designation_id and p.post_id = e.post_id  and a.area_id = b.area_id group by e.emp_name, t.emp_code, b.BRANCH_NAME,d.designation,a.area_name, p.post_name").Tables(0)
        rep.Load(Server.MapPath("12late_block.rpt"), OpenReportMethod.OpenReportByTempCopy)
        rep.Database.Tables("late_block").SetDataSource(dt)


        rep.setparametervalue("FIRM1", session("firm_name"))
        Me.CrystalReportViewer1.ReportSource = rep
        'rep.SetParameterValue("firm", "MANAPPURAM GROUP OF COMPANIES")

    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        rep.Close()
        rep.Dispose()
        GC.Collect()
    End Sub
End Class

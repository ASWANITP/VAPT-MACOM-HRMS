Imports System.Data
Imports System.Data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Class new_punch_bloc_rpt_new_block_branch_new_block_report_a083ea746866
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim dt As New DataTable
    Dim report As New ReportDocument
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'dt = oh.ExecuteDataSet("select h.emp_code, e.emp_name, count(block_times),b.branch_name, p.post_name from hrm_new_block_dtl h, employee_master e, post_mst p,branch_master b where e.emp_code = h.emp_code   and p.post_id = h.post_id   and e.status_id = 1 and b.branch_id=e.branch_id  and h.branch_id=e.branch_id and h.branch_id=" & Me.Request.QueryString("fdt") & " group by h.emp_code, e.emp_name, b.branch_name, p.post_name").Tables(0)

        'dt = oh.ExecuteDataSet("select h.emp_code,e.emp_name,h.block_times,b.branch_name,p.post_name,bm.block_reason from mis.hrm_new_block_dtl h,employee_master   e,      post_mst          p,       branch_master     b,       attend_his        dt,       block_master_1    bm where e.emp_code = h.emp_code   and dt.emp_code = h.emp_code   and p.post_id = h.post_id   and e.status_id = 1   and e.emp_code = dt.EMP_CODE   and b.branch_id = e.branch_id   and h.branch_id =" & Me.Request.QueryString("fdt") & "   and dt.BLOCK like '%,' || bm.block_id || ',%'   and to_char(dt.CURR_DATE, 'MM/yyyy') =to_char(to_date(" & Me.Request.QueryString("tdt") & "), 'MM/yyyy')   and dt.CURR_DATE = h.cur_dt order by h.cur_dt").Tables(0)
        dt = oh.ExecuteDataSet("select h.emp_code,e.emp_name,h.block_times,b.branch_name,p.post_name,bm.block_reason from macmis.hrm_new_block_dtl h,employee_master   e,employ_firm ef,      post_mst          p,       branch_master     b,       attend_his        dt,       block_master_1    bm where e.emp_code = h.emp_code and e.emp_code = ef.emp_code and ef.firm_id = " & Session("firm_id") & "   and dt.emp_code = h.emp_code   and p.post_id = h.post_id   and e.status_id = 1   and e.emp_code = dt.EMP_CODE   and b.branch_id = e.branch_id   and h.branch_id =" & Me.Request.QueryString("fdt") & "   and dt.BLOCK like '%,' || bm.block_id || ',%'   and to_char(dt.CURR_DATE, 'MM/yyyy') =to_char(to_date(" & Me.Request.QueryString("tdt") & "), 'MM/yyyy')   and dt.CURR_DATE = h.cur_dt order by h.cur_dt").Tables(0)
        report.Load(Server.MapPath("new_block_branch.rpt"), OpenReportMethod.OpenReportByTempCopy)
        report.Database.Tables("br_blk").SetDataSource(dt)

        report.setparametervalue("FIRM1", session("firm_name"))

        'report.SetParameterValue("FIRM", "MANAPPURAM GROUP OF COMPANIES")
        Me.CrystalReportViewer1.ReportSource = report
    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Close()
        report.Dispose()
        GC.Collect()
    End Sub
End Class

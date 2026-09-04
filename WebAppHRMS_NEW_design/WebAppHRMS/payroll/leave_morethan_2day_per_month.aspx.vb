Imports system.data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Partial Class january2009_leave_morethan_2day_per_month_ebf804558099
    Inherits System.Web.UI.Page
    Dim report As New ReportDocument
    Dim dt As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dt = oh.ExecuteDataSet("select a1.emp_code,a1.emp_name, a1.designation,a1.department, a1.post, a1.gender, a1.join_dt,a1.ldays,a1.actual,nvl(sum(ew.leave_days), 0) as sanctioned_leave,a1.reason, a1.BRANCH_NAME, a1.AREA_NAME, a1.DIV_NAME, a1.REG_NAME,  a1.zonal_name  from (select a.emp_code,a.emp_name, a.designation,a.department, a.post, a.gender, a.join_dt,a.ldays,nvl(sum(ell.leave_days), 0) as actual,a.status as reason, a.BRANCH_NAME, a.AREA_NAME, a.DIV_NAME, a.REG_NAME,  a.zonal_name from (select e.emp_code, e.emp_name,  e.designation, e.post,  e.gender, e.join_dt, sum(el.leave_days) as ldays,e.status, bd.BRANCH_NAME, bd.AREA_NAME,bd.DIV_NAME, bd.REG_NAME,bd.zonal_name,e.department from branch b, branch_detail bd, employee_current e ,employ_leave_dtl el where el.emp_code =e.emp_code and el.leave_process_id not in (0, 3) and el.status = 1 and b.BRANCH_ID = bd.BRANCH_ID and b.BRANCH_ID = e.branch_id and e.status_id = 1 and to_char(to_date(el.leave_frdate), 'MM/YYYY') =to_char(to_date('" & Request.QueryString("dat") & "'), 'MM/YYYY') having(sum(el.leave_days) >2 ) group by e.emp_code, e.emp_name, e.designation,e.post, e.department, e.gender,e.join_dt, e.status,bd.BRANCH_NAME, bd.AREA_NAME, bd.DIV_NAME,  bd.REG_NAME, bd.zonal_name order by bd.zonal_name,bd.REG_NAME, bd.DIV_NAME, bd.AREA_NAME, bd.BRANCH_NAME) a left outer join employ_leave_dtl ell on (ell.emp_code = a.emp_code and ell.leave_process_id not in (0, 3) and ell.status = 1 and to_char(to_date(ell.leave_frdate), 'MM/YYYY') =to_char(to_date('" & Request.QueryString("dat") & "'),'MM/YYYY') and ell.leave_reason not like  'N/M%') group by a.emp_code,a.emp_name,a.designation,a.post,a.gender,a.ldays,a.status,a.join_dt,a.BRANCH_NAME, a.AREA_NAME,a.DIV_NAME,a.REG_NAME,a.zonal_name, a.department) a1 left outer join employ_leave_dtl ew on (ew.emp_code = a1.emp_code and ew.leave_process_id not in (0, 3) and ew.status = 1 and to_char(to_date(ew.leave_frdate),'MM/YYYY') =to_char(to_date('" & Request.QueryString("dat") & "'), 'MM/YYYY') and ew.entered_by not like 'IT_PROCESS%' and ew.entered_by is not null) group by a1.emp_code, a1.emp_name,a1.designation,a1.post,a1.gender, a1.ldays,a1.reason,a1.join_dt, a1.BRANCH_NAME,a1.AREA_NAME,a1.DIV_NAME,a1.REG_NAME,a1.zonal_name,a1.department, a1.actual order by a1.zonal_name,a1.REG_NAME,a1.DIV_NAME,a1.AREA_NAME,a1.BRANCH_NAME").Tables(0)
        'select a.emp_code, a.emp_name,a.designation,a.post,a.gender,a.join_dt,a.ldays,nvl(sum(ell.leave_days),0) as actual,a.BRANCH_NAME,a.AREA_NAME,a.DIV_NAME,a.REG_NAME,a.zonal_name from (select e.emp_code,e.emp_name,e.designation,e.post,e.gender,e.join_dt,sum(el.leave_days) as ldays,bd.BRANCH_NAME,bd.AREA_NAME,bd.DIV_NAME,bd.REG_NAME,bd.zonal_name from employee_current e,employ_leave_dtl el,branch b,branch_detail bd where b.BRANCH_ID = bd.BRANCH_ID and b.BRANCH_ID = e.branch_id and el.emp_code = e.emp_code and e.status_id=1 and el.leave_process_id not in (0, 3) and el.status = 1 and to_char(to_date(el.leave_frdate), 'MM/YYYY') = to_char(to_date('"& request.querystring("dat")  &"'), 'MM/YYYY') having(sum(el.leave_days) > (2 * to_char(to_date('"& request.querystring("dat")  &"'), 'MM'))) group by e.emp_code,e.emp_name,e.designation,e.post,e.gender,e.join_dt,el.leave_days,bd.BRANCH_NAME,bd.AREA_NAME,bd.DIV_NAME,bd.REG_NAME,bd.zonal_name order by bd.zonal_name,bd.REG_NAME,bd.DIV_NAME,bd.AREA_NAME,bd.BRANCH_NAME ) a  left outer join employ_leave_dtl ell on (ell.emp_code = a.emp_code and ell.leave_process_id not in (0, 3) and ell.status = 1 and to_char(to_date(ell.leave_frdate), 'MM/YYYY') = to_char(to_date('"& request.querystring("dat")  &"'), 'MM/YYYY') and ell.leave_reason <> 'N/M E') group by  a.emp_code,a.emp_name,a.designation,a.post,a.gender,a.ldays,a.join_dt,a.BRANCH_NAME,a.AREA_NAME,a.DIV_NAME,a.REG_NAME,a.zonal_name order by a.zonal_name,a.REG_NAME,a.DIV_NAME,a.AREA_NAME,a.BRANCH_NAME,a.emp_code").Tables(0)
        report.Load(Server.MapPath("leave_morethan_2day_per_month.rpt"), OpenReportMethod.OpenReportByTempCopy)
        report.SetDataSource(dt)
        report.SetParameterValue("head", Request.QueryString("head"))
        report.SetParameterValue("year", Request.QueryString("year"))

        report.SetParameterValue("FIRM", Session("firm_name"))
        Me.CrystalReportViewer1.ReportSource = report
    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Dispose()
        report.Close()
        GC.Collect()
    End Sub
End Class

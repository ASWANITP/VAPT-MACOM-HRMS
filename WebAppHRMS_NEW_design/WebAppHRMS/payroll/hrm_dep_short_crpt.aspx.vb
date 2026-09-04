Imports System.Data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Partial Class Add_Qualification_hrm_dep_short_crpt_235d0e4f7467
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim crSections As Sections
    Dim report As New ReportDocument
    Dim dt1 As DataTable
    Dim export As New IO.MemoryStream
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim dt As DataTable = oh.ExecuteDataSet("select dm.department_name as major_dept,d.dep_name as sub_dept,m.requirement,m.systembasis,m.actual,m.short,m.surplus,m.leave,to_char(to_date(m.tra_dt), 'dd/MM/yyyy'),m.short_reason,h.emp_Code || ' - ' ||h.EMP_NAME as emp_name,to_char(to_date(h.vacancy),'dd/MM/yyyy') as vacancy, h.leave_reason, h.total_leave,g.grade from mis.hrm_dep_short_main    m,department_major dm,mis.hrm_dep_short_dtl     h,department_mst   d,grade_master     g where dm.department_id = m.major_dep_id and m.department_id = h.department_id and d.dep_id = m.department_id and h.grade_id = g.grade_id union all select dm.department_name as major_dept,d.dep_name as sub_dept,m.requirement,m.systembasis,m.actual,m.short, m.surplus, m.leave,to_char(to_date(m.tra_dt), 'dd/MON/yyyy'), m.short_reason,'',null,'',0,'' from mis.hrm_dep_short_main    m,department_major dm, department_mst   d where dm.department_id = m.major_dep_id and d.dep_id = m.department_id and not exists (select p.department_id from mis.hrm_dep_short_dtl p where p.department_id = d.dep_id) order by major_dept,  sub_dept, emp_name").Tables(0)
        Dim dt As DataTable = oh.ExecuteDataSet("select dm.department_name as major_dept,d.dep_name as sub_dept,m.requirement,m.systembasis,m.actual,m.short,m.surplus,m.leave,to_char(to_date(m.tra_dt), 'dd/MM/yyyy'),m.short_reason,h.emp_Code || ' - ' ||h.EMP_NAME as emp_name,to_char(to_date(h.vacancy),'dd/MM/yyyy') as vacancy, h.leave_reason, h.total_leave, to_char(to_date(h.Repdt),'dd/MM/yyyy') as Repdt,g.grade from macmis.hrm_dep_short_main    m,department_major dm,macmis.hrm_dep_short_dtl     h,department_mst   d,grade_master     g where dm.department_id = m.major_dep_id and m.department_id = h.department_id and d.dep_id = m.department_id and h.grade_id = g.grade_id union all select dm.department_name as major_dept,d.dep_name as sub_dept,m.requirement,m.systembasis,m.actual,m.short, m.surplus, m.leave,to_char(to_date(m.tra_dt), 'dd/MON/yyyy'), m.short_reason,'',null,'',0,'','' from macmis.hrm_dep_short_main    m,department_major dm, department_mst   d where dm.department_id = m.major_dep_id and d.dep_id = m.department_id and not exists (select p.department_id from macmis.hrm_dep_short_dtl p where p.department_id = d.dep_id) order by major_dept,  sub_dept, emp_name").Tables(0)
        report.Load(Server.MapPath("dept_short.rpt"), OpenReportMethod.OpenReportByTempCopy)
        report.Database.Tables("DataTable1").SetDataSource(dt)
        report.SetParameterValue("Firm", Session("firm_name"))
        Me.CrystalReportViewer1.ReportSource = report
    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Me.report.Dispose()
        Me.report.Close()
    End Sub
End Class

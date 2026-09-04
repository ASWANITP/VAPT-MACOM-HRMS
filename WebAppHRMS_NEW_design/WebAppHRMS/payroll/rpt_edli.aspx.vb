Imports System.Data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Partial Class EDLI_rpt_edli_03809aa89734
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.oraclehelper
    Dim report As New ReportDocument

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sql As String = ""
        Dim dt As DataTable
        Dim n1, n2 As Date
        Dim currentdt As DataTable = oh.ExecuteDataSet("select to_char(sysdate,'MM'),to_char(sysdate,'YYYY') from dual").Tables(0)
        If Me.Request.QueryString("firm") = 1 Then ' magfil
            n1 = Format(CDate("1/mar/" & currentdt.Rows(0)(1) - 1), "dd/MMM/yyyy")
            n2 = Format(CDate("1/mar/" & currentdt.Rows(0)(1)), "dd/MMM/yyyy")
            If Me.Request.QueryString("rpt") = 1 Then   'new
                sql = "select e.emp_code,e.emp_name,ep.birth_date as birth_dt,e.join_dt ,(e.basic_pay+case when e.da_flag='T' then (select value from da_index where to_dt is null) else 0 end) as wage from employee_master e ,employee_master_dtl em,employ_personal_dtl ep where e.emp_type=1 and e.emp_code=ep.emp_code and e.emp_code>9999 and e.emp_code=em.emp_code and e.firm_id=1 and e.status_id in(1,4,6,10) and e.join_dt>='" & Format(n1, "dd/MMM/yyyy") & "' and e.join_dt<'" & Format(n2, "dd/MMM/yyyy") & "' and (e.status_id in(1,6,10) or em.discont_dt >='" & Format(n2, "dd/MMM/yyyy") & "' ) order by e.emp_name"
                dt = oh.ExecuteDataSet(sql).Tables(0)
                report.Load(Server.MapPath("crpt_edli_newjoined.rpt"), OpenReportMethod.OpenReportByTempCopy)
                report.SetDataSource(dt)
            ElseIf Me.Request.QueryString("rpt") = 2 Then 'resigned
                sql = "select em.insurance_no,e.emp_code,e.emp_name,ep.birth_date as birth_dt,e.join_dt ,(e.basic_pay+case when e.da_flag='T' then (select value from da_index where to_dt is null) else 0 end) as wage ,em.discont_dt,decode(e.status_id,3,'RESIGNED',5,'TERMINATED') as remarks from employee_master e ,employee_master_dtl em ,employ_personal_dtl ep where e.emp_type=1 and e.emp_code=ep.emp_code and e.emp_code=em.emp_code and e.status_id not in(1,4,6,10,13) and e.firm_id=1 and e.join_dt< '" & Format(n1, "dd/MMM/yyyy") & "' and em.discont_dt >='" & Format(n1, "dd/MMM/yyyy") & "'  and em.discont_dt<'" & Format(n2, "dd/MMM/yyyy") & "'  order by e.emp_name"
                dt = oh.ExecuteDataSet(sql).Tables(0)
                report.Load(Server.MapPath("crpt_edli_resigned.rpt"), OpenReportMethod.OpenReportByTempCopy)
                report.SetDataSource(dt)
            Else 'live
                sql = "select em.insurance_no,e.emp_code,e.emp_name,ep.birth_date as birth_dt,e.join_dt,(e.basic_pay+case when e.da_flag='T' then (select value from da_index where to_dt is null) else 0 end) as wage  from employee_master e ,employee_master_dtl em ,employ_personal_dtl ep where e.emp_type=1 and e.emp_code=ep.emp_code and e.emp_code=em.emp_code and e.firm_id=1 and e.join_dt< '" & Format(n1, "dd/MMM/yyyy") & "' and (e.status_id in(1,4,6,10) or em.discont_dt>='" & Format(n2, "dd/MMM/yyyy") & "') order by e.emp_name"
                dt = oh.ExecuteDataSet(sql).Tables(0)
                report.Load(Server.MapPath("crpt_edli_live.rpt"), OpenReportMethod.OpenReportByTempCopy)
                report.SetDataSource(dt)
            End If
        Else 'maben & magro
            n1 = Format(CDate("1/dec/" & currentdt.Rows(0)(1) - 1), "dd/MMM/yyyy")
            n2 = Format(CDate("1/dec/" & currentdt.Rows(0)(1)), "dd/MMM/yyyy")
            If Me.Request.QueryString("rpt") = 1 Then   'new
                sql = "select e.emp_code,e.emp_name,ep.birth_date as birth_dt,e.join_dt,(e.basic_pay+case when e.da_flag='T' then (select value from da_index where to_dt is null) else 0 end) as wage from employee_master e ,employee_master_dtl em,employ_personal_dtl ep where e.emp_type=1 and e.emp_code=ep.emp_code and e.emp_code>9999 and e.emp_code=em.emp_code and e.firm_id in (2,5) and e.status_id in(1,4,6,10) and e.join_dt>='" & Format(n1, "dd/MMM/yyyy") & "' and e.join_dt<'" & Format(n2, "dd/MMM/yyyy") & "' and (e.status_id in(1,6,10) or em.discont_dt >='" & Format(n2, "dd/MMM/yyyy") & "' ) order by e.emp_name"
                dt = oh.ExecuteDataSet(sql).Tables(0)
                report.Load(Server.MapPath("crpt_edli_newjoined.rpt"), OpenReportMethod.OpenReportByTempCopy)
                report.SetDataSource(dt)
            ElseIf Me.Request.QueryString("rpt") = 2 Then 'resigned
                sql = "select em.insurance_no,e.emp_code,e.emp_name,ep.birth_date as birth_dt,e.join_dt ,(e.basic_pay+case when e.da_flag='T' then (select value from da_index where to_dt is null) else 0 end) as wage ,em.discont_dt,decode(e.status_id,3,'RESIGNED',5,'TERMINATED') as remarks from employee_master e ,employee_master_dtl em ,employ_personal_dtl ep where e.emp_type=1 and e.emp_code=ep.emp_code and e.emp_code=em.emp_code and e.status_id not in(1,4,6,10,13) and e.firm_id in(2,5) and e.join_dt< '" & Format(n1, "dd/MMM/yyyy") & "' and em.discont_dt >='" & Format(n1, "dd/MMM/yyyy") & "'  and em.discont_dt<'" & Format(n2, "dd/MMM/yyyy") & "'  order by e.emp_name"
                dt = oh.ExecuteDataSet(sql).Tables(0)
                report.Load(Server.MapPath("crpt_edli_resigned.rpt"), OpenReportMethod.OpenReportByTempCopy)
                report.SetDataSource(dt)
            Else 'live
                sql = "select em.insurance_no,e.emp_code,e.emp_name,ep.birth_date as birth_dt,e.join_dt,(e.basic_pay+case when e.da_flag='T' then (select value from da_index where to_dt is null) else 0 end) as wage  from employee_master e ,employee_master_dtl em ,employ_personal_dtl ep where e.emp_type=1 and e.emp_code=ep.emp_code and e.emp_code=em.emp_code and e.firm_id in(2,5) and e.join_dt< '" & Format(n1, "dd/MMM/yyyy") & "' and (e.status_id in(1,4,6,10) or em.discont_dt>='" & Format(n2, "dd/MMM/yyyy") & "') order by e.emp_name"
                dt = oh.ExecuteDataSet(sql).Tables(0)
                report.Load(Server.MapPath("crpt_edli_live.rpt"), OpenReportMethod.OpenReportByTempCopy)
                report.SetDataSource(dt)
            End If

        End If
        Me.CrystalReportViewer1.ReportSource = report

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        oh.dispose()
        report.Dispose()
        GC.Collect()
    End Sub
End Class

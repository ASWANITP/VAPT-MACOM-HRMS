Imports System.Data
Imports System.Data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Class salary_leave_auth_view_f5b5e0b51874
    Inherits System.Web.UI.Page
    Dim report As New ReportDocument

    Protected Sub Page_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        report.Dispose()
        report.Close()
        GC.Collect()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim oh As New helper.oracle.OracleHelper
        Dim opts As Integer = Request.QueryString.Get("opt")
        Dim ids As Integer = Request.QueryString.Get("id")
        Dim str As String = ""

        Dim dt As DataTable
        If opts = 1 Then  'authority details
            If ids = 0 Then 'leave authority dtls
                str = "select a.emp_code,m.EMP_NAME,b.BRANCH_NAME, a.f_days,a.t_days,rec.EMP_NAME recby,san.EMP_NAME sanby from leave_sanction_authority a,emp_master  m, employ_firm  f,branch  b,emp_master  rec,emp_master  san where a.emp_code = m.EMP_CODE  and m.BRANCH_ID = b.BRANCH_ID and m.EMP_CODE = f.emp_code and f.firm_id = " & Session("firm_id") & " and a.l_rec_by = rec.EMP_CODE  and a.l_sanc_by = san.EMP_CODE"
                report.Load(Server.MapPath("leave_authrpt.rpt"), OpenReportMethod.OpenReportByTempCopy)
            Else  'other leave authority
                str = "select a.emp_id,m.EMP_NAME,b.BRANCH_NAME,mcr.EMP_NAME comprec,mcs.EMP_NAME compsacn,mtr.EMP_NAME tourrec,mts.EMP_NAME toursan,mpr.EMP_NAME punchrec,mps.EMP_NAME punchsan,mer.EMP_NAME earlyrec,mes.EMP_NAME earlysan,mar.EMP_NAME atregrec,mas.EMP_name atregsan from othleave_sanction_authority a,emp_master m,employ_firm f,branch b,emp_master  mcr,emp_master mcs,emp_master mtr,emp_master mts,emp_master mpr, emp_master mps,emp_master mer,emp_master mes,emp_master mar,emp_master mas where a.emp_id = m.EMP_CODE and m.BRANCH_ID = b.BRANCH_ID  and m.EMP_CODE = f.emp_code and f.firm_id = " & Session("firm_id") & " and a.c_recby = mcr.EMP_CODE and a.c_sanby = mcs.EMP_CODE and a.t_recby = mtr.EMP_CODE and a.t_sanby = mts.EMP_CODE and a.pbk_recby = mpr.EMP_CODE and a.pbk_sanby = mps.EMP_CODE and a.at_recby = mar.EMP_CODE and a.at_sanby = mas.EMP_CODE and a.erly_recby = mer.EMP_CODE and a.early_sancby = mes.EMP_CODE"
                report.Load(Server.MapPath("leave_excRpt.rpt"), OpenReportMethod.OpenReportByTempCopy)
            End If
        Else 'exception details
            If ids = 1 Then 'leave authority dtls
                str = "select a.emp_id,m.EMP_NAME,b.BRANCH_NAME,mcr.EMP_NAME comprec,mcs.EMP_NAME compsacn,mtr.EMP_NAME tourrec,mts.EMP_NAME toursan,mpr.EMP_NAME punchrec,mps.EMP_NAME punchsan,mer.EMP_NAME earlyrec,mes.EMP_NAME earlysan,mar.EMP_NAME atregrec,mas.EMP_name atregsan from othleave_sanction_authority a,emp_master m,employ_firm f,branch b,emp_master  mcr,emp_master mcs,emp_master mtr,emp_master mts,emp_master mpr, emp_master mps,emp_master mer,emp_master mes,emp_master mar,emp_master mas where a.emp_id = m.EMP_CODE and m.BRANCH_ID = b.BRANCH_ID  and m.EMP_CODE = f.emp_code and f.firm_id = " & Session("firm_id") & " and a.c_recby = mcr.EMP_CODE and a.c_sanby = mcs.EMP_CODE and a.t_recby = mtr.EMP_CODE and a.t_sanby = mts.EMP_CODE and a.pbk_recby = mpr.EMP_CODE and a.pbk_sanby = mps.EMP_CODE and a.at_recby = mar.EMP_CODE and a.at_sanby = mas.EMP_CODE and a.erly_recby = mer.EMP_CODE and a.early_sancby = mes.EMP_CODE and (a.c_recby = -1 or a.c_sanby = -1 or a.t_recby = -1 or a.t_sanby = -1 or a.at_recby = -1 or a.at_sanby = -1 or a.pbk_recby = -1 or a.pbk_sanby = -1 or a.erly_recby = -1 or a.early_sancby = -1) and m.STATUS_ID=1"
                report.Load(Server.MapPath("leave_excRpt.rpt"), OpenReportMethod.OpenReportByTempCopy)
            Else ''other leave authority
                str = "select a.emp_code,m.EMP_NAME,b.BRANCH_NAME, a.f_days,a.t_days,rec.EMP_NAME recby,san.EMP_NAME sanby from leave_sanction_authority a,emp_master  m, employ_firm  f,branch  b,emp_master  rec,emp_master  san where a.emp_code = m.EMP_CODE  and m.BRANCH_ID = b.BRANCH_ID and m.EMP_CODE = f.emp_code and f.firm_id = " & Session("firm_id") & " and a.l_rec_by = rec.EMP_CODE  and a.l_sanc_by = san.EMP_CODE and (a.l_rec_by = -1 or a.l_sanc_by = -1)"
                report.Load(Server.MapPath("leave_authrpt.rpt"), OpenReportMethod.OpenReportByTempCopy)
            End If
        End If
        dt = oh.ExecuteDataSet(str).Tables(0)
        report.SetDataSource(dt)
        'report.SetParameterValue("firm", Session("firm_name"))
        Me.CrystalReportViewer1.ReportSource = report
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Dispose()
        report.Close()
        GC.Collect()
    End Sub
End Class

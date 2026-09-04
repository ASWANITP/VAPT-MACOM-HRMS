Imports system.data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Partial Class hrm_punch_firmwise_Cryrpt_c7cff0742324
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim crSections As Sections
    Dim report As New ReportDocument
    Dim UserAll(), BranchAll() As String
    Dim UserCode, BranchId As Integer
    Dim dt2 As DataTable
    Dim fir As String
    Dim export As New IO.MemoryStream

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fir = Session("firm_name")
        Dim Frdt As String = Request.QueryString.Get("Fdt")
        Dim firm As String = Request.QueryString.Get("frm")

        dt2 = oh.ExecuteDataSet("select da.emp_code as Ecode,em.emp_name as Ename,ep.father_name as fatname,decode(ep.sex,0,'Female',1,'Male') as sex,to_char(em.join_dt) as joindate,p.post_name as post,d.designation as designaton,dp.dep_name as department,decode(da.m_time, NULL, '----------', da.m_time) as morning_time,decode(e_time, NULL, '----------', e_time) as evening_time,case when(da.m_time is not null and da.e_time is not null and da.pay_id not in(50,51,52) and da.m_time not in('COMPEN'))then 'Present' else case when(da.m_time='COMPEN') then 'Compan' else case when (da.m_time is null and da.pay_id not in (50, 52)) and(da.pay_id not in (51, 52) and da.e_time is null) then 'Absent' else case when da.pay_id in (50) and da.e_time is not null then'Morning-REG'else case when da.pay_id in (51) and da.m_time is not null then'Evening-REG' else case when da.pay_id in (52) then 'BOTH-REG' else case when (da.m_time > bt1.in_time and da.m_time <> 'TOUR' and da.m_time <> 'COMPEN' and da.pay_id not in (50, 7, 52)) and (da.e_time is null and da.pay_id not in (51, 7, 52)) then 'Late & Non-Marking' else case when da.m_time <= bt1.in_time and (da.e_time is null and da.pay_id not in (51, 52)) then 'Non-Marking Evening' else case when (da.m_time is null and da.pay_id not in (50, 52, 7)) and da.e_time < bt2.out_time then 'Non-Marking Morning & Early-Going' else case when (da.m_time is null and da.pay_id not in (50, 52)) and da.e_time >= bt2.out_time then 'Non-Marking Morning' else case when da.m_time <= bt1.in_time and (da.e_time < bt2.out_time and da.e_time <> 'TOUR' and da.e_time <> 'COMPEN' and da.pay_id not in (51, 52, 7)) then 'Early-Going' else case when (da.m_time > bt1.in_time and da.pay_id not in (50, 52)) and (da.e_time < bt2.out_time and da.pay_id not in (51, 52, 7)) then 'Late & Early Going' else case when (da.m_time > bt1.in_time and da.m_time <> 'TOUR' and da.m_time <> 'COMPEN' and da.pay_id not in (50, 52, 7)) and da.e_time >= bt2.out_time then 'Late' else case when da.pay_id in (50) and da.E_TIME is null then 'REG-Morning & Non-Marking Evening' else case when da.pay_id in (51) and da.M_TIME is null then 'REG-Morning & Non-Marking Morning'else case when da.pay_id in (50) and da.e_time <> 'TOUR' and da.e_time <> 'COMPEN' and da.E_TIME < bt2.out_time then'REG-Morning & Early-Going' else case when da.pay_id in (51) and da.m_time <> 'TOUR' and da.m_time <> 'COMPEN' and da.M_TIME > bt1.in_time then'REG-Evening & Late' else case when da.pay_id in (52) then'REG-Morning & Evening' else'' end end end end end end end end end end end end end end end end end end as remarks,curr_date as day from Attend da,employee_master em,time_tab bt1,time_tab bt2,post_mst p,designation_master d,employ_personal_dtl ep,department_mst dp,firm_master f,employ_firm         ef where em.emp_code = da.emp_code and to_char(da.curr_date, 'MM/yyyy') =to_char(to_date('" & Frdt & "'), 'MM/yyyy') and bt1.shift_id = da.m_shift and em.post_id = p.post_id and em.designation_id = d.designation_id and em.department_id=dp.dep_id and em.emp_code=ep.emp_code and bt2.shift_id = da.e_shift and em.emp_code = ef.emp_code    and f.firm_id = ef.firm_id   and ef.firm_id = " & firm & " and em.status_id=1 order by em.emp_code,da.curr_date").Tables(0)
        report.Load(Server.MapPath("hrm_punch_firmwise_rpt.rpt"), OpenReportMethod.OpenReportByTempCopy)
        report.Database.Tables("C1").SetDataSource(dt2)

        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.ReportSource = report
        report.SetParameterValue("fir", fir)

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Dispose()
        report.Close()
        GC.Collect()

    End Sub
End Class

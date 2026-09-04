Imports system.data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Partial Class Attentance_Reg_Comb_Report_hrm_atten_reg_late_non_Cryrpt_cf73a7034451
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim crSections As Sections
    Dim report As New ReportDocument
    Dim UserAll(), BranchAll() As String
    Dim UserCode, BranchId As Integer
    Dim dt2 As DataTable
    Dim export As New IO.MemoryStream
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Frdt As String = Request.QueryString.Get("Fdt")
        Dim Todt As String = Request.QueryString.Get("Tdt")
        BranchAll = Me.Session("branch_id").ToString.Split("!")
        BranchId = BranchAll(0)
        
        'dt2 = oh.ExecuteDataSet("select r.requested_by || '-' || e.emp_name as reqby,to_char(to_date(r.requested_dt)) as reqdt,r.remarks as remark,'LATE' as reqtype,decode(r.status_id,0,'APPLIED',9,'AM RECOMMENDED',8,'RM RECOMMENDED',7,'AM REJECTED',6,'RM REJECTED',2,'RH RECOMMENDED',3,'RH REJECTED',1,'SANCTIONED',4,'REJECTED',10,'APPLIED',11,'RECOMMEND',12,'SANCTIONED') as status from hrm_anytimepunching_reg r, employee_master e where r.requested_by = e.emp_code and r.branch_id = " & BranchId & " and to_date(r.requested_dt) between to_date(' " & Frdt & " ') and to_date(' " & Todt & " ') and r.not_punch is null union select r.requested_by || '-' || e.emp_name as reqby,to_char(to_date(r.att_req_dt)) as reqdt,b.failure_name as remark,'NON MARKING' as reqtype,decode(r.status_id,0,'APPLIED',2,'AM RECOMMENDED',3,'RM RECOMMENDED',5,'AM REJECTED',6,'RM REJECTED',4,'RH RECOMMENDED',7,'RH REJECTED',1,'SANCTIONED',8,'REJECTED',10,'APPLIED',11,'RECOMMEND',12,'SANCTIONED') as status from hrm_anytimepunching_reg r, employee_master e, branch_failure b where r.requested_by = e.emp_code and r.remarks = b.failure_id and r.branch_id = " & BranchId & " and to_date(r.att_req_dt) between to_date(' " & Frdt & " ') and to_date(' " & Todt & " ') and r.not_punch is not null union select a.requested_by || '-' || e.emp_name as reqby,to_char(to_date(a.requested_dt)) as reqdt,a.requested_reason as remark,'All Late' as reqtype,decode(a.status_id,0,'APPLIED',5,'AM RECOMMENDED',6,'AM REJECTED',1,'SANCTIONED',2,'REJECTED') as status from hrm_attendance_regularisation a, employee_master e where a.requested_by = e.emp_code and to_date(a.requested_dt) >= ' " & Frdt & " ' and to_date(a.requested_dt) <= ' " & Todt & " ' and a.branch_id = " & BranchId & " order by reqdt").Tables(0)
        dt2 = oh.ExecuteDataSet("select r.requested_by || '-' || e.emp_name as reqby, to_char(to_date(r.requested_dt)) as reqdt,r.remarks as remark,'LATE' as reqtype, decode(r.status_id, 0, 'APPLIED', 9, 'AM RECOMMENDED', 8, 'RM RECOMMENDED', 7, 'AM REJECTED', 6, 'RM REJECTED', 2, 'RH RECOMMENDED', 3, 'RH REJECTED', 1, 'SANCTIONED', 4, 'REJECTED', 10, 'APPLIED', 11, 'RECOMMEND', 12, 'SANCTIONED') as status from hrm_anytimepunching_reg r, employee_master e, employ_firm ef where r.requested_by = e.emp_code and e.emp_code = ef.emp_code and r.branch_id = " & BranchId & " and ef.firm_id = " & Session("firm_id") & " and to_date(r.requested_dt) between to_date(' " & Frdt & " ') and to_date(' " & Todt & " ') and r.not_punch is null union select r.requested_by || '-' || e.emp_name as reqby, to_char(to_date(r.att_req_dt)) as reqdt, b.failure_name as remark, 'NON MARKING' as reqtype, decode(r.status_id, 0, 'APPLIED', 2, 'AM RECOMMENDED', 3, 'RM RECOMMENDED', 5, 'AM REJECTED', 6, 'RM REJECTED', 4, 'RH RECOMMENDED', 7, 'RH REJECTED', 1, 'SANCTIONED', 8, 'REJECTED', 10, 'APPLIED', 11, 'RECOMMEND', 12, 'SANCTIONED') as status from hrm_anytimepunching_reg r, employee_master e, branch_failure b,employ_firm ef where r.requested_by = e.emp_code and r.remarks = b.failure_id and e.emp_code = ef.emp_code and r.branch_id = " & BranchId & " and ef.firm_id = " & Session("firm_id") & " and to_date(r.att_req_dt) between to_date(' " & Frdt & " ') and to_date(' " & Todt & " ') and r.not_punch is not null union select a.requested_by || '-' || e.emp_name as reqby, to_char(to_date(a.requested_dt)) as reqdt, a.requested_reason as remark, 'All Late' as reqtype, decode(a.status_id, 0, 'APPLIED', 5, 'AM RECOMMENDED', 6, 'AM REJECTED', 1, 'SANCTIONED', 2, 'REJECTED') as status from hrm_attendance_regularisation a, employee_master e,employ_firm ef where a.requested_by = e.emp_code and e.emp_code = ef.emp_code and to_date(a.requested_dt) >= ' " & Frdt & " ' and to_date(a.requested_dt) <= ' " & Todt & " ' and a.branch_id = " & BranchId & " and ef.firm_id = " & Session("firm_id") & " order by reqdt").Tables(0)
         report.Load(Server.MapPath("hrm_atten_reg_late_non_rpt.rpt"), OpenReportMethod.OpenReportByTempCopy)
        report.Database.Tables("C1").SetDataSource(dt2)

        report.SetParameterValue("FIRM", Session("firm_name"))

        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.ReportSource = report
    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Close()
        report.Dispose()
        GC.Collect()
    End Sub
End Class

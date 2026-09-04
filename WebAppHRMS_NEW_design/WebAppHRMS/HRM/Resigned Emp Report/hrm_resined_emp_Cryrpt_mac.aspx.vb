Imports system.data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Partial Class Resigned_Emp_hrm_resined_emp_Cryrpt_48e099d21915
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim crSections As Sections
    Dim report As New ReportDocument
    Dim UserAll(), BranchAll() As String
    Dim UserCode, BranchId As Integer
    Dim dt2 As DataTable
    Dim export As New IO.MemoryStream

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim firm As Integer
        firm = Session("firm_id")

        Dim Frdt As String = Request.QueryString.Get("Fdt")
        Dim Todt As String = Request.QueryString.Get("Tdt")
        'dt2 = oh.ExecuteDataSet("Select data.ecode, data.ename , data.entdt , data.disdt , data.reason from (select e.emp_code as ecode,e.emp_name as ename,to_char(m.enter_dt) as entdt,to_char(r.discont_dt) as disdt,r.remarks as reason from employee_master e, employee_resigtermi r, m_resign_appl m where e.emp_code = r.emp_code and r.emp_code = m.emp_code and m.status = 1 and r.discont_dt between to_date('" & Frdt & "') and to_date('" & Todt & "') union all select e.emp_code as ecode, e.emp_name as ename,to_char(r.notice_dt) as entdt,to_char(r.discont_dt) as disdt,r.remarks as reason from employee_master e, employee_resigtermi r where e.emp_code = r.emp_code and r.status_id=3  and e.emp_code not in(select m1.emp_code from m_resign_appl m1 where m1.emp_code=e.emp_code and m1.status=1 ) and r.discont_dt between to_date('" & Frdt & "') and to_date('" & Todt & "') )data , employ_firm f where data.ecode=f.emp_code and f.firm_id=" & firm & " ").Tables(0)
        dt2 = oh.ExecuteDataSet("Select to_char(data.ecode)ecode, to_char(data.ename)ename, to_char(data.entdt)entdt, to_char(data.disdt)disdt, to_char(data.reason)reason, to_char(nvl(mg.leave_days,0))el_balance from (select e.emp_code as ecode, e.emp_name as ename, to_char(m.enter_dt) as entdt, to_char(r.discont_dt) as disdt, r.remarks as reason from employee_master e, employee_resigtermi r, m_resign_appl m where e.emp_code = r.emp_code and r.emp_code = m.emp_code and m.status = 1 and r.discont_dt between to_date('" & Frdt & "') and to_date('" & Todt & "') union all select e.emp_code as ecode, e.emp_name as ename, to_char(r.notice_dt) as entdt, to_char(r.discont_dt) as disdt, r.remarks as reason from employee_master e, employee_resigtermi r where e.emp_code = r.emp_code and r.status_id = 3 and e.emp_code not in (select m1.emp_code from m_resign_appl m1 where m1.emp_code = e.emp_code and m1.status = 1) and r.discont_dt between to_date('" & Frdt & "') and to_date('" & Todt & "')) data left outer join (select emh.leave_days, emh.emp_code from ((select * from EMPLOY_LEAVE_MASTER_HIS union all select * from EMPLOY_LEAVE_MASTER)) emh inner join (select t.emp_code, max(t.approval_date) appr, max(t.process_date) proc from (select * from EMPLOY_LEAVE_MASTER_HIS union all select * from EMPLOY_LEAVE_MASTER) t where emp_code in (select emp_code from employ_firm where firm_id = 8) and t.leave_id = 3 group by t.emp_Code) fr on emh.emp_code = fr.emp_Code and emh.approval_date = fr.appr and emh.process_date = fr.proc where emh.leave_id = 3) mg on mg.emp_code = data.ecode, employ_firm f where data.ecode = f.emp_code and f.firm_id =" & firm & " order by to_date(data.disdt)").Tables(0)


        report.Load(Server.MapPath("hrm_resined_emp_rpt_mac.rpt"), OpenReportMethod.OpenReportByTempCopy)

        report.Database.Tables("resignedemps").SetDataSource(dt2)
        '==== Set Parameter Value
        report.SetParameterValue("FIRM", Session("firm_name"))
        report.SetParameterValue("count", dt2.Rows.Count)
        '==== Set Parameter Value

        Me.CrystalReportViewer1.ReportSource = report

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Dispose()
        report.Close()
    End Sub
End Class

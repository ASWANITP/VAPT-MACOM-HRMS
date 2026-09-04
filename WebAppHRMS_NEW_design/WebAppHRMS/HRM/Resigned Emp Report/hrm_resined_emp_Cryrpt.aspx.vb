Imports system.data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Partial Class Resigned_Emp_hrm_resined_emp_Cryrpt_48e099d21369
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

        'dt2 = oh.ExecuteDataSet("select e.emp_code as ecode,e.emp_name as ename,to_char(m.enter_dt) as entdt,to_char(r.discont_dt) as disdt,r.remarks as reason from employee_master e, employee_resigtermi r, m_resign_appl m where e.emp_code = r.emp_code and r.emp_code = m.emp_code and m.status = 1 and r.discont_dt between to_date('" & Frdt & "') and to_date('" & Todt & "') union all select e.emp_code as ecode, e.emp_name as ename,to_char(r.notice_dt) as entdt,to_char(r.discont_dt) as disdt,r.remarks as reason from employee_master e, employee_resigtermi r where e.emp_code = r.emp_code and r.status_id=3  and e.emp_code not in(select m1.emp_code from m_resign_appl m1 where m1.emp_code=e.emp_code and m1.status=1 ) and r.discont_dt between to_date('" & Frdt & "') and to_date('" & Todt & "')").Tables(0)
        dt2 = oh.ExecuteDataSet("Select data.ecode, data.ename , data.entdt , data.disdt , data.reason from (select e.emp_code as ecode,e.emp_name as ename,to_char(m.enter_dt) as entdt,to_char(r.discont_dt) as disdt,r.remarks as reason from employee_master e, employee_resigtermi r, m_resign_appl m where e.emp_code = r.emp_code and r.emp_code = m.emp_code and m.status = 1 and r.discont_dt between to_date('" & Frdt & "') and to_date('" & Todt & "') union all select e.emp_code as ecode, e.emp_name as ename,to_char(r.notice_dt) as entdt,to_char(r.discont_dt) as disdt,r.remarks as reason from employee_master e, employee_resigtermi r where e.emp_code = r.emp_code and r.status_id=3  and e.emp_code not in(select m1.emp_code from m_resign_appl m1 where m1.emp_code=e.emp_code and m1.status=1 ) and r.discont_dt between to_date('" & Frdt & "') and to_date('" & Todt & "') )data , employ_firm f where data.ecode=f.emp_code and f.firm_id=" & firm & " ").Tables(0)


        report.Load(Server.MapPath("hrm_resined_emp_rpt.rpt"), OpenReportMethod.OpenReportByTempCopy)

        report.Database.Tables("C1").SetDataSource(dt2)
        '==== Set Parameter Value
        report.SetParameterValue("FIRM", Session("firm_name"))
        '==== Set Parameter Value
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.ReportSource = report

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Dispose()
        report.Close()
    End Sub
End Class

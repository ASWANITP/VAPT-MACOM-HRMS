Imports system.data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Partial Class Shift_Change_hrm_esi_Cryreport_a80c34164191
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim crSections As Sections
    Dim report As New ReportDocument
    Dim dt As DataTable
    Dim export As New IO.MemoryStream

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim Frdt As String = Request.QueryString.Get("Fdt")
        Dim Todt As String = Request.QueryString.Get("Tdt")

        '  dt = oh.ExecuteDataSet("select h.emp_code as ecode,e.emp_name as ename,b.BRANCH_NAME as branch,h.esi_no as esino,h.esi_branch as esibranch,h.disp as disp,to_char(h.issue_dt) as issuedt,to_char(h.ent_dt) as entdt,d.esi_photo as id_photo from hrm_esi_add h,employee_master e, branch_dtl_new b,dms.hrm_id_esi_photo d where h.emp_code = e.emp_code and e.branch_id = b.BRANCH_ID and e.status_id = 1 and d.emp_code =e.emp_code and d.ph_stat=1 and h.ent_dt between to_date(' " & Frdt & " ') and to_date(' " & Todt & " ') order by ecode").Tables(0)
        dt = oh.ExecuteDataSet("select h.emp_code as ecode,e.emp_name as ename,b.BRANCH_NAME as branch,h.esi_no as esino,h.esi_branch as esibranch,h.disp as disp,to_char(h.issue_dt) as issuedt,to_char(h.ent_dt) as entdt,d.esi_photo as id_photo from hrm_esi_add h,employee_master e,employ_firm ef, branch_dtl_new b,dms.hrm_id_esi_photo d where h.emp_code = e.emp_code and e.emp_code = ef.emp_code and ef.firm_id = " & Session("firm_id") & " and e.branch_id = b.BRANCH_ID and e.status_id = 1 and d.emp_code =e.emp_code and d.ph_stat=1 and h.ent_dt between to_date(' " & Frdt & " ') and to_date(' " & Todt & " ') order by ecode").Tables(0)
        report.Load(Server.MapPath("hrm_esi_rpt.rpt"), OpenReportMethod.OpenReportByTempCopy)
        report.Database.Tables("c1").SetDataSource(dt)

        report.SetParameterValue("FIRM", Session("firm_name"))
        Me.CrystalReportViewer1.ReportSource = report
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Dispose()
        report.Close()
        GC.Collect()

    End Sub

    Protected Sub CrystalReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Init

    End Sub
End Class

Imports System.Data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Partial Class Photo_StatusUpdate_Report_0147ac805050
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim dt As DataTable
    Dim report As New ReportDocument

    Protected Sub Page_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        report.Close()
        report.Dispose()
        GC.Collect()

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim user As Integer

        user = Me.Session("user_id").ToString.Split("!")(0)

        '...modified Sajiny
        dt = oh.ExecuteDataSet("select  m.emp_code,m.emp_name,case when (MONTHS_BETWEEN(SYSDATE, Max(H.upload_dt)) <= 36) THEN 'UPDATED' ELSE  'NIL' END PHOTO_UPDATION_STATUS,(  select    to_char( max(h.upload_dt)) as upload_dt  from    hrm_emp_upload  h where h.emp_code=m.emp_code) upload_dt, b.BRANCH_NAME as BRANCH from employee_master m  left outer join  hrm_emp_upload  h on h.emp_code=m.emp_code left outer join employ_firm   f  on f.emp_code = m.emp_code left outer join  branch_master   b on  b.BRANCH_ID = m.branch_id where f.firm_id = '" & CInt(Session("firm_id")) & "' and m.emp_code = f.emp_code and m.status_id = 1 and b.BRANCH_ID = m.branch_id group by m.emp_code,m.emp_name ,b.BRANCH_NAME").Tables(0)
        report.Load(Server.MapPath("photoUpdateCrystalReport.rpt"), OpenReportMethod.OpenReportByTempCopy)
        '.................

        report.Database.Tables("DataTable1").SetDataSource(dt)
        report.SetParameterValue("FIRM", Session("firm_name"))
        ''Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.ReportSource = report

    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Close()
        report.Dispose()
        GC.Collect()

    End Sub

    Protected Sub CrystalReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Init

    End Sub
End Class

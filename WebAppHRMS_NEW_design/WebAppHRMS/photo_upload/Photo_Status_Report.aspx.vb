Imports System.Data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Partial Class Photo_Status_Report_9626ce054621
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As DataTable
    Dim report As New ReportDocument

    Protected Sub Page_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        report.Close()
        report.Dispose()
        GC.Collect()

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim user As Integer
        ''modified krishnadas
        user = Me.Session("user_id").ToString.Split("!")(0)
        dt = oh.ExecuteDataSet("select h.emp_code,h.emp_name,decode(h.status_id, 2, 'REJECTED',0,'APPLIED',1,'VERIFIED') as STATUS,h.rejected_reason,h.rejected_dt,h.upload_dt from hrm_emp_upload h where h.emp_code in(" & user & ")").Tables(0)
        report.Load(Server.MapPath("Photo_Status_CrystalReport.rpt"), OpenReportMethod.OpenReportByTempCopy)

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
End Class

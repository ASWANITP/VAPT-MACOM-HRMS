Imports system.data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Partial Class leave_rajeesh_view_leave_supportings_4bbb81ba4437
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim report As New ReportDocument
    Dim export As New IO.MemoryStream
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim dt As DataTable = oh.ExecuteDataSet("select support from macdms.hrm_app_leave_support where emp_code=" & Request.QueryString("empcode") & " and leav_seq=" & Request.QueryString("leavesequence") & " order by id").Tables(0)
        report.Load(Server.MapPath("crpt_leave_supportings.rpt"), OpenReportMethod.OpenReportByTempCopy)
        report.SetDataSource(dt)

        export = report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)
        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "application/pdf"
        Response.BinaryWrite(export.ToArray())

        Response.End()

        Me.CrystalReportViewer1.ReportSource = export

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Dispose()
        report.Close()
        GC.Collect()
    End Sub
End Class

Imports system.data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Partial Class Sd_ta_salary_details_664e3b3a4595
    Inherits System.Web.UI.Page
    Dim report As New ReportDocument
    Dim oStream As New IO.MemoryStream
    Dim dt, dt1, dt2, dt3, dt4, dt5, dt6, dt7, dt11, dt12, dt13, dt16, dt17 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dt = oh.ExecuteDataSet("select b.branch_name,t.emp_code,t.emp_name,t.amount,decode(t.allow_id,0,'SALARY',1,'TA') as allow from sdta t,branch_master b where t.branch_id=b.branch_id  order by t.allow_id,t.emp_code").Tables(0)
        report.Load(Server.MapPath("SD_TA_SALARY_DETAILS.rpt"), OpenReportMethod.OpenReportByTempCopy)
        report.Database.Tables("SDta").SetDataSource(dt)

        oStream = report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)
        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "application/pdf"
        Response.BinaryWrite(oStream.ToArray())
        Response.End()

        Me.CrystalReportViewer1.ReportSource = oStream
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Dispose()
        report.Close()
        GC.Collect()
    End Sub
End Class

Imports system.data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Partial Class nov2009_newresign_resign_attach_583f006b8432
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim report As New ReportDocument
    Dim emp, tdt, sql, sql1 As String
    Dim export As New IO.MemoryStream

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim emp As String = Request.QueryString("empid")

        ' 1) Load your data-table as you already do:
        Dim dt As DataTable = oh.ExecuteDataSet("select attach from macdms.m_resign_appl_image where emp_code=" & emp & "").Tables(0)

        ' 2) Load & bind your report
        report.Load(Server.MapPath("resign_attach.rpt"),
      OpenReportMethod.OpenReportByTempCopy)
        report.SetDataSource(dt)

        ' a) grab the generic stream
        Dim exportStream As IO.Stream = report.ExportToStream(
      CrystalDecisions.Shared.ExportFormatType.PortableDocFormat
    )

        ' b) read it into a byte array (no MemoryStream cast errors)
        Dim pdfBytes(CInt(exportStream.Length) - 1) As Byte
        exportStream.Read(pdfBytes, 0, pdfBytes.Length)

        ' c) write bytes out and end gracefully
        With Response
            .Clear()
            .Buffer = True
            .ContentType = "application/pdf"
            .AddHeader(
        "Content-Disposition",
        "inline; filename=resign_attach.pdf"
      )
            .BinaryWrite(pdfBytes)
            .Flush()
            HttpContext.Current.ApplicationInstance.CompleteRequest()
        End With

        ' 3) clean up
        exportStream.Close()
        report.Close()
        report.Dispose()
    End Sub


    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Dispose()
        report.Close()
        GC.Collect()

    End Sub
End Class

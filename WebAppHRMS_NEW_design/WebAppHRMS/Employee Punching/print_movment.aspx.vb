Imports System.IO
Imports System.text
Imports System.Data
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Partial Class mainshima_9fb560364351
    Inherits System.Web.UI.Page
    Dim path As String = (HttpContext.Current.Request.PhysicalApplicationPath + "images\")
    Dim url1, fnm, fid As String
    Dim dt1 As DataTable
    Dim aj_report As New ReportDocument
    Dim export As New IO.MemoryStream
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As DataTable = oh.ExecuteDataSet("select t.query from hrm_report_master t where t.query_id=135").Tables(0)
        Dim shima As String = dt.Rows(0)(0).ToString.Split("#")(1).Replace("mycode", Request.QueryString("c"))
        shima = shima.Replace("mydate", Request.QueryString("d"))
        shima = shima.Replace("myexit", Request.QueryString("ex"))
        shima = shima.Replace("myentry", Request.QueryString("en"))
        Dim dts As DataTable = oh.ExecuteDataSet(shima).Tables(0)
        aj_report.Load(Server.MapPath("movrpt.rpt"), OpenReportMethod.OpenReportByTempCopy)
        aj_report.SetParameterValue("mydate", dts.Rows(0)(0))
        aj_report.SetParameterValue("mycode", dts.Rows(0)(1))
        aj_report.SetParameterValue("myapdt", dts.Rows(0)(2))
        aj_report.SetParameterValue("myname", dts.Rows(0)(3))
        aj_report.SetParameterValue("myext", dts.Rows(0)(4))
        aj_report.SetParameterValue("mydep", dts.Rows(0)(5))
        aj_report.SetParameterValue("myent", dts.Rows(0)(6))
        aj_report.SetParameterValue("myplace", dts.Rows(0)(7))
        aj_report.SetParameterValue("mypurp", dts.Rows(0)(8))
        aj_report.SetParameterValue("mov_type", dts.Rows(0)(9))
        aj_report.SetParameterValue("recby", dts.Rows(0)(10))
        aj_report.SetParameterValue("recpost", dts.Rows(0)(11))
        aj_report.SetParameterValue("mystatus", dts.Rows(0)(12))
        aj_report.SetParameterValue("appby", dts.Rows(0)(13))
        aj_report.SetParameterValue("appost", dts.Rows(0)(14))
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.ReportSource = aj_report
        'export = aj_report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)
        'Response.Clear()
        'Response.Buffer = True
        'Response.ContentType = "application/pdf"
        'Response.BinaryWrite(export.ToArray())
        'Response.End()

        Dim exportStream As Stream = aj_report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)

        ' Copy to MemoryStream to make it usable
        Dim export As New MemoryStream()
        exportStream.CopyTo(export)
        export.Position = 0

        ' Send it to the browser
        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "application/pdf"
        Response.AddHeader("content-disposition", "inline; filename=report.pdf")
        Response.BinaryWrite(export.ToArray())
        Response.Flush()
        HttpContext.Current.ApplicationInstance.CompleteRequest()


    End Sub
End Class
Imports system.data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

Partial Class emp_image_view_emp_photo_b00eeb493068
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim report As New ReportDocument
    Dim export As New IO.MemoryStream
    Dim dt As DataTable

    Protected Sub Page_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        report.Close()
        report.Dispose()
        GC.Collect()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim usr As Integer = Me.Session("user_id").ToString.Split("!")(0)
        ''modified krishnadas
        Dim count As Integer = 0
        'Dim ab As Integer = Int(Me.Request.QueryString("empcode").ToString.Split("@")(0))
        ' Dim pq As Integer = Int(Me.Request.QueryString("empcode").ToString.Split("@")(1))
        Dim ab As Integer = usr
        'Dim pq As Integer = Int(Me.Request.QueryString("iid"))
        'If pq = 1 Then
        Dim st As DataTable = oh.ExecuteDataSet("select count(*) from macdms.hrm_emp_ph_certi t where emp_code=" & ab).Tables(0)
        If st.Rows(0)(0) > 0 Then
            dt = oh.ExecuteDataSet("select photo as imag from macdms.hrm_emp_ph_certi t where emp_code=" & ab).Tables(0)
            If Not IsDBNull(dt.Rows(0)(0)) Then
                count = 1
            End If
        End If
        'Else
        Dim st1 As DataTable = oh.ExecuteDataSet("select count(*) from macdms.hrm_emp_ph_certi t where emp_code=" & ab).Tables(0)
        If st.Rows(0)(0) > 0 Then
            dt = oh.ExecuteDataSet("select photo as imag from macdms.hrm_emp_ph_certi t where emp_code=" & ab).Tables(0)
            If Not IsDBNull(dt.Rows(0)(0)) Then
                count = 1
            End If
        End If
        'End If
        If count = 1 Then
            report.Load(Server.MapPath("crpt_emp_image.rpt"), OpenReportMethod.OpenReportByTempCopy)
            report.SetDataSource(dt)

            Dim exportStream As Stream = report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)

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

            Me.CrystalReportViewer1.ReportSource = export
        Else
            Dim cl_script As New StringBuilder
            cl_script.Append("   alert('Photo Not Found') ;")
            cl_script.Append(" window.open('emp_image.aspx');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            Exit Sub
        End If

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Close()
        report.Dispose()
        GC.Collect()
    End Sub
End Class

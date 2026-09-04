Imports System.IO
Imports System.text
Imports System.Data
Imports system.Data.OracleClient
Partial Class mainshima_59332f4e1408
    Inherits System.Web.UI.Page
    Dim path As String = (HttpContext.Current.Request.PhysicalApplicationPath + "images\")
    Dim url1, fnm, fid As String
    Dim dt1 As DataTable
    Dim export As New IO.MemoryStream
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sd As String = "select h.attach a from macdms.m_resign_appl_image h, m_resign_appl a where h.emp_code =a.emp_code and a.status=h.status and h.emp_code=" & Request.QueryString("c") & ""
        dt1 = oh.ExecuteDataSet(sd).Tables(0)
        'Dim dr As OracleDataReader = oh.ExecuteReader(sd)
        'While dr.Read()
        '    If IsDBNull(dr("a")) Then
        '        Dim cl_script1 As New System.Text.StringBuilder
        '        cl_script1.Append("        alert('No Attachment Found!!');")
        '        cl_script1.Append("            window.open('resign_report.aspx','_self');")
        '        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        '        Exit Sub
        '    Else
        '        Response.Clear()
        '        Response.Buffer = True
        '        Response.AddHeader("content-disposition", "attachment;filename=ph.jpg")
        '        Response.Charset = ""
        '        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        '        Response.BinaryWrite(CType(dr("a"), Byte()))
        '        Response.[End]()
        '    End If
        'End While
        If Not (IsDBNull(dt1.Rows(0)(0))) Then

            Dim imgURLtoDownload As String = "Resign Attach " & Request.QueryString("c") & ".jpg"
            Dim bl() As Byte
            bl = CType(dt1.Rows(0)(0), Byte())
            Response.ClearContent()
            Response.ClearHeaders()
            Response.ContentType = "application/octet-stream"
            Response.ContentEncoding = Encoding.UTF8
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + imgURLtoDownload)
            Response.AppendHeader("Content-Length", CStr(bl.Length))
            Response.OutputStream.Write(bl, 0, bl.Length)
            Response.Flush()
            Response.End()
        Else
            Response.Write("<script language=javascript>alert('No attachment Available');</script>")
        End If
    End Sub
End Class

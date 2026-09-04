Imports System.Data
Imports System.Data.OracleClient
Partial Class payroll_Posting_ShowCertificate_7aa3f5a96725
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim sql As String
            Dim ds As New DataSet
            Dim byImage As Byte()
            sql = Request.QueryString("ApplNo")
            ds = oh.ExecuteDataSet("select SSLC_IMAGE from macdms.Emp_SSLC_Scan_dtls where EMP_CODE=" & sql)
            byImage = CType(ds.Tables(0).Rows(0)(0), Byte())
            Response.ContentType = "image/jpeg"
            Response.BinaryWrite(byImage)
            Response.End()

        Catch ex As Exception

        End Try
    End Sub
End Class

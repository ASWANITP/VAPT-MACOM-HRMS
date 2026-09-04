
Partial Class payroll_Posting_SSLC_Img_Certificate_60cd7c961314
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Img_Cert.ImageUrl = "~/payroll/Posting/ShowCertificate.aspx?ApplNo=" & Session("Cert_EMP_CODE") 'Request.QueryString("ApplNo")
        Catch ex As Exception

        End Try
    End Sub
End Class

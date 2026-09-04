Partial Class Tour_Sanction_tour_sanction_wform_8621ff0f2981
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2, dt10, dt11, dt12 As New DataTable
    Dim dr, dr1 As DataRow
    Dim str, str1, sql, sql1, sql2, str3, str4, str5, str6, str7 As String
    Dim ttype As Integer
    Dim uid(), usr() As String
    Dim res As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                Dim srlNo As Integer = Convert.ToInt32(Session("SrlNO"))

                ' Fetch image/pdf blob and optional file type (if available)
                Dim sql As String = "SELECT p.image FROM FEEDBACK_FRM p WHERE p.srno=" & srlNo & " "
                ' Dim dt As DataTable = oh.ExecuteDataSet(sql, New OracleParameter("p1", OracleDbType.Int32, srlNo, ParameterDirection.Input)).Tables(0)
                Dim dt As DataTable = oh.ExecuteDataSet(sql).Tables(0)

                If dt.Rows.Count = 0 Then
                    Response.StatusCode = 404
                    Response.End()
                    Return
                End If

                Dim data() As Byte = CType(dt.Rows(0)("IMAGE"), Byte())
                Dim mime As String = GetMimeType(data, String.Empty)

                Response.Clear()
                Response.ClearHeaders()
                Response.Buffer = True
                Response.ContentType = mime
                Response.AddHeader("Content-Length", data.Length.ToString())
                Response.AddHeader("Content-Disposition", $"inline; filename=""doc{GetExtension(mime)}""")
                Response.BinaryWrite(data)
                Response.Flush()
                HttpContext.Current.ApplicationInstance.CompleteRequest()

            Catch ex As Exception
                Response.StatusCode = 500
                Response.Write("Error streaming file: " & Server.HtmlEncode(ex.Message))
            End Try
        End If
    End Sub
    Private Function GetMimeType(bin() As Byte, storedMime As String) As String
        If bin.Length >= 4 AndAlso System.Text.Encoding.ASCII.GetString(bin, 0, 4) = "%PDF" Then
            Return "application/pdf"
        ElseIf bin.Length >= 3 AndAlso bin(0) = &HFF AndAlso bin(1) = &HD8 Then
            Return "image/jpeg"
        ElseIf bin.Length >= 8 AndAlso bin(0) = &H89 AndAlso bin(1) = &H50 AndAlso bin(2) = &H4E Then
            Return "image/png"
        ElseIf Not String.IsNullOrEmpty(storedMime) Then
            Return storedMime
        Else
            Return "application/octet-stream"
        End If
    End Function

    Private Function GetExtension(mime As String) As String
        Select Case mime.ToLower()
            Case "application/pdf" : Return ".pdf"
            Case "image/jpeg" : Return ".jpg"
            Case "image/png" : Return ".png"
            Case Else : Return ""
        End Select
    End Function

End Class

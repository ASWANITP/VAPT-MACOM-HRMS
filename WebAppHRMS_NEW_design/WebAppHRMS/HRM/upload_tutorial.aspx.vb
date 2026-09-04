Imports System.Data
Imports System.Data.oracleclient
Imports System.IO
Partial Class oct2010_upload_tutorial_a40b26834227
    Inherits System.Web.UI.Page
    Dim sql, fnm As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub upload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles upload.Click
        If Me.FileUpload1.HasFile Then
            Dim fileExtension As String
            fileExtension = System.IO.Path. _
                GetExtension(Me.FileUpload1.FileName).ToLower()
            Dim allowedExtensions As String() = _
                {".ppt"}
            Dim fileok As Boolean
            fileok = False
            For i As Integer = 0 To allowedExtensions.Length - 1
                If fileExtension = allowedExtensions(i) Then
                    fileok = True
                End If
            Next
            If Not (fileok) Then
                Dim cl_script As New StringBuilder
                cl_script.Append("   alert('First Attachement Type Not Supported! PPT format only supported!') ;")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                Exit Sub
            End If
        End If
        Dim DirPath As String
        DirPath = Me.Server.MapPath("../IMAGE")
        Dim cp As String = Me.Server.MapPath(Me.Request.ApplicationPath)

        Try
            If Me.FileUpload1.FileName <> "" Then


                fnm = DirPath + "/sundaytraining.ppt"
                If Me.FileUpload1.HasFile Then
                    Me.FileUpload1.SaveAs(fnm)
                End If
                Dim fs As New IO.FileStream(fnm, IO.FileMode.Open, IO.FileAccess.Read)
                Dim bl(fs.Length) As Byte
                fs.Read(bl, 0, fs.Length)
                fs.Close()
                fs.Dispose()
                Dim fp As New IO.FileInfo(fnm)
                'If fp.Exists Then
                '    fp.Delete()
                'End If
            End If
        Catch ex As Exception
            Response.Write(ex.Message.ToString)
        End Try

        Dim cl_script1 As New StringBuilder
        cl_script1.Append("   alert('Successfully Uploaded!!') ;")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script1.ToString, True)


    End Sub
End Class

Imports system
Imports System.Data
Imports System.IO
Imports System.Data.OracleClient
Partial Class tour_Call_feedback_frm_4947bfe85815
    Inherits System.Web.UI.Page
    Dim dt, dd2, dt1, dt2, dts1, dts2, dtpri, dtrs As New DataTable
    Dim str_tkn As New StringBuilder
    Dim cat, sf() As Integer
    Dim usr(), Sql,fnm As String
    Dim dts, dth, dd1 As New DataTable
    Dim str, strs, frm As String
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        usr = Me.Session("user_id").ToString.Split("!")
        dd2 = oh.ExecuteDataSet("select count(*) from TBLFIELD_PUNCH s where s.empcode=" & usr(0) & "").Tables(0)
        If dd2.Rows(0)(0) = 0 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('You are not Authorised to View this Page !!!!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)

            'Me.Server.Transfer("../show_err.aspx")
        End If
        'If Session("firm_id") = 8 Then
        dt = oh.ExecuteDataSet("SELECT e.emp_code, e.emp_name FROM employee_master e WHERE e.emp_code = " & usr(0) & "").Tables(0)
       
        Me.txt_ecode.Text = dt.Rows(0)(0)
        Me.txt_ename.Text = dt.Rows(0)(1)
        'Me.sr_tckt.Text = dt.Rows(0)(2)
    End Sub
    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Dim script1 As New System.Text.StringBuilder()
        Dim regex As New System.Text.RegularExpressions.Regex("[^a-zA-Z0-9]")
        Dim imageBytes As Byte() = Upload.FileBytes

        Try
            ' File validation
            If Not Me.Upload.HasFile Then
                script1.Append("alert('Please upload a file..!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "client_script", script1.ToString(), True)
                Exit Sub
            End If



            If Not System.Text.RegularExpressions.Regex.IsMatch(Me.sr_tckt.Text, "^[0-9]*$") Then

                script1.Append("alert('Please enter Correct Ticket Number Only!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "client_script", script1.ToString(), True)
                Exit Sub
            End If

            

            Dim fileExtension As String = Path.GetExtension(Me.Upload.FileName).ToLower()
            Dim allowedExtensions As String() = {".pdf"}
            'Dim allowedExtensions As String() = {".jpeg", ".jpg", ".pdf"}
            Dim videoExtensions As String() = {".mp4", ".avi", ".mov", ".wmv"}
            Dim maxFileSize As Integer = 2 * 1024 * 1024 ' 2 MB in bytes

            If Array.IndexOf(videoExtensions, fileExtension) >= 0 Then
                script1.Append("alert('Video files are not allowed for upload!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "client_script", script1.ToString(), True)
                Exit Sub
            End If

            If Array.IndexOf(allowedExtensions, fileExtension) < 0 Then
                script1.Append("alert('Only PDF files allowed!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "client_script", script1.ToString(), True)
                Exit Sub
            End If

            If Me.Upload.PostedFile.ContentLength > maxFileSize Then
                script1.Append("alert('Maximum file size is 2MB!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "client_script", script1.ToString(), True)
                Exit Sub
            End If

            usr = Me.Session("user_id").ToString.Split("!")
            Dim emp As Integer = CInt(usr(0).ToString())

            Dim rpt(3) As OracleParameter
            rpt(0) = New OracleParameter("emp_cod", OracleType.Number)
            rpt(0).Direction = ParameterDirection.Input
            rpt(0).Value = emp

            rpt(1) = New OracleParameter("emp_nam", OracleType.VarChar, 100)
            rpt(1).Direction = ParameterDirection.Input
            rpt(1).Value = Me.txt_ename.Text

            rpt(2) = New OracleParameter("srtktnum", OracleType.Number, 60)
            rpt(2).Direction = ParameterDirection.Input
            rpt(2).Value = Me.sr_tckt.Text

           

            rpt(3) = New OracleParameter("msg", OracleType.VarChar, 500)
            rpt(3).Direction = ParameterDirection.Output
            oh.ExecuteNonQuery("feedbckfrm_confrm", rpt)

            Dim message As String = rpt(3).Value

            If message.StartsWith("0000") Then

                If Me.Upload.FileName <> "" Then
                    Dim DirPath As String
                    DirPath = Me.Server.MapPath("../image")
                    fnm = GetUniqueFilename(DirPath + "support1.pdf")
                    If Me.Upload.HasFile Then
                        Me.Upload.SaveAs(fnm)
                    End If
                    Dim fs As New IO.FileStream(fnm, IO.FileMode.Open, IO.FileAccess.Read)
                    Dim bl(fs.Length) As Byte
                    fs.Read(bl, 0, fs.Length)
                    fs.Close()
                    Dim fp As New IO.FileInfo(fnm)
                    If fp.Exists Then
                        fp.Delete()
                    End If
                    Sql = "update FEEDBACK_FRM f set f.image = :ph where f.empcode = :ecode"
                    Dim parm_coll(1) As OracleParameter
                    parm_coll(0) = New OracleParameter
                    parm_coll(0).ParameterName = "ph"
                    parm_coll(0).OracleType = OracleType.Blob
                    parm_coll(0).Direction = ParameterDirection.Input
                    parm_coll(0).Value = bl
                    parm_coll(1) = New OracleParameter
                    parm_coll(1).ParameterName = "ecode"
                    parm_coll(1).OracleType = OracleType.Number
                    parm_coll(1).Direction = ParameterDirection.Input
                    parm_coll(1).Value = usr(0)

                    oh.ExecuteNonQuery(Sql, parm_coll)
                End If
            End If

            script1.Append("alert('" & message & "');")
            script1.Append("window.open('Call_feedback_frm.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "client_script", script1.ToString(), True)

        Catch ex As Exception
            script1.Append("alert('Error: " & ex.Message & "');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "client_script", script1.ToString(), True)
        End Try
    End Sub
    Protected Sub cmd_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_exit.Click
        Response.Redirect("~/Home.aspx")
    End Sub
    Public Shared Function GetUniqueFilename(ByVal FileName As String) As String
        Dim count As Integer = 0
        Dim Name As String = ""

        If System.IO.File.Exists(FileName) Then
            Dim f As New System.IO.FileInfo(FileName)
            If Not String.IsNullOrEmpty(f.Extension) Then
                Name = f.FullName.Substring(0, f.FullName.LastIndexOf("."))
            Else
                Name = f.FullName
            End If
            While System.IO.File.Exists(FileName)
                count += 1
                FileName = Name + count.ToString() + f.Extension
            End While
        End If
        Return FileName
    End Function

End Class

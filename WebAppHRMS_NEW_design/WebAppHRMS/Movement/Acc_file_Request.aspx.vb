Imports System.Data
Imports System.Data.OracleClient
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Interop
Imports CrystalDecisions.[Shared].Json


Partial Class Acc_file_Request
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim oh, oh1 As New Helper.Oracle.OracleHelper
    Dim res As String
    Dim frm As Integer
    Dim usr(), Sql, fnm As String
    Dim sf() As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'CType(Me.Master, WebAppHRMS.edp).Subtitle = "EMPLOYEE ENROLLMENT"
        Dim masterPage As WebAppHRMS.edp = CType(Me.Master, WebAppHRMS.edp)
        masterPage.Subtitle = "ACCOUNTS FILE MOVEMENT REQUEST"
        frm = Session("firm_id")
        Dim script_val As String
        Dim dt1 As New DataTable
        script_val = "var loanno;" & "loanno='" & "" & Me.files_nos.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function call_server(arg,context) { " & cbref & "; } "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "call_server", cbscript, True)
        FileUpload1.Attributes("onchange") = "UploadFile(this)"
        sf = Session("user_id").ToString.Split("!")
        'If Session("access_id") = 33 Then
        dt1 = oh1.ExecuteDataSet("select count(t.emp_id) ecod  from form_accessibility t  where form_id = 9991  and emp_id = " & Session("user_id").ToString.Split("!")(0)).Tables(0)
        If dt1.Rows(0)(0) = 0 Then
            Server.Transfer("~/show_err.aspx")
        End If

        If Not IsPostBack Then
            Dim dt As New DataTable
            dt = oh.ExecuteDataSet("SELECT emp FROM (SELECT '------------------Select------------------' AS emp, NULL AS emp_code FROM dual UNION ALL SELECT e.emp_code || '-' || e.emp_name AS emp, e.emp_code FROM employee_master e JOIN employ_firm f ON e.emp_code = f.emp_code JOIN department_mst g ON e.department_id = g.dep_id WHERE f.firm_id = 8 AND e.status_id = 1 AND e.emp_code > 9999 AND g.dep_id = 552 AND e.emp_code <> 101127) ORDER BY CASE WHEN emp_code IS NULL THEN 0 ELSE 1 END, emp_code").Tables(0)
            Me.cmb_dep.DataSource = dt
            Me.cmb_dep.DataTextField = dt.Columns(0).ColumnName
            'Me.cmb_dep.DataValueField = dt.Columns(1).ColumnName
            Me.cmb_dep.DataBind()

        End If

        If frm = 8 Then
            dt1 = oh.ExecuteDataSet("SELECT e.emp_code || '-----' || e.emp_name, e.emp_code, d.dep_name FROM employee_master e, department_mst d WHERE e.emp_code = " & sf(0) & " AND e.department_id = d.dep_id").Tables(0)
        End If
        '  End If
        Try
            Me.req_name.Value = dt1.Rows(0)(0)
            Me.dep_name.Value = dt1.Rows(0)(2)

            Dim sql As String


        Catch ex As Exception
        Finally
            dt1.Dispose()
        End Try



        ' Response.Redirect("../../show_err.aspx")
        'End If
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent

    End Sub

    Protected Sub cmd_confirm_Click(sender As Object, e As EventArgs) Handles cmd_confirm.Click



        ' --- File type validation ---
        If FileUpload1.HasFile Then
            Dim ext As String = Path.GetExtension(FileUpload1.FileName).ToLower()
            Dim allowedExts As String() = {".doc", ".docx", ".xls", ".xlsx", ".png", ".jpg", ".pdf"}

            If Not allowedExts.Contains(ext) Then
                lbl_err.Text = "Only DOC, DOCX, XLS, XLSX,PDF, JPG and PNG files are allowed."
                Exit Sub
            End If

        End If


        Dim fileSize As Integer = FileUpload1.PostedFile.ContentLength
        If fileSize > 2 * 1024 * 1024 Then

            Dim cl_scriptSize As New System.Text.StringBuilder(1, 200)
            cl_scriptSize.Append("alert('Upload failed: File size must not exceed 2 MB.');")
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "fileSizeAlert", cl_scriptSize.ToString(), True)
            Exit Sub
        End If


        ' Build parameters in the exact order of the procedure signature
        Dim op(13) As OracleParameter
        Try
            op(0) = New OracleParameter("File_Num", OracleType.Number)
            op(0).Value = DBNull.Value
            op(0).Direction = ParameterDirection.Input

            ' 0 Ref_No
            op(1) = New OracleParameter("Ref_Num", OracleType.VarChar, 30)
            'op(1).Value = Me.file_no.Value.Trim()
            op(1).Value = Me.files_nos.Value.Trim()
            op(1).Direction = ParameterDirection.Input

            ' 1 Req_Name
            Dim reqParts() As String = req_name.Value.Split("-"c)
            Dim reqCode As String = reqParts(0).Trim()
            op(2) = New OracleParameter("Req_Names", OracleType.VarChar, 20)
            op(2).Value = reqCode
            op(2).Direction = ParameterDirection.Input

            ' 2 Dep_Name
            op(3) = New OracleParameter("Dep_Names", OracleType.VarChar, 30)
            op(3).Value = Me.dep_name.Value.Trim()
            op(3).Direction = ParameterDirection.Input

            ' 3 Purpose
            op(4) = New OracleParameter("Purposes", OracleType.VarChar, 50)
            op(4).Value = Me.purpose.Value.Trim()
            op(4).Direction = ParameterDirection.Input

            ' 4 Receiver_Name
            Dim recParts() As String = cmb_dep.SelectedItem.Text.Split("-"c)
            Dim recCode As String = recParts(0).Trim()
            op(5) = New OracleParameter("Receiver_Names", OracleType.VarChar, 20)
            op(5).Value = recCode
            op(5).Direction = ParameterDirection.Input

            ' 5 Upload_file
            op(6) = New OracleParameter("Upload_files", OracleType.Blob)
            'op(6).Value = If(FileUpload1.HasFile, FileUpload1.FileBytes, DBNull.Value)
            op(6).Value = DBNull.Value
            op(6).Direction = ParameterDirection.Input

            ' 6 Upload_filename
            op(7) = New OracleParameter("Upload_filenames", OracleType.VarChar, 4000)
            'op(7).Value = If(FileUpload1.HasFile, Path.GetFileName(FileUpload1.FileName), DBNull.Value)
            op(7).Value = DBNull.Value
            op(7).Direction = ParameterDirection.Input

            ' 7 Upload_contenttype
            op(8) = New OracleParameter("Upload_contenttypes", OracleType.VarChar, 4000)
            op(8).Value = If(FileUpload1.HasFile, FileUpload1.PostedFile.ContentType, DBNull.Value)
            ' op(8).Value = DBNull.Value
            op(8).Direction = ParameterDirection.Input

            ' 8 Remark
            op(9) = New OracleParameter("Remarks", OracleType.VarChar, 200)
            op(9).Value = Me.remark.Value.Trim()
            op(9).Direction = ParameterDirection.Input

            ' 9 Receiver_Remarks  (note the plural to match procedure)
            op(10) = New OracleParameter("Receiver_Remarks", OracleType.VarChar, 200)
            op(10).Value = DBNull.Value
            op(10).Direction = ParameterDirection.Input

            ' 10 ActionType
            op(11) = New OracleParameter("ActionTypes", OracleType.VarChar, 200)
            op(11).Value = "Request"
            op(11).Direction = ParameterDirection.Input

            ' 11 message (OUT)
            op(12) = New OracleParameter("messages", OracleType.VarChar, 2000)
            op(12).Direction = ParameterDirection.Output

            op(13) = New OracleParameter("file", OracleType.Number)
            op(13).Direction = ParameterDirection.Output


            ' Execute
            oh.ExecuteNonQuery("Acc_File_Movement", op)

            Dim msg As String = If(op(12).Value IsNot Nothing, op(12).Value.ToString(), "")

            If msg = 111 Then

                'If Me.FileUpload1.FileName <> "" Then
                '    Dim DirPath As String
                '    DirPath = Me.Server.MapPath("../image")
                '    'fnm = System.IO.Path.GetFileName(Me.FileUpload1.FileName)
                '    fnm = GetUniqueFilename(DirPath + "support1.pdf")

                '    If Me.FileUpload1.HasFile Then
                '        Me.FileUpload1.SaveAs(fnm)
                '    End If

                '    Dim fs As New IO.FileStream(fnm, IO.FileMode.Open, IO.FileAccess.Read)
                '    Dim bl(fs.Length) As Byte
                '    fs.Read(bl, 0, fs.Length)
                '    fs.Close()
                '    Dim fp As New IO.FileInfo(fnm)
                '    If fp.Exists Then
                '        fp.Delete()
                '    End If
                '    Dim parm_coll(1) As OracleParameter
                '    parm_coll(0) = New OracleParameter
                '    parm_coll(0).ParameterName = "ph"
                '    parm_coll(0).OracleType = OracleType.Blob
                '    parm_coll(0).Direction = ParameterDirection.Input
                '    parm_coll(0).Value = bl
                '    parm_coll(1) = New OracleParameter
                '    parm_coll(1).ParameterName = "file"
                '    parm_coll(1).OracleType = OracleType.Number
                '    parm_coll(1).Direction = ParameterDirection.Input
                '    parm_coll(1).Value = op(13).Value
                '    Sql = "update tbl_accfile_mov x set x.upload_file = :ph where x.file_no = :file"
                '    oh.ExecuteNonQuery(Sql, parm_coll)
                'End If

                Dim fnm_1 As String
                Dim FileExtension_1 As String = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName)
                ' Dim cp_1 As String = Me.Server.MapPath(Me.Request.ApplicationPath)
                'fnm_1 = GetUniqueFilename(cp_1 + "\image\" + "Copy1" + FileExtension_1)
                Dim cp_1 As String = "C:\Users\Public\Downloads"
                fnm_1 = GetUniqueFilename(cp_1 + FileExtension_1)
                FileUpload1.SaveAs(fnm_1)
                Dim fs1 As New IO.FileStream(fnm_1, IO.FileMode.Open)
                Dim BData_1() As Byte = New [Byte](fs1.Length) {}
                fs1.Read(BData_1, 0, fs1.Length)


                Dim parm_coll(0) As OracleParameter
                parm_coll(0) = New OracleParameter
                parm_coll(0).ParameterName = "BlobParameter_1"
                parm_coll(0).OracleType = OracleType.Blob
                parm_coll(0).Direction = ParameterDirection.Input
                parm_coll(0).Value = BData_1

                Dim Sql, id As String
                id = op(13).Value
                Sql = "update tbl_accfile_mov t set t.upload_file = :BlobParameter_1, t.Upload_filename = '" + FileExtension_1 + "'   where t.file_no = '" + id + "' "
                Dim res As String = oh.ExecuteNonQuery(Sql, parm_coll)
                fs1.Close()
                File.Delete(fnm_1)
            End If

            Dim cl_script1 As New System.Text.StringBuilder(1, 500)
            'cl_script1.Append("alert('')
            cl_script1.Append("  alert('File Requested Successfully');")
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "client script", cl_script1.ToString(), True)


            files_nos.Value = String.Empty
            purpose.Value = String.Empty
            cmb_dep.ClearSelection()
            remark.Value = String.Empty
            FileUpload1.Attributes.Clear()


        Catch EX As Exception
            If Not Me.FileUpload1.HasFile Then
                Dim cl_script32 As New System.Text.StringBuilder(1, 500)
                cl_script32.Append("  alert('PLEASE CHOOSE A FILE TO UPLOAD');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script1", cl_script32.ToString, True)
                Exit Sub
            Else

                Dim cl_script21 As New System.Text.StringBuilder(1, 500)
                'cl_script21.Append("  alert('UPDATION FAILED');")
                cl_script21.Append("alert('Upload failed: " & EX.Message.Replace("'", "\'") & "');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script1", cl_script21.ToString, True)
            End If

            Dim DirPath As String = Me.hid1.Value
            If File.Exists(DirPath) Then
                System.IO.File.Delete(DirPath)
            End If
            Me.hid1.Value = ""
        End Try



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
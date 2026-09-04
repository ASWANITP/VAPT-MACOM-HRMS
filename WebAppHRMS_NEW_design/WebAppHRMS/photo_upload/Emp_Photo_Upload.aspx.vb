Imports System.Data
Imports System.Data.oracleclient
Imports System.IO
Partial Class HRM_Emp_Photo_Upload_3c997e341915
    Inherits System.Web.UI.Page
    Dim sql, sql7, sql1, sql20, fnm As String
    Dim oh As New Helper.Oracle.OracleHelper
    Dim res As String
    Dim usr() As String
    ''MODIFIED KRISHNAdas
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '--------VAPT - Prevent Caching of Sensitive Content--------
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1))
        Response.Cache.SetNoStore()
        Response.AppendHeader("Pragma", "no-cache")
        
        '--------VAPT - Validate Session--------
        If Session("user_id") Is Nothing Then
            RedirectToLogin()
            Return
        End If
        
        usr = Me.Session("user_id").ToString.Split("!")
        Dim emp, emp1 As New DataTable
        'Dim dd As DataTable = oh.ExecuteDataSet("select count(h.emp_code) from hrm_esi_upload h where h.status_id <= 1 and h.emp_code=" & usr(0) & "").Tables(0)
        'Dim dd As DataTable = oh.ExecuteDataSet("select count(h.emp_code) from HRM_Emp_UPLOAD h where h.status_id <= 1 and h.emp_code=" & usr(0) & "").Tables(0)
        Dim dd As DataTable = oh.ExecuteDataSet("select count(h.emp_code)  from HRM_Emp_UPLOAD h where h.status_id IN(0,1)  and h.emp_code = " & usr(0) & " union   select count(t.emp_code)  from macdms.hrm_emp_ph_certi t where t.emp_code = " & usr(0) & " and t.photo is null").Tables(0)
        Dim f As Integer = dd.Rows(0)(0)
        If f = 0 Then
            Dim dt As DataTable = oh.ExecuteDataSet("select sysdate from dual").Tables(0)
            Dim appdte As Date = dt.Rows(0)(0)
            Me.txtdate.Text = Format(dt.Rows(0)(0), "dd/MMM/yyyy")
            'Me.txtdate.Text = Format(System.DateTime.Now, "dd/MMM/yyyy")



            sql = "select e.emp_code,e.emp_name,p.post_name,d.designation,dm.dep_name,b.branch_name,e.join_dt from employee_master e,post_mst p,designation_master d,branch_master b,department_mst dm where e.post_id=p.post_id and e.department_id=dm.dep_id and d.designation_id=e.designation_id and e.branch_id=b.branch_id and emp_code=" & usr(0) & ""
            emp = oh.ExecuteDataSet(sql).Tables(0)
            If emp.Rows.Count > 0 Then
                Me.txtecode.Text = usr(0)
                Me.txtename.Text = emp.Rows(0)(1)
                Me.txtpost.Text = emp.Rows(0)(2)
                Me.txtdes.Text = emp.Rows(0)(3)
                Me.txtdep.Text = emp.Rows(0)(4)
                Me.txtbranch.Text = emp.Rows(0)(5)
                Me.txtjdate.Text = Format(emp.Rows(0)(6), "dd/MMM/yyyy")
            End If
        Else
            sql1 = "select e.emp_name from employee_master e where e.emp_code=" & usr(0) & ""
            emp1 = oh.ExecuteDataSet(sql1).Tables(0)

            Dim cl_script As New StringBuilder
            cl_script.Append("   alert('" & emp1.Rows(0)(0) & " , YOUR EMP PHOTO ALREADY UPLOADED!!!') ;")
            cl_script.Append("window.open('../../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)

            Exit Sub
            'Response.Redirect("../home.aspx")
        End If
    End Sub

    Protected Sub btnConfrm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfrm.Click
        usr = Me.Session("user_id").ToString.Split("!")
        'Dim sqq As DataTable = oh.ExecuteDataSet("select count(*) from hrm_emp_upload l where l.emp_code=" & usr(0) & " and l.status_id in(0,1)").Tables(0)

        Dim sqq As DataTable = oh.ExecuteDataSet("select count(*) from hrm_emp_upload l where l.emp_code=" & usr(0) & " and l.status_id in(1)").Tables(0)
        oh.ExecuteNonQuery("update hrm_emp_upload h set h.status_id=2,h.rejected_dt=to_date(sysdate),h.rejected_reason = 'Photo Updated' where h.emp_code=" & usr(0) & " and h.status_id=0")


        If Me.Emp_support1.FileName <> "" Then
            If Me.Emp_support1.HasFile Then
                '--------VAPT - Comprehensive File Validation--------
                If Not ValidateUploadedFile(Me.Emp_support1) Then
                    Dim cl_scrip As New StringBuilder
                    cl_scrip.Append("   alert('Invalid file type or malicious content detected!') ;")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_scrip.ToString, True)
                    Exit Sub
                End If
            End If

            Dim dt As DataTable = oh.ExecuteDataSet("select to_date(sysdate) from dual").Tables(0)
            Dim appdte As Date = dt.Rows(0)(0)
            'Try
            'Dim dd As DataTable = oh.ExecuteDataSet("select count(h.emp_code) from hrm_esi_upload h where h.status_id <= 1 and h.emp_code=" & usr(0) & "").Tables(0)
            Dim dd As DataTable = oh.ExecuteDataSet("select count(h.emp_code) from hrm_emp_upload h where h.status_id <= 1 and h.emp_code=" & usr(0) & "").Tables(0)
            Dim f As Integer = dd.Rows(0)(0)
            If f >= 0 Then
                Dim DirPath As String
                DirPath = Me.Server.MapPath("../image")
                If Me.Emp_support1.FileName <> "" Then

                    'Dim Dire() As DirectoryInfo
                    'Dim file() As FileInfo
                    'Dim i As Integer

                    'If DirPath <> "" Then
                    '    Dim dir As New DirectoryInfo(DirPath)
                    '    Dire = dir.GetDirectories()
                    '    file = dir.GetFiles()
                    '    If Dire.Length > 0 Then
                    '        For i = 0 To Dire.Length - 1
                    '            Dire(i).Delete(True)
                    '        Next
                    '    End If
                    '    If file.Length > 0 Then
                    '        For i = 0 To file.Length - 1
                    '            file(i).Delete()
                    '            ''Thread.Sleep(1000)
                    '        Next
                    '    End If
                    'End If


                    fnm = GetUniqueFilename(DirPath + "/Emp_photo.jpg")
                    If Me.Emp_support1.HasFile Then
                        Me.Emp_support1.SaveAs(fnm)
                    End If
                    Dim fs As New IO.FileStream(fnm, IO.FileMode.Open, IO.FileAccess.Read)
                    Dim bl(fs.Length) As Byte
                    fs.Read(bl, 0, fs.Length)
                    fs.Close()
                    Dim fp As New IO.FileInfo(fnm)
                    If fp.Exists Then
                        fp.Delete()
                    End If

                    '--------VAPT - File Size Already Validated in ValidateUploadedFile--------

                    Dim sql8 As DataTable = oh.ExecuteDataSet("select count(*) from macdms.hrm_emp_ph_certi l where l.emp_code=" & usr(0) & "").Tables(0)
                    If sql8.Rows(0)(0) > 0 Then
                        sql7 = "UPDATE macdms.hrm_emp_ph_certi h set h.photo= :ph where h.emp_code=:code"
                        Dim prr(1) As OracleParameter

                        prr(0) = New OracleParameter
                        prr(0).ParameterName = "code"
                        prr(0).OracleType = OracleType.Number
                        prr(0).Direction = ParameterDirection.Input
                        prr(0).Value = Me.txtecode.Text

                        prr(1) = New OracleParameter
                        prr(1).ParameterName = "ph"
                        prr(1).OracleType = OracleType.Blob
                        prr(1).Direction = ParameterDirection.Input
                        prr(1).Value = bl
                        oh.ExecuteNonQuery(sql7, prr)


                    Else
                        sql7 = "INSERT into macdms.hrm_emp_ph_certi (emp_code,photo) values(:code,:ph)"
                        Dim prr(1) As OracleParameter

                        prr(0) = New OracleParameter
                        prr(0).ParameterName = "code"
                        prr(0).OracleType = OracleType.Number
                        prr(0).Direction = ParameterDirection.Input
                        prr(0).Value = Me.txtecode.Text

                        prr(1) = New OracleParameter
                        prr(1).ParameterName = "ph"
                        prr(1).OracleType = OracleType.Blob
                        prr(1).Direction = ParameterDirection.Input
                        prr(1).Value = bl
                        oh.ExecuteNonQuery(sql7, prr)
                    End If



                    sql = "INSERT into hrm_emp_upload(emp_code,emp_Name,STATUS_ID,Upload_Dt) values(:empl_code,:empl_name,:Status,:upd_dt)"
                    Dim pr(3) As OracleParameter

                    pr(0) = New OracleParameter
                    pr(0).ParameterName = "empl_code"
                    pr(0).OracleType = OracleType.Number
                    pr(0).Direction = ParameterDirection.Input
                    pr(0).Value = Me.txtecode.Text

                    pr(1) = New OracleParameter
                    pr(1).ParameterName = "empl_name"
                    pr(1).OracleType = OracleType.VarChar
                    pr(1).Direction = ParameterDirection.Input
                    pr(1).Value = Me.txtename.Text

                    pr(2) = New OracleParameter
                    pr(2).ParameterName = "STATUS"
                    pr(2).OracleType = OracleType.Number
                    pr(2).Direction = ParameterDirection.Input
                    pr(2).Value = 0

                    pr(3) = New OracleParameter
                    pr(3).ParameterName = "upd_dt"
                    pr(3).OracleType = OracleType.DateTime
                    pr(3).Direction = ParameterDirection.Input
                    pr(3).Value = appdte

                    'Modified by Emp_Code:110030:Sajiny Abhilash on 23/12/2017
                    Dim pr4(0) As OracleParameter
                    sql20 = "UPDATE employee_alert_dtl h set h.alert_status= 0 where h.emp_code=:code"

                    pr4(0) = New OracleParameter
                    pr4(0).ParameterName = "code"
                    pr4(0).OracleType = OracleType.Number
                    pr4(0).Direction = ParameterDirection.Input
                    pr4(0).Value = Me.txtecode.Text

                    oh.ExecuteNonQuery(sql20, pr4)
                    '..............................................

                    If oh.ExecuteNonQuery(sql, pr) Then
                        'If  Then


                        Dim cl_scrip1 As New StringBuilder
                        cl_scrip1.Append("   alert('" & txtename.Text & ", YOUR PHOTO Documents Attached Successfully!!') ;")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_scrip1.ToString, True)
                        'Response.Redirect("../home.aspx")
                        clr()
                        Exit Sub
                    End If


                End If
            End If


        Else

            Dim cl_scrip1 As New StringBuilder
            'cl_scrip1.Append("   alert('" & txtename.Text & ", YOUR PHOTO ALREADY  Attached !!!') ;")
            cl_scrip1.Append("   alert('" & txtename.Text & ", Your photo already uploaded and verified !') ;")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_scrip1.ToString, True)
            clr()
        End If
        'End Try
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

    Function clr()
        Me.txtbranch.Text = ""
        Me.txtdate.Text = ""
        Me.txtdep.Text = ""
        Me.txtdes.Text = ""
        Me.txtecode.Text = ""
        Me.txtename.Text = ""
        Me.txtjdate.Text = ""
        Me.txtpost.Text = ""
    End Function
    
    '--------VAPT - File Upload Security Methods--------
    Private Function ValidateUploadedFile(fileUpload As FileUpload) As Boolean
        Try
            ' File size validation (1MB limit)
            If fileUpload.PostedFile.ContentLength > 1048576 Then
                Return False
            End If
            
            ' File extension validation
            Dim fileExtension As String = System.IO.Path.GetExtension(fileUpload.FileName).ToLower()
            Dim allowedExtensions As String() = {".jpg", ".jpeg", ".png", ".bmp"}
            
            If Not allowedExtensions.Contains(fileExtension) Then
                Return False
            End If
            
            ' MIME type validation
            Dim allowedMimeTypes As String() = {"image/jpeg", "image/jpg", "image/png", "image/bmp"}
            If Not allowedMimeTypes.Contains(fileUpload.PostedFile.ContentType.ToLower()) Then
                Return False
            End If
            
            ' File signature validation
            If Not ValidateFileSignature(fileUpload.PostedFile.InputStream, fileExtension) Then
                Return False
            End If
            
            ' Filename validation
            If ContainsMaliciousContent(fileUpload.FileName) Then
                Return False
            End If
            
            Return True
        Catch
            Return False
        End Try
    End Function
    
    Private Function ValidateFileSignature(stream As Stream, extension As String) As Boolean
        Try
            stream.Position = 0
            Dim header(3) As Byte
            stream.Read(header, 0, 4)
            stream.Position = 0
            
            Select Case extension
                Case ".jpg", ".jpeg"
                    Return header(0) = &HFF AndAlso header(1) = &HD8
                Case ".png"
                    Return header(0) = &H89 AndAlso header(1) = &H50 AndAlso header(2) = &H4E AndAlso header(3) = &H47
                Case ".bmp"
                    Return header(0) = &H42 AndAlso header(1) = &H4D
                Case Else
                    Return False
            End Select
        Catch
            Return False
        End Try
    End Function
    
    Private Function ContainsMaliciousContent(input As String) As Boolean
        If String.IsNullOrEmpty(input) Then Return False
        
        Dim maliciousPatterns As String() = {
            "<script", "javascript:", "vbscript:", ".exe", ".bat", ".cmd",
            ".com", ".scr", ".vbs", ".js", ".jar", ".php", ".asp", ".jsp"
        }
        
        Dim lowerInput As String = input.ToLower()
        For Each pattern As String In maliciousPatterns
            If lowerInput.Contains(pattern) Then Return True
        Next
        
        Return False
    End Function
    
    Private Sub RedirectToLogin()
        Dim cl_script0 As New System.Text.StringBuilder
        cl_script0.Append("alert('Please Login Again');")
        cl_script0.Append("window.open('../../main.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
    End Sub

End Class

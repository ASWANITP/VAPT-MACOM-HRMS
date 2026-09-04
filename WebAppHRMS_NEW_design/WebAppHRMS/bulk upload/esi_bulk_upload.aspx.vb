Imports System.Data
Imports System.Data.OracleClient
Imports System.IO
Imports System.Data.OleDb
Imports System.Web.Services
Imports System.Windows.Forms.FileDialog
Imports System.Web
Partial Class bulk_upload_esi_bulk_upload_00f340a49990
    Inherits System.Web.UI.Page
    Dim ExcelPaths, ExcelPath, fn As String
    Dim TextB As New TextBox
    Dim dd1, dta As New DataTable
    Dim page5 As Page = CType(HttpContext.Current.Handler, Page)
    Dim oh As New Helper.Oracle.OracleHelper

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

        FileUpload1.Attributes("onchange") = "UploadFile(this)"

        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim UserId As Integer = User(0)



        'Dim s As String = "select s.post_id from employee_master s where s.emp_code=" & User(0) & " "
        dta = oh.ExecuteDataSet("select s.post_id from employee_master s where s.emp_code=" & User(0) & "").Tables(0)
        If dta.Rows(0)(0) <> 1519 Then

            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('You are not Authorised to View this Page !!!!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)

        End If
        

    End Sub


    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Dim mycons As OleDbConnection = New OleDbConnection()
        Dim mycon As OleDbConnection = New OleDbConnection()

        Try
            '--------VAPT - Validate Excel File Upload--------
            If Not ValidateExcelFile(FileUpload1) Then
                Dim cl_script As New System.Text.StringBuilder
                cl_script.Append("alert('Invalid file type or malicious content detected!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "validation_error", cl_script.ToString, True)
                Return
            End If
            
            Me.hid.Value = ""
            Dim path As String = System.IO.Path.GetFileNameWithoutExtension(FileUpload1.FileName)
            Dim num As Integer = 1
            Dim fname As String = path.Replace(path, num) + ".xlsx"


            If System.IO.File.Exists(Server.MapPath("~/ExcelFile/") + fname) Then
                num = num + 1
                FileUpload1.SaveAs(Server.MapPath("~/ExcelFile/" + num.ToString() + ".xlsx"))
                ExcelPath = (Server.MapPath("~/ExcelFile/") + num.ToString() + ".xlsx")
            Else
                FileUpload1.SaveAs(Server.MapPath("~/ExcelFile/" + fname))
                ExcelPath = (Server.MapPath("~/ExcelFile/") + fname)
            End If


            Dim empcodes As Double
            Dim esinumber As Double



            mycon = New OleDbConnection(("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " _
                            + (ExcelPath + "; Extended Properties=Excel 8.0; Persist Security Info = False")))
            mycon.Open()


            Dim dtSheets As DataTable = mycon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
            Dim drSheet As DataRow
            Dim sheetname As String = ""

            For Each drSheet In dtSheets.Rows
                sheetname = drSheet("TABLE_NAME").ToString().Replace("'", "")
            Next

            Dim qry As String = "select * from [" & sheetname & "]"
            Dim cmd As OleDbCommand = New OleDbCommand(qry, mycon)
            Dim dr As OleDbDataReader = cmd.ExecuteReader
            While dr.Read
                empcodes = dr(0)
                esinumber = dr(1)

            End While

            Me.hid.Value = ExcelPath



            mycon.Close()

            '////////////////////////////////////////////////////////////

            'connection.Open()

            

            ExcelPaths = Me.hid.Value
            'Dim empcodes As Double
            'Dim esinumber As String
            'Dim esinum As Integer

            'Dim msg As String
            'Dim p_flag As Double

            Dim enterby() As String = Session("user_id").ToString.Split("!")
            Dim firm As Integer = Session("firm_id")

            Dim user As String = enterby(0)
            
            'Me.hid.Value = ExcelPath

            mycons = New Data.OleDb.OleDbConnection(("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " _
                            + (ExcelPaths + "; Extended Properties=Excel 8.0; Persist Security Info = False")))
            mycons.Open()
            Dim dtSheets1 As DataTable = mycons.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
            Dim drSheet1 As DataRow
            Dim sheetname1 As String = ""

            For Each drSheet1 In dtSheets1.Rows
                sheetname1 = drSheet1("TABLE_NAME").ToString().Replace("'", "")
            Next

            Dim qry1 As String = "select * from [" & sheetname1 & "]"
            Dim cmd1 As OleDbCommand = New OleDbCommand(qry1, mycons)
            Dim drs1 As OleDbDataReader = cmd1.ExecuteReader

            Dim seqno As DataTable = oh.ExecuteDataSet("SELECT Seq_id1.NEXTVAL FROM DUAL").Tables(0)

            While drs1.Read
                empcodes = drs1(0)
                esinumber = drs1(1).ToString


                Dim parameter(5) As OracleParameter
                ''CODE
                parameter(0) = New OracleParameter("empcode", OracleType.Number, 6)
                parameter(0).Direction = ParameterDirection.Input
                parameter(0).Value = CInt(empcodes)

                parameter(1) = New OracleParameter("firm", OracleType.Number, 2)
                parameter(1).Direction = ParameterDirection.Input
                parameter(1).Value = CInt(firm)

                parameter(2) = New OracleParameter("esino", OracleType.VarChar, 10)
                parameter(2).Direction = ParameterDirection.Input
                'esinum = esinumber.ToString()
                parameter(2).Value = (esinumber)

                parameter(3) = New OracleParameter("enteredby", OracleType.Number, 10)
                parameter(3).Direction = ParameterDirection.Input
                parameter(3).Value = CInt(user)

                parameter(4) = New OracleParameter("seqno", OracleType.VarChar, 10)
                parameter(4).Direction = ParameterDirection.Input
                parameter(4).Value = seqno.Rows(0)(0)


                parameter(5) = New OracleParameter("msg", OracleType.VarChar, 100)
                parameter(5).Direction = ParameterDirection.Output

                oh.ExecuteNonQuery("HRM_ESI_NO_UPLOAD", parameter)
                Dim message As String
                message = parameter(5).Value

                'savedata(empcodes, esinumber, user)





                Dim cl_script1 As New System.Text.StringBuilder(1, 500)
                ' cl_script1.Append("  alert('BULK-EXCEL UPDATION SUCCESSFULLY CONFIRMED!!!!');")
                cl_script1.Append(" alert('" & message & "');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)


            End While
            mycons.Close()
        Catch EX As Exception
            If Not Me.FileUpload1.HasFile Then
                Dim cl_script32 As New System.Text.StringBuilder(1, 500)
                cl_script32.Append("  alert('CHOOSE ANY EXCEL FILE FROM YOUR PC');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script1", cl_script32.ToString, True)
                Exit Sub
            Else

                Dim cl_script21 As New System.Text.StringBuilder(1, 500)
                cl_script21.Append("  alert('UPDATION FAILED');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script1", cl_script21.ToString, True)
            End If
        Finally
            mycons.Close()
            mycons.Dispose()
            mycon.Close()
            mycon.Dispose()
            Dim DirPath As String = Me.hid.Value
            'Dim DirPath As String = ExcelPath
            'If Not String.IsNullOrEmpty(DirPath) Then
            If File.Exists(DirPath) Then
                System.IO.File.Delete(DirPath)
            End If
            Me.hid.Value = ""
            '' Else
            'Dim cl_script22 As New System.Text.StringBuilder(1, 500)
            'cl_script22.Append(" alert('Invalid Excel Path.');")
            'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script2", cl_script22.ToString, True)
            ' End If


        End Try
        ' End Using


    End Sub
  



    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Redirect("~/ExcelFile/Format.xlsx")
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Server.Transfer("../home.aspx")
        Dim cl_script0 As New System.Text.StringBuilder
        cl_script0.Append("window.open('../home.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
    End Sub
    
    '--------VAPT - Excel File Upload Security Methods--------
    Private Function ValidateExcelFile(fileUpload As FileUpload) As Boolean
        Try
            If Not fileUpload.HasFile Then
                Return False
            End If
            
            ' File size validation (5MB limit for Excel files)
            If fileUpload.PostedFile.ContentLength > 5242880 Then
                Return False
            End If
            
            ' File extension validation
            Dim fileExtension As String = System.IO.Path.GetExtension(fileUpload.FileName).ToLower()
            Dim allowedExtensions As String() = {".xlsx", ".xls"}
            
            If Not allowedExtensions.Contains(fileExtension) Then
                Return False
            End If
            
            ' MIME type validation
            Dim allowedMimeTypes As String() = {
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "application/vnd.ms-excel"
            }
            If Not allowedMimeTypes.Contains(fileUpload.PostedFile.ContentType.ToLower()) Then
                Return False
            End If
            
            ' File signature validation
            If Not ValidateExcelSignature(fileUpload.PostedFile.InputStream, fileExtension) Then
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
    
    Private Function ValidateExcelSignature(stream As Stream, extension As String) As Boolean
        Try
            stream.Position = 0
            Dim header(7) As Byte
            stream.Read(header, 0, 8)
            stream.Position = 0
            
            Select Case extension
                Case ".xlsx"
                    ' ZIP signature (XLSX is ZIP-based)
                    Return header(0) = &H50 AndAlso header(1) = &H4B AndAlso (header(2) = &H3 OrElse header(2) = &H5 OrElse header(2) = &H7)
                Case ".xls"
                    ' OLE signature
                    Return header(0) = &HD0 AndAlso header(1) = &HCF AndAlso header(2) = &H11 AndAlso header(3) = &HE0
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
        cl_script0.Append("window.open('../main.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
    End Sub
End Class



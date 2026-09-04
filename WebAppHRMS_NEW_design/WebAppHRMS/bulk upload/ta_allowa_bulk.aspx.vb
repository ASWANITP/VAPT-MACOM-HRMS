Imports System.Data
Imports System.Data.OracleClient
Imports System.IO
Imports System.Data.OleDb
Imports System.Web.Services
Imports System.Windows.Forms.FileDialog
Imports System.Web
Partial Class bulk_upload_ta_allowa_bulk_235ee2944607
    Inherits System.Web.UI.Page
    Dim TextB As New TextBox
    Dim page5 As Page = CType(HttpContext.Current.Handler, Page)
    'Dim TextB As TextBox = CType(Page.FindControl("TextBox1"), TextBox)
    Dim ExcelPath, ExcelPaths, fn As String
    Dim dt1, dt2 As New DataTable
    Dim dd1, dta As New DataTable
    Dim seqno As DataTable
    Dim sum As Double
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

           
        Else


            If Not IsPostBack Then
                dt1 = oh.ExecuteDataSet("select -1 as qualid, '--------SELECT--------' as qual   from dual h union all select t.all_id, t.all_name   from mactech.allowances_master t where t.status_id=1  order by qual").Tables(0)
                Me.DropDownList1.DataSource = dt1
                Me.DropDownList1.DataValueField = dt1.Columns(0).ColumnName
                Me.DropDownList1.DataTextField = dt1.Columns(1).ColumnName
                Me.DropDownList1.DataBind()
            End If
        End If


    End Sub
    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click


        Dim mycons As OleDbConnection = New OleDbConnection()
        Try


            If Me.DropDownList1.SelectedValue = "-1" Then
                Dim cl_script31 As New System.Text.StringBuilder(1, 500)
                cl_script31.Append("  alert('SELECT ANY TA/ALLOWANCE');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script1", cl_script31.ToString, True)
                Exit Sub
            ElseIf Not Me.FileUpload1.HasFile And Not Me.TextBox1.Text >= "0" Then
                Dim cl_script32 As New System.Text.StringBuilder(1, 500)
                cl_script32.Append("  alert('CHOOSE ANY EXCEL FILE FROM YOUR PC');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script1", cl_script32.ToString, True)
                Exit Sub
            End If

            ExcelPaths = Me.hid.Value
            Dim empcodes As Double
            Dim amts As Double
            Dim enterby() As String = Session("user_id").ToString.Split("!")
            Dim firmid As Integer = Me.Session("firm_id")
            Dim s As String = enterby(0)
            Dim allid As Integer
            Dim sumeds As Double



            mycons = New OleDbConnection(("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " _
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

            allid = Me.DropDownList1.SelectedValue
            sumeds = 0
            seqno = oh.ExecuteDataSet("SELECT Seq_id1.NEXTVAL FROM DUAL").Tables(0)
            While drs1.Read
                empcodes = drs1(0)
                amts = drs1(1)
                sumeds = sumeds + drs1(1)
                savedata(empcodes, amts, allid, enterby(0))
            End While

            Dim cl_script1 As New System.Text.StringBuilder(1, 500)
            cl_script1.Append("  alert('BULK-EXCEL UPDATION SUCCESSFULLY CONFIRMED!!!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            dt1 = oh.ExecuteDataSet("select -1 as qualid, '--------SELECT--------' as qual   from dual h union all select t.all_id, t.all_name   from mactech.allowances_master t where t.status_id=1  order by qual").Tables(0)
            Me.DropDownList1.DataSource = dt1
            Me.DropDownList1.DataValueField = dt1.Columns(0).ColumnName
            Me.DropDownList1.DataTextField = dt1.Columns(1).ColumnName
            Me.DropDownList1.DataBind()
            mycons.Close()
        Catch EX As Exception
            Dim cl_script21 As New System.Text.StringBuilder(1, 500)
            cl_script21.Append("  alert('UPDATION FAILED.\nEXCEL CONTAINS DUPLICATED DATA');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script1", cl_script21.ToString, True)
            dt1 = oh.ExecuteDataSet("select -1 as qualid, '--------SELECT--------' as qual   from dual h union all select t.all_id, t.all_name   from mactech.allowances_master t where t.status_id=1  order by qual").Tables(0)
            Me.DropDownList1.DataSource = dt1
            Me.DropDownList1.DataValueField = dt1.Columns(0).ColumnName
            Me.DropDownList1.DataTextField = dt1.Columns(1).ColumnName
            Me.DropDownList1.DataBind()
            Me.TextBox1.Text = ""
        Finally
            mycons.Close()
            mycons.Dispose()
            Dim DirPath As String = Me.hid.Value
            System.IO.File.Delete(DirPath)
            Me.TextBox1.Text = ""
            Me.hid.Value = ""
        End Try
    End Sub

    Private Sub savedata(ByVal empcodes As Integer, ByVal amts As String, ByVal allid As String, ByVal enterby As String)

        Dim firmid As Integer = Me.Session("firm_id")

        Dim query As String = ("insert into mactech.INCENTIVES_ALLOWANCES_TEMP select ef.emp_code, " & allid & " as allowance_id, " & amts & ", to_date(sysdate), to_date(sysdate), em.branch_id, 0 as status_id," & enterby & " enterby,'', ef.firm_id firm, 0 as processflg, " & amts & ",6," & seqno.Rows(0)(0) & " from mactech.employee_master em, mactech.employ_firm ef,mactech.firm_master m where ef.emp_code = em.emp_code and m.firm_id=ef.firm_id and ef.emp_code='" & empcodes & "'and ef.firm_id='" & firmid & "'")

        oh.ExecuteNonQuery(query)

    End Sub

    

    Protected Sub bt1_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles bt1.ServerClick
        Dim mycon As OleDbConnection = New OleDbConnection()
        Try
            '--------VAPT - Validate Excel File Upload--------
            If Not ValidateExcelFile(FileUpload1) Then
                Dim cl_script As New System.Text.StringBuilder
                cl_script.Append("alert('Invalid file type or malicious content detected!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "validation_error", cl_script.ToString, True)
                Return
            End If
            
            If Me.DropDownList1.SelectedValue = "-1" Then
                Dim cl_script31 As New System.Text.StringBuilder(1, 500)
                cl_script31.Append("  alert('SELECT ANY TA/ALLOWANCE');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script1", cl_script31.ToString, True)
                Exit Sub
            Else

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


                Dim empcode As Double
                Dim amt As Double
                Dim sumed As Double
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

                sumed = 0
                While dr.Read
                    empcode = dr(0)
                    amt = dr(1)
                    sumed = sumed + dr(1)
                End While
                Me.hid.Value = ExcelPath
                Me.TextBox1.Text = sumed
                Dim cl_script212 As New System.Text.StringBuilder(1, 500)
                cl_script212.Append("  alert('Sum Of Amount Is " & sumed & "');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script1", cl_script212.ToString, True)
                mycon.Close()
            End If

        Catch es As Exception
            Dim cl_script2121 As New System.Text.StringBuilder(1, 500)
            cl_script2121.Append("  alert('FAILED, EXCEL NOT IN CORRECT FORMAT');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script1", cl_script2121.ToString, True)
            Dim DirPath As String = ExcelPath
            System.IO.File.Delete(DirPath)
        Finally
            mycon.Close()
            mycon.Dispose()



        End Try
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Redirect("~/ExcelFile/Formatta.xlsx")
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

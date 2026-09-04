Imports System.Data
Imports System.Data.OracleClient
Imports System.IO
Imports System.Data.OleDb
Imports System.Web.Services
Imports System.Windows.Forms.FileDialog
Imports System.Web
Partial Class bulk_upload_tds_ded_311c7f144174
    Inherits System.Web.UI.Page
    Dim TextB As New TextBox
    Dim page5 As Page = CType(HttpContext.Current.Handler, Page)
    'Dim TextB As TextBox = CType(Page.FindControl("TextBox1"), TextBox)
    Dim ExcelPath, ExcelPaths, fn As String
    Dim dt1, dt2 As New DataTable
    Dim dd1, dta As New DataTable
    Dim sum As Double
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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
                dt1 = oh.ExecuteDataSet("select -1 as qualid, '--------SELECT--------' as qual from dual h union all select t.id, t.bulk_name from mactech.bulk_option t  where t.status_id = 0 and t.id in (3,4,5) order by qual").Tables(0)
                Me.DropDownList1.DataSource = dt1
                Me.DropDownList1.DataValueField = dt1.Columns(0).ColumnName
                Me.DropDownList1.DataTextField = dt1.Columns(1).ColumnName
                Me.DropDownList1.DataBind()

                If Me.DropDownList1.SelectedValue = 3 Or -1 Then

                    Me.TextBox2.Visible = False
                    Me.Label1.Visible = False
                    Exit Sub

                Else
                    Me.TextBox2.Visible = True
                    Me.Label1.Visible = True
                    Exit Sub
                End If
            End If
        End If

    End Sub
    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Dim mycons As OleDbConnection = New OleDbConnection()
        Try
            If Me.DropDownList1.SelectedValue = "-1" Then
                Dim cl_script31 As New System.Text.StringBuilder(1, 500)
                cl_script31.Append("  alert('SELECT ANY DATA');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script1", cl_script31.ToString, True)
                Exit Sub
            ElseIf Not Me.FileUpload1.HasFile And Not Me.TextBox1.Text >= "0" Then
                Dim cl_script32 As New System.Text.StringBuilder(1, 500)
                cl_script32.Append("  alert('CHOOSE ANY EXCEL FILE FROM YOUR PC');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script1", cl_script32.ToString, True)
                Exit Sub
            End If


            If Me.TextBox2.Visible = True Then

                If Me.TextBox2.Text = "" Then
                    Dim cl_script31 As New System.Text.StringBuilder(1, 500)
                    cl_script31.Append("  alert('PLEASE ENTER REMARK');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script1", cl_script31.ToString, True)
                    Exit Sub
                End If
            End If

            ExcelPaths = Me.hid.Value
            Dim empcodes As Double
            Dim amts As Double
            Dim remark As String = Me.TextBox2.Text.ToString
            Dim sumeds As Double
            Dim value As Double = Me.DropDownList1.SelectedValue


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
            Dim seqno As DataTable = oh.ExecuteDataSet("SELECT Seq_id1.NEXTVAL FROM DUAL").Tables(0)

            sumeds = 0
            While drs1.Read
                empcodes = drs1(0)
                amts = drs1(1)
                sumeds = sumeds + drs1(1)
                'savedata(empcodes, amts, remark)


                Dim parameter(5) As OracleParameter
                ''CODE
                parameter(0) = New OracleParameter("empcode", OracleType.Number, 6)
                parameter(0).Direction = ParameterDirection.Input
                parameter(0).Value = CInt(empcodes)

                parameter(1) = New OracleParameter("amount", OracleType.Number, 6)
                parameter(1).Direction = ParameterDirection.Input
                parameter(1).Value = CInt(amts)

                parameter(2) = New OracleParameter("remark", OracleType.VarChar, 20)
                parameter(2).Direction = ParameterDirection.Input
                parameter(2).Value = remark

                parameter(3) = New OracleParameter("val", OracleType.Number, 6)
                parameter(3).Direction = ParameterDirection.Input
                parameter(3).Value = CInt(value)

                parameter(4) = New OracleParameter("seqno", OracleType.VarChar, 10)
                parameter(4).Direction = ParameterDirection.Input
                parameter(4).Value = seqno.Rows(0)(0)

                parameter(5) = New OracleParameter("msg", OracleType.VarChar, 100)
                parameter(5).Direction = ParameterDirection.Output

                oh.ExecuteNonQuery("HRM_TDS_UPLOAD", parameter)
                Dim message As String
                message = parameter(5).Value



                Dim cl_script1 As New System.Text.StringBuilder(1, 500)
                ' cl_script1.Append("  alert('BULK-EXCEL UPDATION SUCCESSFULLY CONFIRMED!!!!');")
                cl_script1.Append(" alert('" & message & "');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)


            End While
            mycons.Close()


            'Dim cl_script1 As New System.Text.StringBuilder(1, 500)
            'cl_script1.Append("  alert('BULK-EXCEL UPDATION SUCCESSFULLY CONFIRMED!!!!');")
            'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            'dt1 = oh.ExecuteDataSet("select -1 as qualid, '--------SELECT--------' as qual from dual h union all select t.id, t.sal_name from mactech.salary_master t where t.status_id = 1 order by qual").Tables(0)
            'Me.DropDownList1.DataSource = dt1
            'Me.DropDownList1.DataValueField = dt1.Columns(0).ColumnName
            'Me.DropDownList1.DataTextField = dt1.Columns(1).ColumnName
            'Me.DropDownList1.DataBind()
            'mycons.Close()
        Catch EX As Exception
            Dim cl_script21 As New System.Text.StringBuilder(1, 500)
            cl_script21.Append("  alert('UPDATION FAILED.\nEXCEL CONTAINS DUPLICATED DATA');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script1", cl_script21.ToString, True)
            dt1 = oh.ExecuteDataSet("select -1 as qualid, '--------SELECT--------' as qual from dual h union all select t.id, t.sal_name from mactech.salary_master t where t.status_id = 1 order by qual").Tables(0)
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
            Me.TextBox2.Text = ""
        End Try
    End Sub


    'Private Sub savedata(ByVal empcodes As Integer, ByVal amts As String, ByVal remark As String)
    '    'tds
    '    If Me.DropDownList1.SelectedValue = 6 Then

    '        Dim query As String = ("insert into mactech.EMPLOY_SAL_ADD_TEMP select ef.emp_code, 0, 0, 0, '', 0, 0, " & amts & ", 0, '', to_date(sysdate), 0, '', 0, 0, 0 from mactech.employee_master em, mactech.employ_firm ef, mactech.firm_master m where ef.emp_code = em.emp_code and m.firm_id = ef.firm_id and ef.emp_code = '" & empcodes & "'")
    '        oh.ExecuteNonQuery(query)
    '        Exit Sub
    '    End If
    '    'other ded
    '    If Me.DropDownList1.SelectedValue = 7 Then

    '        Dim query As String = ("insert into mactech.EMPLOY_SAL_ADD_TEMP select ef.emp_code, 0, 0, 0, '', 0, 0,0 , " & amts & ", '" & remark & "', to_date(sysdate), 0, '', 0, 0, 0 from mactech.employee_master em, mactech.employ_firm ef, mactech.firm_master m where ef.emp_code = em.emp_code and m.firm_id = ef.firm_id and ef.emp_code = '" & empcodes & "'")
    '        oh.ExecuteNonQuery(query)
    '        Exit Sub
    '    End If

    '    'other add
    '    If Me.DropDownList1.SelectedValue = 3 Then

    '        Dim query As String = ("insert into mactech.EMPLOY_SAL_ADD_TEMP select ef.emp_code, 0, 0, " & amts & ", '" & remark & "', 0, 0,0 , 0, '', to_date(sysdate), 0, '', 0, 0, 0 from mactech.employee_master em, mactech.employ_firm ef, mactech.firm_master m where ef.emp_code = em.emp_code and m.firm_id = ef.firm_id and ef.emp_code = '" & empcodes & "'")
    '        oh.ExecuteNonQuery(query)
    '        Exit Sub
    '    End If

    'End Sub

    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

    '    Try
    '        'Dim DirPath As String = Server.MapPath("~/ExcelFile")
    '        'Dim di As DirectoryInfo = New DirectoryInfo(DirPath)
    '        'For Each file As FileInfo In di.GetFiles()
    '        '    file.Delete()
    '        'Next

    '        Dim path As String = System.IO.Path.GetFileName(FileUpload1.FileName)
    '        path = path.Replace(" ", "")
    '        Dim path1 As String = System.IO.Path.GetExtension(FileUpload1.FileName)

    '        If path1 <> ".xlsx" Then
    '            Dim cl_script2 As New System.Text.StringBuilder(1, 500)
    '            cl_script2.Append("  alert('FAILED.\nVERIFY THAT IT IS AN EXCEL FILE');")
    '            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script1", cl_script2.ToString, True)
    '            Exit Sub
    '        End If

    '        FileUpload1.SaveAs((Server.MapPath("~/ExcelFile/") + path))
    '        ExcelPath = (Server.MapPath("~/ExcelFile/") + path)
    '        Dim mycon1 As OleDbConnection = New OleDbConnection(("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " _
    '                        + (ExcelPath + "; Extended Properties=Excel 8.0; Persist Security Info = False")))

    '        Dim empcode As Double
    '        Dim amt As Double
    '        Dim sumed As Double
    '        Dim mycon As OleDbConnection = New OleDbConnection(("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " _
    '                        + (ExcelPath + "; Extended Properties=Excel 8.0; Persist Security Info = False")))
    '        mycon.Open()
    '        Dim cmd As OleDbCommand = New OleDbCommand("select * from [Sheet1$]", mycon)
    '        Dim dr As OleDbDataReader = cmd.ExecuteReader

    '        Dim querys As String = ("delete from mactech.emp_jewel_inc")
    '        oh.ExecuteNonQuery(querys)
    '        sumed = 0
    '        While dr.Read
    '            empcode = dr(0)
    '            amt = dr(1)
    '            savedata(empcode, amt)
    '            sumed = sumed + dr(1)
    '        End While

    '        Dim query As String = ("select sum(t.amt)from emp_jewel_inc t")
    '        dt2 = oh.ExecuteDataSet(query).Tables(0)
    '        sum = dt2.Rows(0)(0)
    '        Me.TextBox1.Text = sumed
    '        mycon.Close()
    '    Catch ex As Exception
    '        Dim cl_script3 As New System.Text.StringBuilder(1, 500)
    '        cl_script3.Append("  alert('FAILED, EXCEL NOT IN CORRECT FORMAT');")
    '        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script1", cl_script3.ToString, True)
    '        dt1 = oh.ExecuteDataSet("select -1 as qualid, '--------SELECT--------' as qual from dual h union all select t.all_id,t.all_name from incentives_allowances_master t order by qual").Tables(0)
    '        Me.DropDownList1.DataSource = dt1
    '        Me.DropDownList1.DataValueField = dt1.Columns(0).ColumnName
    '        Me.DropDownList1.DataTextField = dt1.Columns(1).ColumnName
    '        Me.DropDownList1.DataBind()
    '        Me.TextBox1.Text = ""
    '    End Try
    'End Sub

    '  <System.Web.Services.WebMethod()> _
    'Public Shared Function DeleteItem()
    '      Try
    '          Dim fileuploadExcel As FileUpload = New FileUpload
    '          Dim ExcelPath As String
    '          Dim FileUpload1 = New System.Web.UI.WebControls.FileUpload
    '          'Dim TextBox1 = New System.Windows.Forms.TextBox
    '          Dim path As String = System.IO.Path.GetFileName(FileUpload1)
    '          path = path.Replace(" ", "")
    '          Dim path1 As String = System.IO.Path.GetExtension(FileUpload1)
    '          ' fileuploadExcel.PostedFile = "C:\Users\100356\Desktop\New folder\jwel.xlsx"
    '          fileuploadExcel.PostedFile.SaveAs((System.Web.HttpContext.Current.Server.MapPath("~/ExlFile/") + path))
    '          ExcelPath = (System.Web.HttpContext.Current.Server.MapPath("~/ExlFile/") + path)

    '          Dim mycon1 As OleDbConnection = New OleDbConnection(("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " _
    '                          + (ExcelPath + "; Extended Properties=Excel 8.0; Persist Security Info = False")))
    '          Dim empcode As Double
    '          Dim amt As Double
    '          Dim sumed As Double
    '          Dim mycon As OleDbConnection = New OleDbConnection(("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " _
    '                          + (ExcelPath + "; Extended Properties=Excel 8.0; Persist Security Info = False")))
    '          mycon.Open()
    '          Dim cmd As OleDbCommand = New OleDbCommand("select * from [Sheet1$]", mycon)
    '          Dim dr As OleDbDataReader = cmd.ExecuteReader

    '          sumed = 0
    '          While dr.Read
    '              empcode = dr(0)
    '              amt = dr(1)
    '              sumed = sumed + dr(1)
    '          End While
    '          Return sumed

    '      Catch es As Exception
    '          Return es
    '      End Try
    '  End Function

    'Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    Try
    '        Me.hid.Value = ""
    '        Dim path As String = System.IO.Path.GetFileName(FileUpload1.FileName)
    '        FileUpload1.SaveAs(Server.MapPath("~/ExcelFile/" + path))
    '        ExcelPath = (Server.MapPath("~/ExcelFile/") + path)

    '        Dim empcode As Double
    '        Dim amt As Double
    '        Dim sumed As Double
    '        Dim mycon As OleDbConnection = New OleDbConnection(("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " _
    '                        + (ExcelPath + "; Extended Properties=Excel 8.0; Persist Security Info = False")))
    '        mycon.Open()
    '        Dim cmd As OleDbCommand = New OleDbCommand("select * from [Sheet1$]", mycon)
    '        Dim dr As OleDbDataReader = cmd.ExecuteReader

    '        sumed = 0
    '        While dr.Read
    '            empcode = dr(0)
    '            amt = dr(1)
    '            sumed = sumed + dr(1)
    '        End While
    '        Me.hid.Value = ExcelPath
    '        Me.TextBox1.Text = sumed
    '        Dim cl_script212 As New System.Text.StringBuilder(1, 500)
    '        cl_script212.Append("  alert('Sum Of Amount Is " & sumed & "');")
    '        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script1", cl_script212.ToString, True)
    '        mycon.Close()
    '    Catch es As Exception
    '        Dim cl_script2121 As New System.Text.StringBuilder(1, 500)
    '        cl_script2121.Append("  alert('FAILED, EXCEL NOT IN CORRECT FORMAT');")
    '        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script1", cl_script2121.ToString, True)
    '    End Try
    'End Sub

    Protected Sub bt1_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles bt1.ServerClick
        Dim mycon As OleDbConnection = New OleDbConnection()
        Try

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

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged

        If Me.DropDownList1.SelectedValue = 3 Then

            Me.TextBox2.Visible = False
            Me.Label1.Visible = False
            'If Me.TextBox2.Text = "" Then
            '    Dim cl_script31 As New System.Text.StringBuilder(1, 500)
            '    cl_script31.Append("  alert('PLEASE ENTER REMARK');")
            '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script1", cl_script31.ToString, True)
            '    Exit Sub
            'End If

        Else
            Me.TextBox2.Visible = True
            Me.Label1.Visible = True
        End If
    End Sub

    'Protected Sub TextBox2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    'End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Server.Transfer("../home.aspx")
        Dim cl_script0 As New System.Text.StringBuilder
        cl_script0.Append("window.open('../home.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
    End Sub
End Class



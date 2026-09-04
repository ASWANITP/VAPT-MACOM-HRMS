Imports system
Imports System.Data
Imports System.IO
Imports System.Data.OracleClient

Partial Class PancardUpdate_6286795c1835
    Inherits System.Web.UI.Page
    Dim dt, dt1, dt2, dts1, dts2, dtpri, dtrs As New DataTable
    'Dim oh As New Helper.Oracle.OracleHelper
    'Dim dts1, dts2, dtpri, dtrs, Data As New DataTable
    Dim UserAll(), UserCode, fnm, sql As String
    Dim str_tkn As New StringBuilder
    Dim cat, sf() As Integer
    'Dim usr() As String
    Dim usr() As String
    Dim dts, dth, dd1 As New DataTable
    Dim str, strs, frm As String
    Dim oh As New Helper.Oracle.OracleHelper




    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim UserId As Integer = User(0)

        usr = Me.Session("user_id").ToString.Split("!")



        If Session("firm_id") = 8 Then
            dt = oh.ExecuteDataSet("SELECT e.emp_code, e.emp_name, NVL(a.pan_no, 'NILL') AS pan_no FROM employee_master e LEFT JOIN HRM_EMP_ADDITIONAL_DTL a ON e.emp_code = a.emp_code /*AND e.firm_id = a.firm_id*/ WHERE e.emp_code = " & usr(0) & "").Tables(0)
        Else
            dt = oh.ExecuteDataSet("select e.emp_code ,e.emp_name, a.pan_no from employee_master e, HRM_EMP_ADDITIONAL_DTL a where e.emp_code = a.emp_code and e.firm_id = a.firm_id and e.emp_code = " & usr(0) & "").Tables(0)
        End If




        Me.txt_ecode.Text = dt.Rows(0)(0)
        Me.txt_ename.Text = dt.Rows(0)(1)
        Me.txt_pan.Text = dt.Rows(0)(2)





    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click



       
        Dim script1 As New System.Text.StringBuilder()
        Dim regex As New System.Text.RegularExpressions.Regex("[^a-zA-Z0-9]")
        Dim imageBytes As Byte() = Upload.FileBytes

        Try
            ' PAN number validation
            If Me.new_txt_pan.Text = "" Then
                script1.Append("alert('Please enter correct PAN number..!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "client_script", script1.ToString(), True)
                Exit Sub
            End If

            ' Check if new PAN matches existing PAN
            If Me.new_txt_pan.Text = Me.txt_pan.Text Then
                script1.Append("alert('Unable to confirm with the same PAN card number');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "client_script", script1.ToString(), True)
                Exit Sub
            End If

            ' Check for special characters in PAN number 
            If regex.IsMatch(Me.new_txt_pan.Text) Then
                script1.Append("alert('Special characters are not allowed in PAN number..!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "client_script", script1.ToString(), True)
                Exit Sub
            End If

            ' Check the length of the PAN card text
            If Me.new_txt_pan.Text.Length <> 10 Then
                script1.Append("alert('PAN card number must be exactly 10 characters long!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "client_script", script1.ToString(), True)
                Exit Sub
            End If

            ' Check if the first five characters are letters
            If Not System.Text.RegularExpressions.Regex.IsMatch(Me.new_txt_pan.Text.Substring(0, 5), "^[A-Z]+$") Then
                script1.Append("alert('The first five characters must be uppercase letters!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "client_script", script1.ToString(), True)
                Exit Sub
            End If

            ' Check if the next four characters are digits
            If Not System.Text.RegularExpressions.Regex.IsMatch(Me.new_txt_pan.Text.Substring(5, 4), "^[0-9]+$") Then
                script1.Append("alert('The next four characters must be digits!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "client_script", script1.ToString(), True)
                Exit Sub
            End If

            ' Check if the last character is a letter
            If Not System.Text.RegularExpressions.Regex.IsMatch(Me.new_txt_pan.Text.Substring(9, 1), "^[A-Z]+$") Then
                script1.Append("alert('The last character must be an uppercase letter!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "client_script", script1.ToString(), True)
                Exit Sub
            End If

            ' File validation
            If Not Me.Upload.HasFile Then
                script1.Append("alert('Please upload a file..!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "client_script", script1.ToString(), True)
                Exit Sub
            End If

            Dim fileExtension As String = Path.GetExtension(Me.Upload.FileName).ToLower()
            Dim allowedExtensions As String() = {".jpeg", ".jpg"}
            Dim videoExtensions As String() = {".mp4", ".avi", ".mov", ".wmv"}
            Dim maxFileSize As Integer = 2 * 1024 * 1024 ' 2 MB in bytes

            If Array.IndexOf(videoExtensions, fileExtension) >= 0 Then
                script1.Append("alert('Video files are not allowed for upload!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "client_script", script1.ToString(), True)
                Exit Sub
            End If

            If Array.IndexOf(allowedExtensions, fileExtension) < 0 Then
                script1.Append("alert('Only JPEG and JPG files are allowed!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "client_script", script1.ToString(), True)
                Exit Sub
            End If

            If Me.Upload.PostedFile.ContentLength > maxFileSize Then
                script1.Append("alert('Maximum file size is 2MB!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "client_script", script1.ToString(), True)
                Exit Sub
            End If

            ' Database operations
            usr = Me.Session("user_id").ToString.Split("!")
            Dim emp As Integer = CInt(usr(0).ToString())

            Dim pan(5) As OracleParameter
            pan(0) = New OracleParameter("emp_code", OracleType.Number)
            pan(0).Direction = ParameterDirection.Input
            pan(0).Value = emp

            pan(1) = New OracleParameter("emp_name", OracleType.VarChar, 100)
            pan(1).Direction = ParameterDirection.Input
            pan(1).Value = Me.txt_ename.Text

            pan(2) = New OracleParameter("exstng_pan_num", OracleType.VarChar, 60)
            pan(2).Direction = ParameterDirection.Input
            pan(2).Value = Me.txt_pan.Text

            pan(3) = New OracleParameter("new_pan_num", OracleType.VarChar, 50)
            pan(3).Direction = ParameterDirection.Input
            pan(3).Value = Me.new_txt_pan.Text

            pan(4) = New OracleParameter("enteredby", OracleType.Number)
            pan(4).Direction = ParameterDirection.Input
            pan(4).Value = CInt(usr(0).ToString())

            pan(5) = New OracleParameter("msg", OracleType.VarChar, 500)
            pan(5).Direction = ParameterDirection.Output
            oh.ExecuteNonQuery("pancard_confrm", pan)

            Dim message As String = pan(5).Value

            If message.StartsWith("999") Then
                sql = "update pancard p set p.image = :ph where p.empcode = '" & txt_ecode.Text & "' "

                Dim parm1(0) As OracleParameter
                parm1(0) = New OracleParameter()
                parm1(0).ParameterName = "ph"
                parm1(0).OracleType = OracleType.Blob
                parm1(0).Direction = ParameterDirection.Input
                parm1(0).Value = imageBytes
                oh.ExecuteNonQuery(sql, parm1)
            End If

            script1.Append("alert('" & message & "');")
            script1.Append("window.open('PancardUpdate.aspx','_self');")
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

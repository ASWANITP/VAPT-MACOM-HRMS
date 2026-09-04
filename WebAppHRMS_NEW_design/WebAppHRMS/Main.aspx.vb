Imports Microsoft.Win32
Imports System
Imports System.Text
Imports System.Data
Imports System.Data.OracleClient
Imports WebAppHRMS
Imports System.IO
Imports System.Security.Cryptography
Imports System.Web.Script.Services
Imports System.Web.Services
Imports WebAppHRMS.SessionHandler

Partial Class Main
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim callbackReturn As Integer
    Dim date_on_br As New Main_BLL.Main_BLL
    Dim _encryptDecrypt As New EncryptionService
    Dim Sessionhandler As New SessionHandler


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        hdnEdata.Value = "8080808080808080"

        ValidateQueryParameters()
        'Dim txtpass As String = txt_password.Text


        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetNoStore()
        Response.Buffer = True
        Response.ExpiresAbsolute = Now().Subtract(New TimeSpan(1, 0, 0, 0))
        Response.Expires = 0
        Response.CacheControl = "no-cache"

        Dim cs As String = "var reg_val;reg_val='HKCU\\DotNet\\DotKv';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)

        If Not IsPostBack Then

            '---------------------------------------------------
            Session.Abandon()
            Dim manager As New System.Web.SessionState.SessionIDManager()
            Dim newId As String = manager.CreateSessionID(Context)

            Dim isRedirected As Boolean = False
            Dim isAdded As Boolean = False
            manager.SaveSessionID(Context, newId, isRedirected, isAdded)

            '----------------------------------------------------
            If Request.QueryString("mid") Is Nothing Then
                hdnMnID.Value = 0
            Else
                Dim midValue As String = Request.QueryString("mid")
                If IsNumeric(midValue) AndAlso CInt(midValue) >= 0 AndAlso CInt(midValue) <= 999999 Then
                    hdnMnID.Value = CInt(midValue)
                Else
                    hdnMnID.Value = 0
                End If
            End If

            'Me.txt_user_id.Focus()
            branch_fill()
            firm_fill()

            ' Generate initial CAPTCHA
            ' GenerateNewCaptcha()
        End If

        Dim cl_id_script As String
        cl_id_script = "var curr_day,curr_month,curr_year,credit_id,branch_id_vouch;credit_id='"
        'cl_id_script = cl_id_script & Me.txt_password.ClientID & "';"
        cl_id_script = cl_id_script & "curr_day=" & Now.Day & ";"
        cl_id_script = cl_id_script & "curr_month=" & Now.Month & ";"
        cl_id_script = cl_id_script & "curr_year=" & Now.Year & ";"
        cl_id_script = cl_id_script & "branch_id_vouch=" & hdnBrID.Value & ";"
        Me.ClientScript.RegisterClientScriptBlock(Me.GetType, "cl_id", cl_id_script, True)
        Me.ClientScript.RegisterClientScriptInclude("mainscript", "script/main.js")

        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "main_receiver", "context", True)
        Dim cbscript As String = "function main_call_server (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "main_call_server", cbscript, True)
    End Sub

    ' Generate new CAPTCHA
    Private Sub GenerateNewCaptcha()
        Dim captchaText As String = GenerateCaptchaString(6)
        Session("CaptchaCode") = captchaText
        hdnEcapt.Value = captchaText

        lblCaptcha.Text = captchaText
    End Sub

    ' Generate random CAPTCHA string
    Private Function GenerateCaptchaString(length As Integer) As String
        Dim chars As String = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789" ' Excluded similar looking characters
        Dim random As New Random()
        Dim result As New StringBuilder()

        For i As Integer = 1 To length
            result.Append(chars(random.Next(chars.Length)))
        Next

        Return result.ToString()
    End Function

    ' Refresh CAPTCHA button click event
    Protected Sub btnRefreshCaptcha_Click(sender As Object, e As EventArgs) Handles btnRefreshCaptcha.Click
        GenerateNewCaptcha()
        txtCaptcha.Text = ""
        lbl_err.Text = ""
    End Sub

    ' Validate CAPTCHA
    Private Function ValidateCaptcha() As Boolean
        If Session("CaptchaCode") Is Nothing Then
            Return False
        End If

        ' Dim sessionCaptcha As String = Session("CaptchaCode").ToString().ToUpper()
        Dim sessionCaptcha As String = hdnEcapt.Value
        Dim userCaptcha As String = txtCaptcha.Text.Trim().ToUpper()

        Return sessionCaptcha = userCaptcha
    End Function

    Public Sub branch_fill()
        Dim oh1 As New Helper.Oracle.OracleHelper
        Dim sql As String = "select branch_id from branch_user where status_id=1 and key_value=75872"
        Dim dt1 As DataTable
        dt1 = oh1.ExecuteDataSet(sql).Tables(0)

        If dt1.Rows.Count = 0 Then
            Server.Transfer("show_err.aspx")
            Exit Sub
        End If

        hdnBrID.Value = Val(dt1.Rows(0)(0))
        Dim br_date As DataTable = date_on_br.fill_date(hdnBrID.Value)

        Dim query As String = "select branch_abbr,branch_name from branch_master where branch_id=" & hdnBrID.Value & ""
        Dim dt As DataTable
        dt = oh1.ExecuteDataSet(query).Tables(0)

        If dt.Rows.Count > 0 Then
            hdnBrNm.Value = dt.Rows(0)(1)
        Else
            hdnBrNm.Value = ""
        End If

        Dim str As New adv_string
    End Sub

    Public Sub firm_fill()
        Dim oh1 As New Helper.Oracle.OracleHelper
        Dim dt As DataTable
        Dim query As String = "select a.firm_id || '!' || a.firm_name as firm_id, a.firm_name, a.firm_abbr from firm_master a, active_firms b where b.branch_id = " & hdnBrID.Value & " and a.firm_id = b.firm_id and a.firm_id=8 and a.status_id=1 order by firm_id"
        dt = oh1.ExecuteDataSet(query).Tables(0)

        If dt.Rows.Count = 0 Then
            Server.Transfer("show_err.aspx")
        End If

        Me.cmb_firm.DataSource = dt
        Me.cmb_firm.DataTextField += dt.Columns(2).ColumnName
        Me.cmb_firm.DataValueField = dt.Columns(0).ColumnName
        Me.cmb_firm.DataBind()
    End Sub

    Protected Sub cmd_login_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_login.Click


        Try
            Dim password As String
            Dim userId As String
            If hdnEUser.Value <> "" AndAlso hdnEPass.Value <> "" Then
                password = _encryptDecrypt.Decrypt(hdnEPass.Value)
                userId = _encryptDecrypt.Decrypt(hdnEUser.Value)
            Else

                Me.lbl_err.Text = "Kindly enter user id and password!!"

                Exit Sub


            End If



            ' Clear error message
            Me.lbl_err.Text = ""

            ' Validate CAPTCHA first
            'If Not ValidateCaptcha() Then
            '    Me.lbl_err.Text = "Invalid Captcha. Please try again."
            '    GenerateNewCaptcha()
            '    txtCaptcha.Text = ""
            '    txt_user_id.Text = txt_user_id.Text
            '    txt_password.Text = txt_password.Text




            '    Exit Sub
            'End If

            If hdnBrNm.Value = "" Then
                Me.lbl_err.Text = "Please Try Again"
                'GenerateNewCaptcha()
                txtCaptcha.Text = ""
                Exit Sub
            Else
                If Session("loginNo") Is Nothing Then
                    Session("loginNo") = 0
                End If

                Session("loginNo") = CInt(Session("loginNo")) + 1

                If CInt(Session("loginNo")) > 3 Then
                    Dim cl_script0 As New System.Text.StringBuilder
                    cl_script0.Append("alert('You exceeded the limit. Try again later.');")
                    cl_script0.Append("window.opener=top; window.close();")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
                    Session.RemoveAll()
                    Exit Sub
                End If

                Me.hdn_key.Value = 75872
                Dim oh As New Helper.Oracle.OracleHelper
                Dim query As String
                Dim it_ip_flag As Boolean = False

                If (IsDBNull(Me.hdn_key.Value) Or Me.hdn_key.Value = "") Then
                    Me.lbl_err.Text = "Not Registered"
                    Me.Session.RemoveAll()
                    ' GenerateNewCaptcha()
                    txtCaptcha.Text = ""
                    Exit Sub
                Else
                    it_ip_flag = True
                End If

                Dim str As New adv_string
                ' Validate User ID

                If String.IsNullOrEmpty(userId) OrElse userId.Length < 5 OrElse userId.Length > 6 Then
                    'Me.txt_user_id.Text = ""
                    'Me.txt_password.Text = ""
                    Me.lbl_err.Text = HttpUtility.HtmlEncode("User ID must be 5-6 digits")
                    'GenerateNewCaptcha()
                    txtCaptcha.Text = ""
                    Exit Sub
                End If

                If Not IsNumeric(userId) Then
                    'Me.txt_user_id.Text = ""
                    'Me.txt_password.Text = ""
                    Me.lbl_err.Text = HttpUtility.HtmlEncode("User ID must contain only numbers")
                    'GenerateNewCaptcha()
                    txtCaptcha.Text = ""
                    Exit Sub
                End If

                ' Validate Password

                If String.IsNullOrEmpty(password) OrElse password.Length < 6 OrElse password.Length > 50 Then
                    'Me.txt_user_id.Text = ""
                    'Me.txt_password.Text = ""
                    Me.lbl_err.Text = HttpUtility.HtmlEncode("Password must be 6-50 characters")
                    'GenerateNewCaptcha()
                    txtCaptcha.Text = ""
                    Exit Sub
                End If

                Dim weakPasswords() As String = {"software", "password", "123456", "admin", "user"}
                If weakPasswords.Contains(password.ToLower()) Then
                    'Me.txt_user_id.Text = ""
                    'Me.txt_password.Text = ""
                    Me.lbl_err.Text = HttpUtility.HtmlEncode("Please use a stronger password")
                    ' GenerateNewCaptcha()
                    txtCaptcha.Text = ""
                    Exit Sub
                End If

                Dim passFlg As Integer
                passFlg = ValidateUser(userId, password)

                If Session("emp_branch_id") <> hdnBrID.Value Then
                    If Me.hdnBrID.Value <> 0 Then
                        Me.lbl_err.Text = "You are trying to access other branch details"
                        Me.Session.RemoveAll()
                        'GenerateNewCaptcha()
                        txtCaptcha.Text = ""
                        Exit Sub
                    Else
                        If Session("role_id") > 5 Then
                            Me.lbl_err.Text = "You are trying to access other branch details"
                            Me.Session.RemoveAll()
                            'GenerateNewCaptcha()
                            txtCaptcha.Text = ""
                            Exit Sub
                        End If
                    End If
                End If
                If (passFlg >= 1 And passFlg < 7) Then
                    Dim request As New HrmsLoginControlRequest
                    Dim Hresponse As New HrmsLoginSessionResponse
                    request.empCode = userId
                    'creating New session id
                    request.session = GenerateCaptchaString(18)


                    request.flag = "2"
                    Hresponse = Sessionhandler.HrmsLoginControl(request)
                    If Hresponse.status = "SUCCESS" Then
                        Session("cookieSessionid") = Session.SessionID
                        Session("session_id") = Hresponse.sessionid
                        Session("session_empcode") = userId
                    Else
                        Me.lbl_err.Text = "SESSION CREATION FAILED"
                        Me.Session.RemoveAll()
                        'GenerateNewCaptcha()
                        txtCaptcha.Text = ""
                        Exit Sub
                    End If

                    Dim fm_ar As Array
                    fm_ar = Me.cmb_firm.SelectedValue.Split("!")
                    Session("firm_id") = Val(fm_ar(0))
                    Session("firm_name") = fm_ar(1)
                    Session("menu_id") = hdnMnID.Value
                    Session("branch_id") = hdnBrID.Value
                    Session("branch_name") = hdnBrNm.Value
                    Session("title") = str.sentence_case(Session("firm_name") & ", " & Session("branch_name"))

                    Dim dtm As DataTable = oh.ExecuteDataSet("select message from message_dtl where firm_id= " & Val(fm_ar(0)) & " ").Tables(0)
                    If dtm.Rows.Count = 0 Then
                        Session("message") = "Welcome to " & fm_ar(1) & ", Have a nice day.."
                    Else
                        Session("message") = dtm.Rows(0)(0)
                    End If

                    Dim parameter(3) As OracleParameter
                    parameter(0) = New OracleParameter("emp", OracleType.Number, 7)
                    parameter(0).Direction = ParameterDirection.Input
                    parameter(0).Value = userId
                    parameter(1) = New OracleParameter("firm", OracleType.Number, 5)
                    parameter(1).Direction = ParameterDirection.Input
                    parameter(1).Value = Session("firm_id")
                    parameter(2) = New OracleParameter("log", OracleType.Number, 5)
                    parameter(2).Direction = ParameterDirection.Output
                    parameter(3) = New OracleParameter("logfr", OracleType.Number, 5)
                    parameter(3).Direction = ParameterDirection.Output
                    oh.ExecuteNonQuery("log_fr_chk", parameter)

                    'Me.txt_user_id.Text = ""
                    'Me.txt_password.Text = ""
                    txtCaptcha.Text = ""

                    If Me.Request.UrlReferrer IsNot Nothing AndAlso Me.Request.UrlReferrer.ToString.Contains("index.html") Then
                        Session("key") = Me.hdn_key.Value
                    Else
                        Session("key") = "75872"
                    End If

                    Dim ss As Integer
                    ss = ip_check()
                    If (ss = 0) Then
                        Dim cl_scriptq As New StringBuilder
                        cl_scriptq.Append("alert('Invalid Address! Cannot Connect! Not Authorised to view this Page!');")
                        cl_scriptq.Append("window.close('main.aspx','_self');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_scriptq.ToString, True)
                        Exit Sub
                    End If

                    ' Clear login attempts on successful login
                    Session("loginNo") = 0

                    If Session("branch_id") = 0 Then
                        Response.Redirect("Home.aspx")
                    End If

                ElseIf passFlg = 7 Or passFlg = 8 Then
                    'Me.txt_user_id.Text = ""
                    'Me.txt_password.Text = ""
                    Session.RemoveAll()
                    Me.lbl_err.Text = "Password Expired. Please Change Your Password"
                    'GenerateNewCaptcha()
                    txtCaptcha.Text = ""

                ElseIf passFlg = 98 Then
                    'Me.txt_user_id.Text = ""
                    'Me.txt_password.Text = ""
                    Session.RemoveAll()
                    Me.lbl_err.Text = "You are not Punched Today!"
                    'GenerateNewCaptcha()
                    txtCaptcha.Text = ""

                Else
                    'Me.txt_user_id.Text = ""
                    'Me.txt_password.Text = ""
                    Session.RemoveAll()
                    Me.lbl_err.Text = "Check your user id / password"
                    'GenerateNewCaptcha()
                    txtCaptcha.Text = ""
                End If
            End If


        Catch ex As Exception
            Me.lbl_err.Text = "ERROR: An unexpected error occurred"
            'GenerateNewCaptcha()
            txtCaptcha.Text = ""
        End Try
    End Sub

    Public Function ValidateUser(ByVal username As String, ByVal passwd As String) As Integer
        Dim userExists As Integer
        Dim ps As New PHelper.passwdClass
        Dim res As String

        res = ps.getRoles(username, passwd)

        If res = "0" Then
            userExists = 0
            Exit Function
        End If

        Dim str() As String
        str = res.Split("-")
        Dim oh1 As New Helper.Oracle.OracleHelper

        If CInt(str(0)) <> 99 Then
            If CInt(str(1)) >= 1 And CInt(str(1)) < 7 Then
                System.Web.HttpContext.Current.Session("user_id") = username + "!" + Me.Context.Request.UserHostAddress
                Session("access_id") = str(0)
                Session("role_id") = str(3)
                Session("emp_branch_id") = str(2)

                Dim sql As String = "select EMP_NAME from employee_master where emp_code=" & username & ""
                Dim dt As New DataTable
                dt = oh1.ExecuteDataSet(sql).Tables(0)

                If dt.Rows.Count > 0 Then
                    Session("user_name") = dt.Rows(0)(0)
                Else
                    Session.RemoveAll()
                    userExists = 0
                End If
            Else
                Session.RemoveAll()
            End If
            userExists = CInt(str(1))
        Else
            userExists = 0
        End If

        Return userExists
    End Function

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return callbackReturn
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim str() As String
        str = eventArgument.Split("?")
        callbackReturn = ValidateUser(str(0), str(1))
    End Sub

    Public Function ip_check()
        Dim oh As New Helper.Oracle.OracleHelper
        Dim VpnSSLCnt As Integer = oh.ExecuteDataSet("select count(*) from branch_system_ips where branch_id = " & Me.Session("branch_id") & " and status_id = 1").Tables(0).Rows(0)(0)

        If VpnSSLCnt = 1 Then
            Dim dt As New DataTable
            dt = oh.ExecuteDataSet("select system_ip_from,system_ip_to from BRANCH_SYSTEM_IPS t where branch_id = " & Me.Session("branch_id") & "").Tables(0)
            If IsInRange(Me.Context.Request.UserHostAddress, dt.Rows(0)(0), dt.Rows(0)(1)) Then
                Return 1
            Else
                Return 0
            End If
        Else
            Return 1
        End If
    End Function

    Public Function IsInRange(ByVal myIP As String, ByVal lowIP As String, ByVal highIP As String) As Boolean
        Dim str1() As String
        Dim str2() As String
        Dim str3() As String
        str1 = myIP.Split(".")
        str2 = lowIP.Split(".")
        str3 = highIP.Split(".")

        If ((CInt(str1(0)) >= CInt(str2(0)) And CInt(str1(0)) <= CInt(str3(0))) And
            (CInt(str1(1)) >= CInt(str2(1)) And CInt(str1(1)) <= CInt(str3(1))) And
            (CInt(str1(2)) >= CInt(str2(2)) And CInt(str1(2)) <= CInt(str3(2))) And
            (CInt(str1(3)) >= CInt(str2(3)) And CInt(str1(3)) <= CInt(str3(3)))) Then


            Return True
        Else
            Return False
        End If
    End Function

    ' VAPT - Validate Query Parameters
    Private Sub ValidateQueryParameters()
        For Each key As String In Request.QueryString.AllKeys
            If key IsNot Nothing Then
                Dim value As String = Request.QueryString(key)

                If ContainsMaliciousContent(value) OrElse value.Length > 100 Then
                    Response.Redirect("show_err.aspx")
                    Return
                End If
            End If
        Next
    End Sub

    Private Function ContainsMaliciousContent(input As String) As Boolean
        If String.IsNullOrEmpty(input) Then Return False

        Dim maliciousPatterns() As String = {
            "<script", "javascript:", "vbscript:", "onload=", "onerror=",
            "''", "--", "/*", "*/", "xp_", "sp_", "exec", "union",
            "select", "insert", "update", "delete", "drop", "create"
        }

        Dim lowerInput As String = input.ToLower()
        For Each pattern As String In maliciousPatterns
            If lowerInput.Contains(pattern) Then Return True
        Next

        Return False
    End Function
#Region "Encryption"
    Public Shared Function DecryptStringAES(cipherText As String) As String
        Dim keybytes As Byte() = Encoding.UTF8.GetBytes("8080808080808080")
        Dim iv As Byte() = Encoding.UTF8.GetBytes("8080808080808080")

        Dim encrypted As Byte() = Convert.FromBase64String(cipherText)
        Dim decriptedFromJavascript As String = DecryptStringFromBytes(encrypted, keybytes, iv)

        Return String.Format("{0}", decriptedFromJavascript)
    End Function
    Private Shared Function DecryptStringFromBytes(cipherText As Byte(), key As Byte(), iv As Byte()) As String
        ' Check arguments.
        If cipherText Is Nothing OrElse cipherText.Length <= 0 Then
            Throw New ArgumentNullException("cipherText")
        End If
        If key Is Nothing OrElse key.Length <= 0 Then
            Throw New ArgumentNullException("key")
        End If
        If iv Is Nothing OrElse iv.Length <= 0 Then
            Throw New ArgumentNullException("key")
        End If

        ' Declare the string used to hold the decrypted text.
        Dim plaintext As String = Nothing

        ' Create a RijndaelManaged object with the specified key and IV.
        Using rijAlg As New RijndaelManaged()
            ' Settings
            rijAlg.Mode = CipherMode.CBC
            rijAlg.Padding = PaddingMode.PKCS7
            rijAlg.FeedbackSize = 128

            rijAlg.Key = key
            rijAlg.IV = iv

            ' Create a decryptor to perform the stream transform.
            Dim decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV)
            Try
                ' Create the streams used for decryption.
                Using msDecrypt As New MemoryStream(cipherText)
                    Using csDecrypt As New CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)
                        Using srDecrypt As New StreamReader(csDecrypt)
                            ' Read the decrypted bytes from the decrypting stream and place them in a string.
                            plaintext = srDecrypt.ReadToEnd()
                        End Using
                    End Using
                End Using
            Catch
                plaintext = "keyError"
            End Try
        End Using

        Return plaintext
    End Function

#End Region
    <WebMethod()>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Shared Function GetKey() As Object
        ' Read API key from request headers
        Dim apiKey As String = HttpContext.Current.Request.Headers("X-API-Key")

        If String.IsNullOrEmpty(apiKey) OrElse apiKey <> "SPA-API-KEY-2024" Then
            Return New With {.message = "Invalid API key"}
        End If

        ' Example: read from Web.config
        Dim key As String = "3F2A9C7B1D4E6F8A0B5C7D9E2F4A6C8D"
        Dim xorKey As String = "XOR2024"

        ' XOR encryption
        Dim encryptedBytes = key.Select(Function(c, i) CByte(AscW(c) Xor AscW(xorKey(i Mod xorKey.Length)))).ToArray()
        Dim encrypted As String = Convert.ToBase64String(encryptedBytes)

        Return New With {.key = encrypted}
    End Function
End Class
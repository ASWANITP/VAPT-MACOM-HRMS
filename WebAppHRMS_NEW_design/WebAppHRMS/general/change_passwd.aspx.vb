Imports System.Data
Imports System.Data.OracleClient
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Web.UI
Partial Class change_passwding
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim va As String
    Dim sb As New StringBuilder
    Dim oh As New Helper.Oracle.OracleHelper
    Dim instance As New Page
    Dim value As New Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '--------VAPT - Prevent Caching of Sensitive Content--------
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1))
        Response.Cache.SetNoStore()
        Response.AppendHeader("Pragma", "no-cache")

        '--------VAPT - Input Validation--------
        ' ValidateSessionData()

        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "rcpt_receiver", "context", True)
        Dim cbscript As String = "function rcpt_call_server (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "rcpt_call_server", cbscript, True)
    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Try
            '--------VAPT - Validate and Sanitize Input--------
            Dim userText As String = ValidateAndSanitizeInput(Me.txt_user.Text)
            Dim oldPassText As String = ValidateAndSanitizeInput(Me.txt_oldpass.Text)
            Dim newPassText As String = ValidateAndSanitizeInput(Me.txt_newpass.Text)
            Dim confPassText As String = ValidateAndSanitizeInput(Me.txt_confpass.Text)
            
            If ContainsMaliciousContent(userText) OrElse ContainsMaliciousContent(oldPassText) OrElse 
               ContainsMaliciousContent(newPassText) OrElse ContainsMaliciousContent(confPassText) Then
                RedirectToLogin()
                Return
            End If
            
            Dim ps As New PHelper.passwdClass
            If Trim(userText) <> "" Then
            If oldPassText <> "" Then
                If newPassText <> "" Then
                    If confPassText <> "" Then
                        '--------VAPT - Enhanced Password Validation--------
                        If Not ValidatePasswordComplexity(newPassText) Then
                            Dim cl_script01 As New System.Text.StringBuilder
                            cl_script01.Append("alert('Password must have at least one alphabet and one numeric character and one special character');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script01.ToString, True)
                            Return
                        End If
                        
                        Dim passwordOrg As String = newPassText
                        Dim rgx As Regex = New Regex("^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$")

                        If passwordOrg.Contains(userText) Then
                            Dim cl_script01 As New System.Text.StringBuilder
                            cl_script01.Append("         alert('The password should not contain employee code');")
                            'cl_script0.Append("       window.open('../home.aspx','_self');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script01.ToString, True)
                            Return

                        ElseIf passwordOrg.Length < 8 OrElse passwordOrg.Length > 12 Then
                            Dim cl_script01 As New System.Text.StringBuilder
                            cl_script01.Append("         alert('Password length should be minimum 8 char and maximum 12');")
                            'cl_script0.Append("       window.open('../home.aspx','_self');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script01.ToString, True)
                            Return
                        ElseIf Not rgx.IsMatch(passwordOrg) Then

                            Dim cl_script01 As New System.Text.StringBuilder
                            'cl_script01.Append("         alert('Password must contain 1 lower case letter, 1 upper case letter, 1 digit, 1 special character');")
                            cl_script01.Append("         alert('Password must have at least one alphabet and one numeric character and one special character');")
                            'cl_script0.Append("       window.open('../home.aspx','_self');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script01.ToString, True)
                            Return

                        ElseIf Not CheckRepeatingSequence(passwordOrg) Then

                            Dim cl_script01 As New System.Text.StringBuilder
                            cl_script01.Append("         alert('Password should not contain any sequential or repeat numbers ( e.g 12345,10101,1111 etc will not be accepted)');")
                            'cl_script0.Append("       window.open('../home.aspx','_self');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script01.ToString, True)
                            Return
                        Else

                            '--------VAPT - Validate User ID Before Use--------
                            Dim userId As Integer = 0
                            If Not Integer.TryParse(userText, userId) OrElse userId <= 0 Then
                                RedirectToLogin()
                                Return
                            End If
                            
                            Dim message = ps.change_password(userId, oldPassText, newPassText)
                            Dim cl_script0 As New System.Text.StringBuilder
                            cl_script0.Append("         alert(' " & message & " ');")
                            cl_script0.Append("       window.open('../main.aspx','_self');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
                            Me.txt_user.Text = ""
                            Me.txt_oldpass.Text = ""
                            Me.txt_newpass.Text = ""
                            Me.txt_confpass.Text = ""
                        End If
                    Else
                        Dim cl_script0 As New System.Text.StringBuilder
                        cl_script0.Append("         alert(' Your Confirm Password is empty ');")
                        'cl_script0.Append("       window.open('../home.aspx','_self');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
                    End If
                Else
                    Dim cl_script0 As New System.Text.StringBuilder
                    cl_script0.Append("         alert(' Your New Password is empty ');")
                    'cl_script0.Append("       window.open('../home.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
                End If

            Else
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert(' Your Current Password is empty ');")
                ' cl_script0.Append("       window.open('" & qq & "','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
            End If
        Else
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('  User name is Empty ');")
            'cl_script0.Append("       window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
        End If
        Catch ex As Exception
            RedirectToLogin()
        End Try
    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return va
    End Function
    Function CheckRepeatingSequence(ByVal pswd As String) As Boolean
        ' Try
        Dim flag As Boolean = True
        Dim len As Integer = pswd.Length
        Dim first, second

        For i As Integer = 0 To len - 1 - 1

            If Char.IsNumber(pswd(i)) Then
                first = (pswd(i))

                If Char.IsNumber(pswd(i + 1)) Then
                    second = (pswd(i + 1))

                    If Val(second) = Val(first) + 1 Then
                        flag = False
                    ElseIf Val(second) = Val(first) - 1 Then
                        flag = False
                    ElseIf second = first Then
                        flag = False
                    End If
                End If
            End If
        Next

        Return flag



    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Try
            '--------VAPT - Enhanced Callback Parameter Validation--------
            If String.IsNullOrEmpty(eventArgument) OrElse eventArgument.Length > 200 OrElse ContainsMaliciousContent(eventArgument) Then
                va = "#9999"
                Return
            End If
            
            Dim aa
            aa = eventArgument.Split("#")
            
            If aa.Length < 2 Then
                va = "#9999"
                Return
            End If
        If aa(1) = "222" Then
            '--------VAPT - Validate Parameter Before SQL--------
            Dim empCode As Integer = 0
            If Not Integer.TryParse(aa(0).ToString(), empCode) OrElse empCode <= 0 Then
                Return
            End If
            
            Dim emcnt As New DataTable
            emcnt = oh.ExecuteDataSet("select count(*) from employee_master where status_id in(1,11) and emp_code>999 and emp_code=" & empCode).Tables(0)
            If emcnt.Rows(0)(0) = 1 Then
                sb.Append("1")
                sb.Append("#")
                sb.Append("1")
            Else
                sb.Append("#")
                sb.Append("9991")
            End If
        ElseIf aa(1) = "333" Then
            Dim qq
            qq = aa(0).ToString.Split("|")
            Dim emp As New DataTable
            Dim ps As New PHelper.passwdClass
            Dim cn As Integer
            cn = ps.password_chek(qq(0), qq(1))
            'emp = oh.ExecuteDataSet("select count(*) from employee_master where status_id=1 and emp_code=" & qq(0) & " and password='" & qq(1) & "'").Tables(0)
            'If emp.Rows(0)(0) = 1 Then
            If cn > 0 Then
                sb.Append("1")
                sb.Append("#")
                sb.Append("2")
            Else
                sb.Append("#")
                sb.Append("9992")
            End If
        End If
        va = sb.ToString
        Catch ex As Exception
            va = "#9999"
        End Try
    End Sub
    
    '--------VAPT - Input Validation Methods--------
    Private Sub ValidateSessionData()
        If Session("user_id") Is Nothing Then
            RedirectToLogin()
            Return
        End If
    End Sub
    
    Private Function ValidateAndSanitizeInput(input As String) As String
        If String.IsNullOrEmpty(input) Then Return String.Empty
        
        '--------VAPT - Enhanced Parameter Validation--------
        If input.Length > 100 OrElse ContainsMaliciousContent(input) Then
            RedirectToLogin()
            Return String.Empty
        End If
        
        ' Additional validation for password fields
        If input.Contains("'") OrElse input.Contains("""") OrElse input.Contains(";") Then
            RedirectToLogin()
            Return String.Empty
        End If
        
        Return input.Trim()
    End Function
    
    Private Function ValidatePasswordComplexity(password As String) As Boolean
        If String.IsNullOrEmpty(password) Then Return False
        
        ' Length check
        If password.Length < 8 OrElse password.Length > 12 Then Return False
        
        ' Complexity requirements
        Dim hasUpper As Boolean = System.Text.RegularExpressions.Regex.IsMatch(password, "[A-Z]")
        Dim hasLower As Boolean = System.Text.RegularExpressions.Regex.IsMatch(password, "[a-z]")
        Dim hasDigit As Boolean = System.Text.RegularExpressions.Regex.IsMatch(password, "\d")
        Dim hasSpecial As Boolean = System.Text.RegularExpressions.Regex.IsMatch(password, "[!*@#$%^&+=]")
        
        Return hasUpper AndAlso hasLower AndAlso hasDigit AndAlso hasSpecial
    End Function
    
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
    
    Private Sub RedirectToLogin()
        Dim cl_script0 As New System.Text.StringBuilder
        cl_script0.Append("alert('Please Login Again');")
        cl_script0.Append("window.open('../main.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
    End Sub
End Class
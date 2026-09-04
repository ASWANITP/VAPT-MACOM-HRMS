Imports System.Data
Imports System.Data.OracleClient
Imports WebAppHRMS
Imports WebAppHRMS.SessionHandler

Partial Class edp
    Inherits System.Web.UI.MasterPage
    Dim date_on_br As New Main_BLL.Main_BLL
    Dim _SessionHandler As New SessionHandler
    Public WriteOnly Property heading()
        Set(ByVal value)
            Dim str As New adv_string
            Me.lbl_head.Text = str.sentence_case(value)
        End Set
    End Property
    Public Property Subtitle As String
        Get
            Return Me.lbl_subhead.Text
        End Get
        Set(value As String)
            Me.lbl_subhead.Text = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '--------VAPT - Input Validation for Query Parameters--------
        ValidateQueryParameters()
        ValidateSessionData()

        Try
            '------------------------Session Checking---------------------------------
            Dim request As New HrmsLoginControlRequest
            Dim Hresponse As New HrmsLoginSessionResponse
            request.empCode = Session("session_empcode").ToString

            request.session = Session("session_id").ToString

            request.flag = "1"
            Hresponse = _SessionHandler.HrmsLoginControl(request)
            If Hresponse.message <> "SESSION IS LIVE" Then
                Session.RemoveAll()
                Response.Redirect("Main.aspx", True)
            End If

            If Session.SessionID <> Session("cookieSessionid") Then
                Session.RemoveAll()
                Response.Redirect("Main.aspx", True)
            End If

            '--------VAPT - Validate Session Data Before Use--------
            'If Session("user_id") Is Nothing OrElse Session("message") Is Nothing OrElse Session("branch_id") Is Nothing Then
            '    RedirectToLogin()
            '    Return
            'End If

            Dim userIdStr As String = Session("user_id").ToString()
            'If String.IsNullOrEmpty(userIdStr) OrElse ContainsMaliciousContent(userIdStr) Then
            '    RedirectToLogin()
            '    Return
            'End If

            Dim User() As String = userIdStr.Split("!")

            '--------VAPT - Sanitize Message Content--------
            Dim messageContent As String = HttpUtility.HtmlEncode(Session("message").ToString())
            Dim cs As String = "var msg_str;msg_str='" & messageContent & "';"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "mesg", cs, True)

            '--------VAPT - Validate Branch ID--------
            Dim branchId As Integer = 0
            'If Not Integer.TryParse(Session("branch_id").ToString(), branchId) OrElse branchId <= 0 Then
            '    RedirectToLogin()
            '    Return
            'End If

            Dim br_date As DataTable = date_on_br.fill_date(branchId)
            Me.lbl_date.Text = Format(br_date.Rows(0)(0), "dd/MMM/yyyy")
            'Me.lbl_time.Text = Format(System.DateTime.Now, "hh:mm:ss")

            '--------VAPT - Sanitize Title and User Name--------
            If Session("title") IsNot Nothing Then
                Me.heading = HttpUtility.HtmlEncode(Session("title").ToString())
            End If

            Dim str As New adv_string
            If Session("user_name") IsNot Nothing Then
                Dim userName As String = HttpUtility.HtmlEncode(Session("user_name").ToString())
                Me.lbl_user.Text = "Welcome :" & str.sentence_case(userName)
            End If
        Catch ex As Exception
            RedirectToLogin()
        End Try
    End Sub
    
    '--------VAPT - Input Validation Methods--------
    Private Sub ValidateQueryParameters()
        For Each key As String In Request.QueryString.AllKeys
            If key IsNot Nothing Then
                Dim value As String = Request.QueryString(key)
                
                If ContainsMaliciousContent(value) OrElse value.Length > 100 Then
                    RedirectToLogin()
                    Return
                End If
            End If
        Next
    End Sub

    Private Sub ValidateSessionData()
        Dim userId As String = Session("user_id")
        Dim brId As String = Session("branch_id")
        If userId = "" OrElse brId = "" Then
            RedirectToLogin()
            Return
        End If
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
    
    Private Sub RedirectToLogin()
        Dim cl_script0 As New System.Text.StringBuilder
        cl_script0.Append("alert('Please Login Again');")
        cl_script0.Append("window.open('main.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
    End Sub
End Class


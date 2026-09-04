Imports System.Data
Imports System.Data.OracleClient
Partial Class attendance_departmenrwise_attdepwise_d24e39db4573
    Inherits System.Web.UI.Page
    Dim dt, dt1, dt2, dt3, dt4, dt7 As New DataTable
    Dim sql, sql1, sql2, sql3, sql7 As String
    Dim oh As New Helper.Oracle.OracleHelper
    Dim str_tkn As New StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '--------VAPT - Prevent Caching of Sensitive Content--------
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1))
        Response.Cache.SetNoStore()
        Response.AppendHeader("Pragma", "no-cache")
        
        '--------VAPT - Input Validation--------
        ValidateSessionData()
        
        Try
            If Not IsPostBack Then
                '--------VAPT - Validate Session Data Before Use--------
                If Session("firm_id") Is Nothing Then
                    RedirectToLogin()
                    Return
                End If
                
                Dim firmId As Integer = 0
                If Not Integer.TryParse(Session("firm_id").ToString(), firmId) OrElse firmId <= 0 Then
                    RedirectToLogin()
                    Return
                End If
                
                sql = "select distinct dep_name,dep_id from department_mst d, employee_master e,employ_firm f where e.department_id=d.dep_id and e.status_id=1 and e.emp_code=f.emp_code and f.firm_id=" & firmId & " order by dep_name"
                dt = oh.ExecuteDataSet(sql).Tables(0)
                Me.cmb_dep.DataSource = dt
                Me.cmb_dep.DataTextField = dt.Columns(0).ColumnName
                Me.cmb_dep.DataValueField = dt.Columns(1).ColumnName
                Me.cmb_dep.DataBind()
            End If
        Catch ex As Exception
            RedirectToLogin()
        End Try
    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Try
            '--------VAPT - Validate and Sanitize Input--------
            Dim fromDate As String = ValidateAndSanitizeInput(Me.Txt_fdt.Text)
            Dim toDate As String = ValidateAndSanitizeInput(Me.Txt_tdt.Text)
            Dim selectedDep As String = ValidateAndSanitizeInput(Me.cmb_dep.SelectedValue)
            
            '--------VAPT - Enhanced Parameter Validation--------
            If String.IsNullOrEmpty(fromDate) OrElse String.IsNullOrEmpty(toDate) OrElse String.IsNullOrEmpty(selectedDep) Then
                RedirectToLogin()
                Return
            End If
            
            If Not ValidateDateRange(fromDate, toDate) Then
                RedirectToLogin()
                Return
            End If
            
            If Not ValidateDepartmentId(selectedDep) Then
                RedirectToLogin()
                Return
            End If
            
            '--------VAPT - Validate Session Data--------
            If Session("user_id") Is Nothing OrElse Session("firm_id") Is Nothing Then
                RedirectToLogin()
                Return
            End If
            
            Dim userIdStr As String = Session("user_id").ToString()
            If ContainsMaliciousContent(userIdStr) Then
                RedirectToLogin()
                Return
            End If
            
            Dim usr = userIdStr.Split("!")
            If fromDate = "" Or toDate = "" Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please Select Date');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Else
            If CDate(fromDate) > CDate(Date.Now) Or CDate(toDate) > CDate(Date.Now) Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("         alert('Future Date Not Allowed');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Else
                If CDate(fromDate) > CDate(toDate) Then
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("         alert('To Date Not Valid');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                Else
                    '--------VAPT - Validate Firm ID--------
                    Dim firmId As Integer = 0
                    If Not Integer.TryParse(Session("firm_id").ToString(), firmId) OrElse firmId <= 0 Then
                        RedirectToLogin()
                        Return
                    End If
                    
                    '--------------- ReqID 8592 starts------------------------------
                    If firmId = 8 Then
                        '--------VAPT - Validate User ID Before SQL--------
                        Dim userId As Integer = 0
                        If Not Integer.TryParse(usr(0), userId) OrElse userId <= 0 Then
                            RedirectToLogin()
                            Return
                        End If
                        
                        dt = oh.ExecuteDataSet("select count(t.dep_head) from department_mst t where t.dep_head = " & userId & "").Tables(0)
                        dt2 = oh.ExecuteDataSet("select count(t.emp_code) from employee_master t where t.access_id = 33 And t.emp_code = " & userId & "").Tables(0)
                        If (dt.Rows(0)(0) >= 1 Or dt2.Rows(0)(0) = 1) Then
                            '--------VAPT - Sanitize URL Parameters--------
                            Server.Transfer("depwiseatt.aspx?fdt='" & HttpUtility.UrlEncode(fromDate) & "'&tdt='" & HttpUtility.UrlEncode(toDate) & "'&dep=" & HttpUtility.UrlEncode(selectedDep) & "")
                        Else
                            str_tkn.Append("         alert('You are not authorized...!');")
                            str_tkn.Append(" window.open('attdepwise.aspx','_self');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
                        End If
                        '--------------- ReqID 8592 starts------------------------------
                    Else
                        '--------VAPT - Sanitize URL Parameters--------
                        Server.Transfer("depwiseatt.aspx?fdt='" & HttpUtility.UrlEncode(fromDate) & "'&tdt='" & HttpUtility.UrlEncode(toDate) & "'&dep=" & HttpUtility.UrlEncode(selectedDep) & "")
                    End If
                    '---------------------end--------------------------------------------------------------------
                End If
            End If
        End If
        Catch ex As Exception
            RedirectToLogin()
        End Try
    End Sub
    
    '--------VAPT - Input Validation Methods--------
    Private Sub ValidateSessionData()
        If Session("user_id") Is Nothing OrElse Session("firm_id") Is Nothing Then
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
        
        ' Remove potentially dangerous characters
        Dim sanitized As String = input.Trim()
        sanitized = System.Text.RegularExpressions.Regex.Replace(sanitized, "[<>""'%;()&+]", "")
        
        Return HttpUtility.HtmlEncode(sanitized)
    End Function
    
    Private Function ValidateDateRange(fromDate As String, toDate As String) As Boolean
        Try
            Dim fDate As DateTime = DateTime.Parse(fromDate)
            Dim tDate As DateTime = DateTime.Parse(toDate)
            
            ' Date range validation
            If fDate > tDate Then Return False
            If fDate > DateTime.Now OrElse tDate > DateTime.Now Then Return False
            If DateTime.Now.Subtract(fDate).Days > 365 Then Return False
            
            Return True
        Catch
            Return False
        End Try
    End Function
    
    Private Function ValidateDepartmentId(deptId As String) As Boolean
        Try
            Dim id As Integer
            If Integer.TryParse(deptId, id) Then
                Return id > 0 AndAlso id <= 9999
            End If
            Return False
        Catch
            Return False
        End Try
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

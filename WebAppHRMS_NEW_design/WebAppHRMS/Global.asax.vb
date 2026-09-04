
Public Class Global_asax
    Inherits HttpApplication
    Private Shared ReadOnly _ipRequests As New Dictionary(Of String, List(Of DateTime))()
    Private Shared ReadOnly _lock As New Object()
    Private Const MaxRequests As Integer = 30
    Private Const TimeWindowMinutes As Integer = 60
    Sub Application_Start(sender As Object, e As EventArgs)
        ' Fires when the application is started
    End Sub
    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)

        '------VAPT - improper parameter validation---------------------------------------
        'Dim paramCount As Integer = Request.QueryString.Count
        'If Request.QueryString.Count > 0 Then
        '    Response.StatusCode = 400
        '    Response.StatusDescription = "Bad Request"
        '    Response.End()
        'End If

        'no bruteforcing limit
        Dim clientIP = GetClientInfo()
        If IsRateLimited(clientIP) Then
            Response.Clear()
            Response.StatusCode = 429
            Response.StatusDescription = "Too Many Requests"
            Response.TrySkipIisCustomErrors = True
            Response.Write("Rate limit exceeded. Please try again later.")
            HttpContext.Current.ApplicationInstance.CompleteRequest()
        End If
        'End

    End Sub
    'no bruteforcing limit
    Private Function GetClientInfo() As String
        Dim ip As String = HttpContext.Current.Request.ServerVariables("HTTP_X_FORWARDED_FOR")

        If Not String.IsNullOrEmpty(ip) Then
            ' Handle multiple IPs if present
            Dim addresses() As String = ip.Split(","c)
            If addresses.Length > 0 Then
                ip = addresses(0).Trim()
            End If
        Else
            ip = HttpContext.Current.Request.UserHostAddress
        End If

        ' Get the requested page (path + query if needed)
        Dim pageName As String = HttpContext.Current.Request.RawUrl
        ' Or use Request.Url.AbsolutePath if you only want the path without query string

        Return String.Format("IP: {0}, Page: {1}", ip, pageName)
    End Function

    'end
    'no bruteforcing limit
    Private Function IsRateLimited(ip As String) As Boolean
        SyncLock _lock
            Dim now = DateTime.Now
            If Not _ipRequests.ContainsKey(ip) Then
                _ipRequests(ip) = New List(Of DateTime)()
            End If

            Dim requests = _ipRequests(ip)
            requests.RemoveAll(Function(r) r < now.AddMinutes(-TimeWindowMinutes))
            requests.Add(now)

            ' Debug logging
            HttpContext.Current.Response.AppendToLog($"IP={ip}, Count={requests.Count}")

            Return requests.Count > MaxRequests
        End SyncLock
    End Function
    'end
    'Sub Application_AcquireRequestState(sender As Object, e As EventArgs)
    '    If Context.Handler IsNot Nothing AndAlso TypeOf Context.Handler Is IRequiresSessionState Then
    '        If HttpContext.Current.Session IsNot Nothing AndAlso Session("user_id") Is Nothing Then
    '            Dim path = HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath.ToLower()

    '            ' Avoid redirect loop
    '            If Not path.EndsWith("main.aspx") AndAlso Not path.EndsWith("sessionexpired.aspx") Then
    '                HttpContext.Current.Response.Redirect("~/SessionExpired.aspx", True)
    '            End If
    '        End If
    '    End If
    'End Sub
    Protected Sub Application_PreSendRequestHeaders(ByVal sender As Object, ByVal e As EventArgs)
        Response.Headers.Remove("X-AspNet-Version")
        Response.Headers.Remove("X-Powered-By")
        Response.Headers.Remove("Cache-Control")
        Response.Headers.Add("Cache-Control", "no-store, no-cache, max-age=0, must-revalidate")
    End Sub

    Sub Application_AcquireRequestState(sender As Object, e As EventArgs)

        If Context.Handler IsNot Nothing AndAlso TypeOf Context.Handler Is IRequiresSessionState Then
            If HttpContext.Current.Session IsNot Nothing AndAlso Session("user_id") Is Nothing Then
                Dim path = HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath.ToLower()

                ' Pages that should be accessible without session
                Dim allowedPages As String() = {
                "~/login.aspx",
                "~/Home.aspx",
                "~/general/change_passwd.aspx",
                "~/main.aspx",
                "~/sessionexpired.aspx",
                "~/show_err.aspx"
            }
                ' Check if current path is not in allowed list
                If Not allowedPages.Contains(path) Then
                    HttpContext.Current.Response.Redirect("~/SessionExpired.aspx", True)
                End If
            End If
        End If
    End Sub


End Class
Imports System
Imports System.Web

Public Class RemoveOracleCookieModule
    Implements IHttpModule

    Public Sub Init(context As HttpApplication) Implements IHttpModule.Init
        AddHandler context.PreSendRequestHeaders, Sub(sender, e)
                                                      Dim response = HttpContext.Current.Response
                                                      Dim request = HttpContext.Current.Request

                                                      'If response.Cookies("X-Oracle-BMC-LBS-Route") IsNot Nothing Then
                                                      '    response.Cookies("X-Oracle-BMC-LBS-Route").Expires = DateTime.Now.AddDays(-1)
                                                      '    response.Cookies("X-Oracle-BMC-LBS-Route").Value = ""
                                                      'End If

                                                      response.Cache.SetCacheability(HttpCacheability.NoCache)
                                                      response.Cache.SetNoStore()
                                                      response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1))
                                                      response.Cache.SetValidUntilExpires(False)
                                                      response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches)

                                                      ' Force remove private and set custom cache-control
                                                      response.Headers.Remove("Cache-Control")
                                                      response.Headers.Add("Cache-Control", "no-store, no-cache, must-revalidate, max-age=0")

                                                      If request.HttpMethod = "TRACE" OrElse request.HttpMethod = "OPTIONS" OrElse request.HttpMethod = "HEAD" Then
                                                          response.StatusCode = 405
                                                          response.End()
                                                      End If

                                                      'Dim referer As String = request.Headers("Referer")
                                                      'If referer = "" OrElse referer = "https://amfluat.asirvad.com/" OrElse referer = "https://apps.asirvad.com/" OrElse referer Is Nothing OrElse referer = "http://localhost:49174/" OrElse referer = "https://test.payu.in/" OrElse referer = "https://secure.payu.in/_payment" Then
                                                      '    ' Allowed referers
                                                      'Else
                                                      '    response.StatusCode = 400
                                                      '    response.StatusDescription = "Referer header not matching"
                                                      '    response.End()
                                                      'End If
                                                  End Sub
    End Sub

    Public Sub Dispose() Implements IHttpModule.Dispose
        ' Nothing to dispose
    End Sub
End Class

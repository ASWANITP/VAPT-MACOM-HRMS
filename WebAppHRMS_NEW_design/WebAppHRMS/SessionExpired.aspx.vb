Public Class SessionExpired
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Prevent browser from caching this page
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetNoStore()
        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1))
    End Sub
End Class
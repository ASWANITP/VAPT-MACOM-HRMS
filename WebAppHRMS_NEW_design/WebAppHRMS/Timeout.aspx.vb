Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Public Class Timeout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session.Abandon()
        Session.Clear()
        Session.RemoveAll()
        System.Web.Security.FormsAuthentication.SignOut()
        Session("user_id") = Nothing
        Session("user_name") = Nothing
        Session("access_id") = Nothing
        Session("branch_id") = Nothing
        Session("emp_branch_id") = Nothing
        Session("role_id") = Nothing
        Session("key") = Nothing
        Session("message") = Nothing
        Session("firm_name") = Nothing
        Session("firm_id") = Nothing
    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("main.aspx")
    End Sub
End Class
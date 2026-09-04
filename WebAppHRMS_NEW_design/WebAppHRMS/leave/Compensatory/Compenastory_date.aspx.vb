Imports System.Data
Imports System.Data.OracleClient

Partial Class Compenastory_assign_5a9845185501
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '------VAPT - improper parameter validation---------------------------------------
        Dim paramCount As Integer = Request.QueryString.Count
        If Request.QueryString.Count > 0 Then
            Response.StatusCode = 400
            Response.StatusDescription = "Bad Request"
            Response.End()
        End If
        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txt_Compdate.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        Me.txt_Compdate.Attributes.Add("onchange", "return checkDt()")
    End Sub
End Class

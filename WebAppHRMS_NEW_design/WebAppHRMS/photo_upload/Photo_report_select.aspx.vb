Imports System.Data
Imports System.Data.OracleClient
Partial Class Honey_Photo_upload_Photo_report_select_fb07c3931947
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper

    Protected Sub btn_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_confirm.Click
        Dim User() As String = Session("user_id").ToString.Split("!")
       
        Dim User1 As Integer = User(0)
        If CDate(Me.txt_frdt.Text) > CDate(Me.txt_todt.Text) Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("        alert('From Date is greater than To Date!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

        Else
            Server.Transfer("photo report view.aspx?frdt='" & Me.txt_frdt.Text & "'&todt='" & Me.txt_todt.Text & "'&user1= " & User1 & "")

        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txt_frdt.ClientID & "';'" & Me.txt_todt.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
    End Sub

    Protected Sub btn_Exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Exit.Click
        Server.Transfer("../home.aspx")
    End Sub
End Class

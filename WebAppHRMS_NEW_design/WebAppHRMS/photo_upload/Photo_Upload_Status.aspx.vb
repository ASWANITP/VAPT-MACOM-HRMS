Imports System.Data
Imports System.Data.OracleClient

Partial Class Photo_upload_Photo_Upload_Status_04e0bd099083
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim usr, user1, status As Integer
    Dim dt As New DataTable
   
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If RadioButton1.Checked = True Then
            status = 1
        Else : RadioButton2.Checked = True
            status = 2
        End If
       
        Response.Redirect("photo upload new.aspx?status=" & status & "")


    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Response.Redirect("home.aspx")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim user1 As Integer = User(0)
        dt = oh.ExecuteDataSet("select count(emp_id) from form_accessibility where form_id in(533,544,545) and emp_id=" & user1 & " ").Tables(0)
        If dt.Rows(0)(0) = 0 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('You Are Not Authorised!!!!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        End If


    End Sub
End Class



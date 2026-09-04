Imports System.Data
Imports System.Data.OracleClient
Partial Class vipin_forms_visit_employee_photo_b4c8c1b89480
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim UserId As Integer = User(0)

        dt = oh.ExecuteDataSet("select count(*) from employee_master where emp_code = " & UserId & " and status_id = 1 and post_id in (1,10,198) ").Tables(0)

        If dt.Rows(0)(0) = 0 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('You Are Not Authorised!!!!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script0.ToString, True)
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

       

        Dim ecde As String = Me.TextBox1.Text





        Response.Redirect("visit employ report.aspx?ecde=" & ecde & " ")
    End Sub
End Class

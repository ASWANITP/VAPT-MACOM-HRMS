Imports System.Data
Imports System.Data.OracleClient

Partial Class WageRegisterCover_2e48e0e58534
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        Me.Label1.Text = Session("firm_name")
        Me.Label2.Text = Session("branch_name")
        Dim dt As DataTable
        Dim usr = Me.Session("user_id").ToString.Split("!")
        dt = oh.ExecuteDataSet("select t.access_id  from  employee_master t where t.emp_code=" & usr(0) & " ").Tables(0)
        If dt.Rows(0)(0) <> 33 And Session("firm_id") = 8 Then
            Server.Transfer("../Show_err.aspx")
        End If
    End Sub
End Class

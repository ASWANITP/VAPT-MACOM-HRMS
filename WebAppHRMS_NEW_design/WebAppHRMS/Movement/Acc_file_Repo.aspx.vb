Imports System.Data.OracleClient
Public Class Acc_file_Repo
    Inherits System.Web.UI.Page
    Dim oh, oh1 As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dtn, dtn1, dt2, dt3, st As New DataTable
    Dim sf(), sf1(), sf2(), app, rec, frm, dm As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        dt1 = oh1.ExecuteDataSet("SELECT COUNT(t.emp_id) AS ecod FROM form_accessibility t WHERE t.form_id IN (9991, 9992) AND emp_id = " & Session("user_id").ToString.Split("!")(0)).Tables(0)
        If dt1.Rows(0)(0) = 0 Then
            Server.Transfer("~/show_err.aspx")
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        sf = Session("user_id").ToString.Split("!")
        Response.Redirect("Acc_repo_file.aspx?&fdt=" & Me.txtFromDate.Value & "&tdt=" & Me.txtToDate.Value & "&emp=" & sf(0))

    End Sub
End Class
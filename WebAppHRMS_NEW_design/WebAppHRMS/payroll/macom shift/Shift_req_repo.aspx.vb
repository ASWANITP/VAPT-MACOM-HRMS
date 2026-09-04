Imports System.Data.OracleClient

Public Class Shift_req_repo
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dtn, dtn1, dt2, dt3, st As New DataTable
    Dim sf(), sf1(), sf2(), app, rec, frm, dm As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        sf = Session("user_id").ToString.Split("!")
        Response.Redirect("Shift_Report.aspx?&fdt=" & Me.txtFromDate.Value & "&tdt=" & Me.txtToDate.Value & "&emp=" & sf(0))

    End Sub
End Class
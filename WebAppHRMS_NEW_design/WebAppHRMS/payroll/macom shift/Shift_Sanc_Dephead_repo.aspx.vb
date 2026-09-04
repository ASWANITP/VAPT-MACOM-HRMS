Imports System.Data.OracleClient

Public Class Shift_Sanc_Dephead_repo
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dtn, dtn1, dt2, dt3, st As New DataTable
    Dim sf(), sf1(), sf2(), app, rec, frm, dm As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            sf = Session("user_id").ToString.Split("!")
            dt3 = oh.ExecuteDataSet("select count(*) from DEPARTMENT_MST where dep_head=" & sf(0) & "  ").Tables(0)
            If dt3.Rows(0)(0) = 0 Then

                Me.Response.Redirect("../../show_err.aspx")
            End If
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        sf = Session("user_id").ToString.Split("!")
        Response.Redirect("Shift_DepHead_Report.aspx?&fdt=" & Me.txtFromDate.Value & "&tdt=" & Me.txtToDate.Value & "&emp=" & sf(0))

    End Sub
End Class
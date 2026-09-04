Imports System.Data
Imports System.Data.OracleClient
Partial Class TOUR_Tour_Report_frm_b35e37a39468
    Inherits System.Web.UI.Page

    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Txt_fromdate.Text = Format(Date.Now, "dd/MMM/yyyy")
            Me.Txt_todate.Text = Format(Date.Now, "dd/MMM/yyyy")
        End If
    End Sub

    Protected Sub cmd_Exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_Exit.Click
        Server.Transfer("../home.aspx")
    End Sub

    Protected Sub Cmd_generate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_generate.Click
        Dim str As String
        str = ""
        str = Me.Txt_fromdate.Text & "|" & Me.Txt_todate.Text
        Server.Transfer("Tour_status_reoport.aspx?from_date=" & str)
    End Sub
End Class

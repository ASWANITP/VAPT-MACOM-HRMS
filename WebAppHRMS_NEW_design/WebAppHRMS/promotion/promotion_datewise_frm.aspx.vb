Imports System.Data
Imports System.Data.OracleClient
Partial Class PROMOTION_promotion_datewise_frm_bf06af8c8771
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.txt_fromdate.Text = Format(Date.Now, "dd/MMM/yyyy")
            Me.txt_todate.Text = Format(Date.Now, "dd/MMM/yyyy")
        End If
    End Sub

    Protected Sub cmd_Exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_Exit.Click
        Response.Redirect("../home.aspx")
    End Sub

    Protected Sub cmd_GENERATE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_GENERATE.Click
        Dim str As String
        str = ""
        str = Me.txt_fromdate.Text & "|" & Me.txt_todate.Text
        Server.Transfer("promotion_datewise_report.aspx?from_date=" & str)
    End Sub

End Class

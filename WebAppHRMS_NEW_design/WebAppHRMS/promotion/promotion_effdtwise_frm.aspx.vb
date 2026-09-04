Imports System.Data
Imports System.Data.OracleClient
Partial Class PROMOTION_promotion_effdtwise_frm_99efcef77644
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.txt_fromdt.Text = Format(Date.Now, "dd/MMM/yyyy")
            Me.txt_todate.Text = Format(Date.Now, "dd/MMM/yyyy")
        End If
    End Sub

    Protected Sub Btn_Exit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("../home.aspx")
    End Sub

    Protected Sub Btn_Generate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim str As String
        str = ""
        str = Me.txt_fromdt.Text & "|" & Me.txt_todate.Text
        Server.Transfer("promotion_effdtwise_report.aspx?from_date=" & str)
    End Sub
End Class

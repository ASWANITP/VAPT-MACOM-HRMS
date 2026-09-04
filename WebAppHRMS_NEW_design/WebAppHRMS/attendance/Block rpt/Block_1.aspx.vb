Imports system.data
Imports System.Data.OracleClient
Partial Class HRM_Block_Report_Block_1_1a89d91e4982
    Inherits System.Web.UI.Page

    Dim userAll() As String
    Dim usercode As Integer
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dtta As String = Me.txtfdt.Text
        Dim dtt1 As String = Me.txttdt.Text

        Me.Server.Transfer("Block_rpt.aspx?&fdt=" & dtta & "&tdt=" & dtt1 & "")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim User() As String = Session("user_id").ToString.Split("!")
    End Sub
End Class

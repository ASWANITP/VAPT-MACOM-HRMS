Imports System.Data
Imports system.data.oracleclient
Partial Class specificempattend_atterepo_2a0239ca8689
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Server.Transfer("individualreport.aspx?&fdt=" & Me.TextBox2.Text & "&tdt=" & Me.TextBox3.Text & "&emp=" & Me.TextBox1.Text)
    End Sub
End Class

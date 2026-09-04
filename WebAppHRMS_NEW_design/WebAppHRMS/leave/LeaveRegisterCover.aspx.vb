Imports System.Data
Imports System.Data.OracleClient

Partial Class LeaveRegisterCover_46e5cf265548
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Label1.Text = Session("firm_name")

        Me.Label2.Text = Session("branch_name")

    End Sub
End Class

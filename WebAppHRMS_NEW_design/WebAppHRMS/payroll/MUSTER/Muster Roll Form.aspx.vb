Imports System.Data
Imports System.Data.OracleClient

Partial Class Muster_Roll_Form_99a97bd44507
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim dt1 As New DataTable
    Dim fid, brid As String

    ''KRISHNADAS UPDATED
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        '  Server.Transfer("Muster Roll.aspx?Fdt=" & TextBox1.Text & "")

        'Dim toda As String

        'Server.Transfer("hrm_sec_salary_Cryrpt.aspx?Fdt=" & TextBox1.Text & "&toda=" & toda & "")

        'Me.Server.Transfer("Muster Roll.aspx?fdt=" & Me.TextBox1.Text)
        'Session("branch_id")
        brid = Session("branch_id").ToString
        'If brid = 0 Then
        Server.Transfer("MusterRollPage.aspx?fdt=" & Me.TextBox1.Text)
        'Else
        '    Server.Transfer("Muster Roll.aspx?fdt=" & Me.TextBox1.Text & "&brn=0" & brid)
        'End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
    End Sub
End Class

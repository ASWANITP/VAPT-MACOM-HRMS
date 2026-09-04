Imports System.Data
Imports System.Data.OracleClient
Partial Class majewel_suspention_majewel_datewise_06cc82cb1815
    Inherits System.Web.UI.Page
    Dim dt1 As New DataTable
    Dim oh As New helper.oracle.OracleHelper
    Dim UserAll(), res, sql, str As String
    Dim UserCode, stat As Integer
    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn As New System.Text.StringBuilder
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim fdt As String = Me.txt_cal1.Text
        Dim tdt As String = Me.txt_cal2.Text


        If Me.rbt_1.Checked = True Then
            Server.Transfer("revocated_employ_report.aspx?&fdt='" & Me.txt_cal1.Text & "' and &tdt='" & Me.txt_cal2.Text & "' ")

        ElseIf Me.rbt_2.Checked = True Then
            Server.Transfer("terminated_report.aspx?&fdt='" & Me.txt_cal1.Text & "' and &tdt='" & Me.txt_cal2.Text & "' ")
            'Response.Write("dkdkfdlfd;f")
        End If



        'Server.Transfer("employ_dtls.aspx")

        'Server.Transfer("mjewel_susp_report.aspx?&fdt='" & Me.DropDownList1.Text & "'")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)

    End Sub
End Class

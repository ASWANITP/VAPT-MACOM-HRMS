Imports System.Data
Imports System.Data.OracleClient
Partial Class employee_search_for_staff_welfare_employee_search_swf_3a91ce263046
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim str As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "EMPLOYEE REPORT"
        If Not IsPostBack Then
            Me.txt_date.Text = Format(Now.Date, "dd/MMM")
            Me.txt_date.Enabled = False
        End If
    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Dim rdb As Integer = 0
        Dim dat As New Date

        If Me.rdb_month.Checked = True Then
            rdb = 0
            dat = CDate("1/jan" & "/" & Now.Year)

        Else
            rdb = 1
            dat = CDate(Me.txt_date.Text & "/" & Now.Year)

        End If
        Me.Server.Transfer("rpt_empsearchwfd.aspx?rdb=" & rdb & "&dat=" & dat & "&month=" & Me.cmb_month.SelectedValue)

    End Sub

    Protected Sub rdb_month_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.rdb_month.Checked = True Then
            Me.cmb_month.Enabled = True
            Me.txt_date.Enabled = False
        Else
            Me.cmb_month.Enabled = False
            Me.txt_date.Enabled = True
        End If
    End Sub

    Protected Sub rdb_date_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.rdb_date.Checked = True Then
            Me.txt_date.Enabled = True
            Me.cmb_month.Enabled = False
        Else
            Me.txt_date.Enabled = False
            Me.txt_date.Enabled = True
        End If
    End Sub
End Class

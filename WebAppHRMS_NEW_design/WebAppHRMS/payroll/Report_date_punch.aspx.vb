Imports System.Data
Imports System.Data.OracleClient
Partial Class november_Report_Report_date_punch_ad250a3c2696
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1 As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cs As String = "var cont_name;cont_name='" & Me.Txt_fdt.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)
        If Not IsPostBack Then
            Me.Txt_fdt.Text = Format(CDate(Date.Today), "dd/MMM/yyyy")
            Me.Txt_tdt.Text = Format(CDate(Date.Today), "dd/MMM/yyyy")
        End If


    End Sub

    Protected Sub Cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_confirm.Click
        Dim script1 As New System.Text.StringBuilder

        If Me.Chk_Abh.Checked = False And Me.Chk_All.Checked = False And Me.Chk_Bh.Checked = False Then


            script1.Append("        alert('Please Select ALL or ABH or BH Option');")
            script1.Append("window.open('Report_date_punch.aspx?state','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

        Else
            If Me.Txt_tdt.Text = "" Or Me.Txt_fdt.Text = "" Then

                script1.Append("        alert('Please Select The Date');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
                Exit Sub
            Else
                Dim sat As Integer
                If Me.Chk_All.Checked = True Then
                    sat = 1
                End If
                If Me.Chk_Bh.Checked = True Then
                    sat = 2
                End If
                If Me.Chk_Abh.Checked = True Then
                    sat = 3
                End If

                script1.Append("window.open('Report_date_punch_display.aspx?state=" & sat & "&fdt=" & Me.Txt_fdt.Text & "&tdt=" & Me.Txt_tdt.Text & "','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            End If
        End If
    End Sub

   
End Class

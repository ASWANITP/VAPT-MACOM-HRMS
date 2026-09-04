Imports System.Data
Imports System.Data.OracleClient
Partial Class january2009_division_leave_percent_5f06f3ec6311
    Inherits System.Web.UI.Page

    Protected Sub Cmd_Confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Confirm.Click
        Dim cl_script1 As New System.Text.StringBuilder
        cl_script1.Append("window.open('Division_leave_perc_report.aspx?&fdt=" & Me.Txt_fdt.Text & "&tdt=" & Me.Txt_tdt.Text & "','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("access_id") = 33 Then
                Me.Txt_fdt.Text = Format(CDate(Date.Today), "dd/MMM/yyyy")
                Me.Txt_tdt.Text = Format(CDate(Date.Today), "dd/MMM/yyyy")

            Else
                Response.Redirect("../show_err.aspx")
            End If
        End If
    End Sub
End Class

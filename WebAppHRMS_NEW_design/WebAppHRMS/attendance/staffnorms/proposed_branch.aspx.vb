Imports System.Data
Imports System.Data.OracleClient
Partial Class Staff_norms_consolidation_proposed_branch_8d3f2a041328
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim script_val As String
        script_val = "var loanno;" & "loanno='" & "" & Me.txt_central.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

        If Not IsPostBack Then
            'Me.txt_central.Text = 0
            'Me.txt_north.Text = 0
            'Me.txt_south.Text = 0
            Me.txt_north.Focus()
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim script1 As New System.Text.StringBuilder
        If Not IsNumeric(Me.txt_central.Text) Or Not IsNumeric(Me.txt_north.Text) Or Not IsNumeric(Me.txt_south.Text) Then
            script1.Append("        alert('Please Enter Numeric Value');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        End If
        Me.Server.Transfer("zonal_consol.aspx?north=" & Val(Me.txt_north.Text) & "&south=" & Val(Me.txt_south.Text) & "&central=" & Val(Me.txt_central.Text))
    End Sub


End Class

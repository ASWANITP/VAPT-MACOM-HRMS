
Partial Class lop_to_personal_account_report_lopperasonalac_b449ae3b3189
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "LOP TO PERSONAL ACCOUNT LEAVE REPORT"
        If Not IsPostBack Then
            If Session("access_id") <> 33 Then
                Server.Transfer("../show_err.aspx")
                Exit Sub
            End If
            Me.txt_month.Text = Format(Now.Date, "MMM/yyyy")

        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If (CDate(Me.txt_month.Text) < CDate("1/dec/2008")) Then
            Dim script1 As New System.Text.StringBuilder
            script1.Append("        alert('Data Not Available');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        Else
            Dim dt As New Date
            dt = CDate("1/" & Me.txt_month.Text)
            Me.Response.Redirect("rpt_loppersonalac.aspx?dat=" & dt)
        End If


    End Sub
End Class

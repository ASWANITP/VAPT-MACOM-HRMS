Imports System.Data
Partial Class payroll_pl3_dt_463bec5a8240
    Inherits System.Web.UI.Page

    Protected Sub cmd_gnrt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_gnrt.Click
        If Request.QueryString.Get("pid") = 1 Then
            If Me.txt_dt.Text = "" Then
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert('Please Enter Date !!!!');")
                'cl_script0.Append("window.open('pl3_rep.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
            Else
                Response.Redirect("pl3_rep.aspx?dt=" & Me.txt_dt.Text)
            End If

        ElseIf Request.QueryString.Get("pid") = 2 Then
            If Me.txt_dt.Text = "" Then
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert('Please Enter Date !!!!');")
                'cl_script0.Append("window.open('pl3_rep.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
            Else
                Response.Redirect("tourrep.aspx?dt=" & Me.txt_dt.Text)
            End If
            End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "SELECT DATE"
        Dim sc As String = "var cont_name;cont_name='" & Me.txt_dt.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var2", sc, True)
        If Not IsPostBack Then
            Me.txt_dt.Text = Format(Date.Today, "dd/MMM/yyyy")
        End If
    End Sub
End Class

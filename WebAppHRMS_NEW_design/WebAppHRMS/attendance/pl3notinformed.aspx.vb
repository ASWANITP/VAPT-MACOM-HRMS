Imports system.data
Imports System.Data.OracleClient
Partial Class pl3absent_pl3notinformed_d108b4909634
    Inherits System.Web.UI.Page
    Protected Sub cmd_confrim_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confrim.Click
        If Me.Txt_fdate.Text = "" Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('Please Enter Date !!!!');")
            'cl_script0.Append("window.open('pl3_rep.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        Else
            If CDate(Me.Txt_fdate.Text) <= Date.Now Then

                Server.Transfer("pl3absent.aspx?fdate=" & Me.Txt_fdate.Text & "&cat=" & Me.Cmb_category.SelectedValue & "")
            Else
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("         alert('Future Date Not Allowed');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            End If
        End If

    End Sub
    Protected Sub cmd_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_exit.Click
        Server.Transfer("../home.aspx")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Txt_fdate.Text = Format(Date.Today, "dd/MMM/yyyy")
        End If
    End Sub
End Class

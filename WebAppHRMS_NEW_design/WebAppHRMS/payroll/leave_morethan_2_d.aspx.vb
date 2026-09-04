Imports System.Data
Imports System.Data.OracleClient
Partial Class feb2009_llll_leave_morethan_2_d_3ceae7504571
    Inherits System.Web.UI.Page
    Dim dat As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("access_id") = 33 Then
                Dim cs As String = "var cont_name;cont_name='" & Me.Txt_yr.ClientID & "';"
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)
            Else
                Response.Redirect("../show_err.aspx")
            End If

        End If
    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        dat = "1" + "/" + Me.Cmb_month.SelectedValue + "/" + Me.Txt_yr.Text
        Server.Transfer("leave_morethan_2day_per_month.aspx?dat=" & dat & "&head=" & Me.Cmb_month.SelectedItem.Text & "&year=" & Me.Txt_yr.Text & "")
    End Sub
End Class

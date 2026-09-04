
Partial Class leave_leavegreater10_59266a909512
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("access_id") <> 33 Then
                Response.Redirect("../show_err.aspx")
            End If
        End If
    End Sub

    Protected Sub btn_sub_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_sub.Click
        Server.Transfer("leaveless10_report.aspx?emp=" & CInt(Me.DropDownList1.SelectedValue) & "&type=" & CInt(Me.DropDownList2.SelectedValue))
    End Sub
End Class

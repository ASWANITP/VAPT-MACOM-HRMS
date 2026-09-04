Public Class Misc_MISHome
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub mnu_main_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles mnu_main.MenuItemClick
        Session("menu_id") = Me.mnu_main.SelectedValue
        Response.Redirect("home.aspx")
    End Sub
End Class
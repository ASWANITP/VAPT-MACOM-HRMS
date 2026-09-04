Imports System.data
Partial Class BlockALert_MainBlockSelect_65e117c06930
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "High Priority Risks UnUpdatable Branches and Employees"

        Dim script_val As String
        script_val = "var loanno;" & "loanno='" & "" & Me.txt_SelectDate.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
    End Sub
End Class

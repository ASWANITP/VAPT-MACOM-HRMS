Imports System.Data
Imports System.Data.OracleClient
Partial Class fixed_TA_New_fixed_ta_select_15a025474773
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.Oraclehelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim access As Integer
        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim UserId As Integer = User(0)
        access = Session("access_id")
        If access <> 33 Then
            Server.Transfer("../show_err.aspx")
            Exit Sub
        End If


        CType(Me.Master, WebAppHRMS.edp).Subtitle = "Fixed TA : All Reports"
        Dim script_val As String
        script_val = "var loanno;" & "loanno='" & "" & Me.check_Area.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

    End Sub
End Class

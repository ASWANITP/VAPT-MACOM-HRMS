Imports System.Data
Imports System.Data.OracleClient
Partial Class RD_Deduction_rdjoinselect_27bb72a19269
    Inherits System.Web.UI.Page

    Protected Sub Cmd_Confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Confirm.Click

        Me.Server.Transfer("rdjoinreport.aspx?EmpFrom=" & Me.Txt_EmpFrom.Text & "&EmpTo=" & Me.Txt_EmpTo.Text)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "RD Deduction Employees"
        Dim script_val2 As String
        script_val2 = "var sal;" & "sal='" & "" & Me.Txt_EmpFrom.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val2, True)

        If Not IsPostBack Then

            If Me.Session("access_id") <> 33 Then

                Me.Server.Transfer("../show_err.aspx")

            End If
        End If


    End Sub
End Class

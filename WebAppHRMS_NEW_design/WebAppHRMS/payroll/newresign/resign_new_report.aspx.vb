Imports System.Data
Imports System.Data.OracleClient
Partial Class new_resign_report_ce2dc8ce5489
    Inherits System.Web.UI.Page
    Dim dt, dt1, dt2, dt3, dt4 As New DataTable
    Dim oh As New helper.oracle.OracleHelper
    Dim UserAll(), res, sql, str, usr As String
    Dim UserCode, stat As Integer
    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn As New System.Text.StringBuilder
    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click

        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)
        If Me.Txt_fdt.Text = "" Or Me.Txt_fdt.Text Is Nothing Or Me.Txt_tdt.Text = "" Or Me.Txt_tdt.Text Is Nothing Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("        alert('Select From Date & To Date!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Else
            'If CDate(Me.Txt_fdt.Text) >= CDate(Me.Txt_tdt.Text) Then
            If CDate(Me.Txt_fdt.Text) > CDate(Me.Txt_tdt.Text) Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("        alert('From Date is greater than To Date!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Else
                Server.Transfer("resign_view _report2.aspx?fdt='" & Me.Txt_fdt.Text & "'&tdt='" & Me.Txt_tdt.Text & "'&usr=" & UserCode & "")

            End If
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Txt_fdt.Attributes.Add("onkeyup", "return check_fromdt()")
        Me.Txt_tdt.Attributes.Add("onkeyup", "return check_todt()")
    End Sub
End Class

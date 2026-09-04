Imports System.Data
Imports system.data.oracleclient
Partial Class specificempattend_atterepo_f4f6fb1e7482
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim fir As Integer
    Dim firm As String
    Dim dt1 As DataTable
    Dim sql As String
    Dim sql2 As String
    Dim fmid As Integer
    Dim dt As DataTable
    Dim dt2 As DataTable
    Dim str_tkn As New System.Text.StringBuilder
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fir = Session("firm_id")
        firm = Session("firm_name")

        Dim user() As String
        user = Session("user_id").ToString.Split("!")
        Dim usr As String = user(0)

        Dim script_val As String
        script_val = "var loanno;" & "loanno='" & "" & Me.txtLeaveFrom.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

        Dim dt As DataTable
        dt = oh.ExecuteDataSet("select t.access_id  from  employee_master t where t.emp_code=" & usr & " ").Tables(0)
        If dt.Rows(0)(0) <> 33 Then
            Server.Transfer("../Show_err.aspx")
        End If
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Server.Transfer("../home.aspx")
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Me.txtLeaveFrom.Text = "" Then
                str_tkn.Append("         alert('Choose date...!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
            Else
                Server.Transfer("simplerpt.aspx?  &from_dt=" & Me.txtLeaveFrom.Text)
            End If
        Catch ex As Exception
            str_tkn.Append("         alert('" & ex.ToString & "...!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
        End Try
    End Sub
End Class

Imports System.Data
Imports System.Data.OracleClient
Partial Class new_punch_bloc_rpt_new_block_employ_844ec3658338
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim dt As New DataTable
    Dim i As Integer
    Dim n As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If emp_txt.Text = "" Then
            Dim str_tkn As New System.Text.StringBuilder
            str_tkn.Append("         alert(' Please Enter Your Employee Code ');")

            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
            Me.emp_txt.Text = ""
            Me.emp_txt.Focus()
        Else
            dt = oh.ExecuteDataSet("select count(e.emp_code) from employee_master e where e.status_id=1 and e.emp_code=" & emp_txt.Text & "  ").Tables(0)

            If dt.Rows(0)(0) > 0 Then
                Dim fdt As String = Me.emp_txt.Text
                Dim mdt As String = Me.txt_month.Text
                Server.Transfer("punch_block_count_rpt.aspx?&fdt='" & Me.emp_txt.Text & "'&mdt='" & Me.txt_month.Text & "'")
            Else
                Dim str_tkn As New System.Text.StringBuilder
                str_tkn.Append("         alert(' Please Enter Correct Employee Code ');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)

            End If
        End If
    End Sub
End Class

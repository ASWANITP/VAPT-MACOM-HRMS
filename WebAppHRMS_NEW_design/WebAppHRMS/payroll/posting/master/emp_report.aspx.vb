Imports System.Data
Imports System.Data.OracleClient
Imports System.Text
Imports System.Web
Partial Class Emp_Master_Data_emp_report_9a03365d6661
    Inherits System.Web.UI.Page
    Dim sf() As String
    Dim dt3 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper

    'Protected ReadOnly Property OracleHelper() As Helper.Oracle.OracleHelper
    '    Get
    '        Dim oh As New Helper.Oracle.OracleHelper
    '        Return oh
    '    End Get
    'End Property

    'Protected ReadOnly Property User() As String()
    '    Get
    '        Return Session("user_id").ToString.Split("!")
    '    End Get
    'End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            sf = Session("user_id").ToString.Split("!")
            dt3 = oh.ExecuteDataSet("select count(*) from employee_master t where t.emp_code=" & sf(0) & " and  t.department_id in (546,1050) and t.firm_id=8 and t.status_id=1 ").Tables(0)
            If dt3.Rows(0)(0) = 0 Then
                Me.Server.Transfer("../../../show_err.aspx")
            End If
            TextBox1.Focus()
        End If
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            Dim script As New StringBuilder
            script.Append("alert('Please Select a Date');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script.ToString, True)
            Return
        End If

        Dim selectedDate As Date = CDate(TextBox1.Text)

        If selectedDate = Date.Now.Date Then
            Dim script As New StringBuilder
            script.Append("alert('Today\'s Date not Valid');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script.ToString, True)
            Return
        End If

        If selectedDate > Date.Now Then
            Dim script As New StringBuilder
            script.Append("alert('Future Date Not Allowed');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script.ToString, True)
            Return
        End If

        ' Redirect to the appropriate report with the selected date
        Response.Redirect("date_wise_report.aspx?date=" & selectedDate.ToString("dd/MMM/yyyy"))
    End Sub
    'Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    Server.Transfer("~\home.aspx")
    'End Sub

    Protected Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class

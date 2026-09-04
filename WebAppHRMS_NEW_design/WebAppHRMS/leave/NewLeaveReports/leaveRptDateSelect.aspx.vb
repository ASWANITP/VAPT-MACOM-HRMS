Imports System.Data
Imports system.data.oracleclient

Imports System.Threading

Partial Class leaveRptDateSelect_63e46aaf7405
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
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
        Dim usr() As String
        usr = Session("user_id").ToString.Split("!")
        'Form Accessibility checking
        dt = oh.ExecuteDataSet("select nvl(count(*),0) from form_accessibility  where form_id=1742 and emp_id = " & usr(0) & " ").Tables(0)
        If (dt.Rows(0)(0) = 0) Then
            'Server.Transfer("~/show_err.aspx")
            Response.Redirect("~/show_err.aspx")
        End If

        fir = Session("firm_id")
        firm = Session("firm_name")
        'TextBox2.Focus()
        Button2.Focus()
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox2.Text = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('Enter From Date');window.location ='leaveRptDateSelect.aspx';", True)
        Else
            If CDate(TextBox2.Text) > CDate(Date.Now) Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('Future Date is Not allowed');window.location ='leaveRptDateSelect.aspx';", True)
            Else
                Dim dtrange As String = TextBox2.Text
                Server.Transfer("dailyLeaveStatus.aspx?argv=" & TextBox2.Text.Trim())
            End If
        End If

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Server.Transfer("../../home.aspx")
    End Sub
End Class

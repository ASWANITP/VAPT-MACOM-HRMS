Imports System.Data
Imports system.data.oracleclient
Partial Class LeaveAbove2Days_8566fc0d1935
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
            Server.Transfer("~/show_err.aspx")
        End If

        fir = Session("firm_id")
        firm = Session("firm_name")
        'TextBox2.Focus()
        Button2.Focus()
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If TextBox2.Text = "" Or TextBox3.Text = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('Enter From Date');window.location ='LeaveAbove2Days.aspx';", True)
            Else
                If CDate(TextBox2.Text) > CDate(TextBox3.Text) Then
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('To Date is Not Valid');window.location ='LeaveAbove2Days.aspx';", True)
                Else
                    If CDate(TextBox3.Text) > CDate(Date.Now) Or CDate(TextBox2.Text) > CDate(Date.Now) Then
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('Future Date is Not allowed');window.location ='LeaveAbove2Days.aspx';", True)
                    Else
                        Dim dtrange As String = TextBox2.Text & "," & TextBox3.Text
                        Session("rpt_Leavedate_sel") = dtrange
                        Server.Transfer("showLeaveAbove2Days.aspx?argv=" & TextBox2.Text.Trim() & "," & TextBox3.Text.Trim())
                    End If
                End If
            End If
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('Failed to load details.');window.location ='LeaveAbove2Days.aspx';", True)
        End Try
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Server.Transfer("../../home.aspx")
    End Sub
End Class

Imports System.Data
Imports system.data.oracleclient
Partial Class specificempattend_atterepo_a74ec7922507
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
        If Not IsPostBack Then


        End If
        Me.TextBox2.Focus()
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox2.Text = "" Or TextBox3.Text = "" Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please Select Date');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Else
            If CDate(TextBox2.Text) > CDate(TextBox3.Text) Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("         alert('To Date Not Valid');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Else
                If CDate(TextBox3.Text) > CDate(Date.Now) Or CDate(TextBox2.Text) > CDate(Date.Now) Then
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("         alert('Future Date Not Allowed');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                Else
                    Server.Transfer("ReportE.aspx?&fdt=" & Me.TextBox2.Text & "&tdt=" & Me.TextBox3.Text & "")
                End If
            End If
        End If
    End Sub

    'Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    Server.Transfer("../../home.aspx")
    'End Sub
End Class

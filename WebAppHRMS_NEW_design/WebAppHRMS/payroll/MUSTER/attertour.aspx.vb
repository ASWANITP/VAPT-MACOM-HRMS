Imports System.Data
Imports system.data.oracleclient
Partial Class specificempattend_atterepo_099614a55884
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

            If Session("access_id") = 33 Then
                Me.TextBox1.Text = user(0)
            Else
                Response.Redirect("../../show_err.aspx")
            End If


        End If
            Me.TextBox1.Enabled = False
            Me.TextBox2.Focus()
            sql = "select count(t.emp_id) from form_accessibility t where t.form_id=849 and t.emp_id='" & user(0) & "'"
            sql2 = "select em.branch_id from employee_master em where em.emp_code='" & user(0) & "'"
            dt = oh.ExecuteDataSet(sql).Tables(0)
            dt2 = oh.ExecuteDataSet(sql2).Tables(0)
            If dt2.Rows(0)(0) = 0 Or dt.Rows(0)(0) <> 0 Then
                Me.TextBox1.Enabled = True
                Me.TextBox1.Focus()
            End If
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        dt1 = oh.ExecuteDataSet("select ef.firm_id from employee_master e,employ_firm ef where ef.emp_code=e.emp_code and e.emp_code=" & Me.TextBox1.Text & "").Tables(0)
        fmid = dt1.Rows(0)(0)
        If fmid <> fir Then
            str_tkn.Append("         alert('Invalid Employee Code...!');")
            str_tkn.Append(" window.open('../Home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
            Exit Sub
        End If
        If Trim(TextBox1.Text) = "" Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please Enter Emp Code');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Else
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
                        Server.Transfer("individualtourrpt.aspx?&fdt=" & Me.TextBox2.Text & "&tdt=" & Me.TextBox3.Text & "&emp=" & Me.TextBox1.Text)
                    End If
                End If
            End If
        End If
    End Sub


End Class

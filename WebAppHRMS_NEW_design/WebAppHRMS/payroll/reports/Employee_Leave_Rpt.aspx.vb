Imports System.Data
Imports System.Data.OracleClient
Partial Class STORES_Outward_Mail_Rpt_4b1ab1d41791
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Dim User() As String = Session("user_id").ToString.Split("!")
            Dim id As Integer
            id = 1406
            Dim dt1 As New DataTable
            dt1 = oh.ExecuteDataSet("select count(*) from form_accessibility where form_id=" & id & " and emp_id=" & User(0) & "").Tables(0)
            If dt1.Rows(0)(0) <= 0 Then
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert('You Are Not Authorised !!!!');")
                cl_script0.Append("window.open('../../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                Exit Sub
            End If

            Me.txt_frdt.Text = Format(Date.Now, "dd/MMM/yyyy")
            Me.txt_todt.Text = Format(Date.Now, "dd/MMM/yyyy")

            Dim dt As DataTable
            Dim sql As String = "select -1, '------Select Dept Name--------' as dep_name  from dual union all select -2, 'ALL DEPARTMENTS' as dep_name from dual union all select t.dep_id, t.dep_name from department_mst t where t.dep_id in (select distinct k.department_id from employee_master k, employ_firm e where k.emp_code = e.emp_code and k.status_id = 1 and e.firm_id =" & Me.Session("Firm_id") & ") order by dep_name"

            dt = oh.ExecuteDataSet(sql).Tables(0)
            If dt.Rows.Count > 0 Then
                Me.Cmb_Dept.DataSource = dt
                Me.Cmb_Dept.DataValueField = dt.Columns(0).ColumnName
                Me.Cmb_Dept.DataTextField = dt.Columns(1).ColumnName
                Me.Cmb_Dept.DataBind()
            End If

        End If
        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txt_frdt.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

    End Sub

    Protected Sub cmd_rpt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_rpt.Click

        If (Me.Cmb_Dept.SelectedValue = "-1") Then
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "alert('Please select Department');", True)
            Exit Sub
        End If

        If (Me.txt_frdt.Text = "" Or Me.txt_todt.Text = "") Then
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "alert('You Should Enter Valid From and To Dates');", True)
            Exit Sub
        End If

        If (CDate(Me.txt_frdt.Text) > CDate(Me.txt_todt.Text)) Then
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "alert('From Date cannot be greater than To Date');", True)
            Exit Sub
        ElseIf ((CDate(Me.txt_todt.Text) > CDate(Date.Today)) Or (CDate(Me.txt_frdt.Text) > CDate(Date.Today)) Or (CDate(Me.txt_frdt.Text) > CDate(Me.txt_todt.Text))) Then
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "alert('You Should not Enter Future Date');", True)
            Exit Sub
        End If

        Me.Server.Transfer("Employee_Leave_RptCode.aspx?frdt=" & Me.txt_frdt.Text & "&todt=" & Me.txt_todt.Text & " &dept_name= " & Me.Cmb_Dept.SelectedItem.Text & " &dept=" & Me.Cmb_Dept.SelectedValue)

    End Sub
End Class

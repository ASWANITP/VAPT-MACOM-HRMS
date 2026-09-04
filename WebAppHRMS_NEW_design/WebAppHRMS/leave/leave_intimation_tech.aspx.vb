Imports System.Data
Imports System.Data.OracleClient
Partial Class Payroll_leave_intimation_leave_intimation_tech_7fa78bdc8899
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dts, dt1, dt, dth As New DataTable
    Dim UserAll(), sf() As String
    Dim UserCode As Integer

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    Dim cs As String = "var cont_name;cont_name='" & Me.txt_remarks.ClientID & "';"
    '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)
    '    UserAll = Me.Session("user_id").ToString.Split("!")
    '    UserCode = UserAll(0)

    '    Dim s As String = "select s.post_id from employee_master s where s.emp_code=" & UserAll(0) & " "
    '    dth = oh.ExecuteDataSet("select s.post_id from employee_master s where s.emp_code=" & UserAll(0) & "").Tables(0)
    '    If Not IsPostBack Then
    '        dt1 = oh.ExecuteDataSet("select count(*) from form_accessibility s where s.form_id=6014 and s.emp_id=" & dth.Rows(0)(0) & "").Tables(0)
    '        If dt1.Rows(0)(0) = 0 Then
    '            Dim cl_script0 As New System.Text.StringBuilder
    '            cl_script0.Append("         alert('You are not Authorised to View this Page !!!!');")
    '            cl_script0.Append("window.open('../home.aspx','_self');")
    '            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)

    '            Me.Server.Transfer("../show_err.aspx")
    '        End If

    '    End If

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cs As String = "var cont_name;cont_name='" & Me.txt_remarks.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)

        UserAll = Me.Session("user_id").ToString.Split("!")
        Dim userCode As String = UserAll(0)

        ' Get post_id from employee_master
        dth = oh.ExecuteDataSet("SELECT s.post_id FROM employee_master s WHERE s.emp_code=" & userCode).Tables(0)

        If Not IsPostBack Then
            Dim postId As String = dth.Rows(0)(0).ToString()

            ' Check access by post_id
            Dim dtPostAccess As DataTable = oh.ExecuteDataSet("SELECT COUNT(*) FROM form_accessibility WHERE form_id=6014 AND emp_id=" & postId).Tables(0)

            ' Check access by userCode
            Dim dtUserAccess As DataTable = oh.ExecuteDataSet("SELECT COUNT(*) FROM form_accessibility WHERE form_id=6014 AND emp_id=" & userCode).Tables(0)

            ' If both counts are 0, show alert
            If dtPostAccess.Rows(0)(0) = 0 AndAlso dtUserAccess.Rows(0)(0) = 0 Then
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("alert('You are not Authorised to View this Page !!!!');")
                cl_script0.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)

                Me.Server.Transfer("../show_err.aspx")
            End If
        End If

        'dts = oh.ExecuteDataSet("select count(*) from form_accessibility where form_id=6014 and emp_id=" & UserAll(0) & "").Tables(0)

        If Not IsPostBack Then
            Me.Txt_fdt.Text = Format(Date.Now, "dd/MMM/yyyy")
            BindDdl()
        End If
    End Sub

    Protected Sub BindDdl()
        Dim str As String
        str = "SELECT '-----SELECT EMPLOYEE-----' AS empname, 0 AS empcode FROM dual UNION SELECT e.emp_code || '-------' || m.emp_name AS empname, e.emp_code AS empcode FROM ATTENDANCE e JOIN tl_trsfr_level d ON d.emp_code = e.emp_code JOIN employee_master m ON e.emp_code = m.emp_code JOIN tl_trsfr_level tl on tl.emp_code=d.emp_code WHERE to_date(e.curr_date) = to_date('" & Txt_fdt.Text & "') AND e.emp_code NOT IN ( SELECT t.emp_code FROM tbl_leave_intimation t WHERE to_date(t.leave_date) = to_date('" & Txt_fdt.Text & "') ) AND e.m_time IS NULL AND e.firm_id = 8 AND e.branch_id = 0 AND m.status_id=1 AND d.tl_empcode = " & UserAll(0) & ""
        'str = "select '-----SELECT EMPLOYEE-----', 0 as empcode from dual union select e.emp_code || '-------' || m.emp_name, e.emp_code empcode from ATTENDANCE e, tbl_dept_structure d, employee_master m where to_date(e.curr_date) = to_date('" & Txt_fdt.Text & "') and d.emp_code = e.emp_code and e.emp_code not in (select t.emp_code from tbl_leave_intimation t where to_date(t.leave_date)= to_date('" & Txt_fdt.Text & "') ) and e.emp_code = m.emp_code and e.m_time is null and e.firm_id = 8 and e.branch_id = 0 and d.head = " & UserAll(0) & ""
        dt = oh.ExecuteDataSet(str).Tables(0)
        If dt.Rows.Count > 0 Then
            ddl_emp.DataSource = dt
            ddl_emp.DataValueField = dt.Columns(1).ColumnName
            ddl_emp.DataTextField = dt.Columns(0).ColumnName
            ddl_emp.DataBind()
        Else
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('No Data Found!!!!');")
            cl_script1.Append(" window.open('leave_intimation_tech.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

        End If
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/home.aspx")
    End Sub

    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        Dim script1 As New System.Text.StringBuilder
        If (ddl_emp.SelectedItem.Value = 0) Then
            script1.Append("        alert('Please Select Employee..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

        ElseIf (cmb_type.SelectedItem.Value = 0) Then
            script1.Append("        alert('Please Select Type..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        ElseIf (ddl_emp.SelectedItem.Value = 0) And (cmb_type.SelectedItem.Value = 0) Then
            script1.Append("        alert('Please Enter Data..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        ElseIf (Me.cmb_type.SelectedValue = 1) And (txt_remarks.Value = "") Then
            script1.Append("        alert('Please Enter Remark..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

        Else

            Dim parameter(5) As OracleParameter
            parameter(0) = New OracleParameter("leave_date", OracleType.DateTime, 150)
            parameter(0).Direction = ParameterDirection.Input
            parameter(0).Value = Format(CDate(Me.Txt_fdt.Text), "dd/MMM/yyyy")


            parameter(1) = New OracleParameter("empcd", OracleType.Number, 6)
            parameter(1).Direction = ParameterDirection.Input
            parameter(1).Value = Me.ddl_emp.SelectedValue

            parameter(2) = New OracleParameter("status", OracleType.Number, 6)
            parameter(2).Direction = ParameterDirection.Input
            parameter(2).Value = Me.cmb_type.SelectedValue

            parameter(3) = New OracleParameter("nhead", OracleType.Number, 6)
            parameter(3).Direction = ParameterDirection.Input
            parameter(3).Value = UserAll(0)

            parameter(4) = New OracleParameter("remark", OracleType.VarChar, 250)
            parameter(4).Direction = ParameterDirection.Input
            If Me.cmb_type.SelectedValue = 1 Then
                parameter(4).Value = Me.txt_remarks.Value
            ElseIf Me.cmb_type.SelectedValue = 2 Then
                parameter(4).Value = ""
            End If


            parameter(5) = New OracleParameter("msg", OracleType.VarChar, 500)
            parameter(5).Direction = ParameterDirection.Output
            oh.ExecuteNonQuery("HRM_LEAVE_INTIMATION", parameter)

            Dim message As String
            message = parameter(5).Value
            script1.Append("                        alert('" & message & "');")
            script1.Append("window.open('leave_intimation_tech.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        End If
    End Sub

    Protected Sub Txt_fdt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_fdt.TextChanged
        BindDdl()
    End Sub
End Class

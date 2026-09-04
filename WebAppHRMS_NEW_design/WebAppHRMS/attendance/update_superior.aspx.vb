Imports System.Data
Imports System.Data.OracleClient

Partial Class payroll_update_superior_b8309cc24577
    Inherits System.Web.UI.Page
    Dim dt, dt1 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim sql, usr() As String
            usr = Me.Session("user_id").ToString.Split("!")
            sql = "select * from department_mst where dep_head=" & usr(0) & ""
            dt = oh.ExecuteDataSet(sql).Tables(0)
            If dt.Rows.Count > 0 Then
                'If Me.rd_ho.Checked = True Then
                Me.lbl_section.Text = "Department Name"
                Me.lbl_superior.Text = "Department Head"
                'If Me.rd_ho.Checked = True Then
                dt = oh.ExecuteDataSet("select dep_id,dep_name from department_mst where status=1").Tables(0)
                Me.cmb_section.DataSource = dt
                Me.cmb_section.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_section.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_section.DataBind()
                dt1 = oh.ExecuteDataSet("select emp_code,upper(emp_name)||'~'||emp_code from employee_master where status_id=1 and shift_id not in (4,5) and department_id=" & Me.cmb_section.SelectedValue & "order by upper(emp_name) ").Tables(0)
                Me.cmb_employ.DataSource = dt1
                Me.cmb_employ.DataTextField = dt1.Columns(1).ColumnName
                Me.cmb_employ.DataValueField = dt1.Columns(0).ColumnName
                Me.cmb_employ.DataBind()
                '    End If
                'End If
            Else
                Me.Server.Transfer("../show_err.aspx")
            End If
        End If
    End Sub

    Protected Sub cmb_section_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'If Me.rd_branch.Checked = True Then
        '    dt1 = oh.ExecuteDataSet("select emp_code,upper(emp_name)||'~'||emp_code from employee_master where status_id=1 and shift_id not in (4,5) and branch_id=" & Me.cmb_section.SelectedValue & "order by upper(emp_name) ").Tables(0)
        '    Me.cmb_employ.DataSource = dt1
        '    Me.cmb_employ.DataTextField = dt1.Columns(1).ColumnName
        '    Me.cmb_employ.DataValueField = dt1.Columns(0).ColumnName
        '    Me.cmb_employ.DataBind()
        'End If
        'If Me.rd_ho.Checked = True Then
        dt1 = oh.ExecuteDataSet("select emp_code,upper(emp_name)||'~'||emp_code from employee_master where status_id=1 and shift_id not in (4,5) and department_id=" & Me.cmb_section.SelectedValue & "order by upper(emp_name) ").Tables(0)
        Me.cmb_employ.DataSource = dt1
        Me.cmb_employ.DataTextField = dt1.Columns(1).ColumnName
        Me.cmb_employ.DataValueField = dt1.Columns(0).ColumnName
        Me.cmb_employ.DataBind()
        'End If
    End Sub

    'Protected Sub rd_ho_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If Me.rd_ho.Checked = True Then
    '        dt = oh.ExecuteDataSet("select dep_id,dep_name from department_mst where status=1 order by dep_name").Tables(0)
    '        Me.cmb_section.DataSource = dt
    '        Me.cmb_section.DataTextField = dt.Columns(1).ColumnName
    '        Me.cmb_section.DataValueField = dt.Columns(0).ColumnName
    '        Me.cmb_section.DataBind()
    '        dt1 = oh.ExecuteDataSet("select emp_code,upper(emp_name)||'~'||emp_code from employee_master where status_id=1 and shift_id not in (4,5) and branch_id=" & Me.cmb_section.SelectedValue & "order by upper(emp_name) ").Tables(0)
    '        Me.cmb_employ.DataSource = dt1
    '        Me.cmb_employ.DataTextField = dt1.Columns(1).ColumnName
    '        Me.cmb_employ.DataValueField = dt1.Columns(0).ColumnName
    '        Me.cmb_employ.DataBind()
    '    End If
    'End Sub

    'Protected Sub rd_branch_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If Me.rd_branch.Checked = True Then
    '        dt = oh.ExecuteDataSet("select branch_id,branch_name from branch_master where branch_id not in (0,9999) order by branch_name").Tables(0)
    '        Me.cmb_section.DataSource = dt
    '        Me.cmb_section.DataTextField = dt.Columns(1).ColumnName
    '        Me.cmb_section.DataValueField = dt.Columns(0).ColumnName
    '        Me.cmb_section.DataBind()
    '        dt1 = oh.ExecuteDataSet("select emp_code,upper(emp_name)||'~'||emp_code from employee_master where status_id=1 and shift_id not in (4,5) and branch_id=" & Me.cmb_section.SelectedValue & "order by upper(emp_name) ").Tables(0)
    '        Me.cmb_employ.DataSource = dt1
    '        Me.cmb_employ.DataTextField = dt1.Columns(1).ColumnName
    '        Me.cmb_employ.DataValueField = dt1.Columns(0).ColumnName
    '        Me.cmb_employ.DataBind()
    '    End If
    'End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Dim op(2) As OracleParameter
        op(0) = New OracleParameter("status", OracleType.Number, 5)
        'If Me.rd_ho.Checked = True Then
        op(0).Value = 0
        'ElseIf Me.rd_branch.Checked = True Then
        'op(0).Value = 1
        'End If

        op(0).Direction = ParameterDirection.Input
        op(1) = New OracleParameter("section", OracleType.Number, 5)
        op(1).Value = CInt(Me.cmb_section.SelectedValue)
        op(1).Direction = ParameterDirection.Input
        op(2) = New OracleParameter("employ", OracleType.Number, 3)
        op(2).Value = CInt(Me.cmb_employ.SelectedValue)
        op(2).Direction = ParameterDirection.Input
        oh.ExecuteNonQuery("add_supperior", op)
        Dim cl_script0 As New System.Text.StringBuilder
        cl_script0.Append("         alert(' Confirmed ');")
        'cl_script0.Append("       window.open('../home.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
    End Sub

    Protected Sub cmd_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_exit.Click
        Response.Redirect("../home.aspx")
    End Sub
End Class

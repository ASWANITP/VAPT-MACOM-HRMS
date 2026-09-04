Imports System.Data
Imports System.Data.OracleClient
Partial Class Payroll_department_structure_department_updation_152b77245816
    Inherits System.Web.UI.Page
    Dim dt, dt1, dt2, dt3, dt4, dt5, dt6, dt7, dt8, dt9, dt10, dt11, dts, dtn As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim RH As New WholeHelper.ClsRepCtrl
    Dim tb As New Table
    Dim dr, dr1, dr2 As TableRow
    Dim BrID As Integer
    Dim sf(), sf1(), sf2 As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim UserId As Integer = User(0)
        dts = oh.ExecuteDataSet("select count(*) from form_accessibility where form_id=6013 and emp_id=" & User(0) & "").Tables(0)
        If dts.Rows(0)(0) = 0 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('You are not Authorised to View this Page !!!!');")
            'cl_script0.Append("window.open('../home.aspx','_self');")

            'the below code snip can be use instead of this line:
            'cl_script0.Append("window.open('../home.aspx','_self');")
            'to avoid any confusion of the depth of the folder where the page lies

            Dim home As String = ResolveUrl("~/home.aspx")
            cl_script0.Append($"window.open('{home}','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        End If
        If Not IsPostBack Then
            sf = Session("user_id").ToString.Split("!")
            'dt2 = oh.ExecuteDataSet("select distinct a.dep_id, a.dep_name || ' - ' || b.emp_code || ' - ' || b.emp_name || ' - ' || c.designation as depname from TBL_DEPT_STRUCTURE t, employee_master b, designation_mst c, employ_firm f, department_mst a where b.emp_code > 9999 and t.head = b.emp_code and a.dep_id = b.department_id and b.designation_id = c.designation_id and b.emp_code = f.emp_code and f.firm_id = " & Session("firm_id") & "").Tables(0)
            'Me.ddl_head.DataSource = dt2
            'Me.ddl_head.DataTextField = dt2.Columns(1).ColumnName
            'Me.ddl_head.DataValueField = dt2.Columns(0).ColumnName
            'Me.ddl_head.DataBind()
            'dt1 = oh.ExecuteDataSet("select distinct a.dep_id, a.dep_name from TBL_DEPT_STRUCTURE t, employee_master b, designation_mst c, employ_firm f, department_mst a where b.emp_code > 9999 and t.head = b.emp_code and a.dep_id = b.department_id and b.designation_id = c.designation_id and b.emp_code = f.emp_code and f.firm_id = 8").Tables(0)
            'Me.ddl_dept.DataSource = dt1
            'Me.ddl_dept.DataTextField = dt1.Columns(1).ColumnName
            'Me.ddl_dept.DataValueField = dt1.Columns(0).ColumnName
            'Me.ddl_dept.DataBind()

            dt3 = oh.ExecuteDataSet("select '--------SELECT HEAD--------' from dual union all select distinct b.emp_code || ' - ' || b.emp_name from TBL_DEPT_STRUCTURE t, employee_master b, designation_master c, employ_firm f, department_mst a where b.emp_code > 9999 and t.head = b.emp_code and a.dep_id = b.department_id and b.designation_id = c.designation_id and b.emp_code = f.emp_code and f.firm_id = 8 order by 1").Tables(0)
            Me.ddl_tech.DataSource = dt3
            Me.ddl_tech.DataTextField = dt3.Columns(0).ColumnName
            Me.ddl_tech.DataValueField = dt3.Columns(0).ColumnName
            Me.ddl_tech.DataBind()
            dt9 = oh.ExecuteDataSet("select '--------SELECT CURRENT HEAD--------' from dual union all select distinct b.emp_code || ' - ' || b.emp_name from TBL_DEPT_STRUCTURE t, employee_master b, designation_master c, employ_firm f, department_mst a where b.emp_code > 9999 and t.head = b.emp_code and a.dep_id = b.department_id and b.designation_id = c.designation_id and b.emp_code = f.emp_code and f.firm_id = 8 order by 1").Tables(0)
            Me.ddl_currname.DataSource = dt9
            Me.ddl_currname.DataTextField = dt9.Columns(0).ColumnName
            Me.ddl_currname.DataValueField = dt9.Columns(0).ColumnName
            Me.ddl_currname.DataBind()




        End If
    End Sub


    'Protected Sub ddl_dept_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_dept.SelectedIndexChanged
    '    dt2 = oh.ExecuteDataSet("select b.emp_code || '-' || b.emp_name from department_mst a, employee_master b where a.dep_head = b.emp_code and a.dep_id = " & ddl_dept.SelectedValue & " ").Tables(0)
    '    Me.txt_dhead.Text = dt2.Rows(0)(0)
    '    Dim s1() As String = dt2.Rows(0)(0).ToString().Split("-")
    '    dt3 = oh.ExecuteDataSet("select t.emp_code||'-'||em.emp_name from tbl_dept_structure t,employee_master em where em.emp_code=t.emp_code and t.head=" & s1(0) & "").Tables(0)
    '    Me.ddl_tech.DataSource = dt3
    '    Me.ddl_tech.DataTextField = dt3.Columns(0).ColumnName
    '    Me.ddl_tech.DataValueField = dt3.Columns(0).ColumnName
    '    Me.ddl_tech.DataBind()

    'End Sub
    Protected Sub Cmd_Exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exit.Click
        Response.Redirect("~/home.aspx")
    End Sub

    Protected Sub btn_exitemp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exitemp.Click
        Response.Redirect("~/home.aspx")
    End Sub

    Protected Sub btn_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_confirm.Click
        'sf2 = Session("user_id").ToString.Split("!")
        'dtn = oh.ExecuteDataSet("select t.emp_name from employee_master t where t.emp_code=" & sf(0) & "").Tables(0)
        Dim script1 As New System.Text.StringBuilder

     

        If (txt_newemp.Text = "") Then
            script1.Append("        alert('Please Enter New Head Empcode..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

        ElseIf (txt_DepHead.Text = "") Then

            script1.Append("        alert('Please Enter Member..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)


        Else

            Dim parameter(3) As OracleParameter
            parameter(0) = New OracleParameter("em_code", OracleType.Number, 10)
            parameter(0).Direction = ParameterDirection.Input
            parameter(0).Value = Me.txt_DepHead.Text
            parameter(1) = New OracleParameter("nhead", OracleType.Number, 10)
            parameter(1).Direction = ParameterDirection.Input
            parameter(1).Value = Me.txt_newemp.Text
            parameter(2) = New OracleParameter("msg", OracleType.VarChar, 150)
            parameter(2).Direction = ParameterDirection.Output
            parameter(3) = New OracleParameter("flag", OracleType.Number, 2)
            parameter(3).Direction = ParameterDirection.Input
            parameter(3).Value = 1
            oh.ExecuteNonQuery("HRM_DEPT_STRUT", parameter)
            Dim message As String
            message = parameter(2).Value
            script1.Append("                        alert('" & message & "');")
            script1.Append("window.open('department_updation.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        End If
    End Sub

    Protected Sub txt_NewHead_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_NewHead.TextChanged
        dt6 = oh.ExecuteDataSet("select em.emp_name from employee_master em where em.emp_code=" & txt_NewHead.Text & "").Tables(0)
        If (dt6.Rows.Count > 0) Then
            txt_Name.Text = dt6.Rows(0)(0)
        Else
            Dim script1 As New System.Text.StringBuilder
            script1.Append("        alert('NO data found..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        End If
    End Sub

    'Protected Sub txt_newemp_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_newemp.TextChanged

    '    dt4 = oh.ExecuteDataSet("select em.emp_name from employee_master em where em.emp_code=" & txt_newemp.Text & "").Tables(0)
    '    TextBoxname.Text = dt4.Rows(0)(0)
    'End Sub
    Protected Sub txt_newemp_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_newemp.TextChanged

        dt4 = oh.ExecuteDataSet("select em.emp_name from employee_master em where em.emp_code=" & txt_newemp.Text & "").Tables(0)

        If (dt4.Rows.Count > 0) Then
            TextBoxname.Text = dt4.Rows(0)(0)
        Else
            Dim script1 As New System.Text.StringBuilder
            script1.Append("        alert('NO data found..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        End If

    End Sub




    Protected Sub txt_DepHead_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_DepHead.TextChanged
        dt5 = oh.ExecuteDataSet("select em.emp_name from employee_master em where em.emp_code=" & txt_DepHead.Text & "").Tables(0)
        If (dt5.Rows.Count > 0) Then
            TextBox1.Text = dt5.Rows(0)(0)


        Else
            Dim script1 As New System.Text.StringBuilder
            script1.Append("        alert('NO data found..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        End If
    End Sub


    Protected Sub btn_conemp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_conemp.Click
        Dim script1 As New System.Text.StringBuilder
        'dt7 = oh.ExecuteDataSet("select count(t.head) from tbl_dept_structure t where t.head=" & Me.txt_NewHead.Text & " ").Tables(0)

        'If (dt7.Rows(0)(0) > 0) Then
        '    script1.Append("        alert('Already a head..!!');")
        '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        '    Exit Sub

        If (txt_NewHead.Text = "") Then
            script1.Append("        alert('Please Enter New Member EmpCode..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        ElseIf (txt_Name.Text = "") Then
            script1.Append("        alert('Please enter a valid empcode..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        Else
            Dim s1() As String = Me.ddl_tech.SelectedValue.ToString().Split("-")
            Dim parameter(3) As OracleParameter
            parameter(0) = New OracleParameter("em_code", OracleType.Number, 6)
            parameter(0).Direction = ParameterDirection.Input
            parameter(0).Value = Me.txt_NewHead.Text

            parameter(1) = New OracleParameter("nhead", OracleType.Number, 6)
            parameter(1).Direction = ParameterDirection.Input
            parameter(1).Value = s1(0)

            parameter(2) = New OracleParameter("msg", OracleType.VarChar, 150)
            parameter(2).Direction = ParameterDirection.Output

            parameter(3) = New OracleParameter("flag", OracleType.Number, 2)
            parameter(3).Direction = ParameterDirection.Input
            parameter(3).Value = 0


            oh.ExecuteNonQuery("HRM_DEPT_STRUT", parameter)
            Dim message As String
            message = parameter(2).Value

            script1.Append("                        alert('" & message & "');")
            script1.Append("window.open('department_updation.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        End If
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim script1 As New System.Text.StringBuilder
        'dt11 = oh.ExecuteDataSet("select count(t.head) from tbl_dept_structure t where t.head=" & Me.txt_newh.Text & " ").Tables(0)

        'If (dt7.Rows(0)(0) > 0) Then
        '    script1.Append("        alert('Already a head..!!');")
        '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        '    Exit Sub

        If (ddl_currname.SelectedIndex = -1) Then
            script1.Append("        alert('Please select current head EmpCode..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        ElseIf (txt_newh.Text = "") Then
            script1.Append("        alert('Please enter  empcode..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        Else
            Dim s2() As String = Me.ddl_currname.SelectedValue.ToString().Split("-")
            Dim parameter(3) As OracleParameter
            parameter(0) = New OracleParameter("em_code", OracleType.Number, 6)
            parameter(0).Direction = ParameterDirection.Input
            parameter(0).Value = Me.txt_newh.Text

            parameter(1) = New OracleParameter("nhead", OracleType.Number, 6)
            parameter(1).Direction = ParameterDirection.Input
            parameter(1).Value = s2(0)

            parameter(2) = New OracleParameter("msg", OracleType.VarChar, 150)
            parameter(2).Direction = ParameterDirection.Output

            parameter(3) = New OracleParameter("flag", OracleType.Number, 2)
            parameter(3).Direction = ParameterDirection.Input
            parameter(3).Value = 2


            oh.ExecuteNonQuery("HRM_DEPT_STRUT", parameter)
            Dim message As String
            message = parameter(2).Value

            script1.Append("                        alert('" & message & "');")
            script1.Append("window.open('department_updation.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        End If
    End Sub

    'Protected Sub Chk_head_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chk_head.CheckedChanged
    '    If Me.Chk_emp.Checked = True Then
    '        Me.Panel1.Visible = False
    '    End If
    'End Sub

    Protected Sub txt_newh_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_newh.TextChanged
        dt10 = oh.ExecuteDataSet("select em.emp_name from employee_master em where em.emp_code=" & txt_newh.Text & "").Tables(0)

        If (dt10.Rows.Count > 0) Then
            txt_newname.Text = dt10.Rows(0)(0)
        Else
            Dim script1 As New System.Text.StringBuilder
            script1.Append("        alert('NO data found..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        End If
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        Response.Redirect("~/home.aspx")
    End Sub
End Class



   

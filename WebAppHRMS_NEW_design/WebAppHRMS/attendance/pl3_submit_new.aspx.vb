Imports System.Data
Imports System.Data.OracleClient
Partial Class pl3_pl3_submit_new_58b07fd55633
    Inherits System.Web.UI.Page
    Dim dt, dt1, dt2, dt3, dt4 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim brid As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim User() As String
        User = Session("user_id").ToString.Split("!")
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "PL3 UPDATION"
        dt = oh.ExecuteDataSet("select a.branch_id from employee_master a where a.emp_code=" & User(0) & " and a.status_id=1 and a.branch_id=" & Session("branch_id") & "").Tables(0)
        If dt.Rows.Count > 0 Then
            brid = dt.Rows(0)(0)
            If brid = 0 Then
                If Not IsPostBack Then
                    dt2 = oh.ExecuteDataSet("select a.dep_id from department_mst a where (a.AUTHORISED_PERSON=" & User(0) & " or a.dep_head=" & User(0) & ")").Tables(0)
                    If dt2.Rows.Count > 0 Then
                        'dt3 = oh.ExecuteDataSet("select a.department_id from department_major a where a.AUTHORISED_PERSON=" & User(0) & " and a.department_id=9").Tables(0)
                        If dt2.Rows(0)(0) = 133 Or dt2.Rows(0)(0) = 23 Then
                            dt1 = oh.ExecuteDataSet("select a.emp_code, upper(a.emp_name) || '~' || a.emp_code from employee_master  a,daily_attend     b,department_mst   d  where (a.emp_code = b.emp_code) and a.status_id = 1 and b.m_time is null and a.department_id = d.dep_id and (d.authorised_person = " & User(0) & " or d.dep_head=" & User(0) & ") and a.shift_id not in (4, 5) and not exists (select t.emp_code from training_attend t where (t.emp_code = a.emp_code) and to_date(t.training_date) = to_date(sysdate) and t.in_time is not null) and not exists (select emp_code from leave_pl3 c where (to_date(leave_date) = to_date(sysdate)) and a.emp_code = c.emp_code) and not exists (select emp_code from employ_leave_dtl d  where to_date(sysdate) between to_date(d.leave_frdate) and to_date(d.leave_todate) and a.emp_code = d.emp_code) and not exists (select emp_code from hrm_7days_off_day h where to_date(sysdate) between to_date(h.from_dt) and to_date(h.to_dt) and a.EMP_CODE=h.emp_code and h.status in (1,3)) order by a.emp_name").Tables(0)
                            If dt1.Rows.Count <= 0 Then
                                Dim cl_script0 As New System.Text.StringBuilder
                                cl_script0.Append("         alert('No Details for PL3!!!!');")
                                cl_script0.Append("window.open('../home.aspx','_self');")
                                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                            Else
                                Me.cmb_Employee.DataSource = dt1
                                Me.cmb_Employee.DataTextField = dt1.Columns(1).ColumnName
                                Me.cmb_Employee.DataValueField = dt1.Columns(0).ColumnName
                                Me.cmb_Employee.DataBind()
                            End If
                        Else
                            dt1 = oh.ExecuteDataSet("select a.emp_code, upper(a.emp_name) || '~' || a.emp_code from employee_master  a,daily_attend     b,department_mst   d  where (a.emp_code = b.emp_code) and a.status_id = 1 and a.emp_type in (1,2) and a.post_id not in (230) and b.m_time is null and a.branch_id = 0 and d.major_dep_id is not null and a.department_id = d.dep_id and (d.authorised_person =" & User(0) & " or d.dep_head=" & User(0) & ") and a.shift_id not in (4, 5) and not exists (select t.emp_code from training_attend t where (t.emp_code = a.emp_code) and to_date(t.training_date) = to_date(sysdate) and t.in_time is not null) and not exists (select emp_code from leave_pl3 c where (to_date(leave_date) = to_date(sysdate)) and a.emp_code = c.emp_code) and not exists (select emp_code from employ_leave_dtl dd where to_date(sysdate) between to_date(dd.leave_frdate) and to_date(dd.leave_todate) and a.emp_code = dd.emp_code) and not exists (select emp_code from hrm_7days_off_day h where to_date(sysdate) between to_date(h.from_dt) and to_date(h.to_dt) and a.EMP_CODE=h.emp_code and h.status in (1,3)) order by a.emp_name").Tables(0)
                            If dt1.Rows.Count <= 0 Then
                                Dim cl_script0 As New System.Text.StringBuilder
                                cl_script0.Append("         alert('No Details for PL3!!!!');")
                                cl_script0.Append("window.open('../home.aspx','_self');")
                                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                            Else
                                Me.cmb_Employee.DataSource = dt1
                                Me.cmb_Employee.DataTextField = dt1.Columns(1).ColumnName
                                Me.cmb_Employee.DataValueField = dt1.Columns(0).ColumnName
                                Me.cmb_Employee.DataBind()
                            End If
                        End If
                    Else
                        Dim cl_script0 As New System.Text.StringBuilder
                        cl_script0.Append("         alert('You Are Not Authorised...!!!!');")
                        cl_script0.Append("window.open('../home.aspx','_self');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                    End If
                End If
            ElseIf brid <> 0 Then
                dt3 = oh.ExecuteDataSet("select a.emp_code from employee_master a where a.emp_code=" & User(0) & " and a.status_id=1 and a.branch_id=" & Session("branch_id") & "").Tables(0)
                If Not IsPostBack Then
                    If dt3.Rows.Count > 0 Then
                        'dt1 = oh.ExecuteDataSet("select a.emp_code, upper(a.emp_name) || '~' || a.emp_code from employee_master a, daily_attend b,department_mst c where(a.emp_code = b.emp_code) and a.status_id = 1 and a.department_id =c.dep_id and c.major_dep_id<>9 and b.m_time is null and a.branch_id =" & Session("branch_id") & " and a.shift_id not in (4, 5) and not exists (select t.emp_code from training_attend t where(t.emp_code = a.emp_code) and to_date(t.training_date) = to_date(sysdate) and t.in_time is not null) and not exists (select emp_code from leave_pl3 c where(to_date(leave_date) = to_date(sysdate)) and a.emp_code = c.emp_code)and not exists (select emp_code from employ_leave_dtl d where to_date(sysdate) between to_date(d.leave_frdate) and to_date(d.leave_todate) and a.emp_code = d.emp_code) order by upper(a.emp_name)").Tables(0)
                        dt1 = oh.ExecuteDataSet("select a.emp_code, upper(a.emp_name) || '~' || a.emp_code from employee_master  a, daily_attend     b, department_mst   c where (a.emp_code = b.emp_code) and a.status_id = 1 and a.department_id = c.dep_id and (c.major_dep_id <> 9 or c.major_dep_id is null) and b.m_time is null and a.branch_id = " & Session("branch_id") & "  and a.shift_id not in (4, 5) and not exists (select t.emp_code from training_attend t where (t.emp_code = a.emp_code) and to_date(t.training_date) = to_date(sysdate) and t.in_time is not null) and not exists (select emp_code from leave_pl3 c where (to_date(leave_date) = to_date(sysdate)) and a.emp_code = c.emp_code) and not exists (select emp_code from employ_leave_dtl d where to_date(sysdate) between to_date(d.leave_frdate) and to_date(d.leave_todate) and a.emp_code = d.emp_code) and not exists (select emp_code from hrm_7days_off_day h where to_date(sysdate) between to_date(h.from_dt) and to_date(h.to_dt) and a.EMP_CODE=h.emp_code and h.status in (1,3)) order by a.emp_name").Tables(0)
                        If dt1.Rows.Count <= 0 Then
                            Dim cl_script0 As New System.Text.StringBuilder
                            cl_script0.Append("         alert('No Details for PL3!!!!');")
                            cl_script0.Append("window.open('../home.aspx','_self');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                        Else
                            Me.cmb_Employee.DataSource = dt1
                            Me.cmb_Employee.DataTextField = dt1.Columns(1).ColumnName
                            Me.cmb_Employee.DataValueField = dt1.Columns(0).ColumnName
                            Me.cmb_Employee.DataBind()
                        End If
                    Else
                        Dim cl_script0 As New System.Text.StringBuilder
                        cl_script0.Append("         alert('You Are Not Authorised...!!!!');")
                        cl_script0.Append("window.open('../home.aspx','_self');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                    End If
                End If
            End If
        Else
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('You Are Not Authorised...!!!!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        End If
        Dim client_name As String
        client_name = "var master_no;" & "master_no='" & "" & Me.txt_Reason.ClientID & "'" & ";"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", client_name, True)
    End Sub
    Protected Sub btn_Confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Confirm.Click
        If Me.txt_Reason.Text = "" And Me.cmb_particulars.SelectedValue <> 0 Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('You must Specify reason ');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Me.txt_Reason.Focus()
        Else
            Dim op(4) As OracleParameter
            op(0) = New OracleParameter("emp_code", OracleType.Number, 5)
            op(0).Value = CInt(Me.cmb_Employee.SelectedValue)
            op(0).Direction = ParameterDirection.Input
            op(1) = New OracleParameter("brid", OracleType.Number, 5)
            op(1).Value = Session("branch_id")
            op(1).Direction = ParameterDirection.Input
            op(2) = New OracleParameter("leave", OracleType.Number, 3)
            op(2).Value = CInt(Me.cmb_particulars.SelectedValue)
            op(2).Direction = ParameterDirection.Input
            op(3) = New OracleParameter("leave_reason", OracleType.VarChar, 250)
            If Me.cmb_particulars.SelectedValue = 0 And Me.txt_Reason.Text = "" Then
                op(3).Value = "NOT INFORMED"
            Else
                op(3).Value = Me.txt_Reason.Text
            End If
            op(3).Direction = ParameterDirection.Input
            op(4) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
            op(4).Direction = ParameterDirection.Output
            oh.ExecuteNonQuery("pl3_confirm", op)
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('" + op(4).Value + "');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Server.Transfer("pl3_submit_new.aspx")
            Me.txt_Reason.Text = ""
        End If
    End Sub
End Class

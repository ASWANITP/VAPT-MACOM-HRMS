Imports System.Data
Imports System.Data.OracleClient
Partial Class feb2009_change_shift_press_40e058a18002
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2, dt3, dt4, dt5 As New DataTable
    Dim sf() As String
    Dim fmid As Integer
    Dim dept As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ass As DataTable = oh.ExecuteDataSet("select count(*) from form_accessibility where emp_id=" & Session("user_id").ToString.Split("!")(0) & " and form_id=2024").Tables(0)
        If ass.Rows(0)(0) = 1 Then
            Server.Transfer("~/payroll/macom shift/multiple_shift_change.aspx")
        End If
        Dim ass1 As DataTable = oh.ExecuteDataSet("select count(*) from form_accessibility where emp_id=" & Session("user_id").ToString.Split("!")(0) & " and form_id=2025").Tables(0)
        If ass1.Rows(0)(0) = 1 Then
            Server.Transfer("~/payroll/macom shift/approve shift.aspx")
        End If
        '---------70009846
        Dim dept As DataTable = oh.ExecuteDataSet("select count(*)from employee_master t where t.DEPARTMENT_ID in(748,825) and t.emp_code=" & Session("user_id").ToString.Split("!")(0) & "").Tables(0)
        If dept.Rows(0)(0) = 1 Then
            Response.Redirect("Change_Shift_press_Mageeth.aspx")
        End If
        '-----------


        fmid = Session("firm_id")

        Dim script_val2 As String
        script_val2 = "var sal;" & "sal='" & "" & Me.lbl_msg.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val2, True)
        If Not IsPostBack Then
            sf = Session("user_id").ToString.Split("!")
            dt = oh.ExecuteDataSet("select count(*) from form_accessibility where emp_id=" & sf(0) & " and form_id=58").Tables(0)

            'adding rule from database 
            Dim ruldt As DataTable
            Dim rulcmd As String
            Dim rulqry As String = ""
            If fmid = 28 Then
                rulcmd = "select * from ho_tour_rule ht where ht.stats_id=1 and ht.rule=4 and ht.emp_code=" & sf(0) & " order by ht.rule"
            Else
                rulcmd = "select * from ho_tour_rule ht where ht.stats_id=1 and ht.rule=3 and ht.emp_code=" & sf(0) & " order by ht.rule"
            End If
            ruldt = oh.ExecuteDataSet(rulcmd).Tables(0)



            If dt.Rows(0)(0) = 0 Then
                Server.Transfer("../show_err.aspx")

            Else

                '---------------------------------------Added on 18-Jun-2019--For Jewellery
                Try
                    If fmid <> 24 Then
                        chkPerm.Visible = False
                    Else ' The option 'Make permanent change' view set to these employees
                        Dim dtSec As New DataTable
                        dtSec = oh.ExecuteDataSet("select count(*) from form_accessibility t where emp_id=" & sf(0) & " and form_id=" & 1818 & "").Tables(0)
                        If dtSec.Rows(0)(0) = 0 Then
                            chkPerm.Visible = False
                        Else
                            chkPerm.Visible = True
                        End If
                    End If
                Catch ex As System.Exception
                    chkPerm.Visible = False
                End Try
                '-----------------------------

                If ruldt.Rows.Count > 0 Then

                    Dim rowCount As Integer = ruldt.Rows.Count
                    For rowCounter As Integer = 0 To rowCount - 1
                        rulqry = rulqry + ruldt.Rows(rowCounter)(2).ToString
                    Next
                    dt1 = oh.ExecuteDataSet(rulqry).Tables(0)
                ElseIf sf(0) = 10749 Then

                    'dt3 = oh.ExecuteDataSet("select department_id from employee_master where emp_code=" & sf(0) & "").Tables(0)

                    dt1 = oh.ExecuteDataSet("select e.emp_code||'--'||e.emp_name||'    ---> '||'   SHIFT'||': '||s.shift||' , TIME :'||'( '||s.in_time||' - '||s.out_time||' )',e.emp_code from employee_master e,time_tab s where e.shift_id=s.shift_id and e.department_id not in (154) and e.department_id in (select d.dep_id from department_mst d where d.major_dep_id=14) and e.emp_code>9999 and e.status_id=1 order by e.emp_code").Tables(0)
                Else

                    dt5 = oh.ExecuteDataSet("select count(*) from department_mst t where t.dep_head=" & sf(0) & "").Tables(0)
                    If dt5.Rows(0)(0) > 0 Then
                        'dt3 = oh.ExecuteDataSet("select department_id from employee_master where emp_code=" & sf(0) & "").Tables(0)
                        dt1 = oh.ExecuteDataSet("select e.emp_code||'--'||e.emp_name||'    ---> '||'   SHIFT'||': '||s.shift||' , TIME :'||'( '||s.in_time||' - '||s.out_time||' )',e.emp_code from employee_master e,time_tab s where e.shift_id=s.shift_id and e.department_id not in (154) and e.department_id in (select a.dep_id from department_mst a where a.dep_head=" & sf(0) & ") and e.emp_code>9999 and e.status_id=1 order by e.department_id ").Tables(0)
                    Else
                        dt3 = oh.ExecuteDataSet("select department_id from employee_master where emp_code=" & sf(0) & "").Tables(0)

                        dt1 = oh.ExecuteDataSet("select e.emp_code||'--'||e.emp_name||'    ---> '||'   SHIFT'||': '||s.shift||' , TIME :'||'( '||s.in_time||' - '||s.out_time||' )',e.emp_code from employee_master e,time_tab s where e.shift_id=s.shift_id and e.department_id not in (154) and e.department_id =" & dt3.Rows(0)(0) & " and e.emp_code>9999 and e.status_id=1 order by e.emp_code").Tables(0)
                    End If

                End If

                Me.Cmb_employ.DataSource = dt1
                Me.Cmb_employ.DataTextField = dt1.Columns(0).ColumnName
                Me.Cmb_employ.DataValueField = dt1.Columns(1).ColumnName
                Me.Cmb_employ.DataBind()
                If (fmid = 16) Then

                    dt3 = oh.ExecuteDataSet("select -1 as in_time, '-----Select-----' as sname from dual union all select t.shift_id, t.shift || ' --> ' || t.in_time || ' -- ' || t.out_time from time_tab t,time_tab_macare_nw m where t.shift_id=m.shift_id order by in_time").Tables(0)
                    Me.Cmb_shift.DataSource = dt3
                    Me.Cmb_shift.DataValueField = dt3.Columns(0).ColumnName
                    Me.Cmb_shift.DataTextField = dt3.Columns(1).ColumnName
                    Me.Cmb_shift.DataBind()
                    'Me.ddlShiftChange.Focus()
                Else
                    dt2 = oh.ExecuteDataSet("select shift||'--->'||'Time: '||'('||in_time||') To ('||out_time||')',shift_id from time_tab where shift_id not in (4,5) order by in_time").Tables(0)
                    Me.Cmb_shift.DataSource = dt2
                    Me.Cmb_shift.DataTextField = dt2.Columns(0).ColumnName
                    Me.Cmb_shift.DataValueField = dt2.Columns(1).ColumnName
                    Me.Cmb_shift.DataBind()
                    Me.Txt_effdt.Text = Format(CDate(Date.Today), "dd/MMM/yyyy")
                End If
            End If

        End If
    End Sub
    Protected Sub Cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_confirm.Click
        Dim script1 As New System.Text.StringBuilder
        Dim parameter(5) As OracleParameter
        parameter(0) = New OracleParameter("empid", OracleType.VarChar, 150)
        parameter(0).Direction = ParameterDirection.Input
        parameter(0).Value = Me.Cmb_employ.SelectedValue
        dt4 = oh.ExecuteDataSet("select department_id from employee_master where emp_code=" & Me.Cmb_employ.SelectedValue & "").Tables(0)

        parameter(1) = New OracleParameter("depid", OracleType.VarChar, 150)
        parameter(1).Direction = ParameterDirection.Input
        parameter(1).Value = dt4.Rows(0)(0)
        sf = Session("user_id").ToString.Split("!")
        parameter(2) = New OracleParameter("user", OracleType.VarChar, 150)
        parameter(2).Direction = ParameterDirection.Input
        parameter(2).Value = sf(0)
        parameter(3) = New OracleParameter("effdt", OracleType.VarChar, 150)
        parameter(3).Direction = ParameterDirection.Input
        parameter(3).Value = Me.Txt_effdt.Text
        parameter(4) = New OracleParameter("shift", OracleType.VarChar, 150)
        parameter(4).Direction = ParameterDirection.Input
        parameter(4).Value = Me.Cmb_shift.SelectedValue
        parameter(5) = New OracleParameter("msg", OracleType.VarChar, 150)
        parameter(5).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("hrm_change_shift", parameter)

        Dim message As String
        message = parameter(5).Value
        '---------------------------
        Try
            If message.StartsWith("SUCESSFULLY") = True Then
                If chkPerm.Checked = True Then
                    Dim dtSec As New DataTable
                    dtSec = oh.ExecuteDataSet("select count(*) from status_master t  where t.module_id = 120  and t.option_id = 1 and t.status_id=" & Me.Cmb_employ.SelectedValue & "").Tables(0)
                    If dtSec.Rows(0)(0) = 0 Then
                        oh.ExecuteNonQuery("insert into status_master(module_id , option_id , status_id , description) values (120,1," & Me.Cmb_employ.SelectedValue & ",'JEWEL SHIFT EXCEPTION EMPLOYEE CODE') ")
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
        '---------------------------
        script1.Append("   alert(' " & message & "');")
        script1.Append("window.open('change_shift_press.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_report.Click
        Dim script2 As New System.Text.StringBuilder
        If Me.Cmb_employ.SelectedValue = 0 Then

            script2.Append("alert('Please select an employee before clicking report');")
            script2.Append("window.open('change_shift_press.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", script2.ToString(), True)
            Exit Sub
        End If
        Dim script1 As New System.Text.StringBuilder
        dt4 = oh.ExecuteDataSet("select department_id from employee_master where emp_code=" & Me.Cmb_employ.SelectedValue & "").Tables(0)
        script1.Append("window.open('change_shift_press_report.aspx?&effdt=" & Me.Txt_effdt.Text & "&dep=" & dt4.Rows(0)(0) & "', 'WinC', 'width=620,height=480,toolbar=yes,location=no,directories=yes,status=no,menubar=yes, scrollbars=yes,resizable=yes,copyhistory=no');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
    End Sub
End Class

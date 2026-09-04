Imports System.Data
Imports System.Data.OracleClient
Partial Class leave_long_leaveaplln_Macom_6652e24f3947
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sc As String = "var cont_name;cont_name='" & Me.txt_dep.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var2", sc, True)
        Dim usr = Session("user_id").ToString.Split("!")
        Dim fr As Integer = session("firm_id")
        ' If Session("access_id") = 33 Then
        If Not IsPostBack Then

            Dim dt, dt1, dt2 As New DataTable


            If Request.QueryString.Get("l_id") = 1 Then
                dt1 = oh.ExecuteDataSet("select count(t.emp_id) from form_accessibility t where t.form_id=1403 and t.emp_id='" & usr(0) & "'").Tables(0)
                If dt1.Rows(0)(0) = 1 Then
                    '  Dim sql = "select e.emp_code, e.emp_code || '***' || emp_name from employee_master e,region_master r,branch_dtl_new b where e.status_id = 1 and e.BRANCH_ID=b.BRANCH_ID and b.reg_id=r.reg_id and r.rh_hr='" & usr(0) & "' and e.emp_code > 9999 order by emp_code"
                    Dim sql = "select e.emp_code, e.emp_code || '***' || emp_name  from employee_master e where e.status_id = 1 and e.emp_code in(select emp_code from employ_firm where firm_id=" & fr & ") order by emp_code"
                    dt = oh.ExecuteDataSet(sql).Tables(0)
                    Me.Panel1.Visible = False
                Else
                    Response.Redirect("../show_err.aspx")
                End If
                Me.Txt_todt.Visible = False
                Me.cmb_emp.DataSource = dt
                Me.cmb_emp.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_emp.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_emp.DataBind()
                Me.cmb_emp.ForeColor = Drawing.Color.DarkOrange
                fill()



            ElseIf Request.QueryString.Get("l_id") = 2 Then
                'ElseIf Request.QueryString.Get("l_id") = 2 Then
                '' dt2 = oh.ExecuteDataSet("select count(*) from employee_master e where e.EMP_CODE='" & usr(0) & "' and e.POST_ID=85 and e.department_id=70").Tables(0)
                dt2 = oh.ExecuteDataSet("select count(t.emp_id) from form_accessibility t where t.form_id=1403 and t.emp_id='" & usr(0) & "'").Tables(0)
                If dt2.Rows(0)(0) = 1 Then
                    Dim sql = "select e.emp_code, e.emp_code || '***' || e.emp_name  from employee_master e,employ_firm f where e.status_id in (6, 10) and e.emp_code=f.emp_code and f.firm_id= " & fr & " and e.emp_code > 9999 order by emp_code"
                    dt = oh.ExecuteDataSet(sql).Tables(0)
                    Me.CalendarExtender1.Enabled = False
                    Me.Panel1.Visible = True
                Else
                    Response.Redirect("../show_err.aspx")
                End If
                Me.cmb_emp.DataSource = dt
                Me.cmb_emp.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_emp.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_emp.DataBind()
                Me.cmb_emp.ForeColor = Drawing.Color.DarkOrange
                fill()
            End If
        End If

        'Else
        '    Response.Redirect("../show_err.aspx")
        'End If
        ' End If
    End Sub

    Protected Sub cmb_emp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        fill()
    End Sub
    Sub fill()
        Dim dt1, dt2 As New DataTable
        If Me.cmb_emp.Items.Count > 0 Then
            dt1 = oh.ExecuteDataSet("select a.emp_code,b.designation,c.dep_name,d.branch_name,e.post_name,a.status_id from employee_master a,designation_master b,department_mst c,branch_master d,post_mst e where a.designation_id=b.designation_id and a.department_id=c.dep_id and a.branch_id=d.branch_id and a.post_id=e.post_id and a.emp_code=" & Me.cmb_emp.SelectedValue).Tables(0)
            If dt1.Rows.Count > 0 Then
                Me.txt_dep.Text = dt1.Rows(0)(2)
                Me.txt_desig.Text = dt1.Rows(0)(1)
                Me.txt_loc.Text = dt1.Rows(0)(3)
                Me.txt_post.Text = dt1.Rows(0)(4)
                Me.txt_dep.ForeColor = Drawing.Color.DarkOrange
                Me.txt_desig.ForeColor = Drawing.Color.DarkOrange
                Me.txt_loc.ForeColor = Drawing.Color.DarkOrange
                Me.txt_post.ForeColor = Drawing.Color.DarkOrange
            End If
            Me.txt_dep.ReadOnly = True
            Me.txt_desig.ReadOnly = True
            Me.txt_loc.ReadOnly = True
            Me.txt_post.ReadOnly = True
            If Request.QueryString.Get("l_id") = 2 Then
                Dim sql = "select a.from_dt,a.remarks from employ_transfer_dtl a where to_dt is null and a.status_id =" & dt1.Rows(0)(5) & " and emp_code=" & dt1.Rows(0)(0)
                dt2 = oh.ExecuteDataSet(sql).Tables(0)
                If dt1.Rows(0)(5) = 6 Then
                    Me.chk_lngleave.Checked = True
                    Me.chk_maternity.Checked = False
                    Me.chk_lngleave.Enabled = False
                    Me.chk_maternity.Enabled = False
                Else
                    Me.chk_maternity.Checked = True
                    Me.chk_lngleave.Checked = False
                    Me.chk_lngleave.Enabled = False
                    Me.chk_maternity.Enabled = False
                End If
                If dt2.Rows.Count > 0 Then
                    Me.txt_fromdt.Text = Format(CDate(dt2.Rows(0)(0)), "dd/MMM/yyyy")
                    If IsDBNull(dt2.Rows(0)(1)) Then
                        Me.txt_remarks.Text = ""
                    Else
                        Me.txt_remarks.Text = dt2.Rows(0)(1)
                    End If
                    Me.txt_fromdt.ReadOnly = True
                    Me.txt_remarks.ReadOnly = True
                    Me.txt_fromdt.ForeColor = Drawing.Color.DarkOrange
                    Me.txt_remarks.ForeColor = Drawing.Color.DarkOrange
                Else
                    Me.txt_fromdt.ReadOnly = True
                    Me.txt_remarks.ReadOnly = True
                End If
            End If
        Else
            Me.txt_dep.Text = ""
            Me.txt_desig.Text = ""
            Me.txt_loc.Text = ""
            Me.txt_post.Text = ""
        End If
    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click

        'Code to check any LOP already added withing the long leave date selection. between start date and current date.
        If CInt(Request.QueryString.Get("l_id")) = 1 Then
            Dim flag As Boolean = False
            Dim dtCheck, dtLeave As New DataTable
            Dim chkdt As String
            Dim r As Integer = 0

            Dim sql = "SELECT to_date(TO_DATE('" & txt_fromdt.Text & "') - 1) + rownum AS dt_range  FROM all_objects  WHERE to_date(TO_DATE('" & txt_fromdt.Text & "')-1) + rownum < = TO_DATE(sysdate)"
            dtCheck = oh.ExecuteDataSet(sql).Tables(0)
            While r < dtCheck.Rows.Count
                chkdt = Format(CDate(dtCheck.Rows(r)(0)), "dd/MMM/yyyy")
                sql = "select nvl(count(t.emp_code),0) from employ_leave_dtl t where t.emp_code=" & cmb_emp.SelectedValue & " and to_date('" & chkdt & "') between t.leave_frdate and t.leave_todate and t.leave_process_id in (1)"
                dtLeave = oh.ExecuteDataSet(sql).Tables(0)
                If dtLeave.Rows(0)(0) > 0 Then
                    flag = True
                    Exit While
                End If
                r = r + 1
            End While

            If flag = True Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('Unable to process your request. Please clear any leave assigned within the selected date.');", True)
                Exit Sub
            End If
        End If
        '------------------------------------------------------
        Dim dt, dt1 As New Date
        Dim cn As New Integer
        dt = Me.txt_fromdt.Text
        cn = DateDiff(DateInterval.Day, dt, Date.Today)
        If cn > 365 Then
            Me.Label1.Text = "<font size=3 color=red><b>One year Back date is not Allowed</b></font>"
            Return
        End If
        If cn < -365 Then
            Me.Label1.Text = "<font size=3 color=red><b>One year future date is not Allowed</b></font>"
            Return
        End If
        Try
            If CDate(Me.txt_fromdt.Text) > Date.Now Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("         alert(' Future date cannot be selected as From Date');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

                'ElseIf CDate(Me.txt_returndt.Text) > Date.Now Then
                '    Dim cl_script1 As New System.Text.StringBuilder
                '    cl_script1.Append("         alert(' Invalid Return Date');")
                '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Else
                Dim op(10) As OracleParameter
                op(0) = New OracleParameter("l_id", OracleType.VarChar, 5)
                op(0).Value = CInt(Request.QueryString.Get("l_id"))
                op(0).Direction = ParameterDirection.Input

                op(1) = New OracleParameter("empcode", OracleType.VarChar, 15)
                op(1).Value = CInt(Me.cmb_emp.SelectedValue)
                op(1).Direction = ParameterDirection.Input

                op(2) = New OracleParameter("frm_dt", OracleType.DateTime)
                op(2).Value = DateTime.Parse(Me.txt_fromdt.Text)
                op(2).Direction = ParameterDirection.Input

                op(3) = New OracleParameter("st_id", OracleType.Number, 3)
                If Me.chk_lngleave.Checked = True Then
                    op(3).Value = 6
                ElseIf Me.chk_maternity.Checked = True Then
                    op(3).Value = 10
                Else
                    op(3).Value = 0
                End If
                op(3).Direction = ParameterDirection.Input
                op(4) = New OracleParameter("remark", OracleType.VarChar, 250)
                If Me.txt_remarks.Text = "" Then
                    op(4).Value = ""
                Else
                    op(4).Value = Me.txt_remarks.Text
                End If
                op(4).Direction = ParameterDirection.Input
                op(5) = New OracleParameter("retn_dt", OracleType.DateTime)


                If CInt(Request.QueryString.Get("l_id")) = 2 Then
                    op(5).Value = Me.txt_returndt.Text
                Else
                    op(5).Value = CDate("15-AUG-1947")
                End If
                If op(5).Value <> CDate("15-AUG-1947") Then
                    dt1 = op(5).Value
                    cn = DateDiff(DateInterval.Day, dt1, dt)
                    If cn >= 0 Then
                        Me.Label1.Text = "<font size=3 color=red><b>Return date is not less than or equal to Entered Date</b></font>"
                        Return
                    End If
                    dt = Me.txt_returndt.Text
                    cn = DateDiff(DateInterval.Day, dt, Date.Today)
                    If cn > 365 Then
                        Me.Label1.Text = "<font size=3 color=red><b>One year Back date is not Allowed</b></font>"
                        Return
                    End If
                    If cn < -365 Then
                        Me.Label1.Text = "<font size=3 color=red><b>One year future date is not Allowed</b></font>"
                        Return
                    End If
                End If
                op(5).Direction = ParameterDirection.Input

                op(6) = New OracleParameter("userid", OracleType.VarChar, 25)
                op(6).Value = Session("user_id")
                op(6).Direction = ParameterDirection.Input

                op(7) = New OracleParameter("flag", OracleType.Number, 3)
                op(7).Direction = ParameterDirection.Output

                op(8) = New OracleParameter("msg", OracleType.VarChar, 200)
                op(8).Direction = ParameterDirection.Output

                ' Add work from Home
                op(9) = New OracleParameter("wrk_sta", OracleType.Number, 3)
                If Me.Chkaddwork.Checked = True Then
                    op(9).Value = 2
                ElseIf Me.Chkdltwrk.Checked = True Then
                    op(9).Value = 1
                Else
                    op(9).Value = 0
                End If
                op(9).Direction = ParameterDirection.Input
                'op(9).Value = Session("wrk_sta")

                op(10) = New OracleParameter("to_dat", OracleType.DateTime)
                If Me.Chkaddwork.Checked = True Then
                    op(10).Value = CDate("15-AUG-1947")
                ElseIf Me.Chkdltwrk.Checked = True Then
                    op(10).Value = DateTime.Parse(Me.Txt_todt.Text)
                Else
                    op(10).Value = CDate("15-AUG-1947")
                End If
                'op(10).Value = CDate(Me.Txt_todt.Text)
                op(10).Direction = ParameterDirection.Input


                oh.ExecuteNonQuery("long_leaveappln_macom", op)
                Dim s As String
                s = op(8).Value.ToString()
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("                                                             alert('" & op(8).Value & "');")

                If op(7).Value = 1 Then
                    cl_script0.Append("window.open('../home.aspx','_self');")
                End If
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
            End If
        Catch ex As Exception
            Dim s As String = ex.ToString()
        End Try





    End Sub

    Protected Sub cmd_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_exit.Click
        Response.Redirect("../home.aspx")
    End Sub

    Protected Sub Chkdltwrk_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chkdltwrk.CheckedChanged
        If (Me.Chkdltwrk.Checked = True) Then
            Me.Txt_todt.Visible = True
            Me.Chkaddwork.Checked = False
            Me.chk_maternity.Checked = False
            Me.chk_lngleave.Checked = False

        Else
            Me.Txt_todt.Visible = False
            Me.Chkaddwork.Checked = True
            Me.chk_maternity.Checked = True
            Me.chk_lngleave.Checked = True
        End If

    End Sub

    Protected Sub Chkaddwork_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chkaddwork.CheckedChanged

        If (Me.Chkaddwork.Checked = True) Then
            Me.Chkdltwrk.Checked = False
            Me.chk_maternity.Checked = False
            Me.chk_lngleave.Checked = False
        Else
            Me.Chkdltwrk.Checked = True
            Me.chk_maternity.Checked = True
            Me.chk_lngleave.Checked = True
        End If

    End Sub

    Protected Sub chk_lngleave_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_lngleave.CheckedChanged

        If (Me.chk_lngleave.Checked = True) Then
            Me.Chkdltwrk.Checked = False
            Me.chk_maternity.Checked = False
            Me.Chkaddwork.Checked = False
        Else
            Me.Chkdltwrk.Checked = True
            Me.chk_maternity.Checked = True
            Me.Chkaddwork.Checked = True
        End If

    End Sub

    Protected Sub chk_maternity_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_maternity.CheckedChanged

        If (Me.chk_maternity.Checked = True) Then
            Me.Chkdltwrk.Checked = False
            Me.chk_lngleave.Checked = False
            Me.Chkaddwork.Checked = False
        Else
            Me.Chkdltwrk.Checked = True
            Me.chk_lngleave.Checked = True
            Me.Chkaddwork.Checked = True
        End If

    End Sub
End Class

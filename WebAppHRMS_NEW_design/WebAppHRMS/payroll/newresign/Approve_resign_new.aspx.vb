Imports System.Data
Imports System.Data.OracleClient
Partial Class New_folder__3_Approve_resign_new_723f2d942842
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2, dt3, dtq As New DataTable
    Dim UserAll(), res, sql, str As String
    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Dim usr() As String

        usr = Me.Session("user_id").ToString.Split("!")


        If Me.Text_remar.Text = "" Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("        alert('Please Enter Remarks!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Exit Sub
        End If




        Dim parameter(4) As OracleParameter
        parameter(0) = New OracleParameter("code", OracleType.Number, 150)
        parameter(0).Direction = ParameterDirection.Input
        parameter(0).Value = Me.lbl_code.Text
        parameter(1) = New OracleParameter("usr", OracleType.Number, 150)
        parameter(1).Direction = ParameterDirection.Input
        parameter(1).Value = usr(0)
        parameter(2) = New OracleParameter("ubr", OracleType.Number, 150)
        parameter(2).Direction = ParameterDirection.Input
        parameter(2).Value = Session("branch_id")

        parameter(3) = New OracleParameter("apprrem", OracleType.VarChar, 150)
        parameter(3).Direction = ParameterDirection.Input
        parameter(3).Value = Me.Text_remar.Text

        parameter(4) = New OracleParameter("msg", OracleType.Number, 150)
        parameter(4).Direction = ParameterDirection.Output



        oh.ExecuteNonQuery("M_RESIGNING_APPR_MAB", parameter)


        If parameter(4).Value = 1 Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("        alert('Confirmed successfully!!');")
            cl_script1.Append("window.open('../../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Exit Sub
            ' Server.Transfer("Approve_resign.aspx")
        End If
        If parameter(4).Value = 2 Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("        alert('No Such application Exist for Cancellation!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Exit Sub
        End If
        If parameter(4).Value = 3 Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("        alert('Error ...Contact IT Department...!!');")
            ' cl_script1.Append("window.open('cancel_resign.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Exit Sub
        End If

        'Server.Transfer("cancel_resign.aspx")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim frm As Integer = Session("firm_id")
            If frm = 2 And Session("branch_id") <> 0 Then
                Server.Transfer("../../show_err.aspx")
                Exit Sub
            End If
            Dim usr() As String
            Dim sql As String
            usr = Me.Session("user_id").ToString.Split("!")

            '--'

            Dim user_id() As String = Session("user_id").ToString.Split("!")
            sql = "select count(t.emp_id) from form_accessibility t where t.form_id=855  and t.emp_id='" & user_id(0) & "' "
            dtq = oh.ExecuteDataSet(sql).Tables(0)
            If dtq.Rows(0)(0) = 0 Then
                Dim script_val1 As New StringBuilder
                script_val1.Append("         alert('You Not Authorized To View This Page !!');")
                script_val1.Append("         window.open('../../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script_val1.ToString, True)
                Exit Sub
            End If
            '--'



            Dim dt As DataTable = oh.ExecuteDataSet("select post_id,branch_id from employee_master where emp_code=" & usr(0) & " and status_id=1  union all  select 0,count(f.emp_id)from form_accessibility f where f.form_id=1305  and f.emp_id=" & usr(0) & " ").Tables(0)
            Dim dt1s As DataTable = oh.ExecuteDataSet("select f.firm_id, em.branch_id,(select stat from photo_stat where module_id=2)block_stat from employ_firm f, employee_master em where em.emp_code = f.emp_code and em.emp_code = " & usr(0) & "").Tables(0)
            Dim ff As Integer = Session("firm_id")
            If dt1s.Rows(0)(0) = 2 And dt1s.Rows(0)(1) <> 0 And dt1s.Rows(0)(2) = 1 Then
                Server.Transfer("../../show_err.aspx")
                Exit Sub
            End If

            'nw for ceo appr

            If dt.Rows(0)(0) = 378 Then

                sql = "select r.emp_code || ' --- ' || e.emp_name || ' --- Branch: ' || b.branch_name, e.emp_code from m_resign_appl r, employee_master e, branch b, employ_firm f where e.emp_code = r.emp_code and e.EMP_CODE = f.emp_code and f.firm_id = " & ff & " and e.branch_id = b.branch_id and r.status in (0) and  e.post_id in 195 and e.status_id = 1 order by emp_code"
                dt = oh.ExecuteDataSet(sql).Tables(0)
                Me.cmb_emp.DataSource = dt
                Me.cmb_emp.DataTextField = dt.Columns(0).ColumnName
                Me.cmb_emp.DataValueField = dt.Columns(1).ColumnName
                Me.cmb_emp.DataBind()
                If dt.Rows.Count > 0 Then
                    Dim dt1 As DataTable = oh.ExecuteDataSet("select emp_code,emp_name from employee_master where emp_code=" & Me.cmb_emp.SelectedValue & " and status_id=1 ").Tables(0)
                    Dim dt2 As DataTable = oh.ExecuteDataSet("select r.resign_dt,u.categ||' -- '||w.college_nm||' , '||w.course||' , '||w.durtion as reason,to_date(r.relieve_dt) from m_resign_appl r,resign_reason_mst u,resign_higherstudies_reason w where  r.emp_code=" & Me.cmb_emp.SelectedValue & " and r.reason=u.categ_id and w.emp_code=r.emp_code and to_date(r.resign_dt)=to_date(w.tra_dt) and w.status=r.status and r.status in (0) union select r.resign_dt,u.categ||' -- '||q.reason as reason,to_date(r.relieve_dt) from m_resign_appl r,resign_reason_mst u,resign_personal_reason q where u.categ_id=r.reason and r.emp_code=" & Me.cmb_emp.SelectedValue & " and q.emp_code=r.emp_code and to_date(r.resign_dt)=to_date(q.tra_dt) and q.status=r.status and r.status in (0) union select r.resign_dt,u.categ||' -- '||q1.firm||' , '||q1.reason||' , '||q1.nature_work||' , '||q1.salary as reason,to_date(r.relieve_dt) from m_resign_appl r,resign_reason_mst u,resign_otheremploy_reason q1 where  r.emp_code=" & Me.cmb_emp.SelectedValue & " and r.reason=u.categ_id and q1.emp_code=r.emp_code and to_date(r.resign_dt)=to_date(q1.tra_dt) and q1.status=r.status and r.status in (0) union select r.resign_dt,u.categ||' -- '||q.reason as reason,to_date(r.relieve_dt) from m_resign_appl r,resign_reason_mst u,resign_personal_reason q where  r.emp_code=" & Me.cmb_emp.SelectedValue & " and u.categ_id=r.reason and q.emp_code=r.emp_code and to_date(r.resign_dt)=to_date(q.tra_dt) and q.status=r.status and r.status in (0) union select r.resign_dt,u.categ||' -- '||q2.partner_name||' , '||q2.job_partner||' , '||q2.place_marriage as reason,to_date(r.relieve_dt) from m_resign_appl r,resign_reason_mst u,resign_marriage_reason q2 where  r.emp_code=" & Me.cmb_emp.SelectedValue & " and r.reason=u.categ_id and q2.emp_code=r.emp_code and to_date(r.resign_dt)=to_date(q2.tra_dt) and q2.status=r.status and r.status in (1,0) union select r.resign_dt,u.categ||' -- '||q3.reason as reason,to_date(r.relieve_dt) from m_resign_appl r,resign_reason_mst u,resign_other_reason q3 where  r.emp_code=" & Me.cmb_emp.SelectedValue & " and u.categ_id=r.reason and q3.emp_code=r.emp_code and to_date(r.resign_dt)=to_date(q3.tra_dt) and q3.status=r.status and r.status in (0) ").Tables(0)
                    Me.lbl_code.Text = dt1.Rows(0)(0)
                    Me.lbl_name.Text = dt1.Rows(0)(1)
                    Me.Txt_rsdt.Text = Format(CDate(dt2.Rows(0)(0)), "dd/MMM/yyyy")
                    Me.Txt_rdt.Text = Format(CDate(dt2.Rows(0)(0)), "dd/MMM/yyyy")

                    'If IsDBNull(dt2.Rows(0)(2)) Then
                    '    Me.Txt_rdt.Text = ""
                    'Else
                    '    Me.Txt_rdt.Text = Format(CDate(dt2.Rows(0)(2)), "dd/MMM/yyyy")
                    'End If
                    ' Me.Txt_rdt.Text = Format(CDate(dt2.Rows(0)(2)), "dd/MMM/yyyy")
                    If IsDBNull(dt2.Rows(0)(1)) Then

                        Me.Txt_rea.Text = " "
                    Else
                        Me.Txt_rea.Text = dt2.Rows(0)(1)
                    End If
                Else
                    Dim cl_script11 As New System.Text.StringBuilder
                    cl_script11.Append("        alert('No Employees Found...!!');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script11.ToString, True)
                End If


                '


            ElseIf dt.Rows(0)(0) = 85 Or dt.Rows(0)(0) = 195 Or dt.Rows(1)(1) = 1 Then

                sql = "select r.emp_code || ' --- ' || e.emp_name || ' --- Branch: ' || b.branch_name, e.emp_code from m_resign_appl r, employee_master e, branch b, employ_firm f where e.emp_code = r.emp_code and e.EMP_CODE = f.emp_code and f.firm_id = " & ff & " and e.branch_id = b.branch_id and r.status in (0) and e.post_id not in 195 and e.status_id = 1 order by emp_code"
                dt = oh.ExecuteDataSet(sql).Tables(0)
                Me.cmb_emp.DataSource = dt
                Me.cmb_emp.DataTextField = dt.Columns(0).ColumnName
                Me.cmb_emp.DataValueField = dt.Columns(1).ColumnName
                Me.cmb_emp.DataBind()
                If dt.Rows.Count > 0 Then
                    Dim dt1 As DataTable = oh.ExecuteDataSet("select emp_code,emp_name from employee_master where emp_code=" & Me.cmb_emp.SelectedValue & " and status_id=1 ").Tables(0)
                    Dim dt2 As DataTable = oh.ExecuteDataSet("select r.resign_dt,u.categ||' -- '||w.college_nm||' , '||w.course||' , '||w.durtion as reason,to_date(r.relieve_dt) from m_resign_appl r,resign_reason_mst u,resign_higherstudies_reason w where  r.emp_code=" & Me.cmb_emp.SelectedValue & " and r.reason=u.categ_id and w.emp_code=r.emp_code and to_date(r.resign_dt)=to_date(w.tra_dt) and w.status=r.status and r.status in (0) union select r.resign_dt,u.categ||' -- '||q.reason as reason,to_date(r.relieve_dt) from m_resign_appl r,resign_reason_mst u,resign_personal_reason q where u.categ_id=r.reason and r.emp_code=" & Me.cmb_emp.SelectedValue & " and q.emp_code=r.emp_code and to_date(r.resign_dt)=to_date(q.tra_dt) and q.status=r.status and r.status in (0) union select r.resign_dt,u.categ||' -- '||q1.firm||' , '||q1.reason||' , '||q1.nature_work||' , '||q1.salary as reason,to_date(r.relieve_dt) from m_resign_appl r,resign_reason_mst u,resign_otheremploy_reason q1 where  r.emp_code=" & Me.cmb_emp.SelectedValue & " and r.reason=u.categ_id and q1.emp_code=r.emp_code and to_date(r.resign_dt)=to_date(q1.tra_dt) and q1.status=r.status and r.status in (0) union select r.resign_dt,u.categ||' -- '||q.reason as reason,to_date(r.relieve_dt) from m_resign_appl r,resign_reason_mst u,resign_personal_reason q where  r.emp_code=" & Me.cmb_emp.SelectedValue & " and u.categ_id=r.reason and q.emp_code=r.emp_code and to_date(r.resign_dt)=to_date(q.tra_dt) and q.status=r.status and r.status in (0) union select r.resign_dt,u.categ||' -- '||q2.partner_name||' , '||q2.job_partner||' , '||q2.place_marriage as reason,to_date(r.relieve_dt) from m_resign_appl r,resign_reason_mst u,resign_marriage_reason q2 where  r.emp_code=" & Me.cmb_emp.SelectedValue & " and r.reason=u.categ_id and q2.emp_code=r.emp_code and to_date(r.resign_dt)=to_date(q2.tra_dt) and q2.status=r.status and r.status in (1,0) union select r.resign_dt,u.categ||' -- '||q3.reason as reason,to_date(r.relieve_dt) from m_resign_appl r,resign_reason_mst u,resign_other_reason q3 where  r.emp_code=" & Me.cmb_emp.SelectedValue & " and u.categ_id=r.reason and q3.emp_code=r.emp_code and to_date(r.resign_dt)=to_date(q3.tra_dt) and q3.status=r.status and r.status in (0) ").Tables(0)
                    Me.lbl_code.Text = dt1.Rows(0)(0)
                    Me.lbl_name.Text = dt1.Rows(0)(1)
                    Me.Txt_rsdt.Text = Format(CDate(dt2.Rows(0)(0)), "dd/MMM/yyyy")
                    Me.Txt_rdt.Text = Format(CDate(dt2.Rows(0)(0)), "dd/MMM/yyyy")

                    'If IsDBNull(dt2.Rows(0)(2)) Then
                    '    Me.Txt_rdt.Text = ""
                    'Else
                    '    Me.Txt_rdt.Text = Format(CDate(dt2.Rows(0)(2)), "dd/MMM/yyyy")
                    'End If
                    ' Me.Txt_rdt.Text = Format(CDate(dt2.Rows(0)(2)), "dd/MMM/yyyy")
                    If IsDBNull(dt2.Rows(0)(1)) Then

                        Me.Txt_rea.Text = " "
                    Else
                        Me.Txt_rea.Text = dt2.Rows(0)(1)
                    End If
                Else
                    Dim cl_script11 As New System.Text.StringBuilder
                    cl_script11.Append("        alert('No Employees Found...!!');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script11.ToString, True)
                    Exit Sub
                End If

            Else

                Dim dt4 As DataTable = oh.ExecuteDataSet("select post_id,branch_id from employee_master where emp_code=" & usr(0) & " and status_id=1 ").Tables(0)

                If dt4.Rows.Count > 0 Then
                    sql = "select r.emp_code||' --- '||e.emp_name||'  ---  Branch: '||b.branch_name,e.emp_code from m_resign_appl r,employee_master e,branch b,employ_firm f where e.emp_code=f.emp_code and f.firm_id=" & ff & " and e.emp_code=r.emp_code and e.emp_code=" & usr(0) & " and e.branch_id=b.branch_id and r.status in (0) and e.post_id not in 195 and e.status_id=1 order by emp_code"
                    dt = oh.ExecuteDataSet(sql).Tables(0)
                    Me.cmb_emp.DataSource = dt
                    Me.cmb_emp.DataTextField = dt.Columns(0).ColumnName
                    Me.cmb_emp.DataValueField = dt.Columns(1).ColumnName
                    Me.cmb_emp.DataBind()
                    If dt.Rows.Count > 0 Then
                        Dim dt1 As DataTable = oh.ExecuteDataSet("select emp_code,emp_name from employee_master where emp_code=" & Me.cmb_emp.SelectedValue & " and status_id=1 ").Tables(0)
                        Dim dt2 As DataTable = oh.ExecuteDataSet("select to_date(r.resign_dt),u.categ||' -- '||w.college_nm||' , '||w.course||' , '||w.durtion as reason,to_date(r.relieve_dt) from m_resign_appl r,resign_reason_mst u,resign_higherstudies_reason w where  r.emp_code=" & Me.cmb_emp.SelectedValue & " and r.reason=u.categ_id and w.emp_code=r.emp_code and to_date(r.resign_dt)=to_date(w.tra_dt) and w.status=r.status and r.status in (0) union select to_date(r.resign_dt),u.categ||' -- '||q.reason as reason,to_date(r.relieve_dt) from m_resign_appl r,resign_reason_mst u,resign_personal_reason q where u.categ_id=r.reason and r.emp_code=" & Me.cmb_emp.SelectedValue & " and q.emp_code=r.emp_code and to_date(r.resign_dt)=to_date(q.tra_dt) and q.status=r.status and r.status in (0) union select to_date(r.resign_dt),u.categ||' -- '||q1.firm||' , '||q1.reason||' , '||q1.nature_work||' , '||q1.salary as reason,to_date(r.relieve_dt) from m_resign_appl r,resign_reason_mst u,resign_otheremploy_reason q1 where  r.emp_code=" & Me.cmb_emp.SelectedValue & " and r.reason=u.categ_id and q1.emp_code=r.emp_code and to_date(r.resign_dt)=to_date(q1.tra_dt) and q1.status=r.status and r.status in (0) union select to_date(r.resign_dt),u.categ||' -- '||q.reason as reason,to_date(r.relieve_dt) from m_resign_appl r,resign_reason_mst u,resign_personal_reason q where  r.emp_code=" & Me.cmb_emp.SelectedValue & " and u.categ_id=r.reason and q.emp_code=r.emp_code and to_date(r.resign_dt)=to_date(q.tra_dt) and q.status=r.status and r.status in (0) union select to_date(r.resign_dt),u.categ||' -- '||q2.partner_name||' , '||q2.job_partner||' , '||q2.place_marriage as reason,to_date(r.relieve_dt) from m_resign_appl r,resign_reason_mst u,resign_marriage_reason q2 where  r.emp_code=" & Me.cmb_emp.SelectedValue & " and r.reason=u.categ_id and q2.emp_code=r.emp_code and to_date(r.resign_dt)=to_date(q2.tra_dt) and q2.status=r.status and r.status in (0) union select to_date(r.resign_dt),u.categ||' -- '||q3.reason as reason,to_date(r.relieve_dt) from m_resign_appl r,resign_reason_mst u,resign_other_reason q3 where  r.emp_code=" & Me.cmb_emp.SelectedValue & " and u.categ_id=r.reason and q3.emp_code=r.emp_code and to_date(r.resign_dt)=to_date(q3.tra_dt) and q3.status=r.status and r.status in (0) ").Tables(0)
                        Me.lbl_code.Text = dt1.Rows(0)(0)
                        Me.lbl_name.Text = dt1.Rows(0)(1)
                        Me.Txt_rsdt.Text = Format(CDate(dt2.Rows(0)(0)), "dd/MMM/yyyy")
                        Me.Txt_rdt.Text = Format(CDate(dt2.Rows(0)(0)), "dd/MMM/yyyy")

                        'If IsDBNull(dt2.Rows(0)(2)) Then
                        '    Me.Txt_rdt.Text = ""
                        'Else
                        '    Me.Txt_rdt.Text = Format(CDate(dt2.Rows(0)(2)), "dd/MMM/yyyy")
                        'End If

                        If IsDBNull(dt2.Rows(0)(1)) Then
                            Me.Txt_rea.Text = " "
                        Else
                            Me.Txt_rea.Text = dt2.Rows(0)(1)
                        End If
                    Else
                        Dim cl_script11 As New System.Text.StringBuilder
                        cl_script11.Append("        alert('No Employees Found...!!');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script11.ToString, True)
                        Exit Sub

                    End If

                Else
                    Server.Transfer("../../show_err.aspx")

                End If
            End If

        End If




    End Sub

    Protected Sub cmb_emp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_emp.SelectedIndexChanged

        Dim dt1 As DataTable = oh.ExecuteDataSet("select emp_code,emp_name from employee_master where emp_code=" & Me.cmb_emp.SelectedValue & " and status_id=1 ").Tables(0)
        Dim dt2 As DataTable = oh.ExecuteDataSet("select to_date(r.resign_dt),u.categ||' -- '||w.college_nm||' , '||w.course||' , '||w.durtion as reason,to_date(r.relieve_dt) from m_resign_appl r,resign_reason_mst u,resign_higherstudies_reason w where  r.emp_code=" & Me.cmb_emp.SelectedValue & " and r.reason=u.categ_id and w.emp_code=r.emp_code and to_date(r.resign_dt)=to_date(w.tra_dt) and w.status=r.status and r.status in (0) union select to_date(r.resign_dt),u.categ||' -- '||q.reason as reason,to_date(r.relieve_dt) from m_resign_appl r,resign_reason_mst u,resign_personal_reason q where u.categ_id=r.reason and r.emp_code=" & Me.cmb_emp.SelectedValue & " and q.emp_code=r.emp_code and to_date(r.resign_dt)=to_date(q.tra_dt) and q.status=r.status and r.status in (0) union select to_date(r.resign_dt),u.categ||' -- '||q1.firm||' , '||q1.reason||' , '||q1.nature_work||' , '||q1.salary as reason,to_date(r.relieve_dt) from m_resign_appl r,resign_reason_mst u,resign_otheremploy_reason q1 where  r.emp_code=" & Me.cmb_emp.SelectedValue & " and r.reason=u.categ_id and q1.emp_code=r.emp_code and to_date(r.resign_dt)=to_date(q1.tra_dt) and q1.status=r.status and r.status in (0) union select to_date(r.resign_dt),u.categ||' -- '||q.reason as reason,to_date(r.relieve_dt) from m_resign_appl r,resign_reason_mst u,resign_personal_reason q where  r.emp_code=" & Me.cmb_emp.SelectedValue & " and u.categ_id=r.reason and q.emp_code=r.emp_code and to_date(r.resign_dt)=to_date(q.tra_dt) and q.status=r.status and r.status in (0) union select to_date(r.resign_dt),u.categ||' -- '||q2.partner_name||' , '||q2.job_partner||' , '||q2.place_marriage as reason,to_date(r.relieve_dt) from m_resign_appl r,resign_reason_mst u,resign_marriage_reason q2 where  r.emp_code=" & Me.cmb_emp.SelectedValue & " and r.reason=u.categ_id and q2.emp_code=r.emp_code and to_date(r.resign_dt)=to_date(q2.tra_dt) and q2.status=r.status and r.status in (0) union select to_date(r.resign_dt),u.categ||' -- '||q3.reason as reason,to_date(r.relieve_dt) from m_resign_appl r,resign_reason_mst u,resign_other_reason q3 where  r.emp_code=" & Me.cmb_emp.SelectedValue & " and u.categ_id=r.reason and q3.emp_code=r.emp_code and to_date(r.resign_dt)=to_date(q3.tra_dt) and q3.status=r.status and r.status in (0) ").Tables(0)
        Me.lbl_code.Text = dt1.Rows(0)(0)
        Me.lbl_name.Text = dt1.Rows(0)(1)
        Me.Txt_rsdt.Text = Format(CDate(dt2.Rows(0)(0)), "dd/MMM/yyyy")
        Me.Txt_rdt.Text = Format(CDate(dt2.Rows(0)(0)), "dd/MMM/yyyy")

        'If IsDBNull(dt2.Rows(0)(2)) Then
        '    Me.Txt_rdt.Text = ""
        'Else
        '    Me.Txt_rdt.Text = Format(CDate(dt2.Rows(0)(2)), "dd/MMM/yyyy")
        'End If

        If IsDBNull(dt2.Rows(0)(1)) Then

            Me.Txt_rea.Text = " "
        Else
            Me.Txt_rea.Text = dt2.Rows(0)(1)
        End If
    End Sub


End Class



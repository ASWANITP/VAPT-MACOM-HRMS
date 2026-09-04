Imports system
Imports System.Data
Imports System.Data.OracleClient
Partial Class Sunday_lopCancellationRequest_78fdc6344226
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim dt, dtl, dtn, dtn1, dt2, dt3, st As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dts1, dts2, dtpri, dtrs, Data As New DataTable
    Dim UserAll(), UserCode As String
    Dim str_tkn As New StringBuilder
    Dim cat As Integer
    Dim str As String
    Dim dr, dr1, dr11, dr111 As DataRow
    Dim usr() As String
    Dim firmid As Integer
    Dim branchid As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim script_val As String
        Me.emp_type.Value = 1
        script_val = "var header;" & "header='" & Me.ddl_lop.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function call_server (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "call_server", cbscript, True)
        Me.ddl_lop.Attributes.Add("onchange", "early_goingOnchange()")
        'Dim usr() As String = Session("user_id").ToString.Split("!")
        usr = Me.Session("user_id").ToString.Split("!")
        Me.hid_user.Value = usr(0)
        Dim ddl_lop As New DataTable

        'If Me.chk_rec.Checked = False Then
        '    Me.chk_rec.Checked = False
        '    Me.chk_app.Checked = True
        '    Me.cmd_rec.Visible = False
        '    Me.cmd_app.Visible = True

        'End If
        ''---------------------------
        'Try
        '    firmid = Convert.ToInt32(Me.Session("firm_id"))
        '    branchid = Me.Session("branch_id")
        '    Dim Sql As String
        '    If firmid = 24 Then
        '        Sql = "select nvl(t.branch_id,'NULL') branch ,t.block_all from hrm_block_leave_frm t where t.firm_id=24 and t.block_opt='SANCTION'"
        '        Dim dtCheck As New DataTable
        '        Dim branch As String
        '        dtCheck = oh.ExecuteDataSet(Sql).Tables(0)
        '        branch = dtCheck.Rows(0)(0)
        '        Dim flag As Boolean = False
        '        If dtCheck.Rows.Count > 0 Then
        '            If dtCheck.Rows(0)(1) = "Y" Then
        '                flag = True
        '            End If
        '            If branch <> "NULL" Then
        '                Dim ar() = branch.Split(",")
        '                Dim index As Integer
        '                For index = 0 To ar.Length - 1
        '                    If Val(ar(index)) = branchid Then
        '                        flag = True
        '                        Exit For
        '                    End If
        '                Next
        '            End If

        '            If flag = True Then
        '                Dim cl_script As New StringBuilder
        '                cl_script.Append("   alert('Leave Entry BLOCKED from HO') ;")
        '                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "BLOCKLEAVE", cl_script.ToString, True)
        'chk_rec.Checked = False
        'chk_rec.Enabled = False
        'chk_app.Checked = False
        'chk_app.Enabled = False

        '                Return
        '            End If
        '        End If
        '    End If
        'Catch ex As System.Exception
        'End Try
        ''---------------------------





        If Not IsPostBack Then


            '    '.....................................................................

            Dim dtt1, dtt2, dtt3, dtt4, dtt5 As New DataTable
            Dim dtt11, dtt12, dtt13, dtt15 As New DataTable


            Me.cmd_rec.Visible = True

            Me.cmd_app.Visible = False


            '    'dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Worked Date - Cancellation date' as empname from dual union select ca.empcode || '*' || ca.comp_id,ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' ||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master  t,othleave_sanction_authority a where t.emp_code = ca.emp_code and t.emp_code = a.emp_id and a.c_recby =" & usr(0) & "  and ca.comp_id = cm.comp_id and ca.status_id in (0)").Tables(0)

            dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code -Employee Name- Worked Date - Cancellation date' as empname from dual union select ca.empcode || '*' || t.emp_name || '*' || ca.workeddate || '*'|| ca.lopcancelltndate||'*', ca.empcode || '*' || t.emp_name || '*' || ca.workeddate || '*'|| ca.lopcancelltndate||'*' from TBL_LOP_CANCELLED ca, employee_master t, mactech.tl_trsfr_level a where t.emp_code = ca.empcode and t.emp_code = a.emp_code and a.tl_empcode = " & usr(0) & " and ca.status in (0)").Tables(0)




            Me.ddl_lop.DataSource = dtt4
            Me.ddl_lop.DataValueField = dtt4.Columns(0).ColumnName
            Me.ddl_lop.DataTextField = dtt4.Columns(1).ColumnName
            Me.ddl_lop.DataBind()

            'dtt5 = oh.ExecuteDataSet("select '-1', 'Employee Code -Employee Name- Worked Date - Cancellation date' as empname from dual union select ca.empcode || '*' || t.emp_name || '*' || ca.workeddate || '*' || ca.lopcancelltndate || '*', ca.empcode || '*' || t.emp_name || '*' || ca.workeddate || '*' || ca.lopcancelltndate || '*' from TBL_LOP_CANCELLED ca, employee_master t, mactech.department_mst d where ca.empcode = t.emp_code and t.department_id = d.dep_id and d.dep_head = " & usr(0) & " and ca.status in (4)").Tables(0)
            If Me.chk_app.Checked = True Then

                Me.cmd_rec.Visible = False

                Me.cmd_app.Visible = True
                dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code -Employee Name- Worked Date - Cancellation date' as empname from dual union select ca.empcode || '*' || t.emp_name || '*' || ca.workeddate || '*' || ca.lopcancelltndate || '*', ca.empcode || '*' || t.emp_name || '*' || ca.workeddate || '*' || ca.lopcancelltndate || '*' from TBL_LOP_CANCELLED ca, employee_master t, mactech.department_mst d where ca.empcode = t.emp_code and t.department_id = d.dep_id and d.dep_head = " & usr(0) & " and ca.status in (4)").Tables(0)
                'Me.ddl_lop.DataSource = dtt5
                'Me.ddl_lop.DataValueField = dtt5.Columns(0).ColumnName
                'Me.ddl_lop.DataTextField = dtt5.Columns(1).ColumnName
                'Me.ddl_lop.DataBind()

                Me.ddl_lop.DataSource = dtt4
                Me.ddl_lop.DataValueField = dtt4.Columns(0).ColumnName
                Me.ddl_lop.DataTextField = dtt4.Columns(1).ColumnName
                Me.ddl_lop.DataBind()


            End If
        End If
    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return str
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        str = ""
        Dim data() As String = eventArgument.Split("*")

        'Select Case CInt(data(0))
        '    Case 1
        '        Dim dt2 As New DataTable
        '---sh
        'If firmid = 8 Then

        ' dtl = oh.ExecuteDataSet("select distinct em.emp_code, em.emp_name, br.branch_name, pm.post_name, to_char(ca.workeddate), to_char(ca.lopcancelltndate), ca.remarks, to_char(ca.applieddate) from employee_master em, post_mst pm, branch br, tbl_lop_cancelled ca where em.post_id = pm.post_id and em.branch_id = br.branch_id and ca.empcode = em.emp_code and ca.status in (0, 4) and ca.empcode=" & aaa(0) & " and ca.workeddate = '" & aaa(2) & "' and ca.lopcancelltndate= '" & aaa(3) & "' ").Tables(0)
        dt = oh.ExecuteDataSet("select distinct em.emp_code || '*' || em.emp_name || '*' || br.branch_name || '*' || pm.post_name || '*' || to_char(ca.workeddate) || '*' ||to_char(ca.lopcancelltndate) || '*' || ca.remarks || '*' || to_char(ca.applieddate) from employee_master em, post_mst pm, branch br, tbl_lop_cancelled ca where em.post_id = pm.post_id and em.branch_id = br.branch_id and ca.empcode = em.emp_code and ca.status in (0, 4)  and ca.empcode=" & data(1) & " and ca.workeddate = '" & data(3) & "' and ca.lopcancelltndate= '" & data(4) & "' ").Tables(0)
        'Else
        ' dt = oh.ExecuteDataSet("select distinct em.emp_code||'*'||em.emp_name||'*'||br.branch_name||'*'||pm.post_name||'*'||ca.leave_dt||'*'||ca.apply_dt||'*'||cm.comp_name||'*'||cd.comp_date||'*'||cd.exp_date||'*'||ca.reason from employee_master em,post_mst pm,branch br,hrm_comp_appl ca,hrm_comp_mst cm,hrm_comp_dtl cd where  em.post_id=pm.post_id and cm.comp_id=cd.comp_id and em.branch_id=br.branch_id and ca.emp_code=em.emp_code and ca.comp_id=cm.comp_id and ca.status_id in (0,4) and ca.comp_id=" & data(2) & " and em.emp_code=" & data(1) & "").Tables(0)
        'End If
        '---sh

        If dt.Rows.Count > 0 Then
            str += dt.Rows(0)(0).ToString
        Else
            str = 4
        End If
        'Case 2


        '    Dim leave(7) As OracleParameter
        '    leave(0) = New OracleParameter("emp_type", OracleType.Number)
        '    leave(0).Direction = ParameterDirection.Input
        '    leave(0).Value = data(3)
        '    leave(1) = New OracleParameter("btn_type", OracleType.Number)
        '    leave(1).Direction = ParameterDirection.Input
        '    leave(1).Value = 3
        '    leave(2) = New OracleParameter("emp_id", OracleType.Number)
        '    leave(2).Direction = ParameterDirection.Input
        '    leave(2).Value = data(1)
        '    leave(3) = New OracleParameter("com_id", OracleType.Number)
        '    leave(3).Direction = ParameterDirection.Input
        '    leave(3).Value = data(2)
        '    leave(4) = New OracleParameter("rec_san_emp_code", OracleType.Number)
        '    leave(4).Direction = ParameterDirection.Input
        '    leave(4).Value = data(4)

        '    leave(5) = New OracleParameter("rej_reason", OracleType.VarChar, 100)
        '    leave(5).Direction = ParameterDirection.Input
        '    leave(5).Value = data(5)

        '    leave(6) = New OracleParameter("err_stat", OracleType.Number)
        '    leave(6).Direction = ParameterDirection.InputOutput
        '    leave(7) = New OracleParameter("err_msg", OracleType.VarChar, 100)
        '    leave(7).Direction = ParameterDirection.Output
        '    oh.ExecuteNonQuery("hrm_compensatory_san", leave)
        '    str += leave(6).Value.ToString()
        '    str += "*"
        '    str += leave(7).Value.ToString()
        '    If leave(6).Value = 1 Then

        '        Dim dt88 As DataTable = oh.ExecuteDataSet("select e.emp_name,a.leave_dt,e1.emp_name,decode(a.status_id,1,'Sanctioned',2,'Rejected',3,'cancelled',5,'cancelled',4,'Recommended') as status,a.email from employee_master e,hrm_comp_appl a,employee_master e1 where a.comp_id=" & data(2) & " and a.emp_code=" & data(1) & " and e.emp_code=a.emp_code and e1.emp_code=" & data(4) & "").Tables(0)
        'If dt88.Rows.Count <> 0 And dt88.Rows.Count = 1 Then
        '    If Not IsDBNull(dt88.Rows(0)(4)) Then

        '        Try
        '            Dim mMailServer As String
        '            Dim mPort As Integer
        '            mMailServer = ConfigurationManager.AppSettings.Get("MyMailServer")
        '            mPort = ConfigurationManager.AppSettings.Get("MyMailServerPort")
        '            Dim ldt As String = Format(CDate(dt88.Rows(0)(1)), "dd/MMM/yyyy")
        '            Dim str As String = "<h1 style='background-color:gold; color:red; text-align:center; font-size:18px'>MANAPPURAM GROUP OF COMPANIES</h1><h2 style='color:red; font-size:14px'><u>COMPENSATORY STATUS</u></h2><p style='font-size:12px'>Mr/Ms " & dt88.Rows(0)(0) & " </p> <p style='font-size:12px'>Your Compensatory Leave on " & ldt & " is " & dt88.Rows(0)(3) & " by Mr/Ms " & dt88.Rows(0)(2) & ",Due to " & data(5) & "</p><p style='color:blue; font-size:12px'> For further Queries and information if needed contact HRM</p><p style='text-align:right; font-size:12px'>Thank you ,</p><p style='text-align:right; font-size:12px'></p><p style='font-family:courier new; text-align:right; color:navy; font-size:12px'>MANAPPURAM-IT(SOFTWARE)</p><p style='font-family:courier new; text-align:right; color:navy; font-size:12px'>Payroll-section</p>"
        '            bilu_send_mail.bilu_send_mail.SendMail(dt88.Rows(0)(3), mMailServer, mPort, "manappuram", ldt, dt88.Rows(0)(0), dt88.Rows(0)(4), "Compensatory Applied Status on " & Format(Date.Now, "dd/MMM/yyyy") & "", str)

        '        Catch ex As Exception
        '            Dim cl_script As New StringBuilder
        '            cl_script.Append("   alert('Mail Service is not Available in this system') ;")
        '            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)


        '        End Try
        '         End If
        'End If
        'End If

        'End Select

    End Sub
    Protected Sub cmd_rec_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_rec.Click
        Dim script1 As New System.Text.StringBuilder

        If (Me.txt_empcd.Value = "") Then
            script1.Append("        alert('Please Select Employee..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)


        ElseIf (txt_remarks.Value = "") Then
            script1.Append("        alert('Please enter remarks..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        Else
            Dim parameter(4) As OracleParameter

            parameter(0) = New OracleParameter("ecode", OracleType.Number, 150)
            parameter(0).Direction = ParameterDirection.Input
            parameter(0).Value = usr(0)


            parameter(1) = New OracleParameter("rec_rem", OracleType.VarChar, 150)
            parameter(1).Direction = ParameterDirection.Input
            parameter(1).Value = Me.txt_remarks.Value


            parameter(2) = New OracleParameter("apl_empcode", OracleType.Number, 150)
            parameter(2).Direction = ParameterDirection.Input
            parameter(2).Value = Me.txt_empcd.Value

            parameter(3) = New OracleParameter("wrkdt", OracleType.DateTime)
            parameter(3).Direction = ParameterDirection.Input
            parameter(3).Value = Me.txtworked_date.Value


            parameter(4) = New OracleParameter("msg", OracleType.VarChar, 500)
            parameter(4).Direction = ParameterDirection.Output
            oh.ExecuteNonQuery("hrm_lopsndy_recmmndtnstatus", parameter)

            Dim message As String
            message = parameter(4).Value


            script1.Append("alert('" & message & "');")
            script1.Append("window.open('Sunday_lopCancellationRequest.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

            'If leave(0).Value = 1 Then
            '    Dim dt88 As DataTable = oh.ExecuteDataSet("select e.emp_name,a.leave_dt,e1.emp_name,decode(a.status_id,1,'Sanctioned',2,'Rejected',3,'cancelled',5,'cancelled',4,'Recommended') as status,a.email from employee_master e,hrm_comp_appl a,employee_master e1 where a.comp_id=" & emp_dt(1) & " and a.emp_code=" & emp_dt(0) & " and e.emp_code=a.emp_code and e1.emp_code=" & Me.hid_user.Value & "").Tables(0)

            '    Dim cl_script0 As New System.Text.StringBuilder
            '    cl_script0.Append("         alert(' " & leave(7).Value & " ');")
            '    cl_script0.Append("       window.open('Sunday_lop_CancelledReport.aspx','_self');")
            '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
            'Else
            'Dim cl_script0 As New System.Text.StringBuilder
            'cl_script0.Append("         alert(' " & leave(7).Value & " ');")
            'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)

        End If


    End Sub



    Protected Sub cmd_app_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_app.Click

        Dim script1 As New System.Text.StringBuilder
        If (Me.txt_empcd.Value = "") Then
            script1.Append("        alert('Please Select Employee..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

        ElseIf (txt_remarks.Value = "") Then
            script1.Append("        alert('Please enter remarks..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        Else
            Dim parameter(5) As OracleParameter

            parameter(0) = New OracleParameter("ecode", OracleType.Number, 150)
            parameter(0).Direction = ParameterDirection.Input
            parameter(0).Value = usr(0)


            parameter(1) = New OracleParameter("app_rem", OracleType.VarChar, 150)
            parameter(1).Direction = ParameterDirection.Input
            parameter(1).Value = Me.txt_remarks.Value


            parameter(2) = New OracleParameter("apl_empcode", OracleType.Number, 150)
            parameter(2).Direction = ParameterDirection.Input
            parameter(2).Value = Me.txt_empcd.Value

            parameter(3) = New OracleParameter("frmdt", OracleType.DateTime)
            parameter(3).Direction = ParameterDirection.Input
            parameter(3).Value = Me.txtlopcanclltn_date.Value

            parameter(4) = New OracleParameter("wrkdt", OracleType.DateTime)
            parameter(4).Direction = ParameterDirection.Input
            parameter(4).Value = Me.txtworked_date.Value




            parameter(5) = New OracleParameter("msg", OracleType.VarChar, 500)
            parameter(5).Direction = ParameterDirection.Output
            oh.ExecuteNonQuery("hrm_lop_apprv", parameter)


            Dim message As String
            message = parameter(5).Value


            script1.Append("alert('" & message & "');")
            script1.Append("window.open('Sunday_lopCancellationRequest.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        End If
    End Sub

    Protected Sub cmd_rej_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_rej.Click

        Dim script1 As New System.Text.StringBuilder

        If (Me.txt_empcd.Value = "") Then
            script1.Append("        alert('Please Select Employee..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

        ElseIf (txt_remarks.Value = "") Then
            script1.Append("        alert('Please enter remarks..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        Else
            Dim parameter(4) As OracleParameter

            parameter(0) = New OracleParameter("ecode", OracleType.Number, 150)
            parameter(0).Direction = ParameterDirection.Input
            parameter(0).Value = usr(0)


            parameter(1) = New OracleParameter("rej_res", OracleType.VarChar, 150)
            parameter(1).Direction = ParameterDirection.Input
            parameter(1).Value = Me.txt_remarks.Value


            parameter(2) = New OracleParameter("apl_empcode", OracleType.Number, 150)
            parameter(2).Direction = ParameterDirection.Input
            parameter(2).Value = Me.txt_empcd.Value

            parameter(3) = New OracleParameter("wrkdt", OracleType.DateTime)
            parameter(3).Direction = ParameterDirection.Input
            parameter(3).Value = Me.txtworked_date.Value


            parameter(4) = New OracleParameter("msg", OracleType.VarChar, 500)
            parameter(4).Direction = ParameterDirection.Output
            oh.ExecuteNonQuery("hrm_lop_reject", parameter)

            Dim message As String
            message = parameter(4).Value


            script1.Append("alert('" & message & "');")
            script1.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        End If
    End Sub


    Protected Sub chk_rec_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_rec.CheckedChanged

        'Dim brid As Integer = Me.Session("branchid")
        'Dim userid As String = Me.Session("userid")
        'Dim usr() As String = userid.Split("!")
        If Not IsPostBack Then

            If Me.chk_rec.Checked = False Then
                Me.chk_rec.Checked = False
                Me.chk_app.Checked = True
                Me.cmd_rec.Visible = False
                Me.cmd_app.Visible = True
                Dim dtt1, dtt2, dtt3, dtt4, dtt5 As New DataTable

                dtt1 = oh.ExecuteDataSet("select '-1', 'Employee Code -Employee Name- Worked Date - Cancellation date' as empname from dual union select ca.empcode || '*' || t.emp_name || '*' || ca.workeddate || '*' || ca.lopcancelltndate || '*', ca.empcode || '*' || t.emp_name || '*' || ca.workeddate || '*' || ca.lopcancelltndate || '*' from TBL_LOP_CANCELLED ca, employee_master t, mactech.department_mst d where ca.empcode=t.emp_code and t.department_id=d.dep_id and d.dep_head=" & usr(0) & " and ca.status in(4)").Tables(0)
                Dim rule As String = ""
                Dim cond As String = ""
                If dtt1.Rows.Count > 0 Then
                    Me.ddl_lop.DataSource = dtt4
                    Me.ddl_lop.DataValueField = dtt4.Columns(0).ColumnName
                    Me.ddl_lop.DataTextField = dtt4.Columns(1).ColumnName
                    Me.ddl_lop.DataBind()
                End If
                If Me.ddl_lop.SelectedValue = -1 Then
                    txt_empcd.Value = ""
                    txt_empnme.Value = ""
                    txt_branch.Value = ""
                    txt_post.Value = ""
                    txtworked_date.Value = ""
                    txtlopcanclltn_date.Value = ""
                    txtemp_rmrks.Value = ""
                    txtapplied_date.Value = ""
                    txt_remarks.Value = ""


                End If


            Else
                Me.chk_rec.Checked = True
                Me.chk_app.Checked = False
                Me.cmd_rec.Visible = True
                Me.cmd_app.Visible = False
                Dim dtt11, dtt12, dtt13, dtt4, dtt15 As New DataTable

                dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code -Employee Name- Worked Date - Cancellation date' as empname from dual union select ca.empcode || '*' || t.emp_name || '*' || ca.workeddate || '*' || ca.lopcancelltndate || '*', ca.empcode || '*' || t.emp_name || '*' || ca.workeddate || '*'|| ca.lopcancelltndate||'*' from TBL_LOP_CANCELLED ca, employee_master t, mactech.tl_trsfr_level a where t.emp_code = ca.empcode and t.emp_code = a.emp_code and a.tl_empcode = " & usr(0) & " and ca.status in (0)").Tables(0)
                If dtt4.Rows.Count > 0 Then
                    Me.ddl_lop.DataSource = dtt4
                    Me.ddl_lop.DataValueField = dtt4.Columns(0).ColumnName
                    Me.ddl_lop.DataTextField = dtt4.Columns(1).ColumnName
                    Me.ddl_lop.DataBind()
                End If
                If Me.ddl_lop.SelectedValue = -1 Then
                    txt_empcd.Value = ""
                    txt_empnme.Value = ""
                    txt_branch.Value = ""
                    txt_post.Value = ""
                    txtworked_date.Value = ""
                    txtlopcanclltn_date.Value = ""
                    txtemp_rmrks.Value = ""
                    txtapplied_date.Value = ""
                    txt_remarks.Value = ""

                End If
            End If


        End If



    End Sub

    Protected Sub chk_app_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_app.CheckedChanged


        'Dim brid As Integer = Me.Session("branchid")
        'Dim userid As String = Me.Session("userid")
        'Dim usr() As String = userid.Split("!")

        If Me.chk_app.Checked = True Then
            Me.chk_rec.Checked = False
            Me.chk_app.Checked = True
            Me.cmd_rec.Visible = False
            Me.cmd_app.Visible = True
            Dim dtt1, dtt2, dtt3, dtt5 As New DataTable

            dtt1 = oh.ExecuteDataSet("select '-1', 'Employee Code -Employee Name- Worked Date - Cancellation date' as empname from dual union select ca.empcode || '*' || t.emp_name || '*' || ca.workeddate || '*' || ca.lopcancelltndate || '*', ca.empcode || '*' || t.emp_name || '*' || ca.workeddate || '*' || ca.lopcancelltndate || '*' from TBL_LOP_CANCELLED ca, employee_master t, mactech.department_mst d where ca.empcode=t.emp_code and t.department_id=d.dep_id and d.dep_head=" & usr(0) & " and ca.status in(4)").Tables(0)
            Dim rule As String = ""
            Dim cond As String = ""
            If dtt1.Rows.Count > 0 Then

                Me.ddl_lop.DataSource = dtt1
                Me.ddl_lop.DataValueField = dtt1.Columns(0).ColumnName
                Me.ddl_lop.DataTextField = dtt1.Columns(1).ColumnName
                Me.ddl_lop.DataBind()
            End If
            If Me.ddl_lop.SelectedValue = -1 Then
                txt_empcd.Value = ""
                txt_empnme.Value = ""
                txt_branch.Value = ""
                txt_post.Value = ""
                txtworked_date.Value = ""
                txtlopcanclltn_date.Value = ""
                txtemp_rmrks.Value = ""
                txtapplied_date.Value = ""
                txt_remarks.Value = ""
                txt_remarks.Value = ""
            End If
            '.......................................................................
        Else
            Me.chk_rec.Checked = True
            Me.chk_app.Checked = False
            Me.cmd_rec.Visible = True
            Me.cmd_app.Visible = False
            Dim dtt11, dtt12, dtt13, dtt4, dtt15 As New DataTable

            dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date - Compensation Name' as emp_name from dual union select ca.empcode || '*' || t.emp_name || '*' || ca.workeddate || '*' || ca.lopcancelltndate || '*',ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' ||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master  t,othleave_sanction_authority a where t.emp_code = ca.emp_code and t.emp_code = a.emp_id and a.c_recby =" & usr(0) & "  and ca.comp_id = cm.comp_id and ca.status_id in (0) ").Tables(0)
            If dtt4.Rows.Count > 0 Then
                Me.ddl_lop.DataSource = dtt4
                Me.ddl_lop.DataValueField = dtt4.Columns(0).ColumnName
                Me.ddl_lop.DataTextField = dtt4.Columns(1).ColumnName
                Me.ddl_lop.DataBind()
            End If
            If Me.ddl_lop.SelectedValue = -1 Then
                txt_empcd.Value = ""
                txt_empnme.Value = ""
                txt_branch.Value = ""
                txt_post.Value = ""
                txtworked_date.Value = ""
                txtlopcanclltn_date.Value = ""
                txtemp_rmrks.Value = ""
                txtapplied_date.Value = ""
                txt_remarks.Value = ""

            End If
        End If
    End Sub
    'Protected Sub ddl_lop_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_lop.SelectedIndexChanged

    '    Dim aaa = Me.ddl_lop.SelectedItem.ToString.Split("*")


    '    dtl = oh.ExecuteDataSet("select distinct em.emp_code, em.emp_name, br.branch_name, pm.post_name, to_char(ca.workeddate), to_char(ca.lopcancelltndate), ca.remarks, to_char(ca.applieddate) from employee_master em, post_mst pm, branch br, tbl_lop_cancelled ca where em.post_id = pm.post_id and em.branch_id = br.branch_id and ca.empcode = em.emp_code and ca.status in (0, 4) and ca.empcode=" & aaa(0) & " and ca.workeddate = '" & aaa(2) & "' and ca.lopcancelltndate= '" & aaa(3) & "' ").Tables(0)


    '    Try

    '        Me.txt_empcd.Value = dtl.Rows(0)(0)
    '        Me.txt_empnme.Value = dtl.Rows(0)(1)
    '        Me.txt_branch.Value = dtl.Rows(0)(2)
    '        Me.txt_post.Value = dtl.Rows(0)(3)
    '        Me.txtworked_date.Value = dtl.Rows(0)(4)
    '        Me.txtlopcanclltn_date.Text = dtl.Rows(0)(5)
    '        Me.txtemp_rmrks.Value = dtl.Rows(0)(6)
    '        Me.txtapplied_date.Value = dtl.Rows(0)(7)


    '    Catch ex As Exception

    '    End Try

    ' End Sub

    'Protected Sub ddl_lop_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_lop.SelectedIndexChanged
    '    dts = oh.ExecuteDataSet("select distinct em.emp_code || '*' || em.emp_name || '*' || br.branch_name || '*' || pm.post_name || '*' || ca.workeddate || '*' || ca.lopcancelltndate || '*' || ca.remarks || '*' || ca.applieddate || '*' || ca.recommenderremarks from employee_master em, post_mst pm, branch br, tbl_lop_cancelled ca where em.post_id = pm.post_id and em.branch_id = br.branch_id and ca.empcode = em.emp_code and ca.status in (0, 4) and ca.empcode = 101057")
    'End Sub

    'End Sub

    'Protected Sub ddl_lop_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_lop.SelectedIndexChanged

    'End Sub
End Class
Imports System.Data
Imports System.Data.OracleClient

Partial Class leave_early_going_sanction_87bf77ed5407
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim str As String
    Dim dtt4, dt As New DataTable
    Dim dr, dr1, dr11, dr111 As DataRow
    Dim oh As New helper.oracle.OracleHelper
    Dim usr() As String
    Dim st As Integer
    '  Dim maill As bilu_send_mail.bilu_send_mail

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' CType(Me.Master, WebAppHRMS.edp).Subtitle = "EARLY GOING CANCEL"
        Dim script_val As String
        Me.emp_type.Value = 1
        script_val = "var header;" & "header='" & Me.cmb_emp.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function call_server (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "call_server", cbscript, True)
        Me.cmb_emp.Attributes.Add("onchange", "early_goingOnchange()")

        usr = Me.Session("user_id").ToString.Split("!")
        'usr = "10001!".Split("!")
        Me.hid_user.Value = usr(0)

        Dim cmb_emp As New DataTable
        If Not IsPostBack Then


            '.....................................................................
            If Me.Session("firm_id") = 24 Then
                Me.chk_rec.Enabled = False
                Me.chk_san.Enabled = False
                Me.cmd_rec.Visible = False
            End If
            Dim brid As Integer = Me.Session("branch_id")
            Dim userid As String = Me.Session("user_id")
            Dim uid() As String = userid.Split("!")
            Dim ecode As Integer = uid(0)

            Dim dtt1, dtt2, dtt3, dtt4, dtt5 As New DataTable
            Dim dtt11, dtt12, dtt13, dtt15 As New DataTable
            'dtt1 = oh.ExecuteDataSet("select t.sanction_by,t.rule from compen_sanction_mst t where (t.sanction_by is not null and t.sanction_by<>'0') ").Tables(0)
            'Dim rule As String = ""
            'Dim cond As String = ""
            'If dtt1.Rows.Count > 0 Then

            '    For Each dr In dtt1.Rows
            '        dtt2 = oh.ExecuteDataSet("select e.emp_code,e.branch_id from employee_master e where e.emp_code in(" & dr(0) & ") and e.emp_code=" & uid(0) & "").Tables(0)
            '        If dtt2.Rows.Count > 0 Then
            '            If rule = "" Then
            '                rule = "0," + dr(1).ToString + ",0"
            '            Else
            '                rule = rule + "," + dr(1).ToString + ",0"
            '            End If
            '        End If
            '    Next
            '    If rule = "" Then
            '        rule = "0"
            '    End If
            '    dtt5 = oh.ExecuteDataSet("select e.emp_code,e.branch_id from employee_master e where e.emp_code=" & uid(0) & "").Tables(0)
            '    dtt3 = oh.ExecuteDataSet("select t.post_id_in from compen_sanction_mst t where t.rule in (" & rule & ") ").Tables(0)

            '    If dtt3.Rows.Count > 0 Then
            '        For Each dr1 In dtt3.Rows
            '            If cond = "" Then
            '                cond = dr1(0).ToString
            '            Else
            '                cond = cond + " union " + dr1(0).ToString
            '            End If

            '        Next
            '    Else
            '        Me.cmd_san.Visible = False
            '    End If
            '    If cond = "" Then
            '        cond = "0"
            '    End If
            'End If
            ''---------------------------

            dtt11 = oh.ExecuteDataSet("select t.recom_by,t.rule from compen_sanction_mst t where (t.recom_by is not null and t.recom_by<>'0') ").Tables(0)
            Dim rule1 As String = ""
            Dim cond1 As String = ""
            If dtt11.Rows.Count > 0 Then

                For Each dr11 In dtt11.Rows
                    dtt12 = oh.ExecuteDataSet("select e.emp_code,e.branch_id from employee_master e where e.emp_code in(" & dr11(0) & ") and e.emp_code=" & uid(0) & "").Tables(0)
                    If dtt12.Rows.Count > 0 Then
                        If rule1 = "" Then
                            rule1 = "0," + dr11(1).ToString + ",0"
                        Else
                            rule1 = rule1 + ",0" + dr11(1).ToString + ",0"
                        End If
                    End If
                Next
                If rule1 = "" Then
                    rule1 = 0
                    'Response.Redirect("show_err.aspx")
                End If
                dtt15 = oh.ExecuteDataSet("select e.emp_code,e.branch_id from employee_master e where e.emp_code=" & uid(0) & "").Tables(0)
                dtt13 = oh.ExecuteDataSet("select t.post_id_in,t.rule from compen_sanction_mst t where t.rule in (" & rule1 & ") ").Tables(0)

                If dtt13.Rows.Count > 0 Then
                    For Each dr111 In dtt13.Rows
                        If cond1 = "" Then
                            cond1 = dr111(0).ToString
                        Else
                            cond1 = cond1 + " union " + dr111(0).ToString
                        End If

                    Next
                Else
                    Me.cmd_rec.Visible = False
                End If
                If cond1 = "" Then
                    cond1 = "0"
                End If
            End If


            If rule1.Contains(",1,") Or rule1.Contains(",23,") Or rule1.Contains(",125,") Then

                dtt4 = oh.ExecuteDataSet("select '-1','Employee Code  - Leave Date - Compensation Name' as emp_name  from dual union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t   where t.emp_code = ca.emp_code  and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (0) and t.emp_code in (" & cond1 & ") and t.branch_id=" & dtt15.Rows(0)(1) & " ").Tables(0)
            Else

                If rule1.Contains(",2,") Or rule1.Contains(",3,") Or rule1.Contains(",25,") Then
                    dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date- Compensation Name' as emp_name  from dual union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t   where t.emp_code = ca.emp_code  and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (0) and t.emp_code in (" & cond1 & ") and t.branch_id in (select r.branch_id from branch_dtl_new b,branch_dtl_new r where b.branch_id=" & dtt15.Rows(0)(1) & " and b.area_id=r.area_id)").Tables(0)
                Else
                    'If rule1.Contains(",3,") Then
                    '    dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date- Compensation Name' as emp_name  from dual union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t   where t.emp_code = ca.emp_code  and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (0) and t.emp_code in (" & cond1 & ") and t.branch_id in  (select r.branch_id from branch_dtl_new b,branch_dtl_new r where b.branch_id=" & dtt15.Rows(0)(1) & " and b.area_id=r.area_id) ").Tables(0)
                    'Else
                    'If rule1.Contains(",4,") Then
                    '    dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date - Compensation Name' as emp_name  from dual union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t   where t.emp_code = ca.emp_code  and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (0) and t.emp_code in (" & cond1 & ") and t.branch_id in  (select r.branch_id from branch_dtl_new b,branch_dtl_new r where b.branch_id=" & dtt15.Rows(0)(1) & " and b.reg_id=r.reg_id) ").Tables(0)
                    'Else
                    If rule1.Contains(",7,") Or rule1.Contains(",11,") Or rule1.Contains(",18,") Or rule1.Contains(",4,") Or rule1.Contains(",14,") Or rule1.Contains(",16,") Then
                        dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date - Compensation Name' as emp_name  from dual union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t   where t.emp_code = ca.emp_code  and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (0) and t.emp_code in (" & cond1 & ") and t.branch_id in (select r.branch_id from branch_dtl_new b,branch_dtl_new r where b.branch_id=" & dtt15.Rows(0)(1) & " and b.reg_id=r.reg_id) ").Tables(0)
                    Else
                        If rule1.Contains(",19,") Then
                            dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date - Compensation Name' as emp_name  from dual  union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t  where t.emp_code = ca.emp_code and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (4) and t.emp_code in (" & cond1 & ") and t.department_id in (select dep_id from  department_mst where dep_head=" & usr(0) & ")").Tables(0)
                        Else
                            dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date - Compensation Name' as emp_name  from dual union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t   where t.emp_code = ca.emp_code  and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (0) and t.emp_code in (" & cond1 & ") ").Tables(0)
                        End If
                    End If

                End If

                ' End If
                ' End If
                '.......................................................................

            End If
            Me.cmb_emp.DataSource = dtt4
            Me.cmb_emp.DataValueField = dtt4.Columns(0).ColumnName
            Me.cmb_emp.DataTextField = dtt4.Columns(1).ColumnName
            Me.cmb_emp.DataBind()

        End If
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return str
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        str = ""
        Dim data() As String = eventArgument.Split("*")

        Select Case CInt(data(0))
            Case 1
                Dim dt2 As New DataTable
                dt = oh.ExecuteDataSet("select distinct em.emp_code||'*'||em.emp_name||'*'||br.branch_name||'*'||pm.post_name||'*'||ca.leave_dt||'*'||ca.apply_dt||'*'||cm.comp_name||'*'||cd.comp_date||'*'||cd.exp_date||'*'||ca.reason from employee_master em,post_mst pm,branch br,hrm_comp_appl ca,hrm_comp_mst cm,hrm_comp_dtl cd where  em.post_id=pm.post_id and cm.comp_id=cd.comp_id and em.branch_id=br.branch_id and ca.emp_code=em.emp_code and ca.comp_id=cm.comp_id and ca.status_id in (0,4) and ca.comp_id=" & data(2) & " and em.emp_code=" & data(1) & "").Tables(0)
                If dt.Rows.Count > 0 Then
                    str += dt.Rows(0)(0).ToString
                Else
                    str = 4
                End If
            Case 2


                Dim leave(7) As OracleParameter
                leave(0) = New OracleParameter("emp_type", OracleType.Number)
                leave(0).Direction = ParameterDirection.Input
                leave(0).Value = data(3)
                leave(1) = New OracleParameter("btn_type", OracleType.Number)
                leave(1).Direction = ParameterDirection.Input
                leave(1).Value = 3
                leave(2) = New OracleParameter("emp_id", OracleType.Number)
                leave(2).Direction = ParameterDirection.Input
                leave(2).Value = data(1)
                leave(3) = New OracleParameter("com_id", OracleType.Number)
                leave(3).Direction = ParameterDirection.Input
                leave(3).Value = data(2)
                leave(4) = New OracleParameter("rec_san_emp_code", OracleType.Number)
                leave(4).Direction = ParameterDirection.Input
                leave(4).Value = data(4)

                leave(5) = New OracleParameter("rej_reason", OracleType.VarChar, 100)
                leave(5).Direction = ParameterDirection.Input
                leave(5).Value = data(5)

                leave(6) = New OracleParameter("err_stat", OracleType.Number)
                leave(6).Direction = ParameterDirection.InputOutput
                leave(7) = New OracleParameter("err_msg", OracleType.VarChar, 100)
                leave(7).Direction = ParameterDirection.Output
                oh.ExecuteNonQuery("hrm_compensatory_san", leave)
                str += leave(6).Value.ToString()
                str += "*"
                str += leave(7).Value.ToString()
                If leave(6).Value = 1 Then

                    Dim dt88 As DataTable = oh.ExecuteDataSet("select e.emp_name,a.leave_dt,e1.emp_name,decode(a.status_id,1,'Sanctioned',2,'Rejected',3,'cancelled',5,'cancelled',4,'Recommended') as status,a.email from employee_master e,hrm_comp_appl a,employee_master e1 where a.comp_id=" & data(2) & " and a.emp_code=" & data(1) & " and e.emp_code=a.emp_code and e1.emp_code=" & data(4) & "").Tables(0)
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
                End If

        End Select

    End Sub

    Protected Sub cmd_rec_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_rec.Click
        Dim emp_dtl() As String
        emp_dtl = Me.cmb_emp.SelectedValue.Split("*")

        Dim leave(7) As OracleParameter
        leave(0) = New OracleParameter("emp_type", OracleType.Number)
        leave(0).Direction = ParameterDirection.Input
        leave(0).Value = Me.emp_type.Value
        leave(1) = New OracleParameter("btn_type", OracleType.Number)
        leave(1).Direction = ParameterDirection.Input
        leave(1).Value = 1
        leave(2) = New OracleParameter("emp_id", OracleType.Number)
        leave(2).Direction = ParameterDirection.Input
        leave(2).Value = emp_dtl(0)
        leave(3) = New OracleParameter("com_id", OracleType.Number)
        leave(3).Direction = ParameterDirection.Input
        leave(3).Value = emp_dtl(1)
        leave(4) = New OracleParameter("rec_san_emp_code", OracleType.Number)
        leave(4).Direction = ParameterDirection.Input
        leave(4).Value = usr(0)

        leave(5) = New OracleParameter("rej_reason", OracleType.VarChar, 100)
        leave(5).Direction = ParameterDirection.Input
        leave(5).Value = Me.hid_rej.Value

        leave(6) = New OracleParameter("err_stat", OracleType.Number)
        leave(6).Direction = ParameterDirection.InputOutput
        leave(7) = New OracleParameter("err_msg", OracleType.VarChar, 100)
        leave(7).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("hrm_compensatory_san", leave)
        If leave(6).Value = 1 Then
            Dim dt88 As DataTable = oh.ExecuteDataSet("select e.emp_name,a.leave_dt,e1.emp_name,decode(a.status_id,1,'Sanctioned',2,'Rejected',3,'cancelled',5,'cancelled',4,'Recommended') as status,a.email from employee_master e,hrm_comp_appl a,employee_master e1 where a.comp_id=" & emp_dtl(1) & " and a.emp_code=" & emp_dtl(0) & " and e.emp_code=a.emp_code and e1.emp_code=" & usr(0) & "").Tables(0)
            'If dt88.Rows.Count <> 0 And dt88.Rows.Count = 1 Then
            '    If Not IsDBNull(dt88.Rows(0)(4)) Then
            '        Try
            '            Dim mMailServer As String
            '            Dim mPort As Integer
            '            mMailServer = ConfigurationManager.AppSettings.Get("MyMailServer")
            '            mPort = ConfigurationManager.AppSettings.Get("MyMailServerPort")
            '            Dim ldt As String = Format(CDate(dt88.Rows(0)(1)), "dd/MMM/yyyy")
            '            Dim str As String = "<h1 style='background-color:gold; color:red; text-align:center; font-size:18px'>MANAPPURAM GROUP OF COMPANIES</h1><h2 style='color:red; font-size:14px'><u>COMPENSATORY STATUS</u></h2><p style='font-size:12px'>Mr/Ms " & dt88.Rows(0)(0) & " </p> <p style='font-size:12px'>Your Compensatory Leave on " & ldt & " is " & dt88.Rows(0)(3) & " by Mr/Ms " & dt88.Rows(0)(2) & " and waiting for Sanction.</p><p style='color:blue; font-size:12px'> For further Queries and information if needed contact HRM</p><p style='text-align:right; font-size:12px'>Thank you ,</p><p style='text-align:right; font-size:12px'></p><p style='font-family:courier new; text-align:right; color:navy; font-size:12px'>MANAPPURAM-IT(SOFTWARE)</p><p style='font-family:courier new; text-align:right; color:navy; font-size:12px'>Payroll-section</p>"
            '            bilu_send_mail.bilu_send_mail.SendMail(dt88.Rows(0)(3), mMailServer, mPort, "manappuram", ldt, dt88.Rows(0)(0), dt88.Rows(0)(4), "Compensatory Applied Status on " & Format(Date.Now, "dd/MMM/yyyy") & "", str)
            '        Catch ex As Exception
            '            Dim cl_script As New StringBuilder
            '            cl_script.Append("   alert('Mail Service is not Available in this system') ;")
            '            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)


            '        End Try
            ' End If
            '    End If
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert(' " & leave(7).Value & " ');")
            cl_script0.Append("       window.open('new_compensatory_sanction.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
        Else
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert(' " & leave(7).Value & " ');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)

        End If
    End Sub


    Protected Sub cmd_san_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_san.Click
        Dim emp_dtl() As String

        emp_dtl = Me.cmb_emp.SelectedValue.Split("*")

        Dim leave(7) As OracleParameter
        leave(0) = New OracleParameter("emp_type", OracleType.Number)
        leave(0).Direction = ParameterDirection.Input
        leave(0).Value = Me.emp_type.Value
        leave(1) = New OracleParameter("btn_type", OracleType.Number)
        leave(1).Direction = ParameterDirection.Input
        leave(1).Value = 2
        leave(2) = New OracleParameter("emp_id", OracleType.Number)
        leave(2).Direction = ParameterDirection.Input
        leave(2).Value = emp_dtl(0)
        leave(3) = New OracleParameter("com_id", OracleType.Number)
        leave(3).Direction = ParameterDirection.Input
        leave(3).Value = emp_dtl(1)
        leave(4) = New OracleParameter("rec_san_emp_code", OracleType.Number)
        leave(4).Direction = ParameterDirection.Input
        leave(4).Value = usr(0)

        leave(5) = New OracleParameter("rej_reason", OracleType.VarChar, 100)
        leave(5).Direction = ParameterDirection.Input
        leave(5).Value = Me.hid_rej.Value

        leave(6) = New OracleParameter("err_stat", OracleType.Number)
        leave(6).Direction = ParameterDirection.InputOutput
        leave(7) = New OracleParameter("err_msg", OracleType.VarChar, 100)
        leave(7).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("hrm_compensatory_san", leave)
        If leave(6).Value = 1 Then
            Dim dt88 As DataTable = oh.ExecuteDataSet("select e.emp_name,a.leave_dt,e1.emp_name,decode(a.status_id,1,'Sanctioned',2,'Rejected',3,'cancelled',5,'cancelled',4,'Recommended') as status,a.email from employee_master e,hrm_comp_appl a,employee_master e1 where a.comp_id=" & emp_dtl(1) & " and a.emp_code=" & emp_dtl(0) & " and e.emp_code=a.emp_code and e1.emp_code=" & usr(0) & "").Tables(0)
            'If dt88.Rows.Count <> 0 And dt88.Rows.Count = 1 Then

            '    If Not IsDBNull(dt88.Rows(0)(4)) Then
            '        Try
            '            Dim mMailServer As String
            '            Dim mPort As Integer
            '            mMailServer = ConfigurationManager.AppSettings.Get("MyMailServer")
            '            mPort = ConfigurationManager.AppSettings.Get("MyMailServerPort")
            '            Dim ldt As String = Format(CDate(dt88.Rows(0)(1)), "dd/MMM/yyyy")
            '            Dim str As String = "<h1 style='background-color:gold; color:red; text-align:center; font-size:18px'>MANAPPURAM GROUP OF COMPANIES</h1><h2 style='color:red; font-size:14px'><u>COMPENSATORY STATUS</u></h2><p style='font-size:12px'>Mr/Ms " & dt88.Rows(0)(0) & " </p> <p style='font-size:12px'>Your Compensatory Leave on " & ldt & " is " & dt88.Rows(0)(3) & " by Mr/Ms " & dt88.Rows(0)(2) & ".</p><p style='color:blue; font-size:12px'> For further Queries and information if needed contact HRM</p><p style='text-align:right; font-size:12px'>Thank you ,</p><p style='text-align:right; font-size:12px'></p><p style='font-family:courier new; text-align:right; color:navy; font-size:12px'>MANAPPURAM-IT(SOFTWARE)</p><p style='font-family:courier new; text-align:right; color:navy; font-size:12px'>Payroll-section</p>"
            '            bilu_send_mail.bilu_send_mail.SendMail(dt88.Rows(0)(3), mMailServer, mPort, "manappuram", ldt, dt88.Rows(0)(0), dt88.Rows(0)(4), "Compensatory Applied Status on " & Format(Date.Now, "dd/MMM/yyyy") & "", str)
            '        Catch ex As Exception
            '            Dim cl_script As New StringBuilder
            '            cl_script.Append("   alert('Mail Service is not Available in this system') ;")
            '            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)


            '        End Try

            '    End If
            'End If
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert(' " & leave(7).Value & " ');")
            cl_script0.Append("       window.open('new_compensatory_sanction.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
        Else
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert(' " & leave(7).Value & " ');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
        End If
    End Sub

    Protected Sub cmd_rej_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_rej.Click
        Dim emp_dtl() As String
        emp_dtl = Me.cmb_emp.SelectedValue.Split("*")

        Dim leave(7) As OracleParameter
        leave(0) = New OracleParameter("emp_type", OracleType.Number)
        leave(0).Direction = ParameterDirection.Input
        leave(0).Value = Me.emp_type.Value
        leave(1) = New OracleParameter("btn_type", OracleType.Number)
        leave(1).Direction = ParameterDirection.Input
        leave(1).Value = 3
        leave(2) = New OracleParameter("emp_id", OracleType.Number)
        leave(2).Direction = ParameterDirection.Input
        leave(2).Value = emp_dtl(0)
        leave(3) = New OracleParameter("com_id", OracleType.Number)
        leave(3).Direction = ParameterDirection.Input
        leave(3).Value = emp_dtl(1)
        leave(4) = New OracleParameter("rec_san_emp_code", OracleType.Number)
        leave(4).Direction = ParameterDirection.Input
        leave(4).Value = usr(0)
        leave(5) = New OracleParameter("rej_reason", OracleType.VarChar, 100)
        leave(5).Direction = ParameterDirection.Input
        leave(5).Value = Me.hid_rej.Value
        leave(6) = New OracleParameter("err_stat", OracleType.Number)
        leave(6).Direction = ParameterDirection.InputOutput
        leave(7) = New OracleParameter("err_msg", OracleType.VarChar, 100)
        leave(7).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("hrm_compensatory_san", leave)
        If leave(6).Value = 1 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert(' " & leave(7).Value & " ');")
            cl_script0.Append("       window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
        Else
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert(' " & leave(7).Value & " ');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
        End If
    End Sub

    Protected Sub chk_rec_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_rec.CheckedChanged
        Dim brid As Integer = Me.Session("branch_id")
        Dim userid As String = Me.Session("user_id")
        Dim uid() As String = userid.Split("!")
        Dim ecode As Integer = uid(0)

        If Me.chk_rec.Checked = False Then
            Me.chk_rec.Checked = False
            Me.chk_san.Checked = True
            Dim dtt1, dtt2, dtt3, dtt5 As New DataTable

            dtt1 = oh.ExecuteDataSet("select t.sanction_by,t.rule from compen_sanction_mst t where (t.sanction_by is not null and t.sanction_by<>'0') ").Tables(0)
            Dim rule As String = ""
            Dim cond As String = ""
            If dtt1.Rows.Count > 0 Then

                For Each dr In dtt1.Rows
                    dtt2 = oh.ExecuteDataSet("select e.emp_code,e.branch_id from employee_master e where e.emp_code in(" & dr(0) & ") and e.emp_code=" & uid(0) & "").Tables(0)
                    If dtt2.Rows.Count > 0 Then
                        If rule = "" Then
                            rule = "0," + dr(1).ToString + ",0"
                        Else
                            rule = rule + "," + dr(1).ToString + ",0"
                        End If
                    End If
                Next
                If rule = "" Then
                    rule = 0
                End If
                dtt5 = oh.ExecuteDataSet("select e.emp_code,e.branch_id from employee_master e where e.emp_code=" & uid(0) & "").Tables(0)
                dtt3 = oh.ExecuteDataSet("select t.post_id_in from compen_sanction_mst t where t.rule in (" & rule & ") ").Tables(0)

                If dtt3.Rows.Count > 0 Then
                    For Each dr1 In dtt3.Rows
                        If cond = "" Then
                            cond = dr1(0).ToString
                        Else
                            cond = cond + " union " + dr1(0).ToString
                        End If

                    Next
                Else
                    If Session("firm_id") <> 24 Then
                        Me.cmd_san.Visible = False
                    End If
                    End If
                    If cond = "" Then
                        cond = "0"
                    End If
            End If

            If rule.Contains(",1,") Or rule.Contains(",2,") Or rule.Contains(",4,") Then
                dtt4 = oh.ExecuteDataSet("select '-1','Employee Code  - Leave Date - Compensation Name' as emp_name  from dual  union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t  where t.emp_code = ca.emp_code and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (4) and t.emp_code in (" & cond & ") and t.branch_id in (select b.branch_id from branch_dtl_new b,zonal_master r where r.hr_head=" & uid(0) & " and b.zonal_id=r.zonal_id)   ").Tables(0)
            Else
                'If rule.Contains(",2,") Then
                '    dtt4 = oh.ExecuteDataSet("select '-1','Employee Code  - Leave Date - Compensation Name' as emp_name  from dual  select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t  where t.emp_code = ca.emp_code and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (4) and t.emp_code in (" & cond & ") and t.branch_id in (select r.branch_id from branch_dtl_new b,branch_dtl_new r where b.branch_id=" & dtt15.Rows(0)(1) & " and b.area_id=r.area_id) ").Tables(0)
                'Else
                'If rule.Contains(",2,") Then
                '    dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date- Compensation Name' as emp_name  from dual union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t  where t.emp_code = ca.emp_code and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (4) and t.emp_code in (" & cond & ") and t.branch_id in (select r.branch_id from branch_dtl_new b,branch_dtl_new r where b.branch_id=" & dtt5.Rows(0)(1) & " and b.reg_id=r.reg_id)").Tables(0)
                'Else
                'If rule.Contains(",3,") Then
                '    dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date- Compensation Name' as emp_name  from dual  union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t  where t.emp_code = ca.emp_code and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (4) and t.emp_code in (" & cond & ") ").Tables(0)
                'Else
                '    If rule.Contains(",4,") Then
                '        dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date - Compensation Name' as emp_name  from dual  union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t  where t.emp_code = ca.emp_code and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (4) and t.emp_code in (" & cond & ") and t.branch_id in (select b.branch_id from branch_dtl_new b,zonal_master r where r.hr_head=" & uid(0) & " and b.zonal_id=r.zonal_id)").Tables(0)
                '    Else
                'If rule.Contains(",7,") Or rule.Contains(",9,") Or rule.Contains(",11,") Or rule.Contains(",14,") Or rule.Contains(",16,") Then
                '    dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date - Compensation Name' as emp_name  from dual  union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t  where t.emp_code = ca.emp_code and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (4) and t.emp_code in (" & cond & ") ").Tables(0)
                'Else
                If rule.Contains(",19,") Then
                    dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date - Compensation Name' as emp_name  from dual  union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t  where t.emp_code = ca.emp_code and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (4) and t.emp_code in (" & cond & ") and t.department_id in (select g.dep_id from department_mst g,department_major t where and t.department_id=g.major_dep_id and t.head_id like '%" & uid(0) & "%')").Tables(0)
                Else
                    If rule.Contains(",18,") Then
                        dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date - Compensation Name' as emp_name  from dual  union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t  where t.emp_code = ca.emp_code and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (4) and t.emp_code in (" & cond & ") and t.branch_id in (select b.branch_id from branch_dtl_new b,zonal_master r where r.head_id=" & uid(0) & " and b.zonal_id=r.zonal_id) ").Tables(0)
                    Else

                        dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date - Compensation Name' as emp_name  from dual  union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t  where t.emp_code = ca.emp_code and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (4) and t.emp_code in (" & cond & ")").Tables(0)
                    End If
                    ' End If
                End If
                ' End If
                '    End If
                'End If
                '.......................................................................
            End If
            Me.cmb_emp.DataSource = dtt4
            Me.cmb_emp.DataValueField = dtt4.Columns(0).ColumnName
            Me.cmb_emp.DataTextField = dtt4.Columns(1).ColumnName
            Me.cmb_emp.DataBind()




        Else
            Me.chk_rec.Checked = True
            Me.chk_san.Checked = False
            Dim dtt11, dtt12, dtt13, dtt15 As New DataTable

            dtt11 = oh.ExecuteDataSet("select t.recom_by,t.rule from compen_sanction_mst t where (t.recom_by is not null and t.recom_by<>'0') ").Tables(0)
            Dim rule1 As String = ""
            Dim cond1 As String = ""
            If dtt11.Rows.Count > 0 Then

                For Each dr11 In dtt11.Rows
                    dtt12 = oh.ExecuteDataSet("select e.emp_code,e.branch_id from employee_master e where e.emp_code in(" & dr11(0) & ") and e.emp_code=" & uid(0) & "").Tables(0)
                    If dtt12.Rows.Count > 0 Then
                        If rule1 = "" Then
                            rule1 = "0," + dr11(1).ToString + ",0"
                        Else
                            rule1 = rule1 + ",0" + dr11(1).ToString + ",0"
                        End If
                    End If
                Next
                If rule1 = "" Then
                    rule1 = 0
                    'Response.Redirect("show_err.aspx")
                End If
                dtt15 = oh.ExecuteDataSet("select e.emp_code,e.branch_id from employee_master e where e.emp_code=" & uid(0) & "").Tables(0)
                dtt13 = oh.ExecuteDataSet("select t.post_id_in,t.rule from compen_sanction_mst t where t.rule in (" & rule1 & ") ").Tables(0)

                If dtt13.Rows.Count > 0 Then
                    For Each dr111 In dtt13.Rows
                        If cond1 = "" Then
                            cond1 = dr111(0).ToString
                        Else
                            cond1 = cond1 + " union " + dr111(0).ToString
                        End If

                    Next
                Else
                    Me.cmd_rec.Visible = False
                End If
                If cond1 = "" Then
                    cond1 = "0"
                End If
            End If


            If rule1.Contains(",1,") Or rule1.Contains(",23,") Then

                dtt4 = oh.ExecuteDataSet("select '-1','Employee Code  - Leave Date - Compensation Name' as emp_name  from dual union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t   where t.emp_code = ca.emp_code  and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (0) and t.emp_code in (" & cond1 & ") and t.branch_id=" & dtt15.Rows(0)(1) & " ").Tables(0)
            Else

                If rule1.Contains(",2,") Or rule1.Contains(",3,") Or rule1.Contains(",25,") Then
                    dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date- Compensation Name' as emp_name  from dual union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t   where t.emp_code = ca.emp_code  and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (0) and t.emp_code in (" & cond1 & ") and t.branch_id in (select r.branch_id from branch_dtl_new b,branch_dtl_new r where b.branch_id=" & dtt15.Rows(0)(1) & " and b.area_id=r.area_id)").Tables(0)
                Else
                    'If rule1.Contains(",3,") Then
                    '    dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date- Compensation Name' as emp_name  from dual union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t   where t.emp_code = ca.emp_code  and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (0) and t.emp_code in (" & cond1 & ") and t.branch_id in  (select r.branch_id from branch_dtl_new b,branch_dtl_new r where b.branch_id=" & dtt15.Rows(0)(1) & " and b.area_id=r.area_id) ").Tables(0)
                    'Else
                    'If rule1.Contains(",4,") Then
                    '    dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date - Compensation Name' as emp_name  from dual union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t   where t.emp_code = ca.emp_code  and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (0) and t.emp_code in (" & cond1 & ") and t.branch_id in  (select r.branch_id from branch_dtl_new b,branch_dtl_new r where b.branch_id=" & dtt15.Rows(0)(1) & " and b.reg_id=r.reg_id) ").Tables(0)
                    'Else
                    If rule1.Contains(",7,") Or rule1.Contains(",11,") Or rule1.Contains(",18,") Or rule1.Contains(",4,") Or rule1.Contains(",14,") Or rule1.Contains(",16,") Then
                        dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date - Compensation Name' as emp_name  from dual union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t   where t.emp_code = ca.emp_code  and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (0) and t.emp_code in (" & cond1 & ") and t.branch_id in (select r.branch_id from branch_dtl_new b,branch_dtl_new r where b.branch_id=" & dtt15.Rows(0)(1) & " and b.reg_id=r.reg_id) ").Tables(0)
                    Else
                        If rule1.Contains(",19,") Then
                            dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date - Compensation Name' as emp_name  from dual  union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t  where t.emp_code = ca.emp_code and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (4) and t.emp_code in (" & cond1 & ") and t.department_id in (select dep_id from  department_mst where dep_head=" & usr(0) & ")").Tables(0)
                        Else
                            dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date - Compensation Name' as emp_name  from dual union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t   where t.emp_code = ca.emp_code  and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (0) and t.emp_code in (" & cond1 & ") ").Tables(0)
                        End If
                    End If

                End If

                ' End If
                ' End If
                '.......................................................................

            End If

            Me.cmb_emp.DataSource = dtt4
            Me.cmb_emp.DataValueField = dtt4.Columns(0).ColumnName
            Me.cmb_emp.DataTextField = dtt4.Columns(1).ColumnName
            Me.cmb_emp.DataBind()

        End If


    End Sub

    Protected Sub chk_san_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_san.CheckedChanged
        Dim brid As Integer = Me.Session("branch_id")
        Dim userid As String = Me.Session("user_id")
        Dim uid() As String = userid.Split("!")
        Dim ecode As Integer = uid(0)

        If Me.chk_san.Checked = True Then
            Me.chk_rec.Checked = False
            Me.chk_san.Checked = True
            Dim dtt1, dtt2, dtt3, dtt5 As New DataTable


            dtt1 = oh.ExecuteDataSet("select t.sanction_by,t.rule from compen_sanction_mst t where (t.sanction_by is not null and t.sanction_by<>'0') ").Tables(0)
            Dim rule As String = ""
            Dim cond As String = ""
            If dtt1.Rows.Count > 0 Then

                For Each dr In dtt1.Rows
                    dtt2 = oh.ExecuteDataSet("select e.emp_code,e.branch_id from employee_master e where e.emp_code in(" & dr(0) & ") and e.emp_code=" & uid(0) & "").Tables(0)
                    If dtt2.Rows.Count > 0 Then
                        If rule = "" Then
                            rule = "0," + dr(1).ToString + ",0"
                        Else
                            rule = rule + "," + dr(1).ToString + ",0"
                        End If
                    End If
                Next
                If rule = "" Then
                    rule = 0
                End If
                dtt5 = oh.ExecuteDataSet("select e.emp_code,e.branch_id from employee_master e where e.emp_code=" & uid(0) & "").Tables(0)
                dtt3 = oh.ExecuteDataSet("select t.post_id_in from compen_sanction_mst t where t.rule in (" & rule & ") ").Tables(0)

                If dtt3.Rows.Count > 0 Then
                    For Each dr1 In dtt3.Rows
                        If cond = "" Then
                            cond = dr1(0).ToString
                        Else
                            cond = cond + " union " + dr1(0).ToString
                        End If

                    Next
                Else
                    Me.cmd_san.Visible = False
                End If
                If cond = "" Then
                    cond = "0"
                End If
            End If

            If rule.Contains(",1,") Or rule.Contains(",2,") Or rule.Contains(",4,") Then
                dtt4 = oh.ExecuteDataSet("select '-1','Employee Code  - Leave Date - Compensation Name' as emp_name  from dual  union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t  where t.emp_code = ca.emp_code and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (4) and t.emp_code in (" & cond & ") and t.branch_id in (select b.branch_id from branch_dtl_new b,zonal_master r where r.hr_head=" & uid(0) & " and b.zonal_id=r.zonal_id)   ").Tables(0)
            Else
                'If rule.Contains(",2,") Then
                '    dtt4 = oh.ExecuteDataSet("select '-1','Employee Code  - Leave Date - Compensation Name' as emp_name  from dual  select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t  where t.emp_code = ca.emp_code and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (4) and t.emp_code in (" & cond & ") and t.branch_id in (select r.branch_id from branch_dtl_new b,branch_dtl_new r where b.branch_id=" & dtt15.Rows(0)(1) & " and b.area_id=r.area_id) ").Tables(0)
                'Else
                'If rule.Contains(",2,") Then
                '    dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date- Compensation Name' as emp_name  from dual union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t  where t.emp_code = ca.emp_code and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (4) and t.emp_code in (" & cond & ") and t.branch_id in (select r.branch_id from branch_dtl_new b,branch_dtl_new r where b.branch_id=" & dtt5.Rows(0)(1) & " and b.reg_id=r.reg_id)").Tables(0)
                'Else
                'If rule.Contains(",3,") Then
                '    dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date- Compensation Name' as emp_name  from dual  union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t  where t.emp_code = ca.emp_code and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (4) and t.emp_code in (" & cond & ") ").Tables(0)
                'Else
                '    If rule.Contains(",4,") Then
                '        dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date - Compensation Name' as emp_name  from dual  union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t  where t.emp_code = ca.emp_code and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (4) and t.emp_code in (" & cond & ") and t.branch_id in (select b.branch_id from branch_dtl_new b,zonal_master r where r.hr_head=" & uid(0) & " and b.zonal_id=r.zonal_id)").Tables(0)
                '    Else
                If rule.Contains(",19,") Then
                    dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date - Compensation Name' as emp_name  from dual  union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t  where t.emp_code = ca.emp_code and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (4) and t.emp_code in (" & cond & ") and t.department_id in (select g.dep_id from department_mst g,department_major t where and t.department_id=g.major_dep_id and t.head_id like '%" & uid(0) & "%')").Tables(0)
                Else
                    If rule.Contains(",18,") Then
                        dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date - Compensation Name' as emp_name  from dual  union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t  where t.emp_code = ca.emp_code and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (4) and t.emp_code in (" & cond & ") and t.branch_id in (select b.branch_id from branch_dtl_new b,zonal_master r where r.head_id=" & uid(0) & " and b.zonal_id=r.zonal_id) ").Tables(0)
                    Else

                        dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date - Compensation Name' as emp_name  from dual  union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t  where t.emp_code = ca.emp_code and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (4) and t.emp_code in (" & cond & ")").Tables(0)
                    End If
                    ' End If
                    'End If
                    ' End If
                    '    End If
                End If
                '.......................................................................
            End If
            Me.cmb_emp.DataSource = dtt4
            Me.cmb_emp.DataValueField = dtt4.Columns(0).ColumnName
            Me.cmb_emp.DataTextField = dtt4.Columns(1).ColumnName
            Me.cmb_emp.DataBind()




        Else
            Me.chk_rec.Checked = True
            Me.chk_san.Checked = False
            Dim dtt11, dtt12, dtt13, dtt15 As New DataTable

            dtt11 = oh.ExecuteDataSet("select t.recom_by,t.rule from compen_sanction_mst t where (t.recom_by is not null and t.recom_by<>'0') ").Tables(0)
            Dim rule1 As String = ""
            Dim cond1 As String = ""
            If dtt11.Rows.Count > 0 Then

                For Each dr11 In dtt11.Rows
                    dtt12 = oh.ExecuteDataSet("select e.emp_code,e.branch_id from employee_master e where e.emp_code in(" & dr11(0) & ") and e.emp_code=" & uid(0) & "").Tables(0)
                    If dtt12.Rows.Count > 0 Then
                        If rule1 = "" Then
                            rule1 = "0," + dr11(1).ToString + ",0"
                        Else
                            rule1 = rule1 + ",0" + dr11(1).ToString + ",0"
                        End If
                    End If
                Next
                If rule1 = "" Then
                    rule1 = 0
                    ' Response.Redirect("show_err.aspx")
                End If
                dtt15 = oh.ExecuteDataSet("select e.emp_code,e.branch_id from employee_master e where e.emp_code=" & uid(0) & "").Tables(0)
                dtt13 = oh.ExecuteDataSet("select t.post_id_in,t.rule from compen_sanction_mst t where t.rule in (" & rule1 & ") ").Tables(0)

                If dtt13.Rows.Count > 0 Then
                    For Each dr111 In dtt13.Rows
                        If cond1 = "" Then
                            cond1 = dr111(0).ToString
                        Else
                            cond1 = cond1 + " union " + dr111(0).ToString
                        End If

                    Next
                Else
                    Me.cmd_rec.Visible = False
                End If
                If cond1 = "" Then
                    cond1 = "0"
                End If
            End If


            If rule1.Contains(",1,") Or rule1.Contains(",23,") Then

                dtt4 = oh.ExecuteDataSet("select '-1','Employee Code  - Leave Date - Compensation Name' as emp_name  from dual union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t   where t.emp_code = ca.emp_code  and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (0) and t.emp_code in (" & cond1 & ") and t.branch_id=" & dtt15.Rows(0)(1) & " ").Tables(0)
            Else

                If rule1.Contains(",2,") Or rule1.Contains(",3,") Or rule1.Contains(",25,") Then
                    dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date- Compensation Name' as emp_name  from dual union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t   where t.emp_code = ca.emp_code  and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (0) and t.emp_code in (" & cond1 & ") and t.branch_id in (select r.branch_id from branch_dtl_new b,branch_dtl_new r where b.branch_id=" & dtt15.Rows(0)(1) & " and b.area_id=r.area_id)").Tables(0)
                Else
                    'If rule1.Contains(",3,") Then
                    '    dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date- Compensation Name' as emp_name  from dual union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t   where t.emp_code = ca.emp_code  and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (0) and t.emp_code in (" & cond1 & ") and t.branch_id in  (select r.branch_id from branch_dtl_new b,branch_dtl_new r where b.branch_id=" & dtt15.Rows(0)(1) & " and b.area_id=r.area_id) ").Tables(0)
                    'Else
                    'If rule1.Contains(",4,") Then
                    '    dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date - Compensation Name' as emp_name  from dual union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t   where t.emp_code = ca.emp_code  and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (0) and t.emp_code in (" & cond1 & ") and t.branch_id in  (select r.branch_id from branch_dtl_new b,branch_dtl_new r where b.branch_id=" & dtt15.Rows(0)(1) & " and b.reg_id=r.reg_id) ").Tables(0)
                    'Else
                    If rule1.Contains(",7,") Or rule1.Contains(",11,") Or rule1.Contains(",18,") Or rule1.Contains(",4,") Or rule1.Contains(",14,") Or rule1.Contains(",16,") Then
                        dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date - Compensation Name' as emp_name  from dual union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t   where t.emp_code = ca.emp_code  and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (0) and t.emp_code in (" & cond1 & ") and t.branch_id in (select r.branch_id from branch_dtl_new b,branch_dtl_new r where b.branch_id=" & dtt15.Rows(0)(1) & " and b.reg_id=r.reg_id) ").Tables(0)
                    Else
                        If rule1.Contains(",19,") Then
                            dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date - Compensation Name' as emp_name  from dual  union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t  where t.emp_code = ca.emp_code and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (4) and t.emp_code in (" & cond1 & ") and t.department_id in (select dep_id from  department_mst where dep_head=" & usr(0) & ")").Tables(0)
                        Else
                            dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date - Compensation Name' as emp_name  from dual union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t   where t.emp_code = ca.emp_code  and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (0) and t.emp_code in (" & cond1 & ") ").Tables(0)
                        End If
                    End If

                End If

                ' End If
                ' End If
                '.......................................................................

            End If

            Me.cmb_emp.DataSource = dtt4
            Me.cmb_emp.DataValueField = dtt4.Columns(0).ColumnName
            Me.cmb_emp.DataTextField = dtt4.Columns(1).ColumnName
            Me.cmb_emp.DataBind()

        End If
    End Sub
End Class



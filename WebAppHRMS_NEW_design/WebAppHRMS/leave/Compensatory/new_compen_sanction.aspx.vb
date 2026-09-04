Imports System.Data
Imports System.Data.OracleClient

Partial Class leave_early_going_sanction_87bf77ed7425
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim str As String
    Dim dtt4, dt As New DataTable
    Dim dr, dr1, dr11, dr111 As DataRow
    Dim oh As New helper.oracle.OracleHelper
    Dim usr() As String

    Dim st As Integer

    Dim firmid As Integer
    Dim branchid As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '------VAPT - improper parameter validation---------------------------------------
        Dim paramCount As Integer = Request.QueryString.Count
        If Request.QueryString.Count > 0 Then
            Response.StatusCode = 400
            Response.StatusDescription = "Bad Request"
            Response.End()
        End If
        ' CType(Me.Master, WebAppHRMS.edp).Subtitle = "EARLY GOING CANCEL"
        Dim script_val As String
        Me.emp_type.Value = 1
        script_val = "var header;" & "header='" & Me.cmb_emp.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function call_server (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "call_server", cbscript, True)
        Me.cmb_emp.Attributes.Add("onchange", "early_goingOnchange()")
        Dim usr() As String = Session("user_id").ToString.Split("!")
        ' usr = Me.Session("user_id").ToString.Split("!")

        Me.hid_user.Value = usr(0)
        Dim cmb_emp As New DataTable


        '---------------------------
        Try
            firmid = Convert.ToInt32(Me.Session("firm_id"))
            branchid = Me.Session("branch_id")
            Dim Sql As String
            If firmid = 24 Then
                Sql = "select nvl(t.branch_id,'NULL') branch ,t.block_all from hrm_block_leave_frm t where t.firm_id=24 and t.block_opt='SANCTION'"
                Dim dtCheck As New DataTable
                Dim branch As String
                dtCheck = oh.ExecuteDataSet(Sql).Tables(0)
                branch = dtCheck.Rows(0)(0)
                Dim flag As Boolean = False
                If dtCheck.Rows.Count > 0 Then
                    If dtCheck.Rows(0)(1) = "Y" Then
                        flag = True
                    End If
                    If branch <> "NULL" Then
                        Dim ar() = branch.Split(",")
                        Dim index As Integer
                        For index = 0 To ar.Length - 1
                            If Val(ar(index)) = branchid Then
                                flag = True
                                Exit For
                            End If
                        Next
                    End If

                    If flag = True Then
                        Dim cl_script As New StringBuilder
                        cl_script.Append("   alert('Leave Entry BLOCKED from HO') ;")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "BLOCKLEAVE", cl_script.ToString, True)
                        chk_rec.Checked = False
                        chk_rec.Enabled = False
                        chk_san.Checked = False
                        chk_san.Enabled = False

                        Return
                    End If
                End If
            End If
        Catch ex As System.Exception
        End Try
        '---------------------------





        If Not IsPostBack Then


            '.....................................................................

            Dim dtt1, dtt2, dtt3, dtt4, dtt5 As New DataTable
            Dim dtt11, dtt12, dtt13, dtt15 As New DataTable

            Me.cmd_rec.Visible = True

            Me.cmd_san.Visible = False


            dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date - Compensation Name' as emp_name from dual union select ca.emp_code || '*' || ca.comp_id,ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' ||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master  t,othleave_sanction_authority a where t.emp_code = ca.emp_code and t.emp_code = a.emp_id and a.c_recby =" & usr(0) & "  and ca.comp_id = cm.comp_id and ca.status_id in (0)").Tables(0)

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
                '---sh
                If firmid = 24 Then
                    dt = oh.ExecuteDataSet("select distinct em.emp_code||'*'||em.emp_name||'*'||br.branch_name||'*'||pm.post_name||'*'||ca.leave_dt||'*'||ca.apply_dt||'*'||cm.comp_name||'*'||cd.comp_date||'*'||cd.exp_date||'*'||ca.reason from employee_master em,post_mst_jwell  pm,branch br,hrm_comp_appl ca,hrm_comp_mst cm,hrm_comp_dtl cd where  em.post_id=pm.post_id and cm.comp_id=cd.comp_id and em.branch_id=br.branch_id and ca.emp_code=em.emp_code and ca.comp_id=cm.comp_id and ca.status_id in (0,4) and ca.comp_id=" & data(2) & " and em.emp_code=" & data(1) & "").Tables(0)
                Else
                    dt = oh.ExecuteDataSet("select distinct em.emp_code||'*'||em.emp_name||'*'||br.branch_name||'*'||pm.post_name||'*'||ca.leave_dt||'*'||ca.apply_dt||'*'||cm.comp_name||'*'||cd.comp_date||'*'||cd.exp_date||'*'||ca.reason from employee_master em,post_mst pm,branch br,hrm_comp_appl ca,hrm_comp_mst cm,hrm_comp_dtl cd where  em.post_id=pm.post_id and cm.comp_id=cd.comp_id and em.branch_id=br.branch_id and ca.emp_code=em.emp_code and ca.comp_id=cm.comp_id and ca.status_id in (0,4) and ca.comp_id=" & data(2) & " and em.emp_code=" & data(1) & "").Tables(0)
                End If
                '---sh

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
        leave(2) = New OracleParameter("empid", OracleType.Number)
        leave(2).Direction = ParameterDirection.Input
        leave(2).Value = emp_dtl(0)
        leave(3) = New OracleParameter("com_id", OracleType.Number)
        leave(3).Direction = ParameterDirection.Input
        leave(3).Value = emp_dtl(1)
        leave(4) = New OracleParameter("rec_san_emp_code", OracleType.Number)
        leave(4).Direction = ParameterDirection.Input
        leave(4).Value = Me.hid_user.Value

        leave(5) = New OracleParameter("rej_reason", OracleType.VarChar, 100)
        leave(5).Direction = ParameterDirection.Input
        leave(5).Value = Me.hid_rej.Value

        leave(6) = New OracleParameter("err_stat", OracleType.Number)
        leave(6).Direction = ParameterDirection.InputOutput
        leave(7) = New OracleParameter("err_msg", OracleType.VarChar, 100)
        leave(7).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("HRM_COMPENSATORY_SAN", leave)
        If leave(6).Value = 1 Then
            Dim dt88 As DataTable = oh.ExecuteDataSet("select e.emp_name,a.leave_dt,e1.emp_name,decode(a.status_id,1,'Sanctioned',2,'Rejected',3,'cancelled',5,'cancelled',4,'Recommended') as status,a.email from employee_master e,hrm_comp_appl a,employee_master e1 where a.comp_id=" & emp_dtl(1) & " and a.emp_code=" & emp_dtl(0) & " and e.emp_code=a.emp_code and e1.emp_code=" & Me.hid_user.Value & "").Tables(0)
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
            'cl_script0.Append("       window.open('new_compen_sanction.aspx','_self');")
            Dim usr() As String = Session("user_id").ToString.Split("!")
            dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date - Compensation Name' as emp_name from dual union select ca.emp_code || '*' || ca.comp_id,ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' ||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst  cm,employee_master t,othleave_sanction_authority a where t.emp_code = ca.emp_code and t.emp_code = a.emp_id and a.c_sanby = " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (4,5) union select ca.emp_code || '*' || ca.comp_id,ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' ||cm.comp_name from hrm_comp_appl ca, hrm_comp_mst cm,employee_master  t, othleave_sanction_authority a where t.emp_code = ca.emp_code and t.emp_code = a.emp_id and a.c_recby=0 and a.c_sanby=" & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (0)").Tables(0)
            If dtt4.Rows.Count > 0 Then
                Me.cmb_emp.DataSource = dtt4
                Me.cmb_emp.DataValueField = dtt4.Columns(0).ColumnName
                Me.cmb_emp.DataTextField = dtt4.Columns(1).ColumnName
                Me.cmb_emp.DataBind()
            End If
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
        leave(2) = New OracleParameter("empid", OracleType.Number)
        leave(2).Direction = ParameterDirection.Input
        leave(2).Value = emp_dtl(0)
        leave(3) = New OracleParameter("com_id", OracleType.Number)
        leave(3).Direction = ParameterDirection.Input
        leave(3).Value = emp_dtl(1)
        leave(4) = New OracleParameter("rec_san_emp_code", OracleType.Number)
        leave(4).Direction = ParameterDirection.Input
        leave(4).Value = Me.hid_user.Value

        leave(5) = New OracleParameter("rej_reason", OracleType.VarChar, 100)
        leave(5).Direction = ParameterDirection.Input
        leave(5).Value = Me.hid_rej.Value

        leave(6) = New OracleParameter("err_stat", OracleType.Number)
        leave(6).Direction = ParameterDirection.InputOutput
        leave(7) = New OracleParameter("err_msg", OracleType.VarChar, 100)
        leave(7).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("HRM_COMPENSATORY_SAN", leave)
        If leave(6).Value = 1 Then
            Dim dt88 As DataTable = oh.ExecuteDataSet("select e.emp_name,a.leave_dt,e1.emp_name,decode(a.status_id,1,'Sanctioned',2,'Rejected',3,'cancelled',5,'cancelled',4,'Recommended') as status,a.email from employee_master e,hrm_comp_appl a,employee_master e1 where a.comp_id=" & emp_dtl(1) & " and a.emp_code=" & emp_dtl(0) & " and e.emp_code=a.emp_code and e1.emp_code=" & Me.hid_user.Value & "").Tables(0)
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
            'cl_script0.Append("       window.open('new_compen_sanction.aspx','_self');")
            Dim usr() As String = Session("user_id").ToString.Split("!")
            dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date - Compensation Name' as emp_name from dual union select ca.emp_code || '*' || ca.comp_id,ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' ||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst  cm,employee_master t,othleave_sanction_authority a where t.emp_code = ca.emp_code and t.emp_code = a.emp_id and a.c_sanby = " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (4,5) union select ca.emp_code || '*' || ca.comp_id,ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' ||cm.comp_name from hrm_comp_appl ca, hrm_comp_mst cm,employee_master  t, othleave_sanction_authority a where t.emp_code = ca.emp_code and t.emp_code = a.emp_id and a.c_recby=0 and a.c_sanby=" & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (0)").Tables(0)
            If dtt4.Rows.Count > 0 Then
                Me.cmb_emp.DataSource = dtt4
                Me.cmb_emp.DataValueField = dtt4.Columns(0).ColumnName
                Me.cmb_emp.DataTextField = dtt4.Columns(1).ColumnName
                Me.cmb_emp.DataBind()
            End If
            Me.txt_empcd.Value = ""
            Me.txt_enm.Value = ""
            Me.txt_branch.Value = ""
            Me.txt_post.Value = ""
            Me.txt_dt.Value = ""
            Me.txt_app_dt.Text = ""
            Me.txt_comp_name.Value = ""
            Me.txt_comp_dt.Value = ""
            Me.txt_exp_dt.Value = ""
            Me.txt_rsn.Value = ""
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
        leave(2) = New OracleParameter("empid", OracleType.Number)
        leave(2).Direction = ParameterDirection.Input
        leave(2).Value = emp_dtl(0)
        leave(3) = New OracleParameter("com_id", OracleType.Number)
        leave(3).Direction = ParameterDirection.Input
        leave(3).Value = emp_dtl(1)
        leave(4) = New OracleParameter("rec_san_emp_code", OracleType.Number)
        leave(4).Direction = ParameterDirection.Input
        leave(4).Value = Me.hid_user.Value
        leave(5) = New OracleParameter("rej_reason", OracleType.VarChar, 100)
        leave(5).Direction = ParameterDirection.Input
        leave(5).Value = Me.hid_rej.Value
        leave(6) = New OracleParameter("err_stat", OracleType.Number)
        leave(6).Direction = ParameterDirection.InputOutput
        leave(7) = New OracleParameter("err_msg", OracleType.VarChar, 100)
        leave(7).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("HRM_COMPENSATORY_SAN", leave)
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
        Dim usr() As String = userid.Split("!")

        If Me.chk_rec.Checked = False Then
            Me.chk_rec.Checked = False
            Me.chk_san.Checked = True
            Me.cmd_rec.Visible = False
            Me.cmd_san.Visible = True
            Dim dtt1, dtt2, dtt3, dtt5 As New DataTable

            dtt1 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date - Compensation Name' as emp_name from dual union select ca.emp_code || '*' || ca.comp_id,ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' ||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst  cm,employee_master t,othleave_sanction_authority a where t.emp_code = ca.emp_code and t.emp_code = a.emp_id and a.c_sanby = " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (4,5) union select ca.emp_code || '*' || ca.comp_id,ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' ||cm.comp_name from hrm_comp_appl ca, hrm_comp_mst cm,employee_master  t, othleave_sanction_authority a where t.emp_code = ca.emp_code and t.emp_code = a.emp_id and a.c_recby=0 and a.c_sanby=" & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (0) ").Tables(0)
            Dim rule As String = ""
            Dim cond As String = ""
            If dtt1.Rows.Count > 0 Then
                Me.cmb_emp.DataSource = dtt4
                Me.cmb_emp.DataValueField = dtt4.Columns(0).ColumnName
                Me.cmb_emp.DataTextField = dtt4.Columns(1).ColumnName
                Me.cmb_emp.DataBind()
            End If
            If Me.cmb_emp.SelectedValue = -1 Then
                txt_empcd.Value = ""
                txt_enm.Value = ""
                txt_branch.Value = ""
                txt_post.Value = ""
                txt_dt.Value = ""
                txt_app_dt.Text = ""
                txt_comp_name.Value = ""
                txt_comp_dt.Value = ""
                txt_exp_dt.Value = ""
                txt_rsn.Value = ""

            End If
        Else
            Me.chk_rec.Checked = True
            Me.chk_san.Checked = False
            Me.cmd_rec.Visible = True
            Me.cmd_san.Visible = False
            Dim dtt11, dtt12, dtt13, dtt15 As New DataTable

            dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date - Compensation Name' as emp_name from dual union select ca.emp_code || '*' || ca.comp_id,ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' ||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master  t,othleave_sanction_authority a where t.emp_code = ca.emp_code and t.emp_code = a.emp_id and a.c_recby =" & usr(0) & "  and ca.comp_id = cm.comp_id and ca.status_id in (0)").Tables(0)
            If dtt4.Rows.Count > 0 Then
                Me.cmb_emp.DataSource = dtt4
                Me.cmb_emp.DataValueField = dtt4.Columns(0).ColumnName
                Me.cmb_emp.DataTextField = dtt4.Columns(1).ColumnName
                Me.cmb_emp.DataBind()
            End If
            If Me.cmb_emp.SelectedValue = -1 Then
                txt_empcd.Value = ""
                txt_enm.Value = ""
                txt_branch.Value = ""
                txt_post.Value = ""
                txt_dt.Value = ""
                txt_app_dt.Text = ""
                txt_comp_name.Value = ""
                txt_comp_dt.Value = ""
                txt_exp_dt.Value = ""
                txt_rsn.Value = ""
            End If
        End If
    End Sub

    Protected Sub chk_san_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_san.CheckedChanged
        Dim brid As Integer = Me.Session("branch_id")
        Dim userid As String = Me.Session("user_id")
        Dim usr() As String = userid.Split("!")

        If Me.chk_san.Checked = True Then
            Me.chk_rec.Checked = False
            Me.chk_san.Checked = True
            Me.cmd_rec.Visible = False
            Me.cmd_san.Visible = True
            Dim dtt1, dtt2, dtt3, dtt5 As New DataTable

            dtt1 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date - Compensation Name' as emp_name from dual union select ca.emp_code || '*' || ca.comp_id,ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' ||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst  cm,employee_master t,othleave_sanction_authority a where t.emp_code = ca.emp_code and t.emp_code = a.emp_id and a.c_sanby = " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (4,5) union select ca.emp_code || '*' || ca.comp_id,ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' ||cm.comp_name from hrm_comp_appl ca, hrm_comp_mst cm,employee_master  t, othleave_sanction_authority a where t.emp_code = ca.emp_code and t.emp_code = a.emp_id and a.c_recby=0 and a.c_sanby=" & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (0)").Tables(0)
            Dim rule As String = ""
            Dim cond As String = ""
            If dtt1.Rows.Count > 0 Then

                Me.cmb_emp.DataSource = dtt1
                Me.cmb_emp.DataValueField = dtt1.Columns(0).ColumnName
                Me.cmb_emp.DataTextField = dtt1.Columns(1).ColumnName
                Me.cmb_emp.DataBind()
            End If
            If Me.cmb_emp.SelectedValue = -1 Then
                txt_empcd.Value = ""
                txt_enm.Value = ""
                txt_branch.Value = ""
                txt_post.Value = ""
                txt_dt.Value = ""
                txt_app_dt.Text = ""
                txt_comp_name.Value = ""
                txt_comp_dt.Value = ""
                txt_exp_dt.Value = ""
                txt_rsn.Value = ""
            End If
            '.......................................................................
        Else
            Me.chk_rec.Checked = True
            Me.chk_san.Checked = False
            Me.cmd_rec.Visible = True
            Me.cmd_san.Visible = False
            Dim dtt11, dtt12, dtt13, dtt15 As New DataTable

            dtt4 = oh.ExecuteDataSet("select '-1', 'Employee Code  - Leave Date - Compensation Name' as emp_name from dual union select ca.emp_code || '*' || ca.comp_id,ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' ||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master  t,othleave_sanction_authority a where t.emp_code = ca.emp_code and t.emp_code = a.emp_id and a.c_recby =" & usr(0) & "  and ca.comp_id = cm.comp_id and ca.status_id in (0) ").Tables(0)
            If dtt4.Rows.Count > 0 Then
                Me.cmb_emp.DataSource = dtt4
                Me.cmb_emp.DataValueField = dtt4.Columns(0).ColumnName
                Me.cmb_emp.DataTextField = dtt4.Columns(1).ColumnName
                Me.cmb_emp.DataBind()
            End If
            If Me.cmb_emp.SelectedValue = -1 Then
                txt_empcd.Value = ""
                txt_enm.Value = ""
                txt_branch.Value = ""
                txt_post.Value = ""
                txt_dt.Value = ""
                txt_app_dt.Text = ""
                txt_comp_name.Value = ""
                txt_comp_dt.Value = ""
                txt_exp_dt.Value = ""
                txt_rsn.Value = ""
            End If
        End If
    End Sub
End Class



Imports System.Data
Imports System.Data.OracleClient
Partial Class leave_Leave_sanction_242da2288321
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim oh As New helper.oracle.oraclehelper
    Dim sql As String
    Dim res As String
    Dim dt1 As DataTable
    ' Dim res As Integer

    Dim firmid As Integer
    Dim branchid As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        firmid = Session("firm_id")

        If firmid = 8 Then

            Response.Redirect("HRM_leave_rec_sanMAC.aspx")
            ' Server.Transfer("HRM_leave_rec_sanMAC.aspx")

        End If
        Try
            'Dim fm As Integer = Session("firm_id")
            'If fm = 2 Then
            '    Dim cl_script As New StringBuilder
            '    'cl_script.Append("   alert(' Redirecting to new maben Leave sanction page') ;")
            '    cl_script.Append("window.open('Mab_Leave_sanction_to.aspx','_self');")
            '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            'Else
            Dim script_val As String
            script_val = "var loanno;" & "loanno='" & "" & Me.txt_frdt.ClientID & "'" & " ; "
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
            Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "sub_call_receiver", "context")
            Dim cbscript As String = "function sub_call_server(arg,context) { " & cbref & "; } "
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "sub_call_server", cbscript, True)
            CType(Me.Master, WebAppHRMS.edp).Subtitle = "LEAVE SANCTION"


            '---------------------------
            Try
                firmid = Convert.ToInt32(Me.Session("firm_id"))
                branchid = Me.Session("branch_id")
                Dim st As New StringBuilder
                Dim st1 As String

                If firmid = 24 Then
                    sql = "select nvl(t.branch_id,'NULL') branch ,t.block_all from hrm_block_leave_frm t where t.firm_id=24 and t.block_opt='SANCTION'"
                    Dim dtCheck As New DataTable
                    Dim branch As String
                    dtCheck = oh.ExecuteDataSet(sql).Tables(0)
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
                            cl_script.Append("   alert('Leave Entry Blocked from HO') ;")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "BLOCKLEAVE", cl_script.ToString, True)
                            st1 = 1 & "#" & 1 & "#" & "Leave Entry BLOCKED from HO"
                            st.Append(st1)
                            res = st.ToString
                            cmb_leave.Enabled = False
                            Return
                        End If
                    End If
                End If
            Catch ex As System.Exception
            End Try
            '---------------------------


            If Not IsPostBack Then


                'If Session("firm_id") = 2 Then
                '    'Response.Redirect("irregular_debit_maben.aspx")
                '    'Server.Transfer("Mab_Leave_sanction_Rec.aspx")
                '    'End If
                '    Dim cl_script As New StringBuilder
                '    '    cl_script.Append("   alert(' Redirecting to new maben Leave sanction page') ;")
                '    cl_script.Append("window.open('Mab_Leave_sanction_Rec.aspx','_self');")
                '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                'Else

                Dim usr = Session("user_id").ToString.Split("!")
                If usr(0) = 10001 Then
                    Me.cmd_rec.Disabled = True
                End If

                Me.cmd_applnform.Disabled = False
                Me.cmd_support.Disabled = False
                Me.cmd_pl28.Disabled = False
                Me.cmb_acc.Visible = False
                Me.Label1.Text = ""
                res = call_proc(2)
                Dim dt As DataTable
                dt = oh.ExecuteDataSet("select branch_id,branch_name from branch_master where branch_id<>9999 union select old_id,branch_name from before_completion where branch_id is null union select -9999,'' from dual").Tables(0)
                Me.cmb_branch.DataSource = dt
                Me.cmb_branch.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_branch.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_branch.DataBind()
                dt = oh.ExecuteDataSet("select post_id,post_name from post_mst union select -9999,'' from dual").Tables(0)
                Me.cmb_post.DataSource = dt
                Me.cmb_post.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_post.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_post.DataBind()
                fill_data(res)
                'End If
            End If
        Catch ex As Exception
            Me.Label1.Text = ex.Message
        End Try
        'Dim usr1() As String = Me.Session("user_id").ToString.Split("!")
        Dim sc As String = "var cont_name;cont_name='" & Me.txt_name.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var2", sc, True)
        Me.Checkbox1.Attributes.Add("onclick", "OnCheck()")
        Me.txt_ParFrDt.Attributes.Add("onkeyup", "OnkeyUpChqDate1()")
        Me.txt_ParToDt.Attributes.Add("onkeyup", "OnkeyUpChqDate()")
        'dt1 = oh.ExecuteDataSet("select emp_code,emp_name,leave_id,to_char(to_date(leave_frdate)),to_char(to_date(leave_todate)),leave_days,leave_apply_date,leave_reason,branch_id,post_id,total_leave_month,total_leave_day,leave_seq,recom_reason,recom_name,recom_post,actual_from,to_char(actual_to, 'dd-MON-yyyy'),emp_code,leave_frdate,leave_todate,emp_name from hrm_leave_application where sanc_code=" & usr1(0) & " order by emp_code,leave_apply_date").Tables(0)
    End Sub
    Sub fill_data(ByVal b As Integer)
        Dim usr() As String = Me.Session("user_id").ToString.Split("!")
        If b = 1 Then
            Dim dt As DataTable
            dt = oh.ExecuteDataSet("select '0', '--SELECT--' as empcode from dual union select s.emp_code || '*' || emp_name || '*' || leave_id || '*' ||  to_char(leave_frdate, 'dd-MON-yyyy') || '*' ||  to_char(leave_todate, 'dd-MON-yyyy') || '*' || leave_days || '*' ||  TO_CHAR(leave_apply_date, 'DD/MON/YYYY- HH12:MI:SS AM') || '*' ||  leave_reason || '*' || s.branch_id || '*' || post_id || '*' ||  total_leave_month || '*' || total_leave_day || '*' || leave_seq || '*' ||  recom_reason || '*' || recom_name || '*' || recom_post || '*' ||  to_char(actual_from, 'dd-MON-yyyy') || '*' ||  to_char(actual_to, 'dd-MON-yyyy') || '*' || recom_dt || '*' || ll.cl || '*' ||  ll.sl || '*' || ll.el,  s.emp_code || '  -  ' || to_char(leave_frdate, 'dd-MON-yyyy') ||  '  -  ' || to_char(leave_todate, 'dd-MON-yyyy') || ' - ' ||  to_char(leave_apply_date, 'dd-MON-yyyy') || ' - ' || emp_name as empcode from hrm_leave_application s,  (select x1.emp_code, x1.leave_days cl, x2.leave_days sl, x3.leave_days el   from (select a.emp_code, a.leave_days   from employ_leave_master a   where a.leave_id = 1) x1, (select a.emp_code, a.leave_days   from employ_leave_master a   where a.leave_id = 2) x2, (select a.emp_code, a.leave_days   from employ_leave_master a   where a.leave_id = 3) x3   where x1.emp_code = x2.emp_code  and x1.emp_code = x3.emp_code) ll where s.sanc_code = " & usr(0) & "  and s.emp_code = ll.emp_code(+)   and s.branch_id = 0 order by empcode ").Tables(0)
            Me.cmb_leave.DataSource = dt
            Me.cmb_leave.DataTextField = dt.Columns(1).ColumnName
            Me.cmb_leave.DataValueField = dt.Columns(0).ColumnName
            Me.cmb_leave.DataBind()
            If dt.Rows.Count = 0 Then
                '  Me.cmb_leave.Items.Add("NO LEAVE FOR SANCTION")
                Dim cl_script As New StringBuilder
                cl_script.Append("   alert(' NO LEAVE FOR SANCTION !!') ;")
                cl_script.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            End If

        Else
            Me.Server.Transfer("../show_err.aspx")
        End If
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim cal_data = eventArgument
        Dim dis() As String = cal_data.ToString.Split("$")
        Dim st As New StringBuilder
        Dim st1 As String
        Dim a As New Integer
        Dim tr(5) As OracleParameter
        Try
            If dis(0) = 1 Then
                Dim str As String = ""
                '  str = Me.hid_empcode.Value & "*" & Me.txt_name.Value & "*" & Me.txt_ltyp.Value & "*" & Me.txt_frdt.Value & "*" & Me.txt_todt.Value & "*" & Me.txt_dur.Value & "*" & Me.txt_appdt.Value & "*" & Me.txt_reason.Value & "*" & Me.hid_seq.Value
                tr(0) = New OracleParameter("usr_id", OracleType.VarChar, 50)
                tr(0).Direction = ParameterDirection.Input
                tr(0).Value = Me.Session("user_id")
                tr(1) = New OracleParameter("id", OracleType.Number, 1)
                tr(1).Direction = ParameterDirection.Input
                tr(1).Value = 1
                tr(2) = New OracleParameter("str", OracleType.VarChar, 500)
                tr(2).Direction = ParameterDirection.Input
                tr(2).Value = dis(1)
                tr(3) = New OracleParameter("flag", OracleType.Number, 2)
                tr(3).Direction = ParameterDirection.Output
                tr(4) = New OracleParameter("msg", OracleType.VarChar, 500)
                tr(4).Direction = ParameterDirection.Output
                tr(5) = New OracleParameter("str1", OracleType.VarChar, 4000)
                tr(5).Direction = ParameterDirection.Output
                oh.ExecuteNonQuery("HRM_LEAVE_SANC_REJ", tr)
                a = tr(3).Value
                st1 = 1 & "#" & tr(3).Value & "#" & tr(4).Value
                st.Append(st1)
                res = st.ToString
            ElseIf dis(0) = 2 Then
                tr(0) = New OracleParameter("usr_id", OracleType.VarChar, 50)
                tr(0).Direction = ParameterDirection.Input
                tr(0).Value = Me.Session("user_id")
                tr(1) = New OracleParameter("id", OracleType.Number, 1)
                tr(1).Direction = ParameterDirection.Input
                tr(1).Value = 2
                tr(2) = New OracleParameter("str", OracleType.VarChar, 500)
                tr(2).Direction = ParameterDirection.Input
                tr(2).Value = dis(1)
                tr(3) = New OracleParameter("flag", OracleType.Number, 2)
                tr(3).Direction = ParameterDirection.Output
                tr(4) = New OracleParameter("msg", OracleType.VarChar, 500)
                tr(4).Direction = ParameterDirection.Output
                tr(5) = New OracleParameter("str1", OracleType.VarChar, 4000)
                tr(5).Direction = ParameterDirection.Output
                oh.ExecuteNonQuery("HRM_LEAVE_SANC_REJ", tr)
                a = tr(3).Value
                st1 = 1 & "#" & tr(3).Value & "#" & tr(4).Value
                st.Append(st1)
                res = st.ToString
            ElseIf dis(0) = 3 Then
                tr(0) = New OracleParameter("usr_id", OracleType.VarChar, 50)
                tr(0).Direction = ParameterDirection.Input
                tr(0).Value = Me.Session("user_id")
                tr(1) = New OracleParameter("id", OracleType.Number, 1)
                tr(1).Direction = ParameterDirection.Input
                tr(1).Value = 4
                tr(2) = New OracleParameter("str", OracleType.VarChar, 500)
                tr(2).Direction = ParameterDirection.Input
                tr(2).Value = dis(1)
                tr(3) = New OracleParameter("flag", OracleType.Number, 2)
                tr(3).Direction = ParameterDirection.Output
                tr(4) = New OracleParameter("msg", OracleType.VarChar, 500)
                tr(4).Direction = ParameterDirection.Output
                tr(5) = New OracleParameter("str1", OracleType.VarChar, 4000)
                tr(5).Direction = ParameterDirection.Output
                oh.ExecuteNonQuery("HRM_LEAVE_SANC_REJ", tr)
                a = tr(3).Value
                st1 = 1 & "#" & tr(3).Value & "#" & tr(4).Value
                st.Append(st1)
                res = st.ToString

            ElseIf dis(0) = 4 Then
                Dim leavesequence = dis(1).ToString.Split("*")(1)
                Dim emp = dis(1).ToString.Split("*")(0)
                Dim dt As DataTable = oh.ExecuteDataSet("select count(*) from macdms.hrm_app_leave_support where emp_code=" & emp & " and leav_seq=" & leavesequence).Tables(0)
                st.Append(dt.Rows(0)(0))
                res = st.ToString
            End If
        Catch ex As Exception
            st1 = 2 & "#" & tr(3).Value & "#" & ex.Message
            res = st.ToString
        End Try
    End Sub

    Protected Sub rdbBr_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbBr.CheckedChanged
        Dim usr() As String = Me.Session("user_id").ToString.Split("!")
        '   res = call_proc()
        'usr = 10584

        Dim dt As DataTable
        Dim fr As Integer = Me.Session("firm_id")
        If rdbBr.Checked = True And rdbSanc.Checked = True Then
            Me.cmd_rec.Visible = False
            Me.cmb_acc.Visible = True
            Me.rdbHo.Checked = False
            'Me.rdbrec.Checked = False
            ' Me.Chk_sac.Checked = False
            res = call_proc(1)
            If res = 1 Then
                dt = oh.ExecuteDataSet("select '0', '--SELECT--' as empcode from dual union select s.emp_code || '*' || emp_name || '*' || leave_id || '*' ||to_char(leave_frdate, 'dd-MON-yyyy') || '*' ||to_char(leave_todate, 'dd-MON-yyyy') || '*' || leave_days || '*' ||TO_CHAR(leave_apply_date, 'DD/MON/YYYY- HH12:MI:SS AM') || '*' ||leave_reason || '*' || s.branch_id || '*' || post_id || '*' ||total_leave_month || '*' || total_leave_day || '*' || leave_seq || '*' ||recom_reason || '*' || recom_name || '*' || recom_post || '*' ||to_char(actual_from, 'dd-MON-yyyy') || '*' || to_char(actual_to, 'dd-MON-yyyy') || '*' || recom_dt,s.emp_code || '   -   ' || to_char(leave_frdate, 'dd-MON-yyyy') ||'   -   ' || to_char(leave_todate, 'dd-MON-yyyy') || '  -  ' ||to_char(leave_apply_date, 'dd-MON-yyyy') || '  -  ' || emp_name as empcode from hrm_leave_application s where s.sanc_code = " & usr(0) & " and s.branch_id<>0 order by empcode").Tables(0)
                Me.cmb_leave.DataSource = dt
                Me.cmb_leave.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_leave.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_leave.DataBind()
            End If
            ' Me.cmd_rec.Visible = False
        ElseIf rdbBr.Checked = True And rdbRec.Checked = True Then
            Me.rdbHo.Checked = False
            'Me.rdbrec.Checked = False
            ' Me.Chk_sac.Checked = False
            res = call_proc(2)
            If res = 1 Then
                dt = oh.ExecuteDataSet("select '0', '--SELECT--' as empcode from dual union select s.emp_code || '*' || emp_name || '*' || leave_id || '*' ||to_char(leave_frdate, 'dd-MON-yyyy') || '*' ||to_char(leave_todate, 'dd-MON-yyyy') || '*' || leave_days || '*' ||TO_CHAR(leave_apply_date, 'DD/MON/YYYY- HH12:MI:SS AM') || '*' ||leave_reason || '*' || s.branch_id || '*' || post_id || '*' ||total_leave_month || '*' || total_leave_day || '*' || leave_seq || '*' ||recom_reason || '*' || recom_name || '*' || recom_post || '*' ||to_char(actual_from, 'dd-MON-yyyy') || '*' || to_char(actual_to, 'dd-MON-yyyy') || '*' || recom_dt,s.emp_code || '   -   ' || to_char(leave_frdate, 'dd-MON-yyyy') ||'   -   ' || to_char(leave_todate, 'dd-MON-yyyy') || '  -  ' ||to_char(leave_apply_date, 'dd-MON-yyyy') || '  -  ' || emp_name as empcode from hrm_leave_application s where s.sanc_code = " & usr(0) & " and s.branch_id<>0 order by empcode").Tables(0)
                Me.cmb_leave.DataSource = dt
                Me.cmb_leave.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_leave.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_leave.DataBind()
            End If
            Me.cmb_acc.Visible = False
            Me.cmd_rec.Visible = True
        ElseIf rdbHo.Checked = False Then
            rdbBr.Checked = True
        End If
    End Sub

    Protected Sub rdbHo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbHo.CheckedChanged
        Dim usr() As String = Me.Session("user_id").ToString.Split("!")
        Dim dt As DataTable
        ' res = call_proc()
        'usr = 10584
        If res = 1 Then
            'usr = 10584
            Dim fr As Integer = Me.Session("firm_id")
            If rdbHo.Checked = True And rdbRec.Checked = True Then
                Me.rdbBr.Checked = False
                res = call_proc(2)
                If res = 1 Then
                    dt = oh.ExecuteDataSet("select '0', '--SELECT--' as empcode from dual union select s.emp_code || '*' || emp_name || '*' || leave_id || '*' ||to_char(leave_frdate, 'dd-MON-yyyy') || '*' ||to_char(leave_todate, 'dd-MON-yyyy') || '*' || leave_days || '*' ||TO_CHAR(leave_apply_date, 'DD/MON/YYYY- HH12:MI:SS AM') || '*' ||leave_reason || '*' || s.branch_id || '*' || post_id || '*' ||total_leave_month || '*' || total_leave_day || '*' || leave_seq || '*' ||recom_reason || '*' || recom_name || '*' || recom_post || '*' ||to_char(actual_from, 'dd-MON-yyyy') || '*' || to_char(actual_to, 'dd-MON-yyyy') || '*' || recom_dt,s.emp_code || '   -   ' || to_char(leave_frdate, 'dd-MON-yyyy') ||'   -   ' || to_char(leave_todate, 'dd-MON-yyyy') || '  -  ' ||to_char(leave_apply_date, 'dd-MON-yyyy') || '  -  ' || emp_name as empcode from hrm_leave_application s where s.sanc_code = " & usr(0) & " and s.branch_id=0 order by empcode").Tables(0)
                    Me.cmb_leave.DataSource = dt
                    Me.cmb_leave.DataTextField = dt.Columns(1).ColumnName
                    Me.cmb_leave.DataValueField = dt.Columns(0).ColumnName
                    Me.cmb_leave.DataBind()
                End If
                Me.cmb_acc.Visible = False
                Me.cmd_rec.Visible = True
            ElseIf rdbHo.Checked = True And rdbSanc.Checked = True Then
                Me.rdbBr.Checked = False
                res = call_proc(1)
                If res = 1 Then
                    'Me.rdbrec.Checked = False
                    ' Me.Chk_sac.Checked = False
                    dt = oh.ExecuteDataSet("select '0', '--SELECT--' as empcode from dual union select s.emp_code || '*' || emp_name || '*' || leave_id || '*' ||to_char(leave_frdate, 'dd-MON-yyyy') || '*' ||to_char(leave_todate, 'dd-MON-yyyy') || '*' || leave_days || '*' ||TO_CHAR(leave_apply_date, 'DD/MON/YYYY- HH12:MI:SS AM') || '*' ||leave_reason || '*' || s.branch_id || '*' || post_id || '*' ||total_leave_month || '*' || total_leave_day || '*' || leave_seq || '*' ||recom_reason || '*' || recom_name || '*' || recom_post || '*' ||to_char(actual_from, 'dd-MON-yyyy') || '*' || to_char(actual_to, 'dd-MON-yyyy') || '*' || recom_dt,s.emp_code || '   -   ' || to_char(leave_frdate, 'dd-MON-yyyy') ||'   -   ' || to_char(leave_todate, 'dd-MON-yyyy') || '  -  ' ||to_char(leave_apply_date, 'dd-MON-yyyy') || '  -  ' || emp_name as empcode from hrm_leave_application s where s.sanc_code = " & usr(0) & " and s.branch_id=0 order by empcode").Tables(0)
                    Me.cmb_leave.DataSource = dt
                    Me.cmb_leave.DataTextField = dt.Columns(1).ColumnName
                    Me.cmb_leave.DataValueField = dt.Columns(0).ColumnName
                    Me.cmb_leave.DataBind()
                End If
                Me.cmd_rec.Visible = False
                Me.cmb_acc.Visible = True

            ElseIf rdbBr.Checked = False Then
                rdbHo.Checked = True
            End If
        End If
        'End If
    End Sub

    Protected Sub rdbRec_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbRec.CheckedChanged
        Dim usr() As String = Me.Session("user_id").ToString.Split("!")
        Dim dt As DataTable
        'Dim usr As Integer
        Dim fr As Integer = Me.Session("firm_id")
        If rdbRec.Checked = True And rdbBr.Checked = True Then
            res = call_proc(2)
            Me.rdbSanc.Checked = False
            If res = 1 Then
                dt = oh.ExecuteDataSet("select '0', '--SELECT--' as empcode  from dual union select s.emp_code || '*' || emp_name || '*' || leave_id || '*' ||   to_char(leave_frdate, 'dd-MON-yyyy') || '*' ||   to_char(leave_todate, 'dd-MON-yyyy') || '*' || leave_days || '*' ||   TO_CHAR(leave_apply_date, 'DD/MON/YYYY- HH12:MI:SS AM') || '*' ||   leave_reason || '*' || s.branch_id || '*' || post_id || '*' ||   total_leave_month || '*' || total_leave_day || '*' || leave_seq || '*' ||   recom_reason || '*' || recom_name || '*' || recom_post || '*' ||   to_char(actual_from, 'dd-MON-yyyy') || '*' ||   to_char(actual_to, 'dd-MON-yyyy') || '*' || recom_dt || '*' || ll.cl || '*' ||   ll.sl || '*' || ll.el,   s.emp_code || '  -  ' || to_char(leave_frdate, 'dd-MON-yyyy') ||   '  -  ' || to_char(leave_todate, 'dd-MON-yyyy') || '  -  ' ||   to_char(leave_apply_date, 'dd-MON-yyyy') || '  -  ' || emp_name as empcode  from hrm_leave_application s,   leave_sanction_authority t,   (select x1.emp_code,   x1.leave_days cl,   x2.leave_days sl,   x3.leave_days el  from (select a.emp_code, a.leave_days   from employ_leave_master a   where a.leave_id = 1) x1,   (select a.emp_code, a.leave_days   from employ_leave_master a   where a.leave_id = 2) x2,   (select a.emp_code, a.leave_days   from employ_leave_master a   where a.leave_id = 3) x3    where x1.emp_code = x2.emp_code    and x1.emp_code = x3.emp_code) ll where s.emp_code = t.emp_code  and t.l_rec_by = s.sanc_code  and s.sanc_code = " & usr(0) & "  and s.emp_code = ll.emp_code(+)  and s.leave_days between t.f_days and t.t_days  and s.branch_id <> 0 order by empcode").Tables(0)
                Me.cmb_leave.DataSource = dt
                Me.cmb_leave.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_leave.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_leave.DataBind()
            End If
            Me.cmb_acc.Visible = False
            Me.cmd_rec.Visible = True

        ElseIf rdbRec.Checked = True And rdbHo.Checked = True Then

            Me.rdbSanc.Checked = False
            Me.cmb_acc.Visible = False
            Me.cmd_rec.Visible = True
            res = call_proc(2)
            If res = 1 Then
                dt = oh.ExecuteDataSet("select '0', '--SELECT--' as empcode from dual union select s.emp_code || '*' || emp_name || '*' || leave_id || '*' ||  to_char(leave_frdate, 'dd-MON-yyyy') || '*' ||  to_char(leave_todate, 'dd-MON-yyyy') || '*' || leave_days || '*' ||  TO_CHAR(leave_apply_date, 'DD/MON/YYYY- HH12:MI:SS AM') || '*' ||  leave_reason || '*' || s.branch_id || '*' || post_id || '*' ||  total_leave_month || '*' || total_leave_day || '*' || leave_seq || '*' ||  recom_reason || '*' || recom_name || '*' || recom_post || '*' ||  to_char(actual_from, 'dd-MON-yyyy') || '*' ||  to_char(actual_to, 'dd-MON-yyyy') || '*' || recom_dt|| '*' || ll.cl || '*' ||  ll.sl || '*' || ll.el,  s.emp_code || '  -  ' || to_char(leave_frdate, 'dd-MON-yyyy') ||  '  -  ' || to_char(leave_todate, 'dd-MON-yyyy') || ' - ' ||  to_char(leave_apply_date, 'dd-MON-yyyy') || ' - ' || emp_name as empcode from hrm_leave_application s, (select x1.emp_code, x1.leave_days cl, x2.leave_days sl, x3.leave_days el   from (select a.emp_code, a.leave_days   from employ_leave_master a   where a.leave_id = 1) x1, (select a.emp_code, a.leave_days   from employ_leave_master a   where a.leave_id = 2) x2, (select a.emp_code, a.leave_days   from employ_leave_master a   where a.leave_id = 3) x3   where x1.emp_code = x2.emp_code  and x1.emp_code = x3.emp_code) ll where s.sanc_code = " & usr(0) & " and s.emp_code = ll.emp_code(+)  and s.branch_id = 0 order by empcode").Tables(0)
                Me.cmb_leave.DataSource = dt
                Me.cmb_leave.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_leave.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_leave.DataBind()
            End If
        ElseIf rdbSanc.Checked = False Then
            rdbRec.Checked = True
        End If
    End Sub

    Protected Sub rdbSanc_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbSanc.CheckedChanged
        Dim usr() As String = Me.Session("user_id").ToString.Split("!")
        Dim dt As DataTable
      
        'usr = 10584
        'usr = 10584
        Dim fr As Integer = Me.Session("firm_id")
        If rdbSanc.Checked = True And rdbBr.Checked = True Then

            Me.rdbRec.Checked = False
            ' Me.Chk_sac.Checked = False
            res = call_proc(1)
            If res = 1 Then
                dt = oh.ExecuteDataSet("select '0', '--SELECT--' as empcode from dual union select s.emp_code || '*' || emp_name || '*' || leave_id || '*' ||  to_char(leave_frdate, 'dd-MON-yyyy') || '*' ||  to_char(leave_todate, 'dd-MON-yyyy') || '*' || leave_days || '*' ||  TO_CHAR(leave_apply_date, 'DD/MON/YYYY- HH12:MI:SS AM') || '*' ||  leave_reason || '*' || s.branch_id || '*' || post_id || '*' ||  total_leave_month || '*' || total_leave_day || '*' || leave_seq || '*' ||  recom_reason || '*' || recom_name || '*' || recom_post || '*' ||  to_char(actual_from, 'dd-MON-yyyy') || '*' ||  to_char(actual_to, 'dd-MON-yyyy') || '*' || recom_dt || '*' || ll.cl || '*' ||  ll.sl || '*' || ll.el,  s.emp_code || '  -  ' || to_char(leave_frdate, 'dd-MON-yyyy') ||  '  -  ' || to_char(leave_todate, 'dd-MON-yyyy') || ' - ' ||  to_char(leave_apply_date, 'dd-MON-yyyy') || ' - ' || emp_name as empcode from hrm_leave_application s,  (select x1.emp_code, x1.leave_days cl, x2.leave_days sl, x3.leave_days el   from (select a.emp_code, a.leave_days   from employ_leave_master a   where a.leave_id = 1) x1, (select a.emp_code, a.leave_days   from employ_leave_master a   where a.leave_id = 2) x2, (select a.emp_code, a.leave_days   from employ_leave_master a   where a.leave_id = 3) x3   where x1.emp_code = x2.emp_code  and x1.emp_code = x3.emp_code) ll where s.sanc_code = " & usr(0) & "   and s.emp_code = ll.emp_code(+) and s.branch_id <> 0 order by empcode").Tables(0)
                Me.cmb_leave.DataSource = dt
                Me.cmb_leave.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_leave.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_leave.DataBind()
            End If

            Me.cmd_rec.Visible = False
            Me.cmb_acc.Visible = True

        ElseIf rdbSanc.Checked = True And rdbHo.Checked = True Then
            Me.rdbRec.Checked = False
            ' Me.Chk_sac.Checked = False
            res = call_proc(1)
            If res = 1 Then
                dt = oh.ExecuteDataSet("select '0', '--SELECT--' as empcode from dual union select s.emp_code || '*' || emp_name || '*' || leave_id || '*' ||  to_char(leave_frdate, 'dd-MON-yyyy') || '*' ||  to_char(leave_todate, 'dd-MON-yyyy') || '*' || leave_days || '*' ||  TO_CHAR(leave_apply_date, 'DD/MON/YYYY- HH12:MI:SS AM') || '*' ||  leave_reason || '*' || s.branch_id || '*' || post_id || '*' ||  total_leave_month || '*' || total_leave_day || '*' || leave_seq || '*' ||  recom_reason || '*' || recom_name || '*' || recom_post || '*' ||  to_char(actual_from, 'dd-MON-yyyy') || '*' ||  to_char(actual_to, 'dd-MON-yyyy') || '*' || recom_dt || '*' || ll.cl || '*' ||  ll.sl || '*' || ll.el,  s.emp_code || ' - ' || to_char(leave_frdate, 'dd-MON-yyyy') ||  ' - ' || to_char(leave_todate, 'dd-MON-yyyy') || ' - ' ||  to_char(leave_apply_date, 'dd-MON-yyyy') || ' - ' || emp_name as empcode from hrm_leave_application s,  (select x1.emp_code, x1.leave_days cl, x2.leave_days sl, x3.leave_days el   from (select a.emp_code, a.leave_days   from employ_leave_master a   where a.leave_id = 1) x1, (select a.emp_code, a.leave_days   from employ_leave_master a   where a.leave_id = 2) x2, (select a.emp_code, a.leave_days   from employ_leave_master a   where a.leave_id = 3) x3   where x1.emp_code = x2.emp_code  and x1.emp_code = x3.emp_code) ll where s.sanc_code = " & usr(0) & "  and s.emp_code = ll.emp_code(+)  and s.branch_id = 0 order by empcode").Tables(0)
                Me.cmb_leave.DataSource = dt
                Me.cmb_leave.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_leave.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_leave.DataBind()
            End If
            Me.cmd_rec.Visible = False
            Me.cmb_acc.Visible = True
            ElseIf rdbRec.Checked = False Then
                rdbSanc.Checked = True
            End If
    End Sub
    Function call_proc(ByVal tp As Integer)
        Me.cmb_leave.DataSource = Nothing
        Me.cmb_leave.Items.Clear()
        Dim tr(2) As OracleParameter
        tr(0) = New OracleParameter("usr_id", OracleType.VarChar, 50)
        tr(0).Direction = ParameterDirection.Input
        tr(0).Value = Me.Session("user_id")
        tr(1) = New OracleParameter("tpid", OracleType.Number, 1)
        tr(1).Direction = ParameterDirection.Input
        tr(1).Value = tp
        tr(2) = New OracleParameter("flag", OracleType.Number, 2)
        tr(2).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("hrm_leave_access_author_new", tr)
        Dim flg As Integer
        flg = tr(2).Value
        Return flg
    End Function

    'Protected Sub cmb_leave_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_leave.SelectedIndexChanged
    '    Dim dt As DataTable
    '    Panel1.Visible = True
    '    Dim sql As String
    '    sql = "select t.emp_code,t.leave_id,t.leave_days from employ_leave_master t where t.emp_code=100006"
    '    dt = oh.ExecuteDataSet(sql).Tables(0)
    'End Sub
End Class

Imports System.Data
Imports System.Data.OracleClient
Partial Class leave_postwise_sanction_be0310eb1214
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql As String
    Dim res As String
    Dim dt1 As DataTable


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Dim script_val As String
            script_val = "var loanno;" & "loanno='" & "" & Me.txt_frdt.ClientID & "'" & " ; "
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
            Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "sub_call_receiver", "context")
            Dim cbscript As String = "function sub_call_server(arg,context) { " & cbref & "; } "
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "sub_call_server", cbscript, True)
            CType(Me.Master, WebAppHRMS.edp).Subtitle = "LEAVE SANCTION"

            If Not IsPostBack Then
                rdbHo.Checked = False
                rdbBr.Checked = False
                rdbRec.Checked = False
                rdbRec1.Checked = False
                rdbSanc.Checked = False
                rdbHo.Checked = True
                Dim usr = Session("user_id").ToString.Split("!")
                txtEmpcode.Text = usr(0)
                'If usr(0) = 10001 Then
                '    Me.cmd_rec.Disabled = True
                'End If

                Me.cmd_applnform.Disabled = False
                Me.cmd_support.Disabled = False
                Me.cmd_pl28.Disabled = False
                Me.cmb_acc.Visible = False
                Me.Label1.Text = ""

                'res = call_proc(1)

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
                'pnlReco_reason.Visible = False
                'fill_data(res)

            End If
        Catch ex As Exception
            Me.Label1.Text = ex.Message
        End Try

        cmb_leave.Items.Remove(cmb_leave.SelectedItem)
        cmb_leave.SelectedIndex = -1

        Dim sc As String = "var cont_name;cont_name='" & Me.txt_name.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var2", sc, True)
        Me.Checkbox1.Attributes.Add("onclick", "OnCheck()")
        Me.txt_ParFrDt.Attributes.Add("onkeyup", "OnkeyUpChqDate1()")
        Me.txt_ParToDt.Attributes.Add("onkeyup", "OnkeyUpChqDate()")
    End Sub

    Protected Sub rdbBr_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbBr.CheckedChanged
        Try
            cmb_leave.Items.Clear()
            cmb_leave.SelectedIndex = -1
            rdbRec.Checked = False
            rdbRec1.Checked = False
            rdbSanc.Checked = False
            clear_data()
        Catch ex As Exception
            Me.Label1.Text = ex.Message
        End Try
    End Sub

    Protected Sub rdbHo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbHo.CheckedChanged
        Try
            cmb_leave.Items.Clear()
            cmb_leave.SelectedIndex = -1
            rdbRec.Checked = False
            rdbRec1.Checked = False
            rdbSanc.Checked = False
            clear_data()
        Catch ex As Exception
            Me.Label1.Text = ex.Message
        End Try
    End Sub


    Function call_proc(ByVal tp As Integer)
        try
        Dim u As String = Me.Session("user_id")
        Me.cmb_leave.DataSource = Nothing
        Me.cmb_leave.Items.Clear()
        Dim tr(3) As OracleParameter
        tr(0) = New OracleParameter("usr_id", OracleType.VarChar, 50)
        tr(0).Direction = ParameterDirection.Input
        tr(0).Value = Me.Session("user_id")
        tr(1) = New OracleParameter("tpid", OracleType.Number, 1)
        tr(1).Direction = ParameterDirection.Input
        tr(1).Value = tp

        tr(2) = New OracleParameter("branch", OracleType.Number, 1)
        tr(2).Direction = ParameterDirection.Input
        If rdbHo.Checked = True Then
            tr(2).Value = 0
        Else
            tr(2).Value = 1
        End If

        tr(3) = New OracleParameter("flag", OracleType.Number, 2)
        tr(3).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("hrm_leave_sanc_auth_new", tr)
        Dim flg As Integer
        flg = tr(3).Value
            Return flg
        Catch ex As Exception
            Me.Label1.Text = ex.Message
        End Try
    End Function

    Sub clear_data()
        txt_name.Value = ""
        txt_dur.Value = ""
        txt_appdt.Value = ""
        txt_frdt.Value = ""
        txt_todt.Value = ""
        txt_reason.Value = ""
        cmb_branch.SelectedIndex = -1
        cmb_post.SelectedIndex = -1
        txt_tot_mon.Value = ""
        txt_leave_day.Value = ""
        txt_recom_reason.Value = ""
        txt_rec_by.Value = ""

        txt_ReqFrDt.Text = ""
        txt_ReqToDt.Text = ""
        txt_ParFrDt.Text = ""
        txt_ParToDt.Text = ""
        txt_req_days.Text = ""
        txt_par_days.Text = ""
        txt_RecDate.Text = ""
        txt_ltyp.Value = ""
        txt_cas.Value = ""
        txt_sik.Value = ""
        txt_earn.Value = ""
    End Sub

    Protected Sub rdbRec1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbRec1.CheckedChanged
        'Checking logged in person's post id available in First Recommend.
        Try
            Me.cmb_acc.Visible = False
            Me.cmd_rec.Visible = True

            pnlReco_reason.Visible = True
            cmb_leave.Items.Clear()
            cmb_leave.SelectedIndex = -1
            clear_data()

            Dim dtCheck, dt As DataTable
            Dim loginPost As Integer
            Dim auth_count As Integer = 0

            Dim fr As Integer = Me.Session("firm_id")
            If rdbRec1.Checked = True And rdbBr.Checked = True Then


                Dim usr() As String = Me.Session("user_id").ToString.Split("!")
                dt = oh.ExecuteDataSet("select count(t.rec1) from leave_auth_list_new t where t.category_no=1 and t.firm_id=" & fr & " and t.rec1=" & usr(0) & "").Tables(0)
                auth_count = dt.Rows(0)(0)

                If auth_count <> 0 Then
                    res = call_proc(1)
                    cmb_leave.Enabled = True
                    Dim dt0 As DataTable
                    dt0 = oh.ExecuteDataSet("select '0', '--SELECT--' as empcode from dual union select s.emp_code || '*' || emp_name || '*' || leave_id || '*' ||  to_char(leave_frdate, 'dd-MON-yyyy') || '*' ||  to_char(leave_todate, 'dd-MON-yyyy') || '*' || leave_days || '*' ||  TO_CHAR(leave_apply_date, 'DD/MON/YYYY- HH12:MI:SS AM') || '*' ||  leave_reason || '*' || s.branch_id || '*' || post_id || '*' ||  total_leave_month || '*' || total_leave_day || '*' || leave_seq || '*' ||  recom_reason || '*' || recom_name || '*' || recom_post || '*' ||  to_char(actual_from, 'dd-MON-yyyy') || '*' ||  to_char(actual_to, 'dd-MON-yyyy') || '*' || recom_dt || '*' || ll.cl || '*' ||  ll.sl || '*' || ll.el,  s.emp_code || '  -  ' || to_char(leave_frdate, 'dd-MON-yyyy') ||  '  -  ' || to_char(leave_todate, 'dd-MON-yyyy') || ' - ' ||  to_char(leave_apply_date, 'dd-MON-yyyy') || ' - ' || emp_name as empcode from hrm_leave_application s,  (select x1.emp_code, x1.leave_days cl, x2.leave_days sl, x3.leave_days el   from (select a.emp_code, a.leave_days   from employ_leave_master a   where a.leave_id = 1) x1, (select a.emp_code, a.leave_days   from employ_leave_master a   where a.leave_id = 2) x2, (select a.emp_code, a.leave_days   from employ_leave_master a   where a.leave_id = 3) x3   where x1.emp_code = x2.emp_code  and x1.emp_code = x3.emp_code) ll where s.sanc_code = " & txtEmpcode.Text & "  and s.emp_code = ll.emp_code(+)   and s.branch_id <> 0 order by empcode ").Tables(0)
                    Me.cmb_leave.DataSource = dt0
                    Me.cmb_leave.DataTextField = dt0.Columns(1).ColumnName
                    Me.cmb_leave.DataValueField = dt0.Columns(0).ColumnName
                    Me.cmb_leave.DataBind()
                Else
                    cmb_leave.Enabled = False
                End If

            ElseIf rdbRec1.Checked = True And rdbHo.Checked = True Then
                Dim usr() As String = Me.Session("user_id").ToString.Split("!")
                dt = oh.ExecuteDataSet("select count(t.rec1) from leave_auth_list_new t where t.category_no=1 and t.firm_id=" & fr & " and t.rec1=" & usr(0) & "").Tables(0)
                auth_count = dt.Rows(0)(0)

                If auth_count <> 0 Then
                    res = call_proc(1)
                    cmb_leave.Enabled = True
                    Dim dt0 As DataTable
                    dt0 = oh.ExecuteDataSet("select '0', '--SELECT--' as empcode from dual union select s.emp_code || '*' || emp_name || '*' || leave_id || '*' ||  to_char(leave_frdate, 'dd-MON-yyyy') || '*' ||  to_char(leave_todate, 'dd-MON-yyyy') || '*' || leave_days || '*' ||  TO_CHAR(leave_apply_date, 'DD/MON/YYYY- HH12:MI:SS AM') || '*' ||  leave_reason || '*' || s.branch_id || '*' || post_id || '*' ||  total_leave_month || '*' || total_leave_day || '*' || leave_seq || '*' ||  recom_reason || '*' || recom_name || '*' || recom_post || '*' ||  to_char(actual_from, 'dd-MON-yyyy') || '*' ||  to_char(actual_to, 'dd-MON-yyyy') || '*' || recom_dt || '*' || ll.cl || '*' ||  ll.sl || '*' || ll.el,  s.emp_code || '  -  ' || to_char(leave_frdate, 'dd-MON-yyyy') ||  '  -  ' || to_char(leave_todate, 'dd-MON-yyyy') || ' - ' ||  to_char(leave_apply_date, 'dd-MON-yyyy') || ' - ' || emp_name as empcode from hrm_leave_application s,  (select x1.emp_code, x1.leave_days cl, x2.leave_days sl, x3.leave_days el   from (select a.emp_code, a.leave_days   from employ_leave_master a   where a.leave_id = 1) x1, (select a.emp_code, a.leave_days   from employ_leave_master a   where a.leave_id = 2) x2, (select a.emp_code, a.leave_days   from employ_leave_master a   where a.leave_id = 3) x3   where x1.emp_code = x2.emp_code  and x1.emp_code = x3.emp_code) ll where s.sanc_code = " & txtEmpcode.Text & "  and s.emp_code = ll.emp_code(+)   and s.branch_id = 0 order by empcode ").Tables(0)
                    Me.cmb_leave.DataSource = dt0
                    Me.cmb_leave.DataTextField = dt0.Columns(1).ColumnName
                    Me.cmb_leave.DataValueField = dt0.Columns(0).ColumnName
                    Me.cmb_leave.DataBind()
                Else
                    cmb_leave.Enabled = False
                End If
            End If
        Catch ex As Exception
            Me.Label1.Text = ex.Message
        End Try
    End Sub


    Protected Sub rdbRec_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbRec.CheckedChanged
        'pnlReco_reason.Visible = False
        Try
            Me.cmb_acc.Visible = False
            Me.cmd_rec.Visible = True

            Dim usr() As String = Me.Session("user_id").ToString.Split("!")
            cmb_leave.Items.Clear()
            cmb_leave.SelectedIndex = -1
            clear_data()


            Dim dtCheck, dt As DataTable
            Dim loginPost As Integer
            Dim auth_count As Integer = 0

            Dim fr As Integer = Me.Session("firm_id")

            If rdbRec.Checked = True And rdbBr.Checked = True Then

                dt = oh.ExecuteDataSet("select count(t.rec2) from leave_auth_list_new t where t.category_no=1 and t.firm_id=" & fr & " and t.rec2=" & usr(0) & "").Tables(0)
                auth_count = dt.Rows(0)(0)

                If auth_count <> 0 Then
                    res = call_proc(2)
                    cmb_leave.Enabled = True
                    Dim dt0 As DataTable
                    dt0 = oh.ExecuteDataSet("select '0', '--SELECT--' as empcode from dual union select s.emp_code || '*' || emp_name || '*' || leave_id || '*' ||  to_char(leave_frdate, 'dd-MON-yyyy') || '*' ||  to_char(leave_todate, 'dd-MON-yyyy') || '*' || leave_days || '*' ||  TO_CHAR(leave_apply_date, 'DD/MON/YYYY- HH12:MI:SS AM') || '*' ||  leave_reason || '*' || s.branch_id || '*' || post_id || '*' ||  total_leave_month || '*' || total_leave_day || '*' || leave_seq || '*' ||  recom_reason || '*' || recom_name || '*' || recom_post || '*' ||  to_char(actual_from, 'dd-MON-yyyy') || '*' ||  to_char(actual_to, 'dd-MON-yyyy') || '*' || recom_dt || '*' || ll.cl || '*' ||  ll.sl || '*' || ll.el,  s.emp_code || '  -  ' || to_char(leave_frdate, 'dd-MON-yyyy') ||  '  -  ' || to_char(leave_todate, 'dd-MON-yyyy') || ' - ' ||  to_char(leave_apply_date, 'dd-MON-yyyy') || ' - ' || emp_name as empcode from hrm_leave_application s,  (select x1.emp_code, x1.leave_days cl, x2.leave_days sl, x3.leave_days el   from (select a.emp_code, a.leave_days   from employ_leave_master a   where a.leave_id = 1) x1, (select a.emp_code, a.leave_days   from employ_leave_master a   where a.leave_id = 2) x2, (select a.emp_code, a.leave_days   from employ_leave_master a   where a.leave_id = 3) x3   where x1.emp_code = x2.emp_code  and x1.emp_code = x3.emp_code) ll where s.sanc_code = " & txtEmpcode.Text & "  and s.emp_code = ll.emp_code(+)   and s.branch_id <> 0 order by empcode ").Tables(0)

                    Me.cmb_leave.DataSource = dt0
                    Me.cmb_leave.DataTextField = dt0.Columns(1).ColumnName
                    Me.cmb_leave.DataValueField = dt0.Columns(0).ColumnName
                    Me.cmb_leave.DataBind()
                Else
                    cmb_leave.Enabled = False
                End If

            ElseIf rdbRec.Checked = True And rdbHo.Checked = True Then
                dt = oh.ExecuteDataSet("select count(t.rec2) from leave_auth_list_new t where t.category_no=1 and t.firm_id=" & fr & " and t.rec2=" & usr(0) & "").Tables(0)
                auth_count = dt.Rows(0)(0)

                If auth_count <> 0 Then
                    res = call_proc(2)
                    cmb_leave.Enabled = True
                    Dim dt0 As DataTable
                    dt0 = oh.ExecuteDataSet("select '0', '--SELECT--' as empcode from dual union select s.emp_code || '*' || emp_name || '*' || leave_id || '*' ||  to_char(leave_frdate, 'dd-MON-yyyy') || '*' ||  to_char(leave_todate, 'dd-MON-yyyy') || '*' || leave_days || '*' ||  TO_CHAR(leave_apply_date, 'DD/MON/YYYY- HH12:MI:SS AM') || '*' ||  leave_reason || '*' || s.branch_id || '*' || post_id || '*' ||  total_leave_month || '*' || total_leave_day || '*' || leave_seq || '*' ||  recom_reason || '*' || recom_name || '*' || recom_post || '*' ||  to_char(actual_from, 'dd-MON-yyyy') || '*' ||  to_char(actual_to, 'dd-MON-yyyy') || '*' || recom_dt || '*' || ll.cl || '*' ||  ll.sl || '*' || ll.el,  s.emp_code || '  -  ' || to_char(leave_frdate, 'dd-MON-yyyy') ||  '  -  ' || to_char(leave_todate, 'dd-MON-yyyy') || ' - ' ||  to_char(leave_apply_date, 'dd-MON-yyyy') || ' - ' || emp_name as empcode from hrm_leave_application s,  (select x1.emp_code, x1.leave_days cl, x2.leave_days sl, x3.leave_days el   from (select a.emp_code, a.leave_days   from employ_leave_master a   where a.leave_id = 1) x1, (select a.emp_code, a.leave_days   from employ_leave_master a   where a.leave_id = 2) x2, (select a.emp_code, a.leave_days   from employ_leave_master a   where a.leave_id = 3) x3   where x1.emp_code = x2.emp_code  and x1.emp_code = x3.emp_code) ll where s.sanc_code = " & txtEmpcode.Text & "  and s.emp_code = ll.emp_code(+)   and s.branch_id = 0 order by empcode ").Tables(0)
                    Me.cmb_leave.DataSource = dt0
                    Me.cmb_leave.DataTextField = dt0.Columns(1).ColumnName
                    Me.cmb_leave.DataValueField = dt0.Columns(0).ColumnName
                    Me.cmb_leave.DataBind()
                Else
                    cmb_leave.Enabled = False
                End If
            End If
        Catch ex As Exception
            Me.Label1.Text = ex.Message
        End Try
    End Sub

    Protected Sub rdbSanc_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbSanc.CheckedChanged
        'pnlReco_reason.Visible = False
        Try
            Me.cmb_acc.Visible = True
            Me.cmd_rec.Visible = False

            Dim usr() As String = Me.Session("user_id").ToString.Split("!")
            cmb_leave.Items.Clear()
            cmb_leave.SelectedIndex = -1
            clear_data()


            Dim dtCheck, dt As DataTable
            Dim loginPost As Integer
            Dim auth_count As Integer = 0

            Dim fr As Integer = Me.Session("firm_id")

            If rdbSanc.Checked = True And rdbBr.Checked = True Then

                dt = oh.ExecuteDataSet("select count(t.sanction) from leave_auth_list_new t where t.category_no=1 and t.firm_id=" & fr & " and t.sanction=" & usr(0) & "").Tables(0)
                auth_count = dt.Rows(0)(0)

                If auth_count <> 0 Then
                    res = call_proc(3)
                    cmb_leave.Enabled = True
                    Dim dt0 As DataTable
                    dt0 = oh.ExecuteDataSet("select '0', '--SELECT--' as empcode from dual union select s.emp_code || '*' || emp_name || '*' || leave_id || '*' ||  to_char(leave_frdate, 'dd-MON-yyyy') || '*' ||  to_char(leave_todate, 'dd-MON-yyyy') || '*' || leave_days || '*' ||  TO_CHAR(leave_apply_date, 'DD/MON/YYYY- HH12:MI:SS AM') || '*' ||  leave_reason || '*' || s.branch_id || '*' || post_id || '*' ||  total_leave_month || '*' || total_leave_day || '*' || leave_seq || '*' ||  recom_reason || '*' || recom_name || '*' || recom_post || '*' ||  to_char(actual_from, 'dd-MON-yyyy') || '*' ||  to_char(actual_to, 'dd-MON-yyyy') || '*' || recom_dt || '*' || ll.cl || '*' ||  ll.sl || '*' || ll.el,  s.emp_code || '  -  ' || to_char(leave_frdate, 'dd-MON-yyyy') ||  '  -  ' || to_char(leave_todate, 'dd-MON-yyyy') || ' - ' ||  to_char(leave_apply_date, 'dd-MON-yyyy') || ' - ' || emp_name as empcode from hrm_leave_application s,  (select x1.emp_code, x1.leave_days cl, x2.leave_days sl, x3.leave_days el   from (select a.emp_code, a.leave_days   from employ_leave_master a   where a.leave_id = 1) x1, (select a.emp_code, a.leave_days   from employ_leave_master a   where a.leave_id = 2) x2, (select a.emp_code, a.leave_days   from employ_leave_master a   where a.leave_id = 3) x3   where x1.emp_code = x2.emp_code  and x1.emp_code = x3.emp_code) ll where s.sanc_code = " & txtEmpcode.Text & "  and s.emp_code = ll.emp_code(+)   and s.branch_id <> 0 order by empcode ").Tables(0)
                    Me.cmb_leave.DataSource = dt0
                    Me.cmb_leave.DataTextField = dt0.Columns(1).ColumnName
                    Me.cmb_leave.DataValueField = dt0.Columns(0).ColumnName
                    Me.cmb_leave.DataBind()
                Else
                    cmb_leave.Enabled = False
                End If

            ElseIf rdbSanc.Checked = True And rdbHo.Checked = True Then

                dt = oh.ExecuteDataSet("select count(t.sanction) from leave_auth_list_new t where t.category_no=1 and t.firm_id=" & fr & " and t.sanction=" & usr(0) & "").Tables(0)
                auth_count = dt.Rows(0)(0)

                If auth_count <> 0 Then
                    res = call_proc(3)
                    cmb_leave.Enabled = True
                    Dim dt0 As DataTable
                    dt0 = oh.ExecuteDataSet("select '0', '--SELECT--' as empcode from dual union select s.emp_code || '*' || emp_name || '*' || leave_id || '*' ||  to_char(leave_frdate, 'dd-MON-yyyy') || '*' ||  to_char(leave_todate, 'dd-MON-yyyy') || '*' || leave_days || '*' ||  TO_CHAR(leave_apply_date, 'DD/MON/YYYY- HH12:MI:SS AM') || '*' ||  leave_reason || '*' || s.branch_id || '*' || post_id || '*' ||  total_leave_month || '*' || total_leave_day || '*' || leave_seq || '*' ||  recom_reason || '*' || recom_name || '*' || recom_post || '*' ||  to_char(actual_from, 'dd-MON-yyyy') || '*' ||  to_char(actual_to, 'dd-MON-yyyy') || '*' || recom_dt || '*' || ll.cl || '*' ||  ll.sl || '*' || ll.el,  s.emp_code || '  -  ' || to_char(leave_frdate, 'dd-MON-yyyy') ||  '  -  ' || to_char(leave_todate, 'dd-MON-yyyy') || ' - ' ||  to_char(leave_apply_date, 'dd-MON-yyyy') || ' - ' || emp_name as empcode from hrm_leave_application s,  (select x1.emp_code, x1.leave_days cl, x2.leave_days sl, x3.leave_days el   from (select a.emp_code, a.leave_days   from employ_leave_master a   where a.leave_id = 1) x1, (select a.emp_code, a.leave_days   from employ_leave_master a   where a.leave_id = 2) x2, (select a.emp_code, a.leave_days   from employ_leave_master a   where a.leave_id = 3) x3   where x1.emp_code = x2.emp_code  and x1.emp_code = x3.emp_code) ll where s.sanc_code = " & txtEmpcode.Text & "  and s.emp_code = ll.emp_code(+)   and s.branch_id = 0 order by empcode ").Tables(0)
                    Me.cmb_leave.DataSource = dt0
                    Me.cmb_leave.DataTextField = dt0.Columns(1).ColumnName
                    Me.cmb_leave.DataValueField = dt0.Columns(0).ColumnName
                    Me.cmb_leave.DataBind()
                Else
                    cmb_leave.Enabled = False
                End If
            End If
        Catch ex As Exception
            Me.Label1.Text = ex.Message
        End Try
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
                If rdbRec1.Checked = True Then
                    'CODE CHANGE-------------------------------------------
                    'IF fIRST RECOMMEND------------------------------------
                    tr(1) = New OracleParameter("id", OracleType.Number, 1)
                    tr(1).Direction = ParameterDirection.Input
                    tr(1).Value = 5
                ElseIf rdbRec.Checked = True Then
                    'SECOND RECOMMEND--------------------------------------
                    tr(1) = New OracleParameter("id", OracleType.Number, 1)
                    tr(1).Direction = ParameterDirection.Input
                    tr(1).Value = 4
                End If


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



End Class

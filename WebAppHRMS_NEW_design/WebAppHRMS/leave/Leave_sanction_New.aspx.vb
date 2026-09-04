Imports System.Data
Imports System.Data.OracleClient
Partial Class leave_Leave_sanction_242da2281677
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim oh As New helper.oracle.oraclehelper
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
                Dim usr = Session("user_id").ToString.Split("!")
                If usr(0) = 10001 Then
                    Me.cmd_rec.Disabled = True

                End If
                Dim dt1 As DataTable = oh.ExecuteDataSet("select e.post_id,e.branch_id from employee_master e where e.emp_code=" & usr(0)).Tables(0)
                Dim dt2 As DataTable = oh.ExecuteDataSet("select count(*) from department_mst where dep_head in(select substr(head_id,0,5) from department_major union select substr(head_id,7,12) from department_major) and dep_head=" & usr(0)).Tables(0)
                Dim dt3 As DataTable = oh.ExecuteDataSet("select count(*) from department_major where substr(head_id,0,5)=" & usr(0) & " or substr(head_id,7,12)=" & usr(0)).Tables(0)
                If dt3.Rows(0)(0) > 0 Or dt2.Rows(0)(0) > 0 Or dt1.Rows(0)(0) = 173 Or usr(0) = 10001 Or usr(0) = 10002 Or usr(0) = 20006 Then
                    Me.cmd_applnform.Disabled = False
                    Me.cmd_support.Disabled = False
                    Me.cmd_pl28.Disabled = False
                Else
                    Me.cmd_applnform.Disabled = True
                    Me.cmd_support.Disabled = True
                    Me.cmd_pl28.Disabled = True
                End If
                Me.Label1.Text = ""
                Dim tr(1) As OracleParameter
                tr(0) = New OracleParameter("usr", OracleType.Number, 6)
                tr(0).Direction = ParameterDirection.Input
                tr(0).Value = usr(0)
                tr(1) = New OracleParameter("flag", OracleType.Number, 2)
                tr(1).Direction = ParameterDirection.Output
                oh.ExecuteNonQuery("hrmLeaveaccessmodify_new", tr)
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
                fill_data(tr(1).Value)
            End If
        Catch ex As Exception
            Me.Label1.Text = ex.Message
        End Try
        Dim sc As String = "var cont_name;cont_name='" & Me.txt_name.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var2", sc, True)
        Me.Checkbox1.Attributes.Add("onclick", "OnCheck()")
        Me.txt_ParFrDt.Attributes.Add("onkeyup", "OnkeyUpChqDate1()")
        Me.txt_ParToDt.Attributes.Add("onkeyup", "OnkeyUpChqDate()")
   End Sub
    Sub fill_data(ByVal b As Integer)
        Dim usr() As String = Me.Session("user_id").ToString.Split("!")
        If b = 1 Then
            Dim dt As DataTable
            dt = oh.ExecuteDataSet("select '0','--SELECT--' as empcode from dual union select emp_code||'*'||emp_name||'*'||leave_id||'*'||to_char(leave_frdate,'dd-MON-yyyy')||'*'||to_char(leave_todate,'dd-MON-yyyy')||'*'||leave_days||'*'||TO_CHAR(leave_apply_date  ,'DD/MON/YYYY- HH12:MI:SS AM')||'*'||leave_reason||'*'||branch_id||'*'||post_id||'*'||total_leave_month||'*'||total_leave_day||'*'||leave_seq||'*'||recom_reason||'*'||recom_name||'*'||recom_post||'*'||to_char(actual_from,'dd-MON-yyyy')||'*'||to_char(actual_to,'dd-MON-yyyy')||'*'||recom_dt,emp_code|| '   -   ' ||to_char(leave_frdate,'dd-MON-yyyy')||'   -   '||to_char(leave_todate,'dd-MON-yyyy')||'  -  '|| to_char(leave_apply_date,'dd-MON-yyyy')  ||'  -  '||emp_name as empcode from hrm_leave_application where sanc_code=" & usr(0) & " order by empcode").Tables(0)
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
        If dis(0) = 2 Then        'reject
            Dim tr(5) As OracleParameter
            Try
                Dim Instr() As String = dis(1).Split("*")
                Dim EmpCode As Integer = Instr(0)
                Dim LeavSeq As Integer = Instr(8)
                Dim Rej As String = Instr(9)

                tr(0) = New OracleParameter("usr_id", OracleType.Number, 6)
                tr(0).Direction = ParameterDirection.Input
                tr(0).Value = Me.Session("user_id").ToString.Split("!")(0)

                tr(1) = New OracleParameter("EmpCode", OracleType.Number, 6)
                tr(1).Direction = ParameterDirection.Input
                tr(1).Value = EmpCode

                tr(2) = New OracleParameter("LeavSeq", OracleType.Number, 10)
                tr(2).Direction = ParameterDirection.Input
                tr(2).Value = LeavSeq

                tr(3) = New OracleParameter("Rej", OracleType.VarChar, 100)
                tr(3).Direction = ParameterDirection.Input
                tr(3).Value = Rej

                tr(4) = New OracleParameter("flag", OracleType.Number, 2)
                tr(4).Direction = ParameterDirection.Output

                tr(5) = New OracleParameter("msg", OracleType.VarChar, 500)
                tr(5).Direction = ParameterDirection.Output


                oh.ExecuteNonQuery("hrm_Leave_reject_Process", tr)

                st1 = 1 & "#" & tr(4).Value & "#" & tr(5).Value
                st.Append(st1)
                res = st.ToString
            Catch ex As Exception
               
            End Try
        ElseIf dis(0) = 3 Then       'Recommend
            Dim tr(11) As OracleParameter
            Try
                Dim Instr() As String = dis(1).Split("*")
                Dim EmpCode As Integer = Instr(0)
                Dim EmpName As String = Instr(1)
                Dim LType As Integer
                If Instr(2) = "C/L" Then
                    LType = 1
                ElseIf Instr(2) = "S/L" Then
                    LType = 2
                ElseIf Instr(2) = "E/L" Then
                    LType = 3
                ElseIf Instr(2) = "LOP" Then
                    LType = 4
                ElseIf Instr(2) = "MAT" Then
                    LType = 10
                End If

                Dim PFromdt As Date = Instr(3)
                Dim PTodt As Date = Instr(4)
                Dim PDays As Integer = Instr(5)
                Dim AppDt As Date = Instr(6)
                Dim Reason As String = Instr(7)
                Dim LeavSeq As Integer = Instr(8)
                Dim TotLeave As Integer = Instr(9)
                Dim Rej As String = Instr(10)
                Dim FrDt As Date = Instr(11)
                Dim ToDt As Date = Instr(12)
                Dim Duration As Integer = Instr(13)

                tr(0) = New OracleParameter("userid", OracleType.Number, 50)
                tr(0).Direction = ParameterDirection.Input
                tr(0).Value = Me.Session("user_id").ToString.Split("!")(0)

                tr(1) = New OracleParameter("EmpCode", OracleType.Number, 6)
                tr(1).Direction = ParameterDirection.Input
                tr(1).Value = EmpCode

                tr(2) = New OracleParameter("leavetype", OracleType.Number, 3)
                tr(2).Direction = ParameterDirection.Input
                tr(2).Value = LType

                tr(3) = New OracleParameter("fromdt", OracleType.DateTime)
                tr(3).Direction = ParameterDirection.Input
                tr(3).Value = PFromdt

                tr(4) = New OracleParameter("todt", OracleType.DateTime)
                tr(4).Direction = ParameterDirection.Input
                tr(4).Value = PTodt

                tr(5) = New OracleParameter("LeaveSeq", OracleType.Number, 10)
                tr(5).Direction = ParameterDirection.Input
                tr(5).Value = LeavSeq

                tr(6) = New OracleParameter("reason", OracleType.VarChar, 100)
                tr(6).Direction = ParameterDirection.Input
                tr(6).Value = Rej

                tr(7) = New OracleParameter("actualfrdt", OracleType.DateTime)
                tr(7).Direction = ParameterDirection.Input
                tr(7).Value = FrDt

                tr(8) = New OracleParameter("actualtodt", OracleType.DateTime)
                tr(8).Direction = ParameterDirection.Input
                tr(8).Value = ToDt

                tr(9) = New OracleParameter("leavedays", OracleType.Number, 2)
                tr(9).Direction = ParameterDirection.Input
                tr(9).Value = Duration

                tr(10) = New OracleParameter("flag", OracleType.Number, 2)
                tr(10).Direction = ParameterDirection.Output

                tr(11) = New OracleParameter("msg", OracleType.VarChar, 500)
                tr(11).Direction = ParameterDirection.Output
              
                oh.ExecuteNonQuery("hrm_Leave_recom_Process", tr)

                a = tr(10).Value
                st1 = 1 & "#" & tr(10).Value & "#" & tr(11).Value
                st.Append(st1)
                res = st.ToString
            Catch ex As Exception
                st1 = 1 & "#0"
                st.Append(st1)
                res = st.ToString
            End Try

        ElseIf dis(0) = 4 Then
            Dim leavesequence = dis(1).ToString.Split("*")(1)
            Dim emp = dis(1).ToString.Split("*")(0)
            Dim dt As DataTable = oh.ExecuteDataSet("select count(*) from  dms.hrm_app_leave_support where emp_code=" & emp & " and leav_seq=" & leavesequence).Tables(0)
            st.Append(dt.Rows(0)(0))
            res = st.ToString
        End If
    End Sub
    Protected Sub cmb_acc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_acc.Click
        Dim User() As String
        User = Session("user_id").ToString.Split("!")
        Dim a As New Integer
        If Me.txt_name.Value <> "" Then
            If Me.Checkbox1.Checked = True Then
                Dim p(11) As OracleParameter
                Dim str As String = ""

                p(0) = New OracleParameter("EmpCode", OracleType.Number, 6)
                p(0).Direction = ParameterDirection.Input
                p(0).Value = Me.hid_empcode.Value
                Dim lid As Integer
                If Me.txt_ltyp.Value = "C/L" Then
                    lid = 1
                ElseIf Me.txt_ltyp.Value = "S/L" Then
                    lid = 2
                ElseIf Me.txt_ltyp.Value = "E/L" Then
                    lid = 3
                ElseIf Me.txt_ltyp.Value = "LOP" Then
                    lid = 4
                ElseIf Me.txt_ltyp.Value = "MAT" Then
                    lid = 10
                End If
                p(1) = New OracleParameter("leavetype", OracleType.Number, 15)
                p(1).Direction = ParameterDirection.Input
                p(1).Value = lid

                p(2) = New OracleParameter("fromdt", OracleType.DateTime)
                p(2).Direction = ParameterDirection.Input
                p(2).Value = Me.txt_ParFrDt.Text

                p(3) = New OracleParameter("todt", OracleType.DateTime)
                p(3).Direction = ParameterDirection.Input
                p(3).Value = Me.txt_ParToDt.Text

                p(4) = New OracleParameter("leavedays", OracleType.Number, 5)
                p(4).Direction = ParameterDirection.Input
                p(4).Value = Me.txt_par_days.Text

                p(5) = New OracleParameter("userid", OracleType.Number, 6)
                p(5).Direction = ParameterDirection.Input
                p(5).Value = User(0)

                p(6) = New OracleParameter("leaveseq", OracleType.Number, 10)
                p(6).Direction = ParameterDirection.Input
                p(6).Value = Me.hid_seq.Value

                p(7) = New OracleParameter("actualfrdt", OracleType.DateTime)
                p(7).Direction = ParameterDirection.Input
                p(7).Value = Me.txt_frdt.Value

                p(8) = New OracleParameter("actualtodt", OracleType.DateTime)
                p(8).Direction = ParameterDirection.Input
                p(8).Value = Me.txt_todt.Value

                p(9) = New OracleParameter("Applydt", OracleType.DateTime)
                p(9).Direction = ParameterDirection.Input
                p(9).Value = Me.txt_appdt.Value.Split("-")(0)

                p(10) = New OracleParameter("reason", OracleType.VarChar, 100)
                p(10).Direction = ParameterDirection.Input
                p(10).Value = Me.txt_reason.Value


                p(11) = New OracleParameter("msg", OracleType.VarChar, 500)
                p(11).Direction = ParameterDirection.Output

                oh.ExecuteNonQuery("hrm_Leave_sanction_Process", p)

                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("         alert('" + p(11).Value + "');")
                cl_script1.Append("         window.open('Leave_sanction_New.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            ElseIf Me.Checkbox1.Checked = False Then
                Dim p(11) As OracleParameter
                Dim str As String = ""
                p(0) = New OracleParameter("EmpCode", OracleType.Number, 6)
                p(0).Direction = ParameterDirection.Input
                p(0).Value = Me.hid_empcode.Value
                Dim lid As Integer
                If Me.txt_ltyp.Value = "C/L" Then
                    lid = 1
                ElseIf Me.txt_ltyp.Value = "S/L" Then
                    lid = 2
                ElseIf Me.txt_ltyp.Value = "E/L" Then
                    lid = 3
                ElseIf Me.txt_ltyp.Value = "LOP" Then
                    lid = 4
                ElseIf Me.txt_ltyp.Value = "MAT" Then
                    lid = 10
                End If
                p(1) = New OracleParameter("leavetype", OracleType.Number, 15)
                p(1).Direction = ParameterDirection.Input
                p(1).Value = lid

                p(2) = New OracleParameter("fromdt", OracleType.DateTime)
                p(2).Direction = ParameterDirection.Input
                p(2).Value = Me.txt_frdt.Value

                p(3) = New OracleParameter("todt", OracleType.DateTime)
                p(3).Direction = ParameterDirection.Input
                p(3).Value = Me.txt_todt.Value

                p(4) = New OracleParameter("leavedays", OracleType.Number, 5)
                p(4).Direction = ParameterDirection.Input
                p(4).Value = Me.txt_dur.Value

                p(5) = New OracleParameter("userid", OracleType.Number, 6)
                p(5).Direction = ParameterDirection.Input
                p(5).Value = User(0)

                p(6) = New OracleParameter("leaveseq", OracleType.Number, 10)
                p(6).Direction = ParameterDirection.Input
                p(6).Value = Me.hid_seq.Value

                p(7) = New OracleParameter("actualfrdt", OracleType.DateTime)
                p(7).Direction = ParameterDirection.Input
                p(7).Value = Me.txt_ParFrDt.Text

                p(8) = New OracleParameter("actualtodt", OracleType.DateTime)
                p(8).Direction = ParameterDirection.Input
                p(8).Value = Me.txt_ParToDt.Text

                p(9) = New OracleParameter("Applydt", OracleType.DateTime)
                p(9).Direction = ParameterDirection.Input
                p(9).Value = Me.txt_appdt.Value.Split("-")(0)

                p(10) = New OracleParameter("reason", OracleType.VarChar, 100)
                p(10).Direction = ParameterDirection.Input
                p(10).Value = Me.txt_reason.Value


                p(11) = New OracleParameter("msg", OracleType.VarChar, 500)
                p(11).Direction = ParameterDirection.Output
                oh.ExecuteNonQuery("hrm_Leave_sanction_Process", p)
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("         alert('" + p(11).Value + "');")
                cl_script1.Append("         window.open('Leave_sanction_New.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

            End If
        Else
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Select Employee!!!');")
            cl_script1.Append("         window.open('Leave_sanction_New.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        End If
    End Sub

  
End Class

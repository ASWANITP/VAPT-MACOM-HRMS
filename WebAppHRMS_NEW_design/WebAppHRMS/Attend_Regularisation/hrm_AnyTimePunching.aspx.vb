Imports System.Data
Imports System.Data.OracleClient

''''''''''''''''''''''''''''CHANGED
Partial Class AnyTimePunching_New_hrm_AnyTimePunching_fd4356312934
    Inherits System.Web.UI.Page
    Implements Web.UI.ICallbackEventHandler
    Dim dt, dt1, dt2, dt10, dt7 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim str_tkn As New System.Text.StringBuilder
    Dim str1 As New System.Text.StringBuilder
    Dim CbResult As String = Nothing
    Dim dr As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim User() As String
        User = Session("user_id").ToString.Split("!")
        Me.hid_sre.Value = User(0)
        Me.hid_br.Value = Session("branch_id")



        'Session("branch_id") = 985
        'Session("user_id") = "17966!985"
        'User = Session("user_id").ToString.Split("!")
        'Me.hid_sre.Value = User(0)
        ''Session("branch_id") = 985
        'Me.hid_br.Value = Session("branch_id")
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "INDIVIDUAL ATTENDANCE REGULARISATION REQUEST"
        'dt1 = oh.ExecuteDataSet("select a.emp_code from employee_master a where a.emp_code=" & User(0) & " and a.branch_id=" & Session("branch_id") & " and a.post_id in (10,198,1,235,234,251,252,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,45) and a.status_id=1").Tables(0)
        'If dt1.Rows.Count <= 0 Then

        'dt7 = oh.ExecuteDataSet("select a.EMP_CODE  from employee_master a where a.STATUS_ID = 1   and a.EMP_CODE =" & User(0) & " ").Tables(0)
        'If dt7.Rows(0)(0) = 15220 Then
        '    dt1 = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name || '*' || d.m_time || '*' ||       b.in_time || '*' || p.post_name  from daily_attend d, time_tab b, employee_master e, post_mst p where d.emp_code = e.emp_code   and e.DEPARTMENT_ID not in (4, 178, 188, 23, 180, 211)   and e.post_id = p.post_id   and d.m_time <> 'TOUR'   and d.m_time <> 'COMPEN'   and d.m_shift = b.shift_id   and d.m_branch in (select br.BRANCH_ID                        from branch_dtl_new br                       where br.status_id = 3                         and br.BRANCH_ID not in (1256))   and d.m_time > b.in_time   and e.emp_code > 10000   and d.m_branch <> 0   and not exists (select r.requested_by          from hrm_anytimepunching_reg r         where r.status_id in (0, 2, 1, 10, 11, 12, 8, 9)           and r.not_punch is null           and to_date(r.requested_dt) = to_date(sysdate)           and d.emp_code = r.requested_by) order by d.emp_code").Tables(0)
        '    If dt1.Rows.Count > 0 Then
        '        For Each dr In dt1.Rows
        '            str_tkn.Append(dr(0))
        '            str_tkn.Append("!")
        '        Next
        '        Me.Hidden3.Value = str_tkn.ToString
        '    End If


        'Else

        dt1 = oh.ExecuteDataSet("select a.emp_code from employee_master a where a.emp_code=" & User(0) & " and a.status_id=1 and a.department_id in (4, 178, 188, 23, 180,211,330,598,594,591)").Tables(0)
        If dt1.Rows.Count <> 0 Then
            dt1 = oh.ExecuteDataSet("select a.emp_code from employee_master a where a.emp_code=" & User(0) & "  and a.status_id=1  ").Tables(0)
            If dt1.Rows.Count <= 0 Then
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert('You Are Not Authorised!!!!');")
                cl_script0.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
            Else
                dt2 = oh.ExecuteDataSet("select e.emp_code||'*'||e.emp_name||'*'||d.m_time||'*'||b.in_time|| '*' ||p.post_name from daily_attend d,time_tab b,employee_master e,post_mst p where d.emp_code=e.emp_code  and e.DEPARTMENT_ID not in (4, 178, 188, 23, 180,211) and e.post_id=p.post_id and d.m_time<>'TOUR' and d.m_time<>'COMPEN' and d.m_shift=b.shift_id and d.m_branch=" & Session("branch_id") & " and d.m_time>b.in_time and e.emp_code>10000 and d.m_branch<>0 and not exists (select r.requested_by from hrm_anytimepunching_reg r where r.status_id in (0,2,1,10,11,12,8,9)and r.not_punch is null and to_date(r.requested_dt)=to_date(sysdate) and d.emp_code=r.requested_by) order by d.emp_code").Tables(0)
                If dt2.Rows.Count > 0 Then
                    dt10 = oh.ExecuteDataSet("select count(*) from employee_master e,daily_attend d where e.emp_code=d.emp_code  and e.DEPARTMENT_ID not in (4, 178, 188, 23, 180,211) and d.m_branch=" & Session("branch_id") & " and d.m_time is not null and e.status_id=1").Tables(0)
                    If dt2.Rows.Count <> dt10.Rows(0)(0) Then
                        Dim cl_script0 As New System.Text.StringBuilder
                        cl_script0.Append("         alert('Enter Through Attendance Regularisation Module!!!!');")
                        cl_script0.Append("window.open('../home.aspx','_self');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                    Else
                        For Each dr In dt2.Rows
                            str_tkn.Append(dr(0))
                            str_tkn.Append("!")
                        Next
                        Me.Hidden3.Value = str_tkn.ToString
                    End If
                End If
                End If
                'End If
                'Else
                dt1 = oh.ExecuteDataSet("select a.emp_code from employee_master a where a.emp_code=" & User(0) & " and a.status_id=1 and a.department_id in (4, 178, 188, 23, 180,211,330)").Tables(0)
                If dt1.Rows.Count <= 0 Then
                    dt2 = oh.ExecuteDataSet("select e.emp_code||'*'||e.emp_name||'*'||d.m_time||'*'||b.in_time|| '*' ||p.post_name from daily_attend d,time_tab b,employee_master e,post_mst p where d.emp_code=e.emp_code and e.post_id=p.post_id and d.m_time<>'TOUR' and d.m_time<>'COMPEN' and d.m_shift=b.shift_id and d.emp_code=" & User(0) & " and d.m_time>b.in_time and e.department_id in (4, 178, 188, 23, 180,211,330) and e.emp_code>10000 and d.m_branch<>0 and not exists (select r.requested_by from hrm_anytimepunching_reg r where r.status_id in (0,2,1,10,11,12,8,9)and r.not_punch is null and to_date(r.requested_dt)=to_date(sysdate) and d.emp_code=r.requested_by) order by d.emp_code").Tables(0)
                    If dt2.Rows.Count > 0 Then
                        For Each dr In dt2.Rows
                            str_tkn.Append(dr(0))
                            str_tkn.Append("!")
                        Next
                        Me.Hidden3.Value = str_tkn.ToString
                    Else
                        Dim cl_script0 As New System.Text.StringBuilder
                        cl_script0.Append("         alert('Already Entered!!!!');")
                        cl_script0.Append("window.open('../home.aspx','_self');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                    End If
                End If
        End If


        'End If        
        Dim client_name As String
        client_name = "var master_no;" & "master_no='" & "" & Me.hid_sre.ClientID & "'" & ";"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", client_name, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "FromServer", "context", True)
        Dim cbscript As String = "function ToServer (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ToServer", cbscript, True)
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return CbResult
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim DataStr() As String
        DataStr = eventArgument.Split("#")
        Select Case (DataStr(1))
            Case 1
                Dim Instr() As String = DataStr(0).Split("%")
                Dim Dataa As String = Instr(0)
                Dim UserID As Integer = Instr(1)
                Dim BrID As Integer = Instr(2)
                Dim ComplaintID As String = Instr(3)
                ' dt1 = oh.ExecuteDataSet("select count(a.emp_code) from employee_master a where a.emp_code=" & UserID & " and a.department_id in (4, 178, 188, 23, 180,211)").Tables(0)
                'If dt1.Rows(0)(0) >= 1 Then
                '    Try
                '        Dim User() As String
                '        User = Session("user_id").ToString.Split("!")
                '        Dim p(4) As OracleParameter

                '        p(0) = New OracleParameter("Dataa", OracleType.VarChar, 10000000)
                '        p(0).Value = Dataa

                '        p(1) = New OracleParameter("userId", OracleType.Number, 5)
                '        p(1).Value = User(0)

                '        p(2) = New OracleParameter("BrID", OracleType.Number, 4)
                '        p(2).Value = BrID

                '        p(3) = New OracleParameter("ComplaintID", OracleType.VarChar, 12)
                '        p(3).Value = ComplaintID

                '        p(4) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
                '        p(4).Direction = ParameterDirection.Output

                '        oh.ExecuteNonQuery("hrm_AnyTimePunch_Req", p)
                '        CbResult = p(4).Value
                '    Catch ex As Exception
                '        CbResult = ex.Message
                '    End Try
                'Else
                dt = oh.ExecuteDataSet("select count(c.problem_id) from complaint_registered c where c.complaint_id=23 and to_date(c.tra_dt)=to_date(sysdate) and c.problem_id=" & ComplaintID & "").Tables(0)
                If dt.Rows(0)(0) >= 1 Then
                    Try
                        Dim User() As String
                        User = Session("user_id").ToString.Split("!")
                        Dim p(4) As OracleParameter

                        p(0) = New OracleParameter("Dataa", OracleType.VarChar, 10000000)
                        p(0).Value = Dataa

                        p(1) = New OracleParameter("userId", OracleType.Number, 5)
                        p(1).Value = User(0)

                        p(2) = New OracleParameter("BrID", OracleType.Number, 4)
                        p(2).Value = BrID

                        p(3) = New OracleParameter("ComplaintID", OracleType.VarChar, 12)
                        p(3).Value = ComplaintID

                        p(4) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
                        p(4).Direction = ParameterDirection.Output

                        oh.ExecuteNonQuery("hrm_AnyTimePunch_Req", p)
                        CbResult = p(4).Value
                    Catch ex As Exception
                        CbResult = ex.Message
                    End Try
                Else
                    CbResult = "Please Contact HO and Register The Complaint!!!"
                End If
                'End If
        End Select
    End Sub
End Class

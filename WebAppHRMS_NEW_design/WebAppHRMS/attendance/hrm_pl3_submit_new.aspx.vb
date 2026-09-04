Imports System.Data
Imports System.Data.OracleClient
Partial Class pl3_pl3_submit_new_58b07fd58752
    Inherits System.Web.UI.Page
    Implements Web.UI.ICallbackEventHandler
    Dim dt, dt1, dt2, dt3, dt4, dt5 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim brid As Integer
    Dim str_tkn As New System.Text.StringBuilder
    Dim str1 As New System.Text.StringBuilder
    Dim CbResult As String = Nothing
    Dim dr As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim User() As String
        User = Session("user_id").ToString.Split("!")
        Me.hid_br.Value = Session("branch_id")
        Me.hid_s.Value = User(0)
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "PL3 UPDATION"
        dt = oh.ExecuteDataSet("select a.branch_id from employee_master a where a.emp_code=" & User(0) & " and a.status_id=1 and a.branch_id=" & Session("branch_id") & "").Tables(0)
        If dt.Rows.Count > 0 Then
            brid = dt.Rows(0)(0)
            If brid = 0 Then
                If Not IsPostBack Then
                    dt2 = oh.ExecuteDataSet("select a.dep_id from department_mst a where (a.AUTHORISED_PERSON=" & User(0) & " or a.dep_head=" & User(0) & ")").Tables(0)
                    If dt2.Rows.Count > 0 Then
                        'dt3 = oh.ExecuteDataSet("select a.department_id from department_major a where a.AUTHORISED_PERSON=" & User(0) & " and a.department_id=9").Tables(0)
                        If dt2.Rows(0)(0) = 133 Or dt2.Rows(0)(0) = 23 Then
                            dt1 = oh.ExecuteDataSet("select a.emp_code || '*' || upper(a.emp_name) || '*' || a.emp_code || '*' ||  d.dep_name  from employee_master a,  daily_attend    b,  department_mst  d,  employ_firm     f,  employ_firm     f1  where (a.emp_code = b.emp_code)  and a.status_id = 1  and a.emp_code = f.emp_code  and f1.emp_code = " & User(0) & "  and f.firm_id = f1.firm_id  and b.m_time is null  and a.department_id = d.dep_id  and (d.authorised_person =  " & User(0) & "  or d.dep_head =  " & User(0) & " )  and a.shift_id not in (4, 5)  and not exists (select t.emp_code  from training_attend t  where (t.emp_code = a.emp_code)  and to_date(t.training_date) = to_date(sysdate)  and t.in_time is not null)  and not exists (select emp_code  from leave_pl3 c  where (to_date(leave_date) = to_date(sysdate))  and a.emp_code = c.emp_code)  and not exists  (select emp_code  from employ_leave_dtl d  where to_date(sysdate) between to_date(d.leave_frdate) and  to_date(d.leave_todate)  and a.emp_code = d.emp_code)  and not exists (select emp_code  from hrm_7days_off_day h  where to_date(sysdate) between to_date(h.from_dt) and  to_date(h.to_dt)  and a.EMP_CODE = h.emp_code  and h.status in (1, 3))  order by a.emp_name").Tables(0)
                            If dt1.Rows.Count <= 0 Then
                                Dim cl_script0 As New System.Text.StringBuilder
                                cl_script0.Append("         alert('No Details for PL3!!!!');")
                                cl_script0.Append("window.open('../home.aspx','_self');")
                                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                            Else
                                For Each dr In dt1.Rows
                                    str_tkn.Append(dr(0))
                                    str_tkn.Append("!")
                                Next
                                Me.Hidden3.Value = str_tkn.ToString
                            End If
                        Else
                            dt1 = oh.ExecuteDataSet("select a.emp_code || '*' || upper(a.emp_name) || '*' || a.emp_code || '*' ||  d.dep_name  from employee_master a, daily_attend b, department_mst d,employ_firm f,employ_firm f1  where (a.emp_code = b.emp_code)  and a.status_id = 1  and a.emp_name not like 'IBM%'  and b.m_time is null  and a.branch_id = 0  and a.emp_code=f.emp_code  and f1.emp_code=" & User(0) & "  and f.firm_id=f1.firm_id  and d.major_dep_id is not null  and a.department_id = d.dep_id  and (d.authorised_person = " & User(0) & " or  d.dep_head = " & User(0) & ")  and a.shift_id not in (4, 5)  and not exists (select t.emp_code  from training_attend t  where (t.emp_code = a.emp_code)  and to_date(t.training_date) = to_date(sysdate)  and t.in_time is not null)  and not exists (select emp_code  from leave_pl3 c  where (to_date(leave_date) = to_date(sysdate))  and a.emp_code = c.emp_code)  and not exists  (select emp_code  from employ_leave_dtl dd  where to_date(sysdate) between to_date(dd.leave_frdate) and  to_date(dd.leave_todate)  and a.emp_code = dd.emp_code)  and not exists (select emp_code  from hrm_7days_off_day h  where to_date(sysdate) between to_date(h.from_dt) and  to_date(h.to_dt)  and a.EMP_CODE = h.emp_code  and h.status in (1, 3))  order by a.emp_name").Tables(0)
                            If dt1.Rows.Count <= 0 Then
                                Dim cl_script0 As New System.Text.StringBuilder
                                cl_script0.Append("         alert('No Details for PL3!!!!');")
                                cl_script0.Append("window.open('../home.aspx','_self');")
                                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                            Else
                                For Each dr In dt1.Rows
                                    str_tkn.Append(dr(0))
                                    str_tkn.Append("!")
                                Next
                                Me.Hidden3.Value = str_tkn.ToString
                            End If
                        End If
                    Else
                        Dim cl_script0 As New System.Text.StringBuilder
                        cl_script0.Append("         alert('You Are Not Authorised...!!!!');")
                        cl_script0.Append("window.open('../home.aspx','_self');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                    End If
                End If
            ElseIf brid <> 0 Then
                dt3 = oh.ExecuteDataSet("select a.emp_code from employee_master a where a.emp_code=" & User(0) & " and a.status_id=1 and a.branch_id=" & Session("branch_id") & "").Tables(0)
                If Not IsPostBack Then
                    If dt3.Rows.Count > 0 Then
                        'dt1 = oh.ExecuteDataSet("select a.emp_code, upper(a.emp_name) || '~' || a.emp_code from employee_master a, daily_attend b,department_mst c where(a.emp_code = b.emp_code) and a.status_id = 1 and a.department_id =c.dep_id and c.major_dep_id<>9 and b.m_time is null and a.branch_id =" & Session("branch_id") & " and a.shift_id not in (4, 5) and not exists (select t.emp_code from training_attend t where(t.emp_code = a.emp_code) and to_date(t.training_date) = to_date(sysdate) and t.in_time is not null) and not exists (select emp_code from leave_pl3 c where(to_date(leave_date) = to_date(sysdate)) and a.emp_code = c.emp_code)and not exists (select emp_code from employ_leave_dtl d where to_date(sysdate) between to_date(d.leave_frdate) and to_date(d.leave_todate) and a.emp_code = d.emp_code) order by upper(a.emp_name)").Tables(0)
                        dt1 = oh.ExecuteDataSet("select a.emp_code||'*'||upper(a.emp_name) ||'*'|| a.emp_code||'*'||c.dep_name from employee_master  a, daily_attend     b, department_mst   c where (a.emp_code = b.emp_code) and a.status_id = 1 and a.department_id = c.dep_id and (c.major_dep_id <> 9 or c.major_dep_id is null) and b.m_time is null and a.branch_id = " & Session("branch_id") & "  and a.shift_id not in (4, 5) and not exists (select t.emp_code from training_attend t where (t.emp_code = a.emp_code) and to_date(t.training_date) = to_date(sysdate) and t.in_time is not null) and not exists (select emp_code from leave_pl3 c where (to_date(leave_date) = to_date(sysdate)) and a.emp_code = c.emp_code) and not exists (select emp_code from employ_leave_dtl d where to_date(sysdate) between to_date(d.leave_frdate) and to_date(d.leave_todate) and a.emp_code = d.emp_code) and not exists (select emp_code from hrm_7days_off_day h where to_date(sysdate) between to_date(h.from_dt) and to_date(h.to_dt) and a.EMP_CODE=h.emp_code and h.status in (1,3)) order by a.emp_name").Tables(0)
                        If dt1.Rows.Count <= 0 Then
                            Dim cl_script0 As New System.Text.StringBuilder
                            cl_script0.Append("         alert('No Details for PL3!!!!');")
                            cl_script0.Append("window.open('../home.aspx','_self');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                        Else
                            For Each dr In dt1.Rows
                                str_tkn.Append(dr(0))
                                str_tkn.Append("!")
                            Next
                            Me.Hidden3.Value = str_tkn.ToString
                        End If
                    Else
                        Dim cl_script0 As New System.Text.StringBuilder
                        cl_script0.Append("         alert('You Are Not Authorised...!!!!');")
                        cl_script0.Append("window.open('../home.aspx','_self');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                    End If
                End If
            End If
        Else
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('You Are Not Authorised...!!!!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        End If

        dt5 = oh.ExecuteDataSet("select a.emp_code from employee_block_dtl a where a.emp_code=" & User(0) & " and a.block_id=105 and a.block_status=1").Tables(0)
        If dt5.Rows.Count > 0 Then
            oh.ExecuteNonQuery("UPDATE employee_block_dtl t set t.block_status=0 where  t.emp_code=" & User(0) & " and t.block_id=105")
        End If

        Dim client_name As String
        client_name = "var master_no;" & "master_no='" & "" & Me.hid_s.ClientID & "'" & ";"
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
                Try
                    Dim User() As String
                    User = Session("user_id").ToString.Split("!")
                    Dim p(3) As OracleParameter

                    p(0) = New OracleParameter("Dataa", OracleType.VarChar, 10000000)
                    p(0).Value = Dataa

                    p(1) = New OracleParameter("userId", OracleType.Number, 5)
                    p(1).Value = User(0)

                    p(2) = New OracleParameter("BrID", OracleType.Number, 4)
                    p(2).Value = BrID

                    p(3) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
                    p(3).Direction = ParameterDirection.Output

                    oh.ExecuteNonQuery("pl3_confirm_new", p)
                    CbResult = p(3).Value
                Catch ex As Exception
                    CbResult = ex.Message
                End Try
        End Select

    End Sub
End Class

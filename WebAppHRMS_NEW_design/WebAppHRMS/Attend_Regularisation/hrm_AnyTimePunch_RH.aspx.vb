Imports System.Data
Imports System.Data.OracleClient
Partial Class AnyTimePunching_New_hrm_AnyTimePunch_RH_671e60db5367
    Inherits System.Web.UI.Page
    Implements Web.UI.ICallbackEventHandler
    Dim dt, dt1, dt2, dt4, dt5, dt10, dt6 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim BranchID, AreaID, RegionID As Integer
    Dim str_tkn As New System.Text.StringBuilder
    Dim str As New System.Text.StringBuilder
    Dim CbResult As String = Nothing
    Dim dr As DataRow
    Dim ZoneID As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim UserId As Integer = User(0)
        Me.hid_sre.Value = User(0)
        Dim id As Integer = 211
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "INDIVIDUAL ATTENDANCE REGULARISATION RECOMMENDATION"
        'Me.hid_br.Value = Session("branch_id")
        Dim client_name As String
        client_name = "var master_no;" & "master_no='" & "" & Me.hid_sre.ClientID & "'" & ";"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", client_name, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "FromServer", "context", True)
        Dim cbscript As String = "function ToServer (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ToServer", cbscript, True)
        dt = oh.ExecuteDataSet("select a.zonal_id,a.head_id from zonal_master a where a.head_id=" & UserId & "").Tables(0)
        If dt.Rows.Count > 0 Then
            ZoneID = dt.Rows(0)(0)
            If UserId = 23045 Then 'MABEN RH OP
                dt = oh.ExecuteDataSet("select 0, '--Branch--Requested Date---' as branchname  from dual  union  select distinct (b.BRANCH_ID),  b.BRANCH_NAME || '~' || to_char(to_date(a.requested_dt)) as branchname  from hrm_anytimepunching_reg a, branch_master b, employee_master e  where a.requested_by = e.emp_code  and b.firm_id=2  and a.branch_id = b.BRANCH_ID  and e.department_id not in (4, 178, 188, 211)  and a.status_id =9  and a.branch_id <> 0  and a.not_punch is null  order by branchname").Tables(0)
                Me.cmb_branch.DataSource = dt
                Me.cmb_branch.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_branch.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_branch.DataBind()
            Else
                'If Not IsPostBack Then
                'RH Recommend
                'dt = oh.ExecuteDataSet("select 0, '--Branch--Requested Date---' as branchname from dual union select distinct (b.BRANCH_ID), b.BRANCH_NAME||'~'||to_char(to_date(a.requested_dt)) as branchname from hrm_anytimepunching_reg a, branch_dtl_new b where a.branch_id = b.BRANCH_ID and b.zonal_id =" & ZoneID & " and a.status_id = 8 and a.branch_id<>0 and a.not_punch is null and (to_date(a.requested_dt)=to_date(sysdate) or to_date(a.requested_dt)=to_date(sysdate-1)) order by branchname").Tables(0)
                'dt = oh.ExecuteDataSet("select 0, '--Branch--Requested Date---' as branchname from dual union select distinct (b.BRANCH_ID), b.BRANCH_NAME||'~'||to_char(to_date(a.requested_dt)) as branchname from hrm_anytimepunching_reg a, branch_dtl_new b where a.branch_id = b.BRANCH_ID and b.zonal_id =" & ZoneID & " and a.status_id = 8 and a.branch_id<>0 and a.not_punch is null order by branchname").Tables(0)
                'If dt.Rows.Count <= 1 Then
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert('You Are Not Authorised!!!!');")
                cl_script0.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                '    Else
                '        Me.cmb_branch.DataSource = dt
                '        Me.cmb_branch.DataTextField = dt.Columns(1).ColumnName
                '        Me.cmb_branch.DataValueField = dt.Columns(0).ColumnName
                '        Me.cmb_branch.DataBind()
                '    End If
            End If
        Else
            dt10 = oh.ExecuteDataSet("select d.emp_code,z.zonal_head,z.zonal_id  from daily_attend d, zonal_master z where d.emp_code = z.head_id  and d.m_time is null and z.head_id=" & UserId & "").Tables(0)
            If dt10.Rows.Count <= 0 Then
                'Jwellery Recomm
                dt6 = oh.ExecuteDataSet("select a.emp_code from employee_master a where a.department_id=275 and a.designation_id=23 and a.status_id=1 and a.emp_code=" & User(0) & "").Tables(0)
                If dt6.Rows.Count >= 1 Then
                    'dt = oh.ExecuteDataSet("select 0, '--Branch--Requested Date---' as branchname from dual union select distinct (b.BRANCH_ID),b.BRANCH_NAME || '~' || to_char(to_date(a.requested_dt)) as branchname from hrm_anytimepunching_reg a, branch_dtl_new b,employee_master e where a.requested_by=e.emp_code and a.branch_id = b.BRANCH_ID and e.department_id not in (4, 178, 188, 211) and a.status_id = 10 and a.branch_id <> 0 and a.not_punch is null and (to_date(a.requested_dt) = to_date(sysdate) or to_date(a.requested_dt) = to_date(sysdate - 1)) order by branchname").Tables(0)
                    dt = oh.ExecuteDataSet("select 0, '--Branch--Requested Date---' as branchname from dual union select distinct (b.BRANCH_ID),b.BRANCH_NAME || '~' || to_char(to_date(a.requested_dt)) as branchname from hrm_anytimepunching_reg a, branch_master b,employee_master e where a.requested_by=e.emp_code and b.status_id=2 and a.branch_id = b.BRANCH_ID and e.department_id not in (4, 178, 188, 211) and a.status_id = 10 and a.branch_id <> 0 and a.not_punch is null order by branchname").Tables(0)
                    Me.cmb_branch.DataSource = dt
                    Me.cmb_branch.DataTextField = dt.Columns(1).ColumnName
                    Me.cmb_branch.DataValueField = dt.Columns(0).ColumnName
                    Me.cmb_branch.DataBind()
                ElseIf UserId = 11855 Or UserId = 15200 Then
                    dt = oh.ExecuteDataSet("select 0, '--Branch--Requested Date---' as branchname from dual union select distinct (b.BRANCH_ID),b.BRANCH_NAME || '~' || to_char(to_date(a.requested_dt)) as branchname from hrm_anytimepunching_reg a, branch_master b,employee_master e where a.requested_by=e.emp_code and b.status_id=3 and a.branch_id = b.BRANCH_ID and e.department_id not in (4, 178, 188, 211) and a.status_id = 10 and a.branch_id <> 0 and a.not_punch is null order by branchname").Tables(0)
                    Me.cmb_branch.DataSource = dt
                    Me.cmb_branch.DataTextField = dt.Columns(1).ColumnName
                    Me.cmb_branch.DataValueField = dt.Columns(0).ColumnName
                    Me.cmb_branch.DataBind()


                Else
                    'AUDIT Recomm
                    dt6 = oh.ExecuteDataSet("select a.emp_code from employee_master a where a.department_id in (4,179) and a.post_id in (85,71) and a.status_id=1 and a.emp_code=" & User(0) & "").Tables(0)
                    If dt6.Rows.Count >= 1 Then
                        'dt = oh.ExecuteDataSet("select 0, '--Branch--Requested Date---' as branchname from dual union select distinct (b.BRANCH_ID),b.BRANCH_NAME || '~' || to_char(to_date(a.requested_dt)) as branchname from hrm_anytimepunching_reg a, branch_dtl_new b, employee_master e where a.requested_by = e.emp_code and a.branch_id = b.branch_id and e.department_id in (4, 178, 188, 211)and a.status_id = 10 and a.branch_id <> 0 and a.not_punch is null and (to_date(a.requested_dt) = to_date(sysdate) or to_date(a.requested_dt) = to_date(sysdate - 1)) order by branchname").Tables(0)
                        dt = oh.ExecuteDataSet("select 0, '--Branch--Requested Date---' as branchname from dual union select distinct (b.BRANCH_ID),b.BRANCH_NAME || '~' || to_char(to_date(a.requested_dt)) as branchname from hrm_anytimepunching_reg a, branch_dtl_new b, employee_master e where a.requested_by = e.emp_code and a.branch_id = b.branch_id and e.department_id in (4, 178, 188, 211)and a.status_id = 20 and a.branch_id <> 0 and a.not_punch is null order by branchname").Tables(0)
                        Me.cmb_branch.DataSource = dt
                        Me.cmb_branch.DataTextField = dt.Columns(1).ColumnName
                        Me.cmb_branch.DataValueField = dt.Columns(0).ColumnName
                        Me.cmb_branch.DataBind()
                    Else
                        Dim cl_script0 As New System.Text.StringBuilder
                        cl_script0.Append("         alert('You Are Not Authorised!!!!');")
                        cl_script0.Append("window.open('../home.aspx','_self');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                    End If
                End If
            Else
                'dt4 = oh.ExecuteDataSet("select a.emp_code from employee_master a where a.emp_code=" & User(0) & " and a.designation_id in (27,28,29) and a.department_id in (169,44) and a.status_id=1").Tables(0)
                'If dt4.Rows.Count >= 1 Then
                '    For Each dr In dt10.Rows
                '        str.Append(dr(2))
                '        str.Append(",")
                '    Next
                '    str.Append("999")
                '    Me.hid_area.Value = str.ToString
                '    'dt5 = oh.ExecuteDataSet("select 0, '--Branch--Requested Date---' as branchname from dual union select distinct (b.BRANCH_ID), b.BRANCH_NAME||'~'||to_char(to_date(a.requested_dt)) as branchname from hrm_anytimepunching_reg a, branch_dtl_new b where a.branch_id = b.BRANCH_ID and b.zonal_id in (" & Me.hid_area.Value & ") and a.status_id = 8 and a.not_punch is null and a.branch_id<>0 and (to_date(a.requested_dt)=to_date(sysdate) or to_date(a.requested_dt)=to_date(sysdate-1)) order by branchname").Tables(0)
                '    dt5 = oh.ExecuteDataSet("select 0, '--Branch--Requested Date---' as branchname from dual union select distinct (b.BRANCH_ID), b.BRANCH_NAME||'~'||to_char(to_date(a.requested_dt)) as branchname from hrm_anytimepunching_reg a, branch_dtl_new b where a.branch_id = b.BRANCH_ID and b.zonal_id in (" & Me.hid_area.Value & ") and a.status_id = 8 and a.not_punch is null and a.branch_id<>0 order by branchname").Tables(0)
                '    If dt5.Rows.Count <= 1 Then
                '        Dim cl_script0 As New System.Text.StringBuilder
                '        cl_script0.Append("         alert('No Details for Recommendation!!!!');")
                '        cl_script0.Append("window.open('../home.aspx','_self');")
                '        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                '    Else
                '        Me.cmb_branch.DataSource = dt5
                '        Me.cmb_branch.DataTextField = dt5.Columns(1).ColumnName
                '        Me.cmb_branch.DataValueField = dt5.Columns(0).ColumnName
                '        Me.cmb_branch.DataBind()
                '    End If
                'Else
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert('You are not Authorised to View this Page !!!!');")
                cl_script0.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                'End If
            End If
        End If
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return CbResult
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim Userd() As String = Session("user_id").ToString.Split("!")
        Dim UserIdd As Integer = Userd(0)
        Dim DataStr() As String
        DataStr = eventArgument.Split("#")
        Select Case (DataStr(1))
            Case 1
                Dim Instr() As String = DataStr(0).Split("%")
                Dim CODE As String = Instr(0)
                Dim ReqDt As String = Instr(1)
                dt = oh.ExecuteDataSet("select b.branch_id from branch_master b where b.branch_id=" & CODE & " and b.status_id in (2,3)").Tables(0)
                If dt.Rows.Count >= 1 Then
                    dt2 = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name || '*' || d.m_time || '*' ||b.in_time|| '*' ||r.remarks|| '*' ||p.post_name|| '*' ||'-'|| '*' ||'-' from daily_attend d, time_tab b, employee_master e,hrm_anytimepunching_reg r,post_mst p where d.emp_code = e.emp_code and e.department_id not in (4, 178, 188,211) and r.not_punch is null and r.branch_id=d.m_branch and e.post_id=p.post_id and d.m_shift = b.shift_id and d.m_branch = " & CODE & " and d.m_time > b.in_time and e.emp_code > 10000 and d.m_branch <> 0 and d.emp_code =r.requested_by and r.status_id=10 and to_date(d.curr_date) =to_date('" & ReqDt & "') and to_date(r.requested_dt)=to_date('" & ReqDt & "') order by d.emp_code").Tables(0)
                    If dt2.Rows.Count <= 0 Then
                        dt2 = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name || '*' || d.m_time || '*' ||b.in_time|| '*' ||r.remarks|| '*' ||p.post_name|| '*' ||'-'|| '*' ||'-' from attend d, time_tab b, employee_master e,hrm_anytimepunching_reg r,post_mst p where d.emp_code = e.emp_code and e.department_id not in (4, 178, 188,211) and r.not_punch is null and r.branch_id=d.m_branch and e.post_id=p.post_id and d.m_shift = b.shift_id and d.m_branch = " & CODE & " and d.m_time > b.in_time and e.emp_code > 10000 and d.m_branch <> 0 and d.emp_code =r.requested_by and r.status_id=10 and to_date(d.curr_date) =to_date('" & ReqDt & "') and to_date(r.requested_dt)=to_date('" & ReqDt & "') order by d.emp_code").Tables(0)
                    End If
                Else
                    dt6 = oh.ExecuteDataSet("select a.emp_code from employee_master a where a.department_id in (4,179) and a.post_id in (85,71) and a.status_id=1 and a.emp_code=" & Userd(0) & "").Tables(0)
                    If dt6.Rows.Count >= 1 Then
                        dt2 = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name || '*' || d.m_time || '*' ||b.in_time|| '*' ||r.remarks|| '*' ||p.post_name|| '*' ||r.rm_recomm_reason|| '*' ||'-' from daily_attend d, time_tab b, employee_master e,hrm_anytimepunching_reg r,post_mst p where d.emp_code = e.emp_code and e.department_id in (4, 178, 188,211) and r.not_punch is null and r.requested_by=d.emp_code and e.post_id=p.post_id and d.m_shift = b.shift_id and r.branch_id = " & CODE & " and d.m_time > b.in_time and e.emp_code > 10000 and d.m_branch <> 0 and d.emp_code =r.requested_by and r.status_id=20 and to_date(d.curr_date) =to_date('" & ReqDt & "') and to_date(r.requested_dt)=to_date('" & ReqDt & "') order by d.emp_code").Tables(0)
                        If dt2.Rows.Count <= 0 Then
                            dt2 = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name || '*' || d.m_time || '*' ||b.in_time|| '*' ||r.remarks|| '*' ||p.post_name|| '*' ||r.rm_recomm_reason|| '*' ||'-' from attend d, time_tab b, employee_master e,hrm_anytimepunching_reg r,post_mst p where d.emp_code = e.emp_code and e.department_id in (4, 178, 188,211) and r.not_punch is null and r.requested_by=d.emp_code and e.post_id=p.post_id and d.m_shift = b.shift_id and r.branch_id = " & CODE & " and d.m_time > b.in_time and e.emp_code > 10000 and d.m_branch <> 0 and d.emp_code =r.requested_by and r.status_id=20 and to_date(d.curr_date) =to_date('" & ReqDt & "') and to_date(r.requested_dt)=to_date('" & ReqDt & "') order by d.emp_code").Tables(0)
                        End If
                    Else
                        dt2 = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name || '*' || d.m_time || '*' ||b.in_time|| '*' ||r.remarks|| '*' ||p.post_name|| '*' ||r.am_recomm_reason|| '*' ||r.rm_recomm_reason from daily_attend d, time_tab b, employee_master e,hrm_anytimepunching_reg r,post_mst p where d.emp_code = e.emp_code and e.department_id not in (4, 178, 188,211) and r.not_punch is null and r.branch_id=d.m_branch and e.post_id=p.post_id and d.m_shift = b.shift_id and d.m_branch = " & CODE & " and d.m_time > b.in_time and e.emp_code > 10000 and d.m_branch <> 0 and d.emp_code =r.requested_by and r.status_id in(8,9) and to_date(d.curr_date) =to_date('" & ReqDt & "') and to_date(r.requested_dt)=to_date('" & ReqDt & "') order by d.emp_code").Tables(0)
                        If dt2.Rows.Count <= 0 Then
                            dt2 = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name || '*' || d.m_time || '*' ||b.in_time|| '*' ||r.remarks|| '*' ||p.post_name|| '*' ||r.am_recomm_reason|| '*' ||r.rm_recomm_reason from attend d, time_tab b, employee_master e,hrm_anytimepunching_reg r,post_mst p where d.emp_code = e.emp_code and e.department_id not in (4, 178, 188,211) and r.not_punch is null and r.branch_id=d.m_branch and e.post_id=p.post_id and d.m_shift = b.shift_id and d.m_branch = " & CODE & " and d.m_time > b.in_time and e.emp_code > 10000 and d.m_branch <> 0 and d.emp_code =r.requested_by and r.status_id in(8,9) and to_date(d.curr_date) =to_date('" & ReqDt & "') and to_date(r.requested_dt)=to_date('" & ReqDt & "') order by d.emp_code").Tables(0)
                        End If
                    End If
                End If
                'If dt2.Rows.Count > 0 Then
                Dim dr As DataRow
                For Each dr In dt2.Rows
                    str_tkn.Append(dr(0))
                    str_tkn.Append("!")
                Next
                str_tkn.Append("@")
                'str_tkn.Append("2")
                'End If
                dt = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name || '*' || d.m_time || '*' ||b.in_time|| '*' ||p.post_name from daily_attend d, time_tab b, employee_master e,post_mst p where d.emp_code = e.emp_code and e.branch_id = d.m_branch and d.m_shift = b.shift_id  and e.post_id=p.post_id and d.m_branch = " & CODE & " and to_date(d.curr_date) =to_date('" & ReqDt & "') and d.m_time <= b.in_time  and e.emp_code > 10000 and d.m_branch <> 0 order by d.emp_code").Tables(0)
                If dt.Rows.Count <= 0 Then
                    dt = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name || '*' || d.m_time || '*' ||b.in_time|| '*' ||p.post_name from attend d, time_tab b, employee_master e,post_mst p where d.emp_code = e.emp_code and e.branch_id = d.m_branch and d.m_shift = b.shift_id  and e.post_id=p.post_id and d.m_branch = " & CODE & " and to_date(d.curr_date) =to_date('" & ReqDt & "') and d.m_time <= b.in_time  and e.emp_code > 10000 and d.m_branch <> 0 order by d.emp_code").Tables(0)
                End If
                'If dt.Rows.Count > 0 Then
                Dim dr1 As DataRow
                For Each dr1 In dt.Rows
                    str_tkn.Append(dr1(0))
                    str_tkn.Append("!")
                Next
                str_tkn.Append("@")
                str_tkn.Append("2")
                'End If
                CbResult = str_tkn.ToString
            Case 2
                Dim Instr() As String = DataStr(0).Split("%")
                Dim Dataa As String = Instr(0)
                Dim UserID As Integer = Instr(1)
                Dim BrID As Integer = Instr(2)
                Dim ReqDT As Date = Instr(3)
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

                    p(3) = New OracleParameter("ReqDT", OracleType.DateTime)
                    p(3).Value = ReqDT

                    p(4) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
                    p(4).Direction = ParameterDirection.Output
                    oh.ExecuteNonQuery("hrm_AnyTimePunch_Recomm", p)
                    CbResult = p(4).Value
                Catch ex As Exception
                    CbResult = ex.Message
                End Try
        End Select
    End Sub
End Class

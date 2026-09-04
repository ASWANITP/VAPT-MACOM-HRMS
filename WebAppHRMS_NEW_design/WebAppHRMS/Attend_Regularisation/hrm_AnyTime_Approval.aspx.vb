Imports System.Data
Imports System.Data.OracleClient
Partial Class AnyTimePunching_New_hrm_AnyTime_Approval_c052bffc6378
    Inherits System.Web.UI.Page
    Implements Web.UI.ICallbackEventHandler
    Dim dt, dt1, dt2, dt4, dt5, dt6 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim BranchID, AreaID, RegionID As Integer
    Dim str_tkn As New System.Text.StringBuilder
    Dim str_tkn1 As New System.Text.StringBuilder
    Dim CbResult As String = Nothing
    Dim dr, dr1 As DataRow
    Dim ZoneID As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim UserId As Integer = User(0)
        Me.hid_sre.Value = User(0)
        Dim ID As Integer = 211
        ' Me.hid_br.Value = Session("branch_id")
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "INDIVIDUAL ATTENDANCE REGULARISATION APPROVAL"
        Dim client_name As String
        client_name = "var master_no;" & "master_no='" & "" & Me.hid_sre.ClientID & "'" & ";"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", client_name, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "FromServer", "context", True)
        Dim cbscript As String = "function ToServer(arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ToServer", cbscript, True)
        If Not IsPostBack Then
            'dt4 = oh.ExecuteDataSet("select a.emp_code from employee_master a where a.emp_code=" & User(0) & " and a.designation_id in (65,29) and a.department_id in (169,44) and a.status_id=1").Tables(0)
            'dt4 = oh.ExecuteDataSet("select a.emp_code from employee_master a where a.emp_code=" & User(0) & " and a.status_id=1").Tables(0)
            Dim EMPCODE1 As Integer
            EMPCODE1 = UserId
            'JGM
            If EMPCODE1 = 21350 Then 'MABEN CEO   ''(21033 Or EMPCODE1 = 21804)

                dt = oh.ExecuteDataSet("select 0, '--Branch--Requested Date---' as branchname from dual union select distinct (b.BRANCH_ID), b.BRANCH_NAME||'~'||to_char(to_date(a.requested_dt)) as branchname from hrm_anytimepunching_reg a, branch_dtl_new b,branch_master bm where a.branch_id = b.BRANCH_ID and a.branch_id=bm.branch_id and a.status_id in (2) and a.not_punch is null and bm.firm_id in (2) order by branchname").Tables(0)
                Me.cmb_branch.DataSource = dt
                Me.cmb_branch.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_branch.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_branch.DataBind()
                'Dim cl_script0 As New System.Text.StringBuilder
                'cl_script0.Append("         alert('You are not authorised!!!!');")
                'cl_script0.Append("window.open('../home.aspx','_self');")
                'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)

                'dt4 = oh.ExecuteDataSet("select a.zonal_id,a.head_id from zonal_master a where a.operation_head=" & EMPCODE1 & "").Tables(0)
                'If dt4.Rows.Count >= 1 Then
                '    For Each dr In dt4.Rows
                '        str_tkn1.Append(dr(0))
                '        str_tkn1.Append(",")
                '    Next
                '    str_tkn1.Append("99")
                '    Me.hid_zonal.Value = str_tkn1.ToString
                'End If
                ''dt5 = oh.ExecuteDataSet("select 0, '--Branch--Requested Date--' as branchname from dual union select distinct (b.BRANCH_ID), b.BRANCH_NAME||'~'||to_char(to_date(a.requested_dt)) as branchname from hrm_anytimepunching_reg a, branch_dtl_new b where a.branch_id = b.BRANCH_ID and a.status_id = 2 and a.branch_id<>0 and a.not_punch is null and (to_date(a.requested_dt)=to_date(sysdate) or to_date(a.requested_dt)=to_date(sysdate-1)) order by branchname").Tables(0)
                'dt5 = oh.ExecuteDataSet("select 0, '--Branch--Requested Date--' as branchname from dual union select distinct (b.BRANCH_ID), b.BRANCH_NAME||'~'||to_char(to_date(a.requested_dt)) as branchname from hrm_anytimepunching_reg a, branch_dtl_new b where a.branch_id = b.BRANCH_ID and a.status_id = 2 and b.zonal_id in (" & Me.hid_zonal.Value & ") and a.branch_id<>0 and a.not_punch is null order by branchname").Tables(0)
                'If dt5.Rows.Count <= 1 Then
                '    Dim cl_script0 As New System.Text.StringBuilder
                '    cl_script0.Append("         alert('No Details for Approval!!!!');")
                '    cl_script0.Append("window.open('../home.aspx','_self');")
                '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                'Else
                '    Me.cmb_branch.DataSource = dt5
                '    Me.cmb_branch.DataTextField = dt5.Columns(1).ColumnName
                '    Me.cmb_branch.DataValueField = dt5.Columns(0).ColumnName
                '    Me.cmb_branch.DataBind()
                'End If
            Else
                dt = oh.ExecuteDataSet("select count(*) from form_accessibility where form_id=" & ID & " and emp_id=" & User(0) & "").Tables(0)
                If dt.Rows(0)(0) = 0 Then
                    'Jwellery Approval
                    'dt = oh.ExecuteDataSet("select a.emp_code from employee_master a where a.emp_code=" & User(0) & " and a.designation_id in (25) and a.department_id in (290) and a.status_id=1").Tables(0)
                    dt = oh.ExecuteDataSet("select a.emp_code from employee_master a where a.emp_code=" & User(0) & " and a.emp_code=11090").Tables(0)
                    If dt.Rows.Count >= 1 Then
                        'dt = oh.ExecuteDataSet("select 0, '--Branch--Requested Date---' as branchname from dual union select distinct (b.BRANCH_ID), b.BRANCH_NAME||'~'||to_char(to_date(a.requested_dt)) as branchname from hrm_anytimepunching_reg a, branch_dtl_new b,branch_master bm where a.branch_id = b.BRANCH_ID and a.branch_id=bm.branch_id and a.status_id = 11 and a.not_punch is null and (to_date(a.requested_dt)=to_date(sysdate) or to_date(a.requested_dt)=to_date(sysdate-1)) and bm.status_id=2 order by branchname").Tables(0)
                        dt = oh.ExecuteDataSet("select 0, '--Branch--Requested Date---' as branchname from dual union select distinct (b.BRANCH_ID), b.BRANCH_NAME||'~'||to_char(to_date(a.requested_dt)) as branchname from hrm_anytimepunching_reg a, branch_dtl_new b,branch_master bm where a.branch_id = b.BRANCH_ID and a.branch_id=bm.branch_id and a.status_id in (11,10) and a.not_punch is null and bm.status_id in (2,3) order by branchname").Tables(0)
                        Me.cmb_branch.DataSource = dt
                        Me.cmb_branch.DataTextField = dt.Columns(1).ColumnName
                        Me.cmb_branch.DataValueField = dt.Columns(0).ColumnName
                        Me.cmb_branch.DataBind()
                    ElseIf UserId = 10132 Then
                        dt = oh.ExecuteDataSet("select 0, '--Branch--Requested Date---' as branchname from dual union select distinct (b.BRANCH_ID),b.BRANCH_NAME || '~' || to_char(to_date(a.requested_dt)) as branchname from hrm_anytimepunching_reg a, branch_master b,employee_master e where a.requested_by=e.emp_code and b.status_id=3 and a.branch_id = b.BRANCH_ID and e.department_id not in (4, 178, 188, 211) and a.status_id = 11 and a.branch_id <> 0 and a.not_punch is null order by branchname").Tables(0)
                        Me.cmb_branch.DataSource = dt
                        Me.cmb_branch.DataTextField = dt.Columns(1).ColumnName
                        Me.cmb_branch.DataValueField = dt.Columns(0).ColumnName
                        Me.cmb_branch.DataBind()

                    Else
                        'Audit Approval
                        dt2 = oh.ExecuteDataSet("select a.zonal_id,a.hr_head from zonal_master a where a.hr_head=" & User(0) & "").Tables(0)
                        If dt2.Rows.Count >= 1 Then
                            Dim ZoneID As Integer = dt2.Rows(0)(0)
                            'dt6 = oh.ExecuteDataSet("select 0, '--Branch--Requested Date---' as branchname from dual union select distinct (b.BRANCH_ID), b.BRANCH_NAME||'~'||to_char(to_date(a.requested_dt)) as branchname from hrm_anytimepunching_reg a, branch_dtl_new b,employee_master bm where a.branch_id = b.BRANCH_ID and b.zonal_id =" & ZoneID & " and a.requested_by=bm.emp_code and  bm.department_id in (4, 178, 188, 23, 180) and a.status_id = 11 and a.not_punch is null and (to_date(a.requested_dt)=to_date(sysdate) or to_date(a.requested_dt)=to_date(sysdate-1)) order by branchname").Tables(0)
                            dt6 = oh.ExecuteDataSet("select 0, '--Branch--Requested Date---' as branchname from dual union select distinct (b.BRANCH_ID), b.BRANCH_NAME||'~'||to_char(to_date(a.requested_dt)) as branchname from hrm_anytimepunching_reg a, branch_dtl_new b,employee_master bm where a.branch_id = b.BRANCH_ID and b.zonal_id =" & ZoneID & " and a.requested_by=bm.emp_code and  bm.department_id in (4, 178, 188,211) and a.status_id = 11 and a.not_punch is null order by branchname").Tables(0)
                            Me.cmb_branch.DataSource = dt6
                            Me.cmb_branch.DataTextField = dt6.Columns(1).ColumnName
                            Me.cmb_branch.DataValueField = dt6.Columns(0).ColumnName
                            Me.cmb_branch.DataBind()
                        ElseIf UserId = 30133 Then
                            dt6 = oh.ExecuteDataSet("select 0, '--Branch--Requested Date---' as branchname  from dual  union  select distinct (b.BRANCH_ID),  b.BRANCH_NAME || '~' || to_char(to_date(a.requested_dt)) as branchname  from hrm_anytimepunching_reg a, branch_dtl_new b, employee_master bm  where a.branch_id = b.BRANCH_ID  and a.requested_by = bm.emp_code  and bm.department_id in (490)  and a.status_id in(10,11,0)  and a.not_punch is null  order by branchname").Tables(0)
                            Me.cmb_branch.DataSource = dt6
                            Me.cmb_branch.DataTextField = dt6.Columns(1).ColumnName
                            Me.cmb_branch.DataValueField = dt6.Columns(0).ColumnName
                            Me.cmb_branch.DataBind()
                        Else
                            Dim cl_script0 As New System.Text.StringBuilder
                            cl_script0.Append("         alert('You Are Not Authorised!!!!');")
                            cl_script0.Append("window.open('../home.aspx','_self');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                        End If
                    End If
                ElseIf UserId = 10132 Then
                    dt5 = oh.ExecuteDataSet("select 0, '--Branch--Requested Date---' as branchname from dual union select distinct (b.BRANCH_ID), b.BRANCH_NAME||'~'||to_char(to_date(a.requested_dt)) as branchname from hrm_anytimepunching_reg a, branch_dtl_new b,branch_master bm where a.branch_id = b.BRANCH_ID and a.branch_id=bm.branch_id and a.status_id in (11) and a.not_punch is null and bm.status_id in (3) order by branchname").Tables(0)
                    Me.cmb_branch.DataSource = dt5
                    Me.cmb_branch.DataTextField = dt5.Columns(1).ColumnName
                    Me.cmb_branch.DataValueField = dt5.Columns(0).ColumnName
                    Me.cmb_branch.DataBind()
                Else
                    'dt5 = oh.ExecuteDataSet("select 0, '--Branch--Requested Date---' as branchname from dual union select distinct (b.BRANCH_ID), b.BRANCH_NAME||'~'||to_char(to_date(a.requested_dt)) as branchname from hrm_anytimepunching_reg a, branch_dtl_new b where a.branch_id = b.BRANCH_ID and a.status_id = 2 and a.branch_id<>0 and a.not_punch is null and (to_date(a.requested_dt)=to_date(sysdate) or to_date(a.requested_dt)=to_date(sysdate-1)) order by branchname").Tables(0)
                    dt5 = oh.ExecuteDataSet("select 0, '--Branch--Requested Date---' as branchname from dual union select distinct (b.BRANCH_ID), b.BRANCH_NAME||'~'||to_char(to_date(a.requested_dt)) as branchname from hrm_anytimepunching_reg a, branch_dtl_new b where a.branch_id = b.BRANCH_ID and a.status_id = 2 and a.branch_id<>0 and a.not_punch is null order by branchname").Tables(0)
                    If dt5.Rows.Count <= 1 Then
                        Dim cl_script0 As New System.Text.StringBuilder
                        cl_script0.Append("         alert('You Are Not Authorised!!!!');")
                        cl_script0.Append("window.open('../home.aspx','_self');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                    Else
                        Me.cmb_branch.DataSource = dt5
                        Me.cmb_branch.DataTextField = dt5.Columns(1).ColumnName
                        Me.cmb_branch.DataValueField = dt5.Columns(0).ColumnName
                        Me.cmb_branch.DataBind()
                    End If
                End If
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
                    dt2 = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name || '*' || d.m_time || '*' ||b.in_time || '*' || r.remarks|| '*' || r.recommended_by|| ' - ' || ee.emp_name|| '*' || r.recommended_reason|| '*' ||p.post_name|| '*' ||'-'|| '*' ||'-' from daily_attend d,time_tab b,employee_master e,employee_master ee,hrm_anytimepunching_reg r,post_mst p where d.emp_code = e.emp_code and r.not_punch is null and e.post_id=p.post_id and r.branch_id=d.m_branch and d.m_shift = b.shift_id and e.department_id not in (4, 178, 188,211) and d.m_branch = " & CODE & " and d.m_time > b.in_time and e.emp_code > 10000 and d.m_branch <> 0 and d.emp_code = r.requested_by and r.status_id in (11,10) and r.recommended_by=ee.emp_code and to_date(r.requested_dt)=to_date('" & ReqDt & "') and (to_date(d.curr_date) =to_date('" & ReqDt & "') ) order by d.emp_code").Tables(0)
                    If dt2.Rows.Count <= 0 Then
                        dt2 = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name || '*' || d.m_time || '*' ||b.in_time || '*' || r.remarks|| '*' || r.recommended_by|| ' - ' || ee.emp_name|| '*' || r.recommended_reason|| '*' ||p.post_name|| '*' ||'-'|| '*' ||'-' from attend d,time_tab b,employee_master e,employee_master ee,hrm_anytimepunching_reg r,post_mst p where d.emp_code = e.emp_code and r.not_punch is null and e.post_id=p.post_id and r.branch_id=d.m_branch and d.m_shift = b.shift_id and e.department_id not in (4, 178, 188,211) and d.m_branch = " & CODE & " and d.m_time > b.in_time and e.emp_code > 10000 and d.m_branch <> 0 and d.emp_code = r.requested_by and r.status_id in (11,10) and r.recommended_by=ee.emp_code and to_date(r.requested_dt)=to_date('" & ReqDt & "') and (to_date(d.curr_date) =to_date('" & ReqDt & "') ) order by d.emp_code").Tables(0)
                    End If
                Else
                    dt2 = oh.ExecuteDataSet("select a.zonal_id,a.hr_head from zonal_master a where a.hr_head=" & Userd(0) & "").Tables(0)
                    If dt2.Rows.Count >= 1 Then
                        dt2 = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name || '*' || d.m_time || '*' ||b.in_time || '*' || r.remarks|| '*' || r.recommended_by|| ' - ' || ee.emp_name|| '*' || r.recommended_reason|| '*' ||p.post_name|| '*' ||'-'|| '*' ||r.rm_recomm_reason from daily_attend d,time_tab b,employee_master e,employee_master ee,hrm_anytimepunching_reg r,post_mst p where d.emp_code = e.emp_code and r.not_punch is null and e.department_id in (4, 178, 188,211) and e.post_id=p.post_id and r.requested_by=d.emp_code and ee.emp_code=r.recommended_by and d.m_shift = b.shift_id and r.branch_id = " & CODE & " and d.m_time > b.in_time and e.emp_code > 10000 and d.m_branch <> 0 and d.emp_code = r.requested_by and r.status_id = 11 and to_date(r.requested_dt)=to_date('" & ReqDt & "') and (to_date(d.curr_date) =to_date('" & ReqDt & "') ) order by d.emp_code").Tables(0)
                        If dt2.Rows.Count <= 0 Then
                            dt2 = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name || '*' || d.m_time || '*' ||b.in_time || '*' || r.remarks|| '*' || r.recommended_by|| ' - ' || ee.emp_name|| '*' || r.recommended_reason|| '*' ||p.post_name|| '*' ||'-'|| '*' ||r.rm_recomm_reason from attend d,time_tab b,employee_master e,employee_master ee,hrm_anytimepunching_reg r,post_mst p where d.emp_code = e.emp_code and r.not_punch is null and e.department_id in (4, 178, 188,211) and e.post_id=p.post_id and r.requested_by=d.emp_code and ee.emp_code=r.recommended_by and d.m_shift = b.shift_id and r.branch_id = " & CODE & " and d.m_time > b.in_time and e.emp_code > 10000 and d.m_branch <> 0 and d.emp_code = r.requested_by and r.status_id = 11 and to_date(r.requested_dt)=to_date('" & ReqDt & "') and (to_date(d.curr_date) =to_date('" & ReqDt & "') ) order by d.emp_code").Tables(0)
                        End If
                    Else
                        dt2 = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name || '*' || d.m_time || '*' ||b.in_time || '*' || r.remarks|| '*' || r.recommended_by|| ' - ' || ee.emp_name|| '*' || r.recommended_reason|| '*' ||p.post_name|| '*' ||r.am_recomm_reason|| '*' ||r.rm_recomm_reason from daily_attend d,time_tab b,employee_master e,employee_master ee,hrm_anytimepunching_reg r,post_mst p where d.emp_code = e.emp_code and r.not_punch is null and e.department_id not in (4, 178, 188,211) and e.post_id=p.post_id and r.branch_id=d.m_branch and d.m_shift = b.shift_id and d.m_branch = " & CODE & " and d.m_time > b.in_time and e.emp_code > 10000 and d.m_branch <> 0 and d.emp_code = r.requested_by and r.status_id = 2 and r.recommended_by=ee.emp_code and to_date(r.requested_dt)=to_date('" & ReqDt & "') and (to_date(d.curr_date) =to_date('" & ReqDt & "') ) order by d.emp_code").Tables(0)
                        If dt2.Rows.Count <= 0 Then
                            dt2 = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name || '*' || d.m_time || '*' ||b.in_time || '*' || r.remarks|| '*' || r.recommended_by|| ' - ' || ee.emp_name|| '*' || r.recommended_reason|| '*' ||p.post_name|| '*' ||r.am_recomm_reason|| '*' ||r.rm_recomm_reason from attend d,time_tab b,employee_master e,employee_master ee,hrm_anytimepunching_reg r,post_mst p where d.emp_code = e.emp_code and r.not_punch is null and e.department_id not in (4, 178, 188,211) and e.post_id=p.post_id and r.branch_id=d.m_branch and d.m_shift = b.shift_id and d.m_branch = " & CODE & " and d.m_time > b.in_time and e.emp_code > 10000 and d.m_branch <> 0 and d.emp_code = r.requested_by and r.status_id = 2 and r.recommended_by=ee.emp_code and to_date(r.requested_dt)=to_date('" & ReqDt & "') and (to_date(d.curr_date) =to_date('" & ReqDt & "') ) order by d.emp_code").Tables(0)
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
                dt = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name || '*' || d.m_time || '*' ||b.in_time|| '*' ||p.post_name  from daily_attend d, time_tab b, employee_master e,post_mst p where d.emp_code = e.emp_code and e.branch_id = d.m_branch and d.m_shift = b.shift_id  and d.m_branch = " & CODE & " and d.m_time <= b.in_time  and e.post_id=p.post_id and e.emp_code > 10000 and to_date(d.curr_date)=to_date('" & ReqDt & "') and d.m_branch <> 0 order by d.emp_code").Tables(0)
                If dt.Rows.Count <= 0 Then
                    dt = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name || '*' || d.m_time || '*' ||b.in_time|| '*' ||p.post_name  from attend d, time_tab b, employee_master e,post_mst p where d.emp_code = e.emp_code and e.branch_id = d.m_branch and d.m_shift = b.shift_id  and d.m_branch = " & CODE & " and d.m_time <= b.in_time  and e.post_id=p.post_id and e.emp_code > 10000 and to_date(d.curr_date)=to_date('" & ReqDt & "') and d.m_branch <> 0 order by d.emp_code").Tables(0)
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
                    oh.ExecuteNonQuery("hrm_AnyTimePunch_Approv", p)
                    CbResult = p(4).Value
                Catch ex As Exception
                    CbResult = ex.Message
                End Try
        End Select
    End Sub
End Class

Imports System.Data
Imports System.Data.OracleClient
Partial Class AnyTimePunching_New_hrm_AnyTimePunch_RH_671e60db5004
    Inherits System.Web.UI.Page
    Implements Web.UI.ICallbackEventHandler
    Dim dt, dt1, dt2, dt4, dt5, dt10, dt6 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim BranchID, AreaID, RegionID As Integer
    Dim str_tkn, str_tkn1, str_tknw As New System.Text.StringBuilder
    Dim str As New System.Text.StringBuilder
    Dim CbResult As String = Nothing
    Dim dr As DataRow
    Dim PostID, DesID, DepID As Integer
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
        dt = oh.ExecuteDataSet("select t.branch_id,t.post_id,t.department_id,t.designation_id from employee_master t where t.status_id=1 and t.emp_code=" & User(0) & "").Tables(0)
        PostID = dt.Rows(0)(1)
        Me.hid_post.value = PostID
        BranchID = dt.Rows(0)(0)
        DesID = dt.Rows(0)(3)
        DepID = dt.Rows(0)(2)
        dt1 = oh.ExecuteDataSet("select b.area_id,b.reg_id  from  branch_dtl_new b where b.branch_id=" & BranchID & "").Tables(0)
        AreaID = dt1.Rows(0)(0)
        RegionID = dt1.Rows(0)(1)

        If PostID = 136 Or PostID = 197 Then 'AH or AM 
            'dt = oh.ExecuteDataSet("select 0 as bid,' --------SELECT----------' as  bname from dual union all select  distinct b.BRANCH_ID, b.branch_name ||'~'|| to_char(to_date(r.requested_dt)) as bname from  branch_dtl_new b,hrm_anytimepunching_reg r where b.area_id= " & AreaID & " and b.branch_id = r.branch_id and r.status_id=0 and r.branch_id<>0 and r.not_punch is null and (to_date(r.requested_dt)=to_date(sysdate) or to_date(r.requested_dt)=to_date(sysdate-1)) order by bname").Tables(0)
            dt = oh.ExecuteDataSet("select 0 as bid,' --------SELECT----------' as  bname from dual union all select  distinct b.BRANCH_ID, b.branch_name ||'~'|| to_char(to_date(r.requested_dt)) as bname from  branch_dtl_new b,hrm_anytimepunching_reg r where b.area_id= " & AreaID & " and b.branch_id = r.branch_id and r.status_id=0 and r.branch_id<>0 and r.not_punch is null order by bname").Tables(0)
            Me.cmb_branch.DataSource = dt
            Me.cmb_branch.DataValueField = dt.Columns(0).ColumnName
            Me.cmb_branch.DataTextField = dt.Columns(1).ColumnName
            Me.cmb_branch.DataBind()
        ElseIf PostID = 199 Or PostID = 278 Or PostID = 282 Or PostID = 28 Or PostID = 245 Or PostID = 247 Or PostID = 244 Or PostID = 275 Then  'RM 
            'dt2 = oh.ExecuteDataSet("select distinct (z.area_id),z.region_id from view_branch z where not exists (select v.area_id from employee_master e, daily_attend a,ids_branch v where e.status_id = 1 and e.post_id in (136, 197) and e.emp_code = a.emp_code and e.branch_id=v.branch_id and a.m_time is not null and v.area_id=z.area_id)").Tables(0)
            'If dt.Rows.Count > 0 Then
            '    For Each dr In dt.Rows
            '        str_tkn.Append(dr(0))
            '        str_tkn.Append(",")
            '    Next
            '    str_tkn.Append("999")
            '    Me.hid_area.Value = str_tkn.ToString
            'End If
            'dt = oh.ExecuteDataSet("select 0 as bid,' --------SELECT----------' as  bname from dual union all select  distinct b.BRANCH_ID, b.branch_name ||'~'|| to_char(to_date(r.requested_dt)) as bname from  branch_dtl_new b,hrm_anytimepunching_reg r where b.reg_id = " & RegionID & "  and b.branch_id = r.branch_id and r.status_id=9 and r.branch_id<>0 and r.not_punch is null and (to_date(r.requested_dt)=to_date(sysdate) or to_date(r.requested_dt)=to_date(sysdate-1)) order by bname ").Tables(0)
            dt2 = oh.ExecuteDataSet("select a.ia_tour_head,a.reg_id from region_master a where a.ia_tour_head=" & UserId & "").Tables(0)
            If dt2.Rows.Count >= 1 Then
                Dim REGGID As String
                For Each dr In dt2.Rows
                    str_tknw.Append(dr(1))
                    str_tknw.Append(",")
                Next
                str_tknw.Append("999")
                REGGID = str_tknw.ToString
                If DepID = 4 Or DepID = 211 Or DepID = 178 Or DepID = 188 Then
                    dt = oh.ExecuteDataSet("select 0 as bid, ' --------SELECT----------' as bname from dual union select distinct b.BRANCH_ID,b.branch_name || '~' || to_char(to_date(r.requested_dt)) as bname from branch_dtl_new b, hrm_anytimepunching_reg r,employee_master e where b.reg_id =" & RegionID & " and r.requested_by=e.emp_code   and b.branch_id = r.branch_id and r.status_id = 10 and e.department_id  in(4, 178, 188,211) and r.branch_id <> 0 and r.not_punch is null").Tables(0)
                    Me.cmb_branch.DataSource = dt
                    Me.cmb_branch.DataValueField = dt.Columns(0).ColumnName
                    Me.cmb_branch.DataTextField = dt.Columns(1).ColumnName
                    Me.cmb_branch.DataBind()
                Else
                    dt = oh.ExecuteDataSet("select 0 as bid, ' --------SELECT----------' as bname from dual union all select distinct b.BRANCH_ID,b.branch_name || '~' || to_char(to_date(r.requested_dt)) as bname from branch_dtl_new b, hrm_anytimepunching_reg r,employee_master e where b.reg_id = " & RegionID & "  and b.branch_id = r.branch_id and r.requested_by=e.emp_code and e.department_id  not in(4, 178, 188,211) and r.status_id = 9 and r.branch_id <> 0 and r.not_punch is null union all select distinct b.BRANCH_ID,b.branch_name || '~' || to_char(to_date(r.requested_dt)) as bname from branch_dtl_new b, hrm_anytimepunching_reg r,employee_master e where b.reg_id =" & RegionID & " and r.requested_by=e.emp_code   and b.branch_id = r.branch_id and r.status_id = 10 and e.department_id  in(4, 178, 188,211) and r.branch_id <> 0 and r.not_punch is null").Tables(0)
                    Me.cmb_branch.DataSource = dt
                    Me.cmb_branch.DataValueField = dt.Columns(0).ColumnName
                    Me.cmb_branch.DataTextField = dt.Columns(1).ColumnName
                    Me.cmb_branch.DataBind()
                End If
            Else
                dt = oh.ExecuteDataSet("select distinct b1.area_id from branch_dtl_new b1, branch_dtl_new b2, emp_master e2 where not exists (select br.area_id from daily_attend a, emp_master e, branch_dtl_new br where a.emp_code = e.emp_code  and e.branch_id = br.BRANCH_ID  and a.m_time is not null and a.m_time not in ('TOUR', 'COMPEN') and e.post_id in (136, 197) and br.area_id = b1.area_id) and b1.reg_id = b2.reg_id and b2.BRANCH_ID = e2.branch_id and e2.post_id in (28, 199, 245, 247, 282) and e2.status_id = 1 and b2.reg_id =" & RegionID & "").Tables(0)
                If dt.Rows.Count >= 1 Then
                    For Each dr In dt.Rows
                        str_tkn1.Append(dr(0))
                        str_tkn1.Append(",")
                    Next
                    str_tkn1.Append("9999")
                    Me.hid_s.Value = str_tkn1.ToString
                Else
                    Me.hid_s.Value = 9999
                End If
                dt = oh.ExecuteDataSet("select 0 as bid,' --------SELECT----------' as  bname from dual union all select  distinct b.BRANCH_ID, b.branch_name ||'~'|| to_char(to_date(r.requested_dt)) as bname from  branch_dtl_new b,hrm_anytimepunching_reg r,employee_master e where b.reg_id = " & RegionID & "  and b.branch_id = r.branch_id and r.status_id=9 and r.branch_id<>0 and r.requested_by=e.emp_code and e.department_id  not in(4, 178, 188,211) and r.not_punch is null union all select distinct b.BRANCH_ID,b.branch_name || '~' || to_char(to_date(r.requested_dt)) as bname from branch_dtl_new b, hrm_anytimepunching_reg r, employee_master e where b.reg_id = " & RegionID & " and b.area_id in (" & Me.hid_s.Value & ")  and b.branch_id = r.branch_id and r.status_id =0 and r.branch_id <> 0 and r.requested_by = e.emp_code and e.department_id not in (4, 178, 188, 211) and r.not_punch is null order by bname").Tables(0)
                Me.cmb_branch.DataSource = dt
                Me.cmb_branch.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_branch.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_branch.DataBind()
            End If
        Else
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('You are not Authorised to View this Page !!!!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        End If
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return CbResult
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim UserIId As Integer = User(0)
        dt1 = oh.ExecuteDataSet("select to_date(sysdate) from dual").Tables(0)
        Me.hdn_sysdate.Value = Format(dt1.Rows(0)(0), "dd/MMM/yy")
        Dim DataStr() As String
        DataStr = eventArgument.Split("#")
        Select Case (DataStr(1))
            Case 1
                Dim Instr() As String = DataStr(0).Split("%")
                Dim CODE As String = Instr(0)
                Dim ReqDt As String = Instr(1)
                Dim reqdate As Date = CDate(ReqDt)
                dt = oh.ExecuteDataSet("select t.post_id,t.department_id,t.designation_id  from employee_master t where t.emp_code=" & User(0) & "").Tables(0)
                PostID = dt.Rows(0)(0)
                DesID = dt.Rows(0)(2)
                DepID = dt.Rows(0)(1)
                If PostID = 136 Or PostID = 197 Then 'AH Or AM
                    If reqdate = Me.hdn_sysdate.Value Then
                        dt2 = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name || '*' || d.m_time || '*' ||b.in_time|| '*' ||r.remarks|| '*' ||p.post_name|| '*' ||'-'|| '*' ||'-' from daily_attend d, time_tab b, employee_master e,hrm_anytimepunching_reg r,post_mst p where d.emp_code = e.emp_code and r.not_punch is null and r.branch_id=d.m_branch and e.post_id=p.post_id and d.m_shift = b.shift_id and d.m_branch = " & CODE & " and d.m_time > b.in_time and e.emp_code > 10000 and d.m_branch <> 0 and d.emp_code =r.requested_by and r.status_id=0 and to_date(d.curr_date) =to_date('" & ReqDt & "') order by d.emp_code").Tables(0)
                    Else
                        dt2 = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name || '*' || d.m_time || '*' ||b.in_time|| '*' ||r.remarks|| '*' ||p.post_name|| '*' ||'-'|| '*' ||'-' from attend d, time_tab b, employee_master e,hrm_anytimepunching_reg r,post_mst p where d.emp_code = e.emp_code and r.not_punch is null and r.branch_id=d.m_branch and e.post_id=p.post_id and d.m_shift = b.shift_id and d.m_branch = " & CODE & " and d.m_time > b.in_time and e.emp_code > 10000 and d.m_branch <> 0 and d.emp_code =r.requested_by and r.status_id=0 and to_date(d.curr_date) =to_date('" & ReqDt & "') order by d.emp_code").Tables(0)
                    End If

                    Dim dr As DataRow
                    For Each dr In dt2.Rows
                        str_tkn.Append(dr(0))
                        str_tkn.Append("!")
                    Next
                    str_tkn.Append("@")
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
                ElseIf PostID = 199 Or PostID = 282 Or PostID = 28 Or PostID = 245 Or PostID = 247 Or PostID = 244 Then
                    If reqdate = Me.hdn_sysdate.Value Then
                        dt2 = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name || '*' || d.m_time || '*' ||b.in_time|| '*' ||r.remarks|| '*' ||p.post_name|| '*' ||r.am_recomm_reason|| '*' ||'-' from daily_attend d, time_tab b, employee_master e,hrm_anytimepunching_reg r,post_mst p where d.emp_code = e.emp_code and r.not_punch is null and r.branch_id=d.m_branch and e.post_id=p.post_id and d.m_shift = b.shift_id and d.m_branch = " & CODE & " and d.m_time > b.in_time and e.department_id not in (4, 178, 188,211) and d.m_branch <> 0 and d.emp_code =r.requested_by and r.status_id in (9,0) and to_date(d.curr_date) =to_date('" & ReqDt & "') union all select e.emp_code || '*' || e.emp_name || '*' || d.m_time || '*' ||b.in_time|| '*' ||r.remarks|| '*' ||p.post_name|| '*' ||r.am_recomm_reason|| '*' ||'-' from daily_attend d, time_tab b, employee_master e,hrm_anytimepunching_reg r,post_mst p where d.emp_code = e.emp_code and r.not_punch is null and r.branch_id=d.m_branch and e.post_id=p.post_id and d.m_shift = b.shift_id and d.m_branch = " & CODE & " and d.m_time > b.in_time and e.department_id in (4, 178, 188,211) and d.m_branch <> 0 and d.emp_code =r.requested_by and r.status_id=10 and to_date(d.curr_date) =to_date('" & ReqDt & "')").Tables(0)
                    Else
                        dt2 = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name || '*' || d.m_time || '*' ||b.in_time|| '*' ||r.remarks|| '*' ||p.post_name|| '*' ||r.am_recomm_reason|| '*' ||'-' from attend d, time_tab b, employee_master e,hrm_anytimepunching_reg r,post_mst p where d.emp_code = e.emp_code and r.not_punch is null and r.branch_id=d.m_branch and e.post_id=p.post_id and d.m_shift = b.shift_id and d.m_branch = " & CODE & " and d.m_time > b.in_time and e.department_id not in (4, 178, 188,211) and d.m_branch <> 0 and d.emp_code =r.requested_by and r.status_id in (9,0) and to_date(d.curr_date) =to_date('" & ReqDt & "') union all select e.emp_code || '*' || e.emp_name || '*' || d.m_time || '*' ||b.in_time|| '*' ||r.remarks|| '*' ||p.post_name|| '*' ||r.am_recomm_reason|| '*' ||'-' from attend d, time_tab b, employee_master e,hrm_anytimepunching_reg r,post_mst p where d.emp_code = e.emp_code and r.not_punch is null and r.branch_id=d.m_branch and e.post_id=p.post_id and d.m_shift = b.shift_id and d.m_branch = " & CODE & " and d.m_time > b.in_time and e.department_id in (4, 178, 188,211) and d.m_branch <> 0 and d.emp_code =r.requested_by and r.status_id=10 and to_date(d.curr_date) =to_date('" & ReqDt & "')").Tables(0)
                    End If
                    Dim dr As DataRow
                    For Each dr In dt2.Rows
                        str_tkn.Append(dr(0))
                        str_tkn.Append("!")
                    Next
                    str_tkn.Append("@")
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
                End If
            Case 2
                Dim Instr() As String = DataStr(0).Split("%")
                Dim Dataa As String = Instr(0)
                Dim UserID As Integer = Instr(1)
                Dim BrID As Integer = Instr(2)
                Dim ReqDT As Date = Instr(3)
                Try
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
                    oh.ExecuteNonQuery("hrm_AnyTimePunch_AMRecomm", p)
                    CbResult = p(4).Value
                Catch ex As Exception
                    CbResult = ex.Message
                End Try
        End Select
    End Sub
End Class

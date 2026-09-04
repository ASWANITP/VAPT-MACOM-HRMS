Imports System.Data
Imports System.Data.OracleClient
Partial Class Punching_Sanction_hrm_punching_Recommendation_994262ab4327
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim cbResult As String
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2, dt4, dt10 As New DataTable
    Dim UserAll(), res, sql, str As String
    Dim UserCode As Integer
    Dim PostID, BranchID, AreaID, RegID As Integer
    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn As New System.Text.StringBuilder
    Dim str_tkn1, str_tknw As New System.Text.StringBuilder
    Dim DesID As Integer
    Dim DepID As Integer
    Dim dr As DataRow
    Dim authorised As Integer = 0
    Dim rule As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim script_val As String
        script_val = "var header;" & "header='" & Me.ddlBranch.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function callserver (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "callserver", cbscript, True)
        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "PUNCH REGULARIZATION"
        If Not IsPostBack Then
            dt10 = oh.ExecuteDataSet("select count(*) from employee_block_dtl e where e.emp_code=" & UserCode & " and e.block_id=212 and e.block_status=1").Tables(0)
            If dt10.Rows(0)(0) > 0 Then
                oh.ExecuteNonQuery("UPDATE employee_block_dtl t set t.block_status=0 where  t.emp_code=" & UserCode & " and t.block_id=212 and to_date(block_date)=to_date(sysdate)")
            End If

            dt = oh.ExecuteDataSet("select t.branch_id,t.post_id,t.department_id,t.designation_id from employee_master t where t.status_id=1 and t.emp_code=" & UserCode & "").Tables(0)
            PostID = dt.Rows(0)(1)
            Me.hid_post.Value = PostID
            BranchID = dt.Rows(0)(0)
            DesID = dt.Rows(0)(3)
            DepID = dt.Rows(0)(2)
            Dim dt2 As New DataTable
            '''''''''HEAD OFFICE
            If BranchID = 0 Then
                If UserCode = 23045 Then  ''maben
                    dt = oh.ExecuteDataSet("select '-1' as bid, '--------SELECT----------' as bname  from dual  union all select distinct b.BRANCH_ID || '~' || r.reg_status || '~' || r.status_id,  b.branch_name || '~' || r.att_req_dt || '~' ||  decode(r.reg_status,  1,  'Morning Punch',  2,  'Evening Punch',  3,  'M & E punch') as bname  from branch_master b, hrm_anytimepunching_reg r, employee_master m  where b.branch_id = r.branch_id  and b.firm_id = 2  and r.status_id = 2  and r.not_punch = 1  and r.requested_by = m.emp_code  order by bname").Tables(0)
                    Me.ddlBranch.DataSource = dt
                    Me.ddlBranch.DataValueField = dt.Columns(0).ColumnName
                    Me.ddlBranch.DataTextField = dt.Columns(1).ColumnName
                    Me.ddlBranch.DataBind()
                    authorised = 1
                    rule = 4
                    Me.hid_rule.Value = rule


                ElseIf PostID = 173 Then    ''RH OPERATION
                    dt2 = oh.ExecuteDataSet("select a.zonal_id,a.head_id from zonal_master a where a.head_id=" & UserCode & "").Tables(0)
                    Dim ZoneID As Integer = dt2.Rows(0)(0)
                    dt = oh.ExecuteDataSet("select '-1' as bid,'--------SELECT----------' as  bname from dual union all select  distinct b.BRANCH_ID||'~'||r.reg_status||'~'||r.status_id, b.branch_name ||'~'|| r.att_req_dt||'~'||decode(r.reg_status,1,'Morning Punch',2,'Evening Punch',3,'M & E punch') as  bname from  branch_dtl_new b,hrm_anytimepunching_reg r where  b.zonal_id =" & ZoneID & " and b.branch_id = r.branch_id and r.status_id=3 and r.not_punch=1 order by bname").Tables(0)
                    Me.ddlBranch.DataSource = dt
                    Me.ddlBranch.DataValueField = dt.Columns(0).ColumnName
                    Me.ddlBranch.DataTextField = dt.Columns(1).ColumnName
                    Me.ddlBranch.DataBind()
                    authorised = 0
                    rule = 1
                    Me.hid_rule.Value = rule
                ElseIf PostID = 195 Then   ''RH HRM --To regularise auditors N/M
                    dt2 = oh.ExecuteDataSet("select a.zonal_id,a.head_id from zonal_master a where a.hr_head=" & UserCode & "").Tables(0)
                    Dim ZoneID As Integer = dt2.Rows(0)(0)
                    dt = oh.ExecuteDataSet("select '-1' as bid,'--------SELECT----------' as  bname from dual union all select distinct bb.BRANCH_ID || '~' || rr.reg_status||'~'||rr.status_id,bb.branch_name || '~' || rr.att_req_dt || '~' ||decode(rr.reg_status, 1, 'Morning Punch', 2, 'Evening Punch') as bname from branch_dtl_new bb, hrm_anytimepunching_reg rr,employee_master ee where bb.zonal_id =" & ZoneID & " and bb.branch_id = rr.branch_id and ee.emp_code=rr.requested_by and ee.department_id in (4, 178, 188,211) and rr.status_id = 11  and rr.not_punch = 1 order by bname").Tables(0)
                    Me.ddlBranch.DataSource = dt
                    Me.ddlBranch.DataValueField = dt.Columns(0).ColumnName
                    Me.ddlBranch.DataTextField = dt.Columns(1).ColumnName
                    Me.ddlBranch.DataBind()
                    authorised = 1
                    rule = 5
                    Me.hid_rule.Value = rule
                    'ElseIf (DesID = 25 Or DesID = 28 Or DesID = 27) And DepID = 44 Then     'JGM /GM 
                ElseIf UserCode = 21033 Or UserCode = 21804 Then
                    dt4 = oh.ExecuteDataSet("select a.zonal_id,a.head_id from zonal_master a where a.operation_head=" & UserCode & "").Tables(0)
                    If dt4.Rows.Count >= 1 Then
                        For Each dr In dt4.Rows
                            str_tkn1.Append(dr(0))
                            str_tkn1.Append(",")
                        Next
                        str_tkn1.Append("99")
                        Me.hid_zonal.Value = str_tkn1.ToString
                    End If
                    dt = oh.ExecuteDataSet("select '-1' as bid, '--------SELECT----------' as bname from dual union all select distinct b.BRANCH_ID||'~'||r.reg_status||'~'||r.status_id, b.branch_name || '~' || r.att_req_dt||'~'||decode(r.reg_status,1,'Morning Punch',2,'Evening Punch',3,'M & E punch') as bname from branch_dtl_new b, hrm_anytimepunching_reg r where  b.branch_id = r.branch_id and r.status_id = 4 and b.zonal_id in (" & Me.hid_zonal.Value & ") and r.not_punch=1 union all select distinct b.BRANCH_ID||'~'||r.reg_status, b.branch_name || '~' || r.att_req_dt||'~'||decode(r.reg_status,1,'Morning Punch',2,'Evening Punch',3,'M & E punch') as bname from branch_dtl_new b, hrm_anytimepunching_reg r,branch_master bm where  r.status_id = 11 and r.not_punch=1 and b.zonal_id in (" & Me.hid_zonal.Value & ") and b.BRANCH_ID=r.branch_id and r.branch_id=bm.branch_id and bm.status_id=2 order by bname").Tables(0)
                    Me.ddlBranch.DataSource = dt
                    Me.ddlBranch.DataValueField = dt.Columns(0).ColumnName
                    Me.ddlBranch.DataTextField = dt.Columns(1).ColumnName
                    Me.ddlBranch.DataBind()
                    authorised = 0
                    rule = 3
                    Me.hid_rule.Value = rule
                ElseIf PostID = 71 And DepID = 275 Then     'Sreejesh U V 
                    dt = oh.ExecuteDataSet("select '-1' as bid, '--------SELECT----------' as bname from dual union all select distinct b.BRANCH_ID||'~'||r.reg_status||'~'||r.status_id, b.branch_name || '~' || r.att_req_dt||'~'||decode(r.reg_status,1,'Morning Punch',2,'Evening Punch',3,'M & E punch') as bname from branch_dtl_new b, hrm_anytimepunching_reg r,branch_master bm where  r.status_id in(10) and r.not_punch=1 and b.BRANCH_ID=r.branch_id and r.branch_id=bm.branch_id and bm.status_id in (2,3) order by bname").Tables(0)
                    Me.ddlBranch.DataSource = dt
                    Me.ddlBranch.DataValueField = dt.Columns(0).ColumnName
                    Me.ddlBranch.DataTextField = dt.Columns(1).ColumnName
                    Me.ddlBranch.DataBind()
                    authorised = 1
                    rule = 4
                    Me.hid_rule.Value = rule
                    ' ElseIf (PostID = 85) And (DepID = 290) Then     'BALU HR
                ElseIf UserCode = 21627 Then     'BALU HR 
                    dt = oh.ExecuteDataSet("select '-1' as bid, '--------SELECT----------' as bname from dual union all select distinct b.BRANCH_ID||'~'||r.reg_status||'~'||r.status_id, b.branch_name || '~' || r.att_req_dt||'~'||decode(r.reg_status,1,'Morning Punch',2,'Evening Punch',3,'M & E punch') as bname from branch_dtl_new b, hrm_anytimepunching_reg r,branch_master bm where  r.status_id in (11) and r.not_punch=1 and b.BRANCH_ID=r.branch_id and r.branch_id=bm.branch_id and bm.status_id in (2,3) order by bname").Tables(0)
                    Me.ddlBranch.DataSource = dt
                    Me.ddlBranch.DataValueField = dt.Columns(0).ColumnName
                    Me.ddlBranch.DataTextField = dt.Columns(1).ColumnName
                    Me.ddlBranch.DataBind()
                    authorised = 1
                    rule = 4
                    Me.hid_rule.Value = rule
                    'ElseIf PostID = 71 And DepID = 179 Then      ' CM Audit  UserCode
                ElseIf UserCode = 30133 Then
                    dt = oh.ExecuteDataSet("select '-1' as bid, '--------SELECT----------' as bname from dual union all select distinct b.BRANCH_ID||'~'||r.reg_status||'~'||r.status_id, b.branch_name || '~' || r.att_req_dt||'~'||decode(r.reg_status,1,'Morning Punch',2,'Evening Punch',3,'M & E punch') as bname from branch_dtl_new b, hrm_anytimepunching_reg r,employee_master m  where  b.branch_id = r.branch_id and r.status_id = 20 and r.not_punch=1 and r.requested_by=m.emp_code and m.department_id in (4, 178, 188,211,490) order by bname").Tables(0)
                    Me.ddlBranch.DataSource = dt
                    Me.ddlBranch.DataValueField = dt.Columns(0).ColumnName
                    Me.ddlBranch.DataTextField = dt.Columns(1).ColumnName
                    Me.ddlBranch.DataBind()
                    authorised = 1
                    rule = 5
                    Me.hid_rule.Value = rule
                ElseIf UserCode = 11855 Or UserCode = 15200 Then
                    dt = oh.ExecuteDataSet("select '-1' as bid, '--------SELECT----------' as bname from dual union all select distinct b.BRANCH_ID || '~' || r.reg_status || '~' || r.status_id,b.branch_name || '~' || r.att_req_dt || '~' ||decode(r.reg_status,1,'Morning Punch',2,'Evening Punch',3,'M & E punch') as bname from branch_dtl_new b, hrm_anytimepunching_reg r, employee_master m where b.branch_id = r.branch_id and b.status_id=3  and r.status_id = 10 and r.not_punch = 1 and r.requested_by = m.emp_code order by bname").Tables(0)
                    Me.ddlBranch.DataSource = dt
                    Me.ddlBranch.DataValueField = dt.Columns(0).ColumnName
                    Me.ddlBranch.DataTextField = dt.Columns(1).ColumnName
                    Me.ddlBranch.DataBind()
                    authorised = 1
                    rule = 4
                    Me.hid_rule.Value = rule
                ElseIf UserCode = 10132 Then
                    dt = oh.ExecuteDataSet("select '-1' as bid, '--------SELECT----------' as bname from dual union all select distinct b.BRANCH_ID || '~' || r.reg_status || '~' || r.status_id,b.branch_name || '~' || r.att_req_dt || '~' ||decode(r.reg_status,1,'Morning Punch',2,'Evening Punch',3,'M & E punch') as bname from branch_dtl_new b, hrm_anytimepunching_reg r, employee_master m where b.branch_id = r.branch_id and b.status_id=3  and r.status_id = 11 and r.not_punch = 1 and r.requested_by = m.emp_code order by bname").Tables(0)
                    Me.ddlBranch.DataSource = dt
                    Me.ddlBranch.DataValueField = dt.Columns(0).ColumnName
                    Me.ddlBranch.DataTextField = dt.Columns(1).ColumnName
                    Me.ddlBranch.DataBind()
                    authorised = 1
                    rule = 4
                    Me.hid_rule.Value = rule

                ElseIf UserCode = 21350 Then  ''maben
                    dt = oh.ExecuteDataSet("select '-1' as bid, '--------SELECT----------' as bname  from dual  union all select distinct b.BRANCH_ID || '~' || r.reg_status || '~' || r.status_id,  b.branch_name || '~' || r.att_req_dt || '~' ||  decode(r.reg_status,  1,  'Morning Punch',  2,  'Evening Punch',  3,  'M & E punch') as bname  from branch_master b, hrm_anytimepunching_reg r, employee_master m  where b.branch_id = r.branch_id  and b.firm_id = 2  and r.status_id = 4  and r.not_punch = 1  and r.requested_by = m.emp_code  order by bname").Tables(0)
                    Me.ddlBranch.DataSource = dt
                    Me.ddlBranch.DataValueField = dt.Columns(0).ColumnName
                    Me.ddlBranch.DataTextField = dt.Columns(1).ColumnName
                    Me.ddlBranch.DataBind()
                    authorised = 1
                    rule = 4
                    Me.hid_rule.Value = rule

                End If
            End If
                '''''''''''BRANCH
                If BranchID <> 0 Then
                    dt1 = oh.ExecuteDataSet("select b.area_id,b.reg_id  from  branch_dtl_new b where b.branch_id=" & BranchID & "").Tables(0)
                    AreaID = dt1.Rows(0)(0)
                    RegID = dt1.Rows(0)(1)

                    If PostID = 136 Or PostID = 197 Then 'AH or AM 
                        dt = oh.ExecuteDataSet("select '-1' as bid,' --------SELECT----------' as  bname from dual union all select  distinct b.BRANCH_ID||'~'||r.reg_status||'~'||r.status_id, b.branch_name ||'~'|| r.att_req_dt||'~'||decode(r.reg_status,1,'Morning Punch',2,'Evening Punch',3,'M & E punch') as  bname from  branch_dtl_new b,hrm_anytimepunching_reg r,employee_master a,attend_his h where b.area_id= " & AreaID & " and b.branch_id = r.branch_id and r.requested_by=h.emp_code and to_date(r.att_req_dt)=h.CURR_DATE and r.requested_by=a.emp_code and a.department_id not in (4, 178, 188,211) and r.status_id=0 and r.not_punch=1 order by bname").Tables(0)
                        Me.ddlBranch.DataSource = dt
                        Me.ddlBranch.DataValueField = dt.Columns(0).ColumnName
                        Me.ddlBranch.DataTextField = dt.Columns(1).ColumnName
                        Me.ddlBranch.DataBind()
                        authorised = 1
                        rule = 6
                        Me.hid_rule.Value = rule
                    ElseIf UserCode = 11855 Or UserCode = 15200 Then
                        dt = oh.ExecuteDataSet("select '-1' as bid, '--------SELECT----------' as bname from dual union all select distinct b.BRANCH_ID || '~' || r.reg_status || '~' || r.status_id,b.branch_name || '~' || r.att_req_dt || '~' ||decode(r.reg_status,1,'Morning Punch',2,'Evening Punch',3,'M & E punch') as bname from branch_dtl_new b, hrm_anytimepunching_reg r, employee_master m where b.branch_id = r.branch_id and b.status_id=3  and r.status_id = 10 and r.not_punch = 1 and r.requested_by = m.emp_code order by bname").Tables(0)
                        Me.ddlBranch.DataSource = dt
                        Me.ddlBranch.DataValueField = dt.Columns(0).ColumnName
                        Me.ddlBranch.DataTextField = dt.Columns(1).ColumnName
                        Me.ddlBranch.DataBind()
                        authorised = 1
                        rule = 4
                        Me.hid_rule.Value = rule
                        'ElseIf UserCode = 30133 Then
                        '    dt = oh.ExecuteDataSet("select '-1' as bid, '--------SELECT----------' as bname from dual union all select distinct b.BRANCH_ID||'~'||r.reg_status||'~'||r.status_id, b.branch_name || '~' || r.att_req_dt||'~'||decode(r.reg_status,1,'Morning Punch',2,'Evening Punch',3,'M & E punch') as bname from branch_dtl_new b, hrm_anytimepunching_reg r,employee_master m  where  b.branch_id = r.branch_id and r.status_id = 20 and r.not_punch=1 and r.requested_by=m.emp_code and m.department_id in (490) order by bname").Tables(0)
                        '    Me.ddlBranch.DataSource = dt
                        '    Me.ddlBranch.DataValueField = dt.Columns(0).ColumnName
                        '    Me.ddlBranch.DataTextField = dt.Columns(1).ColumnName
                        '    Me.ddlBranch.DataBind()
                        '    authorised = 1
                        '    rule = 5
                        '    Me.hid_rule.Value = rule

                    ElseIf PostID = 199 Or PostID = 278 Or PostID = 282 Or PostID = 28 Or PostID = 245 Or PostID = 247 Or PostID = 244 Or PostID = 275 Then  'RM             
                        dt2 = oh.ExecuteDataSet("select distinct (z.area_id),z.region_id from view_branch z where not exists (select v.area_id from employee_master e, daily_attend a,ids_branch v where e.status_id = 1 and e.post_id in (136, 197) and e.emp_code = a.emp_code and e.branch_id=v.branch_id and a.m_time is not null and v.area_id=z.area_id)").Tables(0)
                        If dt.Rows.Count > 0 Then
                            For Each dr In dt.Rows
                                str_tkn.Append(dr(0))
                                str_tkn.Append(",")
                            Next
                            str_tkn.Append("999")
                            Me.hid_area.Value = str_tkn.ToString
                        End If
                        dt2 = oh.ExecuteDataSet("select a.ia_tour_head,a.reg_id from region_master a where a.ia_tour_head=" & UserCode & "").Tables(0)
                        If dt2.Rows.Count >= 1 Then
                            Dim REGGID As String
                            For Each dr In dt2.Rows
                                str_tknw.Append(dr(1))
                                str_tknw.Append(",")
                            Next
                            str_tknw.Append("999")
                            REGGID = str_tknw.ToString
                            If DepID = 4 Or DepID = 211 Or DepID = 178 Or DepID = 188 Then
                                dt = oh.ExecuteDataSet("select '-1' as bid, ' --------SELECT----------' as bname from dual union all select distinct b.BRANCH_ID || '~' || r.reg_status || '~' || r.status_id,b.branch_name || '~' || r.att_req_dt || '~' ||decode(r.reg_status,1,'Morning Punch',2,'Evening Punch',3,'M & E punch') as bname from branch_dtl_new b, hrm_anytimepunching_reg r, employee_master a,attend_his h where a.emp_code = r.requested_by and h.emp_code = r.requested_by and h.CURR_DATE=to_date(r.att_req_dt) and a.department_id  in (4, 178, 188,211)and b.reg_id in (" & REGGID & ") and b.branch_id = r.branch_id and r.status_id =10 and r.not_punch = 1 order by bname").Tables(0)
                                Me.ddlBranch.DataSource = dt
                                Me.ddlBranch.DataValueField = dt.Columns(0).ColumnName
                                Me.ddlBranch.DataTextField = dt.Columns(1).ColumnName
                                Me.ddlBranch.DataBind()
                                authorised = 1
                                rule = 9
                                Me.hid_rule.Value = rule
                            Else
                                dt = oh.ExecuteDataSet("select '-1' as bid, ' --------SELECT----------' as bname from dual union all select distinct b.BRANCH_ID || '~' || r.reg_status || '~' || r.status_id,b.branch_name || '~' || r.att_req_dt || '~' ||decode(r.reg_status,1,'Morning Punch',2,'Evening Punch',3,'M & E punch') as bname from branch_dtl_new b, hrm_anytimepunching_reg r, employee_master a,attend_his h where a.emp_code = r.requested_by and h.emp_code = r.requested_by and h.CURR_DATE=to_date(r.att_req_dt) and a.department_id  in (4, 178, 188,211)and b.reg_id in (" & REGGID & ") and b.branch_id = r.branch_id and r.status_id =10 and r.not_punch = 1 union all select distinct b.BRANCH_ID || '~' || r.reg_status|| '~' || r.status_id,b.branch_name || '~' || r.att_req_dt || '~' ||decode(r.reg_status,1,'Morning Punch',2,'Evening Punch',3,'M & E punch') as bname from branch_dtl_new b, hrm_anytimepunching_reg r, employee_master a where a.emp_code = r.requested_by and a.emp_code = r.requested_by and a.department_id not in (4, 178, 188,211) and b.reg_id in (" & REGGID & ") and b.branch_id = r.branch_id and r.status_id = 2 and r.not_punch = 1 order by bname").Tables(0)
                                Me.ddlBranch.DataSource = dt
                                Me.ddlBranch.DataValueField = dt.Columns(0).ColumnName
                                Me.ddlBranch.DataTextField = dt.Columns(1).ColumnName
                                Me.ddlBranch.DataBind()
                                authorised = 1
                                rule = 9
                                Me.hid_rule.Value = rule
                            End If
                        Else
                            dt = oh.ExecuteDataSet("select '-1' as bid,' --------SELECT----------' as  bname from dual union all select  distinct b.BRANCH_ID||'~'||r.reg_status||'~'||r.status_id,b.branch_name ||'~'|| r.att_req_dt||'~'||decode(r.reg_status,1,'Morning Punch',2,'Evening Punch',3,'M & E punch') as  bname from  branch_dtl_new b,hrm_anytimepunching_reg r,employee_master a,attend_his h where a.emp_code=r.requested_by and h.emp_code = r.requested_by and h.CURR_DATE=to_date(r.att_req_dt) and a.department_id not in (4, 178, 188,211) and  b.reg_id = " & RegID & " and b.branch_id = r.branch_id and r.status_id=2 and r.not_punch=1 union all select  distinct b.BRANCH_ID||'~'||r.reg_status|| '~' || r.status_id, b.branch_name ||'~'|| r.att_req_dt||'~'||decode(r.reg_status,1,'Morning Punch',2,'Evening Punch',3,'M & E punch') as  bname from  branch_dtl_new b,hrm_anytimepunching_reg r,employee_master a  where  a.emp_code=r.requested_by and a.emp_code=r.requested_by and a.department_id not in (4, 178, 188,211)  and b.area_id in (" & Me.hid_area.Value & ") and b.branch_id = r.branch_id and r.status_id=0 and r.not_punch=1 order by bname").Tables(0)
                            Me.ddlBranch.DataSource = dt
                            Me.ddlBranch.DataValueField = dt.Columns(0).ColumnName
                            Me.ddlBranch.DataTextField = dt.Columns(1).ColumnName
                            Me.ddlBranch.DataBind()
                            authorised = 1
                            rule = 7
                            Me.hid_rule.Value = rule
                            'End If
                            'Else
                            '    dt2 = oh.ExecuteDataSet("select a.reg_id,a.ia_tour_head from region_master a where a.ia_tour_head=" & UserCode & "").Tables(0)
                            '    Dim IATOURHEAD As Integer = dt2.Rows(0)(0)
                            '    dt = oh.ExecuteDataSet("select '-1' as bid,'--------SELECT----------' as  bname from dual union all select distinct bb.BRANCH_ID || '~' || rr.reg_status||'~'||rr.status_id,bb.branch_name || '~' || rr.att_req_dt || '~' ||decode(rr.reg_status, 1, 'Morning Punch', 2, 'Evening Punch') as bname from branch_dtl_new bb, hrm_anytimepunching_reg rr,employee_master ee where bb.reg_id =" & IATOURHEAD & " and bb.branch_id = rr.branch_id and ee.emp_code=rr.requested_by and ee.department_id in (4,178,188,211) and rr.status_id = 10  and rr.not_punch = 1 order by bname").Tables(0)
                            '    Me.ddlBranch.DataSource = dt
                            '    Me.ddlBranch.DataValueField = dt.Columns(0).ColumnName
                            '    Me.ddlBranch.DataTextField = dt.Columns(1).ColumnName
                            '    Me.ddlBranch.DataBind()
                            '    authorised = 1
                            '    rule = 5
                            '    Me.hid_rule.Value = rule
                        End If
                    End If
                End If
                If authorised = 0 Then
                    Me.Server.Transfer("../show_err.aspx")
                ElseIf Me.ddlBranch.Items.Count = 1 Then
                    Dim cl_script0 As New System.Text.StringBuilder
                    cl_script0.Append("         alert('No Request Found!!!!');")
                    cl_script0.Append("window.open('../home.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                End If
            End If
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return cbResult
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim cal_data = eventArgument
        Dim str() As String
        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)
        dt1 = oh.ExecuteDataSet("select to_date(sysdate) from dual").Tables(0)
        Me.hdn_sysdate.Value = Format(dt1.Rows(0)(0), "dd/MMM/yy")
        str = cal_data.ToString.Split("$")
        Dim st As New StringBuilder
        Dim x = str(0)
        Select Case (x)
            Case "1"
                Dim DATA = str(1).Split("%")
                Dim BrId As Integer = DATA(0)
                Dim ReqDt As String = DATA(1)
                Dim ATTSTATUS As Integer = DATA(2)
                Dim STATUSTYPE As Integer = DATA(3)
                Dim dt As DataTable
                Dim reqdate As Date = CDate(ReqDt)
                Dim rule As Integer = DATA(4)
                'displays employee details
                Dim tab As DataTable
                If rule = 5 Then   'auditors
                    If reqdate = Me.hdn_sysdate.Value Then
                        tab = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name || '*' || f.failure_name || '*' || p.post_name || '*' || r.branch_id || '*' || r.am_recomm_reason || '*' || r.rm_recomm_reason || '*' || r.recommended_reason from hrm_anytimepunching_reg r,employee_master         e,daily_attend            d,  post_mst                p, branch_failure          f where r.status_id = " & STATUSTYPE & " and r.not_punch = 1 and r.branch_id =" & BrId & "  and f.failure_id = r.remarks and e.department_id  in(4, 178, 188,211,490) and r.reg_status = " & ATTSTATUS & " and e.post_id = p.post_id  and d.emp_code = e.emp_code  and d.emp_code = r.requested_by ").Tables(0)
                    Else
                        tab = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name || '*' || f.failure_name || '*' || p.post_name || '*' || r.branch_id || '*' || r.am_recomm_reason || '*' || r.rm_recomm_reason || '*' ||r.recommended_reason from hrm_anytimepunching_reg r,employee_master         e,attend            d,  post_mst                p, branch_failure          f where r.status_id = " & STATUSTYPE & " and r.not_punch = 1 and r.branch_id =" & BrId & "  and f.failure_id = r.remarks and e.department_id  in(4, 178, 188,211,490) and r.reg_status = " & ATTSTATUS & " and e.post_id = p.post_id  and d.emp_code = e.emp_code  and d.emp_code = r.requested_by and to_date(r.att_req_dt) = to_date('" & ReqDt & "')and d.curr_date=to_date('" & ReqDt & "')").Tables(0)
                    End If
                ElseIf rule = 9 Then
                    If reqdate = Me.hdn_sysdate.Value Then
                        tab = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name || '*' || f.failure_name || '*' || p.post_name || '*' || r.branch_id || '*' || r.am_recomm_reason || '*' || r.rm_recomm_reason || '*' || r.recommended_reason from hrm_anytimepunching_reg r,employee_master         e,daily_attend            d,  post_mst                p, branch_failure          f where r.status_id = " & STATUSTYPE & " and r.not_punch = 1 and r.branch_id =" & BrId & "  and f.failure_id = r.remarks and e.department_id  in(4, 178, 188,211) and r.reg_status = " & ATTSTATUS & " and e.post_id = p.post_id  and d.emp_code = e.emp_code  and d.emp_code = r.requested_by union all select e.emp_code || '*' || e.emp_name || '*' || f.failure_name || '*' || p.post_name || '*' || r.branch_id || '*' || r.am_recomm_reason || '*' || r.rm_recomm_reason || '*' || r.recommended_reason from hrm_anytimepunching_reg r,employee_master         e,daily_attend            d,  post_mst                p, branch_failure          f where r.status_id = " & STATUSTYPE & " and r.not_punch = 1 and r.branch_id =" & BrId & "  and f.failure_id = r.remarks and e.department_id not in(4, 178, 188,211) and r.reg_status = " & ATTSTATUS & " and e.post_id = p.post_id  and d.emp_code = e.emp_code  and d.emp_code = r.requested_by").Tables(0)
                    Else
                        tab = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name || '*' || f.failure_name || '*' || p.post_name || '*' || r.branch_id || '*' || r.am_recomm_reason || '*' || r.rm_recomm_reason || '*' ||r.recommended_reason from hrm_anytimepunching_reg r,employee_master         e,attend            d,  post_mst                p, branch_failure          f where r.status_id = " & STATUSTYPE & " and r.not_punch = 1 and r.branch_id =" & BrId & "  and f.failure_id = r.remarks and e.department_id  in(4, 178, 188,211) and r.reg_status = " & ATTSTATUS & " and e.post_id = p.post_id  and d.emp_code = e.emp_code  and d.emp_code = r.requested_by and to_date(r.att_req_dt) = to_date('" & ReqDt & "')and d.curr_date=to_date('" & ReqDt & "') union all select e.emp_code || '*' || e.emp_name || '*' || f.failure_name || '*' || p.post_name || '*' || r.branch_id || '*' || r.am_recomm_reason || '*' || r.rm_recomm_reason || '*' || r.recommended_reason from hrm_anytimepunching_reg r,employee_master         e,attend            d,  post_mst                p, branch_failure          f where r.status_id = " & STATUSTYPE & " and r.not_punch = 1 and r.branch_id =" & BrId & "  and f.failure_id = r.remarks and e.department_id not in(4, 178, 188,211) and r.reg_status = " & ATTSTATUS & " and e.post_id = p.post_id  and d.emp_code = e.emp_code  and d.emp_code = r.requested_by and to_date(r.att_req_dt) = to_date('" & ReqDt & "') and d.curr_date=to_date('" & ReqDt & "')").Tables(0)
                    End If
                Else
                    If reqdate = Me.hdn_sysdate.Value Then
                        tab = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name || '*' || f.failure_name || '*' || p.post_name || '*' || r.branch_id || '*' || r.am_recomm_reason || '*' || r.rm_recomm_reason || '*' || r.recommended_reason from hrm_anytimepunching_reg r,employee_master         e,daily_attend            d,  post_mst                p, branch_failure          f where r.status_id = " & STATUSTYPE & " and r.not_punch = 1 and r.branch_id =" & BrId & "  and f.failure_id = r.remarks and e.department_id not in(4, 178, 188,211) and r.reg_status = " & ATTSTATUS & " and e.post_id = p.post_id  and d.emp_code = e.emp_code  and d.emp_code = r.requested_by ").Tables(0)
                    Else
                        tab = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name || '*' || f.failure_name || '*' || p.post_name || '*' || r.branch_id || '*' || r.am_recomm_reason || '*' || r.rm_recomm_reason || '*' || r.recommended_reason from hrm_anytimepunching_reg r,employee_master         e,attend            d,  post_mst                p, branch_failure          f where r.status_id = " & STATUSTYPE & " and r.not_punch = 1 and r.branch_id =" & BrId & "  and f.failure_id = r.remarks and e.department_id not in(4, 178, 188,211) and r.reg_status = " & ATTSTATUS & " and e.post_id = p.post_id  and d.emp_code = e.emp_code  and d.emp_code = r.requested_by and to_date(r.att_req_dt) = to_date('" & ReqDt & "') and d.curr_date=to_date('" & ReqDt & "')").Tables(0)
                    End If
                End If
                Dim dr As DataRow
                For Each dr In tab.Rows
                    str_tkn.Append(dr(0))
                    str_tkn.Append("!")
                Next
                str_tkn.Append("@")
                'display punching details
                If reqdate = Me.hdn_sysdate.Value Then
                    dt = oh.ExecuteDataSet("select e.emp_code|| '*' ||e.emp_name|| '*' ||p.post_name|| '*' ||in_time|| '*' ||m_time|| '*' ||out_time|| '*' ||e_time from (select a.emp_code, a.m_time, a.e_time, t1.in_time, t2.out_time from daily_attend a, time_tab t1, time_tab t2 where a.branch_id = " & BrId & " and a.m_branch = " & BrId & "  and a.e_branch = " & BrId & "  and a.m_shift = t1.shift_id  and a.e_shift = t2.shift_id and a.m_time not in ('COMPEN', 'TOUR', 'JOIN') union all select a.emp_code,a.m_time,decode(a.e_time, null, '-', 'Pucnhing in another branch'),t3.in_time,'-' from daily_attend a, time_tab t3 where a.branch_id = " & BrId & " and a.m_branch = " & BrId & " and a.e_branch <> " & BrId & "  and a.m_shift = t3.shift_id and a.m_time not in ('COMPEN', 'TOUR', 'JOIN') union all select a.emp_code, decode(a.m_time, null, '-', 'Pucnhing in another branch'),a.e_time,'-',t4.out_time from daily_attend a, time_tab t4 where a.branch_id = " & BrId & " and a.m_branch <> " & BrId & " and a.e_branch = " & BrId & " and a.e_shift=t4.shift_id and a.m_time not in ('COMPEN', 'TOUR', 'JOIN')) v, employee_master e ,post_mst p where v.emp_code=e.emp_code and e.post_id=p.post_id").Tables(0)
                Else
                    dt = oh.ExecuteDataSet("select e.emp_code|| '*' ||e.emp_name|| '*' ||p.post_name|| '*' ||in_time|| '*' ||m_time|| '*' ||out_time|| '*' ||e_time from (select a.emp_code, a.m_time, a.e_time, t1.in_time, t2.out_time from attend a, time_tab t1, time_tab t2 where a.branch_id = " & BrId & " and a.m_branch = " & BrId & " and a.e_branch = " & BrId & " and a.m_shift = t1.shift_id and a.e_shift = t2.shift_id and a.curr_date='" & ReqDt & "' and a.m_time not in ('COMPEN', 'TOUR', 'JOIN')and a.e_time not in ('COMPEN', 'TOUR', 'JOIN') union all select a.emp_code,a.m_time,decode(a.e_time, null, '-', 'Pucnhing in another branch'),t3.in_time,'-' from attend a, time_tab t3 where a.branch_id = " & BrId & " and a.m_branch = " & BrId & " and a.e_branch <> " & BrId & " and a.m_shift = t3.shift_id and a.curr_date='" & ReqDt & "' and a.m_time not in ('COMPEN', 'TOUR', 'JOIN')and a.e_time not in ('COMPEN', 'TOUR', 'JOIN') union all select a.emp_code,decode(a.m_time, null, '-', 'Pucnhing in another branch'),a.e_time,'-',t4.out_time from attend a, time_tab t4 where a.branch_id = " & BrId & " and a.m_branch <> " & BrId & " and a.e_branch = " & BrId & " and a.e_shift = t4.shift_id  and a.curr_date='" & ReqDt & "' and a.m_time not in ('COMPEN', 'TOUR', 'JOIN')and a.e_time not in ('COMPEN', 'TOUR', 'JOIN')) v,employee_master e,post_mst p where v.emp_code = e.emp_code and e.post_id = p.post_id").Tables(0)
                End If
                Dim dr1 As DataRow
                For Each dr1 In dt.Rows
                    str_tkn.Append(dr1(0))
                    str_tkn.Append("!")
                Next
                str_tkn.Append("@")
                cbResult = str_tkn.ToString
            Case "2"
                Dim Instr() As String = str(1).Split("%")
                Dim Dataa As String = Instr(0)
                Dim ReqDT As String = Instr(1)
                Try
                    Dim p(3) As OracleParameter

                    p(0) = New OracleParameter("Dataa", OracleType.VarChar, 10000000)
                    p(0).Value = Dataa

                    p(1) = New OracleParameter("userId", OracleType.Number, 6)
                    p(1).Value = UserCode

                    p(2) = New OracleParameter("ReqDT", OracleType.DateTime)
                    p(2).Value = ReqDT

                    p(3) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
                    p(3).Direction = ParameterDirection.Output

                    oh.ExecuteNonQuery("hrm_PunchRegular_Recomm", p)
                    cbResult = p(3).Value
                Catch ex As Exception
                    cbResult = ex.Message
                End Try
        End Select
    End Sub
End Class

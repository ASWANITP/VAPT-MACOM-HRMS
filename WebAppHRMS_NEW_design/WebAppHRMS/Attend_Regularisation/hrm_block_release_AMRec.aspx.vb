Imports System.Data
Imports System.Data.OracleClient
Partial Class Block_Release_Request_hrm_punchblock_release_AMRec_805856338229
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim cbResult As String
    Dim oh As New helper.oracle.OracleHelper
    Dim dt As New DataTable
    Dim dt1, dt2, dt3, dt4, dt5, dt6, dt7 As New DataTable
    Dim UserAll(), res, sql, str As String
    Dim UserCode, BranchID, PostID, AreaID, RegionID, ZonalID, DepID, OpHead As Integer
    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn As New System.Text.StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim fid = Session("firm_id").ToString
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "Punch Block Release Recommendation /Sanction"

        Dim script_val As String
        script_val = "var header;" & "header='" & Me.ddlEcode.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function callserver (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "callserver", cbscript, True)
        Dim AccFlag As Integer
        '======STATUS========
        ' 0--Applied
        ' 1--Sanctioned
        ' 2--Rejected
        ' 3--Cancel
        ' 4--AM Recommended
        ' 5--RM Recommended
        ' 6--RH Recommended
        '10--Acc Block Applied
        '11--Acc Block Sanctioned
        '12--Acc Block Rejected
        '13--Acc Block Recommended
        ' ====================

        If Not IsPostBack Then
            UserAll = Me.Session("user_id").ToString.Split("!")
            UserCode = UserAll(0)
            dt = oh.ExecuteDataSet("select count(*) from form_accessibility where form_id=301 and emp_id=" & UserCode & "").Tables(0)
            If dt.Rows(0)(0) > 0 Then
                AccFlag = 1
            End If
            dt = oh.ExecuteDataSet("select a.post_id,a.branch_id,a.department_id from employee_master a where a.emp_code=" & UserCode & " and a.status_id=1").Tables(0)
            PostID = dt.Rows(0)(0)
            BranchID = dt.Rows(0)(1)
            DepID = dt.Rows(0)(2)
            dt1 = oh.ExecuteDataSet("select distinct v.area_id ,v.reg_id,v.zonal_id from branch_dtl_new v where branch_id=" & BranchID & "").Tables(0)
            AreaID = dt1.Rows(0)(0)
            RegionID = dt1.Rows(0)(1)

            'Check Count of Operation Head
            dt7 = oh.ExecuteDataSet("select count(*) from region_master t where t.ophead=" & UserCode & "").Tables(0)
            OpHead = dt7.Rows(0)(0)

            If PostID = 136 Or PostID = 197 Then 'AH or AM 
                dt2 = oh.ExecuteDataSet("select -1 as ecode,'-----Select-----' as ename from dual union all select distinct e.emp_code, e.emp_code||' : '||e.emp_name||'*'||b.BRANCH_NAME||':'||to_char(h.req_dt)||':'||h.status from hrm_punchblock_release_req h, branch_dtl_new b,employee_master e where h.req_by=e.emp_code and to_date(h.req_dt)>= (select to_date('21-'||to_char(sysdate-21,'mon')||'-'||to_char(sysdate-21,'yyyy'))  from dual)  and b.branch_id=e.branch_id and h.status = 0 and b.branch_id<>0 and e.status_id=1 and b.area_id=" & AreaID & " and e.post_id not in(136,197) and e.department_id not in(170,281) and b.status_id<>2 order by ecode").Tables(0)
                Me.ddlEcode.DataSource = dt2
                Me.ddlEcode.DataValueField = dt2.Columns(0).ColumnName
                Me.ddlEcode.DataTextField = dt2.Columns(1).ColumnName
                Me.ddlEcode.DataBind()
                Me.btnSanction.Visible = False

            ElseIf PostID = 199 Or PostID = 247 Then 'RM or ARM
                'dt3 = oh.ExecuteDataSet("select -1 as ecode,'-----Select-----' as ename from dual union all select distinct e.emp_code, e.emp_code||' : '||e.emp_name||'*'||b.BRANCH_NAME||':'||to_char(h.req_dt) as emp from hrm_punchblock_release_req h, branch_dtl_new b,employee_master e where h.req_by=e.emp_code and b.branch_id=e.branch_id and h.status = 4 and b.branch_id<>0 and e.status_id=1 and b.reg_id=" & RegionID & " and e.post_id <> 199 order by ecode").Tables(0)
                'dt3 = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as ename from dual union all select distinct e.emp_code as ecode,e.emp_code || ' : ' || e.emp_name || '*' || b.BRANCH_NAME || ':' ||to_char(h.req_dt) || ':' || h.status from hrm_punchblock_release_req h, branch_dtl_new b, employee_master e where h.req_by = e.emp_code and e.status_id = 1 and h.status = 4 and e.branch_id = b.BRANCH_ID and b.status_id<>2 and exists (select bd.branch_id from branch_dtl_new bd, employee_master em1 where bd.reg_id = b.reg_id and bd.BRANCH_ID = em1.branch_id and em1.emp_code =" & UserCode & " and em1.status_id = 1) order by ecode").Tables(0)
                dt3 = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as ename from dual union all select distinct e.emp_code as ecode,e.emp_code || ' : ' || e.emp_name || '*' || b.BRANCH_NAME || ':' || to_char(h.req_dt) || ':' || h.status from hrm_punchblock_release_req h, branch_dtl_new b, employee_master e where h.req_by = e.emp_code and to_date(h.req_dt)>= (select to_date('21-'||to_char(sysdate-21,'mon')||'-'||to_char(sysdate-21,'yyyy'))  from dual) and e.status_id = 1 and h.status = 4 and e.branch_id = b.BRANCH_ID and b.status_id not in (2,4) and e.department_id not in (170,281) and exists (select bd.branch_id from branch_dtl_new bd, employee_master em1 where bd.reg_id = b.reg_id and bd.BRANCH_ID = em1.branch_id and em1.emp_code = " & UserCode & " and em1.status_id = 1) union all select distinct e.emp_code as ecode,e.emp_code || ' : ' || e.emp_name || '*' || b.BRANCH_NAME || ':' ||to_char(h.req_dt) || ':' || h.status from hrm_punchblock_release_req h, branch_dtl_new b, employee_master e where h.req_by = e.emp_code and to_date(h.req_dt)>= (select to_date('21-'||to_char(sysdate-21,'mon')||'-'||to_char(sysdate-21,'yyyy'))  from dual) and e.status_id = 1 and h.status = 0 and e.branch_id = b.BRANCH_ID and b.status_id not in (2,4) and e.department_id not in(170,281) and e.post_id in(136,197) and exists (select bd.branch_id from branch_dtl_new bd, employee_master em1 where bd.reg_id = b.reg_id and bd.BRANCH_ID = em1.branch_id and em1.emp_code = " & UserCode & " and em1.status_id = 1)order by ecode").Tables(0)
                Me.ddlEcode.DataSource = dt3
                Me.ddlEcode.DataValueField = dt3.Columns(0).ColumnName
                Me.ddlEcode.DataTextField = dt3.Columns(1).ColumnName
                Me.ddlEcode.DataBind()
                Me.btnSanction.Visible = False

            ElseIf PostID = 173 Then 'RH 
                'dt6 = oh.ExecuteDataSet("select t.zonal_id from zonal_master t where t.head_id=" & UserCode & " ").Tables(0)
                dt6 = oh.ExecuteDataSet("select r.rh_op from region_master r where r.rh_op = " & UserCode & " ").Tables(0)
                ZonalID = dt6.Rows(0)(0)
                'dt4 = oh.ExecuteDataSet("select -1 as ecode,'-----Select-----' as ename from dual union all select distinct e.emp_code, e.emp_code||' : '||e.emp_name||'*'||b.BRANCH_NAME||':'||to_char(h.req_dt)||':'||h.status from hrm_punchblock_release_req h, branch_dtl_new b,employee_master e where h.req_by=e.emp_code and b.branch_id=e.branch_id and h.status = 5 and b.branch_id<>0 and e.status_id=1 and b.zonal_id=" & ZonalID & " and e.post_id <> 173 and b.status_id<>2 order by ecode").Tables(0)
                'dt4 = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as ename from dual union all select distinct e.emp_code as ecode,e.emp_code || ' : ' || e.emp_name || '*' || b.BRANCH_NAME || ':' || to_char(h.req_dt) || ':' || h.status from hrm_punchblock_release_req h, branch_dtl_new b, employee_master e where h.req_by = e.emp_code and b.branch_id = e.branch_id and h.status = 5 and b.branch_id <> 0 and e.status_id = 1 and b.zonal_id = " & ZonalID & " and e.post_id <> 173 and e.department_id not in(170,281) and b.status_id <> 2 union all select distinct e.emp_code as ecode,e.emp_code || ' : ' || e.emp_name || '*' || b.BRANCH_NAME || ':' ||to_char(h.req_dt) || ':' || h.status from hrm_punchblock_release_req h, branch_dtl_new b, employee_master e where h.req_by = e.emp_code and b.branch_id = e.branch_id and h.status = 0 and b.branch_id <> 0 and e.status_id = 1 and b.zonal_id = " & ZonalID & " and e.post_id = 199 and e.department_id not in(170,281) and b.status_id <> 2 order by ecode").Tables(0)
                'dt4 = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as ename from dual union all select distinct e.emp_code as ecode,e.emp_code || ' : ' || e.emp_name || '*' || b.BRANCH_NAME || ':' ||to_char(h.req_dt) || ':' || h.status from hrm_punchblock_release_req h, branch_dtl_new b, employee_master e where h.req_by = e.emp_code and b.branch_id = e.branch_id and h.status = 5 and b.branch_id <> 0 and e.status_id = 1 and b.zonal_id in (select zm.zonal_id from zonal_master zm where zm.head_id = " & UserCode & ") and e.post_id <> 173 and e.department_id not in (170, 281) and b.status_id <> 2 union all select distinct e.emp_code as ecode,e.emp_code || ' : ' || e.emp_name || '*' || b.BRANCH_NAME || ':' || to_char(h.req_dt) || ':' || h.status from hrm_punchblock_release_req h, branch_dtl_new b, employee_master e where h.req_by = e.emp_code and b.branch_id = e.branch_id and h.status = 0 and b.branch_id <> 0 and e.status_id = 1 and b.zonal_id in (select zm.zonal_id from zonal_master zm  where zm.head_id = " & UserCode & ")  and e.post_id = 199  and e.department_id not in (170, 281) and b.status_id <> 2 order by ecode").Tables(0)
                dt4 = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as ename from dual union all select distinct e.emp_code as ecode,e.emp_code || ' : ' || e.emp_name || '*' || b.BRANCH_NAME || ':' ||to_char(h.req_dt) || ':' || h.status from hrm_punchblock_release_req h, branch_dtl_new b, employee_master e where h.req_by = e.emp_code and to_date(h.req_dt)>= (select to_date('21-'||to_char(sysdate-21,'mon')||'-'||to_char(sysdate-21,'yyyy'))  from dual) and b.branch_id = e.branch_id and h.status = 5 and b.branch_id <> 0 and e.status_id = 1 and b.reg_id in (select r.reg_id from region_master r where r.rh_op =" & UserCode & ") and e.post_id <> 173 and e.department_id not in (170, 281)and b.status_id not in (2,4) union all select distinct e.emp_code as ecode, e.emp_code || ' : ' || e.emp_name || '*' || b.BRANCH_NAME || ':' || to_char(h.req_dt) || ':' || h.status from hrm_punchblock_release_req h, branch_dtl_new b, employee_master e where h.req_by = e.emp_code and to_date(h.req_dt)>= (select to_date('21-'||to_char(sysdate-21,'mon')||'-'||to_char(sysdate-21,'yyyy'))  from dual) and b.branch_id = e.branch_id and h.status = 0 and b.branch_id <> 0 and e.status_id = 1 and b.reg_id in (select r.rh_op from region_master r where r.rh_op = " & UserCode & ") and e.post_id = 199 and e.department_id not in (170, 281) and b.status_id not in (2,4) order by ecode").Tables(0)
                If fid = 1 Then
                    dt4 = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as ename from dual union all select distinct e.emp_code as ecode,e.emp_code || ' : ' || e.emp_name || '*' || b.BRANCH_NAME || ':' ||to_char(h.req_dt) || ':' || h.status from hrm_punchblock_release_req h, branch_dtl_new b, employee_master e where h.req_by = e.emp_code and to_date(h.req_dt)>= (select to_date('21-'||to_char(sysdate-21,'mon')||'-'||to_char(sysdate-21,'yyyy'))  from dual) and b.branch_id = e.branch_id and h.status = 5 and b.branch_id <> 0 and e.status_id = 1 and b.reg_id in (select r.reg_id from region_master r where r.rh_op =" & UserCode & ") and e.post_id <> 173 and e.department_id not in (170, 281)and b.status_id not in (2,4) union all select distinct e.emp_code as ecode, e.emp_code || ' : ' || e.emp_name || '*' || b.BRANCH_NAME || ':' || to_char(h.req_dt) || ':' || h.status from hrm_punchblock_release_req h, branch_dtl_new b, employee_master e where h.req_by = e.emp_code and to_date(h.req_dt)>= (select to_date('21-'||to_char(sysdate-21,'mon')||'-'||to_char(sysdate-21,'yyyy'))  from dual) and b.branch_id = e.branch_id and h.status = 0 and b.branch_id <> 0 and e.status_id = 1 and b.reg_id in (select r.rh_op from region_master r where r.rh_op = " & UserCode & ") and e.post_id = 199 and e.department_id not in (170, 281) and b.status_id not in (2,4) order by ecode").Tables(0)
                Else
                    dt4 = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as ename from dual union all select distinct e.emp_code as ecode,e.emp_code || ' : ' || e.emp_name || '*' || b.BRANCH_NAME || ':' ||to_char(h.req_dt) || ':' || h.status from hrm_punchblock_release_req h, branch_dtl_new b, employee_master e where h.req_by = e.emp_code and to_date(h.req_dt)>= (select to_date('21-'||to_char(sysdate-21,'mon')||'-'||to_char(sysdate-21,'yyyy'))  from dual) and b.branch_id = e.branch_id and h.status = 4 and b.branch_id <> 0 and e.status_id = 1 and b.reg_id in (select r.reg_id from region_master r where r.rh_op =" & UserCode & ") and e.post_id <> 173 and e.department_id not in (170, 281)and b.status_id not in (2,4) union all select distinct e.emp_code as ecode, e.emp_code || ' : ' || e.emp_name || '*' || b.BRANCH_NAME || ':' || to_char(h.req_dt) || ':' || h.status from hrm_punchblock_release_req h, branch_dtl_new b, employee_master e where h.req_by = e.emp_code and to_date(h.req_dt)>= (select to_date('21-'||to_char(sysdate-21,'mon')||'-'||to_char(sysdate-21,'yyyy'))  from dual) and b.branch_id = e.branch_id and h.status = 0 and b.branch_id <> 0 and e.status_id = 1 and b.reg_id in (select r.rh_op from region_master r where r.rh_op = " & UserCode & ") and e.post_id = 199 and e.department_id not in (170, 281) and b.status_id not in (2,4) order by ecode").Tables(0)
                End If
                Me.ddlEcode.DataSource = dt4
                Me.ddlEcode.DataValueField = dt4.Columns(0).ColumnName
                Me.ddlEcode.DataTextField = dt4.Columns(1).ColumnName
                Me.ddlEcode.DataBind()
                Me.btnSanction.Visible = False
            ElseIf UserCode = 21584 Then 'SM JEWELLERY --Manju
                dt4 = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as ename from dual union all select distinct e.emp_code,e.emp_code || ' : ' || e.emp_name || '*' || b.BRANCH_NAME || ':' ||         to_char(h.req_dt) || ':' || h.status from hrm_punchblock_release_req h, branch_dtl_new b, employee_master e where h.req_by = e.emp_code and to_date(h.req_dt)>= (select to_date('21-'||to_char(sysdate-21,'mon')||'-'||to_char(sysdate-21,'yyyy'))  from dual)  and b.branch_id = e.branch_id and h.status = 0 and b.branch_id <> 0 and e.status_id = 1 and e.post_id <> 71 and b.status_id in (2,4) order by ecode").Tables(0)
                Me.ddlEcode.DataSource = dt4
                Me.ddlEcode.DataValueField = dt4.Columns(0).ColumnName
                Me.ddlEcode.DataTextField = dt4.Columns(1).ColumnName
                Me.ddlEcode.DataBind()
                Me.btnSanction.Visible = False
            ElseIf OpHead > 0 Then 'Operation Heads
                dt5 = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as ename  from dual  union all  select distinct e.emp_code,  e.emp_code || ' : ' || e.emp_name || '*' || b.BRANCH_NAME || ':' ||  to_char(h.req_dt) || ':' || h.status  from hrm_punchblock_release_req h, branch_dtl_new b, employee_master e  where h.req_by = e.emp_code  and to_date(h.req_dt) >=  (select to_date('21-' || to_char(sysdate - 21, 'mon') || '-' ||  to_char(sysdate - 21, 'yyyy'))  from dual)  and b.branch_id = e.branch_id  and h.status = 6  and e.status_id = 1  and h.block_id not in (231, 232)  and e.post_id <> 85  and b.status_id not in (2, 4)  and e.department_id not in (170, 281)  and b.reg_id in  (select z.reg_id  from region_master z  where z.ophead= " & UserCode & ")  order by ecode").Tables(0)
                Me.ddlEcode.DataSource = dt5
                Me.ddlEcode.DataValueField = dt5.Columns(0).ColumnName
                Me.ddlEcode.DataTextField = dt5.Columns(1).ColumnName
                Me.ddlEcode.DataBind()
                Me.btnSanction.Visible = True
                Me.btnConfirm.Visible = False

            ElseIf UserCode = 10584 And BranchID = 0 Then 'DGM JEWELLERY 
                dt5 = oh.ExecuteDataSet("select -1 as ecode,'-----Select-----' as ename from dual union all select distinct e.emp_code, e.emp_code||' : '||e.emp_name||'*'||b.BRANCH_NAME||':'||to_char(h.req_dt)||':'||h.status from hrm_punchblock_release_req h, branch_dtl_new b,employee_master e where h.req_by=e.emp_code and to_date(h.req_dt)>= (select to_date('21-'||to_char(sysdate-21,'mon')||'-'||to_char(sysdate-21,'yyyy'))  from dual)  and b.branch_id=e.branch_id and h.status = 6 and e.status_id=1 and e.post_id <> 85 and b.status_id in (2,4) order by ecode").Tables(0)
                Me.ddlEcode.DataSource = dt5
                Me.ddlEcode.DataValueField = dt5.Columns(0).ColumnName
                Me.ddlEcode.DataTextField = dt5.Columns(1).ColumnName
                Me.ddlEcode.DataBind()
                Me.btnSanction.Visible = True
                Me.btnConfirm.Visible = False
            ElseIf PostID = 73 And DepID = 176 And BranchID = 0 Then 'AGM MARKETING 
                dt5 = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as ename from dual union all select distinct e.emp_code,e.emp_code || ' : ' || e.emp_name || '*' || b.BRANCH_NAME || ':' || to_char(h.req_dt) || ':' || h.status from hrm_punchblock_release_req h, branch_dtl_new b, employee_master e where h.req_by = e.emp_code and to_date(h.req_dt)>= (select to_date('21-'||to_char(sysdate-21,'mon')||'-'||to_char(sysdate-21,'yyyy'))  from dual) and b.branch_id = e.branch_id and h.status = 0 and b.branch_id <> 0 and e.status_id = 1 and e.post_id in(202,210) and b.status_id not in (2,4) order by ecode").Tables(0)
                Me.ddlEcode.DataSource = dt5
                Me.ddlEcode.DataValueField = dt5.Columns(0).ColumnName
                Me.ddlEcode.DataTextField = dt5.Columns(1).ColumnName
                Me.ddlEcode.DataBind()
                Me.btnSanction.Visible = True
                Me.btnConfirm.Visible = False
            ElseIf UserCode = 14586 Then 'AGM Security
                dt5 = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as ename from dual union all select distinct e.emp_code,e.emp_code || ' : ' || e.emp_name || '*' || b.BRANCH_NAME || ':' ||to_char(h.req_dt) || ':' || h.status from hrm_punchblock_release_req h, branch_dtl_new b, employee_master e where h.req_by = e.emp_code and to_date(h.req_dt)>= (select to_date('21-'||to_char(sysdate-21,'mon')||'-'||to_char(sysdate-21,'yyyy'))  from dual)  and b.branch_id = e.branch_id and h.status = 0 and b.branch_id <> 0 and e.status_id = 1 and e.department_id in(170,281) and b.status_id not in (2,4) order by ecode").Tables(0)
                Me.ddlEcode.DataSource = dt5
                Me.ddlEcode.DataValueField = dt5.Columns(0).ColumnName
                Me.ddlEcode.DataTextField = dt5.Columns(1).ColumnName
                Me.ddlEcode.DataBind()
                Me.btnSanction.Visible = True
                Me.btnConfirm.Visible = False
            ElseIf AccFlag = 1 Then  'Accounts for releasing cash/tt block
                dt5 = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as ename from dual union all select distinct e.emp_code,e.emp_code || ' : ' || e.emp_name || '*' || b.BRANCH_NAME || ':' ||to_char(h.req_dt) || ':' || h.status from hrm_punchblock_release_req h, branch_dtl_new b, employee_master e where h.req_by = e.emp_code and to_date(h.req_dt)>= (select to_date('21-'||to_char(sysdate-21,'mon')||'-'||to_char(sysdate-21,'yyyy'))  from dual) and b.branch_id = e.branch_id and h.status = 6 and e.status_id = 1  and h.block_id in(231,232,273) order by ecode").Tables(0)
                Me.ddlEcode.DataSource = dt5
                Me.ddlEcode.DataValueField = dt5.Columns(0).ColumnName
                Me.ddlEcode.DataTextField = dt5.Columns(1).ColumnName
                Me.ddlEcode.DataBind()
                Me.btnSanction.Visible = True
                Me.btnConfirm.Visible = False
            Else
                Me.Server.Transfer("../show_err.aspx")
            End If
        End If

    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return cbResult
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent

        Dim Str() As String
        Str = eventArgument.Split("$")
        Select Case (Str(0))           
            Case 1
                dt2 = oh.ExecuteDataSet("select distinct e.emp_code||'*'||e.emp_name||'*'||b.BRANCH_NAME||'*'||p.post_name||'*'||bl.block_reason||'*'||h.req_reson||'*'||to_date(h.req_dt)||'*'||h.block_id  from employee_master e,hrm_punchblock_release_req h,post_mst p,branch_dtl_new b ,block_master_1 bl where e.emp_code=h.req_by and e.post_id=p.post_id and e.branch_id=b.BRANCH_ID and bl.block_id=h.block_id and h.req_by=" & Str(2) & " and h.req_dt=to_date('" & Str(1) & "') and h.status=" & Str(3) & "").Tables(0)

                Dim dr As DataRow
                For Each dr In dt2.Rows
                    str_tkn.Append(dr(0))
                    str_tkn.Append("!")
                Next
                str_tkn.Append("@")
                cbResult = str_tkn.ToString
        End Select
    End Sub

    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click

        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)

        Dim stat
        stat = 1

        Try
            Dim p(6) As OracleParameter

            p(0) = New OracleParameter("Dataa", OracleType.VarChar, 5000)
            p(0).Value = Me.hdnDataSend.Value

            p(1) = New OracleParameter("UserID", OracleType.Number, 6)
            p(1).Value = UserCode

            p(2) = New OracleParameter("ReqBy", OracleType.Number, 6)
            p(2).Value = Me.hdnEcode.Value

            p(3) = New OracleParameter("ReqDt", OracleType.VarChar, 15)
            p(3).Value = Me.hdnReqDt.Value

            p(4) = New OracleParameter("Status", OracleType.Number, 2)
            p(4).Value = stat

            p(5) = New OracleParameter("BlockIDAll", OracleType.VarChar, 1000)
            p(5).Value = Me.hdnBlockId.Value

            p(6) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
            p(6).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("hrm_block_rel_Proc", p)
            str_tkn.Append("         alert('" & p(6).Value & "');")
            str_tkn.Append(" window.open('hrm_block_release_AMRec.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
        Catch ex As Exception
        End Try

    End Sub

    Protected Sub btnSanction_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSanction.Click

        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)

        Dim stat
        stat = 2

        Try
            Dim p(6) As OracleParameter

            p(0) = New OracleParameter("Dataa", OracleType.VarChar, 5000)
            p(0).Value = Me.hdnDataSend.Value

            p(1) = New OracleParameter("UserID", OracleType.Number, 6)
            p(1).Value = UserCode

            p(2) = New OracleParameter("ReqBy", OracleType.Number, 6)
            p(2).Value = Me.hdnEcode.Value

            p(3) = New OracleParameter("ReqDt", OracleType.VarChar, 15)
            p(3).Value = Me.hdnReqDt.Value

            p(4) = New OracleParameter("Status", OracleType.Number, 2)
            p(4).Value = stat

            p(5) = New OracleParameter("BlockIDAll", OracleType.VarChar, 1000)
            p(5).Value = Me.hdnBlockId.Value

            p(6) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
            p(6).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("hrm_block_rel_Proc", p)
            str_tkn.Append("         alert('" & p(6).Value & "');")
            str_tkn.Append(" window.open('hrm_block_release_AMRec.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
        Catch ex As Exception
        End Try

    End Sub
End Class

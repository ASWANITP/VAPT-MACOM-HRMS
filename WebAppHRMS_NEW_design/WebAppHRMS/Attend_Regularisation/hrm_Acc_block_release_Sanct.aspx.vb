Imports System.Data
Imports System.Data.OracleClient
Partial Class Block_Release_For_Accounts_hrm_Acc_block_release_Sanct_aa5fcb4c8981
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim cbResult As String
    Dim oh As New helper.oracle.OracleHelper
    Dim dt As New DataTable
    Dim dt1, dt2, dt3, dt4, dt5, dt6 As New DataTable
    Dim UserAll(), res, sql, str As String
    Dim UserCode, BranchID, PostID, AreaID, RegionID, ZonalID, DepID As Integer
    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn As New System.Text.StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        CType(Me.Master, WebAppHRMS.edp).Subtitle = "Punch Block Release Recommendation /Sanction"

        Dim script_val As String
        script_val = "var header;" & "header='" & Me.ddlEcode.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function callserver (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "callserver", cbscript, True)

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

            dt = oh.ExecuteDataSet("select a.post_id,a.branch_id,a.department_id from employee_master a where a.emp_code=" & UserCode & " and a.status_id=1").Tables(0)
            PostID = dt.Rows(0)(0)
            BranchID = dt.Rows(0)(1)
            DepID = dt.Rows(0)(2)
            dt1 = oh.ExecuteDataSet("select distinct v.area_id ,v.reg_id,v.zonal_id from branch_dtl_new v where branch_id=" & BranchID & "").Tables(0)
            AreaID = dt1.Rows(0)(0)
            RegionID = dt1.Rows(0)(1)
            ZonalID = dt1.Rows(0)(2)

            If PostID = 199 Or PostID = 247 Then 'RM 
                dt3 = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as ename from dual union all select distinct e.emp_code,e.emp_code || ' : ' || e.emp_name || '*' || b.BRANCH_NAME || ':' ||to_char(h.req_dt) from hrm_punchblock_release_req h, branch_dtl_new b, employee_master e,block_master_1 bl where h.req_by = e.emp_code and b.branch_id = e.branch_id and h.block_id=bl.block_id and h.status = 10  and e.status_id = 1 and b.reg_id = " & RegionID & " and h.block_id in(252,269,268) and e.department_id not in (170, 281) and e.post_id <> 199 and b.status_id <> 2 order by ecode").Tables(0)
                Me.ddlEcode.DataSource = dt3
                Me.ddlEcode.DataValueField = dt3.Columns(0).ColumnName
                Me.ddlEcode.DataTextField = dt3.Columns(1).ColumnName
                Me.ddlEcode.DataBind()
                Me.hdnSanct.Value = 1
            ElseIf PostID = 173 Then 'RH
                dt3 = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as ename  from dual union all select distinct e.emp_code as ecode, e.emp_code || ' : ' || e.emp_name || '*' || b.BRANCH_NAME || ':' || to_char(h.req_dt) from hrm_punchblock_release_req h, branch_dtl_new   b, emp_master   e, block_master_1    bl where h.req_by = e.emp_code and b.branch_id = e.branch_id and h.block_id = bl.block_id and h.status = 10 and h.block_id in (252, 269, 268) and b.branch_id <> 0 and e.status_id = 1 and b.reg_id in (select rm.reg_id from region_master rm where rm.rh_op = " & UserCode & ") and e.post_id <> 173  and e.department_id not in (170, 281)   and b.status_id <> 2 order by ecode").Tables(0)
                Me.ddlEcode.DataSource = dt3
                Me.ddlEcode.DataValueField = dt3.Columns(0).ColumnName
                Me.ddlEcode.DataTextField = dt3.Columns(1).ColumnName
                Me.ddlEcode.DataBind()
                Me.hdnSanct.Value = 1
            ElseIf UserCode = 21793 Or UserCode = 15213 Then  'Divya C R

                dt3 = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as ename from dual union all select distinct e.emp_code as ecode,e.emp_code || ' : ' || e.emp_name || '*' || b.BRANCH_NAME || ':' ||to_char(h.req_dt) from hrm_punchblock_release_req h, branch_dtl_new b, employee_master e where h.req_by = e.emp_code and b.branch_id = e.branch_id and h.status = 13 and b.branch_id <> 0 and h.block_id in (252,268) and e.status_id = 1 and b.status_id <> 2 and b.reg_id in (22,23,24,19,33) order by ecode").Tables(0)
                Me.ddlEcode.DataSource = dt3
                Me.ddlEcode.DataValueField = dt3.Columns(0).ColumnName
                Me.ddlEcode.DataTextField = dt3.Columns(1).ColumnName
                Me.ddlEcode.DataBind()
                Me.hdnSanct.Value = 2
            ElseIf UserCode = 48004 Then  'Govind Raju

                dt3 = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as ename from dual union all select distinct e.emp_code as ecode,e.emp_code || ' : ' || e.emp_name || '*' || b.BRANCH_NAME || ':' ||to_char(h.req_dt) from hrm_punchblock_release_req h, branch_dtl_new b, employee_master e where h.req_by = e.emp_code and b.branch_id = e.branch_id and h.status = 13 and b.branch_id <> 0 and h.block_id in (252,268) and e.status_id = 1 and b.status_id <> 2 and b.reg_id in (27,31,26,20,15,25,21,14,30) order by ecode").Tables(0)
                Me.ddlEcode.DataSource = dt3
                Me.ddlEcode.DataValueField = dt3.Columns(0).ColumnName
                Me.ddlEcode.DataTextField = dt3.Columns(1).ColumnName
                Me.ddlEcode.DataBind()
                Me.hdnSanct.Value = 2
            ElseIf UserCode = 12725 Then 'Shashidhara

                'dt3 = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as ename from dual union all select distinct e.emp_code as ecode,e.emp_code || ' : ' || e.emp_name || '*' || b.BRANCH_NAME || ':' ||to_char(h.req_dt) from hrm_punchblock_release_req h, branch_dtl_new b, employee_master e where h.req_by = e.emp_code and b.branch_id = e.branch_id and h.status = 13 and b.branch_id <> 0 and h.block_id in (268)and e.status_id = 1 and b.status_id <> 2 order by ecode").Tables(0)
                dt3 = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as ename from dual union all select distinct e.emp_code as ecode,e.emp_code || ' : ' || e.emp_name || '*' || b.BRANCH_NAME || ':' ||to_char(h.req_dt) from hrm_punchblock_release_req h, branch_dtl_new b, employee_master e where h.req_by = e.emp_code and b.branch_id = e.branch_id and h.status = 13 and b.branch_id <> 0 and h.block_id in (252,268) and e.status_id = 1  and b.status_id <> 2 and b.reg_id in (32,12,6,17,11,7) order by ecode").Tables(0)
                Me.ddlEcode.DataSource = dt3
                Me.ddlEcode.DataValueField = dt3.Columns(0).ColumnName
                Me.ddlEcode.DataTextField = dt3.Columns(1).ColumnName
                Me.ddlEcode.DataBind()
                Me.hdnSanct.Value = 2
            ElseIf UserCode = 11908 Then  'Shijin

                dt3 = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as ename from dual union all select distinct e.emp_code as ecode,e.emp_code || ' : ' || e.emp_name || '*' || b.BRANCH_NAME || ':' ||to_char(h.req_dt) from hrm_punchblock_release_req h, branch_dtl_new b, employee_master e where h.req_by = e.emp_code and b.branch_id = e.branch_id  and h.status = 13  and b.branch_id <> 0 and e.status_id = 1 and h.block_id in (252,268) and b.status_id <> 2 and b.reg_id in (4,28,29,18,16,1) order by ecode").Tables(0)
                Me.ddlEcode.DataSource = dt3
                Me.ddlEcode.DataValueField = dt3.Columns(0).ColumnName
                Me.ddlEcode.DataTextField = dt3.Columns(1).ColumnName
                Me.ddlEcode.DataBind()
                Me.hdnSanct.Value = 2

            ElseIf UserCode = 10558 Then  'Gold Loan Recovery
                dt3 = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as ename from dual union all select distinct e.emp_code as ecode,e.emp_code || ' : ' || e.emp_name || '*' || b.BRANCH_NAME || ':' ||to_char(h.req_dt) from hrm_punchblock_release_req h, branch_dtl_new b, employee_master e where h.req_by = e.emp_code and b.branch_id = e.branch_id and h.status = 13 and b.branch_id <> 0 and e.status_id = 1 and h.block_id = 269 and b.status_id <> 2 order by ecode").Tables(0)
                Me.ddlEcode.DataSource = dt3
                Me.ddlEcode.DataValueField = dt3.Columns(0).ColumnName
                Me.ddlEcode.DataTextField = dt3.Columns(1).ColumnName
                Me.ddlEcode.DataBind()
                Me.hdnSanct.Value = 3
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
        Dim san = Str(3)
        Select Case (Str(0))
            Case 1
                If san = 1 Then
                    dt2 = oh.ExecuteDataSet("select distinct e.emp_code||'*'||e.emp_name||'*'||b.BRANCH_NAME||'*'||p.post_name||'*'||bl.block_reason||'*'||h.req_reson||'*'||to_date(h.req_dt)||'*'||h.block_id  from employee_master e,hrm_punchblock_release_req h,post_mst p,branch_dtl_new b ,block_master_1 bl where e.emp_code=h.req_by and e.post_id=p.post_id and e.branch_id=b.BRANCH_ID and bl.block_id=h.block_id and h.req_by=" & Str(2) & " and h.req_dt=to_date('" & Str(1) & "') ").Tables(0)
                ElseIf san = 2 Then
                    dt2 = oh.ExecuteDataSet("select distinct e.emp_code||'*'||e.emp_name||'*'||b.BRANCH_NAME||'*'||p.post_name||'*'||bl.block_reason||'*'||h.req_reson||'*'||to_date(h.req_dt)||'*'||h.block_id  from employee_master e,hrm_punchblock_release_req h,post_mst p,branch_dtl_new b ,block_master_1 bl where e.emp_code=h.req_by and e.post_id=p.post_id and e.branch_id=b.BRANCH_ID and bl.block_id=h.block_id and h.block_id in (252,268) and h.req_by=" & Str(2) & " and h.req_dt=to_date('" & Str(1) & "') ").Tables(0)
                ElseIf san = 3 Then
                    dt2 = oh.ExecuteDataSet("select distinct e.emp_code||'*'||e.emp_name||'*'||b.BRANCH_NAME||'*'||p.post_name||'*'||bl.block_reason||'*'||h.req_reson||'*'||to_date(h.req_dt)||'*'||h.block_id  from employee_master e,hrm_punchblock_release_req h,post_mst p,branch_dtl_new b ,block_master_1 bl where e.emp_code=h.req_by and e.post_id=p.post_id and e.branch_id=b.BRANCH_ID and bl.block_id=h.block_id and h.block_id=269 and h.req_by=" & Str(2) & " and h.req_dt=to_date('" & Str(1) & "') ").Tables(0)
                End If

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



            oh.ExecuteNonQuery("hrm_Acc_block_rel_Proc", p)
            str_tkn.Append("         alert('" & p(6).Value & "');")
            str_tkn.Append(" window.open('hrm_Acc_block_release_Sanct.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btn_view_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_view.Click
        Dim emp_code As String
        emp_code = Me.ddlEcode.SelectedValue
        Dim brid As String
        dt3 = oh.ExecuteDataSet("select t.BRANCH_ID from attend_his t where t.EMP_CODE =" & emp_code & " and t.CURR_DATE=to_date('" & Me.hdnReqDt.Value & "')").Tables(0)
        brid = dt3.Rows(0)(0)
        Dim str1 As String
        str1 = brid
        Me.Server.Transfer("authorised_signatory_akgn.aspx?brid=" & str1 & "&key=" & 1 & "")
    End Sub
End Class

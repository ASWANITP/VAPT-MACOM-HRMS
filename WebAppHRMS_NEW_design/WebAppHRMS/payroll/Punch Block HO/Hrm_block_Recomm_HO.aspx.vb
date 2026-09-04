Imports System.Data
Imports System.Data.OracleClient
Partial Class HRM_Block_Rel_Req___HO_Hrm_block_Recomm_HO_706c71609896
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim cbResult As String
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim dt1, dt2, dt3, dt4, dt5, dt6, dt7, dt8 As New DataTable
    Dim UserAll(), res, sql, str As String
    Dim UserCode, BranchID, PostID, AreaID, RegionID, ZonalID, DepID, OpHead As Integer
    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn As New System.Text.StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim fid As Integer = 454
            UserAll = Me.Session("user_id").ToString.Split("!")
            UserCode = UserAll(0)
            dt4 = oh.ExecuteDataSet("select count(*) from form_accessibility f where f.emp_id=" & UserCode & " and f.form_id=454 ").Tables(0)
            If dt4.Rows.Item(0)(0) = 1 Then
                dt3 = oh.ExecuteDataSet("select -1 as bid, '------Select------' as blockrea  from dual  union all  select e.emp_code,  e.emp_code || '--' || b.block_reason || '--' || r.status || '--' ||  r.req_dt || '--' || r.block_id  from employee_master   e,  hrm_punchblock_release_req r,  block_master_1  b,  department_mst   d,  employ_firm f  where e.emp_code = r.req_by  and e.DEPARTMENT_ID = d.dep_id  and e.status_id = 1  and e.branch_id = 0  and e.emp_code=f.emp_code  and f.firm_id= " & Session("firm_id") & "  and r.block_id = b.block_id  and r.status = 0  and r.req_dt > (select to_date('21-' || to_char(sysdate - 29, 'mon') || '-' ||  to_char(sysdate - 29, 'yyyy'))  from dual)").Tables(0)
                Me.ddlEcode.DataSource = dt3
                Me.ddlEcode.DataValueField = dt3.Columns(0).ColumnName
                Me.ddlEcode.DataTextField = dt3.Columns(1).ColumnName
                Me.ddlEcode.DataBind()
            Else
                Me.Server.Transfer("../../show_err.aspx")
            End If
        End If
        'dt1 = oh.ExecuteDataSet("select count( substr(p.user_id, 1, 5)) from hrm_punching_block p, employee_master e where substr(p.user_id, 1, 5) = to_char(e.emp_code) and e.status_id=1 and e.emp_code = " & UserCode & "").Tables(0)

        Dim script_val As String
        script_val = "var header;" & "header='" & Me.ddlEcode.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function callserver (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "callserver", cbscript, True)
        'If dt1.Rows.Item(0)(0) = 0 Then
        '    If dt4.Rows.Item(0)(0) = 1 Then
        '        dt3 = oh.ExecuteDataSet("select e.department_id from employee_master e where e.emp_code=" & UserCode & "").Tables(0)
        '        Dim dep As Integer = dt3.Rows.Item(0)(0)
        '        If dep <> 8 Or 20 Or 21 Or 25 Or 24 Or 29 Or 31 Or 32 Or 34 Or 35 Then

        '            dt5 = oh.ExecuteDataSet("select -1 as bid, '------Select------' as blockrea from dual union all select e.emp_code, e.emp_code || '--' || b.block_reason || '--' || r.status || '--' || r.req_dt || '--' || r.block_id from employee_master e, hrm_punchblock_release_req r,block_master_1 b,department_mst d where e.emp_code = r.req_by and e.DEPARTMENT_ID=d.dep_id and d.major_dep_id in(8,20,21,25,24,29,31,32,34,35) and e.status_id = 1 and e.branch_id = 0 and r.block_id = b.block_id and r.status = 0 and r.req_dt >= '20/Aug/2011'").Tables(0)
        '            Me.ddlEcode.DataSource = dt5
        '            Me.ddlEcode.DataValueField = dt5.Columns(0).ColumnName
        '            Me.ddlEcode.DataTextField = dt5.Columns(1).ColumnName
        '            Me.ddlEcode.DataBind()


        '            'Else

        '        End If
        '    ElseIf UserCode = 21804 Then
        '        dt3 = oh.ExecuteDataSet("select -1 as bid, '------Select------' as blockrea  from dual  union all  select e.emp_code,  e.emp_code || '--' || b.block_reason || '--' || r.status || '--' ||  r.req_dt || '--' || r.block_id  from employee_master            e,  hrm_punchblock_release_req r,  block_master_1             b,  department_mst             d,  employ_firm f  where e.emp_code = r.req_by  and e.DEPARTMENT_ID = d.dep_id  and e.status_id = 1  and e.branch_id = 0  and e.emp_code=f.emp_code  and f.firm_id=9  and r.block_id = b.block_id  and r.status = 0  and r.req_dt > (select to_date('21-' || to_char(sysdate - 29, 'mon') || '-' ||  to_char(sysdate - 29, 'yyyy'))  from dual)").Tables(0)
        '        Me.ddlEcode.DataSource = dt3
        '        Me.ddlEcode.DataValueField = dt3.Columns(0).ColumnName
        '        Me.ddlEcode.DataTextField = dt3.Columns(1).ColumnName
        '        Me.ddlEcode.DataBind()
        '    End If

        'Else
        '    dt2 = oh.ExecuteDataSet("select e.emp_code from employee_master e where e.post_id=85 and e.department_id = 70 and e.status_id =1 ").Tables(0)
        '    If UserCode = dt2.Rows.Item(0)(0) Then
        '        dt3 = oh.ExecuteDataSet("select -1 as bid, '------Select------' as blockrea from dual union all select e.emp_code, e.emp_code || '--' || b.block_reason || '--' || r.status || '--' || r.req_dt || '--' || r.block_id from employee_master e, hrm_punchblock_release_req r,block_master_1 b,department_mst d where e.emp_code = r.req_by and e.DEPARTMENT_ID=d.dep_id and d.major_dep_id not in(8,20,21,25,24,29,31,32,34,35) and e.status_id = 1 and e.branch_id = 0 and r.block_id = b.block_id and r.status = 0 and r.req_dt >= '20/Aug/2011'").Tables(0)
        '        Me.ddlEcode.DataSource = dt3
        '        Me.ddlEcode.DataValueField = dt3.Columns(0).ColumnName
        '        Me.ddlEcode.DataTextField = dt3.Columns(1).ColumnName
        '        Me.ddlEcode.DataBind()
        '    Else
        '        'dt4 = oh.ExecuteDataSet("select -1 as bid, '------Select------' as blockrea from dual union all select r.req_by , r.req_by || '--' || b.block_reason || '--' || r.status || '--' || r.req_dt from hrm_punching_block p, hrm_punchblock_release_req r,block_master_1 b where substr(p.user_id, 0, 5) = " & UserCode & " and p.emp_code=r.req_by and b.block_id = 209 and r.block_id=b.block_id").Tables(0)
        '        dt4 = oh.ExecuteDataSet("select -1 as bid, '------Select------' as blockrea from dual union all select r.req_by, r.req_by || '--' || b.block_reason || '--' || r.status || '--' || r.req_dt||'--'||r.block_id from hrm_punching_block p, hrm_punchblock_release_req r, block_master_1 b,employee_master e where substr(p.user_id, 0, 5) = " & UserCode & " and p.emp_code = r.req_by and r.req_by = e.emp_code and b.block_id = 209 and e.branch_id = 0 and r.req_dt >= '20/Aug/2011' and p.from_dt <= r.req_dt and r.block_id = b.block_id").Tables(0)
        '        Me.ddlEcode.DataSource = dt4
        '        Me.ddlEcode.DataValueField = dt4.Columns(0).ColumnName
        '        Me.ddlEcode.DataTextField = dt4.Columns(1).ColumnName
        '        Me.ddlEcode.DataBind()
        '    End If
        '    'Me.Server.Transfer("../../show_err.aspx")
        'End If
        'Else
        'Me.Server.Transfer("../../show_err.aspx")
        'End If


    End Sub

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent

        Dim Str() As String
        Str = eventArgument.Split("$")
        Select Case (Str(0))
            Case 1
                dt3 = oh.ExecuteDataSet("select distinct e.emp_code||'*'||e.emp_name||'*'||b.BRANCH_NAME||'*'||p.post_name||'*'||bl.block_reason||'*'||h.req_reson||'*'||to_date(h.req_dt)||'*'||h.block_id  from employee_master e,hrm_punchblock_release_req h,post_mst p,branch_dtl_new b ,block_master_1 bl where e.emp_code=h.req_by and e.post_id=p.post_id and e.branch_id=b.BRANCH_ID and bl.block_id = h.block_id and h.block_id='" & Str(4) & "' and h.req_by=" & Str(2) & " and h.req_dt=to_date('" & Str(1) & "') and h.status=" & Str(3) & "").Tables(0)

                Dim dr As DataRow
                For Each dr In dt3.Rows
                    str_tkn.Append(dr(0))
                    str_tkn.Append("!")
                Next
                str_tkn.Append("@")
                cbResult = str_tkn.ToString
        End Select
    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return cbResult
    End Function

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

            'oh.ExecuteNonQuery("hrm_block_rel_Proc_dup", p)
            oh.ExecuteNonQuery("hrm_block_rel_HO", p)

            str_tkn.Append("         alert('" & p(6).Value & "');")
            str_tkn.Append(" window.open('Hrm_block_Recomm_HO.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

   
    
End Class

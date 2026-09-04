Imports System.Data
Imports System.Data.OracleClient
Partial Class Attend_Regularisation_hrm_attend_recommend_61b494ff6809
    Inherits System.Web.UI.Page
    Implements Web.UI.ICallbackEventHandler
    Dim dt, dt1, dt2, dt4, dt5, dt3, dt10 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim BranchID, AreaID, RegionID As Integer
    Dim str_tkn As New System.Text.StringBuilder
    Dim str_tkn1, str_tkn2 As New System.Text.StringBuilder
    Dim CbResult As String = Nothing
    Dim dr As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim UserId As Integer = User(0)
        Dim id As Integer = 210
        'id = Request.QueryString.Get("key")
        Dim client_name As String
        client_name = "var master_no;" & "master_no='" & "" & Me.txt_Reason.ClientID & "'" & ";"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", client_name, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "FromServer", "context", True)
        Dim cbscript As String = "function ToServer (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ToServer", cbscript, True)
        'dt4 = oh.ExecuteDataSet("select a.emp_code from employee_master a where a.emp_code=" & User(0) & " and a.status_id=1").Tables(0)
        Dim EMPCODE1 As Integer
        EMPCODE1 = UserId
        'JGM
        If Not IsPostBack Then
            dt10 = oh.ExecuteDataSet("select count(*) from employee_block_dtl e where e.emp_code=" & UserId & " and e.block_id=212 and e.block_status=1").Tables(0)
            If dt10.Rows(0)(0) > 0 Then
                oh.ExecuteNonQuery("UPDATE employee_block_dtl t set t.block_status=0 where  t.emp_code=" & UserId & " and t.block_id=212 and to_date(block_date)=to_date(sysdate)")
            End If

            If EMPCODE1 = 23045 Then

                dt = oh.ExecuteDataSet("select 0, '--Branch--Requested Date---' as branchname  from dual  union  select distinct (b.BRANCH_ID),  b.BRANCH_NAME || '~' || to_char(to_date(a.requested_dt)) as branchname  from hrm_attendance_regularisation a, branch_master b  where a.branch_id = b.BRANCH_ID  and b.firm_id = 2  and a.status_id in (5)  order by branchname").Tables(0)
                If dt.Rows.Count <= 0 Then
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("         alert('No Branch to Recommend !!!!');")
                    cl_script1.Append("window.open('../home.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script1.ToString, True)
                Else
                    Me.cmb_Branch.DataSource = dt
                    Me.cmb_Branch.DataTextField = dt.Columns(1).ColumnName
                    Me.cmb_Branch.DataValueField = dt.Columns(0).ColumnName
                    Me.cmb_Branch.DataBind()

                End If
                'dt4 = oh.ExecuteDataSet("select a.zonal_id,a.head_id from zonal_master a where a.operation_head=" & EMPCODE1 & "").Tables(0)
                'If dt4.Rows.Count >= 1 Then
                '    For Each dr In dt4.Rows
                '        str_tkn1.Append(dr(0))
                '        str_tkn1.Append(",")
                '    Next
                '    str_tkn1.Append("99")
                '    Me.hid_zonal.Value = str_tkn1.ToString
                'End If
                ''If dt4.Rows.Count >= 1 Then
                ''dt5 = oh.ExecuteDataSet("select 0,'--Branch--Requested Date---' as branchname from dual union select distinct(b.BRANCH_ID),b.BRANCH||'~'||to_char(to_date(a.requested_dt)) as branchname from hrm_attendance_regularisation a,view_branch b where a.branch_id=b.BRANCH_ID and a.status_id=5 and (to_date(a.requested_dt)=to_date(sysdate) or to_date(a.requested_dt)=to_date(sysdate-1) ) order by branchname").Tables(0)
                'dt5 = oh.ExecuteDataSet("select 0,'--Branch--Requested Date---' as branchname from dual union select distinct(b.BRANCH_ID),b.branch_name||'~'||to_char(to_date(a.requested_dt)) as branchname from hrm_attendance_regularisation a,branch_dtl_new b where a.branch_id=b.BRANCH_ID and a.status_id=5 and b.zonal_id in (" & Me.hid_zonal.Value & ") order by branchname").Tables(0)
                'If dt5.Rows.Count <= 1 Then
                'Dim cl_script0 As New System.Text.StringBuilder
                'cl_script0.Append("         alert('You Are Not Authorised!!!!');")
                'cl_script0.Append("window.open('../home.aspx','_self');")
                'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                'Else
                '    Me.cmb_Branch.DataSource = dt5
                '    Me.cmb_Branch.DataTextField = dt5.Columns(1).ColumnName
                '    Me.cmb_Branch.DataValueField = dt5.Columns(0).ColumnName
                '    Me.cmb_Branch.DataBind()
                'End If
            Else
                dt4 = oh.ExecuteDataSet("select a.emp_code,a.branch_id from employee_master a where a.emp_code=" & User(0) & " and a.post_id in (28,199,245,247,282,278) and a.status_id=1").Tables(0)
                If dt4.Rows.Count >= 1 Then
                    dt1 = oh.ExecuteDataSet("select area_id,reg_id from branch_dtl_new where branch_id=" & dt4.Rows(0)(1) & "").Tables(0)
                    'dt5 = oh.ExecuteDataSet("select 0,'--Branch--Requested Date---' as branchname from dual union select distinct(b.BRANCH_ID),b.BRANCH||'~'||to_char(to_date(a.requested_dt)) as branchname from hrm_attendance_regularisation a,view_branch b where a.branch_id=b.BRANCH_ID and a.status_id=5 and (to_date(a.requested_dt)=to_date(sysdate) or to_date(a.requested_dt)=to_date(sysdate-1) ) order by branchname").Tables(0)

                    dt = oh.ExecuteDataSet("select distinct b1.area_id from branch_dtl_new b1, branch_dtl_new b2, emp_master e2 where not exists (select br.area_id from daily_attend a, emp_master e, branch_dtl_new br where a.emp_code = e.emp_code  and e.branch_id = br.BRANCH_ID  and a.m_time is not null and a.m_time not in ('TOUR', 'COMPEN') and e.post_id in (136, 197) and br.area_id = b1.area_id) and b1.reg_id = b2.reg_id and b2.BRANCH_ID = e2.branch_id and e2.post_id in (28, 199, 245, 247, 282) and e2.status_id = 1 and b2.reg_id =" & dt1.Rows(0)(1) & "").Tables(0)
                    If dt.Rows.Count >= 1 Then
                        For Each dr In dt.Rows
                            str_tkn2.Append(dr(0))
                            str_tkn2.Append(",")
                        Next
                        str_tkn2.Append("9999")
                        Me.hid_s.Value = str_tkn2.ToString
                    Else
                        Me.hid_s.Value = 9999
                    End If
                    dt5 = oh.ExecuteDataSet("select 0,'--Branch--Requested Date---' as branchname from dual union select distinct(b.BRANCH_ID),b.BRANCH_name||'~'||to_char(to_date(a.requested_dt)) as branchname from hrm_attendance_regularisation a,branch_dtl_new b where a.branch_id=b.BRANCH_ID and b.reg_id=" & dt1.Rows(0)(1) & " and a.status_id=5 union all select distinct (b.BRANCH_ID),b.BRANCH_name || '~' || to_char(to_date(a.requested_dt)) as branchname  from hrm_attendance_regularisation a, branch_dtl_new b where a.branch_id = b.branch_id and b.reg_id = " & dt1.Rows(0)(1) & " and b.area_id in (" & Me.hid_s.Value & ") and a.status_id = 0 order by branchname").Tables(0)
                    If dt5.Rows.Count <= 1 Then
                        Dim cl_script0 As New System.Text.StringBuilder
                        cl_script0.Append("         alert('No Details for Approval!!!!');")
                        cl_script0.Append("window.open('../home.aspx','_self');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                    Else
                        Me.cmb_Branch.DataSource = dt5
                        Me.cmb_Branch.DataTextField = dt5.Columns(1).ColumnName
                        Me.cmb_Branch.DataValueField = dt5.Columns(0).ColumnName
                        Me.cmb_Branch.DataBind()
                    End If
                Else
                    dt = oh.ExecuteDataSet("select count(*) from form_accessibility where form_id=" & id & " and emp_id=" & User(0) & "").Tables(0)
                    If dt.Rows(0)(0) = 0 Then
                        'Jwellery
                        'dt = oh.ExecuteDataSet("select a.emp_code from employee_master a where a.emp_code=" & User(0) & " and a.designation_id in (25) and a.department_id in (290) and a.status_id=1").Tables(0)
                        dt = oh.ExecuteDataSet("select a.emp_code from employee_master a where a.emp_code=" & User(0) & " and a.emp_code=11090").Tables(0)
                        If dt.Rows.Count >= 1 Then
                            'dt5 = oh.ExecuteDataSet("select 0,'--Branch--Requested Date---' as branchname from dual union select distinct(b.BRANCH_ID),b.BRANCH||'~'||to_char(to_date(a.requested_dt)) as branchname from hrm_attendance_regularisation a,view_branch b where a.branch_id=b.BRANCH_ID and a.status_id=11 and (to_date(a.requested_dt)=to_date(sysdate) or to_date(a.requested_dt)=to_date(sysdate-1)) order by branchname").Tables(0)
                            dt5 = oh.ExecuteDataSet("select 0,'--Branch--Requested Date---' as branchname from dual union select distinct(b.BRANCH_ID),b.BRANCH||'~'||to_char(to_date(a.requested_dt)) as branchname from hrm_attendance_regularisation a,view_branch b where a.branch_id=b.BRANCH_ID and a.status_id in (11,10) order by branchname").Tables(0)
                            If dt5.Rows.Count <= 1 Then
                                Dim cl_script0 As New System.Text.StringBuilder
                                cl_script0.Append("         alert('No Details for Approval!!!!');")
                                cl_script0.Append("window.open('../home.aspx','_self');")
                                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                            Else
                                Me.cmb_Branch.DataSource = dt5
                                Me.cmb_Branch.DataTextField = dt5.Columns(1).ColumnName
                                Me.cmb_Branch.DataValueField = dt5.Columns(0).ColumnName
                                Me.cmb_Branch.DataBind()
                            End If
                        Else
                            Dim cl_script0 As New System.Text.StringBuilder
                            cl_script0.Append("         alert('You are not Authorised to View this Page !!!!');")
                            cl_script0.Append("window.open('../home.aspx','_self');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                        End If
                    Else
                        'dt5 = oh.ExecuteDataSet("select 0,'--Branch--Requested Date---' as branchname from dual union select distinct(b.BRANCH_ID),b.BRANCH||'~'||to_char(to_date(a.requested_dt)) as branchname from hrm_attendance_regularisation a,view_branch b where a.branch_id=b.BRANCH_ID and a.status_id=5 and (to_date(a.requested_dt)=to_date(sysdate) or to_date(a.requested_dt)=to_date(sysdate-1)) order by branchname").Tables(0)
                        dt5 = oh.ExecuteDataSet("select 0,'--Branch--Requested Date---' as branchname from dual union select distinct(b.BRANCH_ID),b.BRANCH_id||'~'||to_char(to_date(a.requested_dt)) as branchname from hrm_attendance_regularisation a,branch_dtl_new b where a.branch_id=b.BRANCH_ID and a.status_id=11 and b.status_id=3 order by branchname").Tables(0)
                        If dt5.Rows.Count <= 1 Then
                            Dim cl_script0 As New System.Text.StringBuilder
                            cl_script0.Append("         alert('No Details for Approval!!!!');")
                            cl_script0.Append("window.open('../home.aspx','_self');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                        Else
                            Me.cmb_Branch.DataSource = dt5
                            Me.cmb_Branch.DataTextField = dt5.Columns(1).ColumnName
                            Me.cmb_Branch.DataValueField = dt5.Columns(0).ColumnName
                            Me.cmb_Branch.DataBind()
                        End If
                    End If


                End If

            End If


        End If
        
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return CbResult
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim DataStr() As String
        dt1 = oh.ExecuteDataSet("select to_date(sysdate) from dual").Tables(0)
        Me.hdn_sysdate.Value = Format(dt1.Rows(0)(0), "dd/MMM/yy")
        'Me.hdn_sysdate.Value = dt1.Rows(0)(0)
        DataStr = eventArgument.Split("#")
        Select Case (DataStr(1))
            Case 1
                Dim Instr() As String = DataStr(0).Split("%")
                Dim CODE As String = Instr(0)
                Dim ReqDt As String = Instr(1)
                Dim reqdate As Date = CDate(ReqDt)
                dt3 = oh.ExecuteDataSet("select count(a.branch_id) from branch_master a where a.branch_id=" & CODE & " and a.status_id in (2,3)").Tables(0)
                If dt3.Rows(0)(0) = 0 Then
                    If reqdate = Me.hdn_sysdate.Value Then
                        dt2 = oh.ExecuteDataSet("select distinct (a.emp_code),  a.emp_name,  c.m_time,  b.requested_reason,  b.requested_by,  b.am_recom_reason,  b.RECOMMENDED_BY,  to_date(b.REQUESTED_DT)  from employee_master a, hrm_attendance_regularisation b, daily_attend c  where a.status_id = 1  and b.status_id in (5, 0)  and b.branch_id = c.m_branch  and c.pay_id not in(50,52,7)  and c.emp_code = a.emp_code  and c.m_time is not null  and to_date(b.requested_dt) = c.curr_date  and to_date(b.requested_dt) = to_date('" & ReqDt & "')  and b.branch_id = " & CODE & "  order by a.emp_code").Tables(0)
                        'dt2 = oh.ExecuteDataSet("select distinct(a.emp_code),a.emp_name,c.m_time,b.requested_reason,b.requested_by,b.am_recom_reason,b.RECOMMENDED_BY,b.HW_RECOM_REASON,b.HW_RECOMMENDED_BY,to_date(b.REQUESTED_DT) from employee_master a,hrm_attendance_regularisation b,daily_attend c where a.branch_id=" & CODE & " and a.status_id=1 and a.emp_code>10000 and a.branch_id=b.branch_id and b.status_id=5 and a.branch_id=c.m_branch and c.m_time is not null and a.emp_code=c.emp_code and to_date(b.requested_dt)=to_date(c.curr_date) and to_date(b.requested_dt)=to_date('" & ReqDt & "') order by a.emp_code").Tables(0)
                    Else
                        dt2 = oh.ExecuteDataSet("select distinct(a.emp_code),a.emp_name,c.m_time,b.requested_reason,b.requested_by,b.am_recom_reason,b.RECOMMENDED_BY,to_date(b.REQUESTED_DT) from employee_master a, hrm_attendance_regularisation b, attend c where a.status_id=1 and b.status_id in(5,0) and b.branch_id=c.m_branch and c.pay_id not in(50,52,7) and c.emp_code=a.emp_code and c.m_time is not null and to_date(b.requested_dt) =c.curr_date and to_date(b.requested_dt) =to_date('" & ReqDt & "') and b.branch_id=" & CODE & " order by a.emp_code").Tables(0)
                        'dt2 = oh.ExecuteDataSet("select distinct(a.emp_code),a.emp_name,c.m_time,b.requested_reason,b.requested_by,b.am_recom_reason,b.RECOMMENDED_BY,b.HW_RECOM_REASON,b.HW_RECOMMENDED_BY,to_date(b.REQUESTED_DT) from employee_master a,hrm_attendance_regularisation b,attend c where a.branch_id=" & CODE & " and a.status_id=1 and a.emp_code>10000 and a.branch_id=b.branch_id and b.status_id=5 and a.branch_id=c.m_branch and c.m_time is not null and a.emp_code=c.emp_code and to_date(b.requested_dt)=to_date(c.curr_date) and to_date(b.requested_dt)=to_date('" & ReqDt & "') order by a.emp_code").Tables(0)
                        'End If
                    End If
                Else
                    If reqdate = Me.hdn_sysdate.Value Then
                        dt2 = oh.ExecuteDataSet("select distinct(a.emp_code),a.emp_name,c.m_time,b.requested_reason,b.requested_by,b.am_recom_reason,b.RECOMMENDED_BY,to_date(b.REQUESTED_DT) from employee_master a, hrm_attendance_regularisation b, daily_attend c where a.status_id=1 and b.status_id in (11,10) and b.branch_id=c.m_branch and c.pay_id not in(50,52,7) and c.emp_code=a.emp_code and c.m_time is not null and to_date(b.requested_dt) = c.curr_date and to_date(b.requested_dt) =to_date('" & ReqDt & "') and b.branch_id=" & CODE & " order by a.emp_code").Tables(0)
                        'dt2 = oh.ExecuteDataSet("select distinct(a.emp_code),a.emp_name,c.m_time,b.requested_reason,b.requested_by,b.am_recom_reason,b.RECOMMENDED_BY,b.HW_RECOM_REASON,b.HW_RECOMMENDED_BY,to_date(b.REQUESTED_DT) from employee_master a,hrm_attendance_regularisation b,daily_attend c where a.branch_id=" & CODE & " and a.status_id=1 and a.emp_code>10000 and a.branch_id=b.branch_id and b.status_id=5 and a.branch_id=c.m_branch and c.m_time is not null and a.emp_code=c.emp_code and to_date(b.requested_dt)=to_date(c.curr_date) and to_date(b.requested_dt)=to_date('" & ReqDt & "') order by a.emp_code").Tables(0)
                    Else
                        dt2 = oh.ExecuteDataSet("select distinct(a.emp_code),a.emp_name,c.m_time,b.requested_reason,b.requested_by,b.am_recom_reason,b.RECOMMENDED_BY,to_date(b.REQUESTED_DT) from employee_master a, hrm_attendance_regularisation b, attend c where a.status_id=1 and b.status_id in (11,10) and b.branch_id=c.m_branch and c.pay_id not in(50,52,7) and c.emp_code=a.emp_code and c.m_time is not null and to_date(b.requested_dt) = c.curr_date and to_date(b.requested_dt) =to_date('" & ReqDt & "') and b.branch_id=" & CODE & " order by a.emp_code").Tables(0)
                        'dt2 = oh.ExecuteDataSet("select distinct(a.emp_code),a.emp_name,c.m_time,b.requested_reason,b.requested_by,b.am_recom_reason,b.RECOMMENDED_BY,b.HW_RECOM_REASON,b.HW_RECOMMENDED_BY,to_date(b.REQUESTED_DT) from employee_master a,hrm_attendance_regularisation b,attend c where a.branch_id=" & CODE & " and a.status_id=1 and a.emp_code>10000 and a.branch_id=b.branch_id and b.status_id=5 and a.branch_id=c.m_branch and c.m_time is not null and a.emp_code=c.emp_code and to_date(b.requested_dt)=to_date(c.curr_date) and to_date(b.requested_dt)=to_date('" & ReqDt & "') order by a.emp_code").Tables(0)
                    End If
                End If

                Dim dr As DataRow
                For Each dr In dt2.Rows
                    str_tkn.Append(dr(0))
                    str_tkn.Append("!")
                    str_tkn.Append(dr(1))
                    str_tkn.Append("!")
                    str_tkn.Append(dr(2))
                    str_tkn.Append("!")
                    str_tkn.Append(dr(3))
                    str_tkn.Append("!")
                    str_tkn.Append(dr(4))
                    str_tkn.Append("!")
                    str_tkn.Append(dr(5))
                    str_tkn.Append("!")
                    str_tkn.Append(dr(6))
                    str_tkn.Append("!")
                    str_tkn.Append(dr(7))
                    str_tkn.Append("~")
                Next
                str_tkn.Append("@")
                str_tkn.Append("2")
                'End If
                CbResult = str_tkn.ToString
            Case 2
                Dim Instr() As String = DataStr(0).Split("%")
                Dim Status As Integer = Instr(0)
                Dim brid As Integer = Instr(1)
                Dim requester As Integer = Instr(2)
                'Dim reason As String = Instr(3)
                Dim recomm As String = Instr(3)
                'Dim hw As String = Instr(4)
                Dim reqdate As Date = Instr(4)
                Try
                    Dim User() As String
                    User = Session("user_id").ToString.Split("!")

                    Dim p(6) As OracleParameter
                    p(0) = New OracleParameter("Status", OracleType.Number, 1)
                    p(0).Value = Status

                    p(1) = New OracleParameter("brid", OracleType.Number, 4)
                    p(1).Value = brid

                    p(2) = New OracleParameter("requester", OracleType.Number, 5)
                    p(2).Value = requester

                    p(3) = New OracleParameter("userId", OracleType.Number, 5)
                    p(3).Value = User(0)

                    'p(4) = New OracleParameter("reason", OracleType.VarChar, 100)
                    'p(4).Value = reason
                    If recomm = "" Then
                        p(4) = New OracleParameter("recomm", OracleType.Number, 5)
                        p(4).Value = 0
                    Else
                        p(4) = New OracleParameter("recomm", OracleType.Number, 5)
                        p(4).Value = recomm

                    End If
                    

                    'p(5) = New OracleParameter("hw", OracleType.Number, 5)
                    'p(5).Value = hw

                    p(5) = New OracleParameter("reqdate", OracleType.DateTime)
                    p(5).Value = reqdate

                    p(6) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
                    p(6).Direction = ParameterDirection.Output
                    oh.ExecuteNonQuery("hrm_attend_approval", p)
                    CbResult = p(6).Value
                Catch ex As Exception
                    CbResult = ex.Message
                End Try
        End Select
    End Sub
End Class

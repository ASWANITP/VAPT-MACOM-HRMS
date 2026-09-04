Imports System.Data
Imports System.Data.OracleClient
Partial Class Attend_Regularisation_hrm_attend_recommend_61b494ff1807
    Inherits System.Web.UI.Page
    Implements Web.UI.ICallbackEventHandler
    Dim dt, dt1, dt2, dt4, dt5, dt3 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim BranchID, AreaID, RegionID As Integer
    Dim str_tkn As New System.Text.StringBuilder
    Dim CbResult As String = Nothing
    Dim dr As DataRow
    Dim POST_ID, DEP_ID, DESIG_ID As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim UserId As Integer = User(0)
        Dim client_name As String
        client_name = "var master_no;" & "master_no='" & "" & Me.txt_Reason.ClientID & "'" & ";"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", client_name, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "FromServer", "context", True)
        Dim cbscript As String = "function ToServer (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ToServer", cbscript, True)
        '******************************************************************************************************
        dt = oh.ExecuteDataSet("select a.post_id,a.branch_id,a.department_id,a.designation_id from employee_master a where a.emp_code=" & User(0) & " and a.status_id=1").Tables(0)
        POST_ID = dt.Rows(0)(0)
        DEP_ID = dt.Rows(0)(2)
        DESIG_ID = dt.Rows(0)(3)
        If (POST_ID = 28 Or POST_ID = 199 Or POST_ID = 245 Or POST_ID = 247) Then
            'If dt.Rows.Count <= 0 Then
            'sreeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee
            'dt = oh.ExecuteDataSet("select a.post_id,a.branch_id from employee_master a where a.emp_code=" & User(0) & " and a.status_id=1 and a.post_id in (28,199,245,247)").Tables(0)
            'If dt.Rows.Count >= 1 Then
            '    BranchID = dt.Rows(0)(1)
            '    dt1 = oh.ExecuteDataSet("select area_id,reg_id from branch_dtl_new where branch_id=" & BranchID & "").Tables(0)
            '    dt4 = oh.ExecuteDataSet("select a.emp_code from employee_master a where a.emp_code=" & User(0) & " and a.post_id in (28,199,245,247) and a.status_id=1").Tables(0)
            '    If dt4.Rows.Count >= 1 Then
            '        If Not IsPostBack Then
            '            dt = oh.ExecuteDataSet("select distinct(z.area_id) from branch_dtl_new z,employee_master a where a.emp_code not in(select e.emp_code from employee_master e,daily_attend a where(e.emp_code = a.emp_code and e.status_id = 1 and e.post_id in (136,197) And a.m_time Is Not null ))and a.branch_id=z.BRANCH_ID").Tables(0)
            '            If dt.Rows.Count > 0 Then
            '                For Each dr In dt.Rows
            '                    str_tkn.Append(dr(0))
            '                    str_tkn.Append(",")
            '                Next
            '                str_tkn.Append("999")
            '                Me.hid_area.Value = str_tkn.ToString
            '                ' dt5 = oh.ExecuteDataSet("select 0,'--Branch--Requested Date--' as branchname from dual union select distinct(b.BRANCH_ID),b.BRANCH_NAME||'~'||to_char(to_date(a.requested_dt)) as branchname from hrm_attendance_regularisation a,branch_dtl_new b where a.branch_id=b.BRANCH_ID and b.area_id in (" & Me.hid_area.Value & ") and a.status_id=0 and b.reg_id=" & dt1.Rows(0)(1) & " and (to_date(a.requested_dt)=to_date(sysdate) or to_date(a.requested_dt)=to_date(sysdate-1)) order by branchname").Tables(0)
            '                dt5 = oh.ExecuteDataSet("select 0,'--Branch--Requested Date--' as branchname from dual union select distinct(b.BRANCH_ID),b.BRANCH_NAME||'~'||to_char(to_date(a.requested_dt)) as branchname from hrm_attendance_regularisation a,branch_dtl_new b where a.branch_id=b.BRANCH_ID and b.area_id in (" & Me.hid_area.Value & ") and a.status_id=0 and b.reg_id=" & dt1.Rows(0)(1) & " order by branchname").Tables(0)

            '                If dt5.Rows.Count <= 1 Then
            '                    Dim cl_script0 As New System.Text.StringBuilder
            '                    cl_script0.Append("         alert('No Details for Recommend!!!!');")
            '                    cl_script0.Append("window.open('../home.aspx','_self');")
            '                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
            '                Else
            '                    Me.cmb_Branch.DataSource = dt5
            '                    Me.cmb_Branch.DataTextField = dt5.Columns(1).ColumnName
            '                    Me.cmb_Branch.DataValueField = dt5.Columns(0).ColumnName
            '                    Me.cmb_Branch.DataBind()
            '                End If
            '            End If
            '        End If
            '    End If
            'Else
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('You are not Authorised to Approval !!!!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
            'End If
            'sreeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee
        ElseIf (POST_ID = 136 Or POST_ID = 197) Then
            BranchID = dt.Rows(0)(1)
            dt = oh.ExecuteDataSet("select area_id,reg_id from branch_dtl_new where branch_id=" & BranchID & "").Tables(0)
            If dt.Rows.Count > 0 Then
                If Not IsPostBack Then
                    AreaID = dt.Rows(0)(0)
                    RegionID = dt.Rows(0)(1)
                    'dt = oh.ExecuteDataSet("select 0,'--Branch--Requested Date---' as branchname from dual union select distinct(b.BRANCH_ID),b.BRANCH_NAME||'~'||to_char(to_date(a.requested_dt)) as branchname from hrm_attendance_regularisation a,branch_dtl_new b where a.branch_id=b.BRANCH_ID and b.area_id=" & dt.Rows(0)(0) & " and b.reg_id=" & dt.Rows(0)(1) & " and a.status_id=0 and (to_date(a.requested_dt)=to_date(sysdate) or to_date(a.requested_dt)=to_date(sysdate-1)) order by branchname").Tables(0)
                    dt = oh.ExecuteDataSet("select 0,'--Branch--Requested Date---' as branchname from dual union select distinct(b.BRANCH_ID),b.BRANCH_NAME||'~'||to_char(to_date(a.requested_dt)) as branchname from hrm_attendance_regularisation a,branch_dtl_new b where a.branch_id=b.BRANCH_ID and b.area_id=" & dt.Rows(0)(0) & " and b.reg_id=" & dt.Rows(0)(1) & " and a.status_id=0 order by branchname").Tables(0)
                    If dt.Rows.Count <= 1 Then
                        Dim cl_script0 As New System.Text.StringBuilder
                        cl_script0.Append("         alert('No Branch to Recommend !!!!');")
                        cl_script0.Append("window.open('../home.aspx','_self');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                    Else
                        Me.cmb_Branch.DataSource = dt
                        Me.cmb_Branch.DataTextField = dt.Columns(1).ColumnName
                        Me.cmb_Branch.DataValueField = dt.Columns(0).ColumnName
                        Me.cmb_Branch.DataBind()
                    End If
                End If
            End If
            'Jwellery
        ElseIf DEP_ID = 275 And DESIG_ID = 23 Then
            'dt = oh.ExecuteDataSet("select 0,'--Branch--Requested Date---' as branchname from dual union select distinct(b.BRANCH_ID),b.BRANCH_NAME||'~'||to_char(to_date(a.requested_dt)) as branchname from hrm_attendance_regularisation a,branch_dtl_new b where a.branch_id=b.BRANCH_ID and a.status_id=10 and (to_date(a.requested_dt)=to_date(sysdate) or to_date(a.requested_dt)=to_date(sysdate-1)) order by branchname").Tables(0)
            dt = oh.ExecuteDataSet("select 0,'--Branch--Requested Date---' as branchname from dual union select distinct(b.BRANCH_ID),b.BRANCH_NAME||'~'||to_char(to_date(a.requested_dt)) as branchname from hrm_attendance_regularisation a,branch_dtl_new b where a.branch_id=b.BRANCH_ID and a.status_id in (10) order by branchname").Tables(0)
            If dt.Rows.Count <= 0 Then
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert('No Branch to Recommend !!!!');")
                cl_script0.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
            Else
                Me.cmb_Branch.DataSource = dt
                Me.cmb_Branch.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_Branch.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_Branch.DataBind()
            End If
        ElseIf (UserId = 11855 Or UserId = 15200) Then
            'dt = oh.ExecuteDataSet("select 0,'--Branch--Requested Date---' as branchname from dual union select distinct(b.BRANCH_ID),b.BRANCH_NAME||'~'||to_char(to_date(a.requested_dt)) as branchname from hrm_attendance_regularisation a,branch_dtl_new b where a.branch_id=b.BRANCH_ID and a.status_id=10 and (to_date(a.requested_dt)=to_date(sysdate) or to_date(a.requested_dt)=to_date(sysdate-1)) order by branchname").Tables(0)
            dt = oh.ExecuteDataSet("select 0,'--Branch--Requested Date---' as branchname from dual union select distinct(b.BRANCH_ID),b.BRANCH_NAME||'~'||to_char(to_date(a.requested_dt)) as branchname from hrm_attendance_regularisation a,branch_dtl_new b where a.branch_id=b.BRANCH_ID and b.status_id=3 and a.status_id in (10) order by branchname").Tables(0)
            If dt.Rows.Count <= 0 Then
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert('No Branch to Recommend !!!!');")
                cl_script0.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
            Else
                Me.cmb_Branch.DataSource = dt
                Me.cmb_Branch.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_Branch.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_Branch.DataBind()

            End If
            'ElseIf UserId = 23045 Then

            '    dt = oh.ExecuteDataSet("select 0, '--Branch--Requested Date---' as branchname  from dual  union  select distinct (b.BRANCH_ID),  b.BRANCH_NAME || '~' || to_char(to_date(a.requested_dt)) as branchname  from hrm_attendance_regularisation a, branch_master b  where a.branch_id = b.BRANCH_ID  and b.firm_id = 2  and a.status_id in (5)  order by branchname").Tables(0)
            '    If dt.Rows.Count <= 0 Then
            '        Dim cl_script0 As New System.Text.StringBuilder
            '        cl_script0.Append("         alert('No Branch to Recommend !!!!');")
            '        cl_script0.Append("window.open('../home.aspx','_self');")
            '        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
            '    Else
            '        Me.cmb_Branch.DataSource = dt
            '        Me.cmb_Branch.DataTextField = dt.Columns(1).ColumnName
            '        Me.cmb_Branch.DataValueField = dt.Columns(0).ColumnName
            '        Me.cmb_Branch.DataBind()

            'End If
        End If
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return CbResult
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim DataStr() As String
        dt1 = oh.ExecuteDataSet("select to_date(sysdate) from dual").Tables(0)
        Me.hdn_sysdate.Value = Format(dt1.Rows(0)(0), "dd/MMM/yy")
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
                        dt2 = oh.ExecuteDataSet("select distinct (a.emp_code),a.emp_name,c.m_time,b.requested_reason,b.requested_by from employee_master a, hrm_attendance_regularisation b, daily_attend c where a.status_id=1  and b.status_id=0 and c.pay_id not in(50,52,7) and b.branch_id=c.m_branch and c.emp_code=a.emp_code and c.m_time is not null and to_date(b.requested_dt) = c.curr_date and to_date(b.requested_dt) =to_date('" & ReqDt & "') and b.branch_id=" & CODE & " order by a.emp_code").Tables(0)
                    Else
                        dt2 = oh.ExecuteDataSet("select distinct (a.emp_code),  a.emp_name,  c.m_time,  b.requested_reason,  b.requested_by  from employee_master a, hrm_attendance_regularisation b, attend c  where a.status_id = 1  and b.status_id = 0  and c.pay_id not in(50,52,7)  and b.branch_id = c.m_branch  and c.emp_code = a.emp_code  and c.m_time is not null  and to_date(b.requested_dt) = c.curr_date  and to_date(b.requested_dt) = to_date('" & ReqDt & "')  and b.branch_id = " & CODE & "  order by a.emp_code").Tables(0)
                    End If
                Else
                    If reqdate = Me.hdn_sysdate.Value Then
                        dt2 = oh.ExecuteDataSet("select distinct (a.emp_code),a.emp_name,c.m_time,b.requested_reason,b.requested_by from employee_master a, hrm_attendance_regularisation b, daily_attend c where a.status_id=1 and a.emp_code>10000 and b.status_id=10 and c.pay_id not in(50,52,7) and b.branch_id=c.m_branch and c.emp_code=a.emp_code and c.m_time is not null and to_date(b.requested_dt) = c.curr_date and to_date(b.requested_dt) =to_date('" & ReqDt & "') and b.branch_id=" & CODE & " order by a.emp_code").Tables(0)
                    Else
                        dt2 = oh.ExecuteDataSet("select distinct (a.emp_code),a.emp_name,c.m_time,b.requested_reason,b.requested_by from employee_master a, hrm_attendance_regularisation b, attend c where a.status_id=1 and a.emp_code>10000 and b.status_id=10 and c.pay_id not in(50,52,7) and b.branch_id=c.m_branch and c.emp_code=a.emp_code and c.m_time is not null and to_date(b.requested_dt) = c.curr_date and to_date(b.requested_dt) =to_date('" & ReqDt & "') and b.branch_id=" & CODE & " order by a.emp_code").Tables(0)
                    End If
                End If

                ' If dt2.Rows.Count > 0 Then
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
                    str_tkn.Append("~")
                Next
                str_tkn.Append("@")
                str_tkn.Append("2")
                ' End If
                CbResult = str_tkn.ToString
            Case 2
                Dim Instr() As String = DataStr(0).Split("%")
                Dim Status As Integer = Instr(0)
                Dim brid As Integer = Instr(1)
                Dim requester As Integer = Instr(2)
                Dim reason As String = Instr(3)
                Dim ReqDT As Date = Instr(4)
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

                    p(4) = New OracleParameter("reason", OracleType.VarChar, 100)
                    p(4).Value = reason

                    p(5) = New OracleParameter("ReqDT", OracleType.DateTime)
                    p(5).Value = ReqDT

                    p(6) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
                    p(6).Direction = ParameterDirection.Output

                    oh.ExecuteNonQuery("hrm_attend_recommend", p)
                    CbResult = p(6).Value
                Catch ex As Exception
                    CbResult = ex.Message
                End Try
        End Select
    End Sub
End Class

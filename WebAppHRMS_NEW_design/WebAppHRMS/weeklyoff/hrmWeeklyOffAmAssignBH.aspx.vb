Imports System.Data
Imports System.Data.OracleClient
Partial Class WeeklyOff_hrmWeeklyOffAmAssignBH_2ed9e8923190
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim oh As New helper.oracle.OracleHelper
    Dim cbResult As String
    Dim dt, dt1, dt2, dt3, dt4, dt5, dt6, dt7, dt8, dt9, dt10, dt11, dt12 As New DataTable
    Dim UserAll(), BranchAll(), res, sql, str, UserAddr As String
    Dim UserCode, BranchId, BrId, PostId, AreaID, RegId As Integer
    Dim ZoneId As String
    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn As New System.Text.StringBuilder
    Dim str_tkn1 As New System.Text.StringBuilder
    Dim IT As New IT.BLL.Common
    Dim dr As DataRow

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)
        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txtDate.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

        Dim FormID As Integer = 1747
        Dim dtc As New DataTable
        Dim uid As Array = Session("user_id").split("!")

        If Not IsPostBack Then
            dt = oh.ExecuteDataSet("select a.post_id, a.branch_id, a.department_id,b.reg_id  from employee_master a,branch_dtl_new b where a.emp_code = " & UserCode & "   and a.status_id = 1   and a.branch_id=b.BRANCH_ID").Tables(0)
            dtc = IT.CheckAccess(FormID, CInt(uid(0)))
            If dtc.Rows.Count > 0 Then
                'CType(Me.Master, WebAppHRMS.edp).Subtitle = "Weekly Off Assigning"
                Dim masterPage As edp = CType(Me.Master, edp)
                masterPage.subtitle = "Weekly Off Assigning"
                Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
                Dim cbscript As String = "function callserver (arg,context) {" & cbref & ";}"
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "callserver", cbscript, True)
                Me.hdnRm.Value = 4

            Else

                'dt = oh.ExecuteDataSet("select a.post_id,a.branch_id,a.department_id from employee_master a where a.emp_code=" & UserCode & " and a.status_id=1").Tables(0)
                'PostId = dt.Rows(0)(0)
                dt = oh.ExecuteDataSet("select a.post_id, a.branch_id, a.department_id,b.reg_id  from employee_master a,branch_dtl_new b where a.emp_code = " & UserCode & "   and a.status_id = 1   and a.branch_id=b.BRANCH_ID").Tables(0)
                PostId = dt.Rows(0)(0)
                RegId = dt.Rows(0)(3)
                If PostId = 136 Or PostId = 197 Then 'AH or AM 
                    Dim masterPage As edp = CType(Me.Master, edp)
                    masterPage.subtitle = "Weekly Off Assigning"
                    Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
                    Dim cbscript As String = "function callserver (arg,context) {" & cbref & ";}"
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "callserver", cbscript, True)
                    Me.hdnRm.Value = 1
                ElseIf PostId = 199 Then 'RM
                    Dim masterPage As edp = CType(Me.Master, edp)
                    masterPage.subtitle = "Weekly Off Assigning"
                    Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
                    Dim cbscript As String = "function callserver (arg,context) {" & cbref & ";}"
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "callserver", cbscript, True)
                    Me.hdnRm.Value = 2
                ElseIf PostId = 247 And RegId = 30 Or RegId = 21 Then 'ARM WARANGAL
                    Dim masterPage As edp = CType(Me.Master, edp)
                    masterPage.subtitle = "Weekly Off Assigning"
                    Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
                    Dim cbscript As String = "function callserver (arg,context) {" & cbref & ";}"
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "callserver", cbscript, True)
                    Me.hdnRm.Value = 2

                ElseIf PostId = 173 Then 'RH 
                    dt6 = oh.ExecuteDataSet("select count(*) from region_master t where t.rh_op=" & UserCode & " ").Tables(0)
                    If dt6.Rows(0)(0) > 0 Then 'RH Operations
                        Dim masterPage As edp = CType(Me.Master, edp)
                        masterPage.subtitle = "Weekly Off Assigning"
                        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
                        Dim cbscript As String = "function callserver (arg,context) {" & cbref & ";}"
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "callserver", cbscript, True)
                        Me.hdnRm.Value = 3
                    Else
                        Me.Server.Transfer("../show_err.aspx")
                    End If
                Else
                    Me.Server.Transfer("../show_err.aspx")
                End If
            End If
        End If
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim da, da1 As Integer
        Dim cal_data = eventArgument
        Dim str() As String
        str = cal_data.ToString.Split("$")
        Dim st As New StringBuilder
        Dim x = str(0)
        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)
        dt2 = oh.ExecuteDataSet("select a.department_id,a.post_id,a.branch_id from employee_master a where a.emp_code=" & UserCode & " and a.status_id=1").Tables(0)
        PostId = dt2.Rows(0)(1)
        BranchId = dt2.Rows(0)(2)
        If PostId = 173 Then
            dt3 = oh.ExecuteDataSet("select z.reg_id from region_master z where z.rh_op=" & UserCode & "").Tables(0)

            If dt3.Rows.Count >= 1 Then
                For Each dr In dt3.Rows
                    str_tkn1.Append(dr(0))
                    str_tkn1.Append(",")
                Next
                str_tkn1.Append("9999")
                Me.hid_zonal.Value = str_tkn1.ToString
                ZoneId = Me.hid_zonal.Value
            Else
                ZoneId = dt3.Rows(0)(0)
            End If



        Else
            dt3 = oh.ExecuteDataSet("select v.area_id,v.reg_id,v.zonal_id from branch_dtl_new v where branch_id=" & BranchId & "").Tables(0)
            AreaID = dt3.Rows(0)(0)
            RegId = dt3.Rows(0)(1)
        End If

        dt4 = oh.ExecuteDataSet("select to_char(to_date(sysdate),'D') as dayy from dual").Tables(0)
        da = dt4.Rows(0)(0)
        dt11 = oh.ExecuteDataSet("select to_char(to_date(sysdate)+1,'D') as dayy from dual").Tables(0)
        da1 = dt11.Rows(0)(0)
        Select Case (x)
            Case "1"
                If str(2) = 1 Then
                    If Me.hdnRm.Value = 1 Then  'AH
                        If str(1) = 1 Then 'BH
                            dt = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as emane from dual union all select distinct e.emp_code,b.BRANCH_NAME || '-->' || e.emp_name || '-->' || e.emp_code from employee_master e, branch_dtl_new b,hrm_7days_off_day s where e.branch_id = b.BRANCH_ID and  e.emp_code=s.emp_code and s.holiday=" & da & " and e.status_id = 1 and b.area_id = " & AreaID & "  and s.status in (1,3) and e.post_id in (10, 198, 252, 12, 15) order by emane").Tables(0)
                            res = FillData(res, dt)
                            res = res + "@"
                        ElseIf str(1) = 2 Then 'ABH
                            dt = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as emane from dual union all select distinct e.emp_code,b.BRANCH_NAME || '-->' || e.emp_name || '-->' || e.emp_code from employee_master e, branch_dtl_new b,hrm_7days_off_day s where e.branch_id = b.BRANCH_ID and e.emp_code=s.emp_code and s.holiday=" & da & " and e.status_id = 1 and b.area_id = " & AreaID & "  and s.status in (1,3) and e.post_id in (1, 251, 5, 3, 6) order by emane").Tables(0)
                            res = FillData(res, dt)
                            res = res + "@"
                        End If
                    ElseIf Me.hdnRm.Value = 2 Then 'RM
                        If str(1) = 1 Then 'BH
                            dt = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as emane from dual union all select distinct e.emp_code,b.BRANCH_NAME || '-->' || e.emp_name || '-->' || e.emp_code from employee_master e, branch_dtl_new b,hrm_7days_off_day s where e.branch_id = b.BRANCH_ID and e.emp_code=s.emp_code and s.holiday=" & da & " and e.status_id = 1 and b.reg_id = " & RegId & "  and s.status in (1,3) and e.post_id in (10, 198, 252, 12, 15) order by emane").Tables(0)
                            res = FillData(res, dt)
                            res = res + "@"
                        ElseIf str(1) = 2 Then 'ABH
                            dt = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as emane from dual union all select distinct e.emp_code,b.BRANCH_NAME || '-->' || e.emp_name || '-->' || e.emp_code from employee_master e, branch_dtl_new b,hrm_7days_off_day s where e.branch_id = b.BRANCH_ID and e.emp_code=s.emp_code and s.holiday=" & da & " and e.status_id = 1 and b.reg_id = " & RegId & "  and s.status in (1,3) and e.post_id in (1, 251, 5, 3, 6) order by emane").Tables(0)
                            res = FillData(res, dt)
                            res = res + "@"
                        End If
                    ElseIf Me.hdnRm.Value = 4 Then
                        If str(1) = 1 Then 'BH
                            dt = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as emane from dual union all select distinct e.emp_code,  b.BRANCH_NAME || '-->' || e.emp_name || '-->' || e.emp_code from employee_master e, branch_dtl_new b, hrm_7days_off_day s where e.branch_id = b.BRANCH_ID and e.emp_code = s.emp_code and s.holiday = " & da & " and e.status_id = 1 and e.firm_id=" & Session("firm_id") & "  order by emane").Tables(0)
                            res = FillData(res, dt)
                            res = res + "@"
                        ElseIf str(1) = 2 Then 'ABH
                            dt = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as emane from dual union all select distinct e.emp_code, b.BRANCH_NAME || '-->' || e.emp_name || '-->' || e.emp_code from employee_master e, branch_dtl_new b, hrm_7days_off_day s where e.branch_id = b.BRANCH_ID and e.emp_code = s.emp_code and s.holiday = " & da & " and e.status_id = 1 and e.firm_id=" & Session("firm_id") & "  order by emane").Tables(0)
                            res = FillData(res, dt)
                            res = res + "@"
                        End If
                    Else    'RH
                        If str(1) = 1 Then 'BH
                            dt = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as emane from dual union all select distinct e.emp_code,b.BRANCH_NAME || '-->' || e.emp_name || '-->' || e.emp_code from employee_master e, branch_dtl_new b,hrm_7days_off_day s where e.branch_id = b.BRANCH_ID and e.emp_code=s.emp_code and s.holiday=" & da & " and e.status_id = 1 and b.reg_id in (select z.reg_id from region_master z where z.rh_op=" & UserCode & " ) and s.status in (1,3)  and e.post_id in (10, 198, 252, 12, 15) order by emane").Tables(0)
                            res = FillData(res, dt)
                            res = res + "@"
                        ElseIf str(1) = 2 Then 'ABH
                            dt = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as emane from dual union all select distinct e.emp_code,b.BRANCH_NAME || '-->' || e.emp_name || '-->' || e.emp_code from employee_master e, branch_dtl_new b,hrm_7days_off_day s where e.branch_id = b.BRANCH_ID and e.emp_code=s.emp_code and s.holiday=" & da & " and e.status_id = 1 and b.reg_id in (select z.reg_id from region_master z where z.rh_op=" & UserCode & " ) and s.status in (1,3) and e.post_id in (1, 251, 5, 3, 6) order by emane").Tables(0)
                            res = FillData(res, dt)
                            res = res + "@"
                        End If
                    End If
                Else
                    If Me.hdnRm.Value = 1 Then 'AH
                        If str(1) = 1 Then 'BH
                            dt = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as emane from dual union all select distinct e.emp_code,b.BRANCH_NAME || '-->' || e.emp_name || '-->' || e.emp_code from employee_master e, branch_dtl_new b,hrm_7days_off_day s where e.branch_id = b.BRANCH_ID and  e.emp_code=s.emp_code and s.holiday=" & da1 & " and e.status_id = 1 and b.area_id = " & AreaID & " and e.post_id in (10, 198, 252, 12, 15) order by emane").Tables(0)
                            res = FillData(res, dt)
                            res = res + "@"
                        ElseIf str(1) = 2 Then 'ABH
                            dt = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as emane from dual union all select distinct e.emp_code,b.BRANCH_NAME || '-->' || e.emp_name || '-->' || e.emp_code from employee_master e, branch_dtl_new b,hrm_7days_off_day s where e.branch_id = b.BRANCH_ID and e.emp_code=s.emp_code and s.holiday=" & da1 & " and e.status_id = 1 and b.area_id = " & AreaID & " and e.post_id in (1, 251, 5, 3, 6) order by emane").Tables(0)
                            res = FillData(res, dt)
                            res = res + "@"
                        End If
                    ElseIf Me.hdnRm.Value = 2 Then 'RM
                        If str(1) = 1 Then  'BH
                            dt = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as emane from dual union all select distinct e.emp_code,b.BRANCH_NAME || '-->' || e.emp_name || '-->' || e.emp_code from employee_master e, branch_dtl_new b,hrm_7days_off_day s where e.branch_id = b.BRANCH_ID and e.emp_code=s.emp_code and s.holiday=" & da1 & " and e.status_id = 1 and b.reg_id = " & RegId & " and e.post_id in (10, 198, 252, 12, 15) order by emane").Tables(0)
                            res = FillData(res, dt)
                            res = res + "@"
                        ElseIf str(1) = 2 Then  'ABH
                            dt = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as emane from dual union all select distinct e.emp_code,b.BRANCH_NAME || '-->' || e.emp_name || '-->' || e.emp_code from employee_master e, branch_dtl_new b,hrm_7days_off_day s where e.branch_id = b.BRANCH_ID and e.emp_code=s.emp_code and s.holiday=" & da1 & " and e.status_id = 1 and b.reg_id = " & RegId & " and e.post_id in (1, 251, 5, 3, 6) order by emane").Tables(0)
                            res = FillData(res, dt)
                            res = res + "@"
                        End If
                    ElseIf Me.hdnRm.Value = 4 Then
                        If str(1) = 1 Then  'BH
                            dt = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as emane from dual union all select distinct e.emp_code,b.BRANCH_NAME || '-->' || e.emp_name || '-->' || e.emp_code from employee_master e, branch_dtl_new b,hrm_7days_off_day s where e.branch_id = b.BRANCH_ID and e.emp_code=s.emp_code and s.holiday=" & da1 & " and e.status_id = 1 and e.firm_id=" & Session("firm_id") & " order by emane").Tables(0)
                            res = FillData(res, dt)
                            res = res + "@"
                        ElseIf str(1) = 2 Then  'ABH
                            dt = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as emane from dual union all select distinct e.emp_code,b.BRANCH_NAME || '-->' || e.emp_name || '-->' || e.emp_code from employee_master e, branch_dtl_new b,hrm_7days_off_day s where e.branch_id = b.BRANCH_ID and e.emp_code=s.emp_code and s.holiday=" & da1 & " and e.status_id = 1 and e.firm_id=" & Session("firm_id") & " order by emane").Tables(0)
                            res = FillData(res, dt)
                            res = res + "@"
                        End If
                    Else    'RH
                        If str(1) = 1 Then  'BH
                            dt = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as emane from dual union all select distinct e.emp_code,b.BRANCH_NAME || '-->' || e.emp_name || '-->' || e.emp_code from employee_master e, branch_dtl_new b,hrm_7days_off_day s where e.branch_id = b.BRANCH_ID and e.emp_code=s.emp_code and s.holiday=" & da1 & " and e.status_id = 1 and b.reg_id in (select z.reg_id from region_master z where z.rh_op=" & UserCode & " )  and e.post_id in (10, 198, 252, 12, 15) order by emane").Tables(0)
                            res = FillData(res, dt)
                            res = res + "@"
                        ElseIf str(1) = 2 Then  'ABH
                            dt = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as emane from dual union all select distinct e.emp_code,b.BRANCH_NAME || '-->' || e.emp_name || '-->' || e.emp_code from employee_master e, branch_dtl_new b,hrm_7days_off_day s where e.branch_id = b.BRANCH_ID and e.emp_code=s.emp_code and s.holiday=" & da1 & " and e.status_id = 1 and b.reg_id in (select z.reg_id from region_master z where z.rh_op=" & UserCode & " ) and e.post_id in (1, 251, 5, 3, 6) order by emane").Tables(0)
                            res = FillData(res, dt)
                            res = res + "@"
                        End If
                    End If
                End If
            Case "2"
                If str(2) = 1 Then 'Today 
                    dt5 = oh.ExecuteDataSet("select e.post_id,e.branch_id,e.department_id from employee_master e where e.emp_code=" & str(1) & "").Tables(0)
                    If dt5.Rows(0)(0) = 10 Or dt5.Rows(0)(0) = 198 Or dt5.Rows(0)(0) = 252 Or dt5.Rows(0)(0) = 12 Or dt5.Rows(0)(0) = 15 Then 'BH
                        Dim br = dt5.Rows(0)(1)
                        'check ABH Count
                        dt6 = oh.ExecuteDataSet("select count(*) from employee_master e where e.post_id in(1, 251, 5, 3, 6) and e.status_id=1 and e.branch_id=" & br & "").Tables(0)
                        If dt6.Rows(0)(0) = 1 Then
                            dt7 = oh.ExecuteDataSet("select e.emp_code from employee_master e where e.post_id in(1, 251, 5, 3, 6) and e.status_id=1 and e.branch_id=" & br & "").Tables(0)
                            dt10 = oh.ExecuteDataSet("select count(h.holiday) from hrm_7days_off_day h where h.to_dt is null and h.status=1 and h.emp_code=" & dt7.Rows(0)(0)).Tables(0)
                            dt8 = oh.ExecuteDataSet("select to_char(to_date(Sysdate)+1,'D') from dual").Tables(0)

                            If dt10.Rows(0)(0) = 0 Then
                                dt9 = oh.ExecuteDataSet("select to_char((sysdate)+1) from dual").Tables(0)
                                res = dt9.Rows(0)(0)
                                res = res + "@"
                            Else
                                dt12 = oh.ExecuteDataSet("select h.holiday from hrm_7days_off_day h where h.to_dt is null and h.status=1 and h.emp_code=" & dt7.Rows(0)(0)).Tables(0)
                                If dt12.Rows(0)(0) = dt8.Rows(0)(0) Then
                                    dt9 = oh.ExecuteDataSet("select to_char((sysdate)+2) from dual").Tables(0)
                                    res = dt9.Rows(0)(0)
                                    res = res + "@"
                                Else
                                    dt9 = oh.ExecuteDataSet("select to_char((sysdate)+1) from dual").Tables(0)
                                    res = dt9.Rows(0)(0)
                                    res = res + "@"
                                End If
                            End If
                        Else
                            dt9 = oh.ExecuteDataSet("select to_char((sysdate)+1) from dual").Tables(0)
                            res = dt9.Rows(0)(0)
                            res = res + "@"
                        End If
                    ElseIf dt5.Rows(0)(0) = 1 Or dt5.Rows(0)(0) = 251 Or dt5.Rows(0)(0) = 5 Or dt5.Rows(0)(0) = 3 Or dt5.Rows(0)(0) = 6 Then 'ABH
                        Dim br = dt5.Rows(0)(1)
                        dt6 = oh.ExecuteDataSet("select count(*) from employee_master e where e.post_id in(10, 198, 252, 12, 15) and e.status_id=1 and e.branch_id=" & br & "").Tables(0)
                        If dt6.Rows(0)(0) = 1 Then
                            dt7 = oh.ExecuteDataSet("select e.emp_code from employee_master e where e.post_id in(10, 198, 252, 12, 15) and e.status_id=1 and e.branch_id=" & br & "").Tables(0)
                            dt10 = oh.ExecuteDataSet("select count(h.holiday) from hrm_7days_off_day h where h.to_dt is null and h.status=1 and h.emp_code=" & dt7.Rows(0)(0)).Tables(0)
                            dt8 = oh.ExecuteDataSet("select to_char(to_date(Sysdate)+1,'D') from dual").Tables(0)
                            'If IsDBNull(dt10.Rows(0)(0)) Then
                            If dt10.Rows(0)(0) = 0 Then
                                dt9 = oh.ExecuteDataSet("select to_char((sysdate)+1) from dual").Tables(0)
                                res = dt9.Rows(0)(0)
                                res = res + "@"
                            Else
                                dt12 = oh.ExecuteDataSet("select h.holiday from hrm_7days_off_day h where h.to_dt is null and h.status=1 and h.emp_code=" & dt7.Rows(0)(0)).Tables(0)
                                If dt12.Rows(0)(0) = dt8.Rows(0)(0) Then
                                    dt9 = oh.ExecuteDataSet("select to_char((sysdate)+2) from dual").Tables(0)
                                    res = dt9.Rows(0)(0)
                                    res = res + "@"
                                Else
                                    dt9 = oh.ExecuteDataSet("select to_char((sysdate)+1) from dual").Tables(0)
                                    res = dt9.Rows(0)(0)
                                    res = res + "@"
                                End If
                            End If
                        Else
                            dt9 = oh.ExecuteDataSet("select to_char((sysdate)+1) from dual").Tables(0)
                            res = dt9.Rows(0)(0)
                            res = res + "@"
                        End If
                    ElseIf (dt5.Rows(0)(0) = 71 Or dt5.Rows(0)(0) = 73 Or dt5.Rows(0)(0) = 500) And dt5.Rows(0)(2) = 546 Then 'ABH
                        dt6 = oh.ExecuteDataSet("select count(*) from employee_master e where e.status_id=1 and e.firm_id=" & Session("firm_id") & " ").Tables(0)
                        If dt6.Rows(0)(0) = 1 Then
                            dt7 = oh.ExecuteDataSet("select e.emp_code from employee_master e where  e.status_id=1 and e.firm_id=" & Session("firm_id") & "").Tables(0)
                            dt10 = oh.ExecuteDataSet("select count(h.holiday) from hrm_7days_off_day h where h.to_dt is null and h.status=1 and h.emp_code=" & dt7.Rows(0)(0)).Tables(0)
                            dt8 = oh.ExecuteDataSet("select to_char(to_date(Sysdate)+1,'D') from dual").Tables(0)

                            If dt10.Rows(0)(0) = 0 Then
                                dt9 = oh.ExecuteDataSet("select to_char((sysdate)+1) from dual").Tables(0)
                                res = dt9.Rows(0)(0)
                                res = res + "@"
                            Else
                                dt12 = oh.ExecuteDataSet("select h.holiday from hrm_7days_off_day h where h.to_dt is null and h.status=1 and h.emp_code=" & dt7.Rows(0)(0)).Tables(0)
                                If dt12.Rows(0)(0) = dt8.Rows(0)(0) Then
                                    dt9 = oh.ExecuteDataSet("select to_char((sysdate)+2) from dual").Tables(0)
                                    res = dt9.Rows(0)(0)
                                    res = res + "@"
                                Else
                                    dt9 = oh.ExecuteDataSet("select to_char((sysdate)+1) from dual").Tables(0)
                                    res = dt9.Rows(0)(0)
                                    res = res + "@"
                                End If
                            End If
                        Else
                            dt9 = oh.ExecuteDataSet("select to_char((sysdate)+1) from dual").Tables(0)
                            res = dt9.Rows(0)(0)
                            res = res + "@"
                        End If
                    End If
                Else 'Tomorrow
                    dt5 = oh.ExecuteDataSet("select e.post_id,e.branch_id,e.department_id from employee_master e where e.emp_code=" & str(1) & "").Tables(0)
                    If dt5.Rows(0)(0) = 10 Or dt5.Rows(0)(0) = 198 Or dt5.Rows(0)(0) = 252 Or dt5.Rows(0)(0) = 12 Or dt5.Rows(0)(0) = 15 Then 'BH
                        Dim br = dt5.Rows(0)(1)
                        dt6 = oh.ExecuteDataSet("select count(*) from employee_master e where e.post_id in(1, 251, 5, 3, 6) and e.status_id=1 and e.branch_id=" & br & "").Tables(0)
                        If dt6.Rows(0)(0) = 1 Then
                            dt7 = oh.ExecuteDataSet("select e.emp_code from employee_master e where e.post_id in(1, 251, 5, 3, 6) and e.status_id=1 and e.branch_id=" & br & "").Tables(0)
                            dt10 = oh.ExecuteDataSet("select h.holiday from hrm_7days_off_day h where h.to_dt is null and h.status=1 and h.emp_code=" & dt7.Rows(0)(0)).Tables(0)
                            dt8 = oh.ExecuteDataSet("select to_char(to_date(Sysdate)+2,'D') from dual").Tables(0)
                            If IsDBNull(dt10.Rows(0)(0)) Then
                                dt9 = oh.ExecuteDataSet("select to_char((sysdate)+2) from dual").Tables(0)
                                res = dt9.Rows(0)(0)
                                res = res + "@"
                            Else
                                If dt10.Rows(0)(0) = dt8.Rows(0)(0) Then
                                    dt9 = oh.ExecuteDataSet("select to_char((sysdate)+3) from dual").Tables(0)
                                    res = dt9.Rows(0)(0)
                                    res = res + "@"
                                Else
                                    dt9 = oh.ExecuteDataSet("select to_char((sysdate)+2) from dual").Tables(0)
                                    res = dt9.Rows(0)(0)
                                    res = res + "@"
                                End If
                            End If
                        Else
                            dt9 = oh.ExecuteDataSet("select to_char((sysdate)+2) from dual").Tables(0)
                            res = dt9.Rows(0)(0)
                            res = res + "@"
                        End If
                    ElseIf dt5.Rows(0)(0) = 1 Or dt5.Rows(0)(0) = 251 Or dt5.Rows(0)(0) = 5 Or dt5.Rows(0)(0) = 3 Or dt5.Rows(0)(0) = 6 Then 'ABH
                        Dim br = dt5.Rows(0)(1)
                        dt6 = oh.ExecuteDataSet("select count(*) from employee_master e where e.post_id in(10, 198, 252, 12, 15) and e.status_id=1 and e.branch_id=" & br & "").Tables(0)
                        If dt6.Rows(0)(0) = 1 Then
                            dt7 = oh.ExecuteDataSet("select e.emp_code from employee_master e where e.post_id in(10, 198, 252, 12, 15) and e.status_id=1 and e.branch_id=" & br & "").Tables(0)
                            dt10 = oh.ExecuteDataSet("select h.holiday from hrm_7days_off_day h where h.to_dt is null and h.status=1 and h.emp_code=" & dt7.Rows(0)(0)).Tables(0)
                            dt8 = oh.ExecuteDataSet("select to_char(to_date(Sysdate)+2,'D') from dual").Tables(0)
                            If IsDBNull(dt10.Rows(0)(0)) Then
                                dt9 = oh.ExecuteDataSet("select to_char((sysdate)+2) from dual").Tables(0)
                                res = dt9.Rows(0)(0)
                                res = res + "@"
                            Else
                                If dt10.Rows(0)(0) = dt8.Rows(0)(0) Then
                                    dt9 = oh.ExecuteDataSet("select to_char((sysdate)+3) from dual").Tables(0)
                                    res = dt9.Rows(0)(0)
                                    res = res + "@"
                                Else
                                    dt9 = oh.ExecuteDataSet("select to_char((sysdate)+2) from dual").Tables(0)
                                    res = dt9.Rows(0)(0)
                                    res = res + "@"
                                End If
                            End If
                        Else
                            dt9 = oh.ExecuteDataSet("select to_char((sysdate)+2) from dual").Tables(0)
                            res = dt9.Rows(0)(0)
                            res = res + "@"
                        End If
                    ElseIf (dt5.Rows(0)(0) = 71 Or dt5.Rows(0)(0) = 73 Or dt5.Rows(0)(0) = 500) And dt5.Rows(0)(2) = 546 Then 'ABH
                        dt6 = oh.ExecuteDataSet("select count(*) from employee_master e where e.status_id=1 and e.firm_id=" & Session("firm_id") & " ").Tables(0)
                        If dt6.Rows(0)(0) = 1 Then
                            dt7 = oh.ExecuteDataSet("select e.emp_code from employee_master e where  e.status_id=1 and e.firm_id=" & Session("firm_id") & "").Tables(0)
                            dt10 = oh.ExecuteDataSet("select count(h.holiday) from hrm_7days_off_day h where h.to_dt is null and h.status=1 and h.emp_code=" & dt7.Rows(0)(0)).Tables(0)
                            dt8 = oh.ExecuteDataSet("select to_char(to_date(Sysdate)+1,'D') from dual").Tables(0)

                            If dt10.Rows(0)(0) = 0 Then
                                dt9 = oh.ExecuteDataSet("select to_char((sysdate)+1) from dual").Tables(0)
                                res = dt9.Rows(0)(0)
                                res = res + "@"
                            Else
                                dt12 = oh.ExecuteDataSet("select h.holiday from hrm_7days_off_day h where h.to_dt is null and h.status=1 and h.emp_code=" & dt7.Rows(0)(0)).Tables(0)
                                If dt12.Rows(0)(0) = dt8.Rows(0)(0) Then
                                    dt9 = oh.ExecuteDataSet("select to_char((sysdate)+2) from dual").Tables(0)
                                    res = dt9.Rows(0)(0)
                                    res = res + "@"
                                Else
                                    dt9 = oh.ExecuteDataSet("select to_char((sysdate)+1) from dual").Tables(0)
                                    res = dt9.Rows(0)(0)
                                    res = res + "@"
                                End If
                            End If
                        Else
                            dt9 = oh.ExecuteDataSet("select to_char((sysdate)+1) from dual").Tables(0)
                            res = dt9.Rows(0)(0)
                            res = res + "@"
                        End If
                    End If
                End If

                dt4 = oh.ExecuteDataSet("select e.emp_name||'*'||b.BRANCH_NAME||'*'||p.post_name||'*'||d.dep_name from employee_master e,branch_dtl_new b,post_mst p,department_mst d where e.branch_id=b.BRANCH_ID and e.post_id=p.post_id and e.department_id=d.dep_id and e.status_id=1 and e.emp_code=" & str(1) & "").Tables(0)
                If dt4.Rows.Count = 0 Then
                    str_tkn.Append("NULL")
                    res = res + str_tkn.ToString
                Else
                    str_tkn.Append(dt4.Rows(0)(0))
                    res = res + str_tkn.ToString
                End If
        End Select
    End Sub
    Public Function FillData(ByVal cbResult As String, ByVal DT As DataTable) As String
        For n As Integer = 0 To DT.Rows.Count - 1
            cbResult += DT.Rows(n)(0).ToString
            cbResult += "$"
            cbResult += DT.Rows(n)(1).ToString
            If n < DT.Rows.Count - 1 Then
                cbResult += "*"
            End If
        Next
        Return cbResult
    End Function

    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click

        ' UserAddr = Me.Session("user_id")

        Try
            Dim p(5) As OracleParameter

            p(0) = New OracleParameter("Empcode", OracleType.Number, 6)
            p(0).Value = Me.hdnEcode.Value

            p(1) = New OracleParameter("UserId", OracleType.Number, 6)
            p(1).Value = UserCode

            p(2) = New OracleParameter("ChDate", OracleType.VarChar, 15)
            p(2).Value = Me.hdnDate.Value

            p(3) = New OracleParameter("Reason", OracleType.VarChar, 500)
            p(3).Value = Me.txtReason.Text

            p(4) = New OracleParameter("DayStat", OracleType.Number, 1)
            p(4).Value = Me.hdnDay.Value

            p(5) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
            p(5).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("hrm_weekoffchangeAM_proc_1", p)

            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('" & p(5).Value & "');")
            cl_script1.Append("window.open('hrmWeeklyOffAmAssignBH.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

        Catch ex As Exception
        End Try
    End Sub
End Class

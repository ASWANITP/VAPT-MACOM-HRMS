Imports System.Data
Imports System.Data.OracleClient
Partial Class _7DaysWorking_hrm_Emp_Off_Updt_a762d4196657
    Inherits System.Web.UI.Page
    Implements Web.UI.ICallbackEventHandler
    Dim dt, dt1, dt2, dt3, dt4, dt5, dt6, dt9, dt10, dt11 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim BranchID, AreaID, RegionID As Integer
    Dim str_tkn, str_tkn1, str_tkn2, str_tkn3, str_tkn12 As New System.Text.StringBuilder
    Dim str_sre As New System.Text.StringBuilder
    Dim CbResult As String = Nothing
    Dim dr As DataRow
    Dim POST As Integer
    Dim DEP As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim UserId As Integer = User(0)
        Me.hid_branch.Value = Session("branch_id")
        'CType(Me.Master, WebAppHRMS.edp).Subtitle = "COMPENSATORY OFF DAY UPDATION"
        Dim masterPage As WebAppHRMS.edp = CType(Me.Master, WebAppHRMS.edp)
        masterPage.subtitle = "COMPENSATORY OFF DAY UPDATION"
        Dim client_name As String
        client_name = "var master_no;" & "master_no='" & "" & Me.cmb_Employee.ClientID & "'" & ";"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", client_name, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "FromServer", "context", True)
        Dim cbscript As String = "function ToServer (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ToServer", cbscript, True)
        If Not IsPostBack Then
            dt1 = oh.ExecuteDataSet("select to_date(sysdate) from dual").Tables(0)
            Me.hdn_sysdate.Value = Format(dt1.Rows(0)(0), "dd/MMM/yyyy")
            Me.txt_Date.Text = Me.hdn_sysdate.Value
        End If
        Me.txt_Date.Attributes.Add("onkeyup", "OnkeyUpChqDate('txt_Date')")
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return CbResult
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim DataStr() As String
        DataStr = eventArgument.Split("#")
        Select Case (DataStr(1))
            Case 1
                Dim Instr() As String = DataStr(0).Split("%")
                Dim CODE As String = Instr(0)
                Dim BR As String = Instr(1)
                dt2 = oh.ExecuteDataSet("select a.emp_code,a.emp_name from employee_master a where a.status_id=1 and a.branch_id=" & BR & " and a.post_id in (1,10,251,252,6,15,2,11) and a.emp_code=" & CODE & "").Tables(0)
                If dt2.Rows.Count > 0 Then
                    Dim Status = 1
                    CbResult = Status
                Else
                    Dim Status = 0
                    CbResult = Status
                End If
            Case 2
                Dim Instr() As String = DataStr(0).Split("%")
                Dim BR As String = Instr(0)
                dt = oh.ExecuteDataSet("select a.emp_code,a.emp_code||'-'||e.emp_name,decode(a.holiday,1,'SUNDAY',2,'MONDAY',3,'TUESDAY',4,'WEDNESDAY',5,'THURSDAY',6,'FRIDAY',7,'SATURDAY') from hrm_7days_off_day a,employee_master e where a.emp_code=e.emp_code and a.status=1 and to_date(a.to_dt) is null and a.branch_id=" & BR & " and to_date(a.enter_dt)=to_date(sysdate)").Tables(0)
                If dt.Rows.Count > 0 Then
                    For Each dr In dt.Rows
                        str_tkn2.Append(dr(0))
                        str_tkn2.Append("*")
                        str_tkn2.Append(dr(1))
                        str_tkn2.Append("*")
                        str_tkn2.Append(dr(2))
                        str_tkn2.Append("!")
                    Next
                    str_tkn2.Append("@")
                    str_tkn2.Append("2")
                    CbResult = str_tkn2.ToString
                End If
            Case 3
                Dim Instr() As String = DataStr(0).Split("%")
                Dim DELData As String = Instr(0)
                Dim BR As Integer = Instr(1)
                Dim Status As Integer = 2
                dt1 = oh.ExecuteDataSet("select to_date(sysdate) from dual").Tables(0)
                Try
                    Dim User() As String
                    User = Session("user_id").ToString.Split("!")
                    Dim p(5) As OracleParameter
                    p(0) = New OracleParameter("brid", OracleType.Number, 4)
                    p(0).Value = BR
                    p(1) = New OracleParameter("userID", OracleType.Number, 5)
                    p(1).Value = User(0)
                    p(2) = New OracleParameter("Str", OracleType.VarChar, 100000)
                    p(2).Value = DELData
                    p(3) = New OracleParameter("Fromdt", OracleType.DateTime)
                    p(3).Value = dt1.Rows(0)(0)
                    p(4) = New OracleParameter("Status", OracleType.Number)
                    p(4).Value = Status
                    p(5) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
                    p(5).Direction = ParameterDirection.Output
                    oh.ExecuteNonQuery("hrm_SevenDays_Comp", p)
                    CbResult = p(5).Value
                Catch ex As Exception
                    CbResult = ex.Message
                End Try
            Case 4
                Dim User() As String = Session("user_id").ToString.Split("!")
                Dim UserId As Integer = User(0)
                dt = oh.ExecuteDataSet("select a.post_id,a.branch_id,a.department_id from employee_master a where a.emp_code=" & User(0) & " and a.status_id=1").Tables(0)
                POST = dt.Rows(0)(0)
                DEP = dt.Rows(0)(2)
                If (DataStr(0) = "-33") Then
                    dt1 = oh.ExecuteDataSet("select count(a.ia_tour_head) from region_master a where a.ia_tour_head=" & User(0) & " ").Tables(0)
                    If dt1.Rows(0)(0) >= 1 Then
                        dt1 = oh.ExecuteDataSet("select reg_id from region_master a where a.ia_tour_head=" & User(0) & " ").Tables(0)
                        If dt1.Rows.Count >= 1 Then
                            For Each dr In dt1.Rows
                                str_tkn3.Append(dr(0))
                                str_tkn3.Append(",")
                            Next
                            str_tkn3.Append("99")
                            Me.hid_s2.Value = str_tkn3.ToString
                        End If
                        dt5 = oh.ExecuteDataSet("select 0,'--Code--Employee--Branch--' as empcode from dual union select a.emp_code,a.emp_code||'-'||a.emp_name||'-'||b.branch_name as empcode from employee_master a, department_mst d,branch_dtl_new b where a.branch_id=b.branch_id and b.reg_id in (" & Me.hid_s2.Value & ") and a.department_id = d.dep_id and a.status_id = 1 and a.department_id in (4, 170, 178, 188,211, 280,281) and a.post_id not in (28,199,245,247,210,202,275,278,279,244,237) and not exists (select d.emp_code from hrm_7days_off_day d where a.emp_code=d.emp_code and d.status in (1,2) and d.to_dt is null) order by  empcode").Tables(0)
                        CbResult = FillData(CbResult, dt5)
                        CbResult = CbResult + "@"
                    ElseIf POST = 28 Or POST = 199 Or POST = 245 Or POST = 247 Then
                        BranchID = dt.Rows(0)(1)
                        dt1 = oh.ExecuteDataSet("select area_id,reg_id from branch_dtl_new where branch_id=" & BranchID & "").Tables(0)
                        dt5 = oh.ExecuteDataSet("select 0,'--Code--Employee--Branch--' as empcode from dual union select a.emp_code,a.emp_code||'-'||a.emp_name||'-'||b.branch_name as empcode from employee_master a, department_mst d,branch_dtl_new b where a.branch_id=b.branch_id and b.reg_id=" & dt1.Rows(0)(1) & " and a.department_id = d.dep_id and a.status_id = 1 and a.post_id in (136, 197) and a.department_id in (280, 281, 210, 211, 5,14,44,108,32,123) and not exists (select d.emp_code from hrm_7days_off_day d where a.emp_code=d.emp_code and d.status in (1,2) and d.to_dt is null) order by  empcode").Tables(0)
                        CbResult = FillData(CbResult, dt5)
                        CbResult = CbResult + "@"
                    ElseIf POST = 136 Or POST = 197 Then
                        BranchID = dt.Rows(0)(1)
                        dt3 = oh.ExecuteDataSet("select area_id,region_id from view_branch where branch_id=" & BranchID & "").Tables(0)
                        AreaID = dt3.Rows(0)(0)
                        RegionID = dt3.Rows(0)(1)
                        dt5 = oh.ExecuteDataSet("select 0,'--Code--Employee--Branch--' as empcode from dual union select a.emp_code,a.emp_code||'-'||a.emp_name||'-'||b.branch_name as empcode from employee_master a, department_mst d,branch_dtl_new b where a.branch_id=b.branch_id and b.area_id=" & AreaID & " and a.department_id = d.dep_id and a.status_id = 1 and a.post_id in (10,198,252,15,12,1) and not exists (select d.emp_code from hrm_7days_off_day d where a.emp_code=d.emp_code and d.status in (1,2) and d.to_dt is null) order by  empcode").Tables(0)
                        CbResult = FillData(CbResult, dt5)
                        CbResult = CbResult + "@"
                    ElseIf POST = 173 Or POST = 195 Then
                        dt3 = oh.ExecuteDataSet("select reg_id from region_master z where (z.rh_op=" & User(0) & " or z.rh_hr=" & User(0) & ")").Tables(0)
                        If dt3.Rows.Count > 1 Then
                            For Each dr In dt3.Rows
                                str_tkn12.Append(dr(0))
                                str_tkn12.Append(",")
                            Next
                            str_tkn12.Append("99")
                            Me.HiddenField1.Value = str_tkn12.ToString
                            dt5 = oh.ExecuteDataSet("select 0,'--Code--Employee--Branch--' as empcode from dual union select a.emp_code,a.emp_code||'-'||a.emp_name||'-'||b.branch_name as empcode from employee_master a, department_mst d,branch_dtl_new b where a.branch_id=b.branch_id and b.reg_id in (" & Me.HiddenField1.Value & ") and a.department_id = d.dep_id and a.status_id = 1 and (a.department_id in (14, 210, 6, 50, 198,186, 215,7, 28, 281, 270, 134, 170,280,211,5,14,44,108,32,123,176,151,32,300,136) or a.post_id in (10,198,252,15,12,1,6,3,251,67)) and not exists (select d.emp_code from hrm_7days_off_day d where a.emp_code=d.emp_code and d.status in (1,2) and d.to_dt is null)order by  empcode").Tables(0)
                        Else
                            Dim ZONEID As Integer = dt3.Rows(0)(0)
                            dt5 = oh.ExecuteDataSet("select 0,'--Code--Employee--Branch--' as empcode from dual union select a.emp_code,a.emp_code||'-'||a.emp_name||'-'||b.branch_name as empcode from employee_master a, department_mst d,branch_dtl_new b where a.branch_id=b.branch_id and b.reg_id=" & ZONEID & " and a.department_id = d.dep_id and a.status_id = 1 and (a.department_id in (14, 210, 6, 50, 198, 215, 28, 281, 270, 134,186,7, 170,280,211,5,14,44,108,32,123,176,151,32,300) or a.post_id in (10,198,252,15,12,1,6,3,251)) and not exists (select d.emp_code from hrm_7days_off_day d where a.emp_code=d.emp_code and d.status in (1,2) and d.to_dt is null)order by  empcode").Tables(0)
                        End If
                        ' Dim ZONEID As Integer = dt3.Rows(0)(0)
                        'dt5 = oh.ExecuteDataSet("select 0,'--Code--Employee--Branch--' as empcode from dual union select a.emp_code,a.emp_code||'-'||a.emp_name||'-'||b.branch_name as empcode from employee_master a, department_mst d,branch_dtl_new b where a.branch_id=b.branch_id and b.zonal_id=" & ZONEID & " and a.department_id = d.dep_id and a.status_id = 1 and ((a.post_id in (210, 202, 199, 136, 204, 283, 237,236,28,245,247,197,210,202,204,274,279) and a.department_id in (14, 210, 6, 50, 198, 215, 28, 281, 270, 134, 170,280,211,5,14,44,108,32,123,176,151,32)) or a.post_id in (10,198,252,15,12,1,6,3,251)) and not exists (select d.emp_code from hrm_7days_off_day d where a.emp_code=d.emp_code and d.status in (1,2) and d.to_dt is null)order by  empcode").Tables(0)
                        CbResult = FillData(CbResult, dt5)
                        CbResult = CbResult + "@"
                    ElseIf UserId = 21680 Then
                        dt5 = oh.ExecuteDataSet("select 0,'--Code--Employee--Branch--' as empcode from dual union select a.emp_code,a.emp_code||'-'||a.emp_name||'-'||b.branch_name as empcode from employee_master a, department_mst d,branch_dtl_new b where a.branch_id=b.branch_id and a.department_id = d.dep_id and a.status_id = 1 and a.department_id in (20) and not exists (select d.emp_code from hrm_7days_off_day d where a.emp_code=d.emp_code and d.status in (1,2) and d.to_dt is null) order by  empcode").Tables(0)
                        CbResult = FillData(CbResult, dt5)
                        CbResult = CbResult + "@"
                    ElseIf ((DEP = 4 Or DEP = 178 Or DEP = 188 Or DEP = 170 Or DEP = 211 Or DEP = 280 Or DEP = 281) And POST = 85) Then
                        dt5 = oh.ExecuteDataSet("select 0, '--Code--Employee--Branch--' as empcode from dual union select a.emp_code,a.emp_code || '-' || a.emp_name || '-' || b.branch_name as empcode from employee_master a, region_master r,branch_dtl_new b where a.status_id = 1  and a.emp_code=r.ia_tour_head and a.branch_id=b.BRANCH_ID  and not exists (select d.emp_code from hrm_7days_off_day d where a.emp_code = d.emp_code  and d.status in (1, 2) and d.to_dt is null) order by empcode").Tables(0)
                        CbResult = FillData(CbResult, dt5)
                        CbResult = CbResult + "@"
                    ElseIf ((DEP = 176 Or DEP = 151 Or DEP = 32) And POST = 73) Then
                        dt5 = oh.ExecuteDataSet("select 0,'--Code--Employee--Branch--' as empcode from dual union select a.emp_code,a.emp_code||'-'||a.emp_name||'-'||b.branch_name as empcode from employee_master a, department_mst d,branch_dtl_new b where a.branch_id=b.branch_id  and a.department_id = d.dep_id and a.status_id = 1 and (a.post_id in (210,202,204) and a.department_id in (176,151,32)) and not exists (select d.emp_code from hrm_7days_off_day d where a.emp_code=d.emp_code and d.status in (1,2) and d.to_dt is null)order by  empcode").Tables(0)
                        CbResult = FillData(CbResult, dt5)
                        CbResult = CbResult + "@"
                    ElseIf UserId = 10749 Then
                        dt5 = oh.ExecuteDataSet("select 0, '--Code--Employee--Branch--' as empcode from dual union select a.emp_code,a.emp_code || '-' || a.emp_name || '-' || b.branch_name as empcode from employee_master a, department_mst dd, branch_dtl_new b where a.branch_id = b.branch_id and a.department_id = dd.dep_id and a.status_id = 1 and a.branch_id<>0 and (dd.major_dep_id in (14)) and not exists (select d.emp_code from hrm_7days_off_day d where a.emp_code = d.emp_code and d.status in (1, 2) and d.to_dt is null) order by empcode").Tables(0)
                        CbResult = FillData(CbResult, dt5)
                        CbResult = CbResult + "@"
                    ElseIf ((DEP = 281 Or DEP = 170) And (POST = 283 Or POST = 237 Or POST = 279)) Then 'RM SECURITY
                        dt5 = oh.ExecuteDataSet("select 0,'--Code--Employee--Branch--' as empcode from dual union select a.emp_code,a.emp_code||'-'||a.emp_name||'-'||b.branch_name as empcode from employee_master a, department_mst d,branch_dtl_new b where a.branch_id=b.branch_id  and a.department_id = d.dep_id and a.status_id = 1 and (a.post_id in (199,236,274,279) and a.department_id in (281,170)) and not exists (select d.emp_code from hrm_7days_off_day d where a.emp_code=d.emp_code and d.status in (1,2) and d.to_dt is null)order by  empcode").Tables(0)
                        CbResult = FillData(CbResult, dt5)
                        CbResult = CbResult + "@"
                    ElseIf Session("branch_id") <> 0 Then
                        dt1 = oh.ExecuteDataSet("select a.emp_code,a.emp_name from employee_master a where a.emp_code=" & UserId & " and a.branch_id=" & Session("branch_id") & " and a.status_id=1 and a.post_id in (10,1,251,252,6,15,12,3,198)").Tables(0)
                        If dt1.Rows.Count > 0 Then
                            dt6 = oh.ExecuteDataSet("select count(*) from employee_master e where e.branch_id=" & Session("branch_id") & " and e.status_id=1").Tables(0)
                            Dim sr As Integer = dt6.Rows(0)(0)
                            dt10 = oh.ExecuteDataSet("select ceil(" & sr & "/7) from dual").Tables(0)
                            Me.Hidden2.Value = dt10.Rows(0)(0)
                            dt5 = oh.ExecuteDataSet("select 0,'---SELECT---' as empcode from dual union select a.emp_code,a.emp_code||'-'||a.emp_name as empcode from employee_master a, department_mst d where a.branch_id =" & Session("branch_id") & " and a.department_id = d.dep_id and a.status_id = 1 and a.department_id in (14,44,108,198,134,50,28,123,60,215,281,210) and a.post_id not in (10, 198, 252, 136, 197, 28, 199, 245, 247, 12, 15,236,237,202,249,274,210,204) and not exists (select d.emp_code from hrm_7days_off_day d where a.emp_code=d.emp_code and d.status in (1,2) and d.to_dt is null) order by  empcode").Tables(0)
                            CbResult = FillData(CbResult, dt5)
                            CbResult = CbResult + "@"
                        End If
                    ElseIf Session("branch_id") = 0 Then
                        dt = oh.ExecuteDataSet("select a.department_id from department_major a where a.head_id='" & User(0) & "'").Tables(0)
                        If dt.Rows.Count > 0 Then
                            dt1 = oh.ExecuteDataSet("select distinct(d.dep_ head) from department_mst d,department_major m where d.major_dep_id=m.department_id and m.head_id='" & User(0) & "' and d.dep_head is not null").Tables(0)
                            If dt1.Rows.Count > 0 Then
                                For Each dr In dt1.Rows
                                    str_tkn.Append(dr(0))
                                    str_tkn.Append(",")
                                Next
                                str_tkn.Append("999999")
                                Me.hid_dep.Value = str_tkn.ToString
                            End If
                            dt5 = oh.ExecuteDataSet("select 0, '---SELECT---' as empcode from dual union select a.emp_code,a.emp_code|| '~' || a.emp_name as empcode from employee_master a, department_mst d,department_major m where a.department_id = d.dep_id and d.major_dep_id=m.department_id and a.status_id = 1 and a.branch_id = 0 and m.head_id= '" & UserId & "'and a.emp_code <>'" & UserId & "' and not exists (select aa.emp_code from employee_master aa,department_mst dd where aa.department_id = dd.dep_id and aa.status_id = 1 and aa.branch_id = 0 and dd.dep_head in (" & Me.hid_dep.Value & ") and aa.emp_code not in (" & Me.hid_dep.Value & ") and a.emp_code=aa.emp_code) and not exists (select d.emp_code from hrm_7days_off_day d where a.emp_code=d.emp_code and d.status in (1,2) and d.to_dt is null) order by empcode").Tables(0)
                            CbResult = FillData(CbResult, dt5)
                            CbResult = CbResult + "@"
                        Else
                            'dt2 = oh.ExecuteDataSet("select a.dep_id from department_mst a where a.dep_head='" & User(0) & "'").Tables(0)
                            'If dt2.Rows.Count > 0 Then
                            '    dt5 = oh.ExecuteDataSet("select 0,'---SELECT---' as empcode from dual union select a.emp_code,a.emp_code|| '~' || a.emp_name as empcode from employee_master a,department_mst d where a.department_id not in (20) and a.department_id = d.dep_id and a.status_id = 1 and d.dep_head = " & UserId & " and a.EMP_CODE <> " & UserId & " and not exists (select d.emp_code from hrm_7days_off_day d where a.emp_code=d.emp_code and d.status in (1,2) and d.to_dt is null) order by  empcode").Tables(0)
                            '    CbResult = FillData(CbResult, dt5)
                            '    CbResult = CbResult + "@"
                            '    Me.hid_count.Value = dt5.Rows.Count
                            '    dt10 = oh.ExecuteDataSet("select ceil(" & Me.hid_count.Value & "/7) from dual").Tables(0)
                            '    Me.Hidden2.Value = dt10.Rows(0)(0)
                            'End If
                            'Earlier code ... commented and modified code added below. This to give authorizarion to do weekly off updation for
                            'Those who available in Form Accessibility set in DB. 20-Oct-2016

                            Dim dtTemp As New DataTable()
                            dtTemp = oh.ExecuteDataSet("select count(*) from form_accessibility where form_id=1726 and emp_id=" & User(0) & "").Tables(0)
                            If dtTemp.Rows(0)(0) > 0 Then
                                dt5 = oh.ExecuteDataSet("select 0,'---SELECT---' as empcode from dual union select a.emp_code,a.emp_code|| '~' || a.emp_name as empcode from employee_master a,department_mst d,employ_firm f where a.department_id not in (20) and a.department_id = d.dep_id  and a.emp_code=f.emp_code and a.status_id = 1 and f.firm_id=8 and a.EMP_CODE <> " & UserId & " and not exists (select d.emp_code from hrm_7days_off_day d where a.emp_code=d.emp_code and d.status in (1,2) and d.to_dt is null) order by  empcode").Tables(0)
                                CbResult = FillData(CbResult, dt5)
                                CbResult = CbResult + "@"
                                Me.hid_count.Value = dt5.Rows.Count
                                dt10 = oh.ExecuteDataSet("select ceil(" & Me.hid_count.Value & "/7) from dual").Tables(0)
                                Me.Hidden2.Value = dt10.Rows(0)(0)
                            Else
                                dt2 = oh.ExecuteDataSet("select a.dep_id from department_mst a where a.dep_head='" & User(0) & "'").Tables(0)
                                If dt2.Rows.Count > 0 Then
                                    dt5 = oh.ExecuteDataSet("select 0,'---SELECT---' as empcode from dual union select a.emp_code,a.emp_code|| '~' || a.emp_name as empcode from employee_master a,department_mst d where a.department_id not in (20) and a.department_id = d.dep_id and a.status_id = 1 and d.dep_head = " & UserId & " and a.EMP_CODE <> " & UserId & " and not exists (select d.emp_code from hrm_7days_off_day d where a.emp_code=d.emp_code and d.status in (1,2) and d.to_dt is null) order by  empcode").Tables(0)
                                    CbResult = FillData(CbResult, dt5)
                                    CbResult = CbResult + "@"
                                    Me.hid_count.Value = dt5.Rows.Count
                                    dt10 = oh.ExecuteDataSet("select ceil(" & Me.hid_count.Value & "/7) from dual").Tables(0)
                                    Me.Hidden2.Value = dt10.Rows(0)(0)
                                End If
                            End If

                        End If

                    End If

                End If
        End Select
    End Sub
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim User() As String
        User = Session("user_id").ToString.Split("!")
        Dim Status As Integer = 1
        Dim p(5) As OracleParameter
        p(0) = New OracleParameter("brid", OracleType.Number, 4)
        p(0).Value = Session("branch_id")
        p(1) = New OracleParameter("userID", OracleType.Number, 5)
        p(1).Value = User(0)
        p(2) = New OracleParameter("Str", OracleType.VarChar, 100000)
        p(2).Value = Me.Hidden1.Value
        p(3) = New OracleParameter("Fromdt", OracleType.DateTime)
        p(3).Value = Me.txt_Date.Text
        p(4) = New OracleParameter("Status", OracleType.Number)
        p(4).Value = Status
        p(5) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
        p(5).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("hrm_SevenDays_Comp", p)
        Dim cl_script1 As New System.Text.StringBuilder
        cl_script1.Append("         alert('" + p(5).Value + "');")
        cl_script1.Append("         window.open('../home.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
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
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        If (Me.hid_Em.Value = "") Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('Please Select The Employee!!!');")
            cl_script0.Append("         window.open('hrm_Emp_Off_Updt.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        Else
            dt = oh.ExecuteDataSet("select branch_id from employee_master where emp_code=" & Me.hid_Em.Value & " and status_id=1").Tables(0)
            If dt.Rows(0)(0) < 0 Then
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert('This Employee Is In Not Opened Branch!!!');")
                cl_script0.Append("         window.open('hrm_Emp_Off_Updt.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
            Else
                'dt = oh.ExecuteDataSet("select branch_id from employee_master where emp_code=" & Me.hid_Em.Value & " and status_id=1").Tables(0)
                Me.Server.Transfer("Week_Off_Report.aspx?bran_name=" & dt.Rows(0)(0) & "")
            End If
        End If

    End Sub
End Class

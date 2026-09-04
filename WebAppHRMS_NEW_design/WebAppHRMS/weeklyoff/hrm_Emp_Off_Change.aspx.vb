Imports System.Data
Imports System.Data.OracleClient
Partial Class _7DaysWorking_hrm_Emp_Off_Change_6416ae436365
    Inherits System.Web.UI.Page
    Implements Web.UI.ICallbackEventHandler
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2, dt3, dt4, dt5 As New DataTable
    Dim BranchID, AreaID, RegionID As Integer
    Dim str_tkn As New System.Text.StringBuilder
    Dim CbResult As String = Nothing
    Dim dr As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim UserId As Integer = User(0)
        Me.hid_branch.Value = Session("branch_id")
        'CType(Me.Master, WebAppHRMS.edp).Subtitle = "COMPENSATORY OFF DAY CHANGE / EXCHANGE"
        Dim masterPage As WebAppHRMS.edp = CType(Me.Master, WebAppHRMS.edp)
        masterPage.subtitle = "COMPENSATORY OFF DAY CHANGE / EXCHANGE"
        dt1 = oh.ExecuteDataSet("select a.emp_code,a.emp_name,a.post_id from employee_master a where a.emp_code=" & UserId & " and a.status_id=1").Tables(0)
        Me.hid_post.value = dt1.Rows(0)(2)
        If dt1.Rows.Count <= 0 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('You Are Not Authorised !!!!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        End If
        Dim client_name As String
        client_name = "var master_no;" & "master_no='" & "" & Me.cmb_Code.ClientID & "'" & ";"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", client_name, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "FromServer", "context", True)
        Dim cbscript As String = "function ToServer (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ToServer", cbscript, True)
        Me.txt_Date.Attributes.Add("onkeyup", "OnkeyUpChqDate('txt_Date')")
        'If Not IsPostBack Then
        '    dt1 = oh.ExecuteDataSet("select to_date(sysdate) from dual").Tables(0)
        '    Me.hdn_sysdate.Value = Format(dt1.Rows(0)(0), "dd/MMM/yyyy")
        '    Me.txt_Date.Text = Me.hdn_sysdate.Value
        'End If
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return CbResult
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim UserId As Integer = User(0)
        Dim DataStr() As String
        DataStr = eventArgument.Split("#")
        Select Case (DataStr(1))
            Case 1
                Dim Instr() As String = DataStr(0).Split("%")
                Dim BRANID As String = Instr(0)
                dt3 = oh.ExecuteDataSet("select a.post_id,a.branch_id,a.department_id from employee_master a where a.emp_code=" & User(0) & " and a.status_id=1").Tables(0)
                Dim POSTID As Integer = dt3.Rows(0)(0)
                Dim DEP As Integer = dt3.Rows(0)(2)
                Dim Sr As Integer = dt3.Rows(0)(1)
                dt1 = oh.ExecuteDataSet("select area_id,reg_id from branch_dtl_new where branch_id=" & Sr & "").Tables(0)
                dt3 = oh.ExecuteDataSet("select count(a.ia_tour_head) from region_master a where a.ia_tour_head=" & User(0) & "").Tables(0)
                If dt3.Rows(0)(0) >= 1 Then
                    dt = oh.ExecuteDataSet("select h.emp_code, h.emp_code || '-' || a.emp_name from employee_master a, hrm_7days_off_day h,branch_dtl_new b where a.emp_code = h.emp_code and h.to_dt is null and h.branch_id=b.branch_id and b.reg_id=" & dt1.Rows(0)(1) & " and a.department_id in (4, 170, 178, 188,211, 280) and h.status=1 and h.chg_count is null order by a.emp_code").Tables(0)
                ElseIf POSTID = 28 Or POSTID = 199 Or POSTID = 245 Or POSTID = 247 Then
                    dt = oh.ExecuteDataSet("select h.emp_code, h.emp_code || '-' || a.emp_name from employee_master a, hrm_7days_off_day h,branch_dtl_new b where a.emp_code = h.emp_code and h.to_dt is null and h.branch_id=b.branch_id and b.reg_id=" & dt1.Rows(0)(1) & " and a.post_id in (136,197) and h.status=1 and h.chg_count is null order by a.emp_code").Tables(0)
                ElseIf POSTID = 136 Or POSTID = 197 Then
                    dt = oh.ExecuteDataSet("select h.emp_code,h.emp_code || '-' || a.emp_name from employee_master a, hrm_7days_off_day h,branch_dtl_new b where a.emp_code = h.emp_code and h.to_dt is null and h.status=1 and h.branch_id=b.branch_id and b.area_id=" & dt1.Rows(0)(0) & " and a.post_id in (10,198,252,12,15) and h.chg_count is null order by a.emp_code").Tables(0)
                ElseIf POSTID = 173 Then
                    dt3 = oh.ExecuteDataSet("select reg_id from region_master z where z.rh_op=" & User(0) & "").Tables(0)
                    If dt3.Rows.Count > 0 Then
                        Dim ZONEID As Integer = dt3.Rows(0)(0)
                        dt = oh.ExecuteDataSet("select h.emp_code, h.emp_code || '-' || a.emp_name from employee_master a, hrm_7days_off_day h, branch_dtl_new b where a.emp_code = h.emp_code and h.to_dt is null and h.status = 1 and h.branch_id = b.branch_id and b.zonal_id = " & ZONEID & "  and (a.post_id in (210,202,199,136,204) or a.department_id in (14,210,32,6,50,198,215,28,4,170,178,188,123,211,280,281)) and h.chg_count is null order by a.emp_code").Tables(0)
                    End If
                ElseIf UserId = 21680 Then
                    dt = oh.ExecuteDataSet("select h.emp_code, h.emp_code || '-' || a.emp_name from employee_master a, hrm_7days_off_day h,branch_dtl_new b where a.emp_code = h.emp_code and h.to_dt is null and h.branch_id=b.branch_id and a.department_id in (20) and h.status=1 and h.chg_count is null order by a.emp_code").Tables(0)
                ElseIf ((DEP = 4 Or DEP = 178 Or DEP = 188 Or DEP = 170 Or DEP = 211 Or DEP = 280 Or DEP = 281) And POSTID = 85) Then
                    dt = oh.ExecuteDataSet("select h.emp_code, h.emp_code || '-' || a.emp_name from employee_master a, hrm_7days_off_day h, region_master r where a.emp_code = h.emp_code and h.to_dt is null and h.emp_code = r.ia_tour_head and h.status = 1 and h.chg_count is null order by a.emp_code").Tables(0)
                Else
                    dt1 = oh.ExecuteDataSet("select a.emp_code,a.emp_name from employee_master a where a.emp_code=" & User(0) & " and a.branch_id=" & BRANID & " and a.status_id=1 and a.post_id in (10,198,252,15,12)").Tables(0)
                    If dt1.Rows.Count > 0 Then
                        dt = oh.ExecuteDataSet("select h.emp_code,h.emp_code || '-' || a.emp_name from employee_master a, hrm_7days_off_day h,branch_dtl_new b where a.emp_code = h.emp_code and h.to_dt is null and h.status=1 and h.branch_id=b.branch_id and h.branch_id = " & BRANID & " and a.post_id not in (10,198,136,197,28,199,252,12,15,236,237,202,249,274) and a.department_id not in (4, 170, 178, 188,211, 280,5) and h.chg_count is null order by a.emp_code").Tables(0)
                    Else
                        dt2 = oh.ExecuteDataSet("select a.dep_id from department_mst a where a.dep_head=" & User(0) & "").Tables(0)
                        If dt2.Rows.Count > 0 Then
                            dt = oh.ExecuteDataSet("select h.emp_code, h.emp_code || '-' || a.emp_name from employee_master a, hrm_7days_off_day h, branch_dtl_new b,department_mst d where a.emp_code = h.emp_code and a.department_id=d.dep_id and h.to_dt is null and h.status = 1 and h.branch_id = b.branch_id and h.emp_code <>" & User(0) & " and d.dep_head=" & User(0) & " and h.chg_count is null order by a.emp_code").Tables(0)
                        Else
                            dt2 = oh.ExecuteDataSet("select a.department_id from department_major a where a.head_id=" & User(0) & "").Tables(0)
                            If dt2.Rows.Count > 0 Then
                                dt = oh.ExecuteDataSet("select h.emp_code, h.emp_code || '-' || a.emp_name from employee_master   a,hrm_7days_off_day h,branch_dtl_new    b,department_mst    d,department_major dd where a.emp_code = h.emp_code and a.department_id = d.dep_id and d.major_dep_id=dd.department_id and dd.head_id='" & User(0) & "' and h.to_dt is null and h.status = 1 and h.branch_id = b.branch_id and h.emp_code <>" & User(0) & " and h.chg_count is null order by a.emp_code").Tables(0)
                            End If
                        End If
                    End If
                End If
                CbResult = FillData(CbResult, dt)
                CbResult = CbResult + "@"
                Try
                    dt1 = oh.ExecuteDataSet("select decode(a.holiday,1,'SUNDAY',2,'MONDAY',3,'TUESDAY',4,'WEDNESDAY',5,'THURSDAY',6,'FRIDAY',7,'SATURDAY') from hrm_7days_off_day a where a.emp_code=" & dt.Rows(0)(0) & " and a.to_dt is null and a.status=1").Tables(0)
                    dt2 = oh.ExecuteDataSet("select next_day(to_date(to_char(sysdate)),'" & dt1.Rows(0)(0) & "')from dual").Tables(0)
                Catch ex As Exception
                    str_tkn.Append(ex.Message)
                End Try
                If dt2.Rows.Count <> 0 Then
                    str_tkn.Append(Format(dt2.Rows(0)(0), "dd/MMM/yyyy"))
                    str_tkn.Append("!")
                    str_tkn.Append(dt1.Rows(0)(0))
                    str_tkn.Append("~")
                End If
                str_tkn.Append("@")
                str_tkn.Append("2")
                CbResult = CbResult + str_tkn.ToString
            Case 2
                Dim Instr() As String = DataStr(0).Split("%")
                Dim BRANID As String = Instr(0)
                dt3 = oh.ExecuteDataSet("select a.post_id,a.branch_id from employee_master a where a.emp_code=" & User(0) & " and a.status_id=1").Tables(0)
                Dim POSTID As Integer = dt3.Rows(0)(0)
                Dim Sr As Integer = dt3.Rows(0)(1)
                If POSTID = 136 Or POSTID = 197 Then
                    dt1 = oh.ExecuteDataSet("select area_id,reg_id from branch_dtl_new where branch_id=" & Sr & "").Tables(0)
                    dt = oh.ExecuteDataSet("select h.emp_code,h.emp_code || '-' || a.emp_name from employee_master a, hrm_7days_off_day h,branch_dtl_new b where a.emp_code = h.emp_code and h.to_dt is null and h.status=1 and h.branch_id=b.branch_id and b.area_id=" & dt1.Rows(0)(0) & " and a.post_id in (10,198,252,12,15) and h.chg_count is null order by a.emp_code").Tables(0)
                Else
                    dt1 = oh.ExecuteDataSet("select a.emp_code,a.emp_name from employee_master a where a.emp_code=" & User(0) & " and a.branch_id=" & BRANID & " and a.status_id=1 and a.post_id=10").Tables(0)
                    If dt1.Rows.Count > 0 Then
                        dt = oh.ExecuteDataSet("select h.emp_code,h.emp_code || '-' || a.emp_name from employee_master a, hrm_7days_off_day h where a.emp_code = h.emp_code and h.to_dt is null and h.status=1 and h.branch_id = " & BRANID & " and a.post_id not in (10,198,136,197,28,199,252,12,15,236,237,202,249,274) and a.department_id not in (4, 170, 178, 188,211, 280,5) and h.chg_count is null order by a.emp_code").Tables(0)
                    Else
                        dt2 = oh.ExecuteDataSet("select a.dep_id from department_mst a where a.dep_head='" & User(0) & "'").Tables(0)
                        If dt2.Rows.Count > 0 Then
                            dt = oh.ExecuteDataSet("select h.emp_code, h.emp_code || '-' || a.emp_name from employee_master a, hrm_7days_off_day h, branch_dtl_new b,department_mst d where a.emp_code = h.emp_code and a.department_id=d.dep_id and h.to_dt is null and h.status = 1 and h.branch_id = b.branch_id and h.emp_code <>" & User(0) & " and d.dep_head=" & User(0) & " and h.chg_count is null order by a.emp_code").Tables(0)
                        End If
                    End If
                End If
                CbResult = FillData(CbResult, dt)
                CbResult = CbResult + "@"
                Try
                    dt1 = oh.ExecuteDataSet("select decode(a.holiday,1,'SUNDAY',2,'MONDAY',3,'TUESDAY',4,'WEDNESDAY',5,'THURSDAY',6,'FRIDAY',7,'SATURDAY') from hrm_7days_off_day a where a.emp_code=" & dt.Rows(0)(0) & " and a.to_dt is null and a.status=1").Tables(0)
                    dt2 = oh.ExecuteDataSet("select next_day(to_date(to_char(sysdate)),'" & dt1.Rows(0)(0) & "')from dual").Tables(0)
                Catch ex As Exception
                    str_tkn.Append(ex.Message)
                End Try
                If dt2.Rows.Count <> 0 Then
                    str_tkn.Append(Format(dt2.Rows(0)(0), "dd/MMM/yyyy"))
                    str_tkn.Append("!")
                    str_tkn.Append(dt1.Rows(0)(0))
                    str_tkn.Append("~")
                End If
                str_tkn.Append("@")
                str_tkn.Append("2")
                CbResult = CbResult + str_tkn.ToString
            Case 3
                Dim Instr() As String = DataStr(0).Split("%")
                Dim CODE As String = Instr(0)
                dt = oh.ExecuteDataSet("select decode(a.holiday,1,'SUNDAY',2,'MONDAY',3,'TUESDAY',4,'WEDNESDAY',5,'THURSDAY',6,'FRIDAY',7,'SATURDAY') from hrm_7days_off_day a where a.emp_code=" & CODE & " and a.to_dt is null and a.status=1").Tables(0)
                dt1 = oh.ExecuteDataSet("select next_day(to_date(to_char(sysdate)),'" & dt.Rows(0)(0) & "')from dual").Tables(0)
                If dt1.Rows.Count <> 0 Then
                    str_tkn.Append(Format(dt1.Rows(0)(0), "dd/MMM/yyyy"))
                    str_tkn.Append("!")
                    str_tkn.Append(dt.Rows(0)(0))
                    str_tkn.Append("~")
                End If
                str_tkn.Append("@")
                str_tkn.Append("2")
                CbResult = str_tkn.ToString
            Case 4
                Dim Instr() As String = DataStr(0).Split("%")
                Dim CODE As String = Instr(0)
                dt = oh.ExecuteDataSet("select decode(a.holiday,1,'SUNDAY',2,'MONDAY',3,'TUESDAY',4,'WEDNESDAY',5,'THURSDAY',6,'FRIDAY',7,'SATURDAY') from hrm_7days_off_day a where a.emp_code=" & CODE & " and a.to_dt is null and a.status=1").Tables(0)
                dt1 = oh.ExecuteDataSet("select next_day(to_date(to_char(sysdate)),'" & dt.Rows(0)(0) & "')from dual").Tables(0)
                If dt1.Rows.Count <> 0 Then
                    str_tkn.Append(Format(dt1.Rows(0)(0), "dd/MMM/yyyy"))
                    str_tkn.Append("!")
                    str_tkn.Append(dt.Rows(0)(0))
                    str_tkn.Append("~")
                End If
                str_tkn.Append("@")
                str_tkn.Append("2")
                CbResult = str_tkn.ToString
            Case 5
                Dim Instr() As String = DataStr(0).Split("%")
                Dim CODE As String = Instr(0)
                dt = oh.ExecuteDataSet("select decode(a.holiday,1,'SUNDAY',2,'MONDAY',3,'TUESDAY',4,'WEDNESDAY',5,'THURSDAY',6,'FRIDAY',7,'SATURDAY') from hrm_7days_off_day a where a.emp_code=" & CODE & " and a.to_dt is null and a.status=1").Tables(0)
                dt1 = oh.ExecuteDataSet("select next_day(to_date(to_char(sysdate)),'" & dt.Rows(0)(0) & "')from dual").Tables(0)
                If dt1.Rows.Count <> 0 Then
                    str_tkn.Append(Format(dt1.Rows(0)(0), "dd/MMM/yyyy"))
                    str_tkn.Append("!")
                    str_tkn.Append(dt.Rows(0)(0))
                    str_tkn.Append("~")
                End If
                str_tkn.Append("@")
                str_tkn.Append("2")
                CbResult = str_tkn.ToString
            Case 6
                Dim Instr() As String = DataStr(0).Split("%")
                Dim EMPCODE As Integer = Instr(0)
                Dim OFFDAY As String = Instr(1)
                Dim OFFDATE As Date = Instr(2)
                Dim BRANID As Integer = Instr(3)
                Dim REASON As String = Instr(4)
                Try
                    'Dim User() As String
                    'User = Session("user_id").ToString.Split("!")
                    Dim p(6) As OracleParameter
                    p(0) = New OracleParameter("EMPCODE", OracleType.Number, 6)
                    p(0).Value = EMPCODE

                    p(1) = New OracleParameter("OFFDAY", OracleType.VarChar, 25)
                    p(1).Value = OFFDAY

                    p(2) = New OracleParameter("OFFDATE", OracleType.DateTime)
                    p(2).Value = OFFDATE

                    p(3) = New OracleParameter("BRANID", OracleType.Number, 4)
                    p(3).Value = BRANID

                    p(4) = New OracleParameter("UserID", OracleType.Number, 6)
                    p(4).Value = User(0)

                    p(5) = New OracleParameter("REASON", OracleType.VarChar, 100)
                    p(5).Value = REASON

                    p(6) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
                    p(6).Direction = ParameterDirection.Output
                    oh.ExecuteNonQuery("hrm_SevenDays_Off_Change", p)
                    CbResult = p(6).Value
                Catch ex As Exception
                    CbResult = ex.Message
                End Try
                'select to_char(to_date('14-jun-2010'),'day') from dual;
            Case 7
                Dim Instr() As String = DataStr(0).Split("%")
                Dim EMPCODE As Integer = Instr(0)
                Dim OFFDAY As String = Instr(1)
                Dim EMPCODE1 As Integer = Instr(2)
                Dim OFFDAY1 As String = Instr(3)
                Dim BRANID As Integer = Instr(4)
                Dim REASON As String = Instr(5)
                Try
                    Dim p(7) As OracleParameter
                    p(0) = New OracleParameter("EMPCODE", OracleType.Number, 6)
                    p(0).Value = EMPCODE

                    p(1) = New OracleParameter("OFFDAY", OracleType.VarChar, 25)
                    p(1).Value = OFFDAY

                    p(2) = New OracleParameter("EMPCODE1", OracleType.Number, 6)
                    p(2).Value = EMPCODE1

                    p(3) = New OracleParameter("OFFDAY1", OracleType.VarChar, 25)
                    p(3).Value = OFFDAY1

                    p(4) = New OracleParameter("BRANID", OracleType.Number, 4)
                    p(4).Value = BRANID

                    p(5) = New OracleParameter("UserID", OracleType.Number, 6)
                    p(5).Value = User(0)

                    p(6) = New OracleParameter("REASON", OracleType.VarChar, 100)
                    p(6).Value = REASON

                    p(7) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
                    p(7).Direction = ParameterDirection.Output
                    oh.ExecuteNonQuery("hrm_SevenDays_Off_ExChange", p)
                    CbResult = p(7).Value
                Catch ex As Exception
                    CbResult = ex.Message
                End Try
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
End Class

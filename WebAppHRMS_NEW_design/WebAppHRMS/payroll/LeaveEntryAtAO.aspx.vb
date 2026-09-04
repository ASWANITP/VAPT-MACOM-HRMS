Imports System.Data
Imports System.Data.OracleClient
Partial Class payroll_LeaveEntryAtAO_b18b22962543
    Inherits System.Web.UI.Page
    Implements Web.UI.ICallbackEventHandler
    Dim CH As New WholeHelper.ClsComCtrl
    Dim str_tkn As New System.Text.StringBuilder
    Dim OH As New Helper.Oracle.OracleHelper
    Dim DT, dttt, dt20 As New DataTable
    Dim cbResult As String
    Dim DateArray() As String
    Protected Sub Page_Load(ByVal sener As Object, ByVal e As System.EventArgs) Handles Me.Load
        '--//---------- Page Heading -----------//--
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "LEAVE ENTRY"
        '--//---------- Access Validations -----------//--
        Dim UserDtl() As String = Session("user_id").split("!")
        DT = OH.ExecuteDataSet("select emp_code from EMPLOYEE_MASTER where branch_id in(0,3439,3427) and access_id = 33 and emp_code = " & CInt(UserDtl(0)) & "").Tables(0)
        If DT.Rows.Count <= 0 Then
            Server.Transfer("../show_err.aspx")
            Return
        End If
        '--//---------- Script Registrations -----------//--
        '/--- For Client ID ---//
        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txtAppliedDt.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        '/--- For Call Back ---//
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "fromServer", "context", True)
        Dim cbscript As String = "function toServer (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "toServer", cbscript, True)
        '--//---------- Declaring Functions -----------//--
        Me.txtEmpCode.Attributes.Add("onkeydown", "EmpCodeOnkeydown()")
        Me.txtAppliedDt.Attributes.Add("onkeydown", "FocusToServer('cmbLeaveType')")
        Me.cmbLeaveType.Attributes.Add("onkeydown", "FocusToServer('txtFromDt')")
        Me.txtFromDt.Attributes.Add("onkeydown", "FocusToServer('txtToDt')")
        Me.txtToDt.Attributes.Add("onkeydown", "FocusToServer('txtReason')")
        Me.txtReason.Attributes.Add("onkeydown", "FocusToClient('btnConfirm')")
        Me.chkApplication.Attributes.Add("onclick", "CheckApplied()")
        Me.txtAppliedDt.Attributes.Add("onblur", "isValidDate('txtAppliedDt')")
        Me.txtFromDt.Attributes.Add("onblur", "isValidDate('txtFromDt')")
        Me.txtToDt.Attributes.Add("onblur", "isValidDate('txtToDt')")
        Me.txtAppliedDt.Attributes.Add("onchange", "CheckFutureDate()")
        Me.txtFromDt.Attributes.Add("onkeyup", "DateOnkeyup()")
        Me.txtToDt.Attributes.Add("onkeyup", "DateOnkeyup()")
        Me.txtFromDt.Attributes.Add("onchange", "GetDays()")
        Me.txtToDt.Attributes.Add("onchange", "GetDays()")
        Me.cmbLeaveType.Attributes.Add("onchange", "GetDays()")
        '--//---------- Initializing Datas -----------//--
        If Not IsPostBack Then
            DT = OH.ExecuteDataSet("select leave_id,leave_type from LEAVE_MASTER where leave_id in (1,2,3,4) order by leave_id").Tables(0)
            CH.ComboFill(cmbLeaveType, DT, 0, 1)
            Me.txtAppliedDt.Text = Format(Date.Today, "dd/MM/yyyy")
            Me.txtFromDt.Text = Format(Date.Today, "dd/MM/yyyy")
            Me.txtToDt.Text = Format(Date.Today, "dd/MM/yyyy")
            Me.hidSystemDate.Value = Format(Date.Today, "dd/MM/yyyy")
            Me.txtDays.Value = 1
            Me.hidTotalDays.Value = 1
        End If
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return cbResult
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim fid As Integer = Session("firm_id")

        Dim data() As String = eventArgument.Split("?")
        Select Case data(0)
            Case "1"    '"1?" + EmpCode
                Dim EmpCode As Integer = CInt(data(1))
                If fid = 24 Then
                    DT = OH.ExecuteDataSet("select count(*)  from EMPLOYEE_MASTER e,employ_firm f where e.emp_code=f.emp_code and f.firm_id=" & fid & " and e.emp_code = " & EmpCode & " and e.status_id in (1, 4,6,10)").Tables(0)
                Else
                    ' DT = OH.ExecuteDataSet("select count(*) from EMPLOYEE_MASTER where emp_code = " & EmpCode & " and status_id in (1,4)").Tables(0)
                    DT = OH.ExecuteDataSet("select count(*)  from EMPLOYEE_MASTER e,employ_firm f where e.emp_code=f.emp_code and f.firm_id=" & fid & " and e.emp_code = " & EmpCode & " and e.status_id in (1, 4)").Tables(0)
                End If
                If CInt(DT.Rows(0)(0)) = 0 Then
                    cbResult = "?0?0?0?Error?No Such Employee Code!"
                Else
                    DT = OH.ExecuteDataSet("select branch_id from EMPLOYEE_MASTER where emp_code = " & EmpCode & "").Tables(0)
                    Dim BranchID As Integer = CInt(DT.Rows(0)(0))
                    DT = OH.ExecuteDataSet("select id from BRANCH_HOLIDAY where branch_id = " & BranchID & "").Tables(0)
                    If DT.Rows.Count <= 0 Then
                        cbResult = "?0?0?0?Error?No Information About Weekly Holiday of Branch !"
                        Return
                    End If
                    If fid = 24 Then
                        DT = OH.ExecuteDataSet("select emp_name from EMPLOYEE_MASTER where emp_code = " & EmpCode & "and status_id in (1,4,6,10) ").Tables(0)
                    Else
                        DT = OH.ExecuteDataSet("select emp_name from EMPLOYEE_MASTER where emp_code = " & EmpCode & "and status_id in (1,4) ").Tables(0)
                    End If
                    Dim EmpName As String = DT.Rows(0)(0).ToString
                    DT = OH.ExecuteDataSet("select nvl(sum(leave_days),0) from employ_leave_master where emp_code = " & EmpCode & " and leave_id = 1").Tables(0)
                    Dim Casual As Integer = CInt(DT.Rows(0)(0))
                    DT = OH.ExecuteDataSet("select nvl(sum(leave_days),0) from employ_leave_master where emp_code = " & EmpCode & " and leave_id = 2").Tables(0)
                    Dim Sick As Integer = CInt(DT.Rows(0)(0))
                    DT = OH.ExecuteDataSet("select nvl(sum(leave_days),0) from employ_leave_master where emp_code = " & EmpCode & " and leave_id = 3").Tables(0)
                    Dim Earned As Integer = CInt(DT.Rows(0)(0))
                    cbResult = EmpName + "?" + Casual.ToString + "?" + Sick.ToString + "?" + Earned.ToString
                End If
            Case "2"    '"2?" + AppliedDt
                DateArray = data(1).ToString.Split("/")
                Dim AppliedDt As Date = CDate(DateArray(1) + "/" + DateArray(0) + "/" + DateArray(2))
                cbResult = "0"
                If AppliedDt > Date.Today Then
                    cbResult = "1"
                End If
            Case "3"    '"3?" + FromDt + "?" + ToDt + "?" + Type + "?" + EmpCode
                DateArray = data(1).ToString.Split("/")
                Dim FromDt As Date = CDate(DateArray(1) + "/" + DateArray(0) + "/" + DateArray(2))
                DateArray = data(2).ToString.Split("/")
                Dim ToDt As Date = CDate(DateArray(1) + "/" + DateArray(0) + "/" + DateArray(2))
                Dim LeaveType = CInt(data(3))
                Dim dt1 As String = Format(FromDt, "dd/MMM/yyyy")
                Dim dt2 As String = Format(ToDt, "dd/MMM/yyyy")
                Dim EmpCode As Integer = CInt(data(4))
                dttt = OH.ExecuteDataSet("select to_char(to_date('" & dt1 & "'),'D')from dual").Tables(0)

                DT = OH.ExecuteDataSet("select branch_id from EMPLOYEE_MASTER where emp_code = " & EmpCode & "").Tables(0)
                Dim BranchID As Integer = CInt(DT.Rows(0)(0))
                'DT = OH.ExecuteDataSet("select id from BRANCH_HOLIDAY where branch_id = " & BranchID & "").Tables(0)
                Dim Holiday As Integer = 1
                If BranchID = 0 Then
                    Holiday = 1
                Else
                    'DT = OH.ExecuteDataSet("select a.holiday from hrm_7days_off_day a where a.emp_code=" & EmpCode & " and (to_date(a.from_dt)>='" & dt1 & "' and to_date(a.to_dt)<='" & dt2 & "') or (to_date(a.from_dt)>='" & dt1 & "' and to_date(a.to_dt) is null)").Tables(0)
                    dt20 = OH.ExecuteDataSet("select count(a.holiday) from hrm_7days_off_day a where a.emp_code = " & EmpCode & "").Tables(0)
                    'If dt20.Rows(0)(0) > 0 Then
                    '    DT = OH.ExecuteDataSet("select count(a.holiday) from hrm_7days_off_day a where a.emp_code = " & EmpCode & " and ((to_date('" & dt1 & "') between to_date(a.from_dt) and to_date(a.to_dt) )or (to_date('" & dt2 & "') between  to_date(a.from_dt) and to_date(a.to_dt)))").Tables(0)
                    '    If DT.Rows(0)(0) = 0 Then
                    '        DT = OH.ExecuteDataSet("select a.holiday from hrm_7days_off_day a where a.emp_code = " & EmpCode & " and to_date(a.to_dt) is null").Tables(0)
                    '        Holiday = CInt(DT.Rows(0)(0))
                    '    Else
                    '        DT = OH.ExecuteDataSet("select a.holiday from hrm_7days_off_day a where a.emp_code = " & EmpCode & " and ((to_date('" & dt1 & "') between to_date(a.from_dt) and to_date(a.to_dt) )or (to_date('" & dt2 & "') between  to_date(a.from_dt) and to_date(a.to_dt)))").Tables(0)
                    '        Holiday = CInt(DT.Rows(0)(0))
                    '    End If
                    'Else
                    '    DT = OH.ExecuteDataSet("select id from BRANCH_HOLIDAY where branch_id = " & BranchID & "").Tables(0)
                    'End If
                End If

                Dim TotalDays As Integer = DateDiff(DateInterval.Day, FromDt, ToDt) + 1
                Dim WorkingDays As Integer = 0
                Dim ActualFirstDate As Date = FromDt
                Dim ActualLastDate As Date = ToDt
                Dim Front As Integer = 0
                Dim tmpDate As Date = FromDt

                For n As Integer = 1 To TotalDays

                    DT = OH.ExecuteDataSet("select count(*) from COMMON_HOLIDAY where branch_id = " & BranchID & " and status_id = 9 and to_date(hol_day) = '" & Format(tmpDate, "dd-MMM-yyyy") & "'").Tables(0)
                    'If CInt(DT.Rows(0)(0)) = 0 And tmpDate.DayOfWeek + 1 <> Holiday Then 'If No Holiday
                    If CInt(DT.Rows(0)(0)) = 0 And CInt(dttt.Rows(0)(0)) <> Holiday Then
                        If Front = 0 Then
                            ActualFirstDate = tmpDate
                            Front = 1
                        End If
                        ActualLastDate = tmpDate
                        WorkingDays += 1
                    End If
                    tmpDate = DateAdd(DateInterval.Day, 1, tmpDate)
                Next
                TotalDays = DateDiff(DateInterval.Day, ActualFirstDate, ActualLastDate) + 1
                If TotalDays > 3 Then
                    WorkingDays = TotalDays
                Else
                    If LeaveType <> 1 Then '--//--  Except Casual Leave  --//--
                        WorkingDays = TotalDays
                    End If
                    If TotalDays < 0 Then
                        TotalDays = 0
                    End If
                    If WorkingDays < 0 Then
                        WorkingDays = 0
                    End If
                End If
                cbResult = TotalDays.ToString + "?" + WorkingDays.ToString + "?" + Format(ActualFirstDate, "dd/MM/yyyy") + "?" + Format(ActualLastDate, "dd/MM/yyyy")
            Case "9"
                '"9"    + "?" + EmpCode + "?" + Applied     + "?" + AppliedDt + "?" + LeaveType + "?";
                'FromDt + "?" + ToDt    + "?" + WorkingDays + "?" + Reason    + "?" + TotalDays + "?" + chairman;
                Dim FailedField As String = ""
                Try
                    FailedField = "Employee Name"
                    Dim EmpCode As Integer = CInt(data(1))
                    FailedField = "Whether Applied"
                    Dim Applied As Integer = CInt(data(2))
                    FailedField = "Applied Date"
                    DateArray = data(3).ToString.Split("/")
                    Dim AppliedDt As Date = CDate(DateArray(1) + "/" + DateArray(0) + "/" + DateArray(2))
                    FailedField = "Leave Type"
                    Dim LeaveID As Integer = CInt(data(4))
                    FailedField = "From Date"
                    DateArray = data(5).ToString.Split("/")
                    Dim FromDt As Date = CDate(DateArray(1) + "/" + DateArray(0) + "/" + DateArray(2))
                    FailedField = "To Date"
                    DateArray = data(6).ToString.Split("/")
                    Dim ToDt As Date = CDate(DateArray(1) + "/" + DateArray(0) + "/" + DateArray(2))
                    FailedField = "Working Days"
                    Dim WorkingDays As Integer = CInt(data(7))
                    FailedField = "Reason"
                    Dim Reason As String = data(8)
                    FailedField = "Total Days"
                    Dim TotalDays As Integer = data(9)
                    FailedField = "Chairman"
                    Dim chairman As Integer = data(10)
                    FailedField = "DataChk"
                    'If data(11) = "" Then
                    '    Dim DataChk As String = 0
                    'Else
                    '    Dim DataChk As String = data(11)
                    'End If

                    FailedField = "Stored Procedure - STP_PAYROLL_LEAVE_ENTRY_1"


                    '--//-- Calling Stored Procedure -- STP_PAYROLL_LEAVE_ENTRY --//--
                    Dim parm_coll(12) As OracleParameter
                    parm_coll(0) = New OracleParameter("EmpCode", OracleType.Number, 5)
                    parm_coll(0).Value = EmpCode
                    parm_coll(0).Direction = ParameterDirection.Input
                    parm_coll(1) = New OracleParameter("Applied", OracleType.Number, 2)
                    parm_coll(1).Value = Applied
                    parm_coll(1).Direction = ParameterDirection.Input
                    parm_coll(2) = New OracleParameter("AppliedDt", OracleType.DateTime)
                    parm_coll(2).Value = AppliedDt
                    parm_coll(2).Direction = ParameterDirection.Input
                    parm_coll(3) = New OracleParameter("LeaveID", OracleType.Number, 2)
                    parm_coll(3).Value = LeaveID
                    parm_coll(3).Direction = ParameterDirection.Input
                    parm_coll(4) = New OracleParameter("FromDt", OracleType.DateTime)
                    parm_coll(4).Value = FromDt
                    parm_coll(4).Direction = ParameterDirection.Input
                    parm_coll(5) = New OracleParameter("ToDt", OracleType.DateTime)
                    parm_coll(5).Value = ToDt
                    parm_coll(5).Direction = ParameterDirection.Input
                    parm_coll(6) = New OracleParameter("Days", OracleType.Number, 10)
                    parm_coll(6).Value = WorkingDays
                    parm_coll(6).Direction = ParameterDirection.Input
                    parm_coll(7) = New OracleParameter("Reason", OracleType.VarChar, 100)
                    parm_coll(7).Value = Reason
                    parm_coll(7).Direction = ParameterDirection.Input
                    parm_coll(8) = New OracleParameter("TotalDays", OracleType.Number, 10)
                    parm_coll(8).Value = TotalDays
                    parm_coll(8).Direction = ParameterDirection.Input
                    parm_coll(9) = New OracleParameter("UserID", OracleType.VarChar, 50)
                    parm_coll(9).Value = Session("user_id")
                    parm_coll(9).Direction = ParameterDirection.Input
                    parm_coll(10) = New OracleParameter("ErrorMsg", OracleType.VarChar, 1000)
                    parm_coll(10).Direction = ParameterDirection.Output
                    parm_coll(11) = New OracleParameter("chair_man", OracleType.Number, 1)
                    parm_coll(11).Value = chairman
                    parm_coll(11).Direction = ParameterDirection.Input

                    If data(11) = "" Then
                        Dim DataChk As String = 0
                        parm_coll(12) = New OracleParameter("DataChk", OracleType.VarChar, 10000)
                        parm_coll(12).Value = DataChk
                        parm_coll(12).Direction = ParameterDirection.Input
                    Else
                        Dim DataChk As String = data(11)
                        parm_coll(12) = New OracleParameter("DataChk", OracleType.VarChar, 10000)
                        parm_coll(12).Value = DataChk
                        parm_coll(12).Direction = ParameterDirection.Input
                    End If
                    OH.ExecuteNonQuery("STP_PAYROLL_LEAVE_ENTRY_1", parm_coll)
                    cbResult = parm_coll(10).Value.ToString
                    DT = OH.ExecuteDataSet("select nvl(sum(leave_days),0) from employ_leave_master where emp_code = " & EmpCode & " and leave_id = 1").Tables(0)
                    Dim CasualRemaining As Integer = CInt(DT.Rows(0)(0))
                    DT = OH.ExecuteDataSet("select nvl(sum(leave_days),0) from employ_leave_master where emp_code = " & EmpCode & " and leave_id = 2").Tables(0)
                    Dim SickRemaining As Integer = CInt(DT.Rows(0)(0))
                    DT = OH.ExecuteDataSet("select nvl(sum(leave_days),0) from employ_leave_master where emp_code = " & EmpCode & " and leave_id = 3").Tables(0)
                    Dim EarnedRemaining As Integer = CInt(DT.Rows(0)(0))
                    cbResult += "?" + CasualRemaining.ToString + "?" + SickRemaining.ToString + "?" + EarnedRemaining.ToString
                Catch ex As Exception
                        cbResult = ex.Message.ToString + " --- Check " + FailedField
                    End Try
            Case "4"
                    Dim Instr() As String = data(1).Split("%")
                Dim CODE As String = Instr(0)
                If fid = 24 Then
                    DT = OH.ExecuteDataSet("select b.emp_name,to_char(to_date(a.leave_frdate)),to_char(to_date(a.leave_todate)),c.leave_type,a.leave_days,d.reason_name,a.leave_seq from hrm_leave_apply_sanction a,employee_master b,leave_master c,hrm_category_dtl d where a.emp_code=b.emp_code and c.leave_id=a.leave_id and d.reason_id=a.reason_id and a.category_id=d.category_id and a.emp_code=" & CODE & " and b.status_id in(1,6,10) and  a.status_id not in (1,2,3) order by a.leave_frdate").Tables(0)
                Else
                    DT = OH.ExecuteDataSet("select b.emp_name,to_char(to_date(a.leave_frdate)),to_char(to_date(a.leave_todate)),c.leave_type,a.leave_days,d.reason_name,a.leave_seq from hrm_leave_apply_sanction a,employee_master b,leave_master c,hrm_category_dtl d where a.emp_code=b.emp_code and c.leave_id=a.leave_id and d.reason_id=a.reason_id and a.category_id=d.category_id and a.emp_code=" & CODE & " and b.status_id=1 and  a.status_id not in (1,2,3) order by a.leave_frdate").Tables(0)
                End If

                Me.hid1.Value = DT.Rows.Count
                If DT.Rows.Count > 0 Then
                    Dim dr As DataRow
                    For Each dr In DT.Rows
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
                        str_tkn.Append(Me.hid1.Value)
                        str_tkn.Append("!")
                        str_tkn.Append(dr(6))
                        str_tkn.Append("!")
                        str_tkn.Append("")
                        str_tkn.Append("!")
                        str_tkn.Append("")
                        str_tkn.Append("~")
                    Next
                    str_tkn.Append("@")
                    str_tkn.Append("2")
                End If
                cbResult = str_tkn.ToString
        End Select
    End Sub
End Class

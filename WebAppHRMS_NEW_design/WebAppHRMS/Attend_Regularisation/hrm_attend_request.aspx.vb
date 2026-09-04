Imports System.Data
Imports System.Data.OracleClient
Partial Class Attend_Regularisation_hrm_attend_request_3bce0db25678
    Inherits System.Web.UI.Page
    Dim dt, dt1 As New DataTable
    Dim AllPunch, LatePunch As Integer
    Dim Usr(), UsrAll, ToDate As String
    Dim UsrCode, UsrValid, AlrCnt As Integer
    Dim oh As New Helper.Oracle.OracleHelper
    Dim cl_script0, cl_script1 As New System.Text.StringBuilder
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim client_name As String
        client_name = "var master_no;" & "master_no='" & "" & Me.txt_Reason.ClientID & "'" & ";"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", client_name, True)
        '//-=-=-=-=  Modification on 050610 by code review.. if any mistake found please change....!!  =-==-=-====-=//
        Me.UsrAll = Me.Session("user_id")
        Me.Usr = Me.UsrAll.Split("!")
        Me.UsrCode = Me.Usr(0)
        If Not IsPostBack Then
            Me.UsrValid = oh.ExecuteDataSet("select count(*) from employee_master where emp_code = " & Me.UsrCode & " and status_id = 1 and (post_id in (1,10,198,15,6,11,2,251,252,3,4,5,7,8,9,11,12,13,14,15,16,17,18,234,264,235,319,45,261,262,271,308,406,248) or department_id in (598,594,591)) and branch_id = " & Me.Session("branch_id")).Tables(0).Rows(0)(0)
            If Me.UsrValid = 0 Then
                cl_script0.Append(" alert('You may have No Authority....BH/BM or ABH have Authority..!! ');")
                cl_script0.Append("    window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script0.ToString, True)
                Exit Sub
            End If
            Me.AlrCnt = oh.ExecuteDataSet("select count(*) from  hrm_attendance_regularisation t where to_date(t.requested_dt) = to_date(sysdate) and t.status_id in (0,1,4,5) and t.branch_id = " & Me.Session("branch_id")).Tables(0).Rows(0)(0)
            If Me.AlrCnt > 0 Then
                cl_script0.Append("         alert('Already Requested...!!!!');")
                cl_script0.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                Exit Sub
            End If
            Me.AllPunch = oh.ExecuteDataSet("select count(*) from employee_master em,daily_attend da where em.emp_code = da.emp_code and em.DEPARTMENT_ID not in (4,178,188,211,330) and em.status_id = 1 and em.post_id <> 182 and da.m_branch = " & Me.Session("branch_id") & " and da.m_time is not null and da.m_time not in ('REG','COMPEN','JOIN','TOUR')").Tables(0).Rows(0)(0)
            Me.LatePunch = oh.ExecuteDataSet("select count(*) from employee_master em,daily_attend da,time_tab bt where em.emp_code = da.emp_code and em.DEPARTMENT_ID not in (4,178,188,211,330) and da.m_shift = bt.shift_id and em.status_id = 1 and em.post_id <> 182 and da.m_branch = " & Me.Session("branch_id") & " and da.m_time > bt.in_time and da.m_time not in ('REG','COMPEN','JOIN','TOUR')").Tables(0).Rows(0)(0)
            If Me.AllPunch <> Me.LatePunch Then
                cl_script0.Append("         alert('All Employees Are Not Late!!!!');")
                cl_script0.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
            ElseIf AllPunch = 0 Then
                cl_script0.Append("         alert('Enter Through Non Marking Module!!!!');")
                cl_script0.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
            End If
            ToDate = oh.ExecuteDataSet("select to_char(sysdate,'dd/Mon/yyyy') from dual").Tables(0).Rows(0)(0)
            Me.txt_Date.Text = ToDate
        End If
        '///// end of modiication -==-=-= old Below//        
    End Sub
    Protected Sub btn_Confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Confirm.Click
        Dim User() As String
        User = Session("user_id").ToString.Split("!")
        dt = oh.ExecuteDataSet("select count(c.problem_id) from complaint_registered c where to_date(c.tra_dt)=to_date(sysdate) and c.complaint_id=23 and c.problem_id=" & Me.txt_Complaint.Text & "").Tables(0)
        If dt.Rows(0)(0) >= 1 Then
            Dim p(4) As OracleParameter

            p(0) = New OracleParameter("brid", OracleType.Number, 4)
            p(0).Value = Session("branch_id")

            p(1) = New OracleParameter("userId", OracleType.Number, 5)
            p(1).Value = User(0)

            p(2) = New OracleParameter("reason", OracleType.VarChar, 150)
            p(2).Value = Me.txt_Reason.Text

            p(3) = New OracleParameter("complaint", OracleType.VarChar, 12)
            p(3).Value = Me.txt_Complaint.Text

            p(4) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
            p(4).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("hrm_attend_request", p)
            cl_script1.Append("         alert('" + p(4).Value + "');")
            cl_script1.Append("         window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Else
            cl_script1.Append("         alert('Please Contact HO and Register The Complaint!!!');")
            cl_script1.Append("         window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        End If
    End Sub
    ''CType(Me.Master, WebAppHRMS.edp).Subtitle = "ATTENDANCE REGULARISATION REQUEST FORM"
    'Dim User() As String
    'User = Session("user_id").ToString.Split("!")
    ''*************************
    'dt = oh.ExecuteDataSet("select d.m_branch, d.curr_date from daily_attend d where (to_date(d.curr_date), d.emp_code) in (select to_date(curr_date), da.emp_code from ATTENDANCE da, time_tab tt where(da.EMP_CODE > 10000) and da.shift_id = tt.shift_id and da.shift_id = tt.shift_id And da.m_time > tt.in_time and da.BRANCH_ID = 0 and da.M_BRANCH = 0 union all select to_date(curr_date), da.emp_code from ATTENDANCE da, branch_time bt1 where(to_date(da.curr_date) = to_date(sysdate)) and da.EMP_CODE > 10000 and bt1.branch_id = da.M_BRANCH And da.m_time > bt1.in_time and da.BRANCH_ID = 0 and da.M_BRANCH <> 0 union all select to_date(curr_date), da.emp_code from ATTENDANCE da,branch_time bt1 where da.EMP_CODE > 10000 and bt1.branch_id = da.M_BRANCH And da.m_time > bt1.in_time and da.BRANCH_ID <> 0) having count(d.m_branch) =(select count(t.m_branch) from daily_attend t where(t.m_branch = d.m_branch) and to_date(t.curr_date) = to_date(sysdate) and t.shift_id not in (4, 5) and t.m_time is not null and d.m_branch=" & Session("branch_id") & ")group by d.m_branch, d.curr_date").Tables(0)
    'If dt.Rows.Count <= 0 Then
    '    Dim cl_script0 As New System.Text.StringBuilder
    '    cl_script0.Append("         alert('All Employees Are Not Late!!!!');")
    '    cl_script0.Append("window.open('../home.aspx','_self');")
    '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
    'End If
    ''*************************
    'dt = oh.ExecuteDataSet("select a.emp_code from employee_master a where a.emp_code=" & User(0) & " and a.branch_id=" & Session("branch_id") & " and a.post_id in (10,198,1,2,3,4,5,6,7,8,9) and a.status_id=1").Tables(0)
    'If dt.Rows.Count <= 0 Then
    '    cl_script0.Append("         alert('You Are Not Authorised !!!!');")
    '    cl_script0.Append("window.open('../home.aspx','_self');")
    '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
    'End If
    'dt1 = oh.ExecuteDataSet("select t.branch_id from  hrm_attendance_regularisation t where to_date(t.requested_dt)=to_date(sysdate) and t.status_id in (0,1,4,5) and t.branch_id=" & Session("branch_id") & "").Tables(0)
    'If dt1.Rows.Count > 0 Then
    '    cl_script0.Append("         alert('Already Requested...!!!!');")
    '    cl_script0.Append("window.open('../home.aspx','_self');")
    '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
    'End If
End Class

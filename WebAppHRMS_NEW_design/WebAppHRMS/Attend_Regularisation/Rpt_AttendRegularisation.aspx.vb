Imports System.Data
Imports System.Data.OracleClient
Partial Class Attend_Regularisation_Rpt_AttendRegularisation_0e075ee94596
    Inherits System.Web.UI.Page
    Dim dt, dt1, dt2, dt3, dt4, dt5, dt6 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim RH As New WholeHelper.ClsRepCtrl
    Dim tb As New Table
    Dim dr As DataRow
    Dim BrID As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BrID = Session("branch_id")
        If BrID <> 0 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('Pls Login in Head Office!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        End If
        'Dim User() As String = Session("user_id").ToString.Split("!")
        'Dim UserId As Integer = User(0)
        'dt1 = oh.ExecuteDataSet("select count(*)from employee_master a where a.e0mp_code=" & User(0) & " and a.access_id=33 and a.status_id=1").Tables(0)
        'If dt1.Rows(0)(0) = 0 Then
        '    Dim cl_script0 As New System.Text.StringBuilder
        '    cl_script0.Append("         alert('You Are Not Authorised!');")
        '    cl_script0.Append("window.open('../home.aspx','_self');")
        '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        'End If
        dt = oh.ExecuteDataSet("select branch_name from branch_master where branch_id=" & BrID & "").Tables(0)
        RH.Heading(Session("branch_id"), Session("branch_name"), Session("firm_name"), tb, "ATTENDANCE REGULARISATION PENDING DETAILED LIST", 77)
        Dim tr07 As New TableRow
        tr07.BackColor = Drawing.Color.PapayaWhip
        tr07.ForeColor = Drawing.Color.Maroon
        Dim tr07_01, tr07_02, tr07_03, tr07_04, tr07_05, tr07_06, tr07_07, tr07_08, tr07_09, tr07_10, tr07_11, tr07_12, tr07_13, tr07_14, tr07_15, tr07_16, tr07_17, tr07_18, tr07_19 As New TableCell
        RH.AddColumn(tr07, tr07_01, 1, 1, "c", "SLNO")
        RH.AddColumn(tr07, tr07_02, 5, 10, "l", "ZONE&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_03, 5, 10, "l", "REGION&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_04, 5, 10, "l", "AREA&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_05, 5, 10, "l", "BRANCH&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_06, 2, 10, "l", "EMP&nbsp;ID")
        RH.AddColumn(tr07, tr07_07, 5, 10, "l", "EMP&nbsp;NAME&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_08, 5, 10, "l", "REQUESTED&nbsp;BY&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_09, 3, 10, "l", "REQUESTED&nbsp;DATE")
        RH.AddColumn(tr07, tr07_10, 5, 10, "l", "REQUESTED&nbsp;REASON&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")

        RH.AddColumn(tr07, tr07_11, 5, 10, "l", "RECOMMENDED&nbsp;AM&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_12, 3, 10, "l", "RECOMMENDED&nbsp;DATE")
        RH.AddColumn(tr07, tr07_13, 5, 10, "l", "AM&nbsp;RECOM&nbsp;REASON&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")

        RH.AddColumn(tr07, tr07_14, 5, 10, "l", "RECOMMENDED&nbsp;HW&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_15, 3, 10, "l", "HW&nbsp;RECOMMENDED_DT")
        RH.AddColumn(tr07, tr07_16, 5, 10, "l", "HW&nbsp;RECOM&nbsp;REASON&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")

        RH.AddColumn(tr07, tr07_17, 5, 10, "l", "APPROVED&nbsp;BY&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_18, 3, 10, "l", "APPROVED&nbsp;DT")
        RH.AddColumn(tr07, tr07_19, 2, 10, "l", "STATUS&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        tb.Controls.Add(tr07)
        RH.DrawLine(tb, 77)
        dt = oh.ExecuteDataSet("select d.m_branch,d.curr_date from daily_attend d where (to_date(d.curr_date), d.emp_code) in (select to_date(curr_date), da.emp_code from ATTENDANCE da, time_tab tt where(da.EMP_CODE > 10000) and da.shift_id = tt.shift_id and da.shift_id = tt.shift_id And da.m_time > tt.in_time and da.BRANCH_ID = 0 and da.M_BRANCH = 0 union all select to_date(curr_date), da.emp_code from ATTENDANCE da, branch_time bt1 where(to_date(da.curr_date) = to_date(sysdate)) and da.EMP_CODE > 10000 and bt1.branch_id = da.M_BRANCH And da.m_time > bt1.in_time and da.BRANCH_ID = 0 and da.M_BRANCH <> 0 union all select to_date(curr_date), da.emp_code from ATTENDANCE da,branch_time bt1 where da.EMP_CODE > 10000 and bt1.branch_id = da.M_BRANCH And da.m_time > bt1.in_time and da.BRANCH_ID <> 0) having count(d.m_branch) =(select count(t.m_branch) from daily_attend t where(t.m_branch = d.m_branch) and to_date(t.curr_date) = to_date(sysdate) and t.shift_id not in (4, 5) and t.m_time is not null) and d.m_branch not in(select branch_id from hrm_attendance_regularisation where to_date(requested_dt)=to_date(sysdate))group by d.m_branch, d.curr_date").Tables(0)
        dt2 = oh.ExecuteDataSet("select b.ZONE,b.REGION,b.AREA,b.BRANCH,c.emp_code,c.emp_name,a.requested_by,to_date(a.requested_dt),a.requested_reason,a.recommended_by,to_date(a.recommended_dt),a.am_recom_reason,a.hw_recommended_by,to_date(a.hr_recommended_dt),a.hw_recom_reason,a.approved_by,to_date(a.approved_dt),a.status_id from hrm_attendance_regularisation a,view_branch b,employee_master c where c.branch_id=b.BRANCH_ID and a.branch_id=c.branch_id and c.status_id=1 and to_date(a.requested_dt)=to_date(sysdate) and c.emp_code>10000  order by b.zone,b.region,b.area,b.BRANCH ").Tables(0)
        Dim slno As Integer = 0
        Dim RowBG As Integer = 0
        For Each dr In dt.Rows
            Dim tr09 As New TableRow
            Dim tr09_01, tr09_02, tr09_03, tr09_04, tr09_05, tr09_06, tr09_07, tr09_08, tr09_09, tr09_10, tr09_11, tr09_12, tr09_13, tr09_14, tr09_15, tr09_16, tr09_17, tr09_18, tr09_19 As New TableCell
            slno = slno + 1
            dt1 = oh.ExecuteDataSet("select b.ZONE,b.REGION,b.AREA,b.BRANCH,'-','-','-','-','-','-','-','-','-','-','-','-','-','9'from view_branch b, employee_master c where(c.branch_id = b.BRANCH_ID) and c.status_id = 1 and c.emp_code > 10000 and b.branch_id = " & dr(0) & " order by b.zone,b.region,b.area,b.BRANCH").Tables(0)
            dt3 = oh.ExecuteDataSet("select ' ',nvl(a.emp_code||'-'||a.emp_name,'NIL')  from employee_master a where a.branch_id=" & dr(0) & " and a.post_id in (10,198) and a.status_id=1").Tables(0)
            dt4 = oh.ExecuteDataSet("select ' ',nvl(a.emp_code||'-'||a.emp_name,'NIL')   from employee_master a where a.branch_id=" & dr(0) & " and a.post_id in (10,198) and a.status_id=1").Tables(0)
            dt5 = oh.ExecuteDataSet("select ' ',nvl(a.emp_code||'-'||a.emp_name,'NIL')   from employee_master a where a.branch_id=" & dr(0) & " and a.post_id in (10,198) and a.status_id=1").Tables(0)
            dt6 = oh.ExecuteDataSet("select ' ',nvl(a.emp_code||'-'||a.emp_name,'NIL')  from employee_master a where a.branch_id=" & dr(0) & " and a.post_id in (10,198) and a.status_id=1").Tables(0)
            If RowBG = 0 Then
                tr09.BackColor = Drawing.Color.AliceBlue
                RowBG = 1
            Else
                tr09.BackColor = Drawing.Color.Snow
                RowBG = 0
            End If
            RH.AddColumn(tr09, tr09_01, 1, 1, "c", slno)
            RH.AddColumn(tr09, tr09_02, 5, 10, "l", dt1.Rows(0)(0))
            RH.AddColumn(tr09, tr09_03, 5, 10, "l", dt1.Rows(0)(1))
            RH.AddColumn(tr09, tr09_04, 5, 10, "l", dt1.Rows(0)(2))
            RH.AddColumn(tr09, tr09_05, 5, 10, "l", dt1.Rows(0)(3))
            RH.AddColumn(tr09, tr09_06, 2, 10, "l", "-")
            RH.AddColumn(tr09, tr09_07, 5, 10, "l", "-")
            RH.AddColumn(tr09, tr09_08, 5, 10, "l", "-")

            RH.AddColumn(tr09, tr09_09, 3, 2, "l", "-")
            RH.AddColumn(tr09, tr09_10, 5, 10, "l", "-")
            RH.AddColumn(tr09, tr09_11, 5, 10, "l", "-")
            RH.AddColumn(tr09, tr09_12, 3, 10, "l", "-")
            RH.AddColumn(tr09, tr09_13, 5, 10, "l", "-")
            RH.AddColumn(tr09, tr09_14, 5, 10, "l", "-")
            RH.AddColumn(tr09, tr09_15, 3, 10, "l", "-")

            RH.AddColumn(tr09, tr09_16, 5, 2, "l", "-")
            RH.AddColumn(tr09, tr09_17, 5, 10, "l", "-")
            RH.AddColumn(tr09, tr09_18, 3, 10, "l", "-")
            RH.AddColumn(tr09, tr09_19, 2, 10, "l", "-")
            'If dt1.Rows(0)(17) = " " Then
            '    Dim xx As String = " "
            '    RH.AddColumn(tr09, tr09_19, 2, 10, "l", xx)
            'End If
            tb.Controls.Add(tr09)
        Next
        Dim tr03 As New TableRow
        Dim tr03_01 As New TableCell
        tr03.BackColor = Drawing.Color.Blue
        tr03.ForeColor = Drawing.Color.White
        RH.AddColumn(tr03, tr03_01, 77, 10, "c", "<b>ATTENDANCE REGULARISED BRANCH DETAILS")
        tb.Controls.Add(tr03)


        For Each dr In dt2.Rows
            Dim tr09 As New TableRow
            Dim tr09_01, tr09_02, tr09_03, tr09_04, tr09_05, tr09_06, tr09_07, tr09_08, tr09_09, tr09_10, tr09_11, tr09_12, tr09_13, tr09_14, tr09_15, tr09_16, tr09_17, tr09_18, tr09_19 As New TableCell
            slno = slno + 1
            dt3 = oh.ExecuteDataSet("select nvl(a.emp_code||'-'||a.emp_name,'NIL')  from employee_master a where a.emp_code=" & dr(6) & "").Tables(0)
            dt4 = oh.ExecuteDataSet("select nvl(a.emp_code||'-'||a.emp_name,'NIL')   from employee_master a where a.emp_code=" & dr(9) & "").Tables(0)
            dt5 = oh.ExecuteDataSet("select nvl(a.emp_code||'-'||a.emp_name,'NIL')   from employee_master a where a.emp_code=" & dr(12) & "").Tables(0)
            dt6 = oh.ExecuteDataSet("select nvl(a.emp_code||'-'||a.emp_name,'NIL')  from employee_master a where a.emp_code=" & dr(15) & "").Tables(0)
            If RowBG = 0 Then
                tr09.BackColor = Drawing.Color.AliceBlue
                RowBG = 1
            Else
                tr09.BackColor = Drawing.Color.Snow
                RowBG = 0
            End If
            RH.AddColumn(tr09, tr09_01, 1, 1, "c", slno)
            RH.AddColumn(tr09, tr09_02, 5, 10, "l", dr(0))
            RH.AddColumn(tr09, tr09_03, 5, 10, "l", dr(1))
            RH.AddColumn(tr09, tr09_04, 5, 10, "l", dr(2))
            RH.AddColumn(tr09, tr09_05, 5, 10, "l", dr(3))
            RH.AddColumn(tr09, tr09_06, 2, 10, "l", dr(4))
            RH.AddColumn(tr09, tr09_07, 5, 10, "l", dr(5))
            RH.AddColumn(tr09, tr09_08, 5, 10, "l", dt3.Rows(0)(0))

            RH.AddColumn(tr09, tr09_09, 3, 2, "l", dr(7))
            RH.AddColumn(tr09, tr09_10, 5, 10, "l", dr(8))
            RH.AddColumn(tr09, tr09_11, 5, 10, "l", dt4.Rows(0)(0))
            RH.AddColumn(tr09, tr09_12, 3, 10, "l", dr(10))
            RH.AddColumn(tr09, tr09_13, 5, 10, "l", dr(11))
            RH.AddColumn(tr09, tr09_14, 5, 10, "l", dt5.Rows(0)(0))
            RH.AddColumn(tr09, tr09_15, 3, 10, "l", dr(13))

            RH.AddColumn(tr09, tr09_16, 5, 2, "l", dr(14))
            RH.AddColumn(tr09, tr09_17, 5, 10, "l", dt6.Rows(0)(0))
            RH.AddColumn(tr09, tr09_18, 3, 10, "l", dr(16))
            If dt1.Rows(0)(17) = 0 Then
                Dim xx As String = "APPLIED"
                RH.AddColumn(tr09, tr09_19, 2, 10, "l", xx)
            End If
            If dt1.Rows(0)(17) = 4 Then
                Dim xx As String = "AM RECOMMEND"
                RH.AddColumn(tr09, tr09_19, 2, 10, "l", xx)
            End If
            If dt1.Rows(0)(17) = 3 Then
                Dim xx As String = "AM REJECT"
                RH.AddColumn(tr09, tr09_19, 2, 10, "l", xx)
            End If

            If dt1.Rows(0)(17) = 5 Then
                Dim xx As String = "HW-AGM RECOMMEND"
                RH.AddColumn(tr09, tr09_19, 2, 10, "l", xx)
            End If
            If dt1.Rows(0)(17) = 6 Then
                Dim xx As String = "HW-AGM REJECT"
                RH.AddColumn(tr09, tr09_19, 2, 10, "l", xx)
            End If

            If dt1.Rows(0)(17) = 1 Then
                Dim xx As String = "JGM APPROVED"
                RH.AddColumn(tr09, tr09_19, 2, 10, "l", xx)
            End If

            If dt1.Rows(0)(17) = 2 Then
                Dim xx As String = "JGM REJECT"
                RH.AddColumn(tr09, tr09_19, 2, 10, "l", xx)
            End If
            tb.Controls.Add(tr09)
        Next
        Panel1.Controls.Add(tb)
    End Sub
End Class

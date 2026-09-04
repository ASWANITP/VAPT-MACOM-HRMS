Imports System.Data
Imports System.Data.OracleClient
Partial Class AnyTimePunching_New_Reports_hrm_Rpt_Attend_Exception1_900268313271
    Inherits System.Web.UI.Page
    Dim RH As New WholeHelper.ClsRepCtrl
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2, dt3 As New DataTable
    Dim tb As New Table
    Dim BrID As Integer
    Dim BranchName As String
    Dim dr, dr1 As DataRow
    Dim tot_count As Double
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim UserId As Integer = User(0)
        Dim fromdate As String = (Request.QueryString.Get("fromdt"))
        Dim todate As String = (Request.QueryString.Get("todt"))
        Dim Status As String = (Request.QueryString.Get("Status"))
        Dim Count As String = (Request.QueryString.Get("Count"))
        Dim BrId As Integer = Session("branch_id")
        dt = oh.ExecuteDataSet("select branch_name from branch_master where branch_id=" & BrId & "").Tables(0)
        BranchName = dt.Rows(0)(0)
        If Status = 1 Then
            RH.Heading(Session("branch_id"), Session("branch_name"), Session("firm_name"), tb, "ALL STAFF ATTENDANCE REGULARISATION EXCEPTION REPORT OF " & BranchName & "" & vbNewLine & " FROM " & fromdate & " TO " & todate & " " & vbNewLine & "", 20)
            Dim tr07 As New TableRow
            tr07.ForeColor = Drawing.Color.Maroon
            Dim tr07_01, tr07_02, tr07_03, tr07_04, tr07_05 As New TableCell
            RH.AddColumn(tr07, tr07_01, 1, 10, "l", "<b>BRANCH&nbsp;ID&nbsp;")
            RH.AddColumn(tr07, tr07_02, 5, 10, "l", "<b>BRANCH&nbsp;NAME&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
            RH.AddColumn(tr07, tr07_03, 5, 10, "l", "<b>REQUESTED&nbsp;BY&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
            RH.AddColumn(tr07, tr07_04, 3, 10, "c", "<b>REQUESTED&nbsp;DATE&nbsp;&nbsp;")
            RH.AddColumn(tr07, tr07_05, 8, 10, "l", "<b>REQUESTED&nbsp;REASON&nbsp;")
            tb.Controls.Add(tr07)
            RH.DrawLine(tb, 20)
            dt = oh.ExecuteDataSet("select h.branch_id,count(h.branch_id) from hrm_attendance_regularisation h  where to_date(h.requested_dt) >='" & fromdate & "'  and to_date(h.requested_dt) <= '" & todate & "' having count(h.branch_id)>" & Count & "  group by h.branch_id").Tables(0)
            Dim RowBG As Integer = 0
            Dim ItemTotal As Integer = 0
            tot_count = 0
            Dim Total As Double = 0
            For Each dr In dt.Rows
                dt1 = oh.ExecuteDataSet("select h.branch_id,b.BRANCH_NAME,h.requested_by ||'-'||e.emp_name,to_char(to_date(h.requested_dt)),h.requested_reason from hrm_attendance_regularisation h,branch_dtl_new b,employee_master e where h.branch_id=b.BRANCH_ID and h.requested_by=e.emp_code and to_date(h.requested_dt)>='" & fromdate & "' and to_date(h.requested_dt)<='" & todate & "' and h.branch_id=" & dr(0) & " order by h.branch_id ").Tables(0)
                For Each dr1 In dt1.Rows
                    Dim tr09 As New TableRow
                    Dim tr09_01, tr09_02, tr09_03, tr09_04, tr09_05 As New TableCell
                    If RowBG = 0 Then
                        tr09.BackColor = Drawing.Color.AliceBlue
                        RowBG = 1
                    Else
                        tr09.BackColor = Drawing.Color.MistyRose
                        RowBG = 0
                    End If
                    RH.AddColumn(tr09, tr09_01, 1, 10, "l", dr1(0))
                    RH.AddColumn(tr09, tr09_02, 5, 10, "l", dr1(1))
                    RH.AddColumn(tr09, tr09_03, 5, 10, "l", dr1(2))
                    RH.AddColumn(tr09, tr09_04, 3, 10, "c", dr1(3))
                    RH.AddColumn(tr09, tr09_05, 8, 10, "l", dr1(4))
                    tb.Controls.Add(tr09)
                    tot_count += 1
                Next
            Next
        End If

        If Status = 2 Then
            RH.Heading(Session("branch_id"), Session("branch_name"), Session("firm_name"), tb, "INDIVIDUAL ATTENDANCE REGULARISATION EXCEPTION REPORT (EMPCODE WISE)OF " & BranchName & "" & vbNewLine & " FROM " & fromdate & " TO " & todate & " " & vbNewLine & "", 20)
            Dim tr07 As New TableRow
            tr07.ForeColor = Drawing.Color.Maroon
            Dim tr07_01, tr07_02, tr07_03, tr07_04, tr07_05 As New TableCell
            RH.AddColumn(tr07, tr07_01, 1, 10, "l", "<b>BRANCH&nbsp;ID&nbsp;")
            RH.AddColumn(tr07, tr07_02, 5, 10, "l", "<b>BRANCH&nbsp;NAME&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
            RH.AddColumn(tr07, tr07_03, 5, 10, "l", "<b>REQUESTED&nbsp;BY&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
            RH.AddColumn(tr07, tr07_04, 3, 10, "c", "<b>REQUESTED&nbsp;DATE&nbsp;&nbsp;")
            RH.AddColumn(tr07, tr07_05, 8, 10, "l", "<b>REQUESTED&nbsp;REASON&nbsp;")
            tb.Controls.Add(tr07)
            RH.DrawLine(tb, 20)
            dt = oh.ExecuteDataSet("select h.requested_by,count(h.requested_by) from hrm_anytimepunching_reg h  where to_date(h.requested_dt) >='" & fromdate & "'  and to_date(h.requested_dt) <= '" & todate & "' having count(h.requested_by)>" & Count & "  group by h.requested_by").Tables(0)
            Dim RowBG As Integer = 0
            Dim ItemTotal As Integer = 0
            tot_count = 0
            Dim Total As Double = 0
            For Each dr In dt.Rows
                dt1 = oh.ExecuteDataSet("select h.branch_id,b.BRANCH_NAME,h.requested_by ||'-'||e.emp_name,to_char(to_date(h.requested_dt)),h.remarks from hrm_anytimepunching_reg h,branch_dtl_new b,employee_master e where h.branch_id=b.BRANCH_ID and h.requested_by=e.emp_code and to_date(h.requested_dt)>='" & fromdate & "' and to_date(h.requested_dt)<='" & todate & "' and h.requested_by=" & dr(0) & " order by h.branch_id ").Tables(0)
                For Each dr1 In dt1.Rows
                    Dim tr09 As New TableRow
                    Dim tr09_01, tr09_02, tr09_03, tr09_04, tr09_05 As New TableCell
                    If RowBG = 0 Then
                        tr09.BackColor = Drawing.Color.AliceBlue
                        RowBG = 1
                    Else
                        tr09.BackColor = Drawing.Color.MistyRose
                        RowBG = 0
                    End If
                    RH.AddColumn(tr09, tr09_01, 1, 10, "l", dr1(0))
                    RH.AddColumn(tr09, tr09_02, 5, 10, "l", dr1(1))
                    RH.AddColumn(tr09, tr09_03, 5, 10, "l", dr1(2))
                    RH.AddColumn(tr09, tr09_04, 3, 10, "c", dr1(3))
                    RH.AddColumn(tr09, tr09_05, 8, 10, "l", dr1(4))
                    tb.Controls.Add(tr09)
                    tot_count += 1
                Next
            Next
        End If
        If Status = 3 Then
            RH.Heading(Session("branch_id"), Session("branch_name"), Session("firm_name"), tb, "INDIVIDUAL ATTENDANCE REGULARISATION EXCEPTION REPORT (EMPCODE WISE)OF " & BranchName & "" & vbNewLine & " FROM " & fromdate & " TO " & todate & " " & vbNewLine & "", 20)
            Dim tr07 As New TableRow
            tr07.ForeColor = Drawing.Color.Maroon
            Dim tr07_01, tr07_02, tr07_03, tr07_04, tr07_05 As New TableCell
            RH.AddColumn(tr07, tr07_01, 1, 10, "l", "<b>BRANCH&nbsp;ID&nbsp;")
            RH.AddColumn(tr07, tr07_02, 5, 10, "l", "<b>BRANCH&nbsp;NAME&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
            RH.AddColumn(tr07, tr07_03, 5, 10, "l", "<b>REQUESTED&nbsp;BY&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
            RH.AddColumn(tr07, tr07_04, 3, 10, "c", "<b>REQUESTED&nbsp;DATE&nbsp;&nbsp;")
            RH.AddColumn(tr07, tr07_05, 8, 10, "l", "<b>REQUESTED&nbsp;REASON&nbsp;")
            tb.Controls.Add(tr07)
            RH.DrawLine(tb, 20)
            dt = oh.ExecuteDataSet("select h.branch_id,count(h.branch_id) from hrm_anytimepunching_reg h  where to_date(h.requested_dt) >='" & fromdate & "'  and to_date(h.requested_dt) <= '" & todate & "' having count(h.branch_id)>" & Count & "  group by h.branch_id").Tables(0)
            Dim RowBG As Integer = 0
            Dim ItemTotal As Integer = 0
            tot_count = 0
            Dim Total As Double = 0
            For Each dr In dt.Rows
                dt1 = oh.ExecuteDataSet("select h.branch_id,b.BRANCH_NAME,h.requested_by ||'-'||e.emp_name,to_char(to_date(h.requested_dt)),h.remarks from hrm_anytimepunching_reg h,branch_dtl_new b,employee_master e where h.branch_id=b.BRANCH_ID and h.requested_by=e.emp_code and to_date(h.requested_dt)>='" & fromdate & "' and to_date(h.requested_dt)<='" & todate & "' and h.branch_id=" & dr(0) & " order by h.branch_id ").Tables(0)
                For Each dr1 In dt1.Rows
                    Dim tr09 As New TableRow
                    Dim tr09_01, tr09_02, tr09_03, tr09_04, tr09_05 As New TableCell
                    If RowBG = 0 Then
                        tr09.BackColor = Drawing.Color.AliceBlue
                        RowBG = 1
                    Else
                        tr09.BackColor = Drawing.Color.MistyRose
                        RowBG = 0
                    End If
                    RH.AddColumn(tr09, tr09_01, 1, 10, "l", dr1(0))
                    RH.AddColumn(tr09, tr09_02, 5, 10, "l", dr1(1))
                    RH.AddColumn(tr09, tr09_03, 5, 10, "l", dr1(2))
                    RH.AddColumn(tr09, tr09_04, 3, 10, "c", dr1(3))
                    RH.AddColumn(tr09, tr09_05, 8, 10, "l", dr1(4))
                    tb.Controls.Add(tr09)
                    tot_count += 1
                Next
            Next
        End If
        RH.DrawLine(tb, 20)
        Dim tr10 As New TableRow
        Dim tr10_01, tr10_02, tr10_03 As New TableCell
        tr10.BackColor = Drawing.Color.AliceBlue
        RH.AddColumn(tr10, tr10_01, 10, 5, "l", "TOTAL :&nbsp;&nbsp;&nbsp;&nbsp;" & "<b>" & tot_count)
        RH.AddColumn(tr10, tr10_03, 10, 5, "r", "")
        tb.Controls.Add(tr10)
        RH.DrawLine(tb, 20)
        Panel1.Controls.Add(tb)
    End Sub
End Class

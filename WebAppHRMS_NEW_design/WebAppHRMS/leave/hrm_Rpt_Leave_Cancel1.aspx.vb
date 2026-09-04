Imports System.Data
Imports System.Data.OracleClient
Partial Class new_leave_hrm_Rpt_Leave_Cancel1_f5f4e9b03679
    Inherits System.Web.UI.Page
    Dim RH As New WholeHelper.ClsRepCtrl
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2 As New DataTable
    Dim tb As New Table
    Dim BranchName As String
    Dim dr As DataRow
    Dim tot_count As Double
    Dim fir As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim fromdate As String = (Request.QueryString.Get("fromdt"))
        Dim todate As String = (Request.QueryString.Get("todt"))
        Dim BrId As Integer = Session("branch_id")
        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim UserIdd As Integer = User(0)
        fir = Session("firm_id")
        dt = oh.ExecuteDataSet("select branch_name from branch_master where branch_id=" & BrId & "").Tables(0)
        BranchName = dt.Rows(0)(0)
        RH.Heading(Session("branch_id"), Session("branch_name"), Session("firm_name"), tb, "LEAVE CANCELLATION REPORT" & vbNewLine & " FROM " & fromdate & " TO " & todate & " " & vbNewLine & "", 30)

        Dim id As Integer
        id = 186
        dt1 = oh.ExecuteDataSet("select count(*) from form_accessibility where form_id=" & id & " and emp_id=" & User(0) & "").Tables(0)
        ' dt1 = oh.ExecuteDataSet("select a.emp_code from employee_master a where a.emp_code=" & UserIdd & " and a.status_id=1 and a.access_id=33").Tables(0)
        If dt1.Rows(0)(0) <= 0 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('You Are Not Authorised !!!!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        End If
        Dim tr07 As New TableRow
        tr07.ForeColor = Drawing.Color.Maroon
        Dim tr07_01, tr07_02, tr07_03, tr07_04, tr07_05, tr07_06, tr07_07, tr07_08, tr07_09, tr07_10 As New TableCell
        RH.AddColumn(tr07, tr07_01, 2, 10, "l", "<b>EMP&nbsp;CODE")
        RH.AddColumn(tr07, tr07_02, 5, 10, "l", "<b>EMP&nbsp;NAME")
        RH.AddColumn(tr07, tr07_03, 2, 10, "l", "<b>LEAVE&nbsp;TYPE&nbsp;")
        RH.AddColumn(tr07, tr07_04, 3, 10, "l", "<b>LEAVE&nbsp;FROM&nbsp;")
        RH.AddColumn(tr07, tr07_05, 3, 10, "l", "<b>LEAVE&nbsp;TO&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_06, 1, 10, "l", "<b>LEAVE&nbsp;DAYS&nbsp;")
        RH.AddColumn(tr07, tr07_07, 5, 10, "l", "<b>LEAVE&nbsp;REASON&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_08, 2, 10, "l", "<b>CANCELLED&nbsp;DATE&nbsp;")
        RH.AddColumn(tr07, tr07_09, 2, 10, "l", "<b>CANCELLED&nbsp;BY&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_10, 7, 10, "l", "<b>CANCELLED&nbsp;REASON&nbsp;")
        tb.Controls.Add(tr07)
        RH.DrawLine(tb, 30)
        'dt = oh.ExecuteDataSet("select distinct (ed.emp_code),e.emp_name,l.leave_abbr,ed.leave_frdate,ed.leave_todate,ed.leave_days,ed.leave_reason,ed.cancel_date as canceldate,ed.cancel_reason,case when substr(ed.cancel_by,6,1) = '!' then substr(ed.cancel_by,1,5) else ed.cancel_by end as Cancel_By from employ_leave_dtl ed,employee_master e,leave_master l where ed.emp_code = e.emp_code and ed.leave_process_id in (0, 3) and ed.leave_id = l.leave_id and to_date(ed.cancel_date) >= to_date('" & fromdate & "') and to_date(ed.cancel_date) <= to_date('" & todate & "') and ed.cancel_date is not null union select distinct (ed.emp_code),e.emp_name,l.leave_abbr,ed.leave_frdate,ed.leave_todate,ed.leave_days,ed.leave_reason,ed.leave_enter_date as canceldate,'NIL',case when substr(ed.entered_by,6,1) = '!' then substr(ed.entered_by,1,5) else ed.entered_by end as Cancel_By from employ_leave_dtl ed,employee_master  e,leave_master l where ed.emp_code = e.emp_code  and ed.leave_process_id in (0, 3) and ed.leave_id = l.leave_id  and to_date(ed.leave_enter_date) >= to_date('" & fromdate & "') and to_date(ed.leave_enter_date) <= to_date('" & todate & "') and ed.cancel_date is null").Tables(0)
        dt = oh.ExecuteDataSet("select distinct (ed.emp_code),  e.emp_name,  l.leave_abbr,  ed.leave_frdate,  ed.leave_todate,  ed.leave_days,  ed.leave_reason,  ed.cancel_date as canceldate,  ed.cancel_reason,  case  when substr(ed.cancel_by, 6, 1) = '!' then  substr(ed.cancel_by, 1, 5)  else  ed.cancel_by  end as Cancel_By  from employ_leave_dtl ed, employee_master e, leave_master l,employ_firm ef  where ed.emp_code = e.emp_code  and ed.leave_process_id in (0, 3)  and ed.leave_id = l.leave_id  and e.emp_code=ef.emp_code  and ef.firm_id=" & fir & " and to_date(ed.cancel_date) >= to_date('" & fromdate & "')  and to_date(ed.cancel_date) <= to_date('" & todate & "')  and ed.cancel_date is not null  union  select distinct (ed.emp_code),  e.emp_name,  l.leave_abbr,  ed.leave_frdate,  ed.leave_todate,  ed.leave_days,  ed.leave_reason,  ed.leave_enter_date as canceldate,  'NIL',  case  when substr(ed.entered_by, 6, 1) = '!' then  substr(ed.entered_by, 1, 5)  else  ed.entered_by  end as Cancel_By  from employ_leave_dtl ed, employee_master e, leave_master l,employ_firm ef  where ed.emp_code = e.emp_code  and ed.leave_process_id in (0, 3)  and ed.leave_id = l.leave_id  and e.emp_code=ef.emp_code  and ef.firm_id=" & fir & "  and to_date(ed.leave_enter_date) >= to_date('" & fromdate & "')  and to_date(ed.leave_enter_date) <= to_date('" & todate & "')  and ed.cancel_date is null").Tables(0)
        If (dt.Rows.Count = 0) Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('No Details To Display..!!!!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
            Exit Sub
        End If
        Dim RowBG As Integer = 0
        tot_count = 0
        Dim Total As Double = 0
        For Each dr In dt.Rows
            Dim tr09 As New TableRow
            Dim tr09_01, tr09_02, tr09_03, tr09_04, tr09_05, tr09_06, tr09_07, tr09_08, tr09_09, tr09_10 As New TableCell
            If RowBG = 0 Then
                tr09.BackColor = Drawing.Color.AliceBlue
                RowBG = 1
            Else
                tr09.BackColor = Drawing.Color.MistyRose
                RowBG = 0
            End If
            RH.AddColumn(tr09, tr09_01, 2, 10, "l", dr(0))
            RH.AddColumn(tr09, tr09_02, 5, 10, "l", dr(1))
            RH.AddColumn(tr09, tr09_03, 2, 10, "c", dr(2))
            RH.AddColumn(tr09, tr09_04, 3, 10, "l", Format(dr(3), "dd-MMM-yyyy"))
            RH.AddColumn(tr09, tr09_05, 3, 10, "l", Format(dr(4), "dd-MMM-yyyy"))
            RH.AddColumn(tr09, tr09_06, 1, 10, "c", dr(5))
            RH.AddColumn(tr09, tr09_07, 5, 10, "l", dr(6))
            RH.AddColumn(tr09, tr09_08, 2, 10, "c", Format(dr(7), "dd-MMM-yyyy"))
            If IsDBNull(dr(9)) Then
                Dim Status = "Nil"
                RH.AddColumn(tr09, tr09_09, 2, 10, "l", Status)
            Else
                If IsNumeric(dr(9)) Then
                    Dim UserId As Integer = dr(9)
                    dt = oh.ExecuteDataSet("select a.emp_code||'-'||a.emp_name from employee_master a where a.emp_code=" & UserId & "").Tables(0)
                    RH.AddColumn(tr09, tr09_09, 2, 10, "l", dt.Rows(0)(0))
                Else
                    Dim Status = dr(9)
                    RH.AddColumn(tr09, tr09_09, 2, 10, "l", Status)
                End If
            End If
            If IsDBNull(dr(8)) Then
                Dim REAS = "Nil"
                RH.AddColumn(tr09, tr09_10, 7, 10, "l", REAS)
            Else
                RH.AddColumn(tr09, tr09_10, 7, 10, "l", dr(8))
            End If
            tb.Controls.Add(tr09)
            tot_count += 1
        Next
        RH.DrawLine(tb, 30)
        Dim tr10 As New TableRow
        Dim tr10_01, tr10_02, tr10_03 As New TableCell
        tr10.BackColor = Drawing.Color.AliceBlue
        RH.AddColumn(tr10, tr10_01, 30, 25, "l", "TOTAL :&nbsp;&nbsp;&nbsp;&nbsp;" & "<b>" & tot_count)
        tb.Controls.Add(tr10)
        RH.DrawLine(tb, 30)
        Panel1.Controls.Add(tb)
    End Sub
End Class

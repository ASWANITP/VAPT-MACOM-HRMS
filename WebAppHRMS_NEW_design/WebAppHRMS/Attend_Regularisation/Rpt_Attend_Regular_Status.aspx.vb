Imports System.Data
Imports System.Data.OracleClient
Partial Class Attend_Regularisation_No_Date_check__Attend_Regularisation_Rpt_Attend_Regular_Status_389c864d1430
    Inherits System.Web.UI.Page
    Dim RH As New WholeHelper.ClsRepCtrl
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt3 As New DataTable
    Dim tb As New Table
    Dim BrID As Integer
    Dim BranchName As String
    Dim dr As DataRow
    Dim tot_count As Double
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim UserId As Integer = User(0)
        Dim fromdate As String = (Request.QueryString.Get("fromdt"))
        Dim todate As String = (Request.QueryString.Get("todt"))
        Dim BrId As Integer = Session("branch_id")
        'dt1 = oh.ExecuteDataSet("select a.emp_code from employee_master a where a.emp_code=" & UserId & " and a.status_id=1 and a.branch_id=" & Session("branch_id") & "").Tables(0)
        'If dt1.Rows.Count <= 0 Then
        '    Dim cl_script0 As New System.Text.StringBuilder
        '    cl_script0.Append("         alert('You Are Not Authorised !!!!');")
        '    cl_script0.Append("window.open('../home.aspx','_self');")
        '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        'End If
        dt = oh.ExecuteDataSet("select branch_name from branch_master where branch_id=" & BrId & "").Tables(0)
        BranchName = dt.Rows(0)(0)
        RH.Heading(Session("branch_id"), Session("branch_name"), Session("firm_name"), tb, "ATTENDANCE REGULARISATION STATUS REPORT OF " & BranchName & "" & vbNewLine & " FROM " & fromdate & " TO " & todate & " " & vbNewLine & "", 33)
        Dim tr07 As New TableRow
        tr07.ForeColor = Drawing.Color.Maroon
        Dim tr07_01, tr07_02, tr07_03, tr07_04, tr07_05, tr07_06, tr07_07, tr07_08, tr07_09, tr07_10 As New TableCell
        RH.AddColumn(tr07, tr07_01, 3, 10, "l", "<b>REQUESTED&nbsp;BY&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_02, 3, 10, "c", "<b>REQUEST&nbsp;DATE&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_03, 5, 10, "l", "<b>REQUESTED&nbsp;REASON&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_04, 3, 10, "l", "<b>AM&nbsp;RECOMMENDED&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_05, 3, 10, "c", "<b>AM&nbsp;RECOMM&nbsp;DATE&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_06, 5, 10, "l", "<b>AM&nbsp;RECOMM&nbsp;REASON&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_07, 3, 10, "l", "<b>JGM&nbsp;APPROVED&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_08, 3, 10, "c", "<b>JGM&nbsp;APPROVED&nbsp;DATE&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_09, 5, 10, "l", "<b>STATUS&nbsp;&nbsp;&nbsp;")
        tb.Controls.Add(tr07)
        RH.DrawLine(tb, 33)
        dt = oh.ExecuteDataSet("select a.requested_by || '-' || e.emp_name,to_char(to_date(a.requested_dt)),a.requested_reason,a.recommended_by,to_char(to_date(a.recommended_dt)),a.am_recom_reason,a.approved_by,to_char(to_date(a.approved_dt)),decode(a.status_id,0,'APPLIED',5,'AM RECOMMENDED',6,'AM REJECTED',1,'REGULARISED',2,'JGM REJECTED') from hrm_attendance_regularisation a,employee_master e where a.requested_by = e.emp_code and to_date(a.requested_dt)>='" & fromdate & "'and to_date(a.requested_dt)<='" & todate & "' and a.branch_id=" & Session("branch_id") & " order by  a.requested_dt").Tables(0)
        If (dt.Rows.Count = 0) Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('No Details To Display..!!!!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
            Exit Sub
        End If
        Dim RowBG As Integer = 0
        Dim ItemTotal As Integer = 0
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
            RH.AddColumn(tr09, tr09_01, 3, 10, "l", dr(0))
            RH.AddColumn(tr09, tr09_02, 3, 10, "c", dr(1))
            RH.AddColumn(tr09, tr09_03, 5, 10, "l", dr(2))
            If Not IsDBNull(dr(3)) Then
                dt3 = oh.ExecuteDataSet("select nvl(a.emp_code||'-'||a.emp_name,'NIL')  from employee_master a where a.emp_code=" & dr(3) & " and a.status_id=1").Tables(0)
                Dim Status = dt3.Rows(0)(0)
                RH.AddColumn(tr09, tr09_04, 3, 10, "l", Status)
            Else
                Dim Status = "-"
                RH.AddColumn(tr09, tr09_04, 3, 10, "l", Status)
            End If
            If Not IsDBNull(dr(4)) Then
                Dim Status = dr(4)
                RH.AddColumn(tr09, tr09_05, 3, 10, "c", Status)
            Else
                Dim Status = "-"
                RH.AddColumn(tr09, tr09_05, 3, 10, "c", Status)
            End If

            If Not IsDBNull(dr(5)) Then
                Dim Status = dr(5)
                RH.AddColumn(tr09, tr09_06, 5, 10, "l", Status)
            Else
                Dim Status = "-"
                RH.AddColumn(tr09, tr09_06, 5, 10, "l", Status)
            End If

            If Not IsDBNull(dr(6)) Then
                dt3 = oh.ExecuteDataSet("select nvl(a.emp_code||'-'||a.emp_name,'NIL')  from employee_master a where a.emp_code=" & dr(6) & " and a.status_id=1").Tables(0)
                Dim Status = dt3.Rows(0)(0)
                RH.AddColumn(tr09, tr09_07, 3, 10, "l", Status)
            Else
                Dim Status = "-"
                RH.AddColumn(tr09, tr09_07, 3, 10, "l", Status)
            End If

            If Not IsDBNull(dr(7)) Then
                Dim Status = dr(7)
                RH.AddColumn(tr09, tr09_08, 3, 10, "c", Status)
            Else
                Dim Status = "-"
                RH.AddColumn(tr09, tr09_08, 3, 10, "c", Status)
            End If
            If Not IsDBNull(dr(8)) Then
                Dim Status = dr(8)
                RH.AddColumn(tr09, tr09_09, 5, 10, "l", Status)
            Else
                Dim Status = "-"
                RH.AddColumn(tr09, tr09_09, 5, 10, "l", Status)
            End If
            tb.Controls.Add(tr09)
            tot_count += 1
        Next
        RH.DrawLine(tb, 33)
        Dim tr10 As New TableRow
        Dim tr10_01, tr10_02, tr10_03 As New TableCell
        tr10.BackColor = Drawing.Color.AliceBlue
        RH.AddColumn(tr10, tr10_01, 14, 5, "l", "TOTAL :&nbsp;&nbsp;&nbsp;&nbsp;" & "<b>" & tot_count)
        'RH.AddColumn(tr10, tr10_02, 2, 5, "r", "<b>" & FormatNumber(ItemTotal))
        RH.AddColumn(tr10, tr10_03, 19, 5, "r", "")
        tb.Controls.Add(tr10)
        RH.DrawLine(tb, 33)
        Panel1.Controls.Add(tb)
    End Sub
End Class

Imports System.Data
Imports System.Data.OracleClient
Partial Class AnyTimePunching_New_hrm_Rpt_Ind_Attend_Status_cc96ff0c1945
    Inherits System.Web.UI.Page
    Dim RH As New WholeHelper.ClsRepCtrl
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2, dt3 As New DataTable
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
        dt = oh.ExecuteDataSet("select branch_name from branch_master where branch_id=" & BrId & "").Tables(0)
        BranchName = dt.Rows(0)(0)
        RH.Heading(Session("branch_id"), Session("branch_name"), Session("firm_name"), tb, "INDIVIDUAL ATTENDANCE REGULARISATION STATUS REPORT OF " & BranchName & "" & vbNewLine & " FROM " & fromdate & " TO " & todate & " " & vbNewLine & "", 19)
        Dim tr07 As New TableRow
        tr07.ForeColor = Drawing.Color.Maroon
        Dim tr07_01, tr07_02, tr07_03, tr07_04, tr07_05, tr07_06, tr07_07, tr07_08, tr07_09, tr07_10 As New TableCell
        RH.AddColumn(tr07, tr07_01, 5, 10, "l", "<b>EMPLOYEE&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_02, 3, 10, "c ", "<b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;REQUEST&nbsp;DATE&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_03, 5, 10, "l", "<b>REQ&nbsp;REASON&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_04, 3, 10, "l", "<b>STATUS&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_05, 3, 10, "l", "<b>ENTERED&nbsp;BY&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        'RH.AddColumn(tr07, tr07_05, 3, 10, "l", "<b>RM&nbsp;RECOMMENDED&nbsp;&nbsp;&nbsp;")
        'RH.AddColumn(tr07, tr07_06, 5, 10, "l", "<b>RH&nbsp;RECOMMENDED&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        'RH.AddColumn(tr07, tr07_07, 3, 10, "l", "<b>JGM&nbsp;RECOMMENDED&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        tb.Controls.Add(tr07)
        RH.DrawLine(tb, 19)

        dt2 = oh.ExecuteDataSet("select a.emp_code from employee_master a where a.emp_code=" & User(0) & " and a.branch_id=" & Session("branch_id") & " and a.status_id=1").Tables(0)
        If dt2.Rows.Count <= 0 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('You Are Not Authorised !!!!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        End If

        dt = oh.ExecuteDataSet("select r.requested_by || '-' || e.emp_name,to_char(to_date(r.requested_dt)),r.remarks,decode(r.status_id,0,'APPLIED',9,'AM&nbsp;RECOMMENDED',8,'RM&nbsp;RECOMMENDED',7,'AM&nbsp;REJECTED',6,'RM&nbsp;REJECTED',2,'RH&nbsp;RECOMMENDED',3,'RH&nbsp;REJECTED',1,'JGM&nbsp;APPROVED', 4,'JGM&nbsp;REJECTED',11,'RECOMMEND',12,'APPROVED'),r.entered_by from hrm_anytimepunching_reg r, employee_master e where r.requested_by = e.emp_code and r.branch_id = " & Session("branch_id") & " and r.not_punch is null order by r.requested_dt").Tables(0)
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
            RH.AddColumn(tr09, tr09_01, 5, 10, "l", dr(0))
            RH.AddColumn(tr09, tr09_02, 3, 10, "c", dr(1))
            RH.AddColumn(tr09, tr09_03, 5, 10, "l", dr(2))
            RH.AddColumn(tr09, tr09_04, 3, 10, "l", dr(3))
            dt3 = oh.ExecuteDataSet("select nvl(a.emp_code||'-'||a.emp_name,'NIL')  from employee_master a where a.emp_code=" & dr(4) & " and a.status_id=1").Tables(0)
            Dim Status = dt3.Rows(0)(0)
            RH.AddColumn(tr09, tr09_05, 3, 10, "l", Status)
            tb.Controls.Add(tr09)
            tot_count += 1
        Next
        RH.DrawLine(tb, 19)
        Dim tr10 As New TableRow
        Dim tr10_01, tr10_02, tr10_03 As New TableCell
        tr10.BackColor = Drawing.Color.AliceBlue
        RH.AddColumn(tr10, tr10_01, 10, 5, "l", "TOTAL :&nbsp;&nbsp;&nbsp;&nbsp;" & "<b>" & tot_count)
        RH.AddColumn(tr10, tr10_03, 9, 5, "r", "")
        tb.Controls.Add(tr10)
        RH.DrawLine(tb, 19)
        Panel1.Controls.Add(tb)
    End Sub
End Class

Imports System.Data
Imports System.Data.OracleClient
Partial Class Attend_Regularisation_No_Date_check__Attend_Regularisation_hrm_Rpt_Attend_HW1_811b6e499814
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
        dt = oh.ExecuteDataSet("select branch_name from branch_master where branch_id=" & BrId & "").Tables(0)
        BranchName = dt.Rows(0)(0)
        RH.Heading(Session("branch_id"), Session("branch_name"), Session("firm_name"), tb, "ATTENDANCE REGULARISATION REPORT OF " & BranchName & "" & vbNewLine & " FROM " & fromdate & " TO " & todate & " " & vbNewLine & "", 29)
        Dim tr07 As New TableRow
        tr07.ForeColor = Drawing.Color.Maroon
        Dim tr07_01, tr07_02, tr07_03, tr07_04, tr07_05 As New TableCell
        RH.AddColumn(tr07, tr07_01, 3, 10, "l", "<b>BR&nbsp;ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_02, 5, 10, "l", "<b>BRANCH&nbsp;NAME&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_03, 8, 10, "l", "<b>REQUESTED&nbsp;BY&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_04, 3, 10, "l", "<b>REQUESTED&nbsp;DATE&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_05, 10, 10, "l", "<b>REQUESTED&nbsp;REASON&nbsp;&nbsp;&nbsp;")
        tb.Controls.Add(tr07)
        RH.DrawLine(tb, 29)
        dt = oh.ExecuteDataSet("select a.emp_code from employee_master a where a.emp_code=" & User(0) & " and a.department_id=20 and a.status_id=1").Tables(0)
        If dt.Rows.Count <= 0 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('You Are Not Authorised !!!!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        End If
        dt = oh.ExecuteDataSet("select a.branch_id,b.BRANCH_NAME,a.requested_by || '-' || e.emp_name,to_char(to_date(a.requested_dt)),a.requested_reason from hrm_attendance_regularisation a, employee_master e,branch_dtl_new b where a.requested_by = e.emp_code and a.branch_id=b.BRANCH_ID and to_date(a.requested_dt) >= '" & fromdate & "' and to_date(a.requested_dt) <= '" & todate & "' order by a.requested_dt").Tables(0)
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
            Dim tr09_01, tr09_02, tr09_03, tr09_04, tr09_05 As New TableCell
            If RowBG = 0 Then
                tr09.BackColor = Drawing.Color.AliceBlue
                RowBG = 1
            Else
                tr09.BackColor = Drawing.Color.MistyRose
                RowBG = 0
            End If
            RH.AddColumn(tr09, tr09_01, 3, 10, "l", dr(0))
            RH.AddColumn(tr09, tr09_02, 5, 10, "l", dr(1))
            RH.AddColumn(tr09, tr09_03, 8, 10, "l", dr(2))
            RH.AddColumn(tr09, tr09_04, 3, 10, "l", dr(3))
            RH.AddColumn(tr09, tr09_05, 10, 10, "l", dr(4))
            tb.Controls.Add(tr09)
            tot_count += 1
        Next
        RH.DrawLine(tb, 29)
        Dim tr10 As New TableRow
        Dim tr10_01, tr10_02, tr10_03 As New TableCell
        tr10.BackColor = Drawing.Color.AliceBlue
        RH.AddColumn(tr10, tr10_01, 10, 5, "l", "TOTAL :&nbsp;&nbsp;&nbsp;&nbsp;" & "<b>" & tot_count)
        RH.AddColumn(tr10, tr10_03, 12, 5, "r", "")
        tb.Controls.Add(tr10)
        RH.DrawLine(tb, 29)
        Panel1.Controls.Add(tb)
    End Sub
End Class

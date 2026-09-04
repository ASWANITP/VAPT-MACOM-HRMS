Imports System.Data
Imports System.Data.OracleClient
Partial Class feb2009_change_shift_press_reports_d2cb19252879
    Inherits System.Web.UI.Page
    Dim dt, dt1, dt2 As New DataTable
    Dim sql, fnm, alls() As String
    Dim usr() As String
    Dim sf() As String
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim tb As New Table
        tb.Attributes.Add("width", "100%")
        tb.Attributes.Add("border", "")

        tb.Attributes.Add("align", "center")

        Dim tr4 As New TableRow
        tr4.BackColor = Drawing.Color.Gold
        Dim tc14 As New TableCell
        tc14.ColumnSpan = 22
        tc14.HorizontalAlign = HorizontalAlign.Center
        tc14.Text = "<font size=5 color=red><b>VAPT PENDING PROJECT</b></font>"
        tr4.Cells.Add(tc14)
        tb.Controls.Add(tr4)
        'dt1 = oh.ExecuteDataSet("select emp_name,emp_code from employee_master where emp_code=" & Request.QueryString("emp") & " ").Tables(0)

        Dim tr5 As New TableRow
        tr5.BackColor = Drawing.Color.FloralWhite
        Dim tc15 As New TableCell
        tc15.ColumnSpan = 22
        tc15.HorizontalAlign = HorizontalAlign.Center



        'tc15.Text = "<MARQUEE  bgColor=snow><STRONG><FONT color=navy><b>" </b></FONT></STRONG></MARQUEE>"
        tr5.Cells.Add(tc15)
        tb.Controls.Add(tr5)





        Dim tr1 As New TableRow
        tr1.BackColor = Drawing.Color.BlanchedAlmond
        Dim tc1 As New TableCell
        tc1.ColumnSpan = 4
        tc1.HorizontalAlign = HorizontalAlign.Left
        tc1.Text = "<font size=2><b>EMPLOYEE&nbsp;CODE</b></font>"
        tr1.Cells.Add(tc1)

        Dim tc2 As New TableCell
        tc2.ColumnSpan = 4
        tc2.HorizontalAlign = HorizontalAlign.Left
        tc2.Text = "<font size=2><b>EMPLOYEE&nbsp;NAME</b></font>"
        tr1.Cells.Add(tc2)

        Dim tc3 As New TableCell
        tc3.ColumnSpan = 4
        tc3.HorizontalAlign = HorizontalAlign.Left
        tc3.Text = "<font size=2><b>ASSIGNED VAPT</b></font>"
        tr1.Cells.Add(tc3)


        tb.Controls.Add(tr1)
        dt = oh.ExecuteDataSet("select em.emp_code,em.emp_name,tm.type_name from vapt_assigned_issues va, vapt_issue_resolving_master vm, time_sheet_project tm, employee_master em where va.issue_resolving_status <> 3 and vm.status_id = va.issue_resolving_status and va.developer = " & Session("user_id").ToString.Split("!")(0) & " and em.emp_code=va.developer and tm.type_id = va.project_id").Tables(0)
        'dt = oh.ExecuteDataSet("select h.emp_code,e.emp_name,to_char(h.eff_dt),t.shift||'&nbsp;--&nbsp;'||t.in_time||'&nbsp;To&nbsp;'||t.out_time,e1.emp_code||'--'||e1.emp_name,d.dep_name,to_char(h.enter_dt),b.BRANCH_NAME from employee_master e,employee_master e1,time_tab t,hrm_shift_change h,department_mst d,branch b where e.emp_code=h.emp_code and h.dep_id=d.dep_id and e.branch_id=b.BRANCH_ID and h.shift_id=t.shift_id and h.user_id=e1.emp_code and to_date(h.eff_dt)=to_date('" & Request.QueryString("effdt") & "') ").Tables(0)


        If (dt.Rows.Count = 0) Then
            tc1.Text = "NO VAPT PROJECTS PENDING"
            tc1.ColumnSpan = 22
            tc2.Visible = False
            tc3.Visible = False



        Else

            Dim dr As DataRow
            Dim color As Integer = 0

            For Each dr In dt.Rows
                Dim tr2 As New TableRow

                If (color = 0) Then
                    tr2.BackColor = Drawing.Color.Snow
                    color = 1
                Else
                    tr2.BackColor = Drawing.Color.Azure
                    color = 0
                End If
                tr2.Attributes.Add("height", "2C5px")

                Dim tc18 As New TableCell
                tc18.ColumnSpan = 4
                tc18.HorizontalAlign = HorizontalAlign.Left
                tc18.Text = "<font size=2>" & dr(0) & "</font>"
                tc18.ForeColor = Drawing.Color.Black
                tr2.Cells.Add(tc18)





                Dim tc19 As New TableCell
                tc19.ColumnSpan = 4
                tc19.HorizontalAlign = HorizontalAlign.Left
                tc19.Text = "<font size=2 color=blue>" & dr(1) & "</font>"
                tr2.Cells.Add(tc19)

                Dim tc20 As New TableCell
                tc20.ColumnSpan = 4
                tc20.HorizontalAlign = HorizontalAlign.Left
                tc20.Text = "<font size=2>" & dr(2) & "</font>"
                tr2.Cells.Add(tc20)

                tb.Controls.Add(tr2)

            Next
        End If
        Me.Panel1.Controls.Add(tb)
    End Sub
End Class

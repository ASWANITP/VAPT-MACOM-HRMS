Imports System.Data
Imports System.Data.OracleClient
Partial Class feb2009_change_shift_press_report_22b0021f7198
    Inherits System.Web.UI.Page
    Dim dt, dt1, dt2 As New DataTable
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
        tc14.Text = "<font size=5 color=red><b>MANAPPURAM GROUP OF COMPANIES</b></font>"
        tr4.Cells.Add(tc14)
        tb.Controls.Add(tr4)
        'dt1 = oh.ExecuteDataSet("select emp_name,emp_code from employee_master where emp_code=" & Request.QueryString("emp") & " ").Tables(0)

        Dim tr5 As New TableRow
        tr5.BackColor = Drawing.Color.FloralWhite
        Dim tc15 As New TableCell
        tc15.ColumnSpan = 22
        tc15.HorizontalAlign = HorizontalAlign.Center
        Dim rep As String


        tc15.Text = "<MARQUEE  bgColor=snow><STRONG><FONT color=navy><b>SHIFT CHANGE REPORT OF " & Request.QueryString("effdt") & " </b></FONT></STRONG></MARQUEE>"
        tr5.Cells.Add(tc15)
        tb.Controls.Add(tr5)


        Dim tr6 As New TableRow
        tr6.BackColor = Drawing.Color.FloralWhite
        Dim tc16 As New TableCell
        tc16.Attributes.Add("width", "50%")
        tc16.ColumnSpan = 11
        tc16.HorizontalAlign = HorizontalAlign.Left
        tc16.BorderWidth = 0
        tc16.Text = "<font size=2 color=darkblue>Date&nbsp:" & Format(Date.Now, "dd/MMM/yyyy") & "</font>"
        tr6.Cells.Add(tc16)


        Dim tc17 As New TableCell
        tc17.Attributes.Add("width", "50%")
        tc17.ColumnSpan = 11
        tc17.BorderWidth = 0
        tc17.HorizontalAlign = HorizontalAlign.Right
        tc17.Text = "<font size=2 color=darkblue>Time&nbsp:" & Format(Date.Now, "hh:mm:ss") & "</font>"
        tr6.Cells.Add(tc17)
        tb.Controls.Add(tr6)


        Dim tr1 As New TableRow
        tr1.BackColor = Drawing.Color.BlanchedAlmond
        Dim tc1 As New TableCell
        tc1.ColumnSpan = 1
        tc1.HorizontalAlign = HorizontalAlign.Left
        tc1.Text = "<font size=2><b>CODE</b></font>"
        tr1.Cells.Add(tc1)

        Dim tc2 As New TableCell
        tc2.ColumnSpan = 2
        tc2.HorizontalAlign = HorizontalAlign.Left
        tc2.Text = "<font size=2><b>EMPLOYEE&nbsp;NAME</b></font>"
        tr1.Cells.Add(tc2)

        Dim tc3 As New TableCell
        tc3.ColumnSpan = 2
        tc3.HorizontalAlign = HorizontalAlign.Left
        tc3.Text = "<font size=2><b>EFFECTIVE&nbsp;DATE</b></font>"
        tr1.Cells.Add(tc3)

        Dim tc4 As New TableCell
        tc4.ColumnSpan = 8
        tc4.HorizontalAlign = HorizontalAlign.Left
        tc4.Text = "<font size=2><b>&nbsp;&nbsp;&nbsp;&nbsp;SHIFT&nbsp;TIME&nbsp;&nbsp;&nbsp;</b></font>"
        tr1.Cells.Add(tc4)

        Dim tc5 As New TableCell
        tc5.ColumnSpan = 3
        tc5.HorizontalAlign = HorizontalAlign.Left
        tc5.Text = "<font size=2><b>ENTERED&nbsp;BY</b></font>"
        tr1.Cells.Add(tc5)

        Dim tc6 As New TableCell
        tc6.ColumnSpan = 2
        tc6.HorizontalAlign = HorizontalAlign.Left
        tc6.Text = "<font size=2><b>DEPARTMENT</b></font>"
        tr1.Cells.Add(tc6)

        Dim tc7 As New TableCell
        tc7.ColumnSpan = 2
        tc7.HorizontalAlign = HorizontalAlign.Left
        tc7.Text = "<font size=2><b>ENTERED&nbsp;DATE</b></font>"
        tr1.Cells.Add(tc7)
        tb.Controls.Add(tr1)
        Dim tc8 As New TableCell
        tc8.ColumnSpan = 2
        tc8.HorizontalAlign = HorizontalAlign.Left
        tc8.Text = "<font size=2><b>BRANCH</b></font>"
        tr1.Cells.Add(tc8)
        tb.Controls.Add(tr1)
        dt = oh.ExecuteDataSet("select h.emp_code,e.emp_name,to_char(h.eff_dt),t.shift||'&nbsp;--&nbsp;'||t.in_time||'&nbsp;To&nbsp;'||t.out_time,e1.emp_code||'--'||e1.emp_name,d.dep_name,to_char(h.enter_dt),b.BRANCH_NAME from employee_master e,employee_master e1,time_tab t,hrm_shift_change h,department_mst d,branch b where e.emp_code=h.emp_code and h.dep_id=d.dep_id and e.branch_id=b.BRANCH_ID and h.shift_id=t.shift_id and h.user_id=e1.emp_code and to_date(h.eff_dt)=to_date('" & Request.QueryString("effdt") & "') and h.dep_id=" & Request.QueryString("dep") & "").Tables(0)


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
            tr2.Attributes.Add("height", "25px")

            Dim tc18 As New TableCell
            tc18.ColumnSpan = 1
            tc18.HorizontalAlign = HorizontalAlign.Left
            tc18.Text = "<font size=2>" & dr(0) & "</font>"
            tc18.ForeColor = Drawing.Color.Black
            tr2.Cells.Add(tc18)


            Dim sd3 As String


            Dim tc19 As New TableCell
            tc19.ColumnSpan = 2
            tc19.HorizontalAlign = HorizontalAlign.Left
            tc19.Text = "<font size=2 color=blue>" & dr(1) & "</font>"
            ' tc19.ForeColor = Drawing.Color.Black
            tr2.Cells.Add(tc19)

            Dim tc20 As New TableCell
            tc20.ColumnSpan = 2
            tc20.HorizontalAlign = HorizontalAlign.Left

            tc20.Text = "<font size=2>" & dr(2) & "</font>"
            ' tc10.Text = dt.Rows(0)(0)
            tr2.Cells.Add(tc20)


            sd3 = dr(3)
            Dim tc21 As New TableCell
            tc21.ColumnSpan = 8
            tc21.HorizontalAlign = HorizontalAlign.Left
            tc21.Text = "<font size=2 color=blue>" & sd3 & "</font>"
            tr2.Cells.Add(tc21)
            tb.Controls.Add(tr2)



            Dim tc22 As New TableCell
            tc22.ColumnSpan = 3
            tc22.HorizontalAlign = HorizontalAlign.Left
            tc22.Text = "<font size=2>" & dr(4) & "</font>"
            tr2.Cells.Add(tc22)
            tb.Controls.Add(tr2)

            Dim tc23 As New TableCell
            tc23.ColumnSpan = 2
            tc23.HorizontalAlign = HorizontalAlign.Left
            tc23.Text = "<font size=2 color=blue>" & dr(5) & "</font>"
            tr2.Cells.Add(tc23)
            tb.Controls.Add(tr2)

            Dim tc24 As New TableCell
            tc24.ColumnSpan = 2
            tc24.HorizontalAlign = HorizontalAlign.Left
            tc24.Text = "<font size=2>" & dr(6) & "</font>"
            tr2.Cells.Add(tc24)
            tb.Controls.Add(tr2)

            Dim tc25 As New TableCell
            tc25.ColumnSpan = 2
            tc25.HorizontalAlign = HorizontalAlign.Left
            tc25.Text = "<font size=2>" & dr(7) & "</font>"
            tr2.Cells.Add(tc25)
            tb.Controls.Add(tr2)

        Next

        Me.Panel1.Controls.Add(tb)
    End Sub
End Class

Imports System.Data

Partial Class attend_attend_emp_5a3dba755663
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable
        Dim date1 As Date = Request.QueryString.Get("fdate")
        Dim dat As Integer = DateDiff(DateInterval.Day, date1, Date.Now)
        Dim arun As String
        If dat = 0 Then
            arun = "select em.emp_name,a.emp_code,a.curr_date,a.m_time,a.e_time from daily_attend a,employee_master em where a.branch_id=em.branch_id and a.emp_code=em.emp_code and to_date(curr_date)='" & Request.QueryString.Get("fdate") & "'  and a.branch_id=" & Request.QueryString.Get("id") & " and a.shift_id=" & Request.QueryString.Get("shift") & ""
        Else
            arun = "select em.emp_name,a.emp_code,a.curr_date,a.m_time,a.e_time from attend a,employee_master em where a.branch_id=em.branch_id and a.emp_code=em.emp_code and to_date(curr_date)='" & Request.QueryString.Get("fdate") & "' and a.branch_id=" & Request.QueryString.Get("id") & " and a.shift_id=" & Request.QueryString.Get("shift") & " "
        End If
        Dim oh As New Helper.Oracle.OracleHelper
        dt = oh.ExecuteDataSet(arun).Tables(0)
        Dim ar As DataRow
        Dim attend As New Table
        Dim trt1 As New TableRow
        Dim tct1 As New TableCell
        tct1.ColumnSpan = 6

        tct1.HorizontalAlign = HorizontalAlign.Center
        tct1.Text = "<b><font size=2 >" & Session("firm_name") & "</font></b>"
        trt1.Controls.Add(tct1)
        attend.Controls.Add(trt1)

        Dim tr_br As New TableRow
        Dim tc_br As New TableCell
        tc_br.ColumnSpan = 6
        tc_br.HorizontalAlign = HorizontalAlign.Center
        tc_br.Text = "<b><font size=2 >Branch ID-" & Session("branch_id") & "," + "  Branch  " & Session("branch_name") & " </font></b>"
        tr_br.Controls.Add(tc_br)
        attend.Controls.Add(tr_br)

        Dim trt2 As New TableRow
        Dim tct2 As New TableCell
        tct2.ColumnSpan = 1
        tct2.Text = "<b><font size=2 >" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
        tct2.HorizontalAlign = HorizontalAlign.Left
        trt2.Controls.Add(tct2)

        Dim ss As String = oh.ExecuteDataSet("select branch_name from branch_master where branch_id=" & Request.QueryString("id")).Tables(0).Rows(0)(0)

        Dim tct3 As New TableCell
        tct3.ColumnSpan = 4
        tct3.Text = "<b><font size=2 > Attendence Report Punched Employee Of Branch " & ss & " </font></b>"
        tct3.HorizontalAlign = HorizontalAlign.Center
        trt2.Controls.Add(tct3)
        Dim tct4 As New TableCell
        tct4.ColumnSpan = 1
        tct4.Text = "<b><font size=2 >" & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
        tct4.HorizontalAlign = HorizontalAlign.Right
        trt2.Controls.Add(tct4)
        attend.Controls.Add(trt2)

        Dim tc1 As New TableCell
        Dim tc2 As New TableCell
        Dim tc3 As New TableCell
        Dim tc4 As New TableCell
        Dim tc5 As New TableCell
        Dim tc6 As New TableCell
        Dim tr As New TableRow
        Dim tr1 As New TableRow
        Dim a As Integer
        Dim line1 As New TableRow
        Dim line11 As New TableCell
        line11.ColumnSpan = 6
        line11.Text = "<hr align=center width=100% >"
        line1.Controls.Add(line11)
        attend.Controls.Add(line1)

        attend.Attributes.Add("align", "center")
        attend.Attributes.Add("width", "75%")
        Dim q As New TableRow
        Dim q1 As New TableCell
        Dim q2, q3, q4, q5 As New TableCell
        q1.Text = "Employee Name"
        q.Cells.Add(q1)
        q2.Text = "Employee Code"
        'q2.HorizontalAlign = HorizontalAlign.Right
        q.Cells.Add(q2)
        q3.Text = "Date"
        q.Cells.Add(q3)
        q4.Text = "Morning Time"
        q.Cells.Add(q4)
        q5.Text = "Evening Time"
        q.Cells.Add(q5)
        attend.Rows.Add(q)

        Dim line10 As New TableRow
        Dim line101 As New TableCell
        line101.ColumnSpan = 6
        line101.Text = "<hr align=center width=100% >"
        line10.Controls.Add(line101)
        attend.Controls.Add(line10)
        Dim c As Integer
        For Each ar In dt.Rows
            Dim t As New TableRow
            'Dim sql As String = "select em.emp_name,da.emp_code,da.curr_date,da.m_time,da.e_time from daily_attend da,employee_master em where da.branch_id=em.branch_id and da.emp_code=em.emp_code and to_date(da.curr_date)>='" & Request.QueryString.Get("fdate") & "' and to_date(da.curr_date)<='" & Request.QueryString.Get("tdate") & "' and da.branch_id=" & Request.QueryString.Get("id") & " and da.shift_id=" & Request.QueryString.Get("shift") & ""
            'Dim dt1 As New DataTable
            'dt1 = oh.ExecuteDataSet(sql).Tables(0)
            'Dim z As New TableRow
            Dim t1 As New TableCell
            Dim t2 As New TableCell
            Dim t3 As New TableCell
            Dim t4 As New TableCell
            Dim t5 As New TableCell
            Dim t6 As New TableCell
            'Dim p As Integer = -1
            't1.Text = "<a href=attend_dv.aspx?id=" & ar(2) & "&shift=" & Request.QueryString("shift") & "&fdate=" & Request.QueryString("fdt") & "&tdate=" & Request.QueryString("tdt") & ">" & ar(0) & "</a>"
            t1.Text = ar(0)
            t.Cells.Add(t1)
            t2.Text = ar(1)
            t.Cells.Add(t2)
            t3.Text = Format(ar(2), "dd/MMM/yyyy")
            t.Cells.Add(t3)
            If IsDBNull(ar(3)) Then
                t4.Text = " "
                t.Cells.Add(t4)
            Else
                t4.Text = ar(3)
                t.Cells.Add(t4)
            End If
            If IsDBNull(ar(4)) Then
                t5.Text = " "
                t.Cells.Add(t5)
            Else
                t5.Text = ar(4)
                t.Cells.Add(t5)
            End If
            c = c + 1
            attend.Rows.Add(t)
        Next
        Dim line110 As New TableRow
        Dim line1101 As New TableCell
        line1101.ColumnSpan = 6
        line1101.Text = "<hr align=center width=100% >"
        line110.Controls.Add(line1101)
        attend.Controls.Add(line110)

        Dim l As New TableRow
        Dim l0 As New TableCell
        Dim l1 As New TableCell
        Dim l2 As New TableCell
        Dim l3 As New TableCell
        l0.Text = "&nbsp"
        l.Cells.Add(l0)
        l1.Text = "Total"
        l.Cells.Add(l1)
        l2.Text = c
        l2.HorizontalAlign = HorizontalAlign.Center
        l.Cells.Add(l2)
        'l3.Text = FormatNumber(price, 2)
        'l3.HorizontalAlign = HorizontalAlign.Right
        'l.Cells.Add(l3)
        attend.Rows.Add(l)

        Dim line210 As New TableRow
        Dim line2101 As New TableCell
        line2101.ColumnSpan = 6
        line2101.Text = "<hr align=center width=100% >"
        line210.Controls.Add(line2101)
        attend.Controls.Add(line210)
        Me.pnl_attedemp.Controls.Add(attend)
    End Sub
End Class

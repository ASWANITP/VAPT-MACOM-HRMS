Imports System.Data
Imports System.Data.OracleClient
Partial Class leave_leave_rpt_db6829b42130
    Inherits System.Web.UI.Page
    Dim name As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt, dt1 As New DataTable
        Dim oh As New Helper.Oracle.OracleHelper
        Dim fdt, tdt, yr As String
        yr = Today.Year
        ' yr = "2008"
        fdt = "01-JAN-" & yr
        tdt = "31-DEC-" & yr
        '    Session("branch_id") = 0
        Dim head As String = " LEAVE DETAILS FROM " & fdt & " TO " & tdt
        'If Session("branch_id") = 0 Then
        Dim name As String = "select a.leave_frdate,a.leave_todate,a.leave_days,b.leave_type,a.leave_reason,a.leave_id from employ_leave_dtl a,leave_master b where a.leave_process_id in (1,2,8) and a.leave_id=b.leave_id and a.emp_code=" & Request.QueryString.Get("emp_code") & " and to_date(leave_frdate)>='" & fdt & "' and to_date(leave_todate)<='" & tdt & "' order by to_date(leave_frdate)"
        ' Dim name As String = "select a.leave_frdate,a.leave_todate,a.leave_days,b.leave_type,a.leave_reason,a.leave_id from employ_leave_dtl a,leave_master b where a.leave_process_id in (1,2) and a.leave_id=b.leave_id and a.emp_code=10188 and to_date(leave_frdate)>='" & fdt & "' and to_date(leave_todate)<='" & tdt & "' order by to_date(leave_frdate)"

        dt = oh.ExecuteDataSet(name).Tables(0)

        dt1 = oh.ExecuteDataSet("select a.emp_code,a.emp_name,a.join_dt,b.designation,c.dep_name ,d.branch_name from employee_master a,designation_master b,department_mst c,branch_master d where a.designation_id=b.designation_id and a.department_id=c.dep_id and a.branch_id=d.branch_id and a.emp_code=" & Request.QueryString.Get("emp_code")).Tables(0)
        '   dt1 = oh.ExecuteDataSet("select a.emp_code,a.emp_name,a.join_dt,b.designation,c.dep_name ,d.branch_name from employee_master a,designation_master b,department_mst c,branch_master d where a.designation_id=b.designation_id and a.department_id=c.dep_id and a.branch_id=d.branch_id and a.emp_code=10188").Tables(0)

        'Else
        '    Dim ar() = Session("user_id").ToString.Split("!")
        '    Dim name As String = "select a.leave_frdate,a.leave_todate,a.leave_days,b.leave_type,a.leave_reason,a.leave_id from employ_leave_dtl a,leave_master b where a.leave_process_id in (1,2,8) and a.leave_id=b.leave_id and a.emp_code=" & ar(0) & " and to_date(leave_frdate)>='" & fdt & "' and to_date(leave_todate)<='" & tdt & "' order by to_date(leave_frdate)"
        '    dt = oh.ExecuteDataSet(name).Tables(0)
        '    dt1 = oh.ExecuteDataSet("select a.emp_code,a.emp_name,a.join_dt,b.designation,c.dep_name ,d.branch_name from employee_master a,designation_master b,department_mst c,branch_master d where a.designation_id=b.designation_id and a.department_id=c.dep_id and a.branch_id=d.branch_id and a.emp_code=" & ar(0)).Tables(0)
        'End If
        Dim at As DataRow
        Dim assettab As New Table
        Dim trt1 As New TableRow
        Dim tct1 As New TableCell
        tct1.ColumnSpan = 7

        tct1.HorizontalAlign = HorizontalAlign.Center
        tct1.Text = "<b><font size=4 >  " & Session("firm_name") & "  </font></b>"
        trt1.Controls.Add(tct1)
        assettab.Controls.Add(trt1)

        Dim tr_br As New TableRow
        Dim tc_br As New TableCell
        tc_br.ColumnSpan = 7
        tc_br.HorizontalAlign = HorizontalAlign.Center
        tc_br.Text = "<font size=2 ><B>Branch&nbspId:&nbsp" & Session("branch_id") & "&nbsp&nbspBranch&nbspName:&nbsp" & Session("branch_name") & "</B></font>"
        tr_br.Controls.Add(tc_br)
        assettab.Controls.Add(tr_br)

        Dim trt2 As New TableRow
        Dim tct2 As New TableCell
        tct2.ColumnSpan = 1
        tct2.Text = "<b><font size=2 >" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
        tct2.HorizontalAlign = HorizontalAlign.Left
        trt2.Controls.Add(tct2)
        Dim tct3 As New TableCell
        tct3.ColumnSpan = 5
        tct3.Text = "<b><font size=2 >" & head & "</font></b>"
        tct3.HorizontalAlign = HorizontalAlign.Center
        trt2.Controls.Add(tct3)
        Dim tct4 As New TableCell
        tct4.ColumnSpan = 1
        tct4.Text = "<b><font size=2 >" & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
        tct4.HorizontalAlign = HorizontalAlign.Right
        trt2.Controls.Add(tct4)
        assettab.Controls.Add(trt2)
        Dim lineq1 As New TableRow
        Dim lineq11 As New TableCell
        lineq11.ColumnSpan = 7
        lineq11.Text = "<hr align=center width=100% >"
        lineq1.Controls.Add(lineq11)
        assettab.Controls.Add(lineq1)

        Dim d1, d2, d3 As New TableRow
        Dim d10, d11, d12, d13, d14, d15, d20, d21, d22, d23, d24, d25, d30, d31, d32, d33, d34, d35 As New TableCell
        d10.Font.Size = 11
        d11.Font.Size = 11
        d12.Font.Size = 11
        d13.Font.Size = 11
        d14.Font.Size = 11
        d15.Font.Size = 11
        d20.Font.Size = 11
        d21.Font.Size = 11
        d22.Font.Size = 11
        d23.Font.Size = 11
        d24.Font.Size = 11
        d25.Font.Size = 11
        d30.Font.Size = 11
        d31.Font.Size = 11
        d32.Font.Size = 11
        d33.Font.Size = 11
        d34.Font.Size = 11
        d35.Font.Size = 11

        d10.Text = "&nbsp"
        d1.Cells.Add(d10)
        d11.Text = "Emp.Code&nbsp:&nbsp"
        d1.Cells.Add(d11)
        d12.Text = dt1.Rows(0)(0)
        d1.Cells.Add(d12)
        d13.Text = "&nbsp"
        d1.Cells.Add(d13)
        d14.Text = "Emp.Name&nbsp:&nbsp"
        d1.Cells.Add(d14)
        d15.Text = dt1.Rows(0)(1)
        d1.Cells.Add(d15)
        d20.Text = "&nbsp"
        d2.Cells.Add(d20)
        d21.Text = "Joining&nbspDate:&nbsp"
        d2.Cells.Add(d21)
        d22.Text = Format(dt1.Rows(0)(2), "dd/MMM/yyyy")
        d2.Cells.Add(d22)
        d23.Text = "&nbsp"
        d2.Cells.Add(d23)
        d24.Text = "Designation&nbsp:&nbsp"
        d2.Cells.Add(d24)
        d25.Text = dt1.Rows(0)(3)
        d2.Cells.Add(d25)
        d30.Text = "&nbsp"
        d3.Cells.Add(d30)
        d31.Text = "Branch&nbspName:&nbsp"
        d3.Cells.Add(d31)
        d32.Text = dt1.Rows(0)(5)
        d3.Cells.Add(d32)
        d33.Text = "&nbsp"
        d3.Cells.Add(d33)
        d34.Text = "Dept.Name&nbsp:&nbsp"
        d3.Cells.Add(d34)
        d35.Text = dt1.Rows(0)(4)
        d3.Cells.Add(d35)
        assettab.Rows.Add(d1)
        assettab.Rows.Add(d2)
        assettab.Rows.Add(d3)
        Dim line1 As New TableRow
        Dim line11 As New TableCell
        line11.ColumnSpan = 7
        line11.Text = "<hr align=center width=100% >"
        line1.Controls.Add(line11)
        assettab.Controls.Add(line1)
        assettab.Attributes.Add("align", "left")
        assettab.Attributes.Add("width", "90%")
        Dim s As New TableRow
        Dim s0 As New TableCell
        s0.Font.Size = 10
        Dim s1 As New TableCell
        s1.Font.Size = 10
        Dim s2 As New TableCell
        s2.Font.Size = 10
        Dim s3 As New TableCell
        s3.Font.Size = 10
        Dim s4 As New TableCell
        s4.Font.Size = 10
        Dim s5 As New TableCell
        s5.Font.Size = 10
        Dim s6 As New TableCell

        s2.Text = "SI&nbspNo"
        s2.HorizontalAlign = HorizontalAlign.Center
        s.Cells.Add(s2)
        s0.Text = " From&nbspDate"
        s.Cells.Add(s0)
        s1.Text = "To&nbspDate"
        s.Cells.Add(s1)
        s3.Text = "Leave&nbspDays"
        s3.HorizontalAlign = HorizontalAlign.Center
        s.Cells.Add(s3)
        s4.Text = "Leave&nbspType"
        s.Cells.Add(s4)
        s5.Text = "Reason"
        s.Cells.Add(s5)
        assettab.Rows.Add(s)
        Dim line10 As New TableRow
        Dim line101 As New TableCell
        line101.ColumnSpan = 7
        line101.Text = "<hr align=center width=100% >"
        line10.Controls.Add(line101)
        assettab.Controls.Add(line10)
        Dim c As Integer
        Dim d As Integer = 1
        Dim casual As Integer = 0
        Dim sick As Integer = 0
        Dim earn As Integer = 0
        Dim lop As Integer = 0

        For Each at In dt.Rows
            Dim m As New TableRow
            Dim m0 As New TableCell
            m0.Font.Size = 8
            Dim m1 As New TableCell
            m1.Font.Size = 8
            Dim m2 As New TableCell
            m2.Font.Size = 8
            Dim m3 As New TableCell
            m3.Font.Size = 8
            Dim m4 As New TableCell
            m4.Font.Size = 8
            Dim m9 As New TableCell
            m9.Font.Size = 8
            '                0           1                   2         3            4            5            6            7        8             9
            'select a.leave_frdate,a.leave_todate,a.leave_days,b.leave_type,a.leave_reason from employ_leave_dtl a,leave_master b where a.leave_id=b.leave_id and and a.emp_code=" & ar(0)
            m9.Text = d
            m9.HorizontalAlign = HorizontalAlign.Center
            m.Cells.Add(m9)
            m0.Text = Format(at(0), "dd/MMM/yyyy")
            m.Cells.Add(m0)
            m1.Text = Format(at(1), "dd/MMM/yyyy")
            m.Cells.Add(m1)
            m2.Text = at(2)
            m2.HorizontalAlign = HorizontalAlign.Center
            m.Cells.Add(m2)
            'm3.HorizontalAlign = HorizontalAlign.Right
            m3.Text = at(3)
            m.Cells.Add(m3)
            m4.Text = at(4)
            m.Cells.Add(m4)
            c = c + 1
            d = d + 1
            assettab.Rows.Add(m)
            If at(5) = 1 Then
                casual += at(2)
            ElseIf at(5) = 2 Then
                sick += at(2)
            ElseIf at(5) = 3 Then
                earn += at(2)
            ElseIf at(5) = 4 Then
                lop += at(2)
            End If
        Next

        Dim line110 As New TableRow
        Dim line1101 As New TableCell
        line1101.ColumnSpan = 7
        line1101.Text = "<hr align=center width=100% >"
        line110.Controls.Add(line1101)
        assettab.Controls.Add(line110)

        Dim tot1, tot2, tot3, tot4 As New TableRow
        'tot1.ForeColor = Drawing.Color.Maroon
        'tot2.ForeColor = Drawing.Color.Maroon
        'tot3.ForeColor = Drawing.Color.Maroon
        'tot4.ForeColor = Drawing.Color.Maroon
        Dim tot11, tot12, tot21, tot22, tot31, tot32, tot41, tot42 As New TableCell
        tot11.ColumnSpan = 2
        tot12.ColumnSpan = 5
        tot21.ColumnSpan = 2
        tot22.ColumnSpan = 5
        tot31.ColumnSpan = 2
        tot32.ColumnSpan = 5
        tot41.ColumnSpan = 2
        tot42.ColumnSpan = 5

        tot11.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Casual Leave : "
        tot12.Text = "<font size=2>" & FormatNumber(casual, 0) & "</font>"
        tot21.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Sick Leave : "
        tot22.Text = "<font size=2>" & FormatNumber(sick, 0) & "</font>"
        tot31.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Earned Leave : "
        tot32.Text = "<font size=2>" & FormatNumber(earn, 0) & "</font>"
        tot41.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Loss Of Pay : "
        tot42.Text = "<font size=2>" & FormatNumber(lop, 0) & "</font>"
        tot1.Controls.Add(tot11)
        tot1.Controls.Add(tot12)
        tot2.Controls.Add(tot21)
        tot2.Controls.Add(tot22)
        tot3.Controls.Add(tot31)
        tot3.Controls.Add(tot32)
        tot4.Controls.Add(tot41)
        tot4.Controls.Add(tot42)
        assettab.Controls.Add(tot1)
        assettab.Controls.Add(tot2)
        assettab.Controls.Add(tot3)
        assettab.Controls.Add(tot4)

        Dim lastrow As New TableRow
        lastrow.Width = 7
        Dim last As New TableCell
        last.ColumnSpan = 7
        last.HorizontalAlign = HorizontalAlign.Left
        'last.ForeColor = Drawing.Color.Red
        last.Text = "<font size=2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Total Leave Taken In This Year : " & FormatNumber(casual + sick + earn + lop, 0) & "</font>"
        lastrow.Controls.Add(last)
        assettab.Controls.Add(lastrow)
        Dim months As DataTable = oh.ExecuteDataSet("select nvl(sum(leave_days),0) from employ_leave_dtl el where el.leave_process_id in (1,2,8) and el.status=1 and el.emp_code=" & Me.Request.QueryString("emp_code") & " and el.leave_frdate>=sysdate-365").Tables(0)
        If months.Rows.Count > 0 Then

            Dim monthrow As New TableRow
            monthrow.Width = 7
            Dim month1 As New TableCell
            month1.ColumnSpan = 7
            month1.HorizontalAlign = HorizontalAlign.Left
            'month1.ForeColor = Drawing.Color.Blue
            month1.Text = "<font size=2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Total Leave Taken In Last 12 Months : " & FormatNumber(months.Rows(0)(0), 0) & "</font>"
            monthrow.Controls.Add(month1)
            assettab.Controls.Add(monthrow)
        End If
        Me.pnl_leav.Controls.Add(assettab)

    End Sub
End Class

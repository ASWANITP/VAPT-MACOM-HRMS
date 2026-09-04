Imports System.Data
Imports System.Data.OracleClient
Partial Class leave_leave_rpt_db6829b44670
    Inherits System.Web.UI.Page
    Dim name, ar() As String
    Dim CurrCode, oldCode, oldCnt As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt, dt1, dt2 As New DataTable
        Dim oh As New Helper.Oracle.OracleHelper
        Dim head As String = " LEAVE DETAILS FROM " & Request.QueryString.Get("fdt") & " TO " & Request.QueryString.Get("tdt")
        Dim pq As DataTable
        Dim fid As Integer = Session("firm_id")
        Dim frm As String = Session("firm_name")
        '//-=-=-==-=Modi on 220510 -=-=-=-==-==//
        If Me.Session("branch_id") = 0 Or 3266 Then
            Me.CurrCode = Me.Request.QueryString.Get("emp_code")
        Else
            ar = Session("user_id").ToString.Split("!")
            Me.CurrCode = ar(0)
        End If
        'frm = oh.ExecuteDataSet("select firm_name from firm_master where firm_id=" & fid & " ").Tables(0).Rows(0)(0)
        Me.oldCnt = oh.ExecuteDataSet("select count(*) from employee_master_dtl where new_empcode = " & Me.CurrCode).Tables(0).Rows(0)(0)
        If oldCnt = 1 Then
            Me.oldCode = oh.ExecuteDataSet("select emp_code from employee_master_dtl where new_empcode = " & Me.CurrCode).Tables(0).Rows(0)(0)
        Else
            Me.oldCode = 0
        End If
        Dim name As String = "select a.leave_frdate,a.leave_todate,case when a.leave_form in(11,12) then to_number(0.5) else a.leave_days end leave_days,b.leave_abbr,decode(a.leave_reason,Null,'----',a.leave_reason) from employ_leave_dtl a,leave_master b where a.leave_id=b.leave_id and a.leave_process_id not in (0,3) and a.status=1 and a.emp_code in (" & Me.CurrCode & "," & Me.oldCode & ") and to_date(leave_frdate)>='" & Request.QueryString.Get("fdt") & "' and to_date(leave_todate)<='" & Request.QueryString.Get("tdt") & "' order by to_date(leave_frdate)"
        dt = oh.ExecuteDataSet(name).Tables(0)
        If Session("firm_id") = 28 Then
            'dt1 = oh.ExecuteDataSet("select a.emp_code,a.emp_name,a.join_dt,case when b.designation_id <> 7 then b.designation || '/' || b.ctgry || '/' || b.ctgry_code when b.designation_id = 7 and exists (select t.emp_code, max(t.year_pass), t.qualification, qc.category_id from employ_qualification_dtl t, qualification_master qm, qualification_category qc where t.emp_code = a.emp_code and qm.qualification_id = t.qualification and qc.category_id = qm.category_id and qc.category_id IN (4, 3) group by t.emp_code, t.qualification, qc.category_id) then b.designation || '/' || 'JR. MANAGEMENT' || '/' || 'JM 4' when b.designation_id = 7 and exists (select t.emp_code, max(t.year_pass), t.qualification, qc.category_id from employ_qualification_dtl t, qualification_master qm, qualification_category qc where t.emp_code = a.emp_code and qm.qualification_id = t.qualification and qc.category_id = qm.category_id and qc.category_id IN (7) group by t.emp_code, t.qualification, qc.category_id) then b.designation || '/' || 'STAFF' || '/' || 'JM 2' when b.designation_id = 7 and exists (select t.emp_code, max(t.year_pass), t.qualification, qc.category_id from employ_qualification_dtl t, qualification_master qm, qualification_category qc where t.emp_code = a.emp_code and qm.qualification_id = t.qualification and qc.category_id = qm.category_id and qc.category_id IN (5, 6, 8) group by t.emp_code, t.qualification, qc.category_id) then b.designation || '/' || 'STAFF' || '/' || 'JM 3' when b.designation_id = 7 and exists (select t.emp_code, max(t.year_pass), t.qualification, qc.category_id from employ_qualification_dtl t, qualification_master qm, qualification_category qc where t.emp_code = a.emp_code and qm.qualification_id = t.qualification and qc.category_id = qm.category_id and qc.category_id IN (2) group by t.emp_code, t.qualification, qc.category_id) then b.designation || '/' || 'JR. MANAGEMENT' || '/' || 'JM 5' end,c.dep_name ,d.branch_name from employee_master a,designation_master b,department_mst c,branch_master_all d where a.designation_id=b.designation_id and a.department_id=c.dep_id and a.branch_id=d.branch_id and a.emp_code=" & Me.CurrCode & " union select a.emp_code,a.emp_name,a.join_dt,case when b.designation_id <> 7 then b.designation || '/' || b.ctgry || '/' || b.ctgry_code when b.designation_id = 7 and exists (select t.emp_code, max(t.year_pass), t.qualification, qc.category_id from employ_qualification_dtl t, qualification_master qm, qualification_category qc where t.emp_code = a.emp_code and qm.qualification_id = t.qualification and qc.category_id = qm.category_id and qc.category_id IN (4, 3) group by t.emp_code, t.qualification, qc.category_id) then b.designation || '/' || 'JR. MANAGEMENT' || '/' || 'JM 4' when b.designation_id = 7 and exists (select t.emp_code, max(t.year_pass), t.qualification, qc.category_id from employ_qualification_dtl t, qualification_master qm, qualification_category qc where t.emp_code = a.emp_code and qm.qualification_id = t.qualification and qc.category_id = qm.category_id and qc.category_id IN (7) group by t.emp_code, t.qualification, qc.category_id) then b.designation || '/' || 'STAFF' || '/' || 'JM 2' when b.designation_id = 7 and exists (select t.emp_code, max(t.year_pass), t.qualification, qc.category_id from employ_qualification_dtl t, qualification_master qm, qualification_category qc where t.emp_code = a.emp_code and qm.qualification_id = t.qualification and qc.category_id = qm.category_id and qc.category_id IN (5, 6, 8) group by t.emp_code, t.qualification, qc.category_id) then b.designation || '/' || 'STAFF' || '/' || 'JM 3' when b.designation_id = 7 and exists (select t.emp_code, max(t.year_pass), t.qualification, qc.category_id from employ_qualification_dtl t, qualification_master qm, qualification_category qc where t.emp_code = a.emp_code and qm.qualification_id = t.qualification and qc.category_id = qm.category_id and qc.category_id IN (2) group by t.emp_code, t.qualification, qc.category_id) then b.designation || '/' || 'JR. MANAGEMENT' || '/' || 'JM 5' end,c.dep_name ,d.branch_name from employee_master a,designation_master b,department_mst c,before_completion d where a.designation_id=b.designation_id and a.department_id=c.dep_id and a.branch_id=d.old_id and d.branch_id is null and a.emp_code=" & Me.CurrCode).Tables(0)
            dt1 = oh.ExecuteDataSet("select a.emp_code, a.emp_name, a.join_dt, case when b.designation_id <> 7 then b.designation || '/' || b.ctgry || '/' || b.ctgry_code when b.designation_id = 7 and exists (select t.emp_code, max(t.year_pass), t.qualification, qc.category_id from employ_qualification_dtl t, qualification_master qm, qualification_category qc where t.emp_code = a.emp_code and qm.qualification_id = t.qualification and qc.category_id = qm.category_id and qc.category_id IN (4, 3) group by t.emp_code, t.qualification, qc.category_id) then b.designation || '/' || 'JR. MANAGEMENT' || '/' || 'JM 4' when b.designation_id = 7 and exists (select t.emp_code, max(t.year_pass), t.qualification, qc.category_id from employ_qualification_dtl t, qualification_master qm, qualification_category qc where t.emp_code = a.emp_code and qm.qualification_id = t.qualification and qc.category_id = qm.category_id and qc.category_id IN (7) group by t.emp_code, t.qualification, qc.category_id) then b.designation || '/' || 'STAFF' || '/' || 'JM 2' when b.designation_id = 7 and exists (select t.emp_code, max(t.year_pass), t.qualification, qc.category_id from employ_qualification_dtl t, qualification_master qm, qualification_category qc where t.emp_code = a.emp_code and qm.qualification_id = t.qualification and qc.category_id = qm.category_id and qc.category_id IN (5, 6, 8) group by t.emp_code, t.qualification, qc.category_id) then b.designation || '/' || 'STAFF' || '/' || 'JM 3' when b.designation_id = 7 and exists (select t.emp_code, max(t.year_pass), t.qualification, qc.category_id from employ_qualification_dtl t, qualification_master qm, qualification_category qc where t.emp_code = a.emp_code and qm.qualification_id = t.qualification and qc.category_id = qm.category_id and qc.category_id IN (2) group by t.emp_code, t.qualification, qc.category_id) then b.designation || '/' || 'JR. MANAGEMENT' || '/' || 'JM 5' else b.designation || '/' || '-----' || '/' || '---' end, c.dep_name, d.branch_name from employee_master a, designation_master b, department_mst c, branch_master_all d where a.designation_id = b.designation_id and a.department_id = c.dep_id and a.branch_id = d.branch_id and a.emp_code = " & Me.CurrCode & " union select a.emp_code, a.emp_name, a.join_dt, case when b.designation_id <> 7 then b.designation || '/' || b.ctgry || '/' || b.ctgry_code when b.designation_id = 7 and exists (select t.emp_code, max(t.year_pass), t.qualification, qc.category_id from employ_qualification_dtl t, qualification_master qm, qualification_category qc where t.emp_code = a.emp_code and qm.qualification_id = t.qualification and qc.category_id = qm.category_id and qc.category_id IN (4, 3) group by t.emp_code, t.qualification, qc.category_id) then b.designation || '/' || 'JR. MANAGEMENT' || '/' || 'JM 4' when b.designation_id = 7 and exists (select t.emp_code, max(t.year_pass), t.qualification, qc.category_id from employ_qualification_dtl t, qualification_master qm, qualification_category qc where t.emp_code = a.emp_code and qm.qualification_id = t.qualification and qc.category_id = qm.category_id and qc.category_id IN (7) group by t.emp_code, t.qualification, qc.category_id) then b.designation || '/' || 'STAFF' || '/' || 'JM 2' when b.designation_id = 7 and exists (select t.emp_code, max(t.year_pass), t.qualification, qc.category_id from employ_qualification_dtl t, qualification_master qm, qualification_category qc where t.emp_code = a.emp_code and qm.qualification_id = t.qualification and qc.category_id = qm.category_id and qc.category_id IN (5, 6, 8) group by t.emp_code, t.qualification, qc.category_id) then b.designation || '/' || 'STAFF' || '/' || 'JM 3' when b.designation_id = 7 and exists (select t.emp_code, max(t.year_pass), t.qualification, qc.category_id from employ_qualification_dtl t, qualification_master qm, qualification_category qc where t.emp_code = a.emp_code and qm.qualification_id = t.qualification and qc.category_id = qm.category_id and qc.category_id IN (2) group by t.emp_code, t.qualification, qc.category_id) then b.designation || '/' || 'JR. MANAGEMENT' || '/' || 'JM 5' else b.designation || '/' || '-----' || '/' || '---' end, c.dep_name, d.branch_name from employee_master a, designation_master b, department_mst c, before_completion d where a.designation_id = b.designation_id and a.department_id = c.dep_id and a.branch_id = d.old_id and d.branch_id is null and a.emp_code = " & Me.CurrCode).Tables(0)

        Else
            dt1 = oh.ExecuteDataSet("select a.emp_code,a.emp_name,a.join_dt,b.designation,c.dep_name ,d.branch_name from employee_master a,designation_master b,department_mst c,branch_master_all d where a.designation_id=b.designation_id and a.department_id=c.dep_id and a.branch_id=d.branch_id and a.emp_code=" & Me.CurrCode & " union select a.emp_code,a.emp_name,a.join_dt,b.designation,c.dep_name ,d.branch_name from employee_master a,designation_master b,department_mst c,before_completion d where a.designation_id=b.designation_id and a.department_id=c.dep_id and a.branch_id=d.old_id and d.branch_id is null and a.emp_code=" & Me.CurrCode).Tables(0)
        End If
        pq = oh.ExecuteDataSet("select t.*  from emp_new_old_all t where (t.new_code=" & Me.CurrCode & " or t.old_code=" & Me.CurrCode & " )").Tables(0)
        '//-=-===-=-=-=- End of Modi in 220510 =-=-=-=-=-=-=-=-=-==-//

        'If Session("branch_id") = 0 Then
        '    'Dim name As String = "select a.leave_frdate,a.leave_todate,a.leave_days,b.leave_abbr,a.leave_reason from employ_leave_dtl a,leave_master b where a.leave_id=b.leave_id and a.leave_process_id not in (0,3) and a.status=1 and a.emp_code=" & Request.QueryString.Get("emp_code") & "and to_date(leave_frdate)>='" & Request.QueryString.Get("fdt") & "' and to_date(leave_todate)<='" & Request.QueryString.Get("tdt") & "' order by to_date(leave_frdate)"
        '    'dt = oh.ExecuteDataSet(name).Tables(0)
        '    dt1 = oh.ExecuteDataSet("select a.emp_code,a.emp_name,a.join_dt,b.designation,c.dep_name ,d.branch_name from employee_master a,designation_master b,department_mst c,branch_master d where a.designation_id=b.designation_id and a.department_id=c.dep_id and a.branch_id=d.branch_id and a.emp_code=" & Request.QueryString.Get("emp_code") & " union select a.emp_code,a.emp_name,a.join_dt,b.designation,c.dep_name ,d.branch_name from employee_master a,designation_master b,department_mst c,before_completion d where a.designation_id=b.designation_id and a.department_id=c.dep_id and a.branch_id=d.old_id and d.branch_id is null and a.emp_code=" & Request.QueryString.Get("emp_code")).Tables(0)
        '    pq = oh.ExecuteDataSet("select t.*  from emp_new_old_all t where (t.new_code=" & Request.QueryString.Get("emp_code") & " or t.old_code=" & Request.QueryString.Get("emp_code") & " )").Tables(0)

        'Else

        '    pq = oh.ExecuteDataSet("select t.*  from emp_new_old_all t where (t.new_code=" & ar(0) & " or t.old_code=" & ar(0) & " )").Tables(0)

        '    'Dim name As String = "select a.leave_frdate,a.leave_todate,a.leave_days,b.leave_abbr,a.leave_reason from employ_leave_dtl a,leave_master b where a.leave_id=b.leave_id and a.leave_process_id not in (0,3) and a.status=1 and a.emp_code=" & ar(0) & "and to_date(leave_frdate)>='" & Request.QueryString.Get("fdt") & "' and to_date(leave_todate)<='" & Request.QueryString.Get("tdt") & "' order by to_date(leave_frdate)"
        '    'dt = oh.ExecuteDataSet(name).Tables(0)
        '    dt1 = oh.ExecuteDataSet("select a.emp_code,a.emp_name,a.join_dt,b.designation,c.dep_name ,d.branch_name from employee_master a,designation_master b,department_mst c,branch_master d where a.designation_id=b.designation_id and a.department_id=c.dep_id and a.branch_id=d.branch_id and a.emp_code=" & ar(0) & " union select a.emp_code,a.emp_name,a.join_dt,b.designation,c.dep_name ,d.branch_name from employee_master a,designation_master b,department_mst c,before_completion d where a.designation_id=b.designation_id and a.department_id=c.dep_id and a.branch_id=d.old_id and d.branch_id is null and a.emp_code=" & ar(0)).Tables(0)
        'End If

        Dim at As DataRow
        Dim assettab As New Table
        Dim trt1 As New TableRow
        Dim tct1 As New TableCell
        tct1.ColumnSpan = 7

        tct1.HorizontalAlign = HorizontalAlign.Center
        tct1.Text = "<b><font size=4 >  " & frm & "  </font></b>"
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

        Dim d1, d2, d3, d4 As New TableRow
        Dim d10, d11, d12, d13, d14, d15, d20, d21, d22, d23, d24, d25, d30, d31, d32, d33, d34, d35, d36, d37, d38, d39, d40, d41 As New TableCell
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
        d22.Text = Format(pq.Rows(0)(3), "dd/MMM/yyyy")
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
        If Session("firm_id") = 28 Then
            d36.Text = "&nbsp"
            d4.Cells.Add(d36)
            d37.Text = "Des. Cat:"
            d4.Cells.Add(d37)
            d38.Text = dt1.Rows(0)(3).ToString().Split("/")(1)
            d4.Cells.Add(d38)
            d39.Text = "&nbsp"
            d4.Cells.Add(d39)
            d40.Text = "Cat Code:"
            d4.Cells.Add(d40)
            d41.Text = dt1.Rows(0)(3).ToString().Split("/")(2)
            d4.Cells.Add(d41)
        End If
        assettab.Rows.Add(d1)
        assettab.Rows.Add(d2)
        assettab.Rows.Add(d3)
        assettab.Rows.Add(d4)
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
        Next

        Dim line110 As New TableRow
        Dim line1101 As New TableCell
        line1101.ColumnSpan = 7
        line1101.Text = "<hr align=center width=100% >"
        line110.Controls.Add(line1101)
        assettab.Controls.Add(line110)

        'Dim n As New TableRow
        'Dim n00 As New TableCell
        'Dim n01 As New TableCell
        'Dim n0 As New TableCell
        'n0.Font.Size = 8
        'Dim n1 As New TableCell
        'n1.Font.Size = 8
        'Dim n2 As New TableCell
        'n2.Font.Size = 8
        'Dim n3 As New TableCell
        'n3.Font.Size = 10
        'n00.Text = "&nbsp"
        'n.Cells.Add(n00)
        'n0.Text = "&nbsp"
        'n.Cells.Add(n0)
        'n1.Text = "<B>Total&nbspLeave&nbspTaken:"
        'n.Cells.Add(n1)
        'n2.Text = "&nbsp"
        'n.Cells.Add(n2)
        'n3.Text = "<B>&nbsp&nbsp&nbsp" + CStr(c)
        'n3.HorizontalAlign = HorizontalAlign.Center
        'n.Cells.Add(n3)
        ''n01.Text = "<B>" & FormatNumber(totalamt, 2)
        ''n01.HorizontalAlign = HorizontalAlign.Right
        ''n01.Font.Size = 8
        ''n.Cells.Add(n01)
        'assettab.Rows.Add(n)
        'Dim line210 As New TableRow
        'Dim line2101 As New TableCell
        'line2101.ColumnSpan = 7
        'line2101.Text = "<hr align=center width=100% >"
        'line210.Controls.Add(line2101)
        'assettab.Controls.Add(line210)
        Me.pnl_leav.Controls.Add(assettab)


    End Sub
End Class

Imports System.Data
Imports System.Data.OracleClient
Partial Class leave_leave_rpt_977aeed57607
    Inherits System.Web.UI.Page
    Dim name, ar(), head, dp As String
    Dim CurrCode, oldCode, oldCnt As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt, dt1, dt2 As New DataTable
        Dim oh As New Helper.Oracle.OracleHelper
        'If Request.QueryString("empcode") = 0 Then
        '    head = "SHIFT DETAILS OF FROM " & Request.QueryString.Get("fdt") & " TO " & Request.QueryString.Get("tdt")
        'Else
        '    Dim dtb As DataTable = oh.ExecuteDataSet("select emp_name||'('||emp_code||')' from employee_master where emp_code=" & Request.QueryString("empcode") & "").Tables(0)
        '    head = "SHIFT DETAILS OF " & dtb.Rows(0)(0) & " FROM " & Request.QueryString.Get("fdt") & " TO " & Request.QueryString.Get("tdt")
        'End If
        Dim dtba As DataTable = oh.ExecuteDataSet("select EMP_name from EMPLOYEE_MASTER where EMP_CODE=" & Request.QueryString("EMP") & "").Tables(0)
        dp = dtba.Rows(0)(0)
        head = "BRANCH VISIT PUNCH REPORT OF " & dtba.Rows(0)(0) & " FROM " & Request.QueryString.Get("fdt") & " TO " & Request.QueryString.Get("tdt")
        Dim pq As DataTable
        Dim fid As Integer = Session("firm_id")
        Dim frm As String = Session("firm_name")
        Dim fdt As String = Request.QueryString.Get("fdt")
        Dim tdt As String = Request.QueryString.Get("tdt")
        Dim emp As String = Request.QueryString.Get("emp")
        Dim firm As String = Session("firm_id")
        ar = Session("user_id").ToString.Split("!")
        Me.CurrCode = ar(0)

        '  name = "select to_char(curr_date) as day,decode(da.m_time,NULL,'----------',da.m_time) as morning_time,decode(e_time,NULL,'----------',e_time) as evening_time,case when da.M_TIME is not null then bm.branch_name else '-' end as bname, case when da.e_TIME is not null then bm1.branch_name else '-' end as ebname,(select firm_name from(select firm_name,firm_id from firm_master union all select firm_name,firm_id from masset.firm_master)where firm_id=da.FIRM_ID) as firm from tour_attendance da,employee_master em, time_tab bt1, time_tab bt2,employ_firm ef,branch_master bm,branch_master   bm1 where  em.emp_code=da.emp_code and  ef.firm_id='" & firm & "'   and ef.emp_code=em.emp_code and da.curr_date between '" & fdt & "' and '" & tdt & "' and bt1.shift_id=da.m_shift and bt2.shift_id=da.e_shift and da.M_BRANCH=bm.branch_id and da.E_BRANCH=bm1.branch_id and da.emp_code=" & emp & " and da.FIRM_ID<>4 union all select to_char(curr_date) as day,decode(da.m_time,NULL,'----------',da.m_time) as morning_time,decode(e_time,NULL,'----------',e_time) as evening_time,case when da.M_TIME is not null then bm.branch_name else '-' end as bname, case when da.e_TIME is not null then bm1.branch_name else '-' end as ebname,(select firm_name from(select firm_name,firm_id from firm_master union all select firm_name,firm_id from masset.firm_master)where firm_id=da.FIRM_ID) as firm from tour_attendance da,employee_master em, masset.time_tab bt1, masset.time_tab bt2,employ_firm ef,masset.branch_master bm,masset.branch_master   bm1 where  em.emp_code=da.emp_code and  ef.firm_id='" & firm & "'   and ef.emp_code=em.emp_code and da.curr_date between '" & fdt & "' and '" & tdt & "' and bt1.shift_id=da.m_shift and bt2.shift_id=da.e_shift and da.M_BRANCH=bm.branch_id and da.E_BRANCH=bm1.branch_id and da.emp_code=" & emp & " and da.FIRM_ID=4 order by 1"
        name = "select to_char(da.curr_date) as day, decode(da.m_time, NULL, '----------', da.m_time) as morning_time, decode(e_time, NULL, '----------', e_time) as evening_time, case when da.M_TIME is not null then bm.branch_name else '-' end as bname, case when da.e_TIME is not null then bm1.branch_name else '-' end as ebname, (select firm_name from (select firm_name, firm_id from firm_master union all select firm_name, firm_id from masset.firm_master) where firm_id = da.FIRM_ID) as firm from tour_attendance da, employee_master em, time_tab bt1, time_tab bt2, employ_firm ef, branch_master bm, branch_master bm1 where em.emp_code = da.emp_code and ef.firm_id = '" & firm & "' and ef.emp_code = em.emp_code and da.curr_date between to_date('" & fdt & "') and to_date('" & tdt & "') and bt1.shift_id = da.m_shift and bt2.shift_id = da.e_shift and da.M_BRANCH = bm.branch_id and da.E_BRANCH = bm1.branch_id and da.emp_code = " & emp & " and da.FIRM_ID <> 4 union all select to_char(da.curr_date) as day, decode(da.m_time, NULL, '----------', da.m_time) as morning_time, decode(e_time, NULL, '----------', e_time) as evening_time, case when da.M_TIME is not null then bm.branch_name else '-' end as bname, case when da.e_TIME is not null then bm1.branch_name else '-' end as ebname, (select firm_name from (select firm_name, firm_id from firm_master union all select firm_name, firm_id from masset.firm_master) where firm_id = da.FIRM_ID) as firm from tour_attendance da, employee_master em, masset.time_tab bt1, masset.time_tab bt2, employ_firm ef, masset.branch_master bm, masset.branch_master bm1 where em.emp_code = da.emp_code and ef.firm_id = '" & firm & "' and ef.emp_code = em.emp_code and da.curr_date between to_date('" & fdt & "') and to_date('" & tdt & "') and bt1.shift_id = da.m_shift and bt2.shift_id = da.e_shift and da.M_BRANCH = bm.branch_id and da.E_BRANCH = bm1.branch_id and da.emp_code = " & emp & " and da.FIRM_ID = 4 order by 1"
        dt = oh.ExecuteDataSet(name).Tables(0)

        Dim at As DataRow
        Dim assettab As New Table
        Dim trt1 As New TableRow
        trt1.BackColor = Drawing.Color.Beige
        Dim tct1 As New TableCell
        tct1.ColumnSpan = 10

        tct1.HorizontalAlign = HorizontalAlign.Center
        tct1.Text = "<b><font size=4 >  " & frm & "  </font></b>"
        trt1.Controls.Add(tct1)
        assettab.Controls.Add(trt1)

        Dim tr_br As New TableRow
        Dim tc_br As New TableCell
        tc_br.ColumnSpan = 10
        tc_br.HorizontalAlign = HorizontalAlign.Center
        'tc_br.Text = "<font size=2 ><B>Branch&nbspId:&nbsp" & Session("branch_id") & "&nbsp&nbspBranch&nbspName:&nbsp" & Session("branch_name") & "</B></font>"
        tr_br.Controls.Add(tc_br)
        assettab.Controls.Add(tr_br)

        Dim trt2 As New TableRow
        Dim tct2 As New TableCell
        tct2.ColumnSpan = 2
        tct2.Text = "<b><font size=2 >" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
        tct2.HorizontalAlign = HorizontalAlign.Left
        trt2.Controls.Add(tct2)
        Dim tct3 As New TableCell
        tct3.ColumnSpan = 2
        'tct3.Text = "<b><font size=2 >" & head & "</font></b>"
        tct3.HorizontalAlign = HorizontalAlign.Center
        trt2.Controls.Add(tct3)
        Dim tct4 As New TableCell
        tct4.ColumnSpan = 6
        tct4.Text = "<b><font size=2 >" & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
        tct4.HorizontalAlign = HorizontalAlign.Right
        trt2.Controls.Add(tct4)
        assettab.Controls.Add(trt2)

        Dim lineq1 As New TableRow
        Dim lineq11 As New TableCell
        lineq11.ColumnSpan = 10
        lineq1.BackColor = Drawing.Color.Bisque
        lineq11.HorizontalAlign = HorizontalAlign.Center
        lineq11.Text = "<b><font size=2 >" & head & "</font></b>"
        lineq1.Controls.Add(lineq11)
        assettab.Controls.Add(lineq1)






        Dim d1, d2, d3 As New TableRow
        Dim d10, d11, d12, d13, d14, d15, d20, d21, d22, d23, d24, d25, d30, d31, d32, d33, d34, d35 As New TableCell
        d10.Font.Size = 10
        d11.Font.Size = 10
        d12.Font.Size = 10
        d13.Font.Size = 10
        d14.Font.Size = 10
        d15.Font.Size = 10
        d20.Font.Size = 10
        d21.Font.Size = 10
        d22.Font.Size = 10
        d23.Font.Size = 10
        d24.Font.Size = 10
        d25.Font.Size = 10
        d30.Font.Size = 10
        d31.Font.Size = 10
        d32.Font.Size = 10
        d33.Font.Size = 10
        d34.Font.Size = 10
        d35.Font.Size = 10


        Dim line1 As New TableRow
        Dim line11 As New TableCell
        line11.ColumnSpan = 10
        line11.Text = "<hr align=center>"
        line1.Controls.Add(line11)
        assettab.Controls.Add(line1)
        assettab.Attributes.Add("align", "center")
        assettab.Attributes.Add("width", "100%")
        Dim s As New TableRow
        s.BorderStyle = BorderStyle.Inset
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
        s6.Font.Size = 10
        Dim s7 As New TableCell
        s7.Font.Size = 10
        Dim s8 As New TableCell
        s8.Font.Size = 10
        Dim s9 As New TableCell
        s9.Font.Size = 10
        Dim s10 As New TableCell
        s10.Font.Size = 10
        Dim s11 As New TableCell
        s11.Font.Size = 10
        Dim s12 As New TableCell
        s12.Font.Size = 10
        Dim s13 As New TableCell
        s13.Font.Size = 10
        Dim s14 As New TableCell
        s14.Font.Size = 10
        Dim s15 As New TableCell
        s15.Font.Size = 10

        's0.Text = "<b>SL.NO"
        's.Cells.Add(s0)
        s1.Text = "<b>DATE"
        s.Cells.Add(s1)
        s2.Text = "<b>MORNING TIME"
        s.Cells.Add(s2)
        s3.Text = "<b>EVENING TIME"
        s.Cells.Add(s3)
        's4.Text = "<b>REMARKS"
        's.Cells.Add(s4)
        s5.Text = "<b>MORNING BRANCH"
        s.Cells.Add(s5)
        's6.Text = "<b> SHIFT"
        's.Cells.Add(s6)
        's7.Text = "<b>DEPARTMENT NAME"
        's.Cells.Add(s7)
        's8.Text = "<b>ENTER DATE"
        's.Cells.Add(s8)
        's9.Text = "<b>ENTER BY"
        's.Cells.Add(s9)
        s10.Text = "<b>EVENING BRANCH"
        s.Cells.Add(s10)
        s11.Text = "<b>PUNCH FIRM"
        s.Cells.Add(s11)


        assettab.Rows.Add(s)
        Dim line10 As New TableRow
        Dim line101 As New TableCell
        line101.ColumnSpan = 10
        line101.Text = "<hr align=center >"
        line10.Controls.Add(line101)
        assettab.Controls.Add(line10)
        Dim c As Integer
        Dim d As Integer = 1
        If dt.Rows.Count <= 0 Then
            Dim cl_script1 As New StringBuilder
            cl_script1.Append(" alert('No data found!! ');")
			cl_script1.Append("    window.open('atterepo.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script1.ToString, True)
            Exit Sub
        End If
        For Each at In dt.Rows
            Dim m As New TableRow
            m.BackColor = Drawing.Color.Azure
            Dim m0 As New TableCell
            m0.Font.Size = 10
            Dim m1 As New TableCell
            m1.Font.Size = 10
            Dim m2 As New TableCell
            m2.Font.Size = 10
            Dim m3 As New TableCell
            m3.Font.Size = 10
            Dim m4 As New TableCell
            m4.Font.Size = 10
            Dim m5 As New TableCell
            m5.Font.Size = 10
            Dim m6 As New TableCell
            m6.Font.Size = 10
            Dim m7 As New TableCell
            m7.Font.Size = 10
            Dim m8 As New TableCell
            m8.Font.Size = 10
            Dim m9 As New TableCell
            m9.Font.Size = 10
            Dim m10 As New TableCell
            m10.Font.Size = 10
            Dim m11 As New TableCell
            m11.Font.Size = 10

            'm0.Text = d
            'm.Cells.Add(m0)
            m1.Text = at(0)
            m.Cells.Add(m1)

            m2.Text = at(1)
            m.Cells.Add(m2)

            m3.Text = at(2)
            m.Cells.Add(m3)

            'm4.Text = at(3)
            'm.Cells.Add(m4)

            m5.Text = at(3)
            m.Cells.Add(m5)

            m6.Text = at(4)
            m.Cells.Add(m6)

            m7.Text = at(5)
            m.Cells.Add(m7)

            'm8.Text = at(7)
            'm.Cells.Add(m8)

            'm9.Text = at(8)
            'm.Cells.Add(m9)

            'm10.Text = at(9)
            'm.Cells.Add(m10)

            'm11.Text = at(10)
            'm.Cells.Add(m11)

            d = d + 1
            assettab.Rows.Add(m)
        Next
        Dim line110 As New TableRow
        Dim line1101 As New TableCell
        line1101.ColumnSpan = 10
        'line1101.Text = "<hr align=center ><br>"
        line110.Controls.Add(line1101)
        assettab.Controls.Add(line110)
        Me.pnl_leav.Controls.Add(assettab)
    End Sub
End Class

Imports system.data
Imports System.Data.OracleClient

Partial Class bilupromotiontfr_viewpromotionrepo_dbcbf8e93761
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim sql, sql1, sql3, sql15 As String
    Dim oh As New Helper.Oracle.OracleHelper
    Dim post1, post2, post3, Join, cd As String
    Dim cas, cast, sic, sict, ear, eart As Integer
    Dim dt6 As DataTable
    Dim dt3, dt15, dt8, dt11, dt12, dt25, dt26, DT27 As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim frm = Session("firm_name").ToString
        Dim frID = Session("firm_ID").ToString
        DT27 = oh.ExecuteDataSet("SELECT F.FIRM_ABBR FROM FIrm_MASTER F WHERE F.FIRM_id=" & frID & "").Tables(0)
        Dim FRR As String = DT27.Rows(0)(0)
        Dim tfrabh, tfrbh, tfrnom, post1, post2, post3, decision, sql5, sql15 As String
        Dim dh As New DataTable
        dh = oh.ExecuteDataSet("select to_char(sysdate,'DD')||to_char(sysdate,'MON') from dual").Tables(0)
        post1 = "A.B.H (G)"
        post2 = "B.H (G)"
        post3 = "B.H(H)"
        ''''''''''''''---------KRISHNADAS changed for maben(Bug in module)
        Dim fdt, newdat, trndt As String
        Dim nwdat(), trandt(), pos(), des(), dep(), br(), fr(), salr() As String
        fdt = Request.QueryString("from_date")

        Dim arr As Array
        arr = fdt.Split("|")

        'olddat = Request.QueryString.Get("oddat")
        newdat = Request.QueryString.Get("newdat")
        'oldat = olddat.ToString.Split("|")
        nwdat = newdat.ToString.Split("|")
        trndt = Request.QueryString.Get("trandt")
        trandt = trndt.ToString.Split("|")
        pos = nwdat(0).ToString.Split("*")
        des = nwdat(1).ToString.Split("*")
        dep = nwdat(2).ToString.Split("*")
        br = nwdat(3).ToString.Split("*")
        fr = nwdat(4).ToString.Split("*")
        salr = nwdat(5).ToString.Split("*")
        'Dim dtq As New Date
        'dtq = trandt(1)
        Dim w As String
        Dim st As Date = trandt(1)
        w = st.DayOfWeek.ToString
        If (trandt(2) = 1) Then

            tfrabh = "TWP/ABH /" + dh.Rows(0)(0)
            tfrbh = "TWP/BH/" + dh.Rows(0)(0)
            tfrnom = "TWP/NOR/" + dh.Rows(0)(0)

        Else

            tfrabh = "TWD/ABH /" + dh.Rows(0)(0)
            tfrbh = "TWD/BH/" + dh.Rows(0)(0)
            tfrnom = "TWD/NOR/" + dh.Rows(0)(0)
        End If



        '------------------------------------------------------------------------------------------
        Dim dt, dt1, dt2, dt3, dt4, dt5, dt6, dt7 As New DataTable
        Dim saldiff As New Integer
        Dim oldfmnm As String

        Dim tb As New Table
        tb.Attributes.Add("width", "90%")
        tb.Attributes.Add("align", "center")

        'header---------------------------------------------------------------------------------
        sql = "select a.firm_name from firm_master a,employ_firm b where a.firm_id=b.firm_id and b.emp_code=" & arr(0)
        dt = oh.ExecuteDataSet(sql).Tables(0)
        oldfmnm = dt.Rows(0)(0)

        sql = "select emp_name,join_dt,branch_id from employee_master where emp_code=" & arr(0)
        dt1 = oh.ExecuteDataSet(sql).Tables(0)


        Dim tr As New TableRow
        Dim tc As New TableCell
        tr.Font.Size = 8
        tc.Attributes.Add("width", "100%")
        tc.ColumnSpan = 10
        tc.HorizontalAlign = HorizontalAlign.Center
        'tc.Text = "<font size=2 color=darkblue><b>" & dt.Rows(0)(0) & "</b></font>"   'firm_name
        tc.Text = "<font size=3 color=darkblue><b>" & frm & "</b></font>"   'firm_name
        tr.Controls.Add(tc)
        tb.Controls.Add(tr)

        Dim tfrno As Integer
        Dim tfrtp As String

        'sql = "select tfr_number from employ_transfer_dtl where emp_code=" & arr(0) & " and to_date(enter_dt)=to_date(sysdate)"
        'dt = oh.ExecuteDataSet(sql).Tables(0)
        'tfrno = dt.Rows(0)(0)

        Dim dt34 As DataTable
        If Session("firm_id") = 24 Then
            dt34 = oh.ExecuteDataSet("select post_name from post_mst_jwell where post_id=" & pos(0) & "").Tables(0)
        Else
            dt34 = oh.ExecuteDataSet("select post_name from post_mst where post_id=" & pos(0) & "").Tables(0)
        End If
        If post1 = dt34.Rows(0)(0) Then
            tfrtp = "" & FRR & "/HRM-P/" & tfrabh & "/" & tfrno

        ElseIf post2 = dt34.Rows(0)(0) Then
            tfrtp = "" & FRR & "/HRM-P/" & tfrbh & "/" & tfrno

        Else
            tfrtp = "" & FRR & "/HRM-P/" & tfrnom & "/" & tfrno

        End If



        'If post1 = pos(0) Then
        '    tfrtp = "MAGRO/HRM-P/" & tfrabh & "/" & tfrno

        'ElseIf post2 = pos(0) Then
        '    tfrtp = "MAGRO/HRM-P/" & tfrbh & "/" & tfrno

        'Else
        '    tfrtp = "MAGRO/HRM-P/" & tfrnom & "/" & tfrno

        'End If


        Dim tra As New TableRow
        tra.Font.Size = 8
        Dim tca As New TableCell
        tca.Attributes.Add("width", "100%")
        tca.ColumnSpan = 10
        tca.HorizontalAlign = HorizontalAlign.Center
        tca.Text = "<font size=2 color=darkblue><b>" & tfrtp & "</b></font>"   'firm_name
        tra.Controls.Add(tca)
        tb.Controls.Add(tra)



        Dim tr1 As New TableRow
        tr1.Font.Size = 8
        Dim tc1 As New TableCell
        tc1.Attributes.Add("width", "100%")
        tc1.ColumnSpan = 10
        tc1.HorizontalAlign = HorizontalAlign.Center
        tc1.Text = "<font size=2 color=darkblue>Regd.Office&nbsp;&nbsp;&nbsp;Manappuram&nbsp;House,&nbsp;&nbsp;&nbsp;V/104,&nbsp;&nbsp;&nbsp;Valappad-680576</font>"
        tr1.Controls.Add(tc1)
        tb.Controls.Add(tr1)

        Dim tr2 As New TableRow
        Dim tc2 As New TableCell
        tr2.Font.Size = 8
        tc2.Attributes.Add("width", "100%")
        tc2.ColumnSpan = 10
        tc2.HorizontalAlign = HorizontalAlign.Center
        tc2.Text = "<font size=2 color=darkblue>DEPARTMENT OF HUMAN RESOURCE MANAGEMENT</font>"
        tr2.Controls.Add(tc2)
        tb.Controls.Add(tr2)


        Dim tr3 As New TableRow
        Dim tc31 As New TableCell
        tr3.Font.Size = 8
        tc31.Attributes.Add("width", "50%")
        tc31.ColumnSpan = 5
        tc31.HorizontalAlign = HorizontalAlign.Left
        tc31.Text = "<font size=2 color=darkblue>Time&nbsp:" & Format(Date.Now, "hh:mm:ss") & "</font>"
        tr3.Controls.Add(tc31)

        Dim tc32 As New TableCell
        tc32.Attributes.Add("width", "50%")
        tc32.ColumnSpan = 5
        tc32.HorizontalAlign = HorizontalAlign.Right
        tc32.Text = "<font size=2 color=darkblue>Date&nbsp:" & Format(Date.Now, "dd/MMM/yyyy") & "</font>"
        tr3.Controls.Add(tc32)
        tb.Controls.Add(tr3)

        If (trandt(2) = 1) Then

            decision = "PROMOTION"

            Dim tr4 As New TableRow
            tr4.Font.Size = 8
            Dim tc4 As New TableCell
            tc4.Attributes.Add("width", "100%")
            tc4.ColumnSpan = 10
            tc4.HorizontalAlign = HorizontalAlign.Center
            tc4.Text = "<font size=2 color=darkblue><b>DUPLICATE&nbsp;TRANSFER&nbsp;&nbsp;WITH&nbsp;" & decision & " &nbsp;</b></font>"
            tr4.Controls.Add(tc4)
            tb.Controls.Add(tr4)

        Else
            decision = "DEMOTION"


            Dim tr4 As New TableRow
            tr4.Font.Size = 8
            Dim tc4 As New TableCell
            tc4.Attributes.Add("width", "100%")
            tc4.ColumnSpan = 10
            tc4.HorizontalAlign = HorizontalAlign.Center
            tc4.Text = "<font size=2 color=darkblue><b>DUPLICATE&nbsp;TRANSFER&nbsp;&nbsp;WITH&nbsp;" & decision & " &nbsp;</b></font>"
            tr4.Controls.Add(tc4)
            tb.Controls.Add(tr4)

        End If



        Dim tr5a As New TableRow
        tr5a.Font.Size = 8
        Dim td5a As New TableCell
        td5a.ColumnSpan = 12
        td5a.HorizontalAlign = HorizontalAlign.Center
        td5a.Text = "<hr>"
        tr5a.Controls.Add(td5a)
        tb.Controls.Add(tr5a)

        Dim tr5 As New TableRow
        Dim tc51 As New TableCell
        tr5.Font.Size = 8
        tc51.Attributes.Add("width", "50%")
        tc51.ColumnSpan = 3
        tc51.HorizontalAlign = HorizontalAlign.Left
        tc51.Text = "<font size=2 color=darkblue>Employee&nbsp;Name&nbsp;&nbsp;</font>"
        tr5.Controls.Add(tc51)


        Dim tc52a As New TableCell
        tc52a.Attributes.Add("width", "50%")
        tc52a.ColumnSpan = 1
        tc52a.HorizontalAlign = HorizontalAlign.Center
        tc52a.Text = "<font size=2 color=darkblue>-</font>"
        tr5.Controls.Add(tc52a)

        Dim tc52 As New TableCell
        tc52.Attributes.Add("width", "50%")
        tc52.ColumnSpan = 7
        tc52.HorizontalAlign = HorizontalAlign.Left

        tc52.Text = "<font size=2 color=darkblue>" & UCase(dt1.Rows(0)(0)) & "</font>"
        tr5.Controls.Add(tc52)
        tb.Controls.Add(tr5)


        Dim tr6 As New TableRow
        Dim tc61 As New TableCell
        tr6.Font.Size = 8
        tc61.Attributes.Add("width", "50%")
        tc61.ColumnSpan = 3
        tc61.HorizontalAlign = HorizontalAlign.Left
        tc61.Text = "<font size=2 color=darkblue>Employee&nbsp;Code&nbsp;&nbsp;</font>"
        tr6.Controls.Add(tc61)


        Dim tc62a As New TableCell
        tc62a.Attributes.Add("width", "50%")
        tc62a.ColumnSpan = 1
        tc62a.HorizontalAlign = HorizontalAlign.Center
        tc62a.Text = "<font size=2 color=darkblue>-</font>"
        tr6.Controls.Add(tc62a)


        Dim tc62 As New TableCell
        tc62.Attributes.Add("width", "50%")
        tc62.ColumnSpan = 7
        tc62.HorizontalAlign = HorizontalAlign.Left
        tc62.Text = "<font size=2 color=darkblue>" & arr(0) & "</font>"
        tr6.Controls.Add(tc62)
        tb.Controls.Add(tr6)


        Dim tr5d As New TableRow
        Dim tc51d As New TableCell
        tr5d.Font.Size = 8
        tc51d.Attributes.Add("width", "50%")
        tc51d.ColumnSpan = 3
        tc51d.HorizontalAlign = HorizontalAlign.Left
        tc51d.Text = "<font size=2 color=darkblue>Date&nbsp;of&nbsp;Joining&nbsp;</font>"
        tr5d.Controls.Add(tc51d)

        Dim tc52g As New TableCell
        tc52g.Attributes.Add("width", "50%")
        tc52g.ColumnSpan = 1
        tc52g.HorizontalAlign = HorizontalAlign.Center
        tc52g.Text = "<font size=2 color=darkblue>-</font>"
        tr5d.Controls.Add(tc52g)

        dt8 = oh.ExecuteDataSet("select emp_code from employee_master_dtl where new_empcode =" & arr(0) & "").Tables(0)
        If (dt8.Rows.Count = 0) Then
            dt11 = oh.ExecuteDataSet("select join_dt from employee_master where emp_code=" & arr(0) & "").Tables(0)
            Join = Format(dt11.Rows(0)(0), "dd/MMM/yyyy")
        Else
            sql3 = "select a.join_dt from employee_master a where a.emp_code='" & dt8.Rows(0)(0) & "' "
            dt = oh.ExecuteDataSet(sql3).Tables(0)
            Join = Format(dt.Rows(0)(0), "dd/MMM/yyyy")
        End If

        Dim tc52h As New TableCell
        tc52h.Attributes.Add("width", "50%")
        tc52h.ColumnSpan = 7
        tc52h.HorizontalAlign = HorizontalAlign.Left
        tc52h.Text = "<font size=2 color=darkblue>" & Join & "</font>"
        tr5d.Controls.Add(tc52h)
        tb.Controls.Add(tr5d)



        Dim designation, brname, pbrname, da_flag, da_flg, deputid As String
        Dim brid, basic, cbasic, pbrid, da_value, da_val, basic1, cbasic1 As Integer
        Dim repotdt, relivdt, entrdt As Date


        'sql = "select designation from designation_master where designation_id=" & des(3)
        'dt = oh.ExecuteDataSet(sql).Tables(0)
        'designation = dt.Rows(0)(0)

        'sql = "select branch_id from employ_transfer_dtl where branch_id in (select branch_id from branch_master union select old_id from before_completion where branch_id is null) and (to_dt in (select max(to_dt) from employ_transfer_dtl where emp_code=" & arr(0) & " and status_id in (1,8)) or to_dt is null) and status_id in (1,8) and emp_code=" & arr(0)
        'dt = oh.ExecuteDataSet(sql).Tables(0)
        'brid = dt.Rows(0)(0)

        'sql = "select branch_name from branch_master where branch_id=" & brid & " union select branch_name from before_completion where branch_id is null and old_id=" & brid
        'dt = oh.ExecuteDataSet(sql).Tables(0)
        'brname = dt.Rows(0)(0)



        sql = "select department_id,post_id,relieve_dt,report_dt,enter_dt,deputation_id from employ_transfer_dtl where status_id in (1,8) and to_dt is null and emp_code=" & arr(0)
        dt = oh.ExecuteDataSet(sql).Tables(0)


        deputid = dt.Rows(0)(5)

        sql = "select a.from_dt,a.basic_pay ,b.designation,a.da_flag,a.designation_id from employ_promotion_dtl a ,designation_master b where a.from_dt in (select max(from_dt) from employ_promotion_dtl where status_id in (1,7,8,11) and emp_code=" & arr(0) & ") and a.designation_id=b.designation_id and a.status_id in (1,7,8,11) and a.emp_code=" & arr(0)
        dt = oh.ExecuteDataSet(sql).Tables(0)
        basic = dt.Rows(0)(1)
        da_flag = dt.Rows(0)(3)
        Dim dt22 As DataTable = oh.ExecuteDataSet("select payment_id from designation_master where designation_id=" & dt.Rows(0)(4) & "").Tables(0)
        If (da_flag = "T" And dt22.Rows(0)(0) <> 14) Then
            sql = "select value,from_dt,to_dt from da_index where from_dt=(select max(from_dt) from da_index where firm_id=" & frID & ") and to_dt is null"
            dt = oh.ExecuteDataSet(sql).Tables(0)
            da_value = dt.Rows(0)(0)
            basic1 = basic + da_value
        Else
            da_value = 0
            basic1 = basic + 0
        End If



        sql = "select a.basic_pay ,b.designation,a.da_flag,c.deputation_id from employ_promotion_dtl a,designation_master b,employ_transfer_dtl c where a.emp_code=c.emp_code and c.to_dt is null and a.to_dt is null and a.from_dt in (select max(from_dt) from employ_promotion_dtl where status_id in (1,7,8,11) and emp_code=" & arr(0) & ") and a.designation_id=b.designation_id and a.status_id in (1,7,8,11) and a.emp_code=" & arr(0)
        dt = oh.ExecuteDataSet(sql).Tables(0)
        cbasic = salr(0)

        Dim dt23 As DataTable = oh.ExecuteDataSet("select da_flag from employee_master where emp_code=" & arr(0) & "").Tables(0)
        da_flg = dt23.Rows(0)(0)

        If (da_flg = "T" And des(3) <> 14) Then
            sql = "select value,from_dt,to_dt from da_index where from_dt=(select max(from_dt) from da_index where to_dt is null) and to_dt is null"
            dt = oh.ExecuteDataSet(sql).Tables(0)
            da_val = dt.Rows(0)(0)
            cbasic1 = cbasic + da_val
        Else
            da_val = 0
            cbasic1 = cbasic + 0
        End If


        'leave_id =1 CASUAL LEAVE
        'leave_id =2 SICK LEAVE
        'leave_id =3 EARN LEAVE
        'leave_id =4 LOSS OF PAY



        Dim tr6d As New TableRow
        tr6d.Font.Size = 8
        Dim tc6d As New TableCell
        tc6d.Attributes.Add("width", "50%")
        tc6d.ColumnSpan = 3
        tc6d.HorizontalAlign = HorizontalAlign.Left
        tc6d.Text = "<font size=2 color=darkblue>Present&nbsp;Designation</font>"
        tr6d.Controls.Add(tc6d)

        Dim tc6e As New TableCell
        tc6e.Attributes.Add("width", "50%")
        tc6e.ColumnSpan = 1
        tc6e.HorizontalAlign = HorizontalAlign.Center
        tc6e.Text = "<font size=2 color=darkblue>-</font>"
        tr6d.Controls.Add(tc6e)

        Dim tc6f As New TableCell
        tc6f.Attributes.Add("width", "50%")
        tc6f.ColumnSpan = 7
        tc6f.HorizontalAlign = HorizontalAlign.Left
        tc6f.Text = "<font size=2 color=darkblue>" & arr(4) & "</font>"
        tr6d.Controls.Add(tc6f)
        tb.Controls.Add(tr6d)

        Dim tr7d As New TableRow
        Dim tc7d As New TableCell
        tr7d.Font.Size = 8
        tc7d.Attributes.Add("width", "50%")
        tc7d.ColumnSpan = 3
        tc7d.HorizontalAlign = HorizontalAlign.Left
        tc7d.Text = "<font size=2 color=darkblue>Present&nbsp;Branch</font>"
        tr7d.Controls.Add(tc7d)

        Dim tc7e As New TableCell
        tc7e.Attributes.Add("width", "50%")
        tc7e.ColumnSpan = 1
        tc7e.HorizontalAlign = HorizontalAlign.Center
        tc7e.Text = "<font size=2 color=darkblue>-</font>"
        tr7d.Controls.Add(tc7e)

        Dim tc7f As New TableCell
        tc7f.Attributes.Add("width", "50%")
        tc7f.ColumnSpan = 7
        tc7f.HorizontalAlign = HorizontalAlign.Left
        tc7f.Text = "<font size=2 color=darkblue>" & arr(3) & "</font>"
        tr7d.Controls.Add(tc7f)
        tb.Controls.Add(tr7d)

        Dim tr8d As New TableRow
        Dim tc8d As New TableCell
        tr8d.Font.Size = 8
        tc8d.Attributes.Add("width", "50%")
        tc8d.ColumnSpan = 3
        tc8d.HorizontalAlign = HorizontalAlign.Left
        tc8d.Text = "<font size=2 color=darkblue>Present&nbsp;Department&nbsp;and&nbsp;Post</font>"
        tr8d.Controls.Add(tc8d)

        Dim tc8e As New TableCell
        tc8e.Attributes.Add("width", "50%")
        tc8e.ColumnSpan = 1
        tc8e.HorizontalAlign = HorizontalAlign.Center
        tc8e.Text = "<font size=2 color=darkblue>-</font>"
        tr8d.Controls.Add(tc8e)

        Dim tc8f As New TableCell
        tc8f.Attributes.Add("width", "50%")
        tc8f.ColumnSpan = 7
        tc8f.HorizontalAlign = HorizontalAlign.Left
        tc8f.Text = "<font size=2 color=darkblue>" & arr(6) & " , " & arr(5) & "</font>"
        tr8d.Controls.Add(tc8f)
        tb.Controls.Add(tr8d)


        Dim tr9d As New TableRow
        tr9d.Font.Size = 8
        Dim tc9d As New TableCell
        tc9d.Attributes.Add("width", "50%")
        tc9d.ColumnSpan = 3
        tc9d.HorizontalAlign = HorizontalAlign.Left
        tc9d.Text = "<font size=2 color=darkblue>Proposed&nbsp;Designation</font>"
        tr9d.Controls.Add(tc9d)

        Dim tc9e As New TableCell
        tc9e.Attributes.Add("width", "50%")
        tc9e.ColumnSpan = 1
        tc9e.HorizontalAlign = HorizontalAlign.Center
        tc9e.Text = "<font size=2 color=darkblue>-</font>"
        tr9d.Controls.Add(tc9e)

        Dim tc9f As New TableCell
        tc9f.Attributes.Add("width", "50%")
        tc9f.ColumnSpan = 7
        tc9f.HorizontalAlign = HorizontalAlign.Left
        tc9f.Text = "<font size=2 color=darkblue>" & des(2) & " </font>"
        tr9d.Controls.Add(tc9f)
        tb.Controls.Add(tr9d)

        Dim tr10d As New TableRow
        Dim tc10d As New TableCell
        tr10d.Font.Size = 8
        tc10d.Attributes.Add("width", "50%")
        tc10d.ColumnSpan = 3
        tc10d.HorizontalAlign = HorizontalAlign.Left
        tc10d.Text = "<font size=2 color=darkblue>Proposed&nbsp;Branch</font>"
        tr10d.Controls.Add(tc10d)

        Dim tc10e As New TableCell
        tc10e.Attributes.Add("width", "50%")
        tc10e.ColumnSpan = 1
        tc10e.HorizontalAlign = HorizontalAlign.Center
        tc10e.Text = "<font size=2 color=darkblue>-</font>"
        tr10d.Controls.Add(tc10e)

        Dim tc10f As New TableCell
        tc10f.Attributes.Add("width", "50%")
        tc10f.ColumnSpan = 7
        tc10f.HorizontalAlign = HorizontalAlign.Left
        tc10f.Text = "<font size=2 color=darkblue>" & br(0) & " </font>"
        tr10d.Controls.Add(tc10f)
        tb.Controls.Add(tr10d)


        Dim tr11d As New TableRow
        Dim tc11d As New TableCell
        tr11d.Font.Size = 8
        tc11d.Attributes.Add("width", "50%")
        tc11d.ColumnSpan = 3
        tc11d.HorizontalAlign = HorizontalAlign.Left
        tc11d.Text = "<font size=2 color=darkblue>Proposed&nbsp;Department&nbsp;And&nbsp;Post</font>"
        tr11d.Controls.Add(tc11d)

        Dim tc11e As New TableCell
        tc11e.Attributes.Add("width", "50%")
        tc11e.ColumnSpan = 1
        tc11e.HorizontalAlign = HorizontalAlign.Center
        tc11e.Text = "<font size=2 color=darkblue>-</font>"
        tr11d.Controls.Add(tc11e)

        Dim tc11f As New TableCell
        tc11f.Attributes.Add("width", "50%")
        tc11f.ColumnSpan = 7
        tc11f.HorizontalAlign = HorizontalAlign.Left
        tc11f.Text = "<font size=2 color=darkblue>" & dep(1) & " , " & dt34.Rows(0)(0) & "</font>"
        tr11d.Controls.Add(tc11f)
        tb.Controls.Add(tr11d)


        Dim tr12d As New TableRow
        Dim tc12d As New TableCell
        tr12d.Font.Size = 8
        tc12d.Attributes.Add("width", "50%")
        tc12d.ColumnSpan = 3
        tc12d.HorizontalAlign = HorizontalAlign.Left
        tc12d.Text = "<font size=2 color=darkblue>Relieving&nbsp;Date</font>"
        tr12d.Controls.Add(tc12d)

        Dim tc12e As New TableCell
        tc12e.Attributes.Add("width", "50%")
        tc12e.ColumnSpan = 1
        tc12e.HorizontalAlign = HorizontalAlign.Center
        tc12e.Text = "<font size=2 color=darkblue>-</font>"
        tr12d.Controls.Add(tc12e)

        Dim tc12f As New TableCell
        tc12f.Attributes.Add("width", "50%")
        tc12f.ColumnSpan = 7
        tc12f.HorizontalAlign = HorizontalAlign.Left
        tc12f.Text = "<font size=2 color=darkblue>" & trandt(0) & "</font>"
        tr12d.Controls.Add(tc12f)
        tb.Controls.Add(tr12d)



        Dim tr13d As New TableRow
        Dim tc13d As New TableCell
        tr13d.Font.Size = 8
        tc13d.Attributes.Add("width", "50%")
        tc13d.ColumnSpan = 3
        tc13d.HorizontalAlign = HorizontalAlign.Left
        tc13d.Text = "<font size=2 color=darkblue>Reporting&nbsp;Date</font>"
        tr13d.Controls.Add(tc13d)

        Dim tc13e As New TableCell
        tc13e.Attributes.Add("width", "50%")
        tc13e.ColumnSpan = 1
        tc13e.HorizontalAlign = HorizontalAlign.Center
        tc13e.Text = "<font size=2 color=darkblue>-</font>"
        tr13d.Controls.Add(tc13e)

        Dim tc13f As New TableCell
        tc13f.Attributes.Add("width", "50%")
        tc13f.ColumnSpan = 7
        tc13f.HorizontalAlign = HorizontalAlign.Left
        tc13f.Text = "<font size=2 color=darkblue>" & trandt(1) & "</font>"
        tr13d.Controls.Add(tc13f)
        tb.Controls.Add(tr13d)


        Dim tr14d As New TableRow
        Dim tc14d As New TableCell
        tr14d.Font.Size = 8
        tc14d.Attributes.Add("width", "50%")
        tc14d.ColumnSpan = 3
        tc14d.HorizontalAlign = HorizontalAlign.Left
        tc14d.Text = "<font size=2 color=darkblue>Date&nbsp;Of&nbsp;Confirmation</font>"
        tr14d.Controls.Add(tc14d)

        Dim tc14e As New TableCell
        tc14e.Attributes.Add("width", "50%")
        tc14e.ColumnSpan = 1
        tc14e.HorizontalAlign = HorizontalAlign.Center
        tc14e.Text = "<font size=2 color=darkblue>-</font>"
        tr14d.Controls.Add(tc14e)

        '''''''''''''''''''''''''''''''''''''

        sql3 = "select basic_pay ,emp_type,da_flag from employee_master where emp_code=" & arr(0) & " and status_id=1 "
        dt3 = oh.ExecuteDataSet(sql3).Tables(0)

        If (dt3.Rows(0)(1) = 2) Then
            cd = "NOT CONFIRMED YET"
        Else

            dt8 = oh.ExecuteDataSet("select emp_code from employee_master_dtl where new_empcode= " & arr(0) & "").Tables(0)
            If (dt8.Rows.Count = 0) Then
                sql15 = "select join_dt from employee_master where emp_code=" & arr(0) & ""
                dt12 = oh.ExecuteDataSet(sql15).Tables(0)

                cd = Format(dt12.Rows(0)(0), "dd/MMM/yyyy")
                'cd = "NOT CONFIRMED YET"
            Else
                sql15 = "select join_dt from employee_master where emp_code=" & arr(0) & ""
                dt12 = oh.ExecuteDataSet(sql15).Tables(0)

                cd = Format(dt12.Rows(0)(0), "dd/MMM/yyyy")

            End If
        End If
        '''''''''''''''''''''''''''''''''''''''

        Dim tc14f As New TableCell
        tc14f.Attributes.Add("width", "50%")
        tc14f.ColumnSpan = 7
        tc14f.HorizontalAlign = HorizontalAlign.Left
        tc14f.Text = "<font size=2 color=darkblue>" & cd & "</font>"
        tr14d.Controls.Add(tc14f)
        tb.Controls.Add(tr14d)


        Dim tr15d As New TableRow
        Dim tc15d As New TableCell
        tr15d.Font.Size = 8
        tc15d.Attributes.Add("width", "50%")
        tc15d.ColumnSpan = 3
        tc15d.HorizontalAlign = HorizontalAlign.Left
        tc15d.Text = "<font size=2 color=darkblue>Present&nbsp;salary</font>"
        tr15d.Controls.Add(tc15d)

        Dim tc15e As New TableCell
        tc15e.Attributes.Add("width", "50%")
        tc15e.ColumnSpan = 1
        tc15e.HorizontalAlign = HorizontalAlign.Center
        tc15e.Text = "<font size=2 color=darkblue>-</font>"
        tr15d.Controls.Add(tc15e)

        Dim tc15f As New TableCell
        tc15f.Attributes.Add("width", "50%")
        tc15f.ColumnSpan = 7
        tc15f.HorizontalAlign = HorizontalAlign.Left
        tc15f.Text = "<font size=2 color=darkblue>Basic Pay(Rs." & basic & " ) + VDA(Rs." & da_value & " ) - Rs." & basic1 & "</font>"
        tr15d.Controls.Add(tc15f)
        tb.Controls.Add(tr15d)


        Dim tr16d As New TableRow
        Dim tc16d As New TableCell
        tr16d.Font.Size = 8
        tc16d.Attributes.Add("width", "50%")
        tc16d.ColumnSpan = 3
        tc16d.HorizontalAlign = HorizontalAlign.Left
        tc16d.Text = "<font size=2 color=darkblue>Proposed&nbsp;salary</font>"
        tr16d.Controls.Add(tc16d)

        Dim tc16e As New TableCell
        tc16e.Attributes.Add("width", "50%")
        tc16e.ColumnSpan = 1
        tc16e.HorizontalAlign = HorizontalAlign.Center
        tc16e.Text = "<font size=2 color=darkblue>-</font>"
        tr16d.Controls.Add(tc16e)

        Dim tc16f As New TableCell
        tc16f.Attributes.Add("width", "50%")
        tc16f.ColumnSpan = 7
        tc16f.HorizontalAlign = HorizontalAlign.Left
        tc16f.Text = "<font size=2 color=darkblue>(Basic Pay(Rs." & cbasic & " ) + VDA( Rs." & da_val & " )) - Rs." & cbasic1 & "</font>"
        tr16d.Controls.Add(tc16f)
        tb.Controls.Add(tr16d)

        Dim t17d As New TableRow
        Dim qq17d As New TableCell
        t17d.Font.Size = 8
        qq17d.Attributes.Add("width", "50%")
        qq17d.ColumnSpan = 3
        qq17d.HorizontalAlign = HorizontalAlign.Left
        qq17d.Text = "<BR>"
        t17d.Controls.Add(qq17d)
        tb.Controls.Add(t17d)


        Dim tr17d As New TableRow
        Dim tc17d As New TableCell
        tr17d.Font.Size = 8
        tc17d.Attributes.Add("width", "50%")
        tc17d.ColumnSpan = 3
        tc17d.HorizontalAlign = HorizontalAlign.Left
        tc17d.Text = "<font size=2 color=darkblue>LEAVE&nbsp;DETAILS</font>"
        tr17d.Controls.Add(tc17d)
        tb.Controls.Add(tr17d)

        Dim tr18d As New TableRow
        Dim tc18d As New TableCell
        tr18d.Font.Size = 8
        tc18d.Attributes.Add("width", "50%")
        tc18d.ColumnSpan = 3
        tc18d.HorizontalAlign = HorizontalAlign.Left
        tc18d.Text = "<font size=2 color=darkblue>****************************</font>"
        tr18d.Controls.Add(tc18d)
        tb.Controls.Add(tr18d)





        '*******************************bilu leave details****************************************8

        sql = "select emp_type from employee_master where emp_code=" & arr(0) & ""
        dt3 = oh.ExecuteDataSet(sql).Tables(0)

        dt25 = oh.ExecuteDataSet("select count(emp_code) from employee_master where emp_code=" & arr(0) & " and emp_type=1 and to_number(to_date('" & trandt(0) & "')-to_date(join_dt))>365").Tables(0)

        If (dt25.Rows(0)(0) = 1) Then
            sql5 = "select distinct case when to_char(process_date,'dd')<15 then to_number(to_char(process_date,'MM'))-1 else  to_number(to_char(process_date,'MM'))  end from employ_leave_master where emp_code=" & arr(0) & " "
            Dim dt88 As DataTable = oh.ExecuteDataSet("select nvl(sum(cas),0) as cs,nvl(sum(sick),0) as sk,nvl(sum(earn),0) as er,nvl(sum(lop),0) as lp from (select case when el.leave_id=1 then sum(el.leave_days) end as cas,case when el.leave_id=2 then sum(el.leave_days) end as sick,case when el.leave_id=3 then sum(el.leave_days) end as earn,case when el.leave_id=4 then sum(el.leave_days) end as lop from employ_leave_dtl el where el.emp_code=" & arr(0) & " and el.leave_process_id not in (0,3) and to_date(el.leave_frdate)>=to_date('01-jan-'||to_char(sysdate,'yyyy')) group by el.leave_id) ").Tables(0)
            dt6 = oh.ExecuteDataSet(sql5).Tables(0)
            sql15 = "select leave_days,leave_id from employ_leave_master where emp_code=" & arr(0) & ""
            Dim dt16 As DataTable = oh.ExecuteDataSet(sql15).Tables(0)
            Dim dr As DataRow
            For Each dr In dt16.Rows

                If (dr(1) = 1) Then

                    cast = 12 - dt6.Rows(0)(0)
                    cas = dr(0)
                End If
                If (dr(1) = 2) Then
                    sic = dr(0)
                    sict = 12 - dt6.Rows(0)(0)
                End If
                If (dr(1) = 3) Then
                    ear = dr(0)
                    eart = 12 - dt6.Rows(0)(0)
                End If
                ''-----   --------------------------------------------------
            Next
            Dim tr19d As New TableRow
            Dim tc19d As New TableCell
            tr19d.Font.Size = 8
            tc19d.Attributes.Add("width", "50%")
            tc19d.ColumnSpan = 3
            tc19d.HorizontalAlign = HorizontalAlign.Left
            tc19d.Text = "<font size=2 color=darkblue>TYPES&nbsp;OF&nbsp;LEAVE</font>"
            tr19d.Controls.Add(tc19d)

            Dim tc19e As New TableCell
            tc19e.Attributes.Add("width", "50%")
            tc19e.ColumnSpan = 3
            tc19e.HorizontalAlign = HorizontalAlign.Left
            tc19e.Text = "<font size=2 color=darkblue>CASUAL</font>"
            tr19d.Controls.Add(tc19e)

            Dim tc19f As New TableCell
            tc19f.Attributes.Add("width", "50%")
            tc19f.ColumnSpan = 3
            tc19f.HorizontalAlign = HorizontalAlign.Left
            tc19f.Text = "<font size=2 color=darkblue>EARNED</font>"
            tr19d.Controls.Add(tc19f)

            Dim tc19g As New TableCell
            tc19g.Attributes.Add("width", "50%")
            tc19g.ColumnSpan = 3
            tc19g.HorizontalAlign = HorizontalAlign.Left
            tc19g.Text = "<font size=2 color=darkblue>SICK</font>"
            tr19d.Controls.Add(tc19g)

            Dim tc19h As New TableCell
            tc19h.Attributes.Add("width", "50%")
            tc19h.ColumnSpan = 3
            tc19h.HorizontalAlign = HorizontalAlign.Left
            tc19h.Text = "<font size=2 color=darkblue>LOSS&nbsp;OF&nbsp;PAY</font>"
            tr19d.Controls.Add(tc19h)
            tb.Controls.Add(tr19d)

            Dim tr20d As New TableRow
            Dim tc20d As New TableCell
            tr20d.Font.Size = 8
            tc20d.Attributes.Add("width", "50%")
            tc20d.ColumnSpan = 3
            tc20d.HorizontalAlign = HorizontalAlign.Left
            tc20d.Text = "<font size=2 color=darkblue>AT&nbsp;THE&nbsp;BEGINING</font>"
            tr20d.Controls.Add(tc20d)


            Dim tc20e As New TableCell
            tc20e.Attributes.Add("width", "50%")
            tc20e.ColumnSpan = 3
            tc20e.HorizontalAlign = HorizontalAlign.Left
            tc20e.Text = "<font size=2 color=darkblue> " & cast & "</font>"
            tr20d.Controls.Add(tc20e)


            Dim tc20f As New TableCell
            tc20f.Attributes.Add("width", "50%")
            tc20f.ColumnSpan = 3
            tc20f.HorizontalAlign = HorizontalAlign.Left
            tc20f.Text = "<font size=2 color=darkblue>" & sict & "</font>"
            tr20d.Controls.Add(tc20f)


            Dim tc20g As New TableCell
            tc20g.Attributes.Add("width", "50%")
            tc20g.ColumnSpan = 3
            tc20g.HorizontalAlign = HorizontalAlign.Left
            tc20g.Text = "<font size=2 color=darkblue> " & eart & "</font>"
            tr20d.Controls.Add(tc20g)

            Dim tc20h As New TableCell
            tc20h.Attributes.Add("width", "50%")
            tc20h.ColumnSpan = 3
            tc20h.HorizontalAlign = HorizontalAlign.Left
            tc20h.Text = "<font size=2 color=darkblue>N.A</font>"
            tr20d.Controls.Add(tc20h)
            tb.Controls.Add(tr20d)


            Dim tr21d As New TableRow
            Dim tc21d As New TableCell
            tr21d.Font.Size = 8
            tc21d.Attributes.Add("width", "50%")
            tc21d.ColumnSpan = 3
            tc21d.HorizontalAlign = HorizontalAlign.Left
            tc21d.Text = "<font size=2 color=darkblue>AVAILED</font>"
            tr21d.Controls.Add(tc21d)




            Dim tc21e As New TableCell
            tc21e.Attributes.Add("width", "50%")
            tc21e.ColumnSpan = 3
            tc21e.HorizontalAlign = HorizontalAlign.Left
            tc21e.Text = "<font size=2 color=darkblue>" & dt88.Rows(0)(0) & "</font>"
            tr21d.Controls.Add(tc21e)


            Dim tc21f As New TableCell
            tc21f.Attributes.Add("width", "50%")
            tc21f.ColumnSpan = 3
            tc21f.HorizontalAlign = HorizontalAlign.Left
            tc21f.Text = "<font size=2 color=darkblue>" & dt88.Rows(0)(1) & "</font>"
            tr21d.Controls.Add(tc21f)



            Dim tc21g As New TableCell
            tc21g.Attributes.Add("width", "50%")
            tc21g.ColumnSpan = 3
            tc21g.HorizontalAlign = HorizontalAlign.Left
            tc21g.Text = "<font size=2 color=darkblue>" & dt88.Rows(0)(2) & "</font>"
            tr21d.Controls.Add(tc21g)


            Dim tc21h As New TableCell
            tc21h.Attributes.Add("width", "50%")
            tc21h.ColumnSpan = 3
            tc21h.HorizontalAlign = HorizontalAlign.Left
            tc21h.Text = "<font size=2 color=darkblue>" & dt88.Rows(0)(3) & "</font>"
            tr21d.Controls.Add(tc21h)
            tb.Controls.Add(tr21d)


            Dim tr22d As New TableRow
            Dim tc22d As New TableCell
            tr22d.Font.Size = 8
            tc22d.Attributes.Add("width", "50%")
            tc22d.ColumnSpan = 3
            tc22d.HorizontalAlign = HorizontalAlign.Left
            tc22d.Text = "<font size=2 color=darkblue>BALANCE</font>"
            tr22d.Controls.Add(tc22d)


            Dim tc22e As New TableCell
            tc22e.Attributes.Add("width", "50%")
            tc22e.ColumnSpan = 3
            tc22e.HorizontalAlign = HorizontalAlign.Left
            tc22e.Text = "<font size=2 color=darkblue>" & cas & "</font>"
            tr22d.Controls.Add(tc22e)


            Dim tc22f As New TableCell
            tc22f.Attributes.Add("width", "50%")
            tc22f.ColumnSpan = 3
            tc22f.HorizontalAlign = HorizontalAlign.Left
            tc22f.Text = "<font size=2 color=darkblue>" & sic & "</font>"
            tr22d.Controls.Add(tc22f)

            Dim tr22g As New TableRow
            Dim tc22g As New TableCell
            tr22g.Font.Size = 8
            tc22g.Attributes.Add("width", "50%")
            tc22g.ColumnSpan = 3
            tc22g.HorizontalAlign = HorizontalAlign.Left
            tc22g.Text = "<font size=2 color=darkblue>" & ear & "</font>"
            tr22d.Controls.Add(tc22g)


            Dim tc22h As New TableCell
            tc22h.Attributes.Add("width", "50%")
            tc22h.ColumnSpan = 3
            tc22h.HorizontalAlign = HorizontalAlign.Left
            tc22h.Text = "<font size=2 color=darkblue>NA</font>"
            tr22d.Controls.Add(tc22h)
            tb.Controls.Add(tr22d)
        Else
            Dim dt88 As DataTable = oh.ExecuteDataSet("select nvl(sum(cas),0) as cs,nvl(sum(sick),0) as sk,nvl(sum(earn),0) as er,nvl(sum(lop),0) as lp from (select case when el.leave_id=1 then sum(el.leave_days) end as cas,case when el.leave_id=2 then sum(el.leave_days) end as sick,case when el.leave_id=3 then sum(el.leave_days) end as earn,case when el.leave_id=4 then sum(el.leave_days) end as lop from employ_leave_dtl el where el.emp_code=" & arr(0) & " and el.leave_process_id not in (0,3) and to_date(el.leave_frdate)>=to_date('01-jan-'||to_char(sysdate,'yyyy')) group by el.leave_id) ").Tables(0)
            Dim tr19d As New TableRow
            Dim tc19d As New TableCell
            tr19d.Font.Size = 8
            tc19d.Attributes.Add("width", "50%")
            tc19d.ColumnSpan = 3
            tc19d.HorizontalAlign = HorizontalAlign.Left
            tc19d.Text = "<font size=2 color=darkblue>TYPES&nbsp;OF&nbsp;LEAVE</font>"
            tr19d.Controls.Add(tc19d)

            Dim tc19e As New TableCell
            tc19e.Attributes.Add("width", "50%")
            tc19e.ColumnSpan = 3
            tc19e.HorizontalAlign = HorizontalAlign.Left
            tc19e.Text = "<font size=2 color=darkblue>CASUAL</font>"
            tr19d.Controls.Add(tc19e)

            Dim tc19f As New TableCell
            tc19f.Attributes.Add("width", "50%")
            tc19f.ColumnSpan = 3
            tc19f.HorizontalAlign = HorizontalAlign.Left
            tc19f.Text = "<font size=2 color=darkblue>EARNED</font>"
            tr19d.Controls.Add(tc19f)

            Dim tc19g As New TableCell
            tc19g.Attributes.Add("width", "50%")
            tc19g.ColumnSpan = 3
            tc19g.HorizontalAlign = HorizontalAlign.Left
            tc19g.Text = "<font size=2 color=darkblue>SICK</font>"
            tr19d.Controls.Add(tc19g)

            Dim tc19h As New TableCell
            tc19h.Attributes.Add("width", "50%")
            tc19h.ColumnSpan = 3
            tc19h.HorizontalAlign = HorizontalAlign.Left
            tc19h.Text = "<font size=2 color=darkblue>LOSS&nbsp;OF&nbsp;PAY</font>"
            tr19d.Controls.Add(tc19h)
            tb.Controls.Add(tr19d)

            Dim tr20d As New TableRow
            Dim tc20d As New TableCell
            tr20d.Font.Size = 8
            tc20d.Attributes.Add("width", "50%")
            tc20d.ColumnSpan = 3
            tc20d.HorizontalAlign = HorizontalAlign.Left
            tc20d.Text = "<font size=2 color=darkblue>AT&nbsp;THE&nbsp;BEGINING</font>"
            tr20d.Controls.Add(tc20d)


            Dim tc20e As New TableCell
            tc20e.Attributes.Add("width", "50%")
            tc20e.ColumnSpan = 3
            tc20e.HorizontalAlign = HorizontalAlign.Left
            tc20e.Text = "<font size=2 color=darkblue> &nbsp-&nbsp Only one leave per month</font>"
            tr20d.Controls.Add(tc20e)


            Dim tc20f As New TableCell
            tc20f.Attributes.Add("width", "50%")
            tc20f.ColumnSpan = 3
            tc20f.HorizontalAlign = HorizontalAlign.Left
            tc20f.Text = "<font size=2 color=darkblue></font>"
            tr20d.Controls.Add(tc20f)


            Dim tc20g As New TableCell
            tc20g.Attributes.Add("width", "50%")
            tc20g.ColumnSpan = 3
            tc20g.HorizontalAlign = HorizontalAlign.Left
            tc20g.Text = "<font size=2 color=darkblue>  </font>"
            tr20d.Controls.Add(tc20g)

            Dim tc20h As New TableCell
            tc20h.Attributes.Add("width", "50%")
            tc20h.ColumnSpan = 3
            tc20h.HorizontalAlign = HorizontalAlign.Left
            tc20h.Text = "<font size=2 color=darkblue>N.A</font>"
            tr20d.Controls.Add(tc20h)
            tb.Controls.Add(tr20d)


            Dim tr21d As New TableRow
            Dim tc21d As New TableCell
            tr21d.Font.Size = 8
            tc21d.Attributes.Add("width", "50%")
            tc21d.ColumnSpan = 3
            tc21d.HorizontalAlign = HorizontalAlign.Left
            tc21d.Text = "<font size=2 color=darkblue>AVAILED</font>"
            tr21d.Controls.Add(tc21d)




            Dim tc21e As New TableCell
            tc21e.Attributes.Add("width", "50%")
            tc21e.ColumnSpan = 3
            tc21e.HorizontalAlign = HorizontalAlign.Left
            tc21e.Text = "<font size=2 color=darkblue>" & dt88.Rows(0)(0) & "</font>"
            tr21d.Controls.Add(tc21e)


            Dim tc21f As New TableCell
            tc21f.Attributes.Add("width", "50%")
            tc21f.ColumnSpan = 3
            tc21f.HorizontalAlign = HorizontalAlign.Left
            tc21f.Text = "<font size=2 color=darkblue>" & dt88.Rows(0)(1) & "</font>"
            tr21d.Controls.Add(tc21f)



            Dim tc21g As New TableCell
            tc21g.Attributes.Add("width", "50%")
            tc21g.ColumnSpan = 3
            tc21g.HorizontalAlign = HorizontalAlign.Left
            tc21g.Text = "<font size=2 color=darkblue>" & dt88.Rows(0)(2) & "</font>"
            tr21d.Controls.Add(tc21g)


            Dim tc21h As New TableCell
            tc21h.Attributes.Add("width", "50%")
            tc21h.ColumnSpan = 3
            tc21h.HorizontalAlign = HorizontalAlign.Left
            tc21h.Text = "<font size=2 color=darkblue>" & dt88.Rows(0)(3) & "</font>"
            tr21d.Controls.Add(tc21h)
            tb.Controls.Add(tr21d)


            Dim tr22d As New TableRow
            Dim tc22d As New TableCell
            tr22d.Font.Size = 8
            tc22d.Attributes.Add("width", "50%")
            tc22d.ColumnSpan = 3
            tc22d.HorizontalAlign = HorizontalAlign.Left
            tc22d.Text = "<font size=2 color=darkblue>BALANCE</font>"
            tr22d.Controls.Add(tc22d)


            Dim tc22e As New TableCell
            tc22e.Attributes.Add("width", "50%")
            tc22e.ColumnSpan = 3
            tc22e.HorizontalAlign = HorizontalAlign.Left
            tc22e.Text = "<font size=2 color=darkblue>NA</font>"
            tr22d.Controls.Add(tc22e)


            Dim tc22f As New TableCell
            tc22f.Attributes.Add("width", "50%")
            tc22f.ColumnSpan = 3
            tc22f.HorizontalAlign = HorizontalAlign.Left
            tc22f.Text = "<font size=2 color=darkblue></font>"
            tr22d.Controls.Add(tc22f)

            Dim tr22g As New TableRow
            Dim tc22g As New TableCell
            tr22g.Font.Size = 8
            tc22g.Attributes.Add("width", "50%")
            tc22g.ColumnSpan = 3
            tc22g.HorizontalAlign = HorizontalAlign.Left
            tc22g.Text = "<font size=2 color=darkblue></font>"
            tr22d.Controls.Add(tc22g)


            Dim tc22h As New TableCell
            tc22h.Attributes.Add("width", "50%")
            tc22h.ColumnSpan = 3
            tc22h.HorizontalAlign = HorizontalAlign.Left
            tc22h.Text = "<font size=2 color=darkblue></font>"
            tr22d.Controls.Add(tc22h)
            tb.Controls.Add(tr22d)


            ''-------------------------------------------------------
        End If
        Dim tr23d As New TableRow
        Dim tc23d As New TableCell
        tr23d.Font.Size = 8
        tc23d.Attributes.Add("width", "50%")
        tc23d.ColumnSpan = 8
        tc23d.HorizontalAlign = HorizontalAlign.Left
        tc23d.Text = "<BR><BR><i><font size=2 color=darkblue color=darkblue>Compliance&nbsp;Of&nbsp;The&nbsp;Above&nbsp;Instructions&nbsp;Shall&nbsp;Be</font>"
        tc23d.Text = tc23d.Text & "<font size=2 color=darkblue>Promptly&nbsp;Reported&nbsp;By&nbsp;The&nbsp;Branches.</font></i>"
        tr23d.Controls.Add(tc23d)
        tb.Controls.Add(tr23d)


        Dim tr24d As New TableRow
        Dim tc24d As New TableCell
        tr24d.Font.Size = 8
        tc24d.Attributes.Add("width", "50%")
        tc24d.ColumnSpan = 3
        tc24d.HorizontalAlign = HorizontalAlign.Left
        tc24d.Text = "<BR><BR><BR><BR><BR>"
        'tc24d.Text = "<font size=2 color=darkblue>Promptly&nbsp;Reported&nbsp;By&nbsp;The&nbsp;Branches.</font>"
        tr24d.Controls.Add(tc24d)
        tb.Controls.Add(tr24d)


        Dim tr25d As New TableRow
        tr25d.Font.Size = 8
        Dim tc25d As New TableCell
        tc25d.Attributes.Add("width", "50%")
        tc25d.ColumnSpan = 3
        tc25d.HorizontalAlign = HorizontalAlign.Left
        tc25d.Text = "<font size=2 color=darkblue><B>AGM(HRM)</B></font>"
        tr25d.Controls.Add(tc25d)
        tb.Controls.Add(tr25d)



        '*************************************************************************************************

        If (trandt(2) = 0 Or trandt(2) = 1) Then

            sql = "select post_id from employ_transfer_dtl where emp_code=" & arr(0) & " and to_date(to_dt) is  null"
            dt = oh.ExecuteDataSet(sql).Tables(0)
            Dim Sql6 As String = ""
            If Session("firm_id") = 24 Then
                Sql6 = "select post_name,post_id from post_mst_jwell where post_id=" & pos(0) & ""
            Else
                Sql6 = "select post_name,post_id from post_mst where post_id=" & pos(0) & ""
            End If
            dt1 = oh.ExecuteDataSet(Sql6).Tables(0)
            If (dt1.Rows(0)(1) <= 18 Or dt1.Rows(0)(1) = 101) Then
                Dim tr26d As New TableRow
                tr26d.Font.Size = 8
                Dim tc26d As New TableCell
                tc26d.Attributes.Add("width", "50%")
                tc26d.ColumnSpan = 3
                tc26d.HorizontalAlign = HorizontalAlign.Left
                tc26d.Text = " <BR><BR><BR><BR><BR><BR><BR><BR><BR><BR><BR><BR><BR><BR><BR><BR><BR><BR><BR><BR><BR><BR><BR><BR><BR><BR><BR><BR><BR><BR><BR><BR><BR> "
                tr26d.Controls.Add(tc26d)
                tb.Controls.Add(tr26d)


                Dim tra1 As New TableRow
                tra1.Font.Size = 8
                Dim tca1 As New TableCell
                tca1.Attributes.Add("width", "100%")
                tca1.ColumnSpan = 10
                tca1.HorizontalAlign = HorizontalAlign.Center
                tca1.Text = "<font size=2 color=darkblue><b>" & tfrtp & "</b></font>"   'firm_name
                tra1.Controls.Add(tca1)
                tb.Controls.Add(tra1)



                Dim tr27d As New TableRow
                tr27d.Font.Size = 8
                Dim tc27d As New TableCell
                tc27d.Attributes.Add("width", "50%")
                tc27d.ColumnSpan = 10
                tc27d.HorizontalAlign = HorizontalAlign.Center
                tc27d.Text = "<font size=2 color=darkblue> DEPARTMENT OF HUMAN RESOURCE MANAGEMENT<BR><BR></font>"
                tr27d.Controls.Add(tc27d)
                tb.Controls.Add(tr27d)


                Dim tr28d As New TableRow
                Dim tc28d As New TableCell
                tr28d.Font.Size = 8
                tc28d.Attributes.Add("width", "100%")
                tc28d.ColumnSpan = 25
                tc28d.HorizontalAlign = HorizontalAlign.Right
                tc28d.Text = "<font size=2 color=darkblue>EMPLOYEE&nbsp;CODE:  " & arr(0) & " <BR></font>"
                tr28d.Controls.Add(tc28d)
                tb.Controls.Add(tr28d)


                Dim tr29d As New TableRow
                tr29d.Font.Size = 8
                Dim tc29d As New TableCell
                tc29d.Attributes.Add("width", "50%")
                tc29d.ColumnSpan = 10
                tc29d.HorizontalAlign = HorizontalAlign.Left
                tc29d.Text = "<font size=2 color=darkblue>Time&nbsp:" & Format(Date.Now, "hh:mm:ss") & " </font>"
                tr29d.Controls.Add(tc29d)
                tb.Controls.Add(tr29d)



                Dim tc30d As New TableCell
                tc30d.Attributes.Add("width", "50%")
                tc30d.ColumnSpan = 10
                tc30d.HorizontalAlign = HorizontalAlign.Right
                tc30d.Text = "<font size=2 color=darkblue>Date&nbsp:" & Format(Date.Now, "dd/MMM/yyyy") & " </font>"
                tr29d.Controls.Add(tc30d)
                tb.Controls.Add(tr29d)

                Dim tr290d As New TableRow
                Dim tc300d As New TableCell
                tc300d.Attributes.Add("width", "100%")
                tc300d.ColumnSpan = 100
                tc300d.HorizontalAlign = HorizontalAlign.Left
                tc300d.Text = "<font size=2 color=darkblue><HR></font>"
                tr290d.Controls.Add(tc300d)
                tb.Controls.Add(tr290d)

                Dim firm, sql2, old_deputid As String

                sql = "select nvl(deputation_id,0) from employ_transfer_dtl where emp_code=" & arr(0) & " and deputation_id is not null and from_dt in (select max(from_dt) from employ_transfer_dtl where deputation_id is not null and emp_code=" & arr(0) & " )"

                dt = oh.ExecuteDataSet(sql).Tables(0)



                sql2 = "select firm_id from employ_firm where emp_code='" & arr(0) & "'"
                dt3 = oh.ExecuteDataSet(sql2).Tables(0)

                '------------------------------
                If (dt.Rows(0)(0) = 0) Then
                    Dim dt15 As DataTable
                    firm = "select firm_name from firm_master where firm_id='" & dt3.Rows(0)(0) & "'"
                    dt15 = oh.ExecuteDataSet(firm).Tables(0)
                    old_deputid = dt15.Rows(0)(0)
                Else
                    Dim dt15 As DataTable
                    firm = "select firm_name from firm_master where firm_id='" & dt.Rows(0)(0) & "'"
                    dt15 = oh.ExecuteDataSet(firm).Tables(0)
                    old_deputid = dt15.Rows(0)(0)
                End If

                Dim dt11 As New DataTable
                Dim sql11 As String
                sql11 = "select deputation_id from employ_transfer_dtl where to_date(to_dt) is null and emp_code='" & arr(0) & "'"
                dt11 = oh.ExecuteDataSet(sql11).Tables(0)
                Dim sy As String
                Dim dt18 As DataTable
                sy = "select nvl(firm_id,0) from firm_master where firm_name='" & fr(0) & "'"
                dt18 = oh.ExecuteDataSet(sy).Tables(0)
                If (dt18.Rows.Count = 0) Then
                    Dim tr31d As New TableRow
                    tr31d.Font.Size = 8
                    Dim tc31d As New TableCell
                    tc31d.Attributes.Add("width", "100%")
                    tc31d.ColumnSpan = 90
                    tc31d.HorizontalAlign = HorizontalAlign.Left
                    tc31d.Text = "<font size=2 color=darkblue><BR><BR><BR><u>TRANSFER&nbsp;AND&nbsp;POSTING</u><BR><BR> </font>"
                    tr31d.Controls.Add(tc31d)
                    tb.Controls.Add(tr31d)

                    sql = "select post_id from employ_transfer_dtl where emp_code=" & arr(0) & " and to_dt is  null"
                    dt = oh.ExecuteDataSet(sql).Tables(0)
                    If Session("firm_id") = 24 Then
                        Sql6 = "select post_name,post_id from post_mst_jwell where post_id=" & pos(0) & ""
                    Else
                        Sql6 = "select post_name,post_id from post_mst where post_id=" & pos(0) & ""
                    End If
                    dt26 = oh.ExecuteDataSet(Sql6).Tables(0)


                    If ((dt26.Rows(0)(1) >= 10 And dt26.Rows(0)(1) <= 18) Or dt26.Rows(0)(1) = 101) Then
                        sql = "select emp_name,join_dt,branch_id from employee_master where emp_code=" & arr(0)
                        dt1 = oh.ExecuteDataSet(sql).Tables(0)
                        Dim tr32d As New TableRow
                        tr32d.Font.Size = 8
                        Dim tc32d As New TableCell
                        tc32d.Attributes.Add("width", "100%")
                        tc32d.ColumnSpan = 90
                        tc32d.HorizontalAlign = HorizontalAlign.Left
                        tc32d.Text = "<font size=2 color=darkblue>Mr/Ms." & UCase(dt1.Rows(0)(0)) & "," & arr(4) & "&nbsp" & arr(5) & "," & arr(3) & " branch <BR><BR> He/She is temporarily  promoted  to the  grade of &nbsp" & des(2) & " .<BR> </font>"
                        tr32d.Controls.Add(tc32d)
                        tb.Controls.Add(tr32d)

                        Dim tr33d As New TableRow
                        Dim tc33d As New TableCell
                        tr33d.Font.Size = 8
                        tc33d.Attributes.Add("width", "100%")
                        tc33d.ColumnSpan = 90
                        tc33d.HorizontalAlign = HorizontalAlign.Left
                        tc33d.Text = "<font size=2 color=darkblue> He / She is transferred from " & arr(3) & " branch and posted at our &nbsp" & br(0) & " branch as Branch Head with effect from " & trandt(1) & ". He / She will be relieved from&nbsp" & arr(3) & " branch on the close  of the business on " & trandt(0) & " so as to report at&nbsp" & br(0) & " branch on " & trandt(1) & ". During the period of his/her assignment, his/her salary would be (Basic Pay(Rs." & cbasic & " ) + VDA( Rs." & da_val & " )) - Rs." & cbasic1 & " /- (Rupees " & getWords(cbasic1) & "  only).<BR> </font>"
                        tr33d.Controls.Add(tc33d)
                        tb.Controls.Add(tr33d)

                        Dim tr34d As New TableRow
                        tr34d.Font.Size = 8
                        Dim tc34d As New TableCell
                        tc34d.Attributes.Add("width", "100%")
                        tc34d.ColumnSpan = 90
                        tc34d.HorizontalAlign = HorizontalAlign.Left
                        tc34d.Text = "<font size=2 color=darkblue>He / She will take  the  complete charge of &nbsp" & br(0) & " branch from  the  joint custodians  of the branch on or before " & w & "," & trandt(1) & " and  submit the usual charge  report  in the  prescribed format  CR-1. He / She will be responsible for branch administration,maintenance of books of accounts,office discipline, and joint custody of the assets of the company, securities etc. with  the Branch Head,  as cited  in  Circular No.338 dated 24th December,2004.<BR></font>"
                        tr34d.Controls.Add(tc34d)
                        tb.Controls.Add(tr34d)

                        Dim tr34h As New TableRow
                        Dim tc34h As New TableCell
                        tr34h.Font.Size = 8
                        tc34h.Attributes.Add("width", "100%")
                        tc34h.ColumnSpan = 90
                        tc34h.HorizontalAlign = HorizontalAlign.Left
                        tc34h.Text = "<font size=2 color=darkblue>He/She is authorised to  accept NCDs and BONDS on the  behalf of  the company and issue NCDs and BONDS receipts under joint signature  with the Branch Head,in accordance with  the rules  and  regulations in  vogue governing the issue of the same. In the absence of the Branch Head,  he / she will be completely responsible for running the office and authorised to advance loans against gold ornaments after ascertaining  the quality and purity of same, strictly  complying with  the procedures and  rate of  advance in vogue.<BR></font>"
                        tr34h.Controls.Add(tc34h)
                        tb.Controls.Add(tr34h)


                        Dim tr34e As New TableRow
                        Dim tc34e As New TableCell
                        tr34e.Font.Size = 8
                        tc34e.Attributes.Add("width", "100%")
                        tc34e.ColumnSpan = 90
                        tc34e.HorizontalAlign = HorizontalAlign.Left
                        tc34e.Text = "<font size=2 color=darkblue> Please note that he/she will be automatically reverted back to his/her regular post as and when the regular incumbent is posted.<BR><BR><BR></font>"
                        tr34e.Controls.Add(tc34e)

                    End If
                    If (dt26.Rows(0)(1) >= 1 And dt26.Rows(0)(1) <= 9) Then
                        sql = "select emp_name,join_dt,branch_id from employee_master where emp_code=" & arr(0)
                        dt1 = oh.ExecuteDataSet(sql).Tables(0)
                        Dim tr32d As New TableRow
                        tr32d.Font.Size = 8
                        Dim tc32d As New TableCell
                        tc32d.Attributes.Add("width", "100%")
                        tc32d.ColumnSpan = 90
                        tc32d.HorizontalAlign = HorizontalAlign.Left
                        tc32d.Text = "<font size=2 color=darkblue>Mr/Ms." & UCase(dt1.Rows(0)(0)) & "," & arr(4) & "&nbsp" & arr(5) & "," & arr(3) & " branch ,He/She is temporarily  promoted  to the  grade of &nbsp" & des(2) & " .<BR> </font>"
                        tr32d.Controls.Add(tc32d)
                        tb.Controls.Add(tr32d)

                        Dim tr33d As New TableRow
                        Dim tc33d As New TableCell
                        tr33d.Font.Size = 8
                        tc33d.Attributes.Add("width", "100%")
                        tc33d.ColumnSpan = 90
                        tc33d.HorizontalAlign = HorizontalAlign.Left
                        tc33d.Text = "<font size=2 color=darkblue>He / She is transferred from " & arr(3) & "  branch  and posted at  our &nbsp" & br(0) & "  branch as Assistant  Branch  Head with effect from " & trandt(1) & ". He / She will be relieved from&nbsp" & arr(3) & " branch on the close of the  business on " & trandt(0) & " so as to report at&nbsp" & br(0) & " branch on " & trandt(1) & ". During the period of his / her assignment, his / her salary would be (Basic Pay(Rs." & cbasic & " ) + VDA( Rs." & da_val & " )) - Rs." & cbasic1 & " /- (Rupees " & getWords(cbasic1) & "  only).<BR> </font>"
                        tr33d.Controls.Add(tc33d)
                        tb.Controls.Add(tr33d)

                        Dim tr34d As New TableRow
                        tr34d.Font.Size = 8
                        Dim tc34d As New TableCell
                        tc34d.Attributes.Add("width", "100%")
                        tc34d.ColumnSpan = 90
                        tc34d.HorizontalAlign = HorizontalAlign.Left
                        tc34d.Text = "<font size=2 color=darkblue>He / She will hold the joint responsibility on matters like Branch administration, maintenance of books of accounts, office discipline, and joint custody of the  assets  of the company, securities etc. with the Branch Head,as cited in Circular No.338 dated 24th December,2004. <BR></font>"
                        tr34d.Controls.Add(tc34d)
                        tb.Controls.Add(tr34d)

                        Dim tr34h As New TableRow
                        Dim tc34h As New TableCell
                        tr34h.Font.Size = 8
                        tc34h.Attributes.Add("width", "100%")
                        tc34h.ColumnSpan = 90
                        tc34h.HorizontalAlign = HorizontalAlign.Left
                        tc34h.Text = "<font size=2 color=darkblue>He / She is authorised to accept NCDs and BONDS on the behalf of the company  and issue NCDs and BONDS receipts under joint signature with the Branch Head,in accordance with the rules and  regulations in vogue  governing the  issue of the same. In the absence of the Branch Head, he / she will be completely responsible for running the office and authorised to advance loans against  gold ornaments after ascertaining the quality and purity of same, strictly complying with the procedures and rate of advance in vogue. <BR></font>"
                        tr34h.Controls.Add(tc34h)
                        tb.Controls.Add(tr34h)


                        Dim tr34e As New TableRow
                        Dim tc34e As New TableCell
                        tr34e.Font.Size = 8
                        tc34e.Attributes.Add("width", "100%")
                        tc34e.ColumnSpan = 90
                        tc34e.HorizontalAlign = HorizontalAlign.Left
                        tc34e.Text = "<font size=2 color=darkblue>Please note that he / she will be automatically  reverted back to his / her regular post as and when the regular incumbent is posted.<BR><BR><BR></font>"
                        tr34e.Controls.Add(tc34e)
                    End If
                Else



                    Dim tr31d As New TableRow
                    tr31d.Font.Size = 8
                    Dim tc31d As New TableCell
                    tc31d.Attributes.Add("width", "100%")
                    tc31d.ColumnSpan = 90
                    tc31d.HorizontalAlign = HorizontalAlign.Left
                    tc31d.Text = "<font size=2 color=darkblue><BR><BR><BR><u>DEPUTATION</u><BR> </font>"
                    tr31d.Controls.Add(tc31d)
                    tb.Controls.Add(tr31d)

                    sql = "select emp_name,join_dt,branch_id from employee_master where emp_code=" & arr(0)
                    dt1 = oh.ExecuteDataSet(sql).Tables(0)
                    Dim tr32d As New TableRow
                    tr32d.Font.Size = 8
                    Dim tc32d As New TableCell
                    tc32d.Attributes.Add("width", "100%")
                    tc32d.ColumnSpan = 90
                    tc32d.HorizontalAlign = HorizontalAlign.Left
                    tc32d.Text = "<font size=2 color=darkblue>Mr/Ms." & UCase(dt1.Rows(0)(0)) & "," & arr(4) & "&nbsp;" & arr(5) & "," & arr(3) & " branch is deputed from " & old_deputid & " to " & fr(0) & "<BR><BR></font>"
                    tr32d.Controls.Add(tc32d)
                    tb.Controls.Add(tr32d)

                    Dim tr311d As New TableRow
                    tr311d.Font.Size = 8
                    Dim tc311d As New TableCell
                    tc311d.Attributes.Add("width", "100%")
                    tc311d.ColumnSpan = 90
                    tc311d.HorizontalAlign = HorizontalAlign.Left
                    tc311d.Text = "<font size=2 color=darkblue><BR><u>TRANSFER&nbsp;AND&nbsp;POSTING</u><BR><BR> </font>"
                    tr311d.Controls.Add(tc311d)
                    tb.Controls.Add(tr311d)

                    sql = "select post_id from employ_transfer_dtl where emp_code=" & arr(0) & " and to_dt is  null"
                    dt = oh.ExecuteDataSet(sql).Tables(0)
                    If Session("firm_id") = 24 Then
                        Sql6 = "select post_name,post_id from post_mst_jwell where post_id=" & pos(0) & ""
                    Else
                        Sql6 = "select post_name,post_id from post_mst where post_id=" & pos(0) & ""
                    End If
                    dt26 = oh.ExecuteDataSet(Sql6).Tables(0)



                    If ((dt26.Rows(0)(1) >= 10 And dt26.Rows(0)(1) <= 18) Or dt26.Rows(0)(1) = 101) Then

                        Dim tr321d As New TableRow
                        tr321d.Font.Size = 8
                        Dim tc321d As New TableCell
                        tc321d.Attributes.Add("width", "100%")
                        tc321d.ColumnSpan = 90
                        tc321d.HorizontalAlign = HorizontalAlign.Left
                        tc321d.Text = "<font size=2 color=darkblue>He/She is temporarily  promoted  to the  grade of &nbsp" & des(2) & " .<BR><BR> </font>"
                        tr321d.Controls.Add(tc321d)
                        tb.Controls.Add(tr321d)

                        Dim tr331d As New TableRow
                        Dim tc331d As New TableCell
                        tr331d.Font.Size = 8
                        tc331d.Attributes.Add("width", "100%")
                        tc331d.ColumnSpan = 90
                        tc331d.HorizontalAlign = HorizontalAlign.Left
                        tc331d.Text = "<font size=2 color=darkblue> He / She is transferred from &nbsp" & arr(3) & " branch and posted at our &nbsp" & br(0) & " branch as Branch Head with effect from " & trandt(1) & ". He / She will be relieved from&nbsp" & arr(3) & " branch on the close  of the business on " & trandt(0) & " so as to report at&nbsp" & br(0) & " branch on " & trandt(1) & ". During the period of his/her assignment, his/her salary would be (Basic Pay(Rs." & cbasic & " ) + VDA( Rs." & da_val & " )) - Rs." & cbasic1 & " /- (Rupees " & getWords(cbasic1) & "  only).<BR> </font>"
                        tr331d.Controls.Add(tc331d)
                        tb.Controls.Add(tr331d)

                        Dim tr34d As New TableRow
                        tr34d.Font.Size = 8
                        Dim tc34d As New TableCell
                        tc34d.Attributes.Add("width", "100%")
                        tc34d.ColumnSpan = 90
                        tc34d.HorizontalAlign = HorizontalAlign.Left
                        tc34d.Text = "<font size=2 color=darkblue>He / She will take  the  complete charge of &nbsp" & br(0) & " branch from  the  joint custodians  of the branch on or before " & w & "," & trandt(1) & " and  submit the usual charge  report  in the  prescribed format  CR-1. He / She will be responsible for branch administration,maintenance of books of accounts,office discipline, and joint custody of the assets of the company, securities etc. with  the Branch Head,  as cited  in  Circular No.338 dated 24th December,2004.<BR></font>"
                        tr34d.Controls.Add(tc34d)
                        tb.Controls.Add(tr34d)

                        Dim tr34h As New TableRow
                        Dim tc34h As New TableCell
                        tr34h.Font.Size = 8
                        tc34h.Attributes.Add("width", "100%")
                        tc34h.ColumnSpan = 90
                        tc34h.HorizontalAlign = HorizontalAlign.Left
                        tc34h.Text = "<font size=2 color=darkblue>He/She is authorised to  accept NCDs and BONDS on the  behalf of  the company and issue NCDs and BONDS receipts under joint signature  with the Branch Head,in accordance with  the rules  and  regulations in  vogue governing the issue of the same. In the absence of the Branch Head,  he / she will be completely responsible for running the office and authorised to advance loans against gold ornaments after ascertaining  the quality and purity of same, strictly  complying with  the procedures and  rate of  advance in vogue.<BR></font>"
                        tr34h.Controls.Add(tc34h)
                        tb.Controls.Add(tr34h)


                        Dim tr34e As New TableRow
                        Dim tc34e As New TableCell
                        tr34e.Font.Size = 8
                        tc34e.Attributes.Add("width", "100%")
                        tc34e.ColumnSpan = 90
                        tc34e.HorizontalAlign = HorizontalAlign.Left
                        tc34e.Text = "<font size=2 color=darkblue>Please note that he/she will be automatically reverted back to his/her regular post as and when the regular incumbent is posted.<BR><BR><BR></font>"
                        tr34e.Controls.Add(tc34e)
                        tb.Controls.Add(tr34e)
                    End If

                    If (dt26.Rows(0)(1) >= 1 And dt26.Rows(0)(1) <= 9) Then

                        Dim tr321d As New TableRow
                        tr321d.Font.Size = 8
                        Dim tc321d As New TableCell
                        tc321d.Attributes.Add("width", "100%")
                        tc321d.ColumnSpan = 90
                        tc321d.HorizontalAlign = HorizontalAlign.Left
                        tc321d.Text = "<font size=2 color=darkblue>He/She is temporarily  promoted  to the  grade of &nbsp" & des(2) & " .<BR><BR> </font>"
                        tr321d.Controls.Add(tc321d)
                        tb.Controls.Add(tr321d)

                        Dim tr331d As New TableRow
                        Dim tc331d As New TableCell
                        tr331d.Font.Size = 8
                        tc331d.Attributes.Add("width", "100%")
                        tc331d.ColumnSpan = 90
                        tc331d.HorizontalAlign = HorizontalAlign.Left
                        tc331d.Text = "<font size=2 color=darkblue>He / She is transferred from &nbsp" & arr(3) & "  branch  and posted at  our &nbsp" & br(0) & "  branch as Assistant  Branch  Head with effect from " & trandt(1) & ". He / She will be relieved from&nbsp" & arr(3) & " branch on the close of the  business on " & trandt(0) & " so as to report at&nbsp" & br(0) & " branch on " & trandt(1) & ". During the period of his/her assignment, his / her salary would be (Basic Pay(Rs." & cbasic & " ) + VDA( Rs." & da_val & " )) - Rs." & cbasic1 & " /- (Rupees " & getWords(cbasic1) & "  only).<BR> </font>"
                        tr331d.Controls.Add(tc331d)
                        tb.Controls.Add(tr331d)

                        Dim tr34d As New TableRow
                        tr34d.Font.Size = 8
                        Dim tc34d As New TableCell
                        tc34d.Attributes.Add("width", "100%")
                        tc34d.ColumnSpan = 90
                        tc34d.HorizontalAlign = HorizontalAlign.Left
                        tc34d.Text = "<font size=2 color=darkblue><BR>He / She will hold the joint responsibility on matters like Branch administration, maintenance of books of accounts, office discipline, and joint custody of the  assets  of the company, securities etc. with the Branch Head,as cited in Circular No.338 dated 24th December,2004.<BR></font>"
                        tr34d.Controls.Add(tc34d)
                        tb.Controls.Add(tr34d)

                        Dim tr34h As New TableRow
                        Dim tc34h As New TableCell
                        tr34h.Font.Size = 8
                        tc34h.Attributes.Add("width", "100%")
                        tc34h.ColumnSpan = 90
                        tc34h.HorizontalAlign = HorizontalAlign.Left
                        tc34h.Text = "<font size=2 color=darkblue><BR>He / She is authorised to accept NCDs and BONDS on the behalf of the company  and issue NCDs and BONDS receipts under joint signature with the Branch Head,in accordance with the rules and  regulations in vogue  governing the  issue of the same. In the absence of the Branch Head, he / she will be completely responsible for running the office and authorised to advance loans against  gold ornaments after ascertaining the quality and purity of same, strictly complying with the procedures and rate of advance in vogue.<BR></font>"
                        tr34h.Controls.Add(tc34h)
                        tb.Controls.Add(tr34h)


                        Dim tr34e As New TableRow
                        Dim tc34e As New TableCell
                        tr34e.Font.Size = 8
                        tc34e.Attributes.Add("width", "100%")
                        tc34e.ColumnSpan = 90
                        tc34e.HorizontalAlign = HorizontalAlign.Left
                        tc34e.Text = "<font size=2 color=darkblue><BR>Please note that he / she will be automatically  reverted back to his / her regular post as and when the regular incumbent is posted.<BR><BR><BR></font>"
                        tr34e.Controls.Add(tc34e)
                        tb.Controls.Add(tr34e)

                    End If

                    Dim tr33d As New TableRow
                    Dim tc33d As New TableCell
                    tr33d.Font.Size = 8
                    tc33d.Attributes.Add("width", "50%")
                    tc33d.ColumnSpan = 3
                    tc33d.HorizontalAlign = HorizontalAlign.Left
                    tc33d.Text = "<font size=2 color=darkblue> </font>"
                    tr33d.Controls.Add(tc33d)
                    tb.Controls.Add(tr33d)


            End If
                Dim tr35s As New TableRow
                Dim tc35s As New TableCell
                tr35s.Font.Size = 8
                tc35s.Attributes.Add("width", "50%")
                tc35s.ColumnSpan = 3
                tc35s.HorizontalAlign = HorizontalAlign.Left
                tc35s.Text = "<font size=2 color=darkblue><BR><BR>AGM(HRM)<BR></font>"
                tr35s.Controls.Add(tc35s)
                tb.Controls.Add(tr35s)


                Dim tr35t As New TableRow
                Dim tc35t As New TableCell
                tr35t.Font.Size = 8
                tc35t.Attributes.Add("width", "50%")
                tc35t.ColumnSpan = 3
                tc35t.HorizontalAlign = HorizontalAlign.Left
                tc35t.Text = "<font size=2 color=darkblue> </font>"
                tr35t.Controls.Add(tc35t)
                tb.Controls.Add(tr35t)


                Dim tr35u As New TableRow
                Dim tc35u As New TableCell
                tr35u.Font.Size = 8
                tc35u.Attributes.Add("width", "50%")
                tc35u.ColumnSpan = 15
                tc35u.HorizontalAlign = HorizontalAlign.Left
                tc35u.Text = "<font size=2 color=darkblue><BR>TO</font>"
                tr35u.Controls.Add(tc35u)
                tb.Controls.Add(tr35u)


                Dim tr35v As New TableRow
                Dim tc35v As New TableCell
                tr35v.Font.Size = 8
                tc35v.Attributes.Add("width", "50%")
                tc35v.ColumnSpan = 3
                tc35v.HorizontalAlign = HorizontalAlign.Left
                tc35v.Text = "<font size=2 color=darkblue> </font>"
                tr35v.Controls.Add(tc35v)
                tb.Controls.Add(tr35v)

                sql = "select emp_name,join_dt,branch_id from employee_master where emp_code=" & arr(0)
                dt1 = oh.ExecuteDataSet(sql).Tables(0)

                Dim tr35w As New TableRow
                Dim tc35w As New TableCell
                tr35w.Font.Size = 8
                tc35w.Attributes.Add("width", "50%")
                tc35w.ColumnSpan = 45
                tc35w.HorizontalAlign = HorizontalAlign.Left
                tc35w.Text = "<font size=2 color=darkblue>Mr./Mrs." & UCase(dt1.Rows(0)(0)) & " </font>"
                tr35w.Controls.Add(tc35w)
                tb.Controls.Add(tr35w)



                Dim tr35y As New TableRow
                Dim tc35y As New TableCell
                tr35y.Font.Size = 8
                tc35y.Attributes.Add("width", "50%")
                tc35y.ColumnSpan = 45
                tc35y.HorizontalAlign = HorizontalAlign.Left
                tc35y.Text = "<font size=2 color=darkblue> " & arr(4) & ",&nbsp" & arr(5) & " </font>"
                tr35y.Controls.Add(tc35y)
                tb.Controls.Add(tr35y)

                Dim tr35z As New TableRow
                Dim tc35z As New TableCell
                tr35z.Font.Size = 8
                tc35z.Attributes.Add("width", "50%")
                tc35z.ColumnSpan = 45
                tc35z.HorizontalAlign = HorizontalAlign.Left
                tc35z.Text = "<font size=2 color=darkblue> " & arr(3) & "&nbsp;Branch<BR><BR><BR></font>"
                tr35z.Controls.Add(tc35z)
                tb.Controls.Add(tr35z)


                Dim tr35z1 As New TableRow
                Dim tc35z1 As New TableCell
                tr35z1.Font.Size = 8
                tc35z1.Attributes.Add("width", "50%")
                tc35z1.ColumnSpan = 45
                tc35z1.HorizontalAlign = HorizontalAlign.Left
                tc35z1.Text = "<font size=2 color=darkblue> CC&nbsp;TO:&nbsp;BH&nbsp;-&nbsp;" & arr(3) & "&nbsp;/" & br(0) & "/HRM-E </font>"
                tr35z1.Controls.Add(tc35z1)
                tb.Controls.Add(tr35z1)



            Else
            End If

        End If
        Me.Panel1.Controls.Add(tb)

    End Sub


    '***********************convertion of decimals to words *********************************

    Public Function getWords(ByVal myNumber As String) As String
        getWords = SpellNumber(myNumber)
    End Function

    Private Function SpellNumber(ByVal MyNumber As String)
        Dim Rupees, Paise, Temp, ornum
        Dim DecimalPlace, Count
        Dim Place(9) As String
        Place(2) = " Thousand "
        Place(3) = " Lakh "
        Place(4) = " Crore "
        MyNumber = Convert.ToString(MyNumber)
        DecimalPlace = InStr(MyNumber, ".")
        If DecimalPlace > 0 Then
            ornum = Trim(Left(MyNumber, DecimalPlace - 1))
        Else
            ornum = MyNumber
        End If
        If DecimalPlace > 0 Then
            Paise = GetTens(Left(Mid(MyNumber, DecimalPlace + 1) & _
                                 "00", 2))
            MyNumber = Trim(Left(MyNumber, DecimalPlace - 1))
            ornum = MyNumber
        End If
        Count = 1
        Do While MyNumber <> ""
            If ornum = MyNumber Then
                Temp = GetHundreds(Right(MyNumber, 3))
                If Temp <> "" Then Rupees = Temp & Place(Count) & Rupees
                If Len(MyNumber) > 3 Then
                    If MyNumber = ornum Then
                        MyNumber = Left(MyNumber, Len(MyNumber) - 3)
                    Else
                        MyNumber = Left(MyNumber, Len(MyNumber) - 2)
                    End If
                Else
                    MyNumber = ""
                End If
                Count = Count + 1
            Else
                Temp = GetTens(Right(MyNumber, 2))
                If Temp <> "" Then Rupees = Temp & Place(Count) & Rupees
                If Len(MyNumber) > 2 Then
                    If MyNumber = ornum Then
                        MyNumber = Left(MyNumber, Len(MyNumber) - 3)
                    Else
                        MyNumber = Left(MyNumber, Len(MyNumber) - 2)
                    End If
                Else
                    MyNumber = ""
                End If
                Count = Count + 1
            End If
        Loop
        Select Case Rupees
            Case ""
                Rupees = "zero Rupees"
            Case "One"
                Rupees = "One Rupees"
            Case Else
                Rupees = Rupees & " Rupees"
        End Select
        Select Case Paise
            Case ""
                Paise = " and zero Paise"
            Case "One"
                Paise = " and One Paise"
            Case Else
                Paise = " and " & Paise & " Paise"
        End Select
        SpellNumber = Rupees & Paise
    End Function

    Private Function GetHundreds(ByVal MyNumber As String)
        Dim Result As String
        If Val(MyNumber) = 0 Then Exit Function
        MyNumber = Right("000" & MyNumber, 3)
        If Mid(MyNumber, 1, 1) <> "0" Then
            Result = GetDigit(Mid(MyNumber, 1, 1)) & " Hundred "
        End If
        If Mid(MyNumber, 2, 1) <> "0" Then
            Result = Result & GetTens(Mid(MyNumber, 2))
        Else
            Result = Result & GetDigit(Mid(MyNumber, 3))
        End If
        GetHundreds = Result
    End Function

    Private Function GetTens(ByVal TensText As String)
        Dim Result As String
        Result = ""
        If Val(Left(TensText, 1)) = 1 Then
            If Len(TensText) = 1 Then
                Result = Result & GetDigit(Right(TensText, 1))
            Else
                Select Case Val(TensText)
                    Case 10 : Result = "Ten"
                    Case 11 : Result = "Eleven"
                    Case 12 : Result = "Twelve"
                    Case 13 : Result = "Thirteen"
                    Case 14 : Result = "Fourteen"
                    Case 15 : Result = "Fifteen"
                    Case 16 : Result = "Sixteen"
                    Case 17 : Result = "Seventeen"
                    Case 18 : Result = "Eighteen"
                    Case 19 : Result = "Nineteen"
                    Case Else
                End Select
            End If
        Else
            If Len(TensText) = 1 Then
            Else
                Dim kl
                kl = CInt(Val(Left(TensText, 1)))
                Select Case CInt(Val(Left(TensText, 1)))
                    Case 2 : Result = "Twenty "
                    Case 3 : Result = "Thirty "
                    Case 4 : Result = "Forty "
                    Case 5 : Result = "Fifty "
                    Case 6 : Result = "Sixty "
                    Case 7 : Result = "Seventy "
                    Case 8 : Result = "Eighty "
                    Case 9 : Result = "Ninety "
                    Case Else
                End Select
            End If
            Result = Result & GetDigit(Right(TensText, 1))
        End If
        GetTens = Result
    End Function

    Private Function GetDigit(ByVal Digit As String)
        Select Case Val(Digit)
            Case 1 : GetDigit = "One"
            Case 2 : GetDigit = "Two"
            Case 3 : GetDigit = "Three"
            Case 4 : GetDigit = "Four"
            Case 5 : GetDigit = "Five"
            Case 6 : GetDigit = "Six"
            Case 7 : GetDigit = "Seven"
            Case 8 : GetDigit = "Eight"
            Case 9 : GetDigit = "Nine"
            Case Else : GetDigit = ""
        End Select
    End Function


End Class

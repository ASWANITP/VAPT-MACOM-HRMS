Imports system.data
Imports system.data.oracleclient

Partial Class specificempattend_individualreport_4e83ed8a9118
    Inherits System.Web.UI.Page
    Dim dt, dt1 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim fdt, tdt, emp, sql, sql1 As String
    Dim dr As DataRow
    Dim per, totalper As Double
    Dim totalp = 0, totals = 0
    Dim color = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fdt = Request.QueryString.Get("fdt")
        tdt = Request.QueryString.Get("tdt")
        emp = Request.QueryString.Get("emp")


        Dim empcode As Integer
        empcode = Request.QueryString.Get("empcode")
        'sql = "select to_date(curr_date) as day,em.emp_code as emp_code,upper(substr(em.emp_name,0,19)) as Name,decode(da.m_time,NULL,'----------',da.m_time) as morning_time,substr(bm1.branch_name,0,12) as Morning_Branch,decode(e_time,NULL,'----------',e_time) as evening_time,substr(bm2.branch_name,0,12) as Evening_Branch,case when (m_time='ONDUTY' and e_time is NULL) then 'Non-Marking' else case when (m_time='ONDUTY' and e_time='ONDUTY') then '' else case when (m_time='OFF' and e_time='OFF') then '' else case when ((da.m_time is null and da.e_time is null) and (to_char(to_date(da.curr_date),'d')=1)) then 'Sunday' else case when da.m_time is null and da.e_time is null then 'Absent' else case when da.m_time>tt.in_time and da.e_time is null then 'Late & Non Marking' else case when da.m_time<=tt.in_time and da.e_time is null then 'Non Marking' else case when da.m_time is null and da.e_time <tt.out_time then 'Non Marking & Early Going' else case when da.m_time is null and da.e_time >=tt.out_time then 'Non Marking' else case when da.m_time<=tt.in_time and da.e_time<tt.out_time then 'Early Going' else case when da.m_time>tt.in_time and da.e_time<tt.out_time then 'Late & Early Going' else case when da.m_time>tt.in_time and da.e_time>tt.out_time then 'Late' else '' end end end end end end end end end end end end as remarks from ATTENDANCE da,employee_master em,branch_master bm,branch_master bm1,branch_master bm2,time_tab tt where  em.emp_code=da.emp_code and bm.branch_id=em.branch_id and em.branch_id=da.branch_id  and da.shift_id not in (4,5) and da.shift_id=tt.shift_id and bm1.branch_id=da.m_branch and bm2.branch_id=da.e_branch and da.EMP_CODE=" & empcode & " order by bm.branch_id,day"
        sql = "select to_date(curr_date) as day,decode(da.m_time,NULL,'----------',da.m_time) as morning_time,decode(e_time,NULL,'----------',e_time) as evening_time,case when (m_time='ONDUTY' and e_time is NULL) then 'Non-Marking' else case when (m_time='ONDUTY' and e_time='ONDUTY') then '' else case when (m_time='OFF' and e_time='OFF') then '' else case when ((da.m_time is null and da.e_time is null) and (to_char(to_date(da.curr_date),'d')=1)) then 'Sunday' else case when da.m_time is null and da.e_time is null then 'Absent' else case when da.m_time>bt1.in_time and da.e_time is null then 'Late & Non Marking' else case when da.m_time<=bt1.in_time and da.e_time is null then 'Non Marking' else case when da.m_time is null and da.e_time <bt2.out_time then 'Non Marking & Early Going' else case when da.m_time is null and da.e_time >=bt2.out_time then 'Non Marking' else case when da.m_time<=bt1.in_time and da.e_time<bt2.out_time then 'Early Going' else case when da.m_time>bt1.in_time and da.e_time<bt2.out_time then 'Late & Early Going' else case when da.m_time>bt1.in_time and da.e_time>bt2.out_time then 'Late' else '' end end end end end end end end end  end end end as remarks from ATTENDANCE da,employee_master em,branch_master bm,branch_time bt1,branch_time bt2,branch_time bt where  em.emp_code=da.emp_code and bm.branch_id=em.branch_id and to_date(da.curr_date)>='" & fdt & "' and to_date(da.curr_date)<='" & tdt & "' and em.branch_id=da.branch_id  and da.shift_id not in (4,5) and bt1.branch_id=da.m_branch and bt2.branch_id=da.e_branch and da.emp_code=" & emp & " and bt.branch_id=da.branch_id and da.branch_id<>0 union  select to_date(curr_date) as day,decode(da.m_time,NULL,'----------',da.m_time) as morning_time,decode(e_time,NULL,'----------',e_time) as evening_time,case when (m_time='ONDUTY' and e_time is NULL) then 'Non-Marking' else case when (m_time='ONDUTY' and e_time='ONDUTY') then '' else case when (m_time='OFF' and e_time='OFF') then '' else case when ((da.m_time is null and da.e_time is null) and (to_char(to_date(da.curr_date),'d')=1)) then 'Sunday' else case when da.m_time is null and da.e_time is null then 'Absent' else case when da.m_time>tt.in_time and da.e_time is null then 'Late & Non Marking' else case when da.m_time<=tt.in_time and da.e_time is null then 'Non Marking' else case when da.m_time is null and da.e_time <tt.out_time then 'Non Marking & Early Going' else case when da.m_time is null and da.e_time >=tt.out_time then 'Non Marking' else case when da.m_time<=tt.in_time and da.e_time<tt.out_time then 'Early Going' else case when da.m_time>tt.in_time and da.e_time<tt.out_time then 'Late & Early Going' else case when da.m_time>tt.in_time and da.e_time>tt.out_time then 'Late' else '' end end end end end end end end end  end end end as remarks from ATTENDANCE da,employee_master em,branch_master bm,branch_master bm1,branch_master bm2,time_tab tt where  em.emp_code=da.emp_code and bm.branch_id=em.branch_id and to_date(da.curr_date)>='" & fdt & "' and to_date(da.curr_date)<='" & tdt & "' and em.branch_id=da.branch_id  and da.shift_id not in (4,5) and da.shift_id=tt.shift_id and bm1.branch_id=da.m_branch and bm2.branch_id=da.e_branch and da.emp_code=" & emp & " and da.branch_id=0 and da.e_branch=0 and da.m_branch=0 union select to_date(curr_date) as day,decode(da.m_time,NULL,'----------',da.m_time) as morning_time,decode(e_time,NULL,'----------',e_time) as evening_time,case when (m_time='ONDUTY' and e_time is NULL) then 'Non-Marking' else case when (m_time='ONDUTY' and e_time='ONDUTY') then '' else case when (m_time='OFF' and e_time='OFF') then '' else case when ((da.m_time is null and da.e_time is null) and (to_char(to_date(da.curr_date),'d')=1)) then 'Sunday' else case when da.m_time is null and da.e_time is null then 'Absent' else case when da.m_time>bt1.in_time and da.e_time is null then 'Late & Non Marking' else case when da.m_time<=bt1.in_time and da.e_time is null then 'Non Marking' else case when da.m_time is null and da.e_time <bt2.out_time then 'Non Marking & Early Going' else case when da.m_time is null and da.e_time >=bt2.out_time then 'Non Marking' else case when da.m_time<=bt1.in_time and da.e_time<bt2.out_time then 'Early Going' else case when da.m_time>bt1.in_time and da.e_time<bt2.out_time then 'Late & Early Going' else case when da.m_time>bt1.in_time and da.e_time>bt2.out_time then 'Late' else '' end end end end end end end end end  end end end as remarks from ATTENDANCE da,employee_master em,branch_master bm,branch_time bt1,branch_time bt2,branch_time bt where  em.emp_code=da.emp_code and bm.branch_id=em.branch_id and to_date(da.curr_date)>='" & fdt & "' and to_date(da.curr_date)<='" & tdt & "' and em.branch_id=da.branch_id  and da.shift_id not in (4,5) and bt1.branch_id=da.m_branch and bt2.branch_id=da.e_branch and da.emp_code=" & emp & " and da.branch_id=0 and (da.m_branch<>0 or da.e_branch<>0) order by day "
        dt = oh.ExecuteDataSet(sql).Tables(0)
        Dim tb As New Table
        ' tb.Attributes.Add("Border", "1")
        tb.Attributes.Add("width", "100%")
        sql1 = "select a.emp_name,b.branch_name,a.branch_id,c.dep_name,d.designation from e_master a,branch_master b,department_mst c,designation_mst d where a.emp_code=" & emp & " and b.branch_id=a.branch_id and a.department_id=c.dep_id and a.designation_id=d.designation_id"
        dt1 = oh.ExecuteDataSet(sql1).Tables(0)




        Dim tr1 As New TableRow
        Dim td11 As New TableCell
        tr1.BackColor = Drawing.Color.Gold
        td11.Attributes.Add("width", "80%")
        td11.ColumnSpan = 80
        td11.HorizontalAlign = HorizontalAlign.Center
        td11.Text = "<font size=4 color=red><b>MANAPPURAM GROUP OF COMPANIES</b></font>"
        tr1.Controls.Add(td11)
        tb.Controls.Add(tr1)

        Dim tr2 As New TableRow
        Dim td21 As New TableCell
        tr2.BackColor = Drawing.Color.MistyRose
        td21.Attributes.Add("width", "40%")
        td21.ColumnSpan = 35
        td21.HorizontalAlign = HorizontalAlign.Right
        td21.Text = "<font size=2 color=darkblue><b>Branch-id :" & dt1.Rows(0)(2) & "</b></font>"
        tr2.Controls.Add(td21)
        Dim td22 As New TableCell
        td22.Attributes.Add("width", "40%")
        td22.ColumnSpan = 40
        td22.HorizontalAlign = HorizontalAlign.Left
        td22.Text = "<font size=2 color=darkblue><b>Branch :" & dt1.Rows(0)(1) & "</b></font>"
        tr2.Controls.Add(td22)
        tb.Controls.Add(tr2)


        Dim tr3 As New TableRow
        'tr3.BackColor = Drawing.Color.MistyRose
        Dim td31 As New TableCell
       

        Dim td32 As New TableCell
        td32.Attributes.Add("width", "40%")
        td32.ColumnSpan = 15
        td32.HorizontalAlign = HorizontalAlign.Center
        td32.Text = "<font size=2 color=darkblue><BR><BR><b>Time :" & Format(Date.Now, "hh:mm:ss") & "</b></font>"
        tr3.Controls.Add(td32)

        Dim td321 As New TableCell
        td321.Attributes.Add("width", "40%")
        td321.ColumnSpan = 42
        td321.HorizontalAlign = HorizontalAlign.Center
        td321.Text = "<font size=2.8 color=darkbrown><BR><b>Attendance Report from &nbsp" & fdt & "&nbsp to &nbsp" & tdt & "</b></font>"
        tr3.Controls.Add(td321)


        td31.Attributes.Add("width", "40%")
        td31.ColumnSpan = 18
        td31.HorizontalAlign = HorizontalAlign.Center
        td31.Text = "<font size=2 color=darkblue><BR><BR><b>Date :" & Format(Date.Now, "dd/MMM/yyyy") & "</b></font>"
        tr3.Controls.Add(td31)

        tb.Controls.Add(tr3)

        Dim l11 As New TableRow
        Dim ld11 As New TableCell
        ld11.Attributes.Add("width", "80%")
        ld11.ColumnSpan = 80
        ld11.HorizontalAlign = HorizontalAlign.Center
        ld11.Text = "<font size=3><hr size='1' NOSHADE></font>"
        l11.Controls.Add(ld11)
        tb.Controls.Add(l11)


        Dim tr4 As New TableRow
        tr4.BackColor = Drawing.Color.Cornsilk
        Dim td41 As New TableCell
        td41.Attributes.Add("width", "80%")
        td41.ColumnSpan = 35
        td41.HorizontalAlign = HorizontalAlign.Center
        td41.Text = "<font size=2.5 color=Maroon><BR><b> EMPLOYEE NAME&nbsp:&nbsp" & dt1.Rows(0)(0) & "</b></font>"
        tr4.Controls.Add(td41)


        Dim td411 As New TableCell
        td411.Attributes.Add("width", "80%")
        td411.ColumnSpan = 55
        td411.HorizontalAlign = HorizontalAlign.Center
        td411.Text = "<font size=2.5 color=Maroon><BR><b> EMPLOYEE CODE&nbsp:&nbsp" & emp & "</b></font>"
        tr4.Controls.Add(td411)
        tb.Controls.Add(tr4)

        Dim tr8 As New TableRow
        tr8.BackColor = Drawing.Color.Cornsilk
        Dim td441 As New TableCell
        td441.Attributes.Add("width", "80%")
        td441.ColumnSpan = 35
        td441.HorizontalAlign = HorizontalAlign.Center
        td441.Text = "<font size=2.5 color=Maroon><BR><b> DEPARTMENT&nbsp:&nbsp" & dt1.Rows(0)(3) & "</b></font>"
        tr8.Controls.Add(td441)


        Dim td414 As New TableCell
        td414.Attributes.Add("width", "80%")
        td414.ColumnSpan = 55
        td414.HorizontalAlign = HorizontalAlign.Center
        td414.Text = "<font size=2.5 color=Maroon><BR><b> DESIGNATION&nbsp:&nbsp" & dt1.Rows(0)(4) & "</b></font>"
        tr8.Controls.Add(td414)
        tb.Controls.Add(tr8)


        Dim l1 As New TableRow
        Dim ld1 As New TableCell
        ld1.Attributes.Add("width", "80%")
        ld1.ColumnSpan = 80
        ld1.HorizontalAlign = HorizontalAlign.Center
        ld1.Text = "<font size=3><hr size='2' NOSHADE></font>"
        l1.Controls.Add(ld1)
        tb.Controls.Add(l1)

        Dim tr5 As New TableRow
        Dim td51 As New TableCell
        td51.Attributes.Add("width", "10%")
        td51.ColumnSpan = 8
        td51.HorizontalAlign = HorizontalAlign.Left
        td51.Text = "<font size=2.5><b>DATE</b></font>"
        tr5.Controls.Add(td51)

        Dim td541 As New TableCell
        td541.Attributes.Add("width", "10%")
        td541.ColumnSpan = 7
        td541.HorizontalAlign = HorizontalAlign.Left
        td541.Text = "<font size=2.5><b></b></font>"
        tr5.Controls.Add(td541)

        Dim td54 As New TableCell
        td54.Attributes.Add("width", "25%")
        td54.ColumnSpan = 15
        td54.HorizontalAlign = HorizontalAlign.Left
        td54.Text = "<font size=2.5><b>MORNING TIME</b></font>"
        tr5.Controls.Add(td54)

        Dim td55 As New TableCell
        td55.Attributes.Add("width", "10%")
        td55.ColumnSpan = 7
        td55.HorizontalAlign = HorizontalAlign.Left
        td55.Text = "<font size=2.5><b></b></font>"
        tr5.Controls.Add(td55)

        Dim td56 As New TableCell
        td56.Attributes.Add("width", "25%")
        td56.ColumnSpan = 15
        td56.HorizontalAlign = HorizontalAlign.Left
        td56.Text = "<font size=2.5><b>EVENING TIME</b></font>"
        tr5.Controls.Add(td56)

        Dim td57 As New TableCell
        td57.Attributes.Add("width", "10%")
        td57.ColumnSpan = 7
        td57.HorizontalAlign = HorizontalAlign.Left
        td57.Text = "<font size=2.5><b></b></font>"
        tr5.Controls.Add(td57)

        Dim td58 As New TableCell
        td58.Attributes.Add("width", "25%")
        td58.ColumnSpan = 15
        td58.HorizontalAlign = HorizontalAlign.Center
        td58.Text = "<font size=2.5><b>REMARKS</b></font>"
        tr5.Controls.Add(td58)
        tb.Controls.Add(tr5)
        tb.Controls.Add(tr5)

        Dim l2 As New TableRow
        Dim ld2 As New TableCell
        ld2.Attributes.Add("width", "100%")
        ld2.ColumnSpan = 80
        ld2.HorizontalAlign = HorizontalAlign.Center
        ld2.Text = "<font size=3><hr size='2' NOSHADE></font>"
        l2.Controls.Add(ld2)
        tb.Controls.Add(l2)

        For Each dr In dt.Rows
            Dim tr6 As New TableRow
            If (color = 0) Then
                tr6.BackColor = Drawing.Color.GhostWhite
                color = 1
            Else
                tr6.BackColor = Drawing.Color.WhiteSmoke
                color = 0
            End If

            Dim td61 As New TableCell
            td61.Attributes.Add("width", "10%")
            td61.ColumnSpan = 8
            td61.HorizontalAlign = HorizontalAlign.Left
            td61.Text = "<font size=2>" & Format(dr(0), "dd/MMM/yyyy") & "</font>"
            tr6.Controls.Add(td61)

            Dim td641 As New TableCell
            td641.Attributes.Add("width", "10%")
            td641.ColumnSpan = 7
            td641.HorizontalAlign = HorizontalAlign.Left
            td641.Text = "<font size=2></font>"
            tr6.Controls.Add(td641)


            Dim td64 As New TableCell
            td64.Attributes.Add("width", "25%")
            td64.ColumnSpan = 15
            td64.HorizontalAlign = HorizontalAlign.Left
            td64.Text = "<font size=2>" & dr(1) & "</font>"
            tr6.Controls.Add(td64)


            Dim td65 As New TableCell
            td65.Attributes.Add("width", "10%")
            td65.ColumnSpan = 7
            td65.HorizontalAlign = HorizontalAlign.Left
            td65.Text = "<font size=2></font>"
            tr6.Controls.Add(td65)


            Dim td66 As New TableCell
            td66.Attributes.Add("width", "25%")
            td66.ColumnSpan = 15
            td66.HorizontalAlign = HorizontalAlign.Left
            td66.Text = "<font size=2>" & dr(2) & "</font>"
            tr6.Controls.Add(td66)


            Dim td67 As New TableCell
            td67.Attributes.Add("width", "10%")
            td67.ColumnSpan = 7
            td67.HorizontalAlign = HorizontalAlign.Left
            td67.Text = "<font size=2></font>"
            tr6.Controls.Add(td67)

            Dim td68 As New TableCell
            td68.Attributes.Add("width", "25%")
            td68.ColumnSpan = 15
            td68.HorizontalAlign = HorizontalAlign.Center
            td68.Text = "<font size=2>" & dr(3) & "</font>"
            tr6.Controls.Add(td68)
            tb.Controls.Add(tr6)

        Next

        Dim l3 As New TableRow
        Dim ld3 As New TableCell
        ld3.Attributes.Add("width", "100%")
        ld3.ColumnSpan = 80
        ld3.HorizontalAlign = HorizontalAlign.Center
        ld3.Text = "<font size=3><b><hr size='2' NOSHADE></b></font>"
        l3.Controls.Add(ld3)
        tb.Controls.Add(l3)

        Me.Panel1.Controls.Add(tb)
    End Sub
End Class
